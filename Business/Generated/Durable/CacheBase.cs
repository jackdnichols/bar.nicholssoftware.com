/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OxyData.Data.Caching
{
    public abstract partial class CacheBase
    {
        #region Constructors 
        internal CacheBase()
        { }
        #endregion

        #region Internal Methods 

        public abstract object ExpireItem(string typeName, string methodName, params object[] queryParameters);

        public abstract void ExpireTypes(List<string> typeNames);

        public abstract object GetData(string typeName, string methodName, params object[] queryParameters);

        public abstract void SetData(object data, string typeName, string methodName, params object[] queryParameters);

        #endregion

        #region Public Methods 

        public virtual StringBuilder DeriveKey(string typeName, string methodName, params object[] queryParameters)
        {
            StringBuilder sb = new StringBuilder(100);

            if (queryParameters != null)
            {
                foreach (object o in queryParameters)
                {
                    sb.Append(o);
                }
            }
            sb.Append(methodName);
            sb.Append(typeName);

            return sb;
        }

        #endregion
    }
}