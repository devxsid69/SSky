using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface IStatusService
    {
        List<Status> GetAll();

        List<Status> GetAllDDL();

        Status GetById(int ID);

    }
}
