using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class Company
    {
        private int _IdCompany;

        public int IdCompany
        {
            get { return _IdCompany; }
            set { _IdCompany = value; }
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
        private Status _EntStatus;

        public Status EntStatus
        {
            get { return _EntStatus; }
            set { _EntStatus = value; }
        }
    }
}
