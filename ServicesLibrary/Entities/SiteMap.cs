using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class SiteMap
    {
        private int _IdSiteMap;

        public int IdSiteMap
        {
            get { return _IdSiteMap; }
            set { _IdSiteMap = value; }
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
        private string _RoleCode;

        public string RoleCode
        {
            get { return _RoleCode; }
            set { _RoleCode = value; }
        }
        private string _URL;

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
        private Status _EntStatus;

        public Status EntStatus
        {
            get { return _EntStatus; }
            set { _EntStatus = value; }
        }

        private bool _IsBrowsable;

        public bool IsBrowsable
        {
            get { return _IsBrowsable; }
            set { _IsBrowsable = value; }
        }

        private int? _IdParent;

        public int? IdParent
        {
            get { return _IdParent; }
            set { _IdParent = value; }
        }
    }
}
