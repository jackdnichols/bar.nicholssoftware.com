

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;
using OxyData.Data;
using OxyData.Data.Caching;

namespace OxyData.Data
{
      public static partial class ChangeNotificationWatch
   {
        /// <summary/>
        /// 
        public static OxyData.Data.Caching.CacheDependencyMap StaticMap
        {

            get
            {
               OxyData.Data.Caching.CacheDependencyMap dependencyMap = new OxyData.Data.Caching.CacheDependencyMap();

               return dependencyMap;
            }

        }

        /// <summary>
        /// Returns an array of T-SQL statements that will be used by the notification system to determine when notification will be fired for table changes.
        /// </summary>
        public static string[] GetStatementsToWatch()
        {
            return new string[]{};
        }

   }

}

