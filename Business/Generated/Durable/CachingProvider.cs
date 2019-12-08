using System;
/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System.Collections.Generic;
using System.Text;

namespace OxyData.Data
{
    public partial class CachingProvider:IDisposable
    {
        #region Fields 
        private bool _Disposed;
        private  OxyData.Data.Caching.CacheManager _Cache;
        private string _NotificationConnectionString;
        private bool _DeactivateCachingOnNotificationFailure = true;
        private bool _ThrowExceptionOnNotificationFailure = false;

        private static CachingProvider _Current;

        #endregion

        #region Properties 
        public static CachingProvider Current
        {
            get { return _Current; }
        }

        /// <summary>
        /// Returns the active cache manager;
        /// </summary>
        public  OxyData.Data.Caching.CacheManager Cache
        {
            get
            {
                return _Cache;
            }
        }
        #endregion
        
        #region Constructors 

        private CachingProvider()
        {
            SetNotificationConnectionString();

            _Cache = new  OxyData.Data.Caching.CacheManager(_NotificationConnectionString, ChangeNotificationWatch.StaticMap, ChangeNotificationWatch.GetStatementsToWatch(), _ThrowExceptionOnNotificationFailure, _DeactivateCachingOnNotificationFailure);
        }

        static CachingProvider()
        {
            _Current = new CachingProvider();
        }

        #endregion 

        #region Methods 
        /// <summary>
        /// If the notification connection field is null or empty, attempts to get the value from the config file
        /// </summary>
        protected virtual void SetNotificationConnectionString()
        {
            if (string.IsNullOrEmpty(_NotificationConnectionString))
            {
                try
                {
                    _NotificationConnectionString = System.Configuration.ConfigurationManager.AppSettings["NotificationConnectionString"];
                }
                catch (Exception XC)
                {
                    throw new Exception("unable to determine connection string. The AppSettings config key used was: 'NotificationConnectionString' ", XC);
                }
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
                    if (_Cache!=null)
                    {
                        _Cache.Dispose();
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

        ~CachingProvider() 
        {
            Dispose(false);
        }
        #endregion

    }
}