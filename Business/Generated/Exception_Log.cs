

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Business
{

   /// <summary>
   /// This is the Primary Domain Model class for Exception_Log.
   /// </summary>
   public partial class Exception_Log 
   {

        #region Fields 

        private Int32 _Exception_Log_Id;
        private String _Exception_Message;
        private String _Name_Space;
        private String _Method;
        private DateTime _Created_Date;
        #endregion 

        #region Properties 

        /// <summary>
        /// The database automatically generates this value.
        /// </summary>
        public virtual Int32 Exception_Log_Id
        {

            get
            {
               return _Exception_Log_Id;
            }

            set
            {
               _Exception_Log_Id = value;
            }
        }

        public virtual String Exception_Message
        {

            get
            {
               return _Exception_Message;
            }

            set
            {
               _Exception_Message = value;
            }
        }

        public virtual String Name_Space
        {

            get
            {
               return _Name_Space;
            }

            set
            {
               _Name_Space = value;
            }
        }

        public virtual String Method
        {

            get
            {
               return _Method;
            }

            set
            {
               _Method = value;
            }
        }

        public virtual DateTime Created_Date
        {

            get
            {
               return _Created_Date;
            }

            set
            {
               _Created_Date = value;
            }
        }

        #endregion 

        #region Default Constructor 

        public Exception_Log()
        {
        }

        #endregion 

        #region Private Methods 

        #endregion 

        #region Constructors 

        internal Exception_Log(Bar.Data.Exception_Log exception_Log)
        {

            Exception_Log_Id = exception_Log.Exception_Log_Id;

            Exception_Message = exception_Log.Exception_Message;

            Name_Space = exception_Log.Name_Space;

            Method = exception_Log.Method;

            Created_Date = exception_Log.Created_Date;

        }

        #endregion 

        #region Public Methods 

        /// <summary>
        /// Returns all instances of Exception_Log.
        /// </summary>
        /// <results>Returns a strongly typed list of Exception_Log. </results>
        public static List<Exception_Log> GetAll()
        {

            List<Bar.Data.Exception_Log> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetAllException_Log();

            List<Exception_Log> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Exception_Log>(dataEntityCollection.Count);
               foreach(Bar.Data.Exception_Log val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Exception_Log(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Exception_Log>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns all instances of Exception_Log. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Exception_Log. </results>
        public static List<Exception_Log> GetAll(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.Exception_Log> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetException_Log(pageSize, startingRowNumber, pageNr, out totalCount);

            List<Exception_Log> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Exception_Log>(dataEntityCollection.Count);
               foreach(Bar.Data.Exception_Log val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Exception_Log(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Exception_Log>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Persists a new instance of Exception_Log to the database.
        /// </summary>
        /// <param name="exception_Log">The instance of exception_Log to persist. </param>
        public static void Insert(Exception_Log exception_Log)
        {
            Int32 exception_Log_Id = exception_Log.Exception_Log_Id;

            Exception_Log.InsertException_Log(exception_Log.Exception_Message, exception_Log.Name_Space, exception_Log.Method, exception_Log.Created_Date, ref exception_Log_Id);

            //Reassign ref and out parameters
            exception_Log.Exception_Log_Id = exception_Log_Id;

        }
        /// <summary>
        /// Persists a new instance of Exception_Log to the database.
        /// </summary>
        /// <param name="exception_Log_Id">Returns the value of exception_Log_Id. The database automatically generates this value. </param>
        public static void InsertException_Log(String exception_Message, String name_Space, String method, DateTime created_Date, ref Int32 exception_Log_Id)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.InsertException_Log(exception_Message, name_Space, method, created_Date, ref exception_Log_Id);

        }
        /// <summary>
        /// Returns all instances of Int32. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>The total number of instances. </results>
        public  static Int32 GetException_LogCount(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetException_Log(pageSize, startingRowNumber, pageNr, out totalCount);

            return (Int32)totalCount;
        }
        /// <summary/>
        /// 
        /// <results>The total number of instances. </results>
        public  static Int64 GetException_LogCount()
        {
            Int64 totalCount;
            Int32 pageSize = 1;
            Int32 startingRowNumber = 1;
            Int32 pageNr = 1;

            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetException_Log(pageSize, startingRowNumber, pageNr, out totalCount);

            return totalCount;
        }
        #endregion 

   }

}


