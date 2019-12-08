using System;
using OxyData.Data;

namespace Bar.Business
{
    /// <summary>
    /// Encapsulates the values required for paging through a collection or table
    /// </summary>
    public partial class PagingInfo
    {
        #region Fields
        private int _PageSize;
        private int _StartingRowNumber;
        private int _PageNr;
        private bool _GetAll;
        private long _TotalCount;
        private CollectionSortInfo _SortInfo;

        #endregion

        #region Properties
        /// <summary>
        /// Information that will enable sorting.
        /// </summary>
        public CollectionSortInfo SortInfo
        {
            get { return _SortInfo; }
            set { _SortInfo = value; }
        }

        /// <summary>
        /// The total count of all the items or rows. This is a returned value and will be set after the call is made
        /// </summary>
        public long TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; }
        }

        /// <summary>
        /// If this is set to true, the underlying service or layer will not implement paging. Rather, all items are returned
        /// </summary>
        public bool GetAll
        {
            get { return _GetAll; }
            set { _GetAll = value; }
        }

        /// <summary>
        /// The page to return. (example: page '1', or page '2')
        /// This is used in conjunction with PageSize to return paged data. 
        /// If this is set to '-1', then the StartingRowNumber is required and will be used in conjunction with PageSize. 
        /// </summary>
        public int PageNr
        {
            get { return _PageNr; }
            set { _PageNr = value; }
        }

        /// <summary>
        /// The one-based index of the row to return. By default, the value of the PageNr is used instead of the StartingRowNumber.
        /// If the PageNr value is '-1', then StartingRowNumber will be used.
        /// </summary>
        public int StartingRowNumber
        {
            get { return _StartingRowNumber; }
            set { _StartingRowNumber = value; }
        }

        /// <summary>
        /// the number of items to return
        /// </summary>
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor. this constructor sets GetAll to 'true'. 
        /// If this constructor is used and the paging properties are then assigned, set 'GetAll' to false to implement paging
        /// </summary>
        public PagingInfo()
        {
            _GetAll = true;
        }

        public PagingInfo(int pageSize, int startingRowNumber, int pageNr)
        {
            _PageSize = pageSize;
            _StartingRowNumber = startingRowNumber;
            _PageNr = pageNr;
            _GetAll = false;
        }

        #endregion

        #region internal Methods
        /// <summary>
        /// Checks the values of the properties and adjusts them if required
        /// </summary>
        internal void Normalize()
        {
            if (PageNr <= -1)
            {
                if (StartingRowNumber <= -1)
                {
                    GetAll = true;
                }
                else
                {
                    if (StartingRowNumber < 1)
                        StartingRowNumber = 1;
                }
            }
            else
            {
                if (PageNr == 0 && StartingRowNumber == 0 && PageSize == 0)
                {
                    GetAll = true;
                    return;
                }

                if (PageNr == 0 && StartingRowNumber == 0 && PageSize > 0)
                {
                    PageNr = 1;
                    return;
                }

                if (PageNr == 0 && StartingRowNumber > 0 && PageSize > 0)
                {
                    PageNr = -1;
                    return;
                }
            }
        }
        #endregion
    }
}