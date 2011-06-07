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
    public  class StatusService:IStatusService
    {
        
        #region Functions
        private void AssignDataObjectToEntity(tbl_Status dbRole, ref Status entity)
        {
            entity.IdStatus = dbRole.IdStatus;
            entity.Name = dbRole.Name;
        }
        
        #endregion

        #region Miembros de IStatusService

        public List<Status> GetAll()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Status> dbListStatus = context.tbl_Status.ToList();

            List<Status> entityList = new List<Status>();


            foreach (var drRow in dbListStatus)
            {
                Status entity = new Status();
                AssignDataObjectToEntity(drRow, ref entity);
                entityList.Add(entity);
            }
            return entityList;

        }

        public List<Status> GetAllDDL()
        {
            Status entity = new Status() { IdStatus=-1,Name="Selecciona..."};
            List<Status> entityList = GetAll();
            entityList.Insert(0, entity);
            return entityList;
        }

        public Status GetById(int ID)
        {
            Status entityList = GetAll().Where(s => s.IdStatus== ID).FirstOrDefault();

            return entityList;
        }

        #endregion
    }
}
