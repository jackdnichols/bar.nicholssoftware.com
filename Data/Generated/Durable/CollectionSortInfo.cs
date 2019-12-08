using System;
using System.Collections.Generic;

using System.Text;

namespace OxyData.Data
{
    public class CollectionSortInfo
    {
        private string _TargetEntityTypeName;
        private string _OperationName;
        private List<FieldSortInfo> _SortInfoList;

        public bool IsValid
        {
            get { return CheckValidity(); }
        }

        public string OperationName
        {
            get { return _OperationName; }
            set { _OperationName = value; }
        }

        public List<FieldSortInfo> SortInfoList
        {
            get { return _SortInfoList; }
            internal set { _SortInfoList = value; }
        }

        public string TargetEntityTypeName
        {
            get { return _TargetEntityTypeName; }
            set { _TargetEntityTypeName = value; }
        }

        private bool CheckValidity()
        {
            bool valid;

            if (_SortInfoList!=null && _SortInfoList.Count>0)
            {
                valid=_SortInfoList.TrueForAll(p => p.IsValid);
            }
            else
            {
                valid = false;
            }

            return valid;
        }

        public CollectionSortInfo(List<FieldSortInfo> sortInfoList)
        {
            _SortInfoList = sortInfoList;
        }
        
    }
}
