using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Utils;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace DataAccessLibrary.Services
{
    public class CategoryService :ICategoryService
    {
        //MySQLConnector mscConnector;
        //CategoryQueries cqQuery;
        //UtilsService Utilities;

        //private void InitializeControllers()
        //{
        //    mscConnector = new MySQLConnector();
        //    cqQuery = new CategoryQueries();
        //    Utilities = new UtilsService();
        //}
        private bool Insert(Category entCategory)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            try
            {
                tbl_Categories dbCategory = new tbl_Categories()
                {
                    Name = entCategory.Name,
                    Description = entCategory.Description,
                    AlternativeMail = entCategory.AlternativeMail,
                    IdUserAssigned = entCategory.AssignedTo.IdUser,
                    IdStatus = entCategory.EntStatus.IdStatus
                };
                context.tbl_Categories.InsertOnSubmit(dbCategory);
                context.SubmitChanges();
                return true;
            }
            catch
            {}
            
            return false;
        }
        private bool Update(Category entCategory)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            try
            {
                tbl_Categories dbCategory = context.tbl_Categories.Where(c => c.IdCategory == entCategory.IdCategory).FirstOrDefault();
                dbCategory.Name = entCategory.Name;
                dbCategory.Description = entCategory.Description;
                dbCategory.AlternativeMail = entCategory.AlternativeMail;
                dbCategory.IdUserAssigned = entCategory.AssignedTo.IdUser;
                dbCategory.IdStatus = entCategory.EntStatus.IdStatus;
                context.SubmitChanges();
                
                return true;
            }
            catch
            { }
            return false;
        }
        #region Miembros de ICategoryService
        private void AssignDataObjectToEntity(tbl_Categories dbCategory, ref Category entCategory)
        {
            entCategory.IdCategory = dbCategory.IdCategory;
            entCategory.Name = dbCategory.Name;
            entCategory.Description = dbCategory.Description;
            entCategory.AssignedTo = new UserInfo()
            {
                IdUser = dbCategory.tbl_Users.IdUser,
                UserCompleteName = dbCategory.tbl_Users.FirstName + ' ' + dbCategory.tbl_Users.LastName,
                CreatedOn = dbCategory.tbl_Users.CreatedOn,
                Email = dbCategory.tbl_Users.Email,
                FirstName = dbCategory.tbl_Users.FirstName,
                LastName = dbCategory.tbl_Users.LastName,
                HashCode = dbCategory.tbl_Users.HashCode,
                ModifiedOn = dbCategory.tbl_Users.ModifiedOn,
                Password = dbCategory.tbl_Users.Password,
                UserName = dbCategory.tbl_Users.UserName,
                Company = new Company()
                {
                    IdCompany = dbCategory.tbl_Users.tbl_Companies.IdCompany,
                    Name = dbCategory.tbl_Users.tbl_Companies.Name,
                    Description = dbCategory.tbl_Users.tbl_Companies.Description,
                    EntStatus = new Status() { IdStatus = dbCategory.tbl_Users.tbl_Companies.tbl_Status.IdStatus, Name = dbCategory.tbl_Users.tbl_Companies.tbl_Status.Name }
                },
                EntRole = new RoleInfo()
                {
                    IdRole = dbCategory.tbl_Users.tbl_Roles.IdRole,
                    Description = dbCategory.tbl_Users.tbl_Roles.Description,
                    Name = dbCategory.tbl_Users.tbl_Roles.Name,
                    RoleCode = dbCategory.tbl_Users.tbl_Roles.RoleCode,
                    EntStatus = new Status()
                    {
                        IdStatus = dbCategory.tbl_Users.tbl_Roles.tbl_Status.IdStatus,
                        Name = dbCategory.tbl_Users.tbl_Roles.tbl_Status.Name
                    }
                },
                EntStatus = new Status() { IdStatus = dbCategory.tbl_Users.tbl_Status.IdStatus, Name = dbCategory.tbl_Users.tbl_Status.Name }
            };
            entCategory.AlternativeMail = dbCategory.AlternativeMail;
            entCategory.EntStatus = new Status() { IdStatus = dbCategory.tbl_Status.IdStatus,Name=dbCategory.tbl_Status.Name};
            entCategory.DefaultMail = entCategory.AssignedTo.Email;
        }

        public List<Category> GetAll()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Categories> dbListCategories = context.tbl_Categories.ToList();
            List<Category> entList = new List<Category>();

            foreach (var drItem in dbListCategories)
            {
                Category entItem = new Category();
                AssignDataObjectToEntity(drItem, ref entItem);
                entList.Add(entItem);
            }

            return entList;
        }
        public List<Category> GetAllDDL()
        {
            Category entity = new Category() { IdCategory = -1, Name = "Selecciona..." };
            List<Category> entList = new List<Category>();
            entList = GetAll();
            entList = entList.Where(c => c.EntStatus.IdStatus == 1).ToList();
            entList.Insert(0, entity);
            return entList;
        }
        public Category GetByID(int ID)
        {
            Category entity = GetAll().Where(c => c.IdCategory == ID).FirstOrDefault();
            if (entity == null)
                return null;
            else
                return entity;
        }
        public bool Save(Category entity)
        {            
            bool blResult = false;
            try
            {                
                if (entity.IdCategory == 0)
                {
                    blResult = Insert(entity);
                }
                else
                {
                    blResult = Update(entity);
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
