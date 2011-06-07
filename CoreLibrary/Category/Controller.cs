using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Interfaces;

namespace CoreLibrary.Category
{
    public class Controller : ICategoryService
    {
        #region Miembros de ICategoryService

        public List<ServicesLibrary.Entities.Category> GetAll()
        {
            return ServiceFactory.GetCategoryService().GetAll();
        }

        public ServicesLibrary.Entities.Category GetByID(int ID)
        {
            return ServiceFactory.GetCategoryService().GetByID(ID);
        }

        public int GetLastID()
        {
            return ServiceFactory.GetCategoryService().GetLastID();
        }
        public bool Save(ServicesLibrary.Entities.Category entity)
        {
            return ServiceFactory.GetCategoryService().Save(entity);
        }
        public List<ServicesLibrary.Entities.Category> GetAllDDL()
        {
            return ServiceFactory.GetCategoryService().GetAllDDL();
        }
        #endregion
    }
}
