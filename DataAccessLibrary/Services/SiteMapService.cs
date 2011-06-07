using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Utils;
using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace DataAccessLibrary.Services
{
    public class SiteMapService :ISiteMapService
    {
        UtilsService Utilities;
        #region Functions
        private void AssignDataObjectToEntity(tbl_SiteMap dbRole, ref ServicesLibrary.Entities.SiteMap entSiteMap)
        {
            entSiteMap.IdSiteMap = dbRole.IdSiteMap;
            entSiteMap.Name = dbRole.Name;
            entSiteMap.Description = dbRole.Description;
            entSiteMap.RoleCode = dbRole.RoleCode;
            entSiteMap.URL = dbRole.URL;
            entSiteMap.EntStatus = new Status(){IdStatus= dbRole.tbl_Status.IdStatus,Name =dbRole.tbl_Status.Name};
            entSiteMap.IsBrowsable = dbRole.IsBrowsable;
            entSiteMap.IdParent = dbRole.IdParent;
            
            
            
            
        }

        #endregion


        #region Miembros de ISiteMapService

        public List<SiteMap> GetMenuByIdRole(int ID)
        {
            
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_SiteMap> dbListSiteMap = (from s in context.tbl_SiteMap
                                               join rs in context.tbl_Roles_SiteMap on s.IdSiteMap equals rs.IdSiteMap
                                               where rs.IdRole == ID
                                               && s.IsBrowsable == true
                                               select s).ToList();
            
            List<ServicesLibrary.Entities.SiteMap> entList = new List<ServicesLibrary.Entities.SiteMap>();

            foreach (var drItem in dbListSiteMap)
                {
                    ServicesLibrary.Entities.SiteMap entItem = new ServicesLibrary.Entities.SiteMap();
                    AssignDataObjectToEntity(drItem, ref entItem);
                    entList.Add(entItem);
                }
            
            return entList;
        }

        public List<ServicesLibrary.Entities.SiteMap> GetAll()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_SiteMap> dbListSiteMap = context.tbl_SiteMap.ToList();


            List<ServicesLibrary.Entities.SiteMap> entList = new List<ServicesLibrary.Entities.SiteMap>();

            foreach (var drItem in dbListSiteMap)
            {
                ServicesLibrary.Entities.SiteMap entItem = new ServicesLibrary.Entities.SiteMap();
                AssignDataObjectToEntity(drItem, ref entItem);
                entList.Add(entItem);
            }

            return entList;
        }

        #endregion
    }
}
