using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class UserInfo:User
    {        
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _HashCode;

        public string HashCode
        {
            get { return _HashCode; }
            set { _HashCode = value; }
        }
        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        private DateTime _CreatedOn;

        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }
        private DateTime _ModifiedOn;

        public DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { _ModifiedOn = value; }
        }
        private Status _EntStatus;

        public Status EntStatus
        {
            get { return _EntStatus; }
            set { _EntStatus = value; }
        }        
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private Company _EntCompany;

        public Company EntCompany
        {
            get { return _EntCompany; }
            set { _EntCompany = value; }
        }
        public UserInfo()
        {             
        }

        public UserInfo(int ilIdUser)
        {
            IdUser = ilIdUser;
        }

        

    }
}
