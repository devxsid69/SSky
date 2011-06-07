using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class RoleInfo
    {
        private int _IdRole;

        public int IdRole
        {
            get { return _IdRole; }
            set { _IdRole = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _RoleCode;

        public string RoleCode
        {
            get { return _RoleCode; }
            set { _RoleCode = value; }
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

        private List<SiteMap> _entListSiteMap;

        public List<SiteMap> EntListSiteMap
        {
            get { return _entListSiteMap; }
            set { _entListSiteMap = value; }
        }
    }
}
