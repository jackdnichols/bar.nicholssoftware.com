/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.Common;

namespace OxyData.Data
{
    public sealed class TransactionBoundConnectionManager
    {
        #region Fields 
        private static object _ActiveManagerLock;
        private int _KillTime = 120000; //2 mins
        private System.Threading.Timer _AutoKillTimer;
        private bool _AutoKillStarted;
        private Transaction _CurrentTransaction;
        private DbConnection _CurrentConnection;
        private static Dictionary<string, TransactionBoundConnectionManager> _ActiveManagers;
        #endregion

        #region Constructors 

        static TransactionBoundConnectionManager()
        {
            try
            {
                _ActiveManagerLock = new object();
                _ActiveManagers = new Dictionary<string, TransactionBoundConnectionManager>(5);
            }
            catch (Exception xc)
            {
                throw new TypeInitializationException("OxyData.Data.TransactionInstanceManager", xc);
            }
        }

        private TransactionBoundConnectionManager(Transaction tran) 
        {
            _CurrentTransaction = tran;
        }
        #endregion

        #region Private Methods 
        
        private static TransactionBoundConnectionManager GetManager(Transaction tran)
        {
            TransactionBoundConnectionManager tbcManager;
            string key = tran.TransactionInformation.LocalIdentifier;
            lock (_ActiveManagerLock)
            {
                if (_ActiveManagers.ContainsKey(key))
                {
                    tbcManager = _ActiveManagers[key];
                }
                else
                {
                    tbcManager = new TransactionBoundConnectionManager(tran);
                    tran.TransactionCompleted += new TransactionCompletedEventHandler(tbcManager.TransactionCompleted);
                    _ActiveManagers[key] = tbcManager;
                }
            }
            return tbcManager;
        }

        private void TransactionCompleted(object sender, System.Transactions.TransactionEventArgs e)
        {
            TransactionInformation ti = e.Transaction.TransactionInformation;
            if (ti.Status == TransactionStatus.Aborted || ti.Status == TransactionStatus.Committed)
            {
                string key = ti.LocalIdentifier;
                lock (_ActiveManagerLock)
                {
                    //Don't interfere too much - just let go. This will help maintain flexibility for developers
                    if (_ActiveManagers.ContainsKey(key))
                    {
                        TransactionBoundConnectionManager tim = _ActiveManagers[key];
                        if (tim._CurrentConnection != null)
                        {
                            tim._CurrentConnection.Close();
                        }
                        _ActiveManagers.Remove(key);
                    }

                    //if there are other managers around, start their auto kill
                    foreach (TransactionBoundConnectionManager tim in _ActiveManagers.Values)
                    {
                        tim.StartAutoKill();
                    }
                }
            }
        }

        private void StartAutoKill()
        {
            if (!_AutoKillStarted)
            {
                _AutoKillTimer = new System.Threading.Timer(AutoRemove, null, _KillTime, System.Threading.Timeout.Infinite);
                _AutoKillStarted = true;
            }
        }

        private void AutoRemove(object state)
        {
            try
            {
                TransactionInformation ti = _CurrentTransaction.TransactionInformation;

                string key = ti.LocalIdentifier;
                lock (_ActiveManagerLock)
                {
                    if (_ActiveManagers.ContainsKey(key))
                    {
                        try
                        {
                            TransactionBoundConnectionManager tim = _ActiveManagers[key];
                            if (tim._CurrentConnection != null)
                            {
                                tim._CurrentConnection.Close();
                            }
                            _ActiveManagers.Remove(key);
                        }
                        catch 
                        {

                        }
                    }
                }
            }
            catch { }

        }

        #endregion

        #region Public, Internal Methods 

        internal static DbConnection GetAmbientConnection( GetConnection getConnectionMethod)
        {
            DbConnection dbCon;
            Transaction tran = Transaction.Current;

            if (tran == null || tran.TransactionInformation.Status == TransactionStatus.Committed || tran.TransactionInformation.Status == TransactionStatus.Aborted)
            {
                dbCon = null;
            }
            else
            {
                if (getConnectionMethod == null)
                {
                    throw new ArgumentNullException("getConnectionMethod");
                }

                TransactionBoundConnectionManager tim = GetManager(tran);
                dbCon = tim._CurrentConnection;
                if (dbCon==null)
                {
                    dbCon = getConnectionMethod();
                    tim._CurrentConnection = dbCon;
                }
            }

            return dbCon;
        }

        internal static bool IsAmbientConnection(DbConnection currentCon)
        {
            bool isAmbient = false;
            Transaction tran = Transaction.Current;

            if (tran != null )
            {
                TransactionBoundConnectionManager tim = GetManager(tran);

                if (object.ReferenceEquals(tim._CurrentConnection, currentCon))
                {
                    isAmbient=true;
                }
            }

            return isAmbient;
        }

        #endregion
    }
}