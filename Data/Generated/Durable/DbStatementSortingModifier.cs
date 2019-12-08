using System;
using System.Collections.Generic;

using System.Text;

namespace OxyData.Data 
{
    public class DbStatementSortingModifier: DbStatementModifierBase
    {
        private const string KEY_SORTINFO = "D0DB6B7CB46040F6B99E998EA3BA125E";

        private bool _IsValid;
        private CollectionSortInfo _SortingInfo;

        public override string ModificationTypeKey
        {
            get { return KEY_SORTINFO; }
        }


        public override bool IsValid
        {
            get { return _IsValid; }
        }

        private DbStatementSortingModifier(CollectionSortInfo sortingInfo, string statementName)
        {
            if (sortingInfo!=null && sortingInfo.IsValid && (! string.IsNullOrEmpty(statementName)))
            {
                StatementName = statementName;
                _SortingInfo = sortingInfo;
                _IsValid = true;
            }
            else
            {
                _IsValid = false;
            }
        }

        public static void CreateModifier(CollectionSortInfo sortingInfo, string statementName)
        {
            (new DbStatementSortingModifier(sortingInfo, statementName)).AddToModificationManager();
        }
        public override string ProcessStatement(string originalStatement)
        {
            string val=originalStatement;
            if (_IsValid)
            {
                CollectionSortInfo columnSortinfo = ConvertToColumnName(_SortingInfo);
                if (columnSortinfo.IsValid)
                {
                    val = ModifyStatementForSorting(columnSortinfo, originalStatement);
                }
            }
            return val;
        }

        private string ModifyStatementForSorting(CollectionSortInfo columnSortinfo, string originalStatement)
        {
            const string OrderByStart = "ROW_NUMBER()";
            const string OrderByEnd = "RowNumber";
            const string OrderByMid = @" OVER (ORDER BY {0}) as ";
            const string OrderByFragmentFormat = OrderByStart + OrderByMid + OrderByEnd;

            string newOrderByFrag = string.Format(OrderByFragmentFormat, GetOrderByClause(columnSortinfo));

            StringBuilder sb = new StringBuilder(originalStatement);

            int startIdx = originalStatement.IndexOf(OrderByStart);
            int endIdx = originalStatement.IndexOf(OrderByEnd);

            if (startIdx != -1 && endIdx != -1)
            {
                sb.Remove(startIdx, endIdx - startIdx + 1 + OrderByEnd.Length).Insert(startIdx, newOrderByFrag);
            }
            return sb.ToString();
        }

        private string GetOrderByClause(CollectionSortInfo columnSortinfo)
        {

            StringBuilder sb = new StringBuilder();
           
            foreach (FieldSortInfo fsi in columnSortinfo.SortInfoList)
            {
                sb.AppendFormat(@"{0} {1},", fsi.FieldName, fsi.SortOrder);
            }
            
            string val;
            if (sb.Length>0)
            {
                val = sb.ToString(0, sb.Length - 1);
            }
            else
            {
                val = null;
            }

            return val;
        }

        private CollectionSortInfo ConvertToColumnName(CollectionSortInfo _SortingInfo)
        {
            bool success = true;
            DbStatementResultSetInfo resultSetinfo = DbStatementResultSetInfoProvider.GetDbStatementInfo(StatementName);

            if (resultSetinfo == null)
            {
                success = false;
            }
            else
            {
                foreach (FieldSortInfo fsi in _SortingInfo.SortInfoList)
                {
                    string colName = resultSetinfo.GetMappedColumn(fsi.FieldName);
                    if (!string.IsNullOrEmpty(colName))
                    {
                        fsi.FieldName = colName;
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }
            }

            if (!success)
            {
                _SortingInfo.SortInfoList = null;
            }
            return _SortingInfo;
        }

    }
}