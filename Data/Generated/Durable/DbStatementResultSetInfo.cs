using System;
using System.Collections.Generic;

using System.Text;

namespace OxyData.Data
{
    public class DbStatementResultSetInfo
    {
        private string _StatementName;
        private string[] _FieldColumns;
        Dictionary<string, string> _FieldColumnMaps;

        public Dictionary<string, string> FieldColumnMaps
        {
            get { return _FieldColumnMaps; }
        }

        public string StatementName
        {
            get { return _StatementName; }
        }

        internal DbStatementResultSetInfo(string statementName, params string[] fieldColumns)
        {
            _StatementName = statementName;
            _FieldColumns = fieldColumns == null ? new string[0] : fieldColumns;
        }

        public string GetMappedColumn(string fieldName)
        {
            string val=null;

            if (!string.IsNullOrEmpty(fieldName))
            {
                if (_FieldColumnMaps==null)
                {
                    _FieldColumnMaps = new Dictionary<string, string>(6);
                }

                if (_FieldColumnMaps.ContainsKey(fieldName))
                {
                    val = _FieldColumnMaps[fieldName];
                }
                else
                {
                    foreach (string fc in _FieldColumns)
                    {
                        int divIdx =fc.IndexOf('|');
                        if (divIdx == -1)
                        {
                            if (fc.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                            {
                                val = fieldName;
                                _FieldColumnMaps[fieldName] = fieldName;
                            }
                        }
                        else if (fc.StartsWith(fieldName, StringComparison.Ordinal) && divIdx==fieldName.Length)
                        {
                            val = fc.Substring(divIdx + 1);
                            _FieldColumnMaps[fieldName] = val;
                            break;
                        }
                    }
                }
            }

            return val;
        }

    }
}