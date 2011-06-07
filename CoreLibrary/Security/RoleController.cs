using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServicesLibrary.Interfaces;

namespace CoreLibrary.Security
{
    public class RoleController:IRoleService
    {

        #region Miembros de IRoleService
        public bool Save(ServicesLibrary.Entities.RoleInfo newRoleInfo)
        {
            return ServiceFactory.GetRoleService().Save(newRoleInfo);
        }

        public List<string> GetRolesCodes()
        {
            return ServiceFactory.GetRoleService().GetRolesCodes();
        }

        public ServicesLibrary.Entities.RoleInfo GetRoleByRoleCode(string RoleCode)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRolesByUserName(string UserName)
        {
            return ServiceFactory.GetRoleService().GetRolesByUserName(UserName);
        }

        public List<ServicesLibrary.Entities.RoleInfo> GetAllRoles()
        {
            return ServiceFactory.GetRoleService().GetAllRoles();
        }

        public List<ServicesLibrary.Entities.RoleInfo> GetAllRolesDDL()
        {
            return ServiceFactory.GetRoleService().GetAllRolesDDL();
        }

        public ServicesLibrary.Entities.RoleInfo GetRoleByUserID(int IdUser)
        {
            return ServiceFactory.GetRoleService().GetRoleByUserID(IdUser);
        }

        public ServicesLibrary.Entities.RoleInfo GetRoleByID(int IdRole)
        {
            return ServiceFactory.GetRoleService().GetRoleByID(IdRole);
        }

        public string GetRoleCodeByURL(string slURL)
        {
            return ServiceFactory.GetRoleService().GetRoleCodeByURL(slURL);
        }

        public Dictionary<int, int> GetRolesSiteMapByIdRole(int ID)
        {
            return ServiceFactory.GetRoleService().GetRolesSiteMapByIdRole(ID);
        }

        public bool Save(ServicesLibrary.Entities.RoleInfo newRoleInfo, Dictionary<int, int> RoleSiteMap)
        {
            return ServiceFactory.GetRoleService().Save(newRoleInfo, RoleSiteMap);
        }
        #endregion
    }
}
