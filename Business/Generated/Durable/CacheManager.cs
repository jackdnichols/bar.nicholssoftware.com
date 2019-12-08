/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace OxyData.Data.Caching
{
    public partial class CacheManager:IDisposable
    {
        #region Fields 
        private bool _Disposed;
        private ChangeNotifier      _SQLChangeNotifier;
        private object              _DataChangedEventSyncLock;
        private CacheDependencyMap  _DependencyMap;
        private CacheBase _Cache;
        #endregion

        #region Constructors 

        public CacheManager(string connectionString, CacheDependencyMap dependencyMap, string[] statementsToWatch, bool throwExceptionOnNotificationFailure, bool deactivateCachingOnNotificationFailure)
        {
            if (dependencyMap == null)
            {
                throw new ArgumentNullException("dependencyMap");
            }

            if (string.IsNullOrEmpty(connectionString) )
            {
                throw new ArgumentNullException("connectionString");
            }

            _DependencyMap = dependencyMap;

            _Cache = CreateCache();

            _DataChangedEventSyncLock       = new object();
            _SQLChangeNotifier              = new ChangeNotifier(connectionString);
            _SQLChangeNotifier.DataChanged += new DataChangeEvent(SQLChangeNotifier_DataChanged);

            if (statementsToWatch != null && statementsToWatch.Length > 0)
            {
                try
                {
                    AddWatch(statementsToWatch);
                }
                catch (Exception XC)
                {
                    if (throwExceptionOnNotificationFailure)
                        throw new Exception("Error adding change notification to Cache Manager (SQLDependency)", XC);

                    if (deactivateCachingOnNotificationFailure)
                        _Cache = CreateDisabledCache();
                }
            }
        }
        
        #endregion

        #region Public Methods 
        
        /// <summary>
        /// A disabled instance of a class derived from CacheBase. 
        /// </summary>
        internal virtual CacheBase CreateDisabledCache()
        {
            return new Cache(true);
        }
        
        /// <summary>
        /// Override this method to change the class used as the Cache. The CreateDisabledCache method should also be overriden
        /// </summary>
        internal virtual CacheBase CreateCache()
        {
            return new Cache();
        }

        public virtual void SQLChangeNotifier_DataChanged(object caller, SqlNotificationEventArgs e, SQLStatementInfo sqlStatmentInfo)
        {
            lock (_DataChangedEventSyncLock)
            {
                List<string> dependents = _DependencyMap.GetDependentTypes(sqlStatmentInfo.TableName);

                _Cache.ExpireTypes(dependents);

            }
        }

        public object ExpireItem(string typeName, string methodName, params object[] queryParameters)
        {
            return _Cache.ExpireItem(typeName, methodName, queryParameters);
        }

        public void ExpireTypes(List<string> typeNames)
        {
            _Cache.ExpireTypes(typeNames);
        }

        public object GetData(string typeName, string methodName, params object[] queryParameters)
        {
            return _Cache.GetData(typeName, methodName, queryParameters);
        }

        public void SetData(object data, string typeName, string methodName, params object[] queryParameters)
        {
            _Cache.SetData(data, typeName, methodName, queryParameters);
        }

        #endregion

        #region Private Methods 
        
        private void AddWatch(SQLStatementInfo[] statementsToWatch)
        {
            try
            {
                _SQLChangeNotifier.AddToWatchList(statementsToWatch);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error adding SQLStatementInfo types to watch",Ex) ;
            }
        }

        private void AddWatch(string[] statementsToWatch)
        {
            List<SQLStatementInfo> sqlInfo = new List<SQLStatementInfo>(statementsToWatch.Length);

            foreach (string s in statementsToWatch)
            {
                sqlInfo.Add(GetStatementInfo(s));
            }

            AddWatch(sqlInfo.ToArray());
        }

        private SQLStatementInfo GetStatementInfo(string statementText)
        {
            statementText = statementText.ToLower();
            string[] textParts = statementText.Split(new string[] { "from" }, StringSplitOptions.RemoveEmptyEntries);

            string columnNames = textParts[0].Replace("select", string.Empty).Trim();
            string[] columnList = columnNames.Split(',');

            string tableName = textParts[1].Trim();

            return new SQLStatementInfo(statementText, tableName, Guid.NewGuid(), columnList);
        }
        #endregion

        
        #region Dispose Pattern 

        private void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    if (_SQLChangeNotifier!=null)
                    {
                        _SQLChangeNotifier.Dispose();
                    }   
                }
                _Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
            
        }

        ~CacheManager() 
        {
            Dispose(false);
        }
        #endregion
    }
}