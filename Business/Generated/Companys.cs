

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Business
{

   /// <summary>
   /// This is the Primary Domain Model class for Companys.
   /// </summary>
   public partial class Companys 
   {

        #region Fields 

        private Int32 _Company_Id;
        private String _Company_Name;
        private String _Address;
        private String _City;
        private String _State;
        private String _Zip_Code;
        private String _Primary_Contact_First_Name;
        private String _Primary_Contact_Last_Name;
        private String _Primary_Contact_Phone;
        private String _Primary_Contact_Email_Address;
        private String _Secondary_Contact_First_Name1;
        private String _Secondary_Contact_Last_Name1;
        private String _Secondary_Contact_Phone1;
        private String _Secondary_Contact_Email_Address1;
        private Boolean _Offers_Befefits_To_Different_Classes;
        private Boolean _Active;
        private String _Company_Logo;
        private Int32 _Company_Logo_Height;
        private Int32 _Company_Logo_Width;
        private List<System_Users> _System_UsersList;
        #endregion 

        #region Properties 

        /// <summary>
        /// The database automatically generates this value.
        /// </summary>
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

        public virtual String Address
        {

            get
            {
               return _Address;
            }

            set
            {
               _Address = value;
            }
        }

        public virtual String City
        {

            get
            {
               return _City;
            }

            set
            {
               _City = value;
            }
        }

        public virtual String State
        {

            get
            {
               return _State;
            }

            set
            {
               _State = value;
            }
        }

        public virtual String Zip_Code
        {

            get
            {
               return _Zip_Code;
            }

            set
            {
               _Zip_Code = value;
            }
        }

        public virtual String Primary_Contact_First_Name
        {

            get
            {
               return _Primary_Contact_First_Name;
            }

            set
            {
               _Primary_Contact_First_Name = value;
            }
        }

        public virtual String Primary_Contact_Last_Name
        {

            get
            {
               return _Primary_Contact_Last_Name;
            }

            set
            {
               _Primary_Contact_Last_Name = value;
            }
        }

        public virtual String Primary_Contact_Phone
        {

            get
            {
               return _Primary_Contact_Phone;
            }

            set
            {
               _Primary_Contact_Phone = value;
            }
        }

        public virtual String Primary_Contact_Email_Address
        {

            get
            {
               return _Primary_Contact_Email_Address;
            }

            set
            {
               _Primary_Contact_Email_Address = value;
            }
        }

        public virtual String Secondary_Contact_First_Name1
        {

            get
            {
               return _Secondary_Contact_First_Name1;
            }

            set
            {
               _Secondary_Contact_First_Name1 = value;
            }
        }

        public virtual String Secondary_Contact_Last_Name1
        {

            get
            {
               return _Secondary_Contact_Last_Name1;
            }

            set
            {
               _Secondary_Contact_Last_Name1 = value;
            }
        }

        public virtual String Secondary_Contact_Phone1
        {

            get
            {
               return _Secondary_Contact_Phone1;
            }

            set
            {
               _Secondary_Contact_Phone1 = value;
            }
        }

        public virtual String Secondary_Contact_Email_Address1
        {

            get
            {
               return _Secondary_Contact_Email_Address1;
            }

            set
            {
               _Secondary_Contact_Email_Address1 = value;
            }
        }

        public virtual Boolean Offers_Befefits_To_Different_Classes
        {

            get
            {
               return _Offers_Befefits_To_Different_Classes;
            }

            set
            {
               _Offers_Befefits_To_Different_Classes = value;
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

        public virtual String Company_Logo
        {

            get
            {
               return _Company_Logo;
            }

            set
            {
               _Company_Logo = value;
            }
        }

        public virtual Int32 Company_Logo_Height
        {

            get
            {
               return _Company_Logo_Height;
            }

            set
            {
               _Company_Logo_Height = value;
            }
        }

        public virtual Int32 Company_Logo_Width
        {

            get
            {
               return _Company_Logo_Width;
            }

            set
            {
               _Company_Logo_Width = value;
            }
        }

        /// <summary>
        /// The list of System_Users that belongs to this Companys. This property is populated on first read.
        /// </summary>
        public virtual List<System_Users> System_UsersList
        {

            get
            {

               if(_System_UsersList==null)
               {
                  _System_UsersList=GetSystem_Users();
               }

               return _System_UsersList;
            }

        }

        #endregion 

        #region Default Constructor 

        public Companys()
        {
        }

        #endregion 

        #region Private Methods 

        private List<System_Users> GetSystem_Users()
        {
            return System_Users.GetSystem_UsersByCompany_Id(Company_Id);
        }

        /// <summary>
        ///Populates the instance using data from the datastore.  
        ///The lookup of the data in the datastore is based on the instance's current ID value.
        /// </summary>
        private void Load()
        {

            List<Bar.Data.Companys> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetCompanysByCompany_Id(Company_Id);

			if(dataEntityCollection.Count == 0)
			{
				throw new InvalidOperationException("Object can't be instantiated: key(s) may be invalid");
			}

            Bar.Data.Companys val = (Bar.Data.Companys)(dataEntityCollection[0]);

            Company_Id = val.Company_Id;

            Company_Name = val.Company_Name;

            Address = val.Address;

            City = val.City;

            State = val.State;

            Zip_Code = val.Zip_Code;

            Primary_Contact_First_Name = val.Primary_Contact_First_Name;

            Primary_Contact_Last_Name = val.Primary_Contact_Last_Name;

            Primary_Contact_Phone = val.Primary_Contact_Phone;

            Primary_Contact_Email_Address = val.Primary_Contact_Email_Address;

            Secondary_Contact_First_Name1 = val.Secondary_Contact_First_Name1;

            Secondary_Contact_Last_Name1 = val.Secondary_Contact_Last_Name1;

            Secondary_Contact_Phone1 = val.Secondary_Contact_Phone1;

            Secondary_Contact_Email_Address1 = val.Secondary_Contact_Email_Address1;

            Offers_Befefits_To_Different_Classes = val.Offers_Befefits_To_Different_Classes;

            Active = val.Active;

            Company_Logo = val.Company_Logo;

            Company_Logo_Height = val.Company_Logo_Height;

            Company_Logo_Width = val.Company_Logo_Width;

        }

        #endregion 

        #region Constructors 

        public Companys( Int32 company_Id)
        {

            Company_Id = company_Id;

            Load();
        }

        internal Companys(Bar.Data.Companys companys)
        {

            Company_Id = companys.Company_Id;

            Company_Name = companys.Company_Name;

            Address = companys.Address;

            City = companys.City;

            State = companys.State;

            Zip_Code = companys.Zip_Code;

            Primary_Contact_First_Name = companys.Primary_Contact_First_Name;

            Primary_Contact_Last_Name = companys.Primary_Contact_Last_Name;

            Primary_Contact_Phone = companys.Primary_Contact_Phone;

            Primary_Contact_Email_Address = companys.Primary_Contact_Email_Address;

            Secondary_Contact_First_Name1 = companys.Secondary_Contact_First_Name1;

            Secondary_Contact_Last_Name1 = companys.Secondary_Contact_Last_Name1;

            Secondary_Contact_Phone1 = companys.Secondary_Contact_Phone1;

            Secondary_Contact_Email_Address1 = companys.Secondary_Contact_Email_Address1;

            Offers_Befefits_To_Different_Classes = companys.Offers_Befefits_To_Different_Classes;

            Active = companys.Active;

            Company_Logo = companys.Company_Logo;

            Company_Logo_Height = companys.Company_Logo_Height;

            Company_Logo_Width = companys.Company_Logo_Width;

        }

        #endregion 

        #region Public Methods 

        /// <summary>
        /// Returns all instances of Companys.
        /// </summary>
        /// <results>Returns a strongly typed list of Companys. </results>
        public static List<Companys> GetAll()
        {

            List<Bar.Data.Companys> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetAllCompanys();

            List<Companys> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Companys>(dataEntityCollection.Count);
               foreach(Bar.Data.Companys val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Companys(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Companys>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns all instances of Companys. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public static List<Companys> GetAll(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            List<Bar.Data.Companys> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetCompanys(pageSize, startingRowNumber, pageNr, out totalCount);

            List<Companys> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Companys>(dataEntityCollection.Count);
               foreach(Bar.Data.Companys val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Companys(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Companys>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Returns an instance of List<Bar.Business.Companys>.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public static List<Companys> GetCompanysByCompany_Id(Int32 company_Id)
        {

            List<Bar.Data.Companys> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetCompanysByCompany_Id(company_Id);

            List<Companys> businessEntityCollection = null;
            if(dataEntityCollection != null) 
            {
               businessEntityCollection = new List<Bar.Business.Companys>(dataEntityCollection.Count);
               foreach(Bar.Data.Companys val in dataEntityCollection)
               {
                  businessEntityCollection.Add(new Bar.Business.Companys(val));
               }

            }
            else
            {
               businessEntityCollection = new List<Bar.Business.Companys>(0);
            }
            return businessEntityCollection;

        }
        /// <summary>
        /// Get the instance of Companys that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of Companys.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        public static Companys GetCompanys(Int32 company_Id)
        {
            Companys val = null;
            List<Bar.Business.Companys> businessEntityCollection = GetCompanysByCompany_Id(company_Id);
            if (businessEntityCollection.Count > 0)
            {
                val = businessEntityCollection[0];
            }
            return val;
        }

        /// <summary>
        /// Persists a new instance of Companys to the database.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        public static void Insert(Companys companys)
        {
            Int32 company_Id = companys.Company_Id;

            Companys.InsertCompanys(companys.Company_Name, companys.Address, companys.City, companys.State, companys.Zip_Code, companys.Primary_Contact_First_Name, companys.Primary_Contact_Last_Name, companys.Primary_Contact_Phone, companys.Primary_Contact_Email_Address, companys.Secondary_Contact_First_Name1, companys.Secondary_Contact_Last_Name1, companys.Secondary_Contact_Phone1, companys.Secondary_Contact_Email_Address1, companys.Offers_Befefits_To_Different_Classes, companys.Active, companys.Company_Logo, companys.Company_Logo_Height, companys.Company_Logo_Width, ref company_Id);

            //Reassign ref and out parameters
            companys.Company_Id = company_Id;

        }
        /// <summary>
        /// Persists a new instance of Companys to the database.
        /// </summary>
        /// <param name="company_Id">Returns the value of company_Id. The database automatically generates this value. </param>
        public static void InsertCompanys(String company_Name, String address, String city, String state, String zip_Code, String primary_Contact_First_Name, String primary_Contact_Last_Name, String primary_Contact_Phone, String primary_Contact_Email_Address, String secondary_Contact_First_Name1, String secondary_Contact_Last_Name1, String secondary_Contact_Phone1, String secondary_Contact_Email_Address1, Boolean offers_Befefits_To_Different_Classes, Boolean active, String company_Logo, Int32 company_Logo_Height, Int32 company_Logo_Width, ref Int32 company_Id)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.InsertCompanys(company_Name, address, city, state, zip_Code, primary_Contact_First_Name, primary_Contact_Last_Name, primary_Contact_Phone, primary_Contact_Email_Address, secondary_Contact_First_Name1, secondary_Contact_Last_Name1, secondary_Contact_Phone1, secondary_Contact_Email_Address1, offers_Befefits_To_Different_Classes, active, company_Logo, company_Logo_Height, company_Logo_Width, ref company_Id);

        }
        /// <summary>
        /// Deletes an instance of Companys based on companys.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean Delete(Companys companys)
        {
            System.Boolean value;
            value = Companys.DeleteCompanys(companys.Company_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of Companys based on Company_Id.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public static Boolean DeleteCompanys(Int32 company_Id)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.DeleteCompanys(company_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of Companys.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(Companys companys)
        {
            System.Boolean value;
            value = companys.Update();

            return value;
        }
        /// <summary>
        /// Updates an instance of Companys.
        /// </summary>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update()
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateCompanys(Company_Name, Address, City, State, Zip_Code, Primary_Contact_First_Name, Primary_Contact_Last_Name, Primary_Contact_Phone, Primary_Contact_Email_Address, Secondary_Contact_First_Name1, Secondary_Contact_Last_Name1, Secondary_Contact_Phone1, Secondary_Contact_Email_Address1, Offers_Befefits_To_Different_Classes, Active, Company_Logo, Company_Logo_Height, Company_Logo_Width, Company_Id);

            return retval;
        }
        /// <summary>
        /// Updates an instance of Companys if the underlying data has not changed. The original instance is Companys_Original. To bypass the concurrency check, pass in 'null' for the Companys_Original parameter.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        /// <param name="companys_Original">The original instance of companys. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public static Boolean Update(Companys companys, Companys companys_Original)
        {
            System.Boolean value;
            value = companys.Update(companys_Original.Company_Name, companys_Original.Address, companys_Original.City, companys_Original.State, companys_Original.Zip_Code, companys_Original.Primary_Contact_First_Name, companys_Original.Primary_Contact_Last_Name, companys_Original.Primary_Contact_Phone, companys_Original.Primary_Contact_Email_Address, companys_Original.Secondary_Contact_First_Name1, companys_Original.Secondary_Contact_Last_Name1, companys_Original.Secondary_Contact_Phone1, companys_Original.Secondary_Contact_Email_Address1, companys_Original.Offers_Befefits_To_Different_Classes, companys_Original.Active, companys_Original.Company_Logo, companys_Original.Company_Logo_Height, companys_Original.Company_Logo_Width);

            return value;
        }
        /// <summary>
        /// Updates an instance of Companys if the original data has not changed.
        /// </summary>
        /// <param name="company_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'company_Name_Original'. </param>
        /// <param name="address_Original">This field is used for optimistic concurrency management. It should contain the original value of 'address_Original'. </param>
        /// <param name="city_Original">This field is used for optimistic concurrency management. It should contain the original value of 'city_Original'. </param>
        /// <param name="state_Original">This field is used for optimistic concurrency management. It should contain the original value of 'state_Original'. </param>
        /// <param name="zip_Code_Original">This field is used for optimistic concurrency management. It should contain the original value of 'zip_Code_Original'. </param>
        /// <param name="primary_Contact_First_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'primary_Contact_First_Name_Original'. </param>
        /// <param name="primary_Contact_Last_Name_Original">This field is used for optimistic concurrency management. It should contain the original value of 'primary_Contact_Last_Name_Original'. </param>
        /// <param name="primary_Contact_Phone_Original">This field is used for optimistic concurrency management. It should contain the original value of 'primary_Contact_Phone_Original'. </param>
        /// <param name="primary_Contact_Email_Address_Original">This field is used for optimistic concurrency management. It should contain the original value of 'primary_Contact_Email_Address_Original'. </param>
        /// <param name="secondary_Contact_First_Name1_Original">This field is used for optimistic concurrency management. It should contain the original value of 'secondary_Contact_First_Name1_Original'. </param>
        /// <param name="secondary_Contact_Last_Name1_Original">This field is used for optimistic concurrency management. It should contain the original value of 'secondary_Contact_Last_Name1_Original'. </param>
        /// <param name="secondary_Contact_Phone1_Original">This field is used for optimistic concurrency management. It should contain the original value of 'secondary_Contact_Phone1_Original'. </param>
        /// <param name="secondary_Contact_Email_Address1_Original">This field is used for optimistic concurrency management. It should contain the original value of 'secondary_Contact_Email_Address1_Original'. </param>
        /// <param name="offers_Befefits_To_Different_Classes_Original">This field is used for optimistic concurrency management. It should contain the original value of 'offers_Befefits_To_Different_Classes_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <param name="company_Logo_Original">This field is used for optimistic concurrency management. It should contain the original value of 'company_Logo_Original'. </param>
        /// <param name="company_Logo_Height_Original">This field is used for optimistic concurrency management. It should contain the original value of 'company_Logo_Height_Original'. </param>
        /// <param name="company_Logo_Width_Original">This field is used for optimistic concurrency management. It should contain the original value of 'company_Logo_Width_Original'. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean Update(String company_Name_Original, String address_Original, String city_Original, String state_Original, String zip_Code_Original, String primary_Contact_First_Name_Original, String primary_Contact_Last_Name_Original, String primary_Contact_Phone_Original, String primary_Contact_Email_Address_Original, String secondary_Contact_First_Name1_Original, String secondary_Contact_Last_Name1_Original, String secondary_Contact_Phone1_Original, String secondary_Contact_Email_Address1_Original, Boolean offers_Befefits_To_Different_Classes_Original, Boolean active_Original, String company_Logo_Original, Int32 company_Logo_Height_Original, Int32 company_Logo_Width_Original)
        {
            System.Boolean retval;
            retval = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.UpdateCompanys(Company_Name, company_Name_Original, Address, address_Original, City, city_Original, State, state_Original, Zip_Code, zip_Code_Original, Primary_Contact_First_Name, primary_Contact_First_Name_Original, Primary_Contact_Last_Name, primary_Contact_Last_Name_Original, Primary_Contact_Phone, primary_Contact_Phone_Original, Primary_Contact_Email_Address, primary_Contact_Email_Address_Original, Secondary_Contact_First_Name1, secondary_Contact_First_Name1_Original, Secondary_Contact_Last_Name1, secondary_Contact_Last_Name1_Original, Secondary_Contact_Phone1, secondary_Contact_Phone1_Original, Secondary_Contact_Email_Address1, secondary_Contact_Email_Address1_Original, Offers_Befefits_To_Different_Classes, offers_Befefits_To_Different_Classes_Original, Active, active_Original, Company_Logo, company_Logo_Original, Company_Logo_Height, company_Logo_Height_Original, Company_Logo_Width, company_Logo_Width_Original, Company_Id);

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
        public  static Int32 GetCompanysCount(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {
            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetCompanys(pageSize, startingRowNumber, pageNr, out totalCount);

            return (Int32)totalCount;
        }
        /// <summary/>
        /// 
        /// <results>The total number of instances. </results>
        public  static Int64 GetCompanysCount()
        {
            Int64 totalCount;
            Int32 pageSize = 1;
            Int32 startingRowNumber = 1;
            Int32 pageNr = 1;

            OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetCompanys(pageSize, startingRowNumber, pageNr, out totalCount);

            return totalCount;
        }

        public static List<Companys> GetCompanysByCompany_Name(String company_Name)
        {

            List<Bar.Data.Companys> dataEntityCollection = OxyData.Data.DataProvider<Bar.Data.DataProvider>.Current.GetCompanyByCompanyName(company_Name);

            List<Companys> businessEntityCollection = null;
            if (dataEntityCollection != null)
            {
                businessEntityCollection = new List<Bar.Business.Companys>(dataEntityCollection.Count);
                foreach (Bar.Data.Companys val in dataEntityCollection)
                {
                    businessEntityCollection.Add(new Bar.Business.Companys(val));
                }

            }
            else
            {
                businessEntityCollection = new List<Bar.Business.Companys>(0);
            }
            return businessEntityCollection;

        }

        #endregion

    }

}


