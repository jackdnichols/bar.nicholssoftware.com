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
    public partial class CacheDependencyMapping
    {
        private string _Dependency;
        private List<string> _DependentTypes;

        public List<string> DependentTypes
        {
            get { return _DependentTypes; }
            set { _DependentTypes = value; }
        } 

        [XmlAttribute]
        public string Dependency
        {
            get 
            { 
                return _Dependency; 
            }
            set 
            { 
                _Dependency = ProcessDependencyString(value); 
            }
        }

        public CacheDependencyMapping() { }

        public CacheDependencyMapping(string dependency, string[] dependentTypes)
        {
            if (string.IsNullOrEmpty(dependency))
            {
                throw new ArgumentException("dependency");
            }

            if (dependentTypes == null || dependentTypes.Length == 0)
            {
                throw new ArgumentException("dependentTypes");
            }

            Dependency     = dependency;

            DependentTypes = new List<string>( dependentTypes);

        }

        internal static string ProcessDependencyString(string dependency)
        {
            StringBuilder sb = new StringBuilder(dependency);
            return sb.Replace("[", "").Replace("]", "").ToString().ToUpper(System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}