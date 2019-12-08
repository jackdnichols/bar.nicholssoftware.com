using System;
using System.Collections.Generic;

using System.Text;

namespace OxyData.Data
{
    public static partial class DbStatementResultSetInfoProvider
    {
        public static DbStatementResultSetInfo GetDbStatementInfo(string statementName)
        {
            DbStatementResultSetInfo val=null;
            if (_ResultSetInfoList!=null && _ResultSetInfoList.Length>0)
            {
                foreach (DbStatementResultSetInfo dbsi in _ResultSetInfoList)
                {
                    if (statementName.Equals(dbsi.StatementName, StringComparison.Ordinal))
                    {
                        val = dbsi;
                        break;
                    }
                }
            }

            return val;
        }
    }
}
