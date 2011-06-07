using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface IMembershipService
    {
        bool ValidateUser(string userName, string password);

        //bool ValidatePassword(string userName, string password);

        List<UserInfo> GetUsers(string userName, int startRowIndex, int maximumRows);

        int GetUsers(string userName);

        List<UserInfo> GetUsersDDL();

        UserInfo GetUserById(int idUser);

        bool Save(UserInfo newUser);

        void ChangeStatus(UserInfo userInfo);

        //bool UpdateByUser(UserInfo ulUser);
    }
}
