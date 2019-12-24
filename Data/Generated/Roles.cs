

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Data
{

   /// <summary>
   /// This is the Data Transfer Object class for Roles.
   /// </summary>
   public partial class Roles
   {

        #region Fields 

        private Int32 _Role_Id;
        private String _Role;
        private Boolean _Active;
        #endregion 

        #region Properties 

        /// <summary>
        /// The database automatically generates this value.
        /// </summary>
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

        public Roles()
        {
        }

        #endregion 

        #region Constructors 

        public Roles(Int32 role_Id, String role, Boolean active)
        {
            Role_Id = role_Id;
            Role = role;
            Active = active;
        }

        #endregion 

   }

}

