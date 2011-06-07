using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

using System.Configuration;
using System.Data;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Utils;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace DataAccessLibrary.Security
{
    public class MembershipService : MembershipProvider, IMembershipService
    {        
        #region Functions
        private void AssignDataObjectToEntity(tbl_Users dbUser, ref User entUser)
        {
            entUser.IdUser = dbUser.IdUser;
            entUser.UserName = dbUser.UserName;
            entUser.EntRole = new RoleService().GetRoleByUserID(entUser.IdUser);
            entUser.UserCompleteName = String.Format("{0} {1}", dbUser.FirstName, dbUser.LastName);
            entUser.Company = new DataAccessLibrary.Services.CompanyService().GetByID(dbUser.IdCompany);
            entUser.IdApplication = dbUser.IdApplication;
            entUser.Application = dbUser.tbl_Applications.Name;
        }

        private void AssignDataObjectToEntity(tbl_Users dbUser, ref UserInfo entUserInfo)
        {
            entUserInfo.UserCompleteName = String.Format("{0} {1}", dbUser.FirstName, dbUser.LastName);
            entUserInfo.IdUser = dbUser.IdUser;
            entUserInfo.UserName = dbUser.UserName;
            entUserInfo.FirstName = dbUser.FirstName;
            entUserInfo.LastName = dbUser.LastName;            
            entUserInfo.Password = dbUser.Password;
            entUserInfo.HashCode = dbUser.HashCode;
            entUserInfo.CreatedOn = dbUser.CreatedOn;
            entUserInfo.ModifiedOn = dbUser.ModifiedOn;
            entUserInfo.EntCompany = new DataAccessLibrary.Services.CompanyService().GetByID(dbUser.IdCompany);
            entUserInfo.EntStatus = new DataAccessLibrary.Services.StatusService().GetById(dbUser.IdStatus);
            entUserInfo.EntRole = new RoleService().GetRoleByID(dbUser.IdRole);
            entUserInfo.Email = dbUser.Email;                
        }
        private bool Insert(UserInfo entUser)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            try
            {
                tbl_Users dbUser = new tbl_Users()
                {
                    FirstName = entUser.FirstName,
                    LastName = entUser.LastName,
                    UserName = entUser.UserName,
                    HashCode = entUser.HashCode,
                    Password = entUser.Password,
                    CreatedOn = DateTime.Now,
                    Email = entUser.Email,
                    IdCompany = entUser.EntCompany.IdCompany,
                    IdStatus = entUser.EntStatus.IdStatus,
                    IdRole = entUser.EntRole.IdRole,
                    ModifiedOn = DateTime.Now
                };
                context.tbl_Users.InsertOnSubmit(dbUser);
                context.SubmitChanges();
                return true;
            }
            catch
            { }
            return false;

        }
        private bool Update(UserInfo entUser)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            try
            {
                tbl_Users dbUser = context.tbl_Users.Where(u => u.IdUser == entUser.IdUser).FirstOrDefault();
                dbUser.FirstName = entUser.FirstName;
                dbUser.LastName = entUser.LastName;
                dbUser.UserName = entUser.UserName;
                dbUser.Password = entUser.Password;
                dbUser.ModifiedOn = DateTime.Now;
                dbUser.HashCode = entUser.HashCode;
                dbUser.Email = entUser.Email;
                dbUser.IdCompany = entUser.EntCompany.IdCompany;
                dbUser.IdRole = entUser.EntRole.IdRole;
                dbUser.IdStatus = entUser.EntStatus.IdStatus;

                context.SubmitChanges();
                return true;
            }
            catch
            { }
            return false;
        }
        #endregion

        public override bool ValidateUser(string UserName, string Password)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            tbl_Users dbUser = context.tbl_Users.Where(u => u.UserName == UserName && u.Password == Password).FirstOrDefault();            
            User entUser = new User();
            if (dbUser!=null)
            {
                AssignDataObjectToEntity(dbUser, ref entUser);
            }
            else
            {
                //if ((UserName == "Administrador") && (Password == "SuperAdmin"))
                //{ 

                //}
                return false;
            }

            HttpContext.Current.Session["CurrentUser"] = entUser;
            return true;
        }

        public UserInfo GetUserById(int idUser)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            tbl_Users dbUser = context.tbl_Users.Where(u => u.IdUser== idUser).FirstOrDefault();            
            
            UserInfo entUser = new UserInfo();
            if (dbUser!=null)
            {
                AssignDataObjectToEntity(dbUser, ref entUser);
            }
            else
            {
                return null;
            }
            return entUser;
        }
     

        private void CreateAdminUser()
        { 
        }

        public List<UserInfo> GetUsers(string userName, int startRowIndex, int maximumRows)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Users> dbListUsers = context.tbl_Users.ToList();

            List<UserInfo> entUserInfoList = new List<UserInfo>();

            foreach (var drUserInfo in dbListUsers)
            {
                UserInfo entUserInfo = new UserInfo();
                AssignDataObjectToEntity(drUserInfo, ref entUserInfo);
                entUserInfoList.Add(entUserInfo);
            }

            return entUserInfoList;
        }
        public List<UserInfo> GetUsersDDL()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            //DataSet dsUser = mscConnector.GetDataFromQuery(uqQuery.SelectAll());
            List<tbl_Users> dbListUsers = context.tbl_Users.Where(u => u.IdStatus == 1).ToList();

            List<UserInfo> entUserInfoList = new List<UserInfo>();

            foreach (var drUserInfo in dbListUsers)
            {
                UserInfo entUserInfo = new UserInfo();
                AssignDataObjectToEntity(drUserInfo, ref entUserInfo);
                entUserInfoList.Add(entUserInfo);
            }

            UserInfo entItem = new UserInfo() { IdUser = -1, FirstName = "Selecciona..." };
            entUserInfoList.Insert(0, entItem);
            return entUserInfoList;
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #region Miembros de IMembershipService


        public int GetUsers(string userName)
        {
            throw new NotImplementedException();
        }        

        public bool Save(UserInfo newUser)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            bool blResult =false;
            try
            {
                
                if (newUser.IdUser == 0)
                    blResult = Insert(newUser);
                else
                    blResult = Update(newUser);
            }
            catch
            {
                return false;
            }
            return blResult;
        }

        public void ChangeStatus(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
