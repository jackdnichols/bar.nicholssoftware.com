

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Business
{

   /// <summary>
   /// This is the Primary Domain Model class for System_User_Roles.
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

        #region Private Methods 

        /// <summary>
        ///Populates the instance using data from the datastore.  
        ///The lookup of the data in the datastore is based on the instance's current ID value.
        /// </summary>
        private void Load()
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_RolesBySystem_User_Role_Id(System_User_Role_Id);

			if(dataEntityCollection.Count == 0)
			{
				throw new InvalidOperationException("Object can't be instantiated: key(s) may be invalid");
			}

            Bar.Data.System_User_Roles val = (Bar.Data.System_User_Roles)(dataEntityCollection[0]);

            System_User_Role_Id = val.System_User_Role_Id;

            System_User_Id = val.System_User_Id;

            Role_Id = val.Role_Id;

            Active = val.Active;

        }

        #endregion 

        #region Constructors 

        public System_User_Roles( Int32 system_User_Role_Id)
        {

            System_User_Role_Id = system_User_Role_Id;

            Load();
        }

        internal System_User_Roles(Bar.Data.System_User_Roles system_User_Roles)
        {

            System_User_Role_Id = system_User_Roles.System_User_Role_Id;

            System_User_Id = system_User_Roles.System_User_Id;

            Role_Id = system_User_Roles.Role_Id;

            Active = system_User_Roles.Active;

        }

        #endregion 

        #region Public Methods 

        /// <summary>
        /// Returns all instances of System_User_Roles.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public static List<System_User_Roles> GetAll()
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetAllSystem_User_Roles();

            List<System_User_Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.System_User_Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_User_Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns all instances of System_User_Roles. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public static List<System_User_Roles> GetAll(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_Roles(pageSize, startingRowNumber, pageNr, out totalCount);

            List<System_User_Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.System_User_Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_User_Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns an instance of List<Bar.Business.System_User_Roles>.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public static List<System_User_Roles> GetSystem_User_RolesBySystem_User_Role_Id(Int32 system_User_Role_Id)
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_RolesBySystem_User_Role_Id(system_User_Role_Id);

            List<System_User_Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.System_User_Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_User_Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Get the instance of System_User_Roles that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of System_User_Roles.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        public static System_User_Roles GetSystem_User_Roles(Int32 system_User_Role_Id)
        {
            System_User_Roles val = null;
            List<Bar.Business.System_User_Roles> businessEntityCollection = GetSystem_User_RolesBySystem_User_Role_Id(system_User_Role_Id);
            if (businessEntityCollection.Count > 0)
            {
                val = businessEntityCollection[0];
            }
            return val;
        }

        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: Role_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public static List<System_User_Roles> GetSystem_User_RolesByRole_Id(Int32 role_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_RolesByRole_Id(role_Id, pageSize, startingRowNumber, pageNr, out totalCount);

            List<System_User_Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.System_User_Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_User_Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: System_User_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public static List<System_User_Roles> GetSystem_User_RolesBySystem_User_Id(Int32 system_User_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_RolesBySystem_User_Id(system_User_Id, pageSize, startingRowNumber, pageNr, out totalCount);

            List<System_User_Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.System_User_Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_User_Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Relates System_Users to System_User_Roles.
        /// Returns a collection of System_User_Roles based on the following criteria: System_User_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public static List<System_User_Roles> GetSystem_User_RolesBySystem_User_Id(Int32 system_User_Id)
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_RolesBySystem_User_Id(system_User_Id);

            List<System_User_Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.System_User_Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_User_Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Relates Roles to System_User_Roles.
        /// Returns a collection of System_User_Roles based on the following criteria: Role_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public static List<System_User_Roles> GetSystem_User_RolesByRole_Id(Int32 role_Id)
        {

            List<Bar.Data.System_User_Roles> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_RolesByRole_Id(role_Id);

            List<System_User_Roles> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(dataEntityCollection.Count);
               foreach(Bar.Data.System_User_Roles val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_User_Roles(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_User_Roles>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Persists a new instance of System_User_Roles to the database.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        public static void Insert(System_User_Roles system_User_Roles)
        {
            Int32 system_User_Role_Id = system_User_Roles.System_User_Role_Id;

            System_User_Roles.InsertSystem_User_Roles(system_User_Roles.System_User_Id, system_User_Roles.Role_Id, system_User_Roles.Active, ref system_User_Role_Id);

            //Reassign ref and out parameters
            system_User_Roles.System_User_Role_Id = system_User_Role_Id;

        }
        /// <summary>
        /// Persists a new instance of System_User_Roles to the database.
        /// </summary>
        /// <param name="system_User_Role_Id">Returns the value of system_User_Role_Id. The database automatically generates this value. </param>
        public static void InsertSystem_User_Roles(Int32 system_User_Id, Int32 role_Id, Boolean active, ref Int32 system_User_Role_Id)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.InsertSystem_User_Roles(system_User_Id, role_Id, active, ref system_User_Role_Id);

        }
        /// <summary>
        /// Deletes an instance of System_User_Roles based on system_User_Roles.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean Delete(System_User_Roles system_User_Roles)
        {
            System.Boolean value;
            value = System_User_Roles.DeleteSystem_User_Roles(system_User_Roles.System_User_Role_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of System_User_Roles based on System_User_Role_Id.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean DeleteSystem_User_Roles(Int32 system_User_Role_Id)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.DeleteSystem_User_Roles(system_User_Role_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of System_User_Roles.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(System_User_Roles system_User_Roles)
        {
            System.Boolean value;
            value = system_User_Roles.Update();

            return value;
        }
        /// <summary>
        /// Updates an instance of System_User_Roles.
        /// </summary>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update()
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateSystem_User_Roles(System_User_Id, Role_Id, Active, System_User_Role_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of System_User_Roles if the underlying data has not changed. The original instance is System_User_Roles_Original. To bypass the concurrency check, pass in 'null' for the System_User_Roles_Original parameter.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        /// <param name="system_User_Roles_Original">The original instance of system_User_Roles. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(System_User_Roles system_User_Roles, System_User_Roles system_User_Roles_Original)
        {
            System.Boolean value;
            value = system_User_Roles.Update(system_User_Roles_Original.System_User_Id, system_User_Roles_Original.Role_Id, system_User_Roles_Original.Active);

            return value;
        }
        /// <summary>
        /// Updates an instance of System_User_Roles if the original data has not changed.
        /// </summary>
        /// <param name="system_User_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'system_User_Id_Original'. </param>
        /// <param name="role_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'role_Id_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update(Int32 system_User_Id_Original, Int32 role_Id_Original, Boolean active_Original)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateSystem_User_Roles(System_User_Id, system_User_Id_Original, Role_Id, role_Id_Original, Active, active_Original, System_User_Role_Id);

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
        public  static Int32 GetSystem_User_RolesCount(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_Roles(pageSize, startingRowNumber, pageNr, out totalCount);

            return (Int32)totalCount;
        }
        /// <summary/>
        /// 
        /// <results>The total number of instances. </results>
        public  static Int64 GetSystem_User_RolesCount()
        {
            Int64 totalCount;
            Int32 pageSize = 1;
            Int32 startingRowNumber = 1;
            Int32 pageNr = 1;

            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_User_Roles(pageSize, startingRowNumber, pageNr, out totalCount);

            return totalCount;
        }
        /// <summary>
        /// Gets the instance of System_Users that corresponds to the System_User_Id property.
        /// Returns an instance of System_Users.
        /// </summary>
        public  Bar.Business.System_Users GetSystem_UsersBySystem_User_Id()
        {
            System_Users value;
            value = Bar.Business.System_Users.GetSystem_Users(System_User_Id);

            return value;
        }
        /// <summary>
        /// Gets the instance of Roles that corresponds to the Role_Id property.
        /// Returns an instance of Roles.
        /// </summary>
        public  Bar.Business.Roles GetRolesByRole_Id()
        {
            Roles value;
            value = Bar.Business.Roles.GetRoles(Role_Id);

            return value;
        }
        #endregion 

   }

}





