using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface IRoleService
    {
        bool Save(RoleInfo newRoleInfo);
        bool Save(RoleInfo newRoleInfo, Dictionary<int, int> RoleSiteMap);

        List<string> GetRolesCodes();

        RoleInfo GetRoleByRoleCode(string RoleCode);

        List<string> GetRolesByUserName(string UserName);

        List<RoleInfo> GetAllRoles();

        List<RoleInfo> GetAllRolesDDL();

        RoleInfo GetRoleByUserID(int IdUser);

        RoleInfo GetRoleByID(int IdRole);

        string GetRoleCodeByURL(string slURL);

        Dictionary<int,int> GetRolesSiteMapByIdRole(int ID);
        
    }
}
