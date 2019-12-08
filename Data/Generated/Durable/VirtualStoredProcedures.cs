/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
namespace OxyData.Data
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Resources;
    using System.IO;
    using System.Xml;

    internal static class VirtualStoredProcedureStore
    {
        #region Fields
        private static ResourceManager _GeneratedResourceManager;
        private static ResourceManager _CustomResourceManager;

        private static System.Boolean _IsValid;

        private static Dictionary<string, string> _InternalCache;
        #endregion

        #region Constructors
        static VirtualStoredProcedureStore()
        {
            _InternalCache = new Dictionary<string, string>();
            string executingAsmName = Assembly.GetExecutingAssembly().GetName().Name;
            Exception error = null;
            try
            {
                _GeneratedResourceManager = new System.Resources.ResourceManager(executingAsmName + ".Generated.VirtualStoredProcedures", typeof(VirtualStoredProcedureStore).Assembly);

                //Test to see if the resource was successfully loaded
                _GeneratedResourceManager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, false, true);
            }
            catch (Exception XC)
            {
                //Do nothing. A geneated resource file was not included.
                _GeneratedResourceManager = null;
                error = XC;
            }

            try
            {
                _CustomResourceManager = new System.Resources.ResourceManager(executingAsmName + ".Custom.VirtualStoredProcedures", typeof(VirtualStoredProcedureStore).Assembly);

                //Test to see if the resource was successfully loaded
                _CustomResourceManager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, false, true);

            }
            catch (Exception XC)
            {
                //Do nothing. A custom resource file was not included.
                _CustomResourceManager = null;
                error = XC;
            }

            if (!(_GeneratedResourceManager == null && _CustomResourceManager == null))
            {
                _IsValid = true;
                PopulateInternalCache();
            }

            try
            {
                //If the right .xml is included in the base directory, use it to populated the cache
                LoadResourceFromReader("VirtualStoredProcedures.xml");
            }
            catch (Exception xc)
            {
                error = xc;
            }

            try
            {
                //If the right .xml is included in the base directory, use it to populated the cache
                //data from this resource will over-write the previous loads
                LoadResourceFromReader("Custom.VirtualStoredProcedures.xml");
            }
            catch (Exception xc)
            {
                error = xc;
            }


            //if the cache was populated, then this is valid
            if (_InternalCache.Count > 0)
            {
                _IsValid = true;
            }

        }
        #endregion

        #region Private Methods
        private static void PopulateInternalCache()
        {
            if (_InternalCache == null)
            {
                _InternalCache = new Dictionary<string, string>(100);
            }
            List<string> procedureNames = ProcedureStorageLocationProvider.GetResourceCommands();

            if (procedureNames != null && procedureNames.Count > 0)
            {
                foreach (string procName in procedureNames)
                {
                    GetText(procName);
                }
            }
        }
        /// <summary>
        /// Load all the data from the .resx 
        /// </summary>
        /// <param name="fileName">The filename. this should NOT include the full path</param>
        private static void LoadResourceFromReader(string fileName)
        {
            Stream fs = ApplicationManager.GetReadOnlyFileStream(fileName);

            if (fs != null)
            {
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(fs);
                    XmlNodeList nodeList = xDoc.DocumentElement.SelectNodes("data");

                    foreach (XmlNode node in nodeList)
                    {
                        _InternalCache.Add((string)(node.Attributes["name"].Value), (string)(node.ChildNodes[0].InnerXml));
                    }
                }
                finally
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the text of the Virtual Stored Procedure, given the name
        /// </summary>
        public static string GetText(string storedProcedureName)
        {
            if (!_IsValid)
            {
                throw new InvalidOperationException("Both the Custom and Generated VirtualStoredProcedures resource files may be missing.");
            }

            string val = null;

            if (_InternalCache.ContainsKey(storedProcedureName))
            {
                val = _InternalCache[storedProcedureName];
            }
            else
            {
                if (_CustomResourceManager != null)
                {
                    try
                    {
                        val = _CustomResourceManager.GetString(storedProcedureName);
                    }
                    catch { }
                }

                if (val == null && _GeneratedResourceManager != null)
                {
                    try
                    {
                        val = _GeneratedResourceManager.GetString(storedProcedureName);
                    }
                    catch { }
                }

                if (val == null)
                {
                    throw new InvalidOperationException("Virtual Stored Procedure not found in resource files");
                }
                else
                {
                    _InternalCache.Add(storedProcedureName, val);
                }
            }

            return val;

        }
        #endregion
    }
}