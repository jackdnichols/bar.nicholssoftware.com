

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Business
{

   /// <summary>
   /// This is the Primary Domain Model class for Roles.
   /// </summary>
   public partial class Roles 
   {

        #region Fields 

        private Int32 _Role_Id;
        private String _Role;
        private Boolean _Active;
        private List<System_User_Roles> _System_User_RolesList;
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

        /// <summary>
        /// The list of System_User_Roles that belongs to this Roles. This property is populated on first read.
        /// </summary>
        public virtual List<System_User_Roles> System_User_RolesList
        {

            get
            {

               if(_System_User_RolesList==null)
               {
                  _System_User_RolesList=GetSystem_User_Roles();
               }

               return _System_User_RolesList;
            }

        }

        #endregion 

        #region Default Constructor 

        public Roles()
        {
        }

        #endregion 

        #region Private Methods 

        private List<System_User_Roles> GetSystem_User_Roles()
        {
            return System_User_Roles.GetSystem_User_RolesByRole_Id(Role_Id);
        }

        /// <summary>
        ///Populates the instance using data from the datastore.  
        ///The lookup of the data in the datastore is based on the instance's current ID value.
        /// </summary>
        private void Load()
        {

            List<Bar.Data.Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetRolesByRole_Id(Role_Id);

			if(dataEntityCollection.Count == 0)
			{
				throw new InvalidOperationException("Object can't be instantiated: key(s) may be invalid");
			}

            Bar.Data.Roles val = (Bar.Data.Roles)(dataEntityCollection[0]);

            Role_Id = val.Role_Id;

            Role = val.Role;

            Active = val.Active;

        }

        #endregion 

        #region Constructors 

        public Roles( Int32 role_Id)
        {

            Role_Id = role_Id;

            Load();
        }

        internal Roles(Bar.Data.Roles roles)
        {

            Role_Id = roles.Role_Id;

            Role = roles.Role;

            Active = roles.Active;

        }

        #endregion 

        #region Public Methods 

        /// <summary>
        /// Returns all instances of Roles.
        /// </summary>
        /// <results>Returns a strongly typed list of Roles. </results>
        public static List<Roles> GetAll()
        {

            List<Bar.Data.Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetAllRoles();

            List<Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns all instances of Roles. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public static List<Roles> GetAll(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetRoles(pageSize, startingRowNumber, pageNr, out totalCount);

            List<Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns an instance of List<Bar.Business.Roles>.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public static List<Roles> GetRolesByRole_Id(Int32 role_Id)
        {

            List<Bar.Data.Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetRolesByRole_Id(role_Id);

            List<Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Get the instance of Roles that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of Roles.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        public static Roles GetRoles(Int32 role_Id)
        {
            Roles val = null;
            List<Bar.Business.Roles> businessEntityCollection = GetRolesByRole_Id(role_Id);
            if (businessEntityCollection.Count > 0)
            {
                val = businessEntityCollection[0];
            }
            return val;
        }

        /// <summary>
        /// Persists a new instance of Roles to the database.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        public static void Insert(Roles roles)
        {
            Int32 role_Id = roles.Role_Id;

            Roles.InsertRoles(roles.Role, roles.Active, ref role_Id);

            //Reassign ref and out parameters
            roles.Role_Id = role_Id;

        }
        /// <summary>
        /// Persists a new instance of Roles to the database.
        /// </summary>
        /// <param name="role_Id">Returns the value of role_Id. The database automatically generates this value. </param>
        public static void InsertRoles(String role, Boolean active, ref Int32 role_Id)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.InsertRoles(role, active, ref role_Id);

        }
        /// <summary>
        /// Deletes an instance of Roles based on roles.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean Delete(Roles roles)
        {
            System.Boolean value;
            value = Roles.DeleteRoles(roles.Role_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of Roles based on Role_Id.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean DeleteRoles(Int32 role_Id)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.DeleteRoles(role_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of Roles.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(Roles roles)
        {
            System.Boolean value;
            value = roles.Update();

            return value;
        }
        /// <summary>
        /// Updates an instance of Roles.
        /// </summary>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update()
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateRoles(Role, Active, Role_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of Roles if the underlying data has not changed. The original instance is Roles_Original. To bypass the concurrency check, pass in 'null' for the Roles_Original parameter.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        /// <param name="roles_Original">The original instance of roles. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(Roles roles, Roles roles_Original)
        {
            System.Boolean value;
            value = roles.Update(roles_Original.Role, roles_Original.Active);

            return value;
        }
        /// <summary>
        /// Updates an instance of Roles if the original data has not changed.
        /// </summary>
        /// <param name="role_Original">This field is used for optimistic concurrency management. It should contain the original value of 'role_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update(String role_Original, Boolean active_Original)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateRoles(Role, role_Original, Active, active_Original, Role_Id);

            return retval;
        }
        /// <summary>
        /// Returns all instances of Int32. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>The total number of instances. </results>
        public  static Int32 GetRolesCount(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetRoles(pageSize, startingRowNumber, pageNr, out totalCount);

            return (Int32)totalCount;
        }
        /// <summary/>
        /// 
        /// <results>The total number of instances. </results>
        public  static Int64 GetRolesCount()
        {
            Int64 totalCount;
            Int32 pageSize = 1;
            Int32 startingRowNumber = 1;
            Int32 pageNr = 1;

            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetRoles(pageSize, startingRowNumber, pageNr, out totalCount);

            return totalCount;
        }
        #endregion 

   }

}


