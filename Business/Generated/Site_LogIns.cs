

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Business
{

   /// <summary>
   /// This is the Primary Domain Model class for Site_LogIns.
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

        #region Private Methods 

        /// <summary>
        ///Populates the instance using data from the datastore.  
        ///The lookup of the data in the datastore is based on the instance's current ID value.
        /// </summary>
        private void Load()
        {

            List<Bar.Data.Site_LogIns> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSite_LogInsBySite_LogIn_Id(Site_LogIn_Id);

			if(dataEntityCollection.Count == 0)
			{
				throw new InvalidOperationException("Object can't be instantiated: key(s) may be invalid");
			}

            Bar.Data.Site_LogIns val = (Bar.Data.Site_LogIns)(dataEntityCollection[0]);

            Site_LogIn_Id = val.Site_LogIn_Id;

            System_User_Id = val.System_User_Id;

            Session_Session_Id = val.Session_Session_Id;

            Company_Name = val.Company_Name;

            Role = val.Role;

            First_Name = val.First_Name;

            Last_Name = val.Last_Name;

            Email_Address = val.Email_Address;

            CreatedDate = val.CreatedDate;

            LogOutDate = val.LogOutDate;

        }

        #endregion 

        #region Constructors 

        public Site_LogIns( Int32 site_LogIn_Id)
        {

            Site_LogIn_Id = site_LogIn_Id;

            Load();
        }

        internal Site_LogIns(Bar.Data.Site_LogIns site_LogIns)
        {

            Site_LogIn_Id = site_LogIns.Site_LogIn_Id;

            System_User_Id = site_LogIns.System_User_Id;

            Session_Session_Id = site_LogIns.Session_Session_Id;

            Company_Name = site_LogIns.Company_Name;

            Role = site_LogIns.Role;

            First_Name = site_LogIns.First_Name;

            Last_Name = site_LogIns.Last_Name;

            Email_Address = site_LogIns.Email_Address;

            CreatedDate = site_LogIns.CreatedDate;

            LogOutDate = site_LogIns.LogOutDate;

        }

        #endregion 

        #region Public Methods 

        /// <summary>
        /// Returns all instances of Site_LogIns.
        /// </summary>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public static List<Site_LogIns> GetAll()
        {

            List<Bar.Data.Site_LogIns> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetAllSite_LogIns();

            List<Site_LogIns> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(dataEntityCollection.Count);
               foreach(Bar.Data.Site_LogIns val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Site_LogIns(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns all instances of Site_LogIns. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public static List<Site_LogIns> GetAll(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.Site_LogIns> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSite_LogIns(pageSize, startingRowNumber, pageNr, out totalCount);

            List<Site_LogIns> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(dataEntityCollection.Count);
               foreach(Bar.Data.Site_LogIns val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Site_LogIns(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns an instance of List<Bar.Business.Site_LogIns>.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public static List<Site_LogIns> GetSite_LogInsBySite_LogIn_Id(Int32 site_LogIn_Id)
        {

            List<Bar.Data.Site_LogIns> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSite_LogInsBySite_LogIn_Id(site_LogIn_Id);

            List<Site_LogIns> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(dataEntityCollection.Count);
               foreach(Bar.Data.Site_LogIns val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Site_LogIns(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Get the instance of Site_LogIns that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of Site_LogIns.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        public static Site_LogIns GetSite_LogIns(Int32 site_LogIn_Id)
        {
            Site_LogIns val = null;
            List<Bar.Business.Site_LogIns> businessEntityCollection = GetSite_LogInsBySite_LogIn_Id(site_LogIn_Id);
            if (businessEntityCollection.Count > 0)
            {
                val = businessEntityCollection[0];
            }
            return val;
        }

        /// <summary>
        /// Returns a collection of Site_LogIns filtered on the following criteria: System_User_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public static List<Site_LogIns> GetSite_LogInsBySystem_User_Id(Int32 system_User_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.Site_LogIns> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSite_LogInsBySystem_User_Id(system_User_Id, pageSize, startingRowNumber, pageNr, out totalCount);

            List<Site_LogIns> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(dataEntityCollection.Count);
               foreach(Bar.Data.Site_LogIns val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Site_LogIns(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Relates System_Users to Site_LogIns.
        /// Returns a collection of Site_LogIns based on the following criteria: System_User_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public static List<Site_LogIns> GetSite_LogInsBySystem_User_Id(Int32 system_User_Id)
        {

            List<Bar.Data.Site_LogIns> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSite_LogInsBySystem_User_Id(system_User_Id);

            List<Site_LogIns> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(dataEntityCollection.Count);
               foreach(Bar.Data.Site_LogIns val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Site_LogIns(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Site_LogIns>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Persists a new instance of Site_LogIns to the database.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        public static void Insert(Site_LogIns site_LogIns)
        {
            Int32 site_LogIn_Id = site_LogIns.Site_LogIn_Id;

            Site_LogIns.InsertSite_LogIns(site_LogIns.System_User_Id, site_LogIns.Session_Session_Id, site_LogIns.Company_Name, site_LogIns.Role, site_LogIns.First_Name, site_LogIns.Last_Name, site_LogIns.Email_Address, site_LogIns.CreatedDate, site_LogIns.LogOutDate, ref site_LogIn_Id);

            //Reassign ref and out parameters
            site_LogIns.Site_LogIn_Id = site_LogIn_Id;

        }
        /// <summary>
        /// Persists a new instance of Site_LogIns to the database.
        /// </summary>
        /// <param name="logOutDate">This is not a required field. </param>
        /// <param name="site_LogIn_Id">Returns the value of site_LogIn_Id. The database automatically generates this value. </param>
        public static void InsertSite_LogIns(Int32 system_User_Id, String session_Session_Id, String company_Name, String role, String first_Name, String last_Name, String email_Address, DateTime createdDate, DateTime? logOutDate, ref Int32 site_LogIn_Id)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.InsertSite_LogIns(system_User_Id, session_Session_Id, company_Name, role, first_Name, last_Name, email_Address, createdDate, logOutDate, ref site_LogIn_Id);

        }
        /// <summary>
        /// Deletes an instance of Site_LogIns based on site_LogIns.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean Delete(Site_LogIns site_LogIns)
        {
            System.Boolean value;
            value = Site_LogIns.DeleteSite_LogIns(site_LogIns.Site_LogIn_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of Site_LogIns based on Site_LogIn_Id.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean DeleteSite_LogIns(Int32 site_LogIn_Id)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.DeleteSite_LogIns(site_LogIn_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of Site_LogIns.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(Site_LogIns site_LogIns)
        {
            System.Boolean value;
            value = site_LogIns.Update();

            return value;
        }
        /// <summary>
        /// Updates an instance of Site_LogIns.
        /// </summary>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update()
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateSite_LogIns(System_User_Id, Session_Session_Id, Company_Name, Role, First_Name, Last_Name, Email_Address, CreatedDate, LogOutDate, Site_LogIn_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of Site_LogIns if the underlying data has not changed. The original instance is Site_LogIns_Original. To bypass the concurrency check, pass in 'null' for the Site_LogIns_Original parameter.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        /// <param name="site_LogIns_Original">The original instance of site_LogIns. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(Site_LogIns site_LogIns, Site_LogIns site_LogIns_Original)
        {
            System.Boolean value;
            value = site_LogIns.Update(site_LogIns_Original.System_User_Id, site_LogIns_Original.Session_Session_Id, site_LogIns_Original.Company_Name, site_LogIns_Original.Role, site_LogIns_Original.First_Name, site_LogIns_Original.Last_Name, site_LogIns_Original.Email_Address, site_LogIns_Original.CreatedDate, site_LogIns_Original.LogOutDate);

            return value;
        }
        /// <summary>
        /// Updates an instance of Site_LogIns if the original data has not changed.
        /// </summary>
        /// <param name="system_User_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'system_User_Id_Original'. </param>
        /// <param name="session_Session_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'session_Session_Id_Original'. </param>
        /// <param name="company_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'company_Name_Original'. </param>
        /// <param name="role_Original">This field is used for optimistic concurrency management. It should contain the original value of 'role_Original'. </param>
        /// <param name="first_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'first_Name_Original'. </param>
        /// <param name="last_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'last_Name_Original'. </param>
        /// <param name="email_Address_Original">This field is used for optimistic concurrency management. It should contain the original value of 'email_Address_Original'. </param>
        /// <param name="createdDate_Original">This field is used for optimistic concurrency management. It should contain the original value of 'createdDate_Original'. </param>
        /// <param name="logOutDate_Original">This field is used for optimistic concurrency management. It should contain the original value of 'logOutDate_Original'. This is not a required field. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update(Int32 system_User_Id_Original, String session_Session_Id_Original, String company_Name_Original, String role_Original, String first_Name_Original, String last_Name_Original, String email_Address_Original, DateTime createdDate_Original, DateTime? logOutDate_Original)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateSite_LogIns(System_User_Id, system_User_Id_Original, Session_Session_Id, session_Session_Id_Original, Company_Name, company_Name_Original, Role, role_Original, First_Name, first_Name_Original, Last_Name, last_Name_Original, Email_Address, email_Address_Original, CreatedDate, createdDate_Original, LogOutDate, logOutDate_Original, Site_LogIn_Id);

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
        public  static Int32 GetSite_LogInsCount(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSite_LogIns(pageSize, startingRowNumber, pageNr, out totalCount);

            return (Int32)totalCount;
        }
        /// <summary/>
        /// 
        /// <results>The total number of instances. </results>
        public  static Int64 GetSite_LogInsCount()
        {
            Int64 totalCount;
            Int32 pageSize = 1;
            Int32 startingRowNumber = 1;
            Int32 pageNr = 1;

            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetSite_LogIns(pageSize, startingRowNumber, pageNr, out totalCount);

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
        #endregion 

   }

}



