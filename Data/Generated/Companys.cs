

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;

namespace Bar.Data
{

   /// <summary>
   /// This is the Data Transfer Object class for Companys.
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

        #endregion 

        #region Default Constructor 

        public Companys()
        {
        }

        #endregion 

        #region Constructors 

        public Companys(Int32 company_Id, String company_Name, String address, String city, String state, String zip_Code, String primary_Contact_First_Name, String primary_Contact_Last_Name, String primary_Contact_Phone, String primary_Contact_Email_Address, String secondary_Contact_First_Name1, String secondary_Contact_Last_Name1, String secondary_Contact_Phone1, String secondary_Contact_Email_Address1, Boolean offers_Befefits_To_Different_Classes, Boolean active, String company_Logo, Int32 company_Logo_Height, Int32 company_Logo_Width)
        {
            Company_Id = company_Id;
            Company_Name = company_Name;
            Address = address;
            City = city;
            State = state;
            Zip_Code = zip_Code;
            Primary_Contact_First_Name = primary_Contact_First_Name;
            Primary_Contact_Last_Name = primary_Contact_Last_Name;
            Primary_Contact_Phone = primary_Contact_Phone;
            Primary_Contact_Email_Address = primary_Contact_Email_Address;
            Secondary_Contact_First_Name1 = secondary_Contact_First_Name1;
            Secondary_Contact_Last_Name1 = secondary_Contact_Last_Name1;
            Secondary_Contact_Phone1 = secondary_Contact_Phone1;
            Secondary_Contact_Email_Address1 = secondary_Contact_Email_Address1;
            Offers_Befefits_To_Different_Classes = offers_Befefits_To_Different_Classes;
            Active = active;
            Company_Logo = company_Logo;
            Company_Logo_Height = company_Logo_Height;
            Company_Logo_Width = company_Logo_Width;
        }

        #endregion 

   }

}

