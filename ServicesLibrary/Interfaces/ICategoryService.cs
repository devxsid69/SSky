using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();        

        List<Category> GetAllDDL();

        Category GetByID(int ID);

        bool Save(Category entity);

        int GetLastID();

    }
}
