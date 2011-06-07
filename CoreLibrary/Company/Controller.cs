using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Interfaces;

namespace CoreLibrary.Company
{
    public class Controller:ICompanyService
    {

        #region Miembros de ICompanyService

        public List<ServicesLibrary.Entities.Company> GetAll()
        {
            return ServiceFactory.GetCompanyService().GetAll();
        }

        public List<ServicesLibrary.Entities.Company> GetAllDDL()
        {
            return ServiceFactory.GetCompanyService().GetAllDDL();
        }

        public ServicesLibrary.Entities.Company GetByID(int ID)
        {
            return ServiceFactory.GetCompanyService().GetByID(ID);
        }

        public bool Save(ServicesLibrary.Entities.Company newCompany)
        {
            return ServiceFactory.GetCompanyService().Save(newCompany);
        }

        public int GetLastID()
        {
            return ServiceFactory.GetCompanyService().GetLastID();
        }

        #endregion
    }
}
