using System;
using System.Collections.Generic;

using System.Text;

namespace OxyData.Data
{
    public class FieldSortInfo
    {
        #region Constants 
        public const string ORDER_ASCENDING     = "ASC";
        public const string ORDER_DESCENDING    = "DESC";
        #endregion

        #region Fields 
        private static readonly FieldSortInfo _Empty = new FieldSortInfo(null);
        private string _FieldName;
        private string _SortOrder;
        private bool _IsValid;
        #endregion

        #region Properties 

        public bool IsValid
        {
            get { return _IsValid; }
        }

        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }

        public string SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
        #endregion

        #region Constructors 
        public FieldSortInfo(string fieldName)
        {
            if (IsValidFieldName(fieldName))
            {
                _FieldName = fieldName;
                _IsValid = true;
                _SortOrder = ORDER_ASCENDING;
            }
            else
            {
                _FieldName = null;
                _IsValid = false;
                _SortOrder = null;
            }
        }
        public FieldSortInfo(string fieldName, string sortOrder)
            : this(fieldName)
        {
            if ((!string.IsNullOrEmpty(sortOrder)) &&
                (sortOrder.Equals(ORDER_ASCENDING, StringComparison.OrdinalIgnoreCase) || sortOrder.Equals(ORDER_DESCENDING, StringComparison.OrdinalIgnoreCase)))
            {
                _SortOrder = sortOrder;
            }
            _IsValid = true;
        }
        #endregion

        #region Methods 

        public static FieldSortInfo Empty
        {
            get { return _Empty; }
        }

        public static bool IsValidFieldName(string fieldName)
        {
            bool val=true;
            if (string.IsNullOrEmpty(fieldName))
            {
                val = false;
            }
            else
            {
                foreach (char c in fieldName)
                {
                    if (char.IsLetterOrDigit(c) || c == '_')
                    {

                    }
                    else
                    {
                        val = false;
                        break;
                    }
                }
            }

            return val;
        }

        /// <summary>
        /// Parses a string similart to 'CustomerName;ASC' into a FieldSortInfo Object.
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryParse(string sortExpression, out FieldSortInfo value)
        {
            bool success;
            if (!string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = sortExpression.Trim();
                string[] parts = sortExpression.Split(';',',');
                switch (parts.Length)
                {
                    case 1:
                        success = true;
                        value = new FieldSortInfo(parts[0]);
                        break;
                    case 2:
                        success = true;
                        value = new FieldSortInfo(parts[0],parts[1]);
                        break;
                    default:
                        success = false;
                        value = FieldSortInfo.Empty;
                        break;
                }
            }
            else
            {
                success = false;
                value = FieldSortInfo.Empty;
            }

            return success;
        }
        #endregion
    }
}