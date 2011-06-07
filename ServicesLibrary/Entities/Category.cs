using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class Category
    {
        private int _IdCategory;

        public int IdCategory
        {
            get { return _IdCategory; }
            set { _IdCategory = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private UserInfo _AssignedTo;

        public UserInfo AssignedTo
        {
            get { return _AssignedTo; }
            set { _AssignedTo = value; }
        }

        private string _DefaultMail;

        public string DefaultMail
        {
            get { return _DefaultMail; }
            set { _DefaultMail = value; }
        }

        private string _AlternativeMail;

        public string AlternativeMail
        {
            get { return _AlternativeMail; }
            set { _AlternativeMail = value; }
        }

        private Status _EntStatus;

        public Status EntStatus
        {
            get { return _EntStatus; }
            set { _EntStatus = value; }
        }    
    }
}
