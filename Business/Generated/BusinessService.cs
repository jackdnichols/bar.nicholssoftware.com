

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OxyData.Data;
using OxyData.Business;

namespace Bar.Business
{

   /// <summary>
   /// A selection of the services offered by the Business Layer.
   /// This a PrimaryBusinessService class that represents a BusinessService.
   /// </summary>
   public partial class BusinessService
   {
        /// <summary>
        /// Returns all instances of Companys. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public List<Companys> GetAllCompanys(PagingInfo pagingInfo)
        {
            List<Companys> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = Companys.GetAll();
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = Companys.GetAll(pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Returns an instance of List<Bar.Business.Companys>.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Companys. </results>
        public  List<Companys> GetCompanysByCompany_Id(Int32 company_Id)
        {
            List<Companys> value;
            value = Companys.GetCompanysByCompany_Id(company_Id);

            return value;
        }
        /// <summary>
        /// Get the instance of Companys that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of Companys.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        public Companys GetCompanys(Int32 company_Id)
        {
            Companys businessValue;
            businessValue = Companys.GetCompanys(company_Id);
            return businessValue;

        }

        /// <summary>
        /// Persists a new instance of Companys to the database.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        public  void InsertCompanys(Companys companys)
        {

            Companys.Insert(companys);

        }
        /// <summary>
        /// Deletes an instance of Companys based on Company_Id.
        /// </summary>
        /// <param name="company_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteCompanys(Int32 company_Id)
        {
            System.Boolean value;
            value = Companys.DeleteCompanys(company_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of Companys based on companys.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteCompanys(Companys companys)
        {
            System.Boolean value;
            value = Companys.Delete(companys);

            return value;
        }
        /// <summary>
        /// Updates an instance of Companys.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateCompanys(Companys companys)
        {
            System.Boolean val;

            val = companys.Update();
            return val;

        }
        /// <summary>
        /// Updates an instance of Companys if the underlying data has not changed. The original instance is Companys_Original. To bypass the concurrency check, pass in 'null' for the Companys_Original parameter.
        /// </summary>
        /// <param name="companys">The instance of companys to persist. </param>
        /// <param name="companys_Original">The original instance of companys. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateCompanys(Companys companys, Companys companys_Original)
        {
            System.Boolean val;

            if(companys_Original == null)
            {
               val = companys.Update();

            }
            else
            {
               val = Companys.Update(companys, companys_Original);

            }
            return val;

        }
        /// <summary>
        /// Returns all instances of Exception_Log. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of Exception_Log. </results>
        public List<Exception_Log> GetAllException_Log(PagingInfo pagingInfo)
        {
            List<Exception_Log> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = Exception_Log.GetAll();
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = Exception_Log.GetAll(pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Persists a new instance of Exception_Log to the database.
        /// </summary>
        /// <param name="exception_Log">The instance of exception_Log to persist. </param>
        public  void InsertException_Log(Exception_Log exception_Log)
        {

            Exception_Log.Insert(exception_Log);

        }
        /// <summary>
        /// Returns all instances of Roles. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public List<Roles> GetAllRoles(PagingInfo pagingInfo)
        {
            List<Roles> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = Roles.GetAll();
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = Roles.GetAll(pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Returns an instance of List<Bar.Business.Roles>.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Roles. </results>
        public  List<Roles> GetRolesByRole_Id(Int32 role_Id)
        {
            List<Roles> value;
            value = Roles.GetRolesByRole_Id(role_Id);

            return value;
        }
        /// <summary>
        /// Get the instance of Roles that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of Roles.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        public Roles GetRoles(Int32 role_Id)
        {
            Roles businessValue;
            businessValue = Roles.GetRoles(role_Id);
            return businessValue;

        }

        /// <summary>
        /// Persists a new instance of Roles to the database.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        public  void InsertRoles(Roles roles)
        {

            Roles.Insert(roles);

        }
        /// <summary>
        /// Deletes an instance of Roles based on Role_Id.
        /// </summary>
        /// <param name="role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteRoles(Int32 role_Id)
        {
            System.Boolean value;
            value = Roles.DeleteRoles(role_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of Roles based on roles.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteRoles(Roles roles)
        {
            System.Boolean value;
            value = Roles.Delete(roles);

            return value;
        }
        /// <summary>
        /// Updates an instance of Roles.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateRoles(Roles roles)
        {
            System.Boolean val;

            val = roles.Update();
            return val;

        }
        /// <summary>
        /// Updates an instance of Roles if the underlying data has not changed. The original instance is Roles_Original. To bypass the concurrency check, pass in 'null' for the Roles_Original parameter.
        /// </summary>
        /// <param name="roles">The instance of roles to persist. </param>
        /// <param name="roles_Original">The original instance of roles. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateRoles(Roles roles, Roles roles_Original)
        {
            System.Boolean val;

            if(roles_Original == null)
            {
               val = roles.Update();

            }
            else
            {
               val = Roles.Update(roles, roles_Original);

            }
            return val;

        }
        /// <summary>
        /// Returns all instances of Site_LogIns. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetAllSite_LogIns(PagingInfo pagingInfo)
        {
            List<Site_LogIns> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = Site_LogIns.GetAll();
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = Site_LogIns.GetAll(pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Returns an instance of List<Bar.Business.Site_LogIns>.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public  List<Site_LogIns> GetSite_LogInsBySite_LogIn_Id(Int32 site_LogIn_Id)
        {
            List<Site_LogIns> value;
            value = Site_LogIns.GetSite_LogInsBySite_LogIn_Id(site_LogIn_Id);

            return value;
        }
        /// <summary>
        /// Get the instance of Site_LogIns that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of Site_LogIns.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        public Site_LogIns GetSite_LogIns(Int32 site_LogIn_Id)
        {
            Site_LogIns businessValue;
            businessValue = Site_LogIns.GetSite_LogIns(site_LogIn_Id);
            return businessValue;

        }

        /// <summary>
        /// Returns a collection of Site_LogIns filtered on the following criteria: System_User_Id. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of Site_LogIns. </results>
        public List<Site_LogIns> GetSite_LogInsBySystem_User_Id(Int32 system_User_Id, PagingInfo pagingInfo)
        {
            List<Site_LogIns> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = Site_LogIns.GetSite_LogInsBySystem_User_Id(system_User_Id);
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = Site_LogIns.GetSite_LogInsBySystem_User_Id(system_User_Id, pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Persists a new instance of Site_LogIns to the database.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        public  void InsertSite_LogIns(Site_LogIns site_LogIns)
        {

            Site_LogIns.Insert(site_LogIns);

        }
        /// <summary>
        /// Deletes an instance of Site_LogIns based on Site_LogIn_Id.
        /// </summary>
        /// <param name="site_LogIn_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteSite_LogIns(Int32 site_LogIn_Id)
        {
            System.Boolean value;
            value = Site_LogIns.DeleteSite_LogIns(site_LogIn_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of Site_LogIns based on site_LogIns.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteSite_LogIns(Site_LogIns site_LogIns)
        {
            System.Boolean value;
            value = Site_LogIns.Delete(site_LogIns);

            return value;
        }
        /// <summary>
        /// Updates an instance of Site_LogIns.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSite_LogIns(Site_LogIns site_LogIns)
        {
            System.Boolean val;

            val = site_LogIns.Update();
            return val;

        }
        /// <summary>
        /// Updates an instance of Site_LogIns if the underlying data has not changed. The original instance is Site_LogIns_Original. To bypass the concurrency check, pass in 'null' for the Site_LogIns_Original parameter.
        /// </summary>
        /// <param name="site_LogIns">The instance of site_LogIns to persist. </param>
        /// <param name="site_LogIns_Original">The original instance of site_LogIns. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSite_LogIns(Site_LogIns site_LogIns, Site_LogIns site_LogIns_Original)
        {
            System.Boolean val;

            if(site_LogIns_Original == null)
            {
               val = site_LogIns.Update();

            }
            else
            {
               val = Site_LogIns.Update(site_LogIns, site_LogIns_Original);

            }
            return val;

        }
        /// <summary>
        /// Returns all instances of System_User_Roles. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetAllSystem_User_Roles(PagingInfo pagingInfo)
        {
            List<System_User_Roles> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = System_User_Roles.GetAll();
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = System_User_Roles.GetAll(pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Returns an instance of List<Bar.Business.System_User_Roles>.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public  List<System_User_Roles> GetSystem_User_RolesBySystem_User_Role_Id(Int32 system_User_Role_Id)
        {
            List<System_User_Roles> value;
            value = System_User_Roles.GetSystem_User_RolesBySystem_User_Role_Id(system_User_Role_Id);

            return value;
        }
        /// <summary>
        /// Get the instance of System_User_Roles that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of System_User_Roles.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        public System_User_Roles GetSystem_User_Roles(Int32 system_User_Role_Id)
        {
            System_User_Roles businessValue;
            businessValue = System_User_Roles.GetSystem_User_Roles(system_User_Role_Id);
            return businessValue;

        }

        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: Role_Id. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesByRole_Id(Int32 role_Id, PagingInfo pagingInfo)
        {
            List<System_User_Roles> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = System_User_Roles.GetSystem_User_RolesByRole_Id(role_Id);
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = System_User_Roles.GetSystem_User_RolesByRole_Id(role_Id, pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Returns a collection of System_User_Roles filtered on the following criteria: System_User_Id. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of System_User_Roles. </results>
        public List<System_User_Roles> GetSystem_User_RolesBySystem_User_Id(Int32 system_User_Id, PagingInfo pagingInfo)
        {
            List<System_User_Roles> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = System_User_Roles.GetSystem_User_RolesBySystem_User_Id(system_User_Id);
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = System_User_Roles.GetSystem_User_RolesBySystem_User_Id(system_User_Id, pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Persists a new instance of System_User_Roles to the database.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        public  void InsertSystem_User_Roles(System_User_Roles system_User_Roles)
        {

            System_User_Roles.Insert(system_User_Roles);

        }
        /// <summary>
        /// Deletes an instance of System_User_Roles based on System_User_Role_Id.
        /// </summary>
        /// <param name="system_User_Role_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteSystem_User_Roles(Int32 system_User_Role_Id)
        {
            System.Boolean value;
            value = System_User_Roles.DeleteSystem_User_Roles(system_User_Role_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of System_User_Roles based on system_User_Roles.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteSystem_User_Roles(System_User_Roles system_User_Roles)
        {
            System.Boolean value;
            value = System_User_Roles.Delete(system_User_Roles);

            return value;
        }
        /// <summary>
        /// Updates an instance of System_User_Roles.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_User_Roles(System_User_Roles system_User_Roles)
        {
            System.Boolean val;

            val = system_User_Roles.Update();
            return val;

        }
        /// <summary>
        /// Updates an instance of System_User_Roles if the underlying data has not changed. The original instance is System_User_Roles_Original. To bypass the concurrency check, pass in 'null' for the System_User_Roles_Original parameter.
        /// </summary>
        /// <param name="system_User_Roles">The instance of system_User_Roles to persist. </param>
        /// <param name="system_User_Roles_Original">The original instance of system_User_Roles. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_User_Roles(System_User_Roles system_User_Roles, System_User_Roles system_User_Roles_Original)
        {
            System.Boolean val;

            if(system_User_Roles_Original == null)
            {
               val = system_User_Roles.Update();

            }
            else
            {
               val = System_User_Roles.Update(system_User_Roles, system_User_Roles_Original);

            }
            return val;

        }
        /// <summary>
        /// Returns all instances of System_Users. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetAllSystem_Users(PagingInfo pagingInfo)
        {
            List<System_Users> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = System_Users.GetAll();
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = System_Users.GetAll(pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Returns an instance of List<Bar.Business.System_Users>.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public  List<System_Users> GetSystem_UsersBySystem_User_Id(Int32 system_User_Id)
        {
            List<System_Users> value;
            value = System_Users.GetSystem_UsersBySystem_User_Id(system_User_Id);

            return value;
        }
        /// <summary>
        /// Get the instance of System_Users that corresponds to the primary key. If no data is found, a null instance is returned.
        /// Returns an instance of System_Users.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        public System_Users GetSystem_Users(Int32 system_User_Id)
        {
            System_Users businessValue;
            businessValue = System_Users.GetSystem_Users(system_User_Id);
            return businessValue;

        }

        /// <summary>
        /// Returns a collection of System_Users filtered on the following criteria: Company_Id. The pagingInfo parameters are used for paging.
        /// </summary>
        /// <param name="pagingInfo">a container for the paging parameters. </param>
        /// <results>Returns a strongly typed list of System_Users. </results>
        public List<System_Users> GetSystem_UsersByCompany_Id(Int32 company_Id, PagingInfo pagingInfo)
        {
            List<System_Users> val;
            long totalCount;
            if (pagingInfo == null || pagingInfo.GetAll)
            {
               val = System_Users.GetSystem_UsersByCompany_Id(company_Id);
               if(pagingInfo!=null) pagingInfo.TotalCount = val.Count;

            }
            else
            {
               pagingInfo.Normalize();
               val = System_Users.GetSystem_UsersByCompany_Id(company_Id, pagingInfo.PageSize,  pagingInfo.StartingRowNumber,  pagingInfo.PageNr,  out totalCount);
               pagingInfo.TotalCount = totalCount;

            }
            return val;
        }

        /// <summary>
        /// Persists a new instance of System_Users to the database.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        public  void InsertSystem_Users(System_Users system_Users)
        {

            System_Users.Insert(system_Users);

        }
        /// <summary>
        /// Deletes an instance of System_Users based on System_User_Id.
        /// </summary>
        /// <param name="system_User_Id">The database automatically generates this value. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteSystem_Users(Int32 system_User_Id)
        {
            System.Boolean value;
            value = System_Users.DeleteSystem_Users(system_User_Id);

            return value;
        }
        /// <summary>
        /// Deletes an instance of System_Users based on system_Users.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        /// <results>'true' if the instance was deleted, otherwise, 'false'. </results>
        public  Boolean DeleteSystem_Users(System_Users system_Users)
        {
            System.Boolean value;
            value = System_Users.Delete(system_Users);

            return value;
        }
        /// <summary>
        /// Updates an instance of System_Users.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_Users(System_Users system_Users)
        {
            System.Boolean val;

            val = system_Users.Update();
            return val;

        }
        /// <summary>
        /// Updates an instance of System_Users if the underlying data has not changed. The original instance is System_Users_Original. To bypass the concurrency check, pass in 'null' for the System_Users_Original parameter.
        /// </summary>
        /// <param name="system_Users">The instance of system_Users to persist. </param>
        /// <param name="system_Users_Original">The original instance of system_Users. </param>
        /// <results>'true' if the instance was updated, otherwise, 'false'. </results>
        public Boolean UpdateSystem_Users(System_Users system_Users, System_Users system_Users_Original)
        {
            System.Boolean val;

            if(system_Users_Original == null)
            {
               val = system_Users.Update();

            }
            else
            {
               val = System_Users.Update(system_Users, system_Users_Original);

            }
            return val;

        }
   }

}

