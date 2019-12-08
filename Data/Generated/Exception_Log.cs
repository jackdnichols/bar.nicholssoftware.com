

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Data
{

   /// <summary>
   /// This is the Data Transfer Object class for Exception_Log.
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

        #region Constructors 

        public Exception_Log(Int32 exception_Log_Id, String exception_Message, String name_Space, String method, DateTime created_Date)
        {
            Exception_Log_Id = exception_Log_Id;
            Exception_Message = exception_Message;
            Name_Space = name_Space;
            Method = method;
            Created_Date = created_Date;
        }

        #endregion 

   }

}

