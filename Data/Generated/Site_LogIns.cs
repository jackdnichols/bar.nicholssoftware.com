

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Data
{

   /// <summary>
   /// This is the Data Transfer Object class for Site_LogIns.
   /// </summary>
   public partial class Site_LogIns
   {

        #region Fields 

        private Int32 _Site_LogIn_Id;
        private Int32 _System_User_Id;
        private String _Session_Session_Id;
        private String _Company_Name;
        private String _Role;
        private String _First_Name;
        private String _Last_Name;
        private String _Email_Address;
        private DateTime _CreatedDate;
        private DateTime? _LogOutDate;
        #endregion 

        #region Properties 

        /// <summary>
        /// The database automatically generates this value.
        /// </summary>
        public virtual Int32 Site_LogIn_Id
        {

            get
            {
               return _Site_LogIn_Id;
            }

            set
            {
               _Site_LogIn_Id = value;
            }
        }

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

        public virtual String Session_Session_Id
        {

            get
            {
               return _Session_Session_Id;
            }

            set
            {
               _Session_Session_Id = value;
            }
        }

        public virtual String Company_Name
        {

            get
            {
               return _Company_Name;
            }

            set
            {
               _Company_Name = value;
            }
        }

        public virtual String Role
        {

            get
            {
               return _Role;
            }

            set
            {
               _Role = value;
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

        public virtual DateTime CreatedDate
        {

            get
            {
               return _CreatedDate;
            }

            set
            {
               _CreatedDate = value;
            }
        }

        /// <summary>
        /// This is not a required field.
        /// </summary>
        public virtual DateTime? LogOutDate
        {

            get
            {
               return _LogOutDate;
            }

            set
            {
               _LogOutDate = value;
            }
        }

        #endregion 

        #region Default Constructor 

        public Site_LogIns()
        {
        }

        #endregion 

        #region Constructors 

        public Site_LogIns(Int32 site_LogIn_Id, Int32 system_User_Id, String session_Session_Id, String company_Name, String role, String first_Name, String last_Name, String email_Address, DateTime createdDate, DateTime? logOutDate)
        {
            Site_LogIn_Id = site_LogIn_Id;
            System_User_Id = system_User_Id;
            Session_Session_Id = session_Session_Id;
            Company_Name = company_Name;
            Role = role;
            First_Name = first_Name;
            Last_Name = last_Name;
            Email_Address = email_Address;
            CreatedDate = createdDate;
            LogOutDate = logOutDate;
        }

        #endregion 

   }

}

