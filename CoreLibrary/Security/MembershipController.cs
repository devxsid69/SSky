using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Interfaces;
using ServicesLibrary.Entities;

namespace CoreLibrary.Security
{
    public class MembershipController : IMembershipService
    {

        #region Miembros de IMembershipService

        public bool ValidateUser(string userName, string password)
        {
            return ServiceFactory.GetMembershipService().ValidateUser(userName, password);
        }

        public bool ValidatePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public List<ServicesLibrary.Entities.UserInfo> GetUsers(string userName, int startRowIndex, int maximumRows)
        {
            return ServiceFactory.GetMembershipService().GetUsers(userName, startRowIndex, maximumRows);
        }

        public int GetUsers(string userName)
        {
            throw new NotImplementedException();
        }

        public ServicesLibrary.Entities.UserInfo GetUserById(int idUser)
        {
            return ServiceFactory.GetMembershipService().GetUserById(idUser);
        }

        public bool Save(ServicesLibrary.Entities.UserInfo newUser)
        {
            return ServiceFactory.GetMembershipService().Save(newUser);
        }

        public void ChangeStatus(ServicesLibrary.Entities.UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
        public List<UserInfo> GetUsersDDL()
        {
            return ServiceFactory.GetMembershipService().GetUsersDDL();
        }

        #endregion
    }
}
