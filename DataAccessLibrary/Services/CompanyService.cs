using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using System.Collections.Generic;

using System.Linq;
using System.Text;

using System.Configuration;

using DataAccessLibrary.Repository;
using DataAccessLibrary.Utils;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace DataAccessLibrary.Services
{
    public class CompanyService:ICompanyService
    {
        #region Functions
        private bool Insert(Company entCompany)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            tbl_Companies dbCompany = new tbl_Companies() { 
                Description = entCompany.Description,
                Name = entCompany.Name,
                IdStatus = entCompany.EntStatus.IdStatus
            };
            try
            {
                context.tbl_Companies.InsertOnSubmit(dbCompany);
                context.SubmitChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        private bool Update(Company entCompany)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            tbl_Companies dbCompany = context.tbl_Companies.Where(c => c.IdCompany == entCompany.IdCompany).FirstOrDefault();

            if (dbCompany != null)
            {
                try
                {
                    dbCompany.Name = entCompany.Name;
                    dbCompany.Description = entCompany.Description;
                    dbCompany.IdStatus = entCompany.EntStatus.IdStatus;
                    context.SubmitChanges();
                    return true;
                }
                catch {
                    return false;
                }
            }
            return false;
        }

        private void AssignDataObjectToEntity(tbl_Companies dbCompany, ref Company entCompany)
        {
            entCompany.IdCompany = dbCompany.IdCompany;
            entCompany.Name = dbCompany.Name;
            entCompany.Description = dbCompany.Description;
            entCompany.EntStatus = new Status() {
                IdStatus= dbCompany.tbl_Status.IdStatus, 
                Name= dbCompany.tbl_Status.Name};
        }
        #endregion

        #region Miembros de ICompanyService

        public List<Company> GetAll()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Companies> dbListCompanies = context.tbl_Companies.ToList();

            List<Company> entList = new List<Company>();

            foreach (var drItem in dbListCompanies)
            {
                Company entItem = new Company();
                AssignDataObjectToEntity(drItem, ref entItem);
                entList.Add(entItem);
            }

            return entList;

        }

        public List<Company> GetAllDDL()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            Company entity = new Company() { IdCompany = -1, Name = "Selecciona..." };
            List<Company> entList = new List<Company>();
            List<tbl_Companies> dbListCompanies = context.tbl_Companies.Where(c => c.IdStatus == 1).ToList();
            foreach (var drItem in dbListCompanies)
            {
                Company entItem = new Company();
                AssignDataObjectToEntity(drItem, ref entItem);
                entList.Add(entItem);
            }
            entList.Insert(0, entity);
            return entList;

        }

        public Company GetByID(int ID)
        {
            Company company = GetAll().Where(c => c.IdCompany == ID).FirstOrDefault();
            if (company == null)
                return null;
            else
                return company;
        }

        public bool Save(Company newCompany)
        {
            
            bool blResult = false;
            try
            {
                
                if (newCompany.IdCompany == 0)
                {
                    blResult = Insert(newCompany);
                }
                else
                {
                    blResult = Update(newCompany);
                }
            }
            catch { return false; }
            return blResult;
        }

        public int GetLastID()
        {
            
            int ilResult = 0;
            //try
            //{
            //    ilResult = mscConnector.GetLastID(cqQuery.GetLastId(), cqQuery.IdField);
            //}
            //catch
            //{ }
            return ilResult;
        }

        #endregion
    }
}
