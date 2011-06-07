using System;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Web.Security;

using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Utils;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace DataAccessLibrary.Security
{
    public class RoleService :IRoleService
    {
        
        #region Functions
        private void AssignDataObjectToEntity(tbl_Roles dbRole, ref RoleInfo entRoleInfo)
        {
            entRoleInfo.IdRole = dbRole.IdRole;
            entRoleInfo.Name = dbRole.Name;
            entRoleInfo.Description = dbRole.Description;
            entRoleInfo.RoleCode = dbRole.RoleCode;
            entRoleInfo.EntStatus = new Status { IdStatus = dbRole.tbl_Status.IdStatus, Name = dbRole.tbl_Status.Name };
        }
        private void AssignDataObjectToEntity(tbl_SiteMap dbSiteMap, ref ServicesLibrary.Entities.SiteMap entSiteMap)
        {
            entSiteMap.IdSiteMap = dbSiteMap.IdSiteMap;
            entSiteMap.Name = dbSiteMap.Name;
            entSiteMap.Description = dbSiteMap.Description;
            entSiteMap.RoleCode = dbSiteMap.URL;
            entSiteMap.URL = dbSiteMap.URL;
            entSiteMap.EntStatus = new Status { IdStatus = dbSiteMap.tbl_Status.IdStatus, Name = dbSiteMap.tbl_Status.Name };
            entSiteMap.IsBrowsable = dbSiteMap.IsBrowsable;
        }
        private bool InsertRole(RoleInfo entRole)
        {
            DbTransaction trans = null;
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            bool result = false;

            try
            {               
                context.Connection.Open();
                trans = context.Connection.BeginTransaction();
                context.Transaction = trans;

                tbl_Roles dbRole = new tbl_Roles()
                {                    
                    Description = entRole.Description,
                    IdStatus = entRole.EntStatus.IdStatus,
                    Name = entRole.Name,
                    RoleCode = entRole.RoleCode
                };
                context.tbl_Roles.InsertOnSubmit(dbRole);
                context.SubmitChanges();

                List<ServicesLibrary.Entities.SiteMap> listSiteMap = entRole.EntListSiteMap;
                List<tbl_Roles_SiteMap> dbRolesSiteMap = (from s in listSiteMap
                                                          select new tbl_Roles_SiteMap()
                                                          {
                                                              IdRole = dbRole.IdRole,
                                                              IdSiteMap = s.IdSiteMap
                                                          }).ToList();
                context.tbl_Roles_SiteMap.InsertAllOnSubmit(dbRolesSiteMap);
                context.SubmitChanges();

                trans.Commit();

                result = true;
            }
            catch (SqlException excs)
            {
                if (trans != null)
                    trans.Rollback();

            }
            catch (Exception exc)
            {
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                if (context.Connection.State == ConnectionState.Open)
                    context.Connection.Close();
            }
            return result;
        }
        private bool UpdateRole(RoleInfo entRole)
        { 
            DbTransaction trans = null;
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            bool result = false;

            try
            {
                context.Connection.Open();
                trans = context.Connection.BeginTransaction();
                context.Transaction = trans;

                tbl_Roles dbRole = context.tbl_Roles.Where(s => s.IdRole == entRole.IdRole).FirstOrDefault();
                dbRole.IdStatus = entRole.EntStatus.IdStatus;
                dbRole.Name = entRole.Name;
                dbRole.Description = entRole.Description;
                dbRole.RoleCode = entRole.RoleCode;
                context.SubmitChanges();

                List<tbl_Roles_SiteMap> listRolesSiteMap = context.tbl_Roles_SiteMap.Where(rs => rs.IdRole == entRole.IdRole).ToList();
                context.tbl_Roles_SiteMap.DeleteAllOnSubmit(listRolesSiteMap);
                context.SubmitChanges();

                List<ServicesLibrary.Entities.SiteMap> listSiteMap = entRole.EntListSiteMap;
                List<tbl_Roles_SiteMap> dbRolesSiteMap = (from s in listSiteMap
                                                          select new tbl_Roles_SiteMap()
                                                          {
                                                              IdRole = dbRole.IdRole,
                                                              IdSiteMap = s.IdSiteMap
                                                          }).ToList();
                context.tbl_Roles_SiteMap.InsertAllOnSubmit(dbRolesSiteMap);
                context.SubmitChanges();

                trans.Commit();
                result = true;

            }
            catch (SqlException excs)
            {
                if (trans != null)
                    trans.Rollback();

            }
            catch (Exception exc)
            {
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                if (context.Connection.State == ConnectionState.Open)
                    context.Connection.Close();
            }
            return result;
        }
        #endregion

        
        #region Miembros de IRoleService
        public int GetLastID(int ID)
        {
            
            int ilResult = 0;
            //try{
            //    ilResult = mscConnector.GetLastID(rqQuery.GetLastId(),rqQuery.IdField);
            //}
            //catch
            //{}
            return ilResult;
        }

        public bool Save(RoleInfo newRoleInfo)
        {
            bool blResult = false;
            try
            {

                if (newRoleInfo.IdRole == 0)
                {
                    blResult = InsertRole(newRoleInfo);
                    //int IdRole = mscConnector.GetLastID(rqQuery.GetLastId(), rqQuery.IdField);
                    //newRoleInfo.IdRole = IdRole;
                }
                else
                {
                    blResult = UpdateRole(newRoleInfo);
                }                
            }
            catch { return false; }
            return blResult;
        }

        public bool Save(RoleInfo newRoleInfo, Dictionary<int, int> RoleSiteMap)
        {
            
            bool blResult = false;
            try {
                
                if (newRoleInfo.IdRole == 0)
                {
                    blResult = InsertRole(newRoleInfo);                    
                }
                else
                {
                    blResult = UpdateRole(newRoleInfo);
                }
                //if (blResult)
                //{
                //    blResult = mscConnector.ExecuteNoNQuery(rqQuery.DeleteRoleSiteMapById(newRoleInfo.IdRole));
                //    foreach (KeyValuePair<int, int> KeyRoleSiteMap in RoleSiteMap)
                //    {
                //        blResult = mscConnector.ExecuteNoNQuery(rqQuery.Insert(KeyRoleSiteMap,newRoleInfo.IdRole));
                //    }
                //}
            }
            catch { return false; }
            return blResult;
        }

        public List<string> GetRolesCodes()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Roles> dbListRoles = context.tbl_Roles.ToList();

            //DataSet dsRole = mscConnector.GetDataFromQuery(rqQuery.SelectAll());
            List<string> entList = new List<string>();

            entList = dbListRoles.Select(s => s.RoleCode).ToList();
            //foreach (var drItem in dbListRoles)
            //{
            //    RoleInfo entItem = new RoleInfo();
            //    AssignDataObjectToEntity(drItem, ref entItem);
            //    entList.Add(entItem.RoleCode);
            //}
            return entList;
        }

        public Dictionary<int, int> GetRolesSiteMapByIdRole(int ID)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Roles_SiteMap> dbListRolesSiteMap = (from rs in context.tbl_Roles_SiteMap
                                               where rs.IdRole == ID                                              
                                               select rs).ToList();

            Dictionary<int, int> Role_Permissions = new Dictionary<int, int>();

            foreach (var drItem in dbListRolesSiteMap)
            {
                Role_Permissions.Add(drItem.IdSiteMap, drItem.IdRole);
            }


            return Role_Permissions;
        }

        public RoleInfo GetRoleByRoleCode(string RoleCode)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRolesByUserName(string UserName)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_SiteMap> tblListSiteMap = (from sm in context.tbl_SiteMap
                                                join rs in context.tbl_Roles_SiteMap on sm.IdSiteMap equals rs.IdSiteMap
                                                join r in context.tbl_Roles on rs.IdRole equals r.IdRole
                                                join u in context.tbl_Users on r.IdRole equals u.IdRole
                                                where u.UserName == UserName
                                                select sm).ToList();
            //DataSet dsRole = mscConnector.GetDataFromQuery(rqQuery.SelectRoleCodesByUserName(UserName));
            List<ServicesLibrary.Entities.SiteMap> entList = new List<ServicesLibrary.Entities.SiteMap>();

            foreach (var drItem in tblListSiteMap)
            {
                ServicesLibrary.Entities.SiteMap entItem = new ServicesLibrary.Entities.SiteMap();
                AssignDataObjectToEntity(drItem, ref entItem);
                entList.Add(entItem);
            }

            return entList.Select(c => c.RoleCode).ToList();
        }

        public List<RoleInfo> GetAllRoles()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Roles> dbListRoles = context.tbl_Roles.ToList();
            List<RoleInfo> entList = new List<RoleInfo>();
            foreach (var drItem in dbListRoles)
            {
                RoleInfo entItem = new RoleInfo();
                AssignDataObjectToEntity(drItem, ref entItem);
                entList.Add(entItem);
            }

            return entList;
        }

        public List<RoleInfo> GetAllRolesDDL()
        {            
            RoleInfo entItem = new RoleInfo() { IdRole = -1, Name = "Selecciona..." };
            
            List<RoleInfo> entList = GetAllRoles();

            entList.Insert(0, entItem);
            return entList;
        }

        public RoleInfo GetRoleByUserID(int IdUser)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            tbl_Roles dbRole = (from r in context.tbl_Roles
                                join u in context.tbl_Users on r.IdRole equals u.IdRole
                                where u.IdUser == IdUser
                                select r).FirstOrDefault();
            
            RoleInfo entItem = new RoleInfo();
            if (dbRole!=null)
            {                
                AssignDataObjectToEntity(dbRole, ref entItem);
            }
            return entItem;
        }

        public RoleInfo GetRoleByID(int IdRole)
        {
            RoleInfo entity = GetAllRoles().Where(r => r.IdRole == IdRole).FirstOrDefault();
            return entity;
        }

        public string GetRoleCodeByURL(string slURL)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();

            if (!slURL.Contains("~"))
            {
                //slURL = slURL.Replace("/","\\");
                slURL = String.Format("~{0}", slURL);
            }
            tbl_SiteMap dbSiteMap = context.tbl_SiteMap.Where(sm => sm.URL == slURL).FirstOrDefault();

            
            ServicesLibrary.Entities.SiteMap entItem= new ServicesLibrary.Entities.SiteMap();
            string code;
            if (dbSiteMap!= null)
            {                
                AssignDataObjectToEntity(dbSiteMap, ref entItem);
                code = entItem.RoleCode;
            }            
            else
            {
                code = "Not Permission or URL not exists";
            }

            return code;
        }

        #endregion
    }
}
