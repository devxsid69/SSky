using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace CoreLibrary.Status
{
    public class Controller :IStatusService
    {
        #region Miembros de IStatusService

        public List<ServicesLibrary.Entities.Status> GetAll()
        {
            return ServiceFactory.GetStatusService().GetAll();
        }

        public List<ServicesLibrary.Entities.Status> GetAllDDL()
        {
            return ServiceFactory.GetStatusService().GetAllDDL();
        }

        public ServicesLibrary.Entities.Status GetById(int ID)
        {
            return ServiceFactory.GetStatusService().GetById(ID);
        }
        #endregion
    }
}
