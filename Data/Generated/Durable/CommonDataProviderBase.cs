/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using OxyData.Data;

namespace OxyData.Data
{
    public abstract class CommonDataProviderBase
    {
        #region Operation Executed Event 

        private readonly object _OperationExecutedEventLock = new object();
        private static readonly object _StaticOperationExecutedEventLock = new object();

        private OperationExecutedDelegate _OperationExecuted;
        private static OperationExecutedDelegate _StaticOperationExecuted;

        public event OperationExecutedDelegate OperationExecuted
        {
            add
            {
                lock (_OperationExecutedEventLock)
                {
                    _OperationExecuted += value;
                }
            }
            remove
            {
                lock (_OperationExecutedEventLock)
                {
                    _OperationExecuted -= value;
                }
            }
        }

        public static event OperationExecutedDelegate StaticOperationExecuted
        {
            add
            {
                lock (_StaticOperationExecuted)
                {
                    _StaticOperationExecuted += value;
                }
            }
            remove
            {
                lock (_StaticOperationExecutedEventLock)
                {
                    _StaticOperationExecuted -= value;
                }
            }
        }

        protected virtual void OnOperationExecuted(string operationName, object[] outputs)
        {
            OperationExecutedDelegate tmp = _OperationExecuted;
            if (tmp != null)
            {
                tmp(operationName, outputs);
            }
        }

        protected static void OnStaticOperationExecuted(string operationName, object[] outputs)
        {
            OperationExecutedDelegate tmp = _StaticOperationExecuted;
            if (tmp != null)
            {
                tmp(operationName, outputs);
            }
        }

        #endregion

        #region Fields 
        private DbProviderFactory _DBMSProviderFactory;
        private string _ConnectionString;
        private string _NotificationConnectionString;
        private string _DbConnectionStringName = "DBConnectionString";
        private string _NotificationConnectionStringName = "NotificationConnectionString";
        private bool _ContainsStatementModifiers;
        #endregion

        #region Properties 

        protected internal bool ContainsStatementModifiers
        {
            get { return _ContainsStatementModifiers; }
            set { _ContainsStatementModifiers = value; }
        }
        public virtual string NotificationConnectionStringName
        {
            get { return _NotificationConnectionStringName; }
            set { _NotificationConnectionStringName = value; }
        }

        public virtual string DbConnectionStringName
        {
            get { return _DbConnectionStringName; }
            set { _DbConnectionStringName = value; }
        }

        /// <summary>
        /// The name of the DBMS Provider Factory.
        /// Change this to read from a config file if you want to point to a different DBMS
        /// </summary>
        protected abstract string DBMSProviderFactoryName { get; }

        /// <summary>
        /// The connection string used for runtime database connectivity.
        /// </summary>
        public string ConnectionString
        {

            get
            {
                return _ConnectionString;
            }

            set
            {
                _ConnectionString = value;
            }
        }

        #endregion

        #region Internal Methods 
        
        /// <summary>
        /// Logs a call to the database
        /// </summary>
        /// <param name="methodName">The name of the method that made the call</param>
        /// <param name="statementName">The database statement that was called</param>
        /// <param name="rowsAffected">the number of rowsaffected, if any</param>
        /// <param name="connection">The DbConnection object that was used to make the call. 
        /// This is for informational use only, the object is likely to have been finalized</param>
        /// <param name="dbParameters">The parameters that were part of the call</param>
        public static void LogDataActivity(string methodName, string statementName, int rowsAffected, DbConnection connection, DbParameter[] dbParameters)
        {
            //Write logging code here
        }

        /// <summary>
        /// Reads all the bytes from a DataReader column
        /// </summary>
        /// <param name="dataReader">The DataReader to read from</param>
        /// <param name="ordinalPosition">The ordinal of the column to read</param>
        /// <returns>the byte[] from the column</returns>
        protected virtual byte[] ReadBytes(DbDataReader dataReader, int ordinalPosition)
        {
            Byte[] bytes = new Byte[(int)(dataReader.GetBytes(ordinalPosition, 0, null, 0, Int32.MaxValue))];
            dataReader.GetBytes(ordinalPosition, 0, bytes, 0, bytes.Length);

            return bytes;
        }

        /// <summary>
        /// Executes a DB call that returns a SqlDataReader object that can be used to return the results of the stored procedure call
        /// </summary>
        /// <param name="sqlCon">The SqlConnection object to use</param>
        /// <param name="tran">The SqlTransaction object to use for the call. .NET 2.0 introduced System.Transactions which is the 
        /// preferred transactions approach, so this is usually 'null'. If it is not null, the connection object from the transaction will be
        /// used to make the connection</param>
        /// <param name="StoredProcedureName">The name of the stored procedure to call</param>
        /// <param name="inputValues">The array of SqlParameters that is needed for the call</param>
        /// <returns>The SqlDataReader that accesses the results of the DB call</returns>
        protected virtual DbDataReader GetData(DbConnection sqlCon, DbTransaction tran, string storedProcedureName, DbParameter[] inputValues)
        {
            DbCommand cmd = GetCommand(sqlCon, tran, storedProcedureName, inputValues);
            cmd.CommandTimeout = 3600;
            DbDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                try
                {
                    if (sqlCon.State != ConnectionState.Closed)
                    {
                        FinalizeConnection(sqlCon, tran);
                    }
                }
                catch { }

                throw new Exception(string.Format("DB command execution error. {0}", ex.Message), ex);
            }

            return dr;
        }

        /// <summary>
        /// Executes a non-query call that returns the number of rows affected by the call
        /// </summary>
        /// <param name="sqlCon">The SqlConnection object to use</param>
        /// <param name="tran">The SqlTransaction object to use for the call. .NET 2.0 introduced System.Transactions which is the 
        /// preferred transactions approach, so this is usually 'null'. If it is not null, the connection object from the transaction will be
        /// used to make the connection</param>
        /// <param name="StoredProcedureName">The name of the stored procedure to call</param>
        /// <param name="inputValues">The array of SqlParameters that is needed for the call</param>
        /// <returns>The number of rows affected by the call</returns>
        protected virtual int ExecuteNonQuery(DbConnection sqlCon, DbTransaction tran, string storedProcedureName, DbParameter[] inputValues)
        {
            int retval = 0;

            DbCommand cmd = GetCommand(sqlCon, tran, storedProcedureName, inputValues);

            try
            {
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                try
                {
                    if (sqlCon.State != ConnectionState.Closed)
                    {
                        FinalizeConnection(sqlCon, tran);
                    }
                }
                catch { }

                throw new Exception(string.Format("DB command execution error. {0}", ex.Message), ex);
            }

            return retval;

        }

        /// <summary>
        /// Executes a DB call that returns the first cell of the first row
        /// </summary>
        /// <param name="sqlCon">The SqlConnection object to use</param>
        /// <param name="tran">The SqlTransaction object to use for the call. .NET 2.0 introduced System.Transactions which is the 
        /// preferred transactions approach, so this is usually 'null'. If it is not null, the connection object from the transaction will be
        /// used to make the connection</param>
        /// <param name="StoredProcedureName">The name of the stored procedure to call</param>
        /// <param name="inputValues">The array of SqlParameters that is needed for the call</param>
        /// <returns>The value returned</returns>        
        protected virtual object GetScalar(DbConnection sqlCon, DbTransaction tran, string storedProcedureName, DbParameter[] inputValues)
        {
            DbCommand cmd = GetCommand(sqlCon, tran, storedProcedureName, inputValues);

            object obj;
            try
            {
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                try
                {
                    if (sqlCon.State != ConnectionState.Closed)
                    {
                        FinalizeConnection(sqlCon, tran);
                    }
                }
                catch { }

                throw new Exception(string.Format("DB command execution error. {0}", ex.Message), ex);
            }

            return obj;
        }

        /// <summary>
        /// Executes a query call that returns Xml. This is used for Stored Procedures that use the 'FOR XML' clause or return data from an 
        /// Xml Column. The returned XmlReader is open, and uses a connection. in SQL Server 2005, the MARS feature may allow the reuse of the connection
        /// while the XmlReader is still open. In SQL Server 2000, the connection can't be reused and must be closed first.
        /// </summary>
        /// <param name="sqlCon">The SqlConnection object to use</param>
        /// <param name="tran">The SqlTransaction object to use for the call. .NET 2.0 introduced System.Transactions which is the 
        /// preferred transactions approach, so this is usually 'null'. If it is not null, the connection object from the transaction will be
        /// used to make the connection</param>
        /// <param name="StoredProcedureName">The name of the stored procedure to call</param>
        /// <param name="inputValues">The array of SqlParameters that is needed for the call</param>
        /// <returns>The XmlReader object</returns>
        protected virtual System.Xml.XmlReader GetXmlData(DbConnection sqlCon, DbTransaction tran, string storedProcedureName, DbParameter[] inputValues)
        {
            DbCommand cmd = GetCommand(sqlCon, tran, storedProcedureName, inputValues);

            System.Xml.XmlReader xr;
            try
            {
                xr = ExecuteCommandXmlReader(cmd);
            }
            catch (Exception ex)
            {
                try
                {
                    if (sqlCon.State != ConnectionState.Closed)
                    {
                        FinalizeConnection(sqlCon, tran);
                    }
                }
                catch { }

                throw new Exception(string.Format("DB command execution error. {0}", ex.Message),ex);
            }

            return xr;
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object.
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="dbType">The common db type</param>
        /// <param name="length">The length</param>
        protected abstract DbParameter GetDbParameter(string parameterName, DbType dbType, int length);
        /// <summary>
        /// A Provider specific call to return an XmlReader.
        /// Extend the implementation for different providers
        /// </summary>
        protected abstract System.Xml.XmlReader ExecuteCommandXmlReader(DbCommand cmd);

        /// <summary>
        /// Returns a Provider specific DbParameter object, the type is inferred from the value. 
        /// You need to change this manually if you change providers
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="length">The length</param>
        protected abstract DbParameter GetDbParameter(string parameterName, int length);
        /// <summary>
        /// Returns a Provider specific DbParameter object.
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="dbType">The provider specific db type as an int</param>
        /// <param name="length">The length</param>
        protected abstract DbParameter GetDbParameter(string parameterName, CommonDbType dbType, int length);

        /// <summary>
        /// Returns a Provider specific DbParameter object. The DbParameter is created specifically for User Defined Types
        /// </summary>
        protected abstract DbParameter GetDbParameterForUdt(string parameterName, CommonDbType dbType, string userDefinedName, int length);

        /// <summary>
        /// Returns a Provider specific DbParameter object. The DbParameter is created specifically for Structured types (i.e., Table-Valued Parameters)
        /// </summary>
        protected abstract DbParameter GetDbParameterForStructured(string parameterName, CommonDbType dbType, string userDefinedName);

        /// <summary>
        /// Returns a Provider specific DbParameter object. The DbParameter is created specifically for User Defined Types
        /// </summary>
        protected abstract DbParameter GetDbParameterForUdt(string parameterName, CommonDbType dbType, string userDefinedName);

        /// <summary>
        /// Returns a Provider specific DbParameter object.
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="dbType">The provider specific db type as an int</param>
        protected abstract DbParameter GetDbParameter(string parameterName, CommonDbType dbType);

        /// <summary>
        /// Returns a Provider specific DbParameter object, the type is inferred from the value. You need to change this manually if you change providers
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        protected abstract DbParameter GetDbParameter(string parameterName);

        /// <summary>
        /// Returns a Provider specific DbCommand. When the Provider is changed, the type returned will automatically changed
        /// </summary>
        protected virtual DbCommand GetCommand(DbConnection dbCon, DbTransaction tran, string storedProcedureName, DbParameter[] inputValues)
        {
            DbCommand cmd = _DBMSProviderFactory.CreateCommand();

            CommandType commandType;
            cmd.CommandText = GetCommandText(storedProcedureName, out commandType);
            
            cmd.Connection = dbCon;
            cmd.CommandType = commandType;
            cmd.Transaction = tran;

            foreach (DbParameter sp in inputValues)
            {
                cmd.Parameters.Add(sp);
            }

            return cmd;
        }

        /// <summary>
        /// Returns a prepared statement to execute (in case of virtual stored procedures) 
        /// or the name of a stored procedure to execute (in case of stored procedures executed from the database)
        /// </summary>
        /// <param name="StoredProcedureName"></param>       
        private string GetCommandText(string storedProcedureName, out CommandType commandType)
        {
            string val;
            ProcedureStorageLocationType procedureStorageLocationType = ProcedureStorageLocationProvider.GetLocation(storedProcedureName);

            if (procedureStorageLocationType == ProcedureStorageLocationType.None) //Get default
            {
                procedureStorageLocationType = GetSPOption();
            }

            switch (procedureStorageLocationType)
            {
                case ProcedureStorageLocationType.Db:
                    commandType = CommandType.StoredProcedure;
                    val = storedProcedureName;
                    break;
                case ProcedureStorageLocationType.Resource:
                    commandType = CommandType.Text;
                    val = LookUpText(storedProcedureName);
                    break;
                case ProcedureStorageLocationType.None:
                default:
                    throw new InvalidOperationException(string.Format("specified option not implemented. Option was {0}",procedureStorageLocationType));

            }

            return val;
        }

        /// <summary>
        /// Reads a stored procedures storage option from the config file and returns it.
        /// </summary>
        protected virtual ProcedureStorageLocationType GetSPOption()
        {
            string tmp = System.Configuration.ConfigurationManager.AppSettings["ProcedureStorageLocationType"];
            ProcedureStorageLocationType val;
            try
            {
                val = (ProcedureStorageLocationType)Enum.Parse(typeof(ProcedureStorageLocationType), tmp);
            }
            catch (Exception XC)
            {
                throw new InvalidOperationException("Error getting the Procedure storage option from the config file", XC);
            }

            return val;
        }

        /// <summary>
        /// Returns a prepared statement to execute for a given name of the stored procedure.
        /// </summary>
        /// <param name="StoredProcedureName"></param>        
        protected virtual string LookUpText(string storedProcedureName)
        {
            string statement = OxyData.Data.VirtualStoredProcedureStore.GetText(storedProcedureName);
            if (ContainsStatementModifiers)
            {
                statement=DbStatementModificationManager.ModifyDbStatement(storedProcedureName, statement);
            }
            return statement;
        }



        #endregion

        #region Public Methods 
        /// <summary>
        /// If the primary connection field is null or empty, attempts to get the value from the config file
        /// </summary>
        public virtual void SetConnectionString()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                try
                {
                    ConnectionString = System.Configuration.ConfigurationManager.AppSettings[DbConnectionStringName];
                }
                catch (Exception XC)
                {
                    throw new Exception(string.Format("unable to determine connection string. The AppSettings config key used was: {0}",DbConnectionStringName), XC);
                }
            }
        }

        /// <summary>
        /// If the notification connection field is null or empty, attempts to get the value from the config file
        /// </summary>
        public virtual void SetNotificationConnectionString()
        {
            if (string.IsNullOrEmpty(_NotificationConnectionString))
            {
                try
                {
                    _NotificationConnectionString = System.Configuration.ConfigurationManager.AppSettings[NotificationConnectionStringName];
                }
                catch (Exception XC)
                {
                    throw new Exception(string.Format("unable to determine connection string. The AppSettings config key used was: {0}", NotificationConnectionStringName), XC);
                }
            }
        }

        /// <summary>
        /// Creates and returns the primary connection object
        /// </summary>
        public virtual DbConnection GetConnection()
        {

            if (string.IsNullOrEmpty(ConnectionString))
            {
                try
                {
                    ConnectionString = System.Configuration.ConfigurationManager.AppSettings[DbConnectionStringName];
                }
                catch (Exception xc)
                {
                    throw new Exception(string.Format( "unable to determine connection string. The AppSettings config key used was: {0}",DbConnectionStringName), xc);
                }
            }

            DbConnection con = TransactionBoundConnectionManager.GetAmbientConnection(CreateNewConnection);
            if (con == null)
            {
                con = CreateNewConnection();
            }

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        internal DbConnection CreateNewConnection()
        {
            DbConnection con = _DBMSProviderFactory.CreateConnection();
            con.ConnectionString = ConnectionString;
            return con;
        }

        /// <summary>
        /// Closes the connection. If the transaction object is not null, The connection will not be closed. 
        /// You may change this method to handle the finalization in a different way
        /// </summary>
        public static void FinalizeConnection(DbConnection dbCon, DbTransaction tran)
        {
            if (tran == null && (!TransactionBoundConnectionManager.IsAmbientConnection(dbCon)))
            {
                try
                {
                    if (dbCon.State != ConnectionState.Closed)
                    {
                        dbCon.Close();
                    }
                }
                catch
                {
                    //Log error
                }
            }
        }

        /// <summary>
        /// Creates a new DbConnection object. If the DbTransaction object <paramref name="tran"/> tran is not null, 
        /// then it's connection object will be used instead of creating a new one.
        /// </summary>
        /// <param name="tran">A DbTransaction object. This is usually null</param>
        /// <returns>The DbConnection that will be used to access the database</returns>
        public DbConnection InitializeConnection(DbTransaction tran)
        {
            DbConnection sqlcon = null;
            if (tran != null)
            {
                sqlcon = tran.Connection;
            }
            else
            {
                sqlcon = GetConnection();
            }
            
            return sqlcon;
        }


        protected void AttachSortInfoModifier(CollectionSortInfo sortInfo, string storedProcedureName)
        {
            if (sortInfo != null && sortInfo.IsValid)
            {
                ContainsStatementModifiers = true;
                DbStatementSortingModifier.CreateModifier(sortInfo, storedProcedureName);
            }
        }
        
        #endregion

        #region Constructors 
        protected CommonDataProviderBase()
        {
            _DBMSProviderFactory = DbProviderFactories.GetFactory(DBMSProviderFactoryName);

            SetNotificationConnectionString();
            SetConnectionString();
        }
        #endregion

        #region Private Methods 
        /// <summary>
        /// Returns 'true' if the function that assigns row numbers in the database is zero-based, otherwise 'false'
        /// </summary>
        private bool IsDbRowNumberZeroBased
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns 'true' if a row number of zero represents the first row, otherwise 'false'
        /// </summary>
        private bool IsRowNumberZeroBased
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Calculates the variables required for paging.
        /// </summary>
        protected void GetStartRowAndEndRowForPaging(int pageSize, int pageNr, ref int startingRowNumber, out int endingRowNumber, out long totalCount)
        {
            int dbRowNumberAdjustmentValue = (IsDbRowNumberZeroBased ? 0 : 1);
            if (pageNr < 1)
            {
                int rowNrAdjValue = GetRowNumberAdjValue();

                startingRowNumber = startingRowNumber + rowNrAdjValue;


                endingRowNumber = startingRowNumber + (pageSize - 1);
            }
            else
            {
                startingRowNumber = ((pageNr - 1) * pageSize) + dbRowNumberAdjustmentValue;
                endingRowNumber = startingRowNumber + pageSize - 1;
            }

            if (startingRowNumber < 0)
            {
                startingRowNumber = dbRowNumberAdjustmentValue;
            }

            if (endingRowNumber < 0)
            {
                endingRowNumber = dbRowNumberAdjustmentValue;
            }

            //totalCount can't be assigned for DBMSs that can't execute multiple statements.
            //What the follow statement does is add 1 to the endingRowNumber.
            //The real total count should be derived from the 'Get[EntityName]Count' method.
            totalCount = endingRowNumber + 1;
        }

        /// <summary>
        /// Get Row Number Adjustment Value.
        /// </summary>
        protected int GetRowNumberAdjValue()
        {
            int val = int.MinValue;
            if (IsDbRowNumberZeroBased == IsRowNumberZeroBased)
            {
                val = 0;
            }
            else if (IsRowNumberZeroBased && (!IsDbRowNumberZeroBased))
            {
                val = 1;
            }
            else if ((!IsRowNumberZeroBased) && IsDbRowNumberZeroBased)
            {
                val = -1;
            }

            return val;
        }

        #endregion
    }
}