

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using OxyData.Data;

namespace Bar.Data
{

   /// <summary>
   /// Encapsulates data packaging and  transformation tasks needed to send data to, and receive data from the database.
   /// </summary>
   public partial class DataProvider : SpecificDataProviderBase
   {

        #region Properties 

        #endregion 

        #region Private Methods 

        #endregion 

        #region Companys 

        /// <summary>
        /// Returns an instance of List<Bar.Data.Companys>.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public List<Companys> GetCompanysByCompany_Id(Int32 company_Id)
        {
            return GetCompanysByCompany_Id(company_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns an instance of List<Bar.Data.Companys>.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public List<Companys> GetCompanysByCompany_Id(Int32 company_Id, DbTransaction tran)
        {

            List<Companys> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Companys_PK]", sps);

            dataList = new List<Bar.Data.Companys>();

            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int addressOrdinal = dr.GetOrdinal("Address");
            int cityOrdinal = dr.GetOrdinal("City");
            int stateOrdinal = dr.GetOrdinal("State");
            int zip_CodeOrdinal = dr.GetOrdinal("Zip_Code");
            int primary_Contact_First_NameOrdinal = dr.GetOrdinal("Primary_Contact_First_Name");
            int primary_Contact_Last_NameOrdinal = dr.GetOrdinal("Primary_Contact_Last_Name");
            int primary_Contact_PhoneOrdinal = dr.GetOrdinal("Primary_Contact_Phone");
            int primary_Contact_Email_AddressOrdinal = dr.GetOrdinal("Primary_Contact_Email_Address");
            int secondary_Contact_First_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_First_Name1");
            int secondary_Contact_Last_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_Last_Name1");
            int secondary_Contact_Phone1Ordinal = dr.GetOrdinal("Secondary_Contact_Phone1");
            int secondary_Contact_Email_Address1Ordinal = dr.GetOrdinal("Secondary_Contact_Email_Address1");
            int offers_Befefits_To_Different_ClassesOrdinal = dr.GetOrdinal("Offers_Befefits_To_Different_Classes");
            int activeOrdinal = dr.GetOrdinal("Active");
            int company_LogoOrdinal = dr.GetOrdinal("Company_Logo");
            int company_Logo_HeightOrdinal = dr.GetOrdinal("Company_Logo_Height");
            int company_Logo_WidthOrdinal = dr.GetOrdinal("Company_Logo_Width");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Companys(dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(addressOrdinal), 
                   dr.GetString(cityOrdinal), 
                   dr.GetString(stateOrdinal), 
                   dr.GetString(zip_CodeOrdinal), 
                   dr.GetString(primary_Contact_First_NameOrdinal), 
                   dr.GetString(primary_Contact_Last_NameOrdinal), 
                   dr.GetString(primary_Contact_PhoneOrdinal), 
                   dr.GetString(primary_Contact_Email_AddressOrdinal), 
                   dr.GetString(secondary_Contact_First_Name1Ordinal), 
                   dr.GetString(secondary_Contact_Last_Name1Ordinal), 
                   dr.GetString(secondary_Contact_Phone1Ordinal), 
                   dr.GetString(secondary_Contact_Email_Address1Ordinal), 
                   dr.GetBoolean(offers_Befefits_To_Different_ClassesOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetString(company_LogoOrdinal), 
                   dr.GetInt32(company_Logo_HeightOrdinal), 
                   dr.GetInt32(company_Logo_WidthOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetCompanysByCompany_Id", "[dbo].[oSP_Select_Companys_PK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of Companys.
        /// </summary>
        /// <results>Returns a strongly typed list of Companys. </results>
        public List<Companys> GetAllCompanys()
        {
            return GetAllCompanys((DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Companys.
        /// </summary>
        /// <results>Returns a strongly typed list of Companys. </results>
        public List<Companys> GetAllCompanys(DbTransaction tran)
        {

            List<Companys> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Companys_All]", sps);

            dataList = new List<Bar.Data.Companys>();

            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int addressOrdinal = dr.GetOrdinal("Address");
            int cityOrdinal = dr.GetOrdinal("City");
            int stateOrdinal = dr.GetOrdinal("State");
            int zip_CodeOrdinal = dr.GetOrdinal("Zip_Code");
            int primary_Contact_First_NameOrdinal = dr.GetOrdinal("Primary_Contact_First_Name");
            int primary_Contact_Last_NameOrdinal = dr.GetOrdinal("Primary_Contact_Last_Name");
            int primary_Contact_PhoneOrdinal = dr.GetOrdinal("Primary_Contact_Phone");
            int primary_Contact_Email_AddressOrdinal = dr.GetOrdinal("Primary_Contact_Email_Address");
            int secondary_Contact_First_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_First_Name1");
            int secondary_Contact_Last_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_Last_Name1");
            int secondary_Contact_Phone1Ordinal = dr.GetOrdinal("Secondary_Contact_Phone1");
            int secondary_Contact_Email_Address1Ordinal = dr.GetOrdinal("Secondary_Contact_Email_Address1");
            int offers_Befefits_To_Different_ClassesOrdinal = dr.GetOrdinal("Offers_Befefits_To_Different_Classes");
            int activeOrdinal = dr.GetOrdinal("Active");
            int company_LogoOrdinal = dr.GetOrdinal("Company_Logo");
            int company_Logo_HeightOrdinal = dr.GetOrdinal("Company_Logo_Height");
            int company_Logo_WidthOrdinal = dr.GetOrdinal("Company_Logo_Width");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Companys(dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(addressOrdinal), 
                   dr.GetString(cityOrdinal), 
                   dr.GetString(stateOrdinal), 
                   dr.GetString(zip_CodeOrdinal), 
                   dr.GetString(primary_Contact_First_NameOrdinal), 
                   dr.GetString(primary_Contact_Last_NameOrdinal), 
                   dr.GetString(primary_Contact_PhoneOrdinal), 
                   dr.GetString(primary_Contact_Email_AddressOrdinal), 
                   dr.GetString(secondary_Contact_First_Name1Ordinal), 
                   dr.GetString(secondary_Contact_Last_Name1Ordinal), 
                   dr.GetString(secondary_Contact_Phone1Ordinal), 
                   dr.GetString(secondary_Contact_Email_Address1Ordinal), 
                   dr.GetBoolean(offers_Befefits_To_Different_ClassesOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetString(company_LogoOrdinal), 
                   dr.GetInt32(company_Logo_HeightOrdinal), 
                   dr.GetInt32(company_Logo_WidthOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetAllCompanys", "[dbo].[oSP_Select_Companys_All]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of Companys. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public List<Companys> GetCompanys(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetCompanys(startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Companys. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public List<Companys> GetCompanys(Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<Companys> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[2].Direction = ParameterDirection.InputOutput;
            sps[2].Value = inputValues[2];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Companys_All_Paged]", sps);

            dataList = new List<Bar.Data.Companys>();

            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int addressOrdinal = dr.GetOrdinal("Address");
            int cityOrdinal = dr.GetOrdinal("City");
            int stateOrdinal = dr.GetOrdinal("State");
            int zip_CodeOrdinal = dr.GetOrdinal("Zip_Code");
            int primary_Contact_First_NameOrdinal = dr.GetOrdinal("Primary_Contact_First_Name");
            int primary_Contact_Last_NameOrdinal = dr.GetOrdinal("Primary_Contact_Last_Name");
            int primary_Contact_PhoneOrdinal = dr.GetOrdinal("Primary_Contact_Phone");
            int primary_Contact_Email_AddressOrdinal = dr.GetOrdinal("Primary_Contact_Email_Address");
            int secondary_Contact_First_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_First_Name1");
            int secondary_Contact_Last_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_Last_Name1");
            int secondary_Contact_Phone1Ordinal = dr.GetOrdinal("Secondary_Contact_Phone1");
            int secondary_Contact_Email_Address1Ordinal = dr.GetOrdinal("Secondary_Contact_Email_Address1");
            int offers_Befefits_To_Different_ClassesOrdinal = dr.GetOrdinal("Offers_Befefits_To_Different_Classes");
            int activeOrdinal = dr.GetOrdinal("Active");
            int company_LogoOrdinal = dr.GetOrdinal("Company_Logo");
            int company_Logo_HeightOrdinal = dr.GetOrdinal("Company_Logo_Height");
            int company_Logo_WidthOrdinal = dr.GetOrdinal("Company_Logo_Width");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Companys(dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(addressOrdinal), 
                   dr.GetString(cityOrdinal), 
                   dr.GetString(stateOrdinal), 
                   dr.GetString(zip_CodeOrdinal), 
                   dr.GetString(primary_Contact_First_NameOrdinal), 
                   dr.GetString(primary_Contact_Last_NameOrdinal), 
                   dr.GetString(primary_Contact_PhoneOrdinal), 
                   dr.GetString(primary_Contact_Email_AddressOrdinal), 
                   dr.GetString(secondary_Contact_First_Name1Ordinal), 
                   dr.GetString(secondary_Contact_Last_Name1Ordinal), 
                   dr.GetString(secondary_Contact_Phone1Ordinal), 
                   dr.GetString(secondary_Contact_Email_Address1Ordinal), 
                   dr.GetBoolean(offers_Befefits_To_Different_ClassesOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetString(company_LogoOrdinal), 
                   dr.GetInt32(company_Logo_HeightOrdinal), 
                   dr.GetInt32(company_Logo_WidthOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[2].Value) )
            {
               totalCount = (Int64)(sps[2].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetCompanys", "[dbo].[oSP_Select_Companys_All_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Deletes an instance of Companys based on Company_Id.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteCompanys(Int32 company_Id)
        {
            return DeleteCompanys(company_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of Companys based on Company_Id.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteCompanys(Int32 company_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_Companys_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteCompanys", "[dbo].[oSP_Delete_Companys_PK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Deletes all instances of Companys.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllCompanys()
        {
            return DeleteAllCompanys((DbTransaction)null);
        }

        /// <summary>
        /// Deletes all instances of Companys.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllCompanys(DbTransaction tran)
        {

            Int32 rowsAffected;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_Companys_All]", sps);

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteAllCompanys", "[dbo].[oSP_Delete_Companys_All]", rowsAffected, sqlcon, sps);
            return rowsAffected;
        }

        /// <summary>
        /// Updates an instance of Companys.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateCompanys(String company_Name, String address, String city, String state, String zip_Code, String primary_Contact_First_Name, String primary_Contact_Last_Name, String primary_Contact_Phone, String primary_Contact_Email_Address, String secondary_Contact_First_Name1, String secondary_Contact_Last_Name1, String secondary_Contact_Phone1, String secondary_Contact_Email_Address1, Boolean offers_Befefits_To_Different_Classes, Boolean active, String company_Logo, Int32 company_Logo_Height, Int32 company_Logo_Width, Int32 company_Id)
        {
            return UpdateCompanys(company_Name, address, city, state, zip_Code, primary_Contact_First_Name, primary_Contact_Last_Name, primary_Contact_Phone, primary_Contact_Email_Address, secondary_Contact_First_Name1, secondary_Contact_Last_Name1, secondary_Contact_Phone1, secondary_Contact_Email_Address1, offers_Befefits_To_Different_Classes, active, company_Logo, company_Logo_Height, company_Logo_Width, company_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Updates an instance of Companys.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateCompanys(String company_Name, String address, String city, String state, String zip_Code, String primary_Contact_First_Name, String primary_Contact_Last_Name, String primary_Contact_Phone, String primary_Contact_Email_Address, String secondary_Contact_First_Name1, String secondary_Contact_Last_Name1, String secondary_Contact_Phone1, String secondary_Contact_Email_Address1, Boolean offers_Befefits_To_Different_Classes, Boolean active, String company_Logo, Int32 company_Logo_Height, Int32 company_Logo_Width, Int32 company_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Name, address, city, state, zip_Code, primary_Contact_First_Name, primary_Contact_Last_Name, primary_Contact_Phone, primary_Contact_Email_Address, secondary_Contact_First_Name1, secondary_Contact_Last_Name1, secondary_Contact_Phone1, secondary_Contact_Email_Address1, offers_Befefits_To_Different_Classes, active, company_Logo, company_Logo_Height, company_Logo_Width, company_Id};
            DbParameter[] sps = new DbParameter[19];

            sps[0] = GetDbParameter("@Company_Name", CommonDbType.AnsiString, 50);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Address", CommonDbType.AnsiString, 50);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@City", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@State", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Zip_Code", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Primary_Contact_First_Name", CommonDbType.AnsiString, 50);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Primary_Contact_Last_Name", CommonDbType.AnsiString, 50);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@Primary_Contact_Phone", CommonDbType.AnsiString, 50);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@Primary_Contact_Email_Address", CommonDbType.AnsiString, 50);
            sps[8].Value = inputValues[8];

            sps[9] = GetDbParameter("@Secondary_Contact_First_Name1", CommonDbType.AnsiString, 50);
            sps[9].Value = inputValues[9];

            sps[10] = GetDbParameter("@Secondary_Contact_Last_Name1", CommonDbType.AnsiString, 50);
            sps[10].Value = inputValues[10];

            sps[11] = GetDbParameter("@Secondary_Contact_Phone1", CommonDbType.AnsiString, 50);
            sps[11].Value = inputValues[11];

            sps[12] = GetDbParameter("@Secondary_Contact_Email_Address1", CommonDbType.AnsiString, 50);
            sps[12].Value = inputValues[12];

            sps[13] = GetDbParameter("@Offers_Befefits_To_Different_Classes", CommonDbType.Boolean, 1);
            sps[13].Value = inputValues[13];

            sps[14] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[14].Value = inputValues[14];

            sps[15] = GetDbParameter("@Company_Logo", CommonDbType.AnsiString, 250);
            sps[15].Value = inputValues[15];

            sps[16] = GetDbParameter("@Company_Logo_Height", CommonDbType.Int32, 4);
            sps[16].Value = inputValues[16];

            sps[17] = GetDbParameter("@Company_Logo_Width", CommonDbType.Int32, 4);
            sps[17].Value = inputValues[17];

            sps[18] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[18].Value = inputValues[18];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_Companys_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateCompanys", "[dbo].[oSP_Update_Companys_PK]", rowsAffected, sqlcon, sps);
            return success;
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
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateCompanys(String company_Name, String company_Name_Original, String address, String address_Original, String city, String city_Original, String state, String state_Original, String zip_Code, String zip_Code_Original, String primary_Contact_First_Name, String primary_Contact_First_Name_Original, String primary_Contact_Last_Name, String primary_Contact_Last_Name_Original, String primary_Contact_Phone, String primary_Contact_Phone_Original, String primary_Contact_Email_Address, String primary_Contact_Email_Address_Original, String secondary_Contact_First_Name1, String secondary_Contact_First_Name1_Original, String secondary_Contact_Last_Name1, String secondary_Contact_Last_Name1_Original, String secondary_Contact_Phone1, String secondary_Contact_Phone1_Original, String secondary_Contact_Email_Address1, String secondary_Contact_Email_Address1_Original, Boolean offers_Befefits_To_Different_Classes, Boolean offers_Befefits_To_Different_Classes_Original, Boolean active, Boolean active_Original, String company_Logo, String company_Logo_Original, Int32 company_Logo_Height, Int32 company_Logo_Height_Original, Int32 company_Logo_Width, Int32 company_Logo_Width_Original, Int32 company_Id)
        {
            return UpdateCompanys(company_Name, company_Name_Original, address, address_Original, city, city_Original, state, state_Original, zip_Code, zip_Code_Original, primary_Contact_First_Name, primary_Contact_First_Name_Original, primary_Contact_Last_Name, primary_Contact_Last_Name_Original, primary_Contact_Phone, primary_Contact_Phone_Original, primary_Contact_Email_Address, primary_Contact_Email_Address_Original, secondary_Contact_First_Name1, secondary_Contact_First_Name1_Original, secondary_Contact_Last_Name1, secondary_Contact_Last_Name1_Original, secondary_Contact_Phone1, secondary_Contact_Phone1_Original, secondary_Contact_Email_Address1, secondary_Contact_Email_Address1_Original, offers_Befefits_To_Different_Classes, offers_Befefits_To_Different_Classes_Original, active, active_Original, company_Logo, company_Logo_Original, company_Logo_Height, company_Logo_Height_Original, company_Logo_Width, company_Logo_Width_Original, company_Id, (DbTransaction)null);
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
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateCompanys(String company_Name, String company_Name_Original, String address, String address_Original, String city, String city_Original, String state, String state_Original, String zip_Code, String zip_Code_Original, String primary_Contact_First_Name, String primary_Contact_First_Name_Original, String primary_Contact_Last_Name, String primary_Contact_Last_Name_Original, String primary_Contact_Phone, String primary_Contact_Phone_Original, String primary_Contact_Email_Address, String primary_Contact_Email_Address_Original, String secondary_Contact_First_Name1, String secondary_Contact_First_Name1_Original, String secondary_Contact_Last_Name1, String secondary_Contact_Last_Name1_Original, String secondary_Contact_Phone1, String secondary_Contact_Phone1_Original, String secondary_Contact_Email_Address1, String secondary_Contact_Email_Address1_Original, Boolean offers_Befefits_To_Different_Classes, Boolean offers_Befefits_To_Different_Classes_Original, Boolean active, Boolean active_Original, String company_Logo, String company_Logo_Original, Int32 company_Logo_Height, Int32 company_Logo_Height_Original, Int32 company_Logo_Width, Int32 company_Logo_Width_Original, Int32 company_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Name, company_Name_Original, address, address_Original, city, city_Original, state, state_Original, zip_Code, zip_Code_Original, primary_Contact_First_Name, primary_Contact_First_Name_Original, primary_Contact_Last_Name, primary_Contact_Last_Name_Original, primary_Contact_Phone, primary_Contact_Phone_Original, primary_Contact_Email_Address, primary_Contact_Email_Address_Original, secondary_Contact_First_Name1, secondary_Contact_First_Name1_Original, secondary_Contact_Last_Name1, secondary_Contact_Last_Name1_Original, secondary_Contact_Phone1, secondary_Contact_Phone1_Original, secondary_Contact_Email_Address1, secondary_Contact_Email_Address1_Original, offers_Befefits_To_Different_Classes, offers_Befefits_To_Different_Classes_Original, active, active_Original, company_Logo, company_Logo_Original, company_Logo_Height, company_Logo_Height_Original, company_Logo_Width, company_Logo_Width_Original, company_Id};
            DbParameter[] sps = new DbParameter[37];

            sps[0] = GetDbParameter("@Company_Name", CommonDbType.AnsiString, 50);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Company_Name_Original", CommonDbType.AnsiString, 50);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Address", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Address_Original", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@City", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@City_Original", CommonDbType.AnsiString, 50);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@State", CommonDbType.AnsiString, 50);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@State_Original", CommonDbType.AnsiString, 50);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@Zip_Code", CommonDbType.AnsiString, 50);
            sps[8].Value = inputValues[8];

            sps[9] = GetDbParameter("@Zip_Code_Original", CommonDbType.AnsiString, 50);
            sps[9].Value = inputValues[9];

            sps[10] = GetDbParameter("@Primary_Contact_First_Name", CommonDbType.AnsiString, 50);
            sps[10].Value = inputValues[10];

            sps[11] = GetDbParameter("@Primary_Contact_First_Name_Original", CommonDbType.AnsiString, 50);
            sps[11].Value = inputValues[11];

            sps[12] = GetDbParameter("@Primary_Contact_Last_Name", CommonDbType.AnsiString, 50);
            sps[12].Value = inputValues[12];

            sps[13] = GetDbParameter("@Primary_Contact_Last_Name_Original", CommonDbType.AnsiString, 50);
            sps[13].Value = inputValues[13];

            sps[14] = GetDbParameter("@Primary_Contact_Phone", CommonDbType.AnsiString, 50);
            sps[14].Value = inputValues[14];

            sps[15] = GetDbParameter("@Primary_Contact_Phone_Original", CommonDbType.AnsiString, 50);
            sps[15].Value = inputValues[15];

            sps[16] = GetDbParameter("@Primary_Contact_Email_Address", CommonDbType.AnsiString, 50);
            sps[16].Value = inputValues[16];

            sps[17] = GetDbParameter("@Primary_Contact_Email_Address_Original", CommonDbType.AnsiString, 50);
            sps[17].Value = inputValues[17];

            sps[18] = GetDbParameter("@Secondary_Contact_First_Name1", CommonDbType.AnsiString, 50);
            sps[18].Value = inputValues[18];

            sps[19] = GetDbParameter("@Secondary_Contact_First_Name1_Original", CommonDbType.AnsiString, 50);
            sps[19].Value = inputValues[19];

            sps[20] = GetDbParameter("@Secondary_Contact_Last_Name1", CommonDbType.AnsiString, 50);
            sps[20].Value = inputValues[20];

            sps[21] = GetDbParameter("@Secondary_Contact_Last_Name1_Original", CommonDbType.AnsiString, 50);
            sps[21].Value = inputValues[21];

            sps[22] = GetDbParameter("@Secondary_Contact_Phone1", CommonDbType.AnsiString, 50);
            sps[22].Value = inputValues[22];

            sps[23] = GetDbParameter("@Secondary_Contact_Phone1_Original", CommonDbType.AnsiString, 50);
            sps[23].Value = inputValues[23];

            sps[24] = GetDbParameter("@Secondary_Contact_Email_Address1", CommonDbType.AnsiString, 50);
            sps[24].Value = inputValues[24];

            sps[25] = GetDbParameter("@Secondary_Contact_Email_Address1_Original", CommonDbType.AnsiString, 50);
            sps[25].Value = inputValues[25];

            sps[26] = GetDbParameter("@Offers_Befefits_To_Different_Classes", CommonDbType.Boolean, 1);
            sps[26].Value = inputValues[26];

            sps[27] = GetDbParameter("@Offers_Befefits_To_Different_Classes_Original", CommonDbType.Boolean, 1);
            sps[27].Value = inputValues[27];

            sps[28] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[28].Value = inputValues[28];

            sps[29] = GetDbParameter("@Active_Original", CommonDbType.Boolean, 1);
            sps[29].Value = inputValues[29];

            sps[30] = GetDbParameter("@Company_Logo", CommonDbType.AnsiString, 250);
            sps[30].Value = inputValues[30];

            sps[31] = GetDbParameter("@Company_Logo_Original", CommonDbType.AnsiString, 250);
            sps[31].Value = inputValues[31];

            sps[32] = GetDbParameter("@Company_Logo_Height", CommonDbType.Int32, 4);
            sps[32].Value = inputValues[32];

            sps[33] = GetDbParameter("@Company_Logo_Height_Original", CommonDbType.Int32, 4);
            sps[33].Value = inputValues[33];

            sps[34] = GetDbParameter("@Company_Logo_Width", CommonDbType.Int32, 4);
            sps[34].Value = inputValues[34];

            sps[35] = GetDbParameter("@Company_Logo_Width_Original", CommonDbType.Int32, 4);
            sps[35].Value = inputValues[35];

            sps[36] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[36].Value = inputValues[36];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_Companys]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateCompanys", "[dbo].[oSP_Update_Companys]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Persists a new instance of Companys to the database.
        /// </summary>
        /// <param name="company_Id">Returns the value of company_Id. The database automatically generates this value. </param>
        public void InsertCompanys(String company_Name, String address, String city, String state, String zip_Code, String primary_Contact_First_Name, String primary_Contact_Last_Name, String primary_Contact_Phone, String primary_Contact_Email_Address, String secondary_Contact_First_Name1, String secondary_Contact_Last_Name1, String secondary_Contact_Phone1, String secondary_Contact_Email_Address1, Boolean offers_Befefits_To_Different_Classes, Boolean active, String company_Logo, Int32 company_Logo_Height, Int32 company_Logo_Width, ref Int32 company_Id)
        {
            InsertCompanys(company_Name, address, city, state, zip_Code, primary_Contact_First_Name, primary_Contact_Last_Name, primary_Contact_Phone, primary_Contact_Email_Address, secondary_Contact_First_Name1, secondary_Contact_Last_Name1, secondary_Contact_Phone1, secondary_Contact_Email_Address1, offers_Befefits_To_Different_Classes, active, company_Logo, company_Logo_Height, company_Logo_Width, ref company_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Persists a new instance of Companys to the database.
        /// </summary>
        /// <param name="company_Id">Returns the value of company_Id. The database automatically generates this value. </param>
        public void InsertCompanys(String company_Name, String address, String city, String state, String zip_Code, String primary_Contact_First_Name, String primary_Contact_Last_Name, String primary_Contact_Phone, String primary_Contact_Email_Address, String secondary_Contact_First_Name1, String secondary_Contact_Last_Name1, String secondary_Contact_Phone1, String secondary_Contact_Email_Address1, Boolean offers_Befefits_To_Different_Classes, Boolean active, String company_Logo, Int32 company_Logo_Height, Int32 company_Logo_Width, ref Int32 company_Id, DbTransaction tran)
        {

            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Name, address, city, state, zip_Code, primary_Contact_First_Name, primary_Contact_Last_Name, primary_Contact_Phone, primary_Contact_Email_Address, secondary_Contact_First_Name1, secondary_Contact_Last_Name1, secondary_Contact_Phone1, secondary_Contact_Email_Address1, offers_Befefits_To_Different_Classes, active, company_Logo, company_Logo_Height, company_Logo_Width, company_Id};
            DbParameter[] sps = new DbParameter[19];

            sps[0] = GetDbParameter("@Company_Name", CommonDbType.AnsiString, 50);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Address", CommonDbType.AnsiString, 50);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@City", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@State", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Zip_Code", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Primary_Contact_First_Name", CommonDbType.AnsiString, 50);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Primary_Contact_Last_Name", CommonDbType.AnsiString, 50);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@Primary_Contact_Phone", CommonDbType.AnsiString, 50);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@Primary_Contact_Email_Address", CommonDbType.AnsiString, 50);
            sps[8].Value = inputValues[8];

            sps[9] = GetDbParameter("@Secondary_Contact_First_Name1", CommonDbType.AnsiString, 50);
            sps[9].Value = inputValues[9];

            sps[10] = GetDbParameter("@Secondary_Contact_Last_Name1", CommonDbType.AnsiString, 50);
            sps[10].Value = inputValues[10];

            sps[11] = GetDbParameter("@Secondary_Contact_Phone1", CommonDbType.AnsiString, 50);
            sps[11].Value = inputValues[11];

            sps[12] = GetDbParameter("@Secondary_Contact_Email_Address1", CommonDbType.AnsiString, 50);
            sps[12].Value = inputValues[12];

            sps[13] = GetDbParameter("@Offers_Befefits_To_Different_Classes", CommonDbType.Boolean, 1);
            sps[13].Value = inputValues[13];

            sps[14] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[14].Value = inputValues[14];

            sps[15] = GetDbParameter("@Company_Logo", CommonDbType.AnsiString, 250);
            sps[15].Value = inputValues[15];

            sps[16] = GetDbParameter("@Company_Logo_Height", CommonDbType.Int32, 4);
            sps[16].Value = inputValues[16];

            sps[17] = GetDbParameter("@Company_Logo_Width", CommonDbType.Int32, 4);
            sps[17].Value = inputValues[17];

            sps[18] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[18].Direction = ParameterDirection.InputOutput;
            sps[18].Value = inputValues[18];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Insert_Companys]", sps);
            if( ! DBNull.Value.Equals(sps[18].Value) )
            {
               company_Id = (Int32)(sps[18].Value);
            }
            else
            {
               company_Id = 0;
            }


            FinalizeConnection(sqlcon, tran);
            LogDataActivity("InsertCompanys", "[dbo].[oSP_Insert_Companys]", rowsAffected, sqlcon, sps);
        }
        
        public List<Companys> GetCompanyByCompanyName(String company_Name)
        {
            return GetCompanyByCompanyName(company_Name, (DbTransaction)null);
        }

        public List<Companys> GetCompanyByCompanyName(String company_Name, DbTransaction tran)
        {
            List<Companys> dataList;
            DbConnection sqlcon = InitializeConnection(tran);
    
            object[] inputValues = new object[] { company_Name };
            DbParameter[] sps = new DbParameter[1];
                        
            sps[0] = GetDbParameter("@CompanyName", CommonDbType.String, 50);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Company_By_Company_Name]", sps);

            dataList = new List<Bar.Data.Companys>();

            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int addressOrdinal = dr.GetOrdinal("Address");
            int cityOrdinal = dr.GetOrdinal("City");
            int stateOrdinal = dr.GetOrdinal("State");
            int zip_CodeOrdinal = dr.GetOrdinal("Zip_Code");
            int primary_Contact_First_NameOrdinal = dr.GetOrdinal("Primary_Contact_First_Name");
            int primary_Contact_Last_NameOrdinal = dr.GetOrdinal("Primary_Contact_Last_Name");
            int primary_Contact_PhoneOrdinal = dr.GetOrdinal("Primary_Contact_Phone");
            int primary_Contact_Email_AddressOrdinal = dr.GetOrdinal("Primary_Contact_Email_Address");
            int secondary_Contact_First_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_First_Name1");
            int secondary_Contact_Last_Name1Ordinal = dr.GetOrdinal("Secondary_Contact_Last_Name1");
            int secondary_Contact_Phone1Ordinal = dr.GetOrdinal("Secondary_Contact_Phone1");
            int secondary_Contact_Email_Address1Ordinal = dr.GetOrdinal("Secondary_Contact_Email_Address1");
            int offers_Befefits_To_Different_ClassesOrdinal = dr.GetOrdinal("Offers_Befefits_To_Different_Classes");
            int activeOrdinal = dr.GetOrdinal("Active");
            int company_LogoOrdinal = dr.GetOrdinal("Company_Logo");
            int company_Logo_HeightOrdinal = dr.GetOrdinal("Company_Logo_Height");
            int company_Logo_WidthOrdinal = dr.GetOrdinal("Company_Logo_Width");

            while (dr.Read())
            {
                dataList.Add(new Bar.Data.Companys(dr.GetInt32(company_IdOrdinal),
                    dr.GetString(company_NameOrdinal),
                    dr.GetString(addressOrdinal),
                    dr.GetString(cityOrdinal),
                    dr.GetString(stateOrdinal),
                    dr.GetString(zip_CodeOrdinal),
                    dr.GetString(primary_Contact_First_NameOrdinal),
                    dr.GetString(primary_Contact_Last_NameOrdinal),
                    dr.GetString(primary_Contact_PhoneOrdinal),
                    dr.GetString(primary_Contact_Email_AddressOrdinal),
                    dr.GetString(secondary_Contact_First_Name1Ordinal),
                    dr.GetString(secondary_Contact_Last_Name1Ordinal),
                    dr.GetString(secondary_Contact_Phone1Ordinal),
                    dr.GetString(secondary_Contact_Email_Address1Ordinal),
                    dr.GetBoolean(offers_Befefits_To_Different_ClassesOrdinal),
                    dr.GetBoolean(activeOrdinal),
                    dr.GetString(company_LogoOrdinal),
                    dr.GetInt32(company_Logo_HeightOrdinal),
                    dr.GetInt32(company_Logo_WidthOrdinal)));
            }

            dr.Close();
            
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetCompanys", "[dbo].[oSP_Select_Companys_All_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        #endregion 

        #region Exception_Log 

        /// <summary>
        /// Returns all instances of Exception_Log.
        /// </summary>
        /// <results>Returns a strongly typed list of Exception_Log. </results>
        public List<Exception_Log> GetAllException_Log()
        {
            return GetAllException_Log((DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Exception_Log.
        /// </summary>
        /// <results>Returns a strongly typed list of Exception_Log. </results>
        public List<Exception_Log> GetAllException_Log(DbTransaction tran)
        {

            List<Exception_Log> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Exception_Log_All]", sps);

            dataList = new List<Bar.Data.Exception_Log>();

            int exception_Log_IdOrdinal = dr.GetOrdinal("Exception_Log_Id");
            int exception_MessageOrdinal = dr.GetOrdinal("Exception_Message");
            int name_SpaceOrdinal = dr.GetOrdinal("Name_Space");
            int methodOrdinal = dr.GetOrdinal("Method");
            int created_DateOrdinal = dr.GetOrdinal("Created_Date");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Exception_Log(dr.GetInt32(exception_Log_IdOrdinal), 
                   dr.GetString(exception_MessageOrdinal), 
                   dr.GetString(name_SpaceOrdinal), 
                   dr.GetString(methodOrdinal), 
                   dr.GetDateTime(created_DateOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetAllException_Log", "[dbo].[oSP_Select_Exception_Log_All]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of Exception_Log. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Exception_Log. </results>
        public List<Exception_Log> GetException_Log(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetException_Log(startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Exception_Log. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Exception_Log. </results>
        public List<Exception_Log> GetException_Log(Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<Exception_Log> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[2].Direction = ParameterDirection.InputOutput;
            sps[2].Value = inputValues[2];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Exception_Log_All_Paged]", sps);

            dataList = new List<Bar.Data.Exception_Log>();

            int exception_Log_IdOrdinal = dr.GetOrdinal("Exception_Log_Id");
            int exception_MessageOrdinal = dr.GetOrdinal("Exception_Message");
            int name_SpaceOrdinal = dr.GetOrdinal("Name_Space");
            int methodOrdinal = dr.GetOrdinal("Method");
            int created_DateOrdinal = dr.GetOrdinal("Created_Date");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Exception_Log(dr.GetInt32(exception_Log_IdOrdinal), 
                   dr.GetString(exception_MessageOrdinal), 
                   dr.GetString(name_SpaceOrdinal), 
                   dr.GetString(methodOrdinal), 
                   dr.GetDateTime(created_DateOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[2].Value) )
            {
               totalCount = (Int64)(sps[2].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetException_Log", "[dbo].[oSP_Select_Exception_Log_All_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Persists a new instance of Exception_Log to the database.
        /// </summary>
        /// <param name="exception_Log_Id">Returns the value of exception_Log_Id. The database automatically generates this value. </param>
        public void InsertException_Log(String exception_Message, String name_Space, String method, DateTime created_Date, ref Int32 exception_Log_Id)
        {
            InsertException_Log(exception_Message, name_Space, method, created_Date, ref exception_Log_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Persists a new instance of Exception_Log to the database.
        /// </summary>
        /// <param name="exception_Log_Id">Returns the value of exception_Log_Id. The database automatically generates this value. </param>
        public void InsertException_Log(String exception_Message, String name_Space, String method, DateTime created_Date, ref Int32 exception_Log_Id, DbTransaction tran)
        {

            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {exception_Message, name_Space, method, created_Date, exception_Log_Id};
            DbParameter[] sps = new DbParameter[5];

            sps[0] = GetDbParameter("@Exception_Message", CommonDbType.AnsiString);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Name_Space", CommonDbType.AnsiString, 150);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Method", CommonDbType.AnsiString, 150);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Created_Date", CommonDbType.DateTime, 8);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Exception_Log_Id", CommonDbType.Int32, 4);
            sps[4].Direction = ParameterDirection.InputOutput;
            sps[4].Value = inputValues[4];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Insert_Exception_Log]", sps);
            if( ! DBNull.Value.Equals(sps[4].Value) )
            {
               exception_Log_Id = (Int32)(sps[4].Value);
            }
            else
            {
               exception_Log_Id = 0;
            }


            FinalizeConnection(sqlcon, tran);
            LogDataActivity("InsertException_Log", "[dbo].[oSP_Insert_Exception_Log]", rowsAffected, sqlcon, sps);
        }

        #endregion 

        #region Roles 

        /// <summary>
        /// Returns an instance of List<Bar.Data.Roles>.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public List<Roles> GetRolesByRole_Id(Int32 role_Id)
        {
            return GetRolesByRole_Id(role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns an instance of List<Bar.Data.Roles>.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public List<Roles> GetRolesByRole_Id(Int32 role_Id, DbTransaction tran)
        {

            List<Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {role_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Roles_PK]", sps);

            dataList = new List<Bar.Data.Roles>();

            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int roleOrdinal = dr.GetOrdinal("Role");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Roles(dr.GetInt32(role_IdOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetRolesByRole_Id", "[dbo].[oSP_Select_Roles_PK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of Roles.
        /// </summary>
        /// <results>Returns a strongly typed list of Roles. </results>
        public List<Roles> GetAllRoles()
        {
            return GetAllRoles((DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Roles.
        /// </summary>
        /// <results>Returns a strongly typed list of Roles. </results>
        public List<Roles> GetAllRoles(DbTransaction tran)
        {

            List<Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Roles_All]", sps);

            dataList = new List<Bar.Data.Roles>();

            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int roleOrdinal = dr.GetOrdinal("Role");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Roles(dr.GetInt32(role_IdOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetAllRoles", "[dbo].[oSP_Select_Roles_All]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of Roles. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public List<Roles> GetRoles(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetRoles(startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Roles. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public List<Roles> GetRoles(Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[2].Direction = ParameterDirection.InputOutput;
            sps[2].Value = inputValues[2];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Roles_All_Paged]", sps);

            dataList = new List<Bar.Data.Roles>();

            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int roleOrdinal = dr.GetOrdinal("Role");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Roles(dr.GetInt32(role_IdOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[2].Value) )
            {
               totalCount = (Int64)(sps[2].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetRoles", "[dbo].[oSP_Select_Roles_All_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Deletes an instance of Roles based on Role_Id.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteRoles(Int32 role_Id)
        {
            return DeleteRoles(role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of Roles based on Role_Id.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteRoles(Int32 role_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {role_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_Roles_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteRoles", "[dbo].[oSP_Delete_Roles_PK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Deletes all instances of Roles.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllRoles()
        {
            return DeleteAllRoles((DbTransaction)null);
        }

        /// <summary>
        /// Deletes all instances of Roles.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllRoles(DbTransaction tran)
        {

            Int32 rowsAffected;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_Roles_All]", sps);

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteAllRoles", "[dbo].[oSP_Delete_Roles_All]", rowsAffected, sqlcon, sps);
            return rowsAffected;
        }

        /// <summary>
        /// Updates an instance of Roles.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateRoles(String role, Boolean active, Int32 role_Id)
        {
            return UpdateRoles(role, active, role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Updates an instance of Roles.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateRoles(String role, Boolean active, Int32 role_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {role, active, role_Id};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@Role", CommonDbType.AnsiString, 50);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[2].Value = inputValues[2];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_Roles_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateRoles", "[dbo].[oSP_Update_Roles_PK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Updates an instance of Roles if the original data has not changed.
        /// </summary>
        /// <param name="role_Original">This field is used for optimistic concurrency management. It should contain the original value of 'role_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateRoles(String role, String role_Original, Boolean active, Boolean active_Original, Int32 role_Id)
        {
            return UpdateRoles(role, role_Original, active, active_Original, role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Updates an instance of Roles if the original data has not changed.
        /// </summary>
        /// <param name="role_Original">This field is used for optimistic concurrency management. It should contain the original value of 'role_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateRoles(String role, String role_Original, Boolean active, Boolean active_Original, Int32 role_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {role, role_Original, active, active_Original, role_Id};
            DbParameter[] sps = new DbParameter[5];

            sps[0] = GetDbParameter("@Role", CommonDbType.AnsiString, 50);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Role_Original", CommonDbType.AnsiString, 50);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Active_Original", CommonDbType.Boolean, 1);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[4].Value = inputValues[4];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_Roles]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateRoles", "[dbo].[oSP_Update_Roles]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Persists a new instance of Roles to the database.
        /// </summary>
        /// <param name="role_Id">Returns the value of role_Id. The database automatically generates this value. </param>
        public void InsertRoles(String role, Boolean active, ref Int32 role_Id)
        {
            InsertRoles(role, active, ref role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Persists a new instance of Roles to the database.
        /// </summary>
        /// <param name="role_Id">Returns the value of role_Id. The database automatically generates this value. </param>
        public void InsertRoles(String role, Boolean active, ref Int32 role_Id, DbTransaction tran)
        {

            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {role, active, role_Id};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@Role", CommonDbType.AnsiString, 50);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[2].Direction = ParameterDirection.InputOutput;
            sps[2].Value = inputValues[2];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Insert_Roles]", sps);
            if( ! DBNull.Value.Equals(sps[2].Value) )
            {
               role_Id = (Int32)(sps[2].Value);
            }
            else
            {
               role_Id = 0;
            }


            FinalizeConnection(sqlcon, tran);
            LogDataActivity("InsertRoles", "[dbo].[oSP_Insert_Roles]", rowsAffected, sqlcon, sps);
        }

        #endregion 

        #region Site_LogIns 

        /// <summary>
        /// Returns an instance of List<Bar.Data.Site_LogIns>.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogInsBySite_LogIn_Id(Int32 site_LogIn_Id)
        {
            return GetSite_LogInsBySite_LogIn_Id(site_LogIn_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns an instance of List<Bar.Data.Site_LogIns>.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogInsBySite_LogIn_Id(Int32 site_LogIn_Id, DbTransaction tran)
        {

            List<Site_LogIns> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {site_LogIn_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Site_LogIn_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Site_LogIns_PK]", sps);

            dataList = new List<Bar.Data.Site_LogIns>();

            int site_LogIn_IdOrdinal = dr.GetOrdinal("Site_LogIn_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int session_Session_IdOrdinal = dr.GetOrdinal("Session_Session_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int roleOrdinal = dr.GetOrdinal("Role");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int createdDateOrdinal = dr.GetOrdinal("CreatedDate");
            int logOutDateOrdinal = dr.GetOrdinal("LogOutDate");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Site_LogIns(dr.GetInt32(site_LogIn_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetString(session_Session_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetDateTime(createdDateOrdinal), 
                   dr.IsDBNull(logOutDateOrdinal) ? null : new Nullable<DateTime>(dr.GetDateTime(logOutDateOrdinal))));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSite_LogInsBySite_LogIn_Id", "[dbo].[oSP_Select_Site_LogIns_PK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of Site_LogIns.
        /// </summary>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetAllSite_LogIns()
        {
            return GetAllSite_LogIns((DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Site_LogIns.
        /// </summary>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetAllSite_LogIns(DbTransaction tran)
        {

            List<Site_LogIns> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Site_LogIns_All]", sps);

            dataList = new List<Bar.Data.Site_LogIns>();

            int site_LogIn_IdOrdinal = dr.GetOrdinal("Site_LogIn_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int session_Session_IdOrdinal = dr.GetOrdinal("Session_Session_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int roleOrdinal = dr.GetOrdinal("Role");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int createdDateOrdinal = dr.GetOrdinal("CreatedDate");
            int logOutDateOrdinal = dr.GetOrdinal("LogOutDate");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Site_LogIns(dr.GetInt32(site_LogIn_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetString(session_Session_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetDateTime(createdDateOrdinal), 
                   dr.IsDBNull(logOutDateOrdinal) ? null : new Nullable<DateTime>(dr.GetDateTime(logOutDateOrdinal))));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetAllSite_LogIns", "[dbo].[oSP_Select_Site_LogIns_All]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of Site_LogIns. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogIns(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetSite_LogIns(startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of Site_LogIns. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogIns(Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<Site_LogIns> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[2].Direction = ParameterDirection.InputOutput;
            sps[2].Value = inputValues[2];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Site_LogIns_All_Paged]", sps);

            dataList = new List<Bar.Data.Site_LogIns>();

            int site_LogIn_IdOrdinal = dr.GetOrdinal("Site_LogIn_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int session_Session_IdOrdinal = dr.GetOrdinal("Session_Session_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int roleOrdinal = dr.GetOrdinal("Role");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int createdDateOrdinal = dr.GetOrdinal("CreatedDate");
            int logOutDateOrdinal = dr.GetOrdinal("LogOutDate");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Site_LogIns(dr.GetInt32(site_LogIn_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetString(session_Session_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetDateTime(createdDateOrdinal), 
                   dr.IsDBNull(logOutDateOrdinal) ? null : new Nullable<DateTime>(dr.GetDateTime(logOutDateOrdinal))));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[2].Value) )
            {
               totalCount = (Int64)(sps[2].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSite_LogIns", "[dbo].[oSP_Select_Site_LogIns_All_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of Site_LogIns based on the following criteria: System_User_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogInsBySystem_User_Id(Int32 system_User_Id)
        {
            return GetSite_LogInsBySystem_User_Id(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of Site_LogIns based on the following criteria: System_User_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogInsBySystem_User_Id(Int32 system_User_Id, DbTransaction tran)
        {

            List<Site_LogIns> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Site_LogIns_By_System_Users_System_User_Id_FK]", sps);

            dataList = new List<Bar.Data.Site_LogIns>();

            int site_LogIn_IdOrdinal = dr.GetOrdinal("Site_LogIn_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int session_Session_IdOrdinal = dr.GetOrdinal("Session_Session_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int roleOrdinal = dr.GetOrdinal("Role");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int createdDateOrdinal = dr.GetOrdinal("CreatedDate");
            int logOutDateOrdinal = dr.GetOrdinal("LogOutDate");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Site_LogIns(dr.GetInt32(site_LogIn_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetString(session_Session_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetDateTime(createdDateOrdinal), 
                   dr.IsDBNull(logOutDateOrdinal) ? null : new Nullable<DateTime>(dr.GetDateTime(logOutDateOrdinal))));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSite_LogInsBySystem_User_Id", "[dbo].[oSP_Select_Site_LogIns_By_System_Users_System_User_Id_FK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of Site_LogIns filtered on the following criteria: System_User_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogInsBySystem_User_Id(Int32 system_User_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetSite_LogInsBySystem_User_Id(system_User_Id, startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of Site_LogIns filtered on the following criteria: System_User_Id. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogInsBySystem_User_Id(Int32 system_User_Id, Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<Site_LogIns> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {system_User_Id, startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[4];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[3].Direction = ParameterDirection.InputOutput;
            sps[3].Value = inputValues[3];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_Site_LogIns_By_System_Users_System_User_Id_FK_Paged]", sps);

            dataList = new List<Bar.Data.Site_LogIns>();

            int site_LogIn_IdOrdinal = dr.GetOrdinal("Site_LogIn_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int session_Session_IdOrdinal = dr.GetOrdinal("Session_Session_Id");
            int company_NameOrdinal = dr.GetOrdinal("Company_Name");
            int roleOrdinal = dr.GetOrdinal("Role");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int createdDateOrdinal = dr.GetOrdinal("CreatedDate");
            int logOutDateOrdinal = dr.GetOrdinal("LogOutDate");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.Site_LogIns(dr.GetInt32(site_LogIn_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetString(session_Session_IdOrdinal), 
                   dr.GetString(company_NameOrdinal), 
                   dr.GetString(roleOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetDateTime(createdDateOrdinal), 
                   dr.IsDBNull(logOutDateOrdinal) ? null : new Nullable<DateTime>(dr.GetDateTime(logOutDateOrdinal))));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[3].Value) )
            {
               totalCount = (Int64)(sps[3].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSite_LogInsBySystem_User_Id", "[dbo].[oSP_Select_Site_LogIns_By_System_Users_System_User_Id_FK_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Deletes an instance of Site_LogIns based on Site_LogIn_Id.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSite_LogIns(Int32 site_LogIn_Id)
        {
            return DeleteSite_LogIns(site_LogIn_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of Site_LogIns based on Site_LogIn_Id.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSite_LogIns(Int32 site_LogIn_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {site_LogIn_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Site_LogIn_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_Site_LogIns_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteSite_LogIns", "[dbo].[oSP_Delete_Site_LogIns_PK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Deletes all instances of Site_LogIns.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllSite_LogIns()
        {
            return DeleteAllSite_LogIns((DbTransaction)null);
        }

        /// <summary>
        /// Deletes all instances of Site_LogIns.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllSite_LogIns(DbTransaction tran)
        {

            Int32 rowsAffected;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_Site_LogIns_All]", sps);

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteAllSite_LogIns", "[dbo].[oSP_Delete_Site_LogIns_All]", rowsAffected, sqlcon, sps);
            return rowsAffected;
        }

        /// <summary>
        /// Deletes an instance of Site_LogIns based on System_User_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSite_LogInsBySystem_User_Id(Int32 system_User_Id)
        {
            return DeleteSite_LogInsBySystem_User_Id(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of Site_LogIns based on System_User_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSite_LogInsBySystem_User_Id(Int32 system_User_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_Site_LogIns_By_System_Users_System_User_Id_FK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteSite_LogInsBySystem_User_Id", "[dbo].[oSP_Delete_Site_LogIns_By_System_Users_System_User_Id_FK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Updates an instance of Site_LogIns.
        /// </summary>
        /// <param name="logOutDate">This is not a required field. </param>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSite_LogIns(Int32 system_User_Id, String session_Session_Id, String company_Name, String role, String first_Name, String last_Name, String email_Address, DateTime createdDate, DateTime? logOutDate, Int32 site_LogIn_Id)
        {
            return UpdateSite_LogIns(system_User_Id, session_Session_Id, company_Name, role, first_Name, last_Name, email_Address, createdDate, logOutDate, site_LogIn_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Updates an instance of Site_LogIns.
        /// </summary>
        /// <param name="logOutDate">This is not a required field. </param>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSite_LogIns(Int32 system_User_Id, String session_Session_Id, String company_Name, String role, String first_Name, String last_Name, String email_Address, DateTime createdDate, DateTime? logOutDate, Int32 site_LogIn_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id, session_Session_Id, company_Name, role, first_Name, last_Name, email_Address, createdDate, logOutDate, site_LogIn_Id};
            DbParameter[] sps = new DbParameter[10];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Session_Session_Id", CommonDbType.AnsiString, 150);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Company_Name", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Role", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@First_Name", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Last_Name", CommonDbType.AnsiString, 50);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Email_Address", CommonDbType.AnsiString, 50);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@CreatedDate", CommonDbType.DateTime, 8);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@LogOutDate", CommonDbType.DateTime, 8);
            if (logOutDate.HasValue)
            {
               sps[8].Value = inputValues[8];
            }
            else
            {
               sps[8].Value = DBNull.Value;
            }

            sps[9] = GetDbParameter("@Site_LogIn_Id", CommonDbType.Int32, 4);
            sps[9].Value = inputValues[9];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_Site_LogIns_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateSite_LogIns", "[dbo].[oSP_Update_Site_LogIns_PK]", rowsAffected, sqlcon, sps);
            return success;
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
        /// <param name="logOutDate">This is not a required field. </param>
        /// <param name="logOutDate_Original">This field is used for optimistic concurrency management. It should contain the original value of 'logOutDate_Original'. This is not a required field. </param>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSite_LogIns(Int32 system_User_Id, Int32 system_User_Id_Original, String session_Session_Id, String session_Session_Id_Original, String company_Name, String company_Name_Original, String role, String role_Original, String first_Name, String first_Name_Original, String last_Name, String last_Name_Original, String email_Address, String email_Address_Original, DateTime createdDate, DateTime createdDate_Original, DateTime? logOutDate, DateTime? logOutDate_Original, Int32 site_LogIn_Id)
        {
            return UpdateSite_LogIns(system_User_Id, system_User_Id_Original, session_Session_Id, session_Session_Id_Original, company_Name, company_Name_Original, role, role_Original, first_Name, first_Name_Original, last_Name, last_Name_Original, email_Address, email_Address_Original, createdDate, createdDate_Original, logOutDate, logOutDate_Original, site_LogIn_Id, (DbTransaction)null);
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
        /// <param name="logOutDate">This is not a required field. </param>
        /// <param name="logOutDate_Original">This field is used for optimistic concurrency management. It should contain the original value of 'logOutDate_Original'. This is not a required field. </param>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSite_LogIns(Int32 system_User_Id, Int32 system_User_Id_Original, String session_Session_Id, String session_Session_Id_Original, String company_Name, String company_Name_Original, String role, String role_Original, String first_Name, String first_Name_Original, String last_Name, String last_Name_Original, String email_Address, String email_Address_Original, DateTime createdDate, DateTime createdDate_Original, DateTime? logOutDate, DateTime? logOutDate_Original, Int32 site_LogIn_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id, system_User_Id_Original, session_Session_Id, session_Session_Id_Original, company_Name, company_Name_Original, role, role_Original, first_Name, first_Name_Original, last_Name, last_Name_Original, email_Address, email_Address_Original, createdDate, createdDate_Original, logOutDate, logOutDate_Original, site_LogIn_Id};
            DbParameter[] sps = new DbParameter[19];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@System_User_Id_Original", CommonDbType.Int32, 4);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Session_Session_Id", CommonDbType.AnsiString, 150);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Session_Session_Id_Original", CommonDbType.AnsiString, 150);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Company_Name", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Company_Name_Original", CommonDbType.AnsiString, 50);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Role", CommonDbType.AnsiString, 50);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@Role_Original", CommonDbType.AnsiString, 50);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@First_Name", CommonDbType.AnsiString, 50);
            sps[8].Value = inputValues[8];

            sps[9] = GetDbParameter("@First_Name_Original", CommonDbType.AnsiString, 50);
            sps[9].Value = inputValues[9];

            sps[10] = GetDbParameter("@Last_Name", CommonDbType.AnsiString, 50);
            sps[10].Value = inputValues[10];

            sps[11] = GetDbParameter("@Last_Name_Original", CommonDbType.AnsiString, 50);
            sps[11].Value = inputValues[11];

            sps[12] = GetDbParameter("@Email_Address", CommonDbType.AnsiString, 50);
            sps[12].Value = inputValues[12];

            sps[13] = GetDbParameter("@Email_Address_Original", CommonDbType.AnsiString, 50);
            sps[13].Value = inputValues[13];

            sps[14] = GetDbParameter("@CreatedDate", CommonDbType.DateTime, 8);
            sps[14].Value = inputValues[14];

            sps[15] = GetDbParameter("@CreatedDate_Original", CommonDbType.DateTime, 8);
            sps[15].Value = inputValues[15];

            sps[16] = GetDbParameter("@LogOutDate", CommonDbType.DateTime, 8);
            if (logOutDate.HasValue)
            {
               sps[16].Value = inputValues[16];
            }
            else
            {
               sps[16].Value = DBNull.Value;
            }

            sps[17] = GetDbParameter("@LogOutDate_Original", CommonDbType.DateTime, 8);
            if (logOutDate_Original.HasValue)
            {
               sps[17].Value = inputValues[17];
            }
            else
            {
               sps[17].Value = DBNull.Value;
            }

            sps[18] = GetDbParameter("@Site_LogIn_Id", CommonDbType.Int32, 4);
            sps[18].Value = inputValues[18];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_Site_LogIns]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateSite_LogIns", "[dbo].[oSP_Update_Site_LogIns]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Persists a new instance of Site_LogIns to the database.
        /// </summary>
        /// <param name="logOutDate">This is not a required field. </param>
        /// <param name="site_LogIn_Id">Returns the value of site_LogIn_Id. The database automatically generates this value. </param>
        public void InsertSite_LogIns(Int32 system_User_Id, String session_Session_Id, String company_Name, String role, String first_Name, String last_Name, String email_Address, DateTime createdDate, DateTime? logOutDate, ref Int32 site_LogIn_Id)
        {
            InsertSite_LogIns(system_User_Id, session_Session_Id, company_Name, role, first_Name, last_Name, email_Address, createdDate, logOutDate, ref site_LogIn_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Persists a new instance of Site_LogIns to the database.
        /// </summary>
        /// <param name="logOutDate">This is not a required field. </param>
        /// <param name="site_LogIn_Id">Returns the value of site_LogIn_Id. The database automatically generates this value. </param>
        public void InsertSite_LogIns(Int32 system_User_Id, String session_Session_Id, String company_Name, String role, String first_Name, String last_Name, String email_Address, DateTime createdDate, DateTime? logOutDate, ref Int32 site_LogIn_Id, DbTransaction tran)
        {

            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id, session_Session_Id, company_Name, role, first_Name, last_Name, email_Address, createdDate, logOutDate, site_LogIn_Id};
            DbParameter[] sps = new DbParameter[10];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Session_Session_Id", CommonDbType.AnsiString, 150);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Company_Name", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Role", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@First_Name", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Last_Name", CommonDbType.AnsiString, 50);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Email_Address", CommonDbType.AnsiString, 50);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@CreatedDate", CommonDbType.DateTime, 8);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@LogOutDate", CommonDbType.DateTime, 8);
            if (logOutDate.HasValue)
            {
               sps[8].Value = inputValues[8];
            }
            else
            {
               sps[8].Value = DBNull.Value;
            }

            sps[9] = GetDbParameter("@Site_LogIn_Id", CommonDbType.Int32, 4);
            sps[9].Direction = ParameterDirection.InputOutput;
            sps[9].Value = inputValues[9];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Insert_Site_LogIns]", sps);
            if( ! DBNull.Value.Equals(sps[9].Value) )
            {
               site_LogIn_Id = (Int32)(sps[9].Value);
            }
            else
            {
               site_LogIn_Id = 0;
            }


            FinalizeConnection(sqlcon, tran);
            LogDataActivity("InsertSite_LogIns", "[dbo].[oSP_Insert_Site_LogIns]", rowsAffected, sqlcon, sps);
        }

        #endregion 

        #region System_User_Roles 

        /// <summary>
        /// Returns an instance of List<Bar.Data.System_User_Roles>.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesBySystem_User_Role_Id(Int32 system_User_Role_Id)
        {
            return GetSystem_User_RolesBySystem_User_Role_Id(system_User_Role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns an instance of List<Bar.Data.System_User_Roles>.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesBySystem_User_Role_Id(Int32 system_User_Role_Id, DbTransaction tran)
        {

            List<System_User_Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Role_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Role_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_User_Roles_PK]", sps);

            dataList = new List<Bar.Data.System_User_Roles>();

            int system_User_Role_IdOrdinal = dr.GetOrdinal("System_User_Role_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_User_Roles(dr.GetInt32(system_User_Role_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(role_IdOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_User_RolesBySystem_User_Role_Id", "[dbo].[oSP_Select_System_User_Roles_PK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of System_User_Roles.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetAllSystem_User_Roles()
        {
            return GetAllSystem_User_Roles((DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of System_User_Roles.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetAllSystem_User_Roles(DbTransaction tran)
        {

            List<System_User_Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_User_Roles_All]", sps);

            dataList = new List<Bar.Data.System_User_Roles>();

            int system_User_Role_IdOrdinal = dr.GetOrdinal("System_User_Role_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_User_Roles(dr.GetInt32(system_User_Role_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(role_IdOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetAllSystem_User_Roles", "[dbo].[oSP_Select_System_User_Roles_All]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of System_User_Roles. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_Roles(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetSystem_User_Roles(startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of System_User_Roles. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_Roles(Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<System_User_Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[2].Direction = ParameterDirection.InputOutput;
            sps[2].Value = inputValues[2];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_User_Roles_All_Paged]", sps);

            dataList = new List<Bar.Data.System_User_Roles>();

            int system_User_Role_IdOrdinal = dr.GetOrdinal("System_User_Role_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_User_Roles(dr.GetInt32(system_User_Role_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(role_IdOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[2].Value) )
            {
               totalCount = (Int64)(sps[2].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_User_Roles", "[dbo].[oSP_Select_System_User_Roles_All_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of System_User_Roles based on the following criteria: System_User_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesBySystem_User_Id(Int32 system_User_Id)
        {
            return GetSystem_User_RolesBySystem_User_Id(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of System_User_Roles based on the following criteria: System_User_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesBySystem_User_Id(Int32 system_User_Id, DbTransaction tran)
        {

            List<System_User_Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_User_Roles_By_System_Users_System_User_Id_FK]", sps);

            dataList = new List<Bar.Data.System_User_Roles>();

            int system_User_Role_IdOrdinal = dr.GetOrdinal("System_User_Role_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_User_Roles(dr.GetInt32(system_User_Role_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(role_IdOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_User_RolesBySystem_User_Id", "[dbo].[oSP_Select_System_User_Roles_By_System_Users_System_User_Id_FK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: System_User_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesBySystem_User_Id(Int32 system_User_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetSystem_User_RolesBySystem_User_Id(system_User_Id, startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: System_User_Id. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesBySystem_User_Id(Int32 system_User_Id, Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<System_User_Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {system_User_Id, startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[4];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[3].Direction = ParameterDirection.InputOutput;
            sps[3].Value = inputValues[3];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_User_Roles_By_System_Users_System_User_Id_FK_Paged]", sps);

            dataList = new List<Bar.Data.System_User_Roles>();

            int system_User_Role_IdOrdinal = dr.GetOrdinal("System_User_Role_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_User_Roles(dr.GetInt32(system_User_Role_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(role_IdOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[3].Value) )
            {
               totalCount = (Int64)(sps[3].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_User_RolesBySystem_User_Id", "[dbo].[oSP_Select_System_User_Roles_By_System_Users_System_User_Id_FK_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of System_User_Roles based on the following criteria: Role_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesByRole_Id(Int32 role_Id)
        {
            return GetSystem_User_RolesByRole_Id(role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of System_User_Roles based on the following criteria: Role_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesByRole_Id(Int32 role_Id, DbTransaction tran)
        {

            List<System_User_Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {role_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_User_Roles_By_Roles_Role_Id_FK]", sps);

            dataList = new List<Bar.Data.System_User_Roles>();

            int system_User_Role_IdOrdinal = dr.GetOrdinal("System_User_Role_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_User_Roles(dr.GetInt32(system_User_Role_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(role_IdOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_User_RolesByRole_Id", "[dbo].[oSP_Select_System_User_Roles_By_Roles_Role_Id_FK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: Role_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesByRole_Id(Int32 role_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetSystem_User_RolesByRole_Id(role_Id, startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: Role_Id. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesByRole_Id(Int32 role_Id, Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<System_User_Roles> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {role_Id, startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[4];

            sps[0] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[3].Direction = ParameterDirection.InputOutput;
            sps[3].Value = inputValues[3];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_User_Roles_By_Roles_Role_Id_FK_Paged]", sps);

            dataList = new List<Bar.Data.System_User_Roles>();

            int system_User_Role_IdOrdinal = dr.GetOrdinal("System_User_Role_Id");
            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int role_IdOrdinal = dr.GetOrdinal("Role_Id");
            int activeOrdinal = dr.GetOrdinal("Active");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_User_Roles(dr.GetInt32(system_User_Role_IdOrdinal), 
                   dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(role_IdOrdinal), 
                   dr.GetBoolean(activeOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[3].Value) )
            {
               totalCount = (Int64)(sps[3].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_User_RolesByRole_Id", "[dbo].[oSP_Select_System_User_Roles_By_Roles_Role_Id_FK_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Deletes an instance of System_User_Roles based on System_User_Role_Id.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_User_Roles(Int32 system_User_Role_Id)
        {
            return DeleteSystem_User_Roles(system_User_Role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of System_User_Roles based on System_User_Role_Id.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_User_Roles(Int32 system_User_Role_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Role_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Role_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_System_User_Roles_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteSystem_User_Roles", "[dbo].[oSP_Delete_System_User_Roles_PK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Deletes all instances of System_User_Roles.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllSystem_User_Roles()
        {
            return DeleteAllSystem_User_Roles((DbTransaction)null);
        }

        /// <summary>
        /// Deletes all instances of System_User_Roles.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllSystem_User_Roles(DbTransaction tran)
        {

            Int32 rowsAffected;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_System_User_Roles_All]", sps);

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteAllSystem_User_Roles", "[dbo].[oSP_Delete_System_User_Roles_All]", rowsAffected, sqlcon, sps);
            return rowsAffected;
        }

        /// <summary>
        /// Deletes an instance of System_User_Roles based on System_User_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_User_RolesBySystem_User_Id(Int32 system_User_Id)
        {
            return DeleteSystem_User_RolesBySystem_User_Id(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of System_User_Roles based on System_User_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_User_RolesBySystem_User_Id(Int32 system_User_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_System_User_Roles_By_System_Users_System_User_Id_FK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteSystem_User_RolesBySystem_User_Id", "[dbo].[oSP_Delete_System_User_Roles_By_System_Users_System_User_Id_FK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Deletes an instance of System_User_Roles based on Role_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_User_RolesByRole_Id(Int32 role_Id)
        {
            return DeleteSystem_User_RolesByRole_Id(role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of System_User_Roles based on Role_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_User_RolesByRole_Id(Int32 role_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {role_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_System_User_Roles_By_Roles_Role_Id_FK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteSystem_User_RolesByRole_Id", "[dbo].[oSP_Delete_System_User_Roles_By_Roles_Role_Id_FK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Updates an instance of System_User_Roles.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_User_Roles(Int32 system_User_Id, Int32 role_Id, Boolean active, Int32 system_User_Role_Id)
        {
            return UpdateSystem_User_Roles(system_User_Id, role_Id, active, system_User_Role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Updates an instance of System_User_Roles.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_User_Roles(Int32 system_User_Id, Int32 role_Id, Boolean active, Int32 system_User_Role_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id, role_Id, active, system_User_Role_Id};
            DbParameter[] sps = new DbParameter[4];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@System_User_Role_Id", CommonDbType.Int32, 4);
            sps[3].Value = inputValues[3];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_System_User_Roles_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateSystem_User_Roles", "[dbo].[oSP_Update_System_User_Roles_PK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Updates an instance of System_User_Roles if the original data has not changed.
        /// </summary>
        /// <param name="system_User_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'system_User_Id_Original'. </param>
        /// <param name="role_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'role_Id_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_User_Roles(Int32 system_User_Id, Int32 system_User_Id_Original, Int32 role_Id, Int32 role_Id_Original, Boolean active, Boolean active_Original, Int32 system_User_Role_Id)
        {
            return UpdateSystem_User_Roles(system_User_Id, system_User_Id_Original, role_Id, role_Id_Original, active, active_Original, system_User_Role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Updates an instance of System_User_Roles if the original data has not changed.
        /// </summary>
        /// <param name="system_User_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'system_User_Id_Original'. </param>
        /// <param name="role_Id_Original">This field is used for optimistic concurrency management. It should contain the original value of 'role_Id_Original'. </param>
        /// <param name="active_Original">This field is used for optimistic concurrency management. It should contain the original value of 'active_Original'. </param>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_User_Roles(Int32 system_User_Id, Int32 system_User_Id_Original, Int32 role_Id, Int32 role_Id_Original, Boolean active, Boolean active_Original, Int32 system_User_Role_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id, system_User_Id_Original, role_Id, role_Id_Original, active, active_Original, system_User_Role_Id};
            DbParameter[] sps = new DbParameter[7];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@System_User_Id_Original", CommonDbType.Int32, 4);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Role_Id_Original", CommonDbType.Int32, 4);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Active_Original", CommonDbType.Boolean, 1);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@System_User_Role_Id", CommonDbType.Int32, 4);
            sps[6].Value = inputValues[6];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_System_User_Roles]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateSystem_User_Roles", "[dbo].[oSP_Update_System_User_Roles]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Persists a new instance of System_User_Roles to the database.
        /// </summary>
        /// <param name="system_User_Role_Id">Returns the value of system_User_Role_Id. The database automatically generates this value. </param>
        public void InsertSystem_User_Roles(Int32 system_User_Id, Int32 role_Id, Boolean active, ref Int32 system_User_Role_Id)
        {
            InsertSystem_User_Roles(system_User_Id, role_Id, active, ref system_User_Role_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Persists a new instance of System_User_Roles to the database.
        /// </summary>
        /// <param name="system_User_Role_Id">Returns the value of system_User_Role_Id. The database automatically generates this value. </param>
        public void InsertSystem_User_Roles(Int32 system_User_Id, Int32 role_Id, Boolean active, ref Int32 system_User_Role_Id, DbTransaction tran)
        {

            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id, role_Id, active, system_User_Role_Id};
            DbParameter[] sps = new DbParameter[4];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Role_Id", CommonDbType.Int32, 4);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@System_User_Role_Id", CommonDbType.Int32, 4);
            sps[3].Direction = ParameterDirection.InputOutput;
            sps[3].Value = inputValues[3];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Insert_System_User_Roles]", sps);
            if( ! DBNull.Value.Equals(sps[3].Value) )
            {
               system_User_Role_Id = (Int32)(sps[3].Value);
            }
            else
            {
               system_User_Role_Id = 0;
            }


            FinalizeConnection(sqlcon, tran);
            LogDataActivity("InsertSystem_User_Roles", "[dbo].[oSP_Insert_System_User_Roles]", rowsAffected, sqlcon, sps);
        }

        #endregion 

        #region System_Users 

        /// <summary>
        /// Returns an instance of List<Bar.Data.System_Users>.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_UsersBySystem_User_Id(Int32 system_User_Id)
        {
            return GetSystem_UsersBySystem_User_Id(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns an instance of List<Bar.Data.System_Users>.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_UsersBySystem_User_Id(Int32 system_User_Id, DbTransaction tran)
        {

            List<System_Users> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_Users_PK]", sps);

            dataList = new List<Bar.Data.System_Users>();

            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int login_IdOrdinal = dr.GetOrdinal("Login_Id");
            int hashOrdinal = dr.GetOrdinal("Hash");
            int saltOrdinal = dr.GetOrdinal("Salt");
            int activeOrdinal = dr.GetOrdinal("Active");
            int created_DateOrdinal = dr.GetOrdinal("Created_Date");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_Users(dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetString(login_IdOrdinal), 
                   ReadBytes(dr, hashOrdinal), 
                   ReadBytes(dr, saltOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetDateTime(created_DateOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_UsersBySystem_User_Id", "[dbo].[oSP_Select_System_Users_PK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a 'Byte[]' from a binary field of a record based on the primary key.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a single instance of Byte[]. </results>
        public Byte[] GetSystem_UsersHashBySystem_User_Id(Int32 system_User_Id)
        {
            return GetSystem_UsersHashBySystem_User_Id(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a 'Byte[]' from a binary field of a record based on the primary key.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a single instance of Byte[]. </results>
        public Byte[] GetSystem_UsersHashBySystem_User_Id(Int32 system_User_Id, DbTransaction tran)
        {

            System.Byte[] scalarReturnValue;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            object obj = GetScalar(sqlcon, tran, "[dbo].[oSP_HashSystem_Users_PB]", sps);

            if(obj != null)
            {
               scalarReturnValue = (Byte[])obj;
            }
            else
            {
               scalarReturnValue = null;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_UsersHashBySystem_User_Id", "[dbo].[oSP_HashSystem_Users_PB]", -1, sqlcon, sps);
            return scalarReturnValue;
        }

        /// <summary>
        /// Returns a 'Byte[]' from a binary field of a record based on the primary key.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a single instance of Byte[]. </results>
        public Byte[] GetSystem_UsersSaltBySystem_User_Id(Int32 system_User_Id)
        {
            return GetSystem_UsersSaltBySystem_User_Id(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a 'Byte[]' from a binary field of a record based on the primary key.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a single instance of Byte[]. </results>
        public Byte[] GetSystem_UsersSaltBySystem_User_Id(Int32 system_User_Id, DbTransaction tran)
        {

            System.Byte[] scalarReturnValue;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            object obj = GetScalar(sqlcon, tran, "[dbo].[oSP_SaltSystem_Users_PB]", sps);

            if(obj != null)
            {
               scalarReturnValue = (Byte[])obj;
            }
            else
            {
               scalarReturnValue = null;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_UsersSaltBySystem_User_Id", "[dbo].[oSP_SaltSystem_Users_PB]", -1, sqlcon, sps);
            return scalarReturnValue;
        }

        /// <summary>
        /// Returns all instances of System_Users.
        /// </summary>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetAllSystem_Users()
        {
            return GetAllSystem_Users((DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of System_Users.
        /// </summary>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetAllSystem_Users(DbTransaction tran)
        {

            List<System_Users> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_Users_All]", sps);

            dataList = new List<Bar.Data.System_Users>();

            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int login_IdOrdinal = dr.GetOrdinal("Login_Id");
            int hashOrdinal = dr.GetOrdinal("Hash");
            int saltOrdinal = dr.GetOrdinal("Salt");
            int activeOrdinal = dr.GetOrdinal("Active");
            int created_DateOrdinal = dr.GetOrdinal("Created_Date");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_Users(dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetString(login_IdOrdinal), 
                   ReadBytes(dr, hashOrdinal), 
                   ReadBytes(dr, saltOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetDateTime(created_DateOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetAllSystem_Users", "[dbo].[oSP_Select_System_Users_All]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns all instances of System_Users. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_Users(Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetSystem_Users(startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns all instances of System_Users. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_Users(Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<System_Users> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[3];

            sps[0] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[2].Direction = ParameterDirection.InputOutput;
            sps[2].Value = inputValues[2];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_Users_All_Paged]", sps);

            dataList = new List<Bar.Data.System_Users>();

            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int login_IdOrdinal = dr.GetOrdinal("Login_Id");
            int hashOrdinal = dr.GetOrdinal("Hash");
            int saltOrdinal = dr.GetOrdinal("Salt");
            int activeOrdinal = dr.GetOrdinal("Active");
            int created_DateOrdinal = dr.GetOrdinal("Created_Date");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_Users(dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetString(login_IdOrdinal), 
                   ReadBytes(dr, hashOrdinal), 
                   ReadBytes(dr, saltOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetDateTime(created_DateOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[2].Value) )
            {
               totalCount = (Int64)(sps[2].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_Users", "[dbo].[oSP_Select_System_Users_All_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of System_Users based on the following criteria: Company_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_UsersByCompany_Id(Int32 company_Id)
        {
            return GetSystem_UsersByCompany_Id(company_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of System_Users based on the following criteria: Company_Id.
        /// </summary>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_UsersByCompany_Id(Int32 company_Id, DbTransaction tran)
        {

            List<System_Users> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_Users_By_Companys_Company_Id_FK]", sps);

            dataList = new List<Bar.Data.System_Users>();

            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int login_IdOrdinal = dr.GetOrdinal("Login_Id");
            int hashOrdinal = dr.GetOrdinal("Hash");
            int saltOrdinal = dr.GetOrdinal("Salt");
            int activeOrdinal = dr.GetOrdinal("Active");
            int created_DateOrdinal = dr.GetOrdinal("Created_Date");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_Users(dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetString(login_IdOrdinal), 
                   ReadBytes(dr, hashOrdinal), 
                   ReadBytes(dr, saltOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetDateTime(created_DateOrdinal)));
            }

            dr.Close();

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_UsersByCompany_Id", "[dbo].[oSP_Select_System_Users_By_Companys_Company_Id_FK]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Returns a collection of System_Users filtered on the following criteria: Company_Id. The PageNr, PageSize, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="pageSize">This paging parameter sets the number of items in a page. </param>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="pageNr">This paging parameter determines which data set (page) to display. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_UsersByCompany_Id(Int32 company_Id, Int32 pageSize, Int32 startingRowNumber, Int32 pageNr, out Int64 totalCount)
        {

            Int32 endingRowNumber;
            GetStartRowAndEndRowForPaging(pageSize, pageNr, ref startingRowNumber, out endingRowNumber, out totalCount);
            return GetSystem_UsersByCompany_Id(company_Id, startingRowNumber, endingRowNumber, out totalCount, (DbTransaction)null);
        }

        /// <summary>
        /// Returns a collection of System_Users filtered on the following criteria: Company_Id. The EndingRowNumber, StartingRowNumber, TotalCount parameters are used for paging.
        /// </summary>
        /// <param name="startingRowNumber">The row or item to start from. </param>
        /// <param name="totalCount">The number of items in the entire set. Returns the value of totalCount. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_UsersByCompany_Id(Int32 company_Id, Int32 startingRowNumber, Int32 endingRowNumber, out Int64 totalCount, DbTransaction tran)
        {

            List<System_Users> dataList;
            DbConnection sqlcon = InitializeConnection(tran);

            totalCount = 0;
            object[] inputValues = new object[] {company_Id, startingRowNumber, endingRowNumber, totalCount};
            DbParameter[] sps = new DbParameter[4];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@StartingRowNumber", CommonDbType.Int32, 8);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@EndingRowNumber", CommonDbType.Int32, 8);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@TotalCount", CommonDbType.Int64, 8);
            sps[3].Direction = ParameterDirection.InputOutput;
            sps[3].Value = inputValues[3];

            DbDataReader dr = GetData(sqlcon, tran, "[dbo].[oSP_Select_System_Users_By_Companys_Company_Id_FK_Paged]", sps);

            dataList = new List<Bar.Data.System_Users>();

            int system_User_IdOrdinal = dr.GetOrdinal("System_User_Id");
            int company_IdOrdinal = dr.GetOrdinal("Company_Id");
            int first_NameOrdinal = dr.GetOrdinal("First_Name");
            int last_NameOrdinal = dr.GetOrdinal("Last_Name");
            int email_AddressOrdinal = dr.GetOrdinal("Email_Address");
            int login_IdOrdinal = dr.GetOrdinal("Login_Id");
            int hashOrdinal = dr.GetOrdinal("Hash");
            int saltOrdinal = dr.GetOrdinal("Salt");
            int activeOrdinal = dr.GetOrdinal("Active");
            int created_DateOrdinal = dr.GetOrdinal("Created_Date");

            while (dr.Read())
            {
               dataList.Add(new Bar.Data.System_Users(dr.GetInt32(system_User_IdOrdinal), 
                   dr.GetInt32(company_IdOrdinal), 
                   dr.GetString(first_NameOrdinal), 
                   dr.GetString(last_NameOrdinal), 
                   dr.GetString(email_AddressOrdinal), 
                   dr.GetString(login_IdOrdinal), 
                   ReadBytes(dr, hashOrdinal), 
                   ReadBytes(dr, saltOrdinal), 
                   dr.GetBoolean(activeOrdinal), 
                   dr.GetDateTime(created_DateOrdinal)));
            }

            dr.Close();

            if( ! DBNull.Value.Equals(sps[3].Value) )
            {
               totalCount = (Int64)(sps[3].Value);
            }
            else
            {
               totalCount = 0;
            }

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("GetSystem_UsersByCompany_Id", "[dbo].[oSP_Select_System_Users_By_Companys_Company_Id_FK_Paged]", -1, sqlcon, sps);
            return dataList;
        }

        /// <summary>
        /// Deletes an instance of System_Users based on System_User_Id.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_Users(Int32 system_User_Id)
        {
            return DeleteSystem_Users(system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of System_Users based on System_User_Id.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_Users(Int32 system_User_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {system_User_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_System_Users_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteSystem_Users", "[dbo].[oSP_Delete_System_Users_PK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Deletes all instances of System_Users.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllSystem_Users()
        {
            return DeleteAllSystem_Users((DbTransaction)null);
        }

        /// <summary>
        /// Deletes all instances of System_Users.
        /// </summary>
        /// <results>The number of items deleted. </results>
        public Int32 DeleteAllSystem_Users(DbTransaction tran)
        {

            Int32 rowsAffected;
            DbConnection sqlcon = InitializeConnection(tran);

            DbParameter[] sps = new DbParameter[0];

            rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_System_Users_All]", sps);

            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteAllSystem_Users", "[dbo].[oSP_Delete_System_Users_All]", rowsAffected, sqlcon, sps);
            return rowsAffected;
        }

        /// <summary>
        /// Deletes an instance of System_Users based on Company_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_UsersByCompany_Id(Int32 company_Id)
        {
            return DeleteSystem_UsersByCompany_Id(company_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Deletes an instance of System_Users based on Company_Id.
        /// </summary>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public Boolean DeleteSystem_UsersByCompany_Id(Int32 company_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Id};
            DbParameter[] sps = new DbParameter[1];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Delete_System_Users_By_Companys_Company_Id_FK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("DeleteSystem_UsersByCompany_Id", "[dbo].[oSP_Delete_System_Users_By_Companys_Company_Id_FK]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Updates an instance of System_Users.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_Users(Int32 company_Id, String first_Name, String last_Name, String email_Address, String login_Id, Byte[] hash, Byte[] salt, Boolean active, DateTime created_Date, Int32 system_User_Id)
        {
            return UpdateSystem_Users(company_Id, first_Name, last_Name, email_Address, login_Id, hash, salt, active, created_Date, system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Updates an instance of System_Users.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_Users(Int32 company_Id, String first_Name, String last_Name, String email_Address, String login_Id, Byte[] hash, Byte[] salt, Boolean active, DateTime created_Date, Int32 system_User_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Id, first_Name, last_Name, email_Address, login_Id, hash, salt, active, created_Date, system_User_Id};
            DbParameter[] sps = new DbParameter[10];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@First_Name", CommonDbType.AnsiString, 50);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Last_Name", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Email_Address", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Login_Id", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Hash", CommonDbType.VarBinary, 250);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Salt", CommonDbType.VarBinary, 250);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@Created_Date", CommonDbType.DateTime, 8);
            sps[8].Value = inputValues[8];

            sps[9] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[9].Value = inputValues[9];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_System_Users_PK]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateSystem_Users", "[dbo].[oSP_Update_System_Users_PK]", rowsAffected, sqlcon, sps);
            return success;
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
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_Users(Int32 company_Id, Int32 company_Id_Original, String first_Name, String first_Name_Original, String last_Name, String last_Name_Original, String email_Address, String email_Address_Original, String login_Id, String login_Id_Original, Byte[] hash, Byte[] hash_Original, Byte[] salt, Byte[] salt_Original, Boolean active, Boolean active_Original, DateTime created_Date, DateTime created_Date_Original, Int32 system_User_Id)
        {
            return UpdateSystem_Users(company_Id, company_Id_Original, first_Name, first_Name_Original, last_Name, last_Name_Original, email_Address, email_Address_Original, login_Id, login_Id_Original, hash, hash_Original, salt, salt_Original, active, active_Original, created_Date, created_Date_Original, system_User_Id, (DbTransaction)null);
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
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_Users(Int32 company_Id, Int32 company_Id_Original, String first_Name, String first_Name_Original, String last_Name, String last_Name_Original, String email_Address, String email_Address_Original, String login_Id, String login_Id_Original, Byte[] hash, Byte[] hash_Original, Byte[] salt, Byte[] salt_Original, Boolean active, Boolean active_Original, DateTime created_Date, DateTime created_Date_Original, Int32 system_User_Id, DbTransaction tran)
        {

            Boolean success;
            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Id, company_Id_Original, first_Name, first_Name_Original, last_Name, last_Name_Original, email_Address, email_Address_Original, login_Id, login_Id_Original, hash, hash_Original, salt, salt_Original, active, active_Original, created_Date, created_Date_Original, system_User_Id};
            DbParameter[] sps = new DbParameter[19];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@Company_Id_Original", CommonDbType.Int32, 4);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@First_Name", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@First_Name_Original", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Last_Name", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Last_Name_Original", CommonDbType.AnsiString, 50);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Email_Address", CommonDbType.AnsiString, 50);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@Email_Address_Original", CommonDbType.AnsiString, 50);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@Login_Id", CommonDbType.AnsiString, 50);
            sps[8].Value = inputValues[8];

            sps[9] = GetDbParameter("@Login_Id_Original", CommonDbType.AnsiString, 50);
            sps[9].Value = inputValues[9];

            sps[10] = GetDbParameter("@Hash", CommonDbType.VarBinary, 250);
            sps[10].Value = inputValues[10];

            sps[11] = GetDbParameter("@Hash_Original", CommonDbType.VarBinary, 250);
            sps[11].Value = inputValues[11];

            sps[12] = GetDbParameter("@Salt", CommonDbType.VarBinary, 250);
            sps[12].Value = inputValues[12];

            sps[13] = GetDbParameter("@Salt_Original", CommonDbType.VarBinary, 250);
            sps[13].Value = inputValues[13];

            sps[14] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[14].Value = inputValues[14];

            sps[15] = GetDbParameter("@Active_Original", CommonDbType.Boolean, 1);
            sps[15].Value = inputValues[15];

            sps[16] = GetDbParameter("@Created_Date", CommonDbType.DateTime, 8);
            sps[16].Value = inputValues[16];

            sps[17] = GetDbParameter("@Created_Date_Original", CommonDbType.DateTime, 8);
            sps[17].Value = inputValues[17];

            sps[18] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[18].Value = inputValues[18];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Update_System_Users]", sps);

            success = ( rowsAffected > 0 );
            FinalizeConnection(sqlcon, tran);
            LogDataActivity("UpdateSystem_Users", "[dbo].[oSP_Update_System_Users]", rowsAffected, sqlcon, sps);
            return success;
        }

        /// <summary>
        /// Persists a new instance of System_Users to the database.
        /// </summary>
        /// <param name="system_User_Id">Returns the value of system_User_Id. The database automatically generates this value. </param>
        public void InsertSystem_Users(Int32 company_Id, String first_Name, String last_Name, String email_Address, String login_Id, Byte[] hash, Byte[] salt, Boolean active, DateTime created_Date, ref Int32 system_User_Id)
        {
            InsertSystem_Users(company_Id, first_Name, last_Name, email_Address, login_Id, hash, salt, active, created_Date, ref system_User_Id, (DbTransaction)null);
        }

        /// <summary>
        /// Persists a new instance of System_Users to the database.
        /// </summary>
        /// <param name="system_User_Id">Returns the value of system_User_Id. The database automatically generates this value. </param>
        public void InsertSystem_Users(Int32 company_Id, String first_Name, String last_Name, String email_Address, String login_Id, Byte[] hash, Byte[] salt, Boolean active, DateTime created_Date, ref Int32 system_User_Id, DbTransaction tran)
        {

            DbConnection sqlcon = InitializeConnection(tran);

            object[] inputValues = new object[] {company_Id, first_Name, last_Name, email_Address, login_Id, hash, salt, active, created_Date, system_User_Id};
            DbParameter[] sps = new DbParameter[10];

            sps[0] = GetDbParameter("@Company_Id", CommonDbType.Int32, 4);
            sps[0].Value = inputValues[0];

            sps[1] = GetDbParameter("@First_Name", CommonDbType.AnsiString, 50);
            sps[1].Value = inputValues[1];

            sps[2] = GetDbParameter("@Last_Name", CommonDbType.AnsiString, 50);
            sps[2].Value = inputValues[2];

            sps[3] = GetDbParameter("@Email_Address", CommonDbType.AnsiString, 50);
            sps[3].Value = inputValues[3];

            sps[4] = GetDbParameter("@Login_Id", CommonDbType.AnsiString, 50);
            sps[4].Value = inputValues[4];

            sps[5] = GetDbParameter("@Hash", CommonDbType.VarBinary, 250);
            sps[5].Value = inputValues[5];

            sps[6] = GetDbParameter("@Salt", CommonDbType.VarBinary, 250);
            sps[6].Value = inputValues[6];

            sps[7] = GetDbParameter("@Active", CommonDbType.Boolean, 1);
            sps[7].Value = inputValues[7];

            sps[8] = GetDbParameter("@Created_Date", CommonDbType.DateTime, 8);
            sps[8].Value = inputValues[8];

            sps[9] = GetDbParameter("@System_User_Id", CommonDbType.Int32, 4);
            sps[9].Direction = ParameterDirection.InputOutput;
            sps[9].Value = inputValues[9];

            int rowsAffected = ExecuteNonQuery(sqlcon, tran, "[dbo].[oSP_Insert_System_Users]", sps);
            if( ! DBNull.Value.Equals(sps[9].Value) )
            {
               system_User_Id = (Int32)(sps[9].Value);
            }
            else
            {
               system_User_Id = 0;
            }


            FinalizeConnection(sqlcon, tran);
            LogDataActivity("InsertSystem_Users", "[dbo].[oSP_Insert_System_Users]", rowsAffected, sqlcon, sps);
        }

        #endregion 

   }

}

