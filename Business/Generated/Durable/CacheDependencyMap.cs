/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace OxyData.Data.Caching
{
    [Serializable]
    public partial class CacheDependencyMap
    {
        #region Fields 
        private List<CacheDependencyMapping> _Mappings;
        #endregion

        #region Properties 
        public List<CacheDependencyMapping> Mappings
        {
            get { return _Mappings; }
        }
        #endregion

        #region Constructors 
        public CacheDependencyMap() 
        {
            _Mappings = new List<CacheDependencyMapping>(0);
        }
        #endregion

        public List<string> GetDependentTypes(string dependency)
        {
            List<string> dependents=null;

            if (! string.IsNullOrEmpty(dependency))
            {
                dependency = CacheDependencyMapping.ProcessDependencyString(dependency);

                foreach (CacheDependencyMapping cdm in _Mappings)
                {
                    if (string.Equals(cdm.Dependency, dependency, StringComparison.Ordinal))
                    {
                        dependents = cdm.DependentTypes;
                        break;
                    }
                }
            }

            if (dependents == null)
            {
                dependents = new List<string>(0);
            }

            return dependents;

        }

    }
}