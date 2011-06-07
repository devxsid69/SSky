using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetAll();

        List<Company> GetAllDDL();

        Company GetByID(int ID);

        bool Save(Company newCompany);

        int GetLastID();
    }
}
