/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace OxyData.Data
{
    internal static class ApplicationManager
    {
        /// <summary>
        /// Logs operations on a method by method basis
        /// </summary>
        internal static void LogActivity(object source, MethodBase currentMethod, params object[] parameterValues)
        {
 
        }

        /// <summary>
        /// Given a filename, returns an open stream to that file. The path to the Application Base directory is added to the given filename
        /// </summary>
        internal static FileStream GetReadOnlyFileStream(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("The name of the file must be specified", fileName);
            }
            FileStream fs=null;

            List<string> basePaths = GetDirectorySearchPaths();

            foreach (string basePath in basePaths)
            {
                if ( ! string.IsNullOrEmpty(basePath))
                {
                    string fullPath = Path.Combine(basePath, fileName);

                    if (File.Exists(fullPath))
                    {
                        fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        break;
                    }
                }
            }

            return fs;
        }
        /// <summary>
        /// Get the paths that will be search for files that app needs to run
        /// </summary>
        internal static List<string> GetDirectorySearchPaths()
        {
            AppDomain currentDomain = System.AppDomain.CurrentDomain;
            List<string> searchPaths = new List<string>(5);
            searchPaths.Add(currentDomain.RelativeSearchPath);
            searchPaths.Add(currentDomain.BaseDirectory);

            return searchPaths;
        }
    }
}