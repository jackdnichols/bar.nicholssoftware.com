

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Data
{

   /// <summary>
   /// This is the Data Transfer Object class for System_User_Roles.
   /// </summary>
   public partial class System_User_Roles
   {

        #region Fields 

        private Int32 _System_User_Role_Id;
        private Int32 _System_User_Id;
        private Int32 _Role_Id;
        private Boolean _Active;
        #endregion 

        #region Properties 

        /// <summary>
        /// The database automatically generates this value.
        /// </summary>
        public virtual Int32 System_User_Role_Id
        {

            get
            {
               return _System_User_Role_Id;
            }

            set
            {
               _System_User_Role_Id = value;
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

        public virtual Int32 Role_Id
        {

            get
            {
               return _Role_Id;
            }

            set
            {
               _Role_Id = value;
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

        #endregion 

        #region Default Constructor 

        public System_User_Roles()
        {
        }

        #endregion 

        #region Constructors 

        public System_User_Roles(Int32 system_User_Role_Id, Int32 system_User_Id, Int32 role_Id, Boolean active)
        {
            System_User_Role_Id = system_User_Role_Id;
            System_User_Id = system_User_Id;
            Role_Id = role_Id;
            Active = active;
        }

        #endregion 

   }

}

