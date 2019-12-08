/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;

namespace OxyData.Data
{
    public static partial class ProcedureStorageLocationProvider
    {
        private static Dictionary<string, ProcedureStorageLocationType> _LocationCache;

        static ProcedureStorageLocationProvider()
        {
            try
            {
                _LocationCache = new Dictionary<string, ProcedureStorageLocationType>(_ResourceCommands.Length + _DbCommands.Length);
                foreach (string cmd in _ResourceCommands)
                {
                    _LocationCache.Add(cmd, ProcedureStorageLocationType.Resource);
                }

                foreach (string cmd in _DbCommands)
                {
                    if ( ! _LocationCache.ContainsKey(cmd) )
                    {
                        _LocationCache.Add(cmd, ProcedureStorageLocationType.Db);
                    }
                }
            }
            catch (Exception exception)
            {

                throw new TypeInitializationException(typeof(ProcedureStorageLocationProvider).AssemblyQualifiedName,exception);
            }
        }

        public static ProcedureStorageLocationType GetLocation(string commandName)
        {
            ProcedureStorageLocationType val = ProcedureStorageLocationType.None;

            if (_LocationCache.ContainsKey(commandName))
            {
                val = _LocationCache[commandName];
            }

            return val;
        }

        public static List<string> GetResourceCommands()
        {
            return new List<string>(_ResourceCommands);
        }

        public static List<string> GetDbCommands()
        {
            return new List<string>(_DbCommands);
        }
    }
}