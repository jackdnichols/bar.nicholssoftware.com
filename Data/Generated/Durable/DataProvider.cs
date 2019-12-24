/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;
using OxyData.Data;

namespace OxyData.Data
{
    /// <summary>
    /// Provides centralized access to the current data provider
    /// </summary>
    public static partial class DataProvider<T> where T: SpecificDataProviderBase , new()
    {
        #region Fields 
        private static T  _Current = null;
        #endregion

        #region Properties 

        public static T Current
        {
            get
            {
                return _Current;
            }
        }

        #endregion


        #region Constructors

        static DataProvider()
        {
            _Current = new T();
        }
        #endregion
    }
}
