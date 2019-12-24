

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Business
{

   /// <summary>
   /// This is the Primary Domain Model class for System_Users.
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
        private List<Site_LogIns> _Site_LogInsList;
        private List<System_User_Roles> _System_User_RolesList;
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

        /// <summary>
        /// The list of Site_LogIns that belongs to this System_Users. This property is populated on first read.
        /// </summary>
        public virtual List<Site_LogIns> Site_LogInsList
        {

            get
            {

               if(_Site_LogInsList==null)
               {
                  _Site_LogInsList=GetSite_LogIns();
               }

               return _Site_LogInsList;
            }

        }

        /// <summary>
        /// The list of System_User_Roles that belongs to this System_Users. This property is populated on first read.
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

        public System_Users()
        {
        }

        #endregion 

        #region Private Methods 

        private List<Site_LogIns> GetSite_LogIns()
        {
            return Site_LogIns.GetSite_LogInsBySystem_User_Id(System_User_Id);
        }


        private List<System_User_Roles> GetSystem_User_Roles()
        {
            return System_User_Roles.GetSystem_User_RolesBySystem_User_Id(System_User_Id);
        }

        /// <summary>
        ///Populates the instance using data from the datastore.  
        ///The lookup of the data in the datastore is based on the instance's current ID value.
        /// </summary>
        private void Load()
        {

            List<Bar.Data.System_Users> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_UsersBySystem_User_Id(System_User_Id);

			if(dataEntityCollection.Count == 0)
			{
				throw new InvalidOperationException("Object can't be instantiated: key(s) may be invalid");
			}

            Bar.Data.System_Users val = (Bar.Data.System_Users)(dataEntityCollection[0]);

            System_User_Id = val.System_User_Id;

            Company_Id = val.Company_Id;

            First_Name = val.First_Name;

            Last_Name = val.Last_Name;

            Email_Address = val.Email_Address;

            Login_Id = val.Login_Id;

            Hash = val.Hash;

            Salt = val.Salt;

            Active = val.Active;

            Created_Date = val.Created_Date;

        }

        #endregion 

        #region Constructors 

        public System_Users( Int32 system_User_Id)
        {

            System_User_Id = system_User_Id;

            Load();
        }

        internal System_Users(Bar.Data.System_Users system_Users)
        {

            System_User_Id = system_Users.System_User_Id;

            Company_Id = system_Users.Company_Id;

            First_Name = system_Users.First_Name;

            Last_Name = system_Users.Last_Name;

            Email_Address = system_Users.Email_Address;

            Login_Id = system_Users.Login_Id;

            Hash = system_Users.Hash;

            Salt = system_Users.Salt;

            Active = system_Users.Active;

            Created_Date = system_Users.Created_Date;

        }

        #endregion 

        #region Public Methods 

        /// <summary>
        /// Returns all instances of System_Users.
        /// </summary>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public static List<System_Users> GetAll()
        {

            List<Bar.Data.System_Users> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetAllSystem_Users();

            List<System_Users> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(dataEntityCollection.Count);
               foreach(Bar.Data.System_Users val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_Users(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns all instances of System_Users. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public static List<System_Users> GetAll(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.System_Users> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_Users(pageSize, startingRowNumber, pageNr, out totalCount);

            List<System_Users> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(dataEntityCollection.Count);
               foreach(Bar.Data.System_Users val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_Users(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns an instance of List<Bar.Business.System_Users>.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public static List<System_Users> GetSystem_UsersBySystem_User_Id(Int32 system_User_Id)
        {

            List<Bar.Data.System_Users> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_UsersBySystem_User_Id(system_User_Id);

            List<System_Users> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(dataEntityCollection.Count);
               foreach(Bar.Data.System_Users val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_Users(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Get the instance of System_Users that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of System_Users.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        public static System_Users GetSystem_Users(Int32 system_User_Id)
        {
            System_Users val = null;
            List<Bar.Business.System_Users> businessEntityCollection = GetSystem_UsersBySystem_User_Id(system_User_Id);
            if (businessEntityCollection.Count > 0)
            {
                val = businessEntityCollection[0];
            }
            return val;
        }

        /// <summary>
        /// Returns a 'Byte[]' from a binary field of a record based on the primary key.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a single instance of Byte[]. </results>
        public static Byte[] GetSystem_UsersSaltBySystem_User_Id(Int32 system_User_Id)
        {
            System.Byte[] methodReturnVal = null;

            System.Byte[] dataEntity = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_UsersSaltBySystem_User_Id(system_User_Id);

            methodReturnVal = dataEntity;
            return methodReturnVal;

        }
        /// <summary>
        /// Returns a 'Byte[]' from a binary field of a record based on the primary key.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a single instance of Byte[]. </results>
        public static Byte[] GetSystem_UsersHashBySystem_User_Id(Int32 system_User_Id)
        {
            System.Byte[] methodReturnVal = null;

            System.Byte[] dataEntity = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_UsersHashBySystem_User_Id(system_User_Id);

            methodReturnVal = dataEntity;
            return methodReturnVal;

        }
        /// <summary>
        /// Returns a collection of System_Users filtered on the following criteria: Company_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public static List<System_Users> GetSystem_UsersByCompany_Id(Int32 company_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.System_Users> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_UsersByCompany_Id(company_Id, pageSize, startingRowNumber, pageNr, out totalCount);

            List<System_Users> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(dataEntityCollection.Count);
               foreach(Bar.Data.System_Users val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_Users(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Relates Companys to System_Users.
        /// Returns a collection of System_Users based on the following criteria: Company_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public static List<System_Users> GetSystem_UsersByCompany_Id(Int32 company_Id)
        {

            List<Bar.Data.System_Users> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_UsersByCompany_Id(company_Id);

            List<System_Users> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(dataEntityCollection.Count);
               foreach(Bar.Data.System_Users val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.System_Users(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.System_Users>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Persists a new instance of System_Users to the database.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        public static void Insert(System_Users system_Users)
        {
            Int32 system_User_Id = system_Users.System_User_Id;

            System_Users.InsertSystem_Users(system_Users.Company_Id, system_Users.First_Name, system_Users.Last_Name, system_Users.Email_Address, system_Users.Login_Id, system_Users.Hash, system_Users.Salt, system_Users.Active, system_Users.Created_Date, ref system_User_Id);

            //Reassign ref and out parameters
            system_Users.System_User_Id = system_User_Id;

        }
        /// <summary>
        /// Persists a new instance of System_Users to the database.
        /// </summary>
        /// <param name="system_User_Id">Returns the value of system_User_Id. The database automatically generates this value. </param>
        public static void InsertSystem_Users(Int32 company_Id, String first_Name, String last_Name, String email_Address, String login_Id, Byte[] hash, Byte[] salt, Boolean active, DateTime created_Date, ref Int32 system_User_Id)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.InsertSystem_Users(company_Id, first_Name, last_Name, email_Address, login_Id, hash, salt, active, created_Date, ref system_User_Id);

        }
        /// <summary>
        /// Deletes an instance of System_Users based on system_Users.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean Delete(System_Users system_Users)
        {
            System.Boolean value;
            value = System_Users.DeleteSystem_Users(system_Users.System_User_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of System_Users based on System_User_Id.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean DeleteSystem_Users(Int32 system_User_Id)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.DeleteSystem_Users(system_User_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of System_Users.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(System_Users system_Users)
        {
            System.Boolean value;
            value = system_Users.Update();

            return value;
        }
        /// <summary>
        /// Updates an instance of System_Users.
        /// </summary>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update()
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateSystem_Users(Company_Id, First_Name, Last_Name, Email_Address, Login_Id, Hash, Salt, Active, Created_Date, System_User_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of System_Users if the underlying data has not changed. The original instance is System_Users_Original. To bypass the concurrency check, pass in 'null' for the System_Users_Original parameter.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        /// <param name="system_Users_Original">The original instance of system_Users. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(System_Users system_Users, System_Users system_Users_Original)
        {
            System.Boolean value;
            value = system_Users.Update(system_Users_Original.Company_Id, system_Users_Original.First_Name, system_Users_Original.Last_Name, system_Users_Original.Email_Address, system_Users_Original.Login_Id, system_Users_Original.Hash, system_Users_Original.Salt, system_Users_Original.Active, system_Users_Original.Created_Date);

            return value;
        }
        /// <summary>
        /// Updates an instance of System_Users if the original data has not changed.
        /// </summary>
        /// <param name="company_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'company_Id_Original'. </param>
        /// <param name="first_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'first_Name_Original'. </param>
        /// <param name="last_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'last_Name_Original'. </param>
        /// <param name="email_Address_Original">This field is used for optimistic concurrency management. It should contain the original value of 'email_Address_Original'. </param>
        /// <param name="login_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'login_Id_Original'. </param>
        /// <param name="hash_Original">This field is used for optimistic concurrency management. It should contain the original value of 'hash_Original'. </param>
        /// <param name="salt_Original">This field is used for optimistic concurrency management. It should contain the original value of 'salt_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <param name="created_Date_Original">This field is used for optimistic concurrency management. It should contain the original value of 'created_Date_Original'. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update(Int32 company_Id_Original, String first_Name_Original, String last_Name_Original, String email_Address_Original, String login_Id_Original, Byte[] hash_Original, Byte[] salt_Original, Boolean active_Original, DateTime created_Date_Original)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateSystem_Users(Company_Id, company_Id_Original, First_Name, first_Name_Original, Last_Name, last_Name_Original, Email_Address, email_Address_Original, Login_Id, login_Id_Original, Hash, hash_Original, Salt, salt_Original, Active, active_Original, Created_Date, created_Date_Original, System_User_Id);

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
        public  static Int32 GetSystem_UsersCount(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_Users(pageSize, startingRowNumber, pageNr, out totalCount);

            return (Int32)totalCount;
        }
        /// <summary/>
        /// 
        /// <results>The total number of instances. </results>
        public  static Int64 GetSystem_UsersCount()
        {
            Int64 totalCount;
            Int32 pageSize = 1;
            Int32 startingRowNumber = 1;
            Int32 pageNr = 1;

            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSystem_Users(pageSize, startingRowNumber, pageNr, out totalCount);

            return totalCount;
        }
        /// <summary>
        /// Gets the instance of Companys that corresponds to the Company_Id property.
        /// Returns an instance of Companys.
        /// </summary>
        public  Bar.Business.Companys GetCompanysByCompany_Id()
        {
            Companys value;
            value = Bar.Business.Companys.GetCompanys(Company_Id);

            return value;
        }
        #endregion 

   }

}





