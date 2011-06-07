using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class User
    {
        private int _IdUser;

        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _UserCompleteName;
        public string UserCompleteName
        {
            get { return _UserCompleteName; }
            set { _UserCompleteName = value; }
        }

        private RoleInfo _EntRole;

        public RoleInfo EntRole
        {
            get { return _EntRole; }
            set { _EntRole = value; }
        }

        private Company _Company;

        public Company Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        private int _IdApplication;

        public int IdApplication
        {
            get { return _IdApplication; }
            set { _IdApplication = value; }
        }

        private string _Application;

        public string Application
        {
            get { return _Application; }
            set { _Application = value; }
        }

        public User()
        {}

        public User(int IdUser, string UserName)
        {
            _IdUser = IdUser;
            _UserName = UserName;
        }
    }
}
