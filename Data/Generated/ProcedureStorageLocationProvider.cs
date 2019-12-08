
using System;
using System.Collections.Generic;
using System.Text;

namespace OxyData.Data
{
    public static partial class ProcedureStorageLocationProvider
    {
        private static string[] _ResourceCommands = new string[] 
        {
 
        };
        private static string[] _DbCommands = new string[] 
        {
               "[dbo].[oSP_Select_Companys_PK]", 
               "[dbo].[oSP_Select_Companys_All]", 
               "[dbo].[oSP_Select_Companys_All_Paged]", 
               "[dbo].[oSP_Delete_Companys_PK]", 
               "[dbo].[oSP_Delete_Companys_All]", 
               "[dbo].[oSP_Update_Companys_PK]", 
               "[dbo].[oSP_Update_Companys]", 
               "[dbo].[oSP_Insert_Companys]", 
               "[dbo].[oSP_Select_Exception_Log_All]", 
               "[dbo].[oSP_Select_Exception_Log_All_Paged]", 
               "[dbo].[oSP_Insert_Exception_Log]", 
               "[dbo].[oSP_Select_Roles_PK]", 
               "[dbo].[oSP_Select_Roles_All]", 
               "[dbo].[oSP_Select_Roles_All_Paged]", 
               "[dbo].[oSP_Delete_Roles_PK]", 
               "[dbo].[oSP_Delete_Roles_All]", 
               "[dbo].[oSP_Update_Roles_PK]", 
               "[dbo].[oSP_Update_Roles]", 
               "[dbo].[oSP_Insert_Roles]", 
               "[dbo].[oSP_Select_Site_LogIns_PK]", 
               "[dbo].[oSP_Select_Site_LogIns_All]", 
               "[dbo].[oSP_Select_Site_LogIns_All_Paged]", 
               "[dbo].[oSP_Select_Site_LogIns_By_System_Users_System_User_Id_FK]", 
               "[dbo].[oSP_Select_Site_LogIns_By_System_Users_System_User_Id_FK_Paged]", 
               "[dbo].[oSP_Delete_Site_LogIns_PK]", 
               "[dbo].[oSP_Delete_Site_LogIns_All]", 
               "[dbo].[oSP_Delete_Site_LogIns_By_System_Users_System_User_Id_FK]", 
               "[dbo].[oSP_Update_Site_LogIns_PK]", 
               "[dbo].[oSP_Update_Site_LogIns]", 
               "[dbo].[oSP_Insert_Site_LogIns]", 
               "[dbo].[oSP_Select_System_User_Roles_PK]", 
               "[dbo].[oSP_Select_System_User_Roles_All]", 
               "[dbo].[oSP_Select_System_User_Roles_All_Paged]", 
               "[dbo].[oSP_Select_System_User_Roles_By_System_Users_System_User_Id_FK]", 
               "[dbo].[oSP_Select_System_User_Roles_By_System_Users_System_User_Id_FK_Paged]", 
               "[dbo].[oSP_Select_System_User_Roles_By_Roles_Role_Id_FK]", 
               "[dbo].[oSP_Select_System_User_Roles_By_Roles_Role_Id_FK_Paged]", 
               "[dbo].[oSP_Delete_System_User_Roles_PK]", 
               "[dbo].[oSP_Delete_System_User_Roles_All]", 
               "[dbo].[oSP_Delete_System_User_Roles_By_System_Users_System_User_Id_FK]", 
               "[dbo].[oSP_Delete_System_User_Roles_By_Roles_Role_Id_FK]", 
               "[dbo].[oSP_Update_System_User_Roles_PK]", 
               "[dbo].[oSP_Update_System_User_Roles]", 
               "[dbo].[oSP_Insert_System_User_Roles]", 
               "[dbo].[oSP_Select_System_Users_PK]", 
               "[dbo].[oSP_HashSystem_Users_PB]", 
               "[dbo].[oSP_SaltSystem_Users_PB]", 
               "[dbo].[oSP_Select_System_Users_All]", 
               "[dbo].[oSP_Select_System_Users_All_Paged]", 
               "[dbo].[oSP_Select_System_Users_By_Companys_Company_Id_FK]", 
               "[dbo].[oSP_Select_System_Users_By_Companys_Company_Id_FK_Paged]", 
               "[dbo].[oSP_Delete_System_Users_PK]", 
               "[dbo].[oSP_Delete_System_Users_All]", 
               "[dbo].[oSP_Delete_System_Users_By_Companys_Company_Id_FK]", 
               "[dbo].[oSP_Update_System_Users_PK]", 
               "[dbo].[oSP_Update_System_Users]", 
               "[dbo].[oSP_Insert_System_Users]", 

        };
    }
}
