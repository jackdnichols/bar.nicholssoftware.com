//----------------------------------------------------------OCG Version: 3.7.0.0
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0
using System;
using System.Collections.Generic;
using System.Text;

namespace OxyData.Data.Caching
{
    internal partial class Cache:CacheBase
    {
        #region Fields 
        private Dictionary<string, object> _StoreNull;
        private Dictionary<string, object>  _Store0;
        private Dictionary<string, object>  _Store1;
        private Dictionary<string, object>  _Store2;
        private Dictionary<string, object>  _Store3;
        private Dictionary<string, object>  _Store4;
        private Dictionary<string, object>  _Store5;
        private byte                        _NextCacheNr;
        private Dictionary<string, byte>    _CachedTypes;
        private object _NextCacheNrSyncLock;
        private readonly bool _Enabled = true;

        /// <summary>
        /// Determines if data will be stored in this instance. The default is true. 
        /// </summary>
        internal bool Enabled
        {
            get { return _Enabled; }
        }
        #endregion

        #region Constructors 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disabled"></param>
        internal Cache(bool disabled):this()
        {
            _Enabled = (!disabled);
        }
        internal Cache()
        {
             InitializeCaches();
            _NextCacheNrSyncLock    = new object();
            _CachedTypes            = new Dictionary<string, byte>(10);
            _NextCacheNr            = 0;
        }
        #endregion

        #region Internal Methods 

       public override void ExpireTypes(List<string> typeNames)
        {
            if (_Enabled)
            {
                List<byte> cacheNrs = new List<byte>(6);

                foreach (string typename in typeNames)
                {
                    byte nr = byte.MaxValue;
                    try
                    {
                        nr = _CachedTypes[typename];
                    }
                    catch { }

                    if (nr != byte.MaxValue)
                    {
                        if (!cacheNrs.Contains(nr))
                        {
                            cacheNrs.Add(nr);
                        }
                    }
                }

                List<Dictionary<string, object>> caches = new List<Dictionary<string, object>>(6);

                foreach (byte nr in cacheNrs)
                {
                    ReInitializeStore(nr);
                }
            }
        }

        public override void SetData(object data, string typeName, string methodName, params object[] queryParameters)
        {
            if (_Enabled)
            {
                if (data == null)
                    throw new ArgumentNullException("data", "a null object can't be added to the cache");

                if (string.IsNullOrEmpty(typeName))
                    throw new ArgumentException("typeName");

                if (string.IsNullOrEmpty(methodName))
                    throw new ArgumentException("methodName");

                byte cacheNr = GetCacheNr(typeName);

                Dictionary<string, object> store = GetStore(cacheNr);

                StringBuilder key = DeriveKey(typeName, methodName, queryParameters);

                lock (store)
                {
                    store[key.ToString()] = data;
                }
            }
        }

        internal object GetData(string typeName, string methodName, bool isRemove, params object[] queryParameters) 
        {
            object value = null;

            if (_Enabled)
            {
                byte cacheNr = GetCacheNr(typeName);

                Dictionary<string, object> store = GetStore(cacheNr);

                string key = DeriveKey(typeName, methodName, queryParameters).ToString();

                lock (store)
                {
                    if (store.ContainsKey(key))
                    {
                        value = store[key];

                        if (isRemove)
                        {
                            store.Remove(key);
                        }
                    }
                    else
                    {
                        value = null;
                    }
                }
            }

            return value;
        }

        public override object GetData(string typeName, string methodName, params object[] queryParameters)
        {
            return GetData(typeName, methodName, false, queryParameters);
        }

        public override object ExpireItem(string typeName, string methodName, params object[] queryParameters)
        {
            return GetData(typeName, methodName, true, queryParameters);
        }
        #endregion

        #region Private Methods 
        private Dictionary<string, object> GetStore(byte cacheNr)
        {

            switch (cacheNr)
            {
                case 0:
                    return _Store0;

                case 1:
                    return _Store1;

                case 2:
                    return _Store2;

                case 3:
                    return _Store3;

                case 4:
                    return _Store4;

                case 5:
                    return _Store5;

                default:
                    return _StoreNull;
            }
        }

        private void SetNextCacheNr()
        {
            lock (_NextCacheNrSyncLock)
            {
                _NextCacheNr++;

                if (_NextCacheNr > 5)
                {
                    _NextCacheNr = 0;
                }
            }

        }

        private byte GetCacheNr(string typeName)
        {
            byte retval = 0;

            lock (_CachedTypes)
            {
                if (_CachedTypes.ContainsKey(typeName))
                {
                    retval = _CachedTypes[typeName];
                }
                else
                {
                    _CachedTypes[typeName] = _NextCacheNr;
                    retval = _NextCacheNr;

                    SetNextCacheNr();
                }
            }

            return retval; 

        }

        private void InitializeCaches()
        {
            _StoreNull = new Dictionary<string, object>(1);
            _Store0 = new Dictionary<string, object>(5);
            _Store1 = new Dictionary<string, object>(5);
            _Store2 = new Dictionary<string, object>(5);
            _Store3 = new Dictionary<string, object>(5);
            _Store4 = new Dictionary<string, object>(5);
            _Store5 = new Dictionary<string, object>(5);
        }

        private void ReInitializeStore(byte cacheNr)
        {
            switch (cacheNr)
            {
                case 0:
                    _Store0 = new Dictionary<string, object>(5);
                    break;
                case 1:
                    _Store1 = new Dictionary<string, object>(5);
                    break;

                case 2:
                    _Store2 = new Dictionary<string, object>(5);
                    break;

                case 3:
                    _Store3 = new Dictionary<string, object>(5);
                    break;

                case 4:
                    _Store4 = new Dictionary<string, object>(5);
                    break;

                case 5:
                    _Store5 = new Dictionary<string, object>(5);
                    break;

                default:
                    _StoreNull = new Dictionary<string, object>(1);
                    break;
            }
        }
        #endregion
    }
}