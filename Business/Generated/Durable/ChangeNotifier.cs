/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace OxyData.Data.Caching
{
    public delegate void DataChangeEvent(object caller, SqlNotificationEventArgs e, SQLStatementInfo sqlStatmentInfo);
    
    public partial class ChangeNotifier:IDisposable
    {
        #region Types 

        public class WatchedStatementInfo : SQLStatementInfo
        {
            private SqlCommand _Command;

            public SqlCommand Command
            {
                get { return _Command; }
                set { _Command = value; }
            }

            public WatchedStatementInfo(SQLStatementInfo statementInfo, SqlCommand command) : base (statementInfo)
            {
                if (command == null)
                    throw new ArgumentNullException("command");

                _Command = command;
            }
        }
        #endregion

        #region Private Fields 
        private object _FinalizeLock=new object();
        private bool _Disposed;
        private string _QueryConnectionString;
        private List<WatchedStatementInfo> _WatchList;
        private Dictionary<string, SqlConnection> _Connections;
        private bool _AutoRenewRequest = true;
        private List<SqlDependency> _SQLDependencies;
        private Dictionary<string,int> _StartPerConnection;
        #endregion

        #region Public Properties 
        
        public bool AutoRenewRequest
        {
            get { return _AutoRenewRequest; }
            set { _AutoRenewRequest = value; }
        }

        public string QueryConnectionString
        {
            get { return _QueryConnectionString; }
            set { _QueryConnectionString = value; }
        }
        #endregion

        #region Events 
        public event DataChangeEvent DataChanged;
        #endregion

        #region Constructors 

        public ChangeNotifier(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                _QueryConnectionString = connectionString;
            }

            _WatchList = new List<WatchedStatementInfo>(5);
            _Connections = new Dictionary<string, SqlConnection>(5);
            _StartPerConnection = new Dictionary<string, int>(5);
            _SQLDependencies = new List<SqlDependency>(5);

            //if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            //{
            //    AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            //}
            //else
            //{
            //    AppDomain.CurrentDomain.DomainUnload += new EventHandler(CurrentDomain_DomainUnload);
            //}

        }

        void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            ReverseSqlDependencySetupActivities();
        }

        private void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            ReverseSqlDependencySetupActivities();
        }
        #endregion

        #region Public Methods 

        private void ReverseSqlDependencySetupActivities()
        {
            lock (_FinalizeLock)
            {
                if (_Connections != null && _StartPerConnection != null)
                {
                    foreach (KeyValuePair<string, SqlConnection> kvpConn in _Connections)
                    {
                        string connectionString = kvpConn.Key;
                        SqlConnection conn = kvpConn.Value;

                        int startCount = 0;

                        if (_StartPerConnection.ContainsKey(connectionString))
                        {
                            startCount = _StartPerConnection[connectionString];
                            for (int i = 0; i < startCount; i++)
                            {
                                try
                                {
                                    SqlDependency.Stop(connectionString);
                                }
                                catch { break; }
                            }
                        }

                        if (conn != null)
                        {
                            try
                            {
                                conn.Close();
                            }
                            catch { }
                        }

                    }

                    _Connections = null;
                    _StartPerConnection = null;
                }
            }
        }

        public void AddToWatchList(SQLStatementInfo[] statementInfoList, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("connectionString is null or empty","connectionString");
            }

            if (CanRequestNotifications())
            {
                if (statementInfoList == null)
                {
                    throw new ArgumentNullException("statementInfoList");
                }

                List<WatchedStatementInfo> watchedStatementInfo = GetWatchedStatementInfos(statementInfoList, connectionString);

                _WatchList.AddRange(watchedStatementInfo);

                SqlDependency.Start(connectionString);
                IncrementStartPerConnection(connectionString);

                foreach (WatchedStatementInfo wsi in watchedStatementInfo)
                {
                    _SQLDependencies.Add(SeekNotification(wsi, wsi.Command));
                    wsi.Command.Dispose();
                    wsi.Command = null;
                }
            }
        }

        private void IncrementStartPerConnection(string connectionString)
        {
            _StartPerConnection[connectionString] = (_StartPerConnection[connectionString] + 1);
        }

        public void AddToWatchList(SQLStatementInfo[] statementInfoList)
        {
            AddToWatchList(statementInfoList, _QueryConnectionString);
        }

        #endregion

        #region Private Methods 

        private List<WatchedStatementInfo> GetWatchedStatementInfos(SQLStatementInfo[] statementInfoList, string connectionString)
        {
            List<WatchedStatementInfo> watchedCommands = new List<WatchedStatementInfo>(statementInfoList.Length);
            SqlConnection connection;

            if (_Connections.ContainsKey(connectionString))
            {
                connection = _Connections[connectionString];
            }
            else
            {
                connection = new SqlConnection(connectionString);
                _Connections.Add(connectionString, connection);
                _StartPerConnection.Add(connectionString, 0);
            }

            foreach (SQLStatementInfo ssi in statementInfoList)
            {
                watchedCommands.Add(new WatchedStatementInfo(ssi, new SqlCommand(ssi.Text, connection)));
            }

            return watchedCommands;
        }

        private SqlDependency SeekNotification(SQLStatementInfo sqlInfo, SqlCommand cmd)
        {
            // create dependency associated with cmd
            SqlDependency depend = new SqlDependency(cmd, null, 0);

            // register handler
            depend.OnChange += (delegate(object caller, SqlNotificationEventArgs e)
                                    {

                                        if (DataChanged != null)
                                        {
                                            DataChanged(caller, e, sqlInfo);
                                        }

                                        if (AutoRenewRequest)
                                        {
                                            SeekNotification(sqlInfo, new SqlCommand(cmd.CommandText,cmd.Connection));
                                        }
                                    }
                                );

            if (cmd.Connection.State != System.Data.ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Close();
            
            return depend;

        }

        private bool CanRequestNotifications()
        {
            SqlClientPermission permission = new SqlClientPermission(PermissionState.Unrestricted);
            try
            {
                permission.Demand();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        #endregion

        
        #region Dispose Pattern 

        private void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    ReverseSqlDependencySetupActivities();
                }
                _Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
            
        }

        ~ChangeNotifier() 
        {
            Dispose(false);
        }
        #endregion

    }
}