

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Data
{

   /// <summary>
   /// This is the Data Transfer Object class for System_Users.
   /// </summary>
   public partial class System_Users
   {

        #region Fields 

        private Int32 _System_User_Id;
        private Int32 _Company_Id;
        private String _First_Name;
        private String _Last_Name;
        private String _Email_Address;
        private String _Login_Id;
        private Byte[] _Hash;
        private Byte[] _Salt;
        private Boolean _Active;
        private DateTime _Created_Date;
        #endregion 

        #region Properties 

        /// <summary>
        /// The database automatically generates this value.
        /// </summary>
        public virtual Int32 System_User_Id
        {

            get
            {
               return _System_User_Id;
            }

            set
            {
               _System_User_Id = value;
            }
        }

        public virtual Int32 Company_Id
        {

            get
            {
               return _Company_Id;
            }

            set
            {
               _Company_Id = value;
            }
        }

        public virtual String First_Name
        {

            get
            {
               return _First_Name;
            }

            set
            {
               _First_Name = value;
            }
        }

        public virtual String Last_Name
        {

            get
            {
               return _Last_Name;
            }

            set
            {
               _Last_Name = value;
            }
        }

        public virtual String Email_Address
        {

            get
            {
               return _Email_Address;
            }

            set
            {
               _Email_Address = value;
            }
        }

        public virtual String Login_Id
        {

            get
            {
               return _Login_Id;
            }

            set
            {
               _Login_Id = value;
            }
        }

        public virtual Byte[] Hash
        {

            get
            {
               return _Hash;
            }

            set
            {
               _Hash = value;
            }
        }

        public virtual Byte[] Salt
        {

            get
            {
               return _Salt;
            }

            set
            {
               _Salt = value;
            }
        }

        public virtual Boolean Active
        {

            get
            {
               return _Active;
            }

            set
            {
               _Active = value;
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

        public System_Users()
        {
        }

        #endregion 

        #region Constructors 

        public System_Users(Int32 system_User_Id, Int32 company_Id, String first_Name, String last_Name, String email_Address, String login_Id, Byte[] hash, Byte[] salt, Boolean active, DateTime created_Date)
        {
            System_User_Id = system_User_Id;
            Company_Id = company_Id;
            First_Name = first_Name;
            Last_Name = last_Name;
            Email_Address = email_Address;
            Login_Id = login_Id;
            Hash = hash;
            Salt = salt;
            Active = active;
            Created_Date = created_Date;
        }

        #endregion 

   }

}

