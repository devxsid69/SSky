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
    public class TicketService:ITicketService
    {
        #region Functions
        private void AssignDataObjectToEntity(tbl_Tickets dbCategory, ref Ticket entity)
        {


            entity.IdTicket = dbCategory.IdTicket;
            entity.Description = dbCategory.Description;
            entity.CreatedOn = dbCategory.CreatedOn;
            entity.AssignedTo = new Security.MembershipService().GetUserById(dbCategory.IdAssignedTo);
            entity.Category = new CategoryService().GetByID(dbCategory.IdCategory);
            entity.TicketStatus = dbCategory.TicketStatus == "Abierto" ? Ticket.TicketStatusEnum.Abierto : Ticket.TicketStatusEnum.Cerrado;
            entity.CreatedBy = new Security.MembershipService().GetUserById(dbCategory.CreatedBy);
            entity.CloseDescription = dbCategory.CloseDescription;
            try
            {
                entity.ClosedOn = dbCategory.ClosedOn;
                entity.ClosedOnByUser = dbCategory.ClosedOnByUser.Value;
            }
            catch
            { }

            entity.IdPrioriy = dbCategory.IdPriority;
        }
        private int Insert(Ticket entTicket)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            try
            {
                tbl_Tickets dbTickets = new tbl_Tickets() { 
                    CloseDescription = entTicket.CloseDescription,
                    CreatedOn = entTicket.CreatedOn,
                    CreatedBy = entTicket.CreatedBy.IdUser,
                    Description = entTicket.Description,
                    IdAssignedTo = entTicket.AssignedTo.IdUser,
                    IdCategory = entTicket.Category.IdCategory,
                    IdPriority = entTicket.IdPrioriy,
                    TicketStatus = entTicket.TicketStatus.ToString()                    
                };
                context.tbl_Tickets.InsertOnSubmit(dbTickets);
                context.SubmitChanges();

                return dbTickets.IdTicket;
            }
            catch
            { }
            return -1;
        }
        private int Update(Ticket entTicket)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            try {
                tbl_Tickets dbTickets = context.tbl_Tickets.Where(t => t.IdTicket == entTicket.IdTicket).FirstOrDefault();
                dbTickets.CloseDescription = entTicket.CloseDescription;
                dbTickets.ClosedOn = DateTime.Now;
                dbTickets.TicketStatus = entTicket.TicketStatus.ToString();
                dbTickets.ClosedOnByUser = entTicket.ClosedOnByUser;

                context.SubmitChanges();
                return dbTickets.IdTicket;
            }
            catch { }
            return -1;
        }
        #endregion

        #region Miembros de ITicketService


        public List<Ticket> GetAll()
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<tbl_Tickets> dbListTickets = context.tbl_Tickets.ToList();

            List<Ticket> entList = new List<Ticket>();

            foreach (var drItem in dbListTickets)
            {
                Ticket entItem = new Ticket();
                AssignDataObjectToEntity(drItem, ref entItem);
                entList.Add(entItem);
            }

            return entList;
        }

        public List<Ticket> GetAllByIdCompany(int ID)
        {
            List<Ticket> entityList = GetAll().Where(t => t.CreatedBy.EntCompany.IdCompany == ID).ToList();
            return entityList;
        }

        public List<Ticket> GetAllByIdCompanyStatus(int ID,Ticket.TicketStatusEnum Status)
        {
            List<Ticket> entityList = GetAll().Where(t => t.CreatedBy.EntCompany.IdCompany == ID && t.TicketStatus == Ticket.TicketStatusEnum.Abierto).ToList();
            return entityList;
        }

        public Ticket SelectByID(int ID)
        {
            Ticket entity = GetAll().Where(t => t.IdTicket == ID).FirstOrDefault();
            return entity;
        }

        public int Save(Ticket newTicket)
        {            
            int blResult = -1;
            try
            {
                if (newTicket.IdTicket == 0)
                {
                    blResult = Insert(newTicket);
                }
                else
                {
                    blResult = Update(newTicket);
                }
            }
            catch {
                return -1;
            }
            return blResult;
        }

        public int GetLastID()
        {
            //InitializeControllers();
            int ilResult = 0;
            //try
            //{
            //    ilResult = mscConnector.GetLastID(tqQuery.GetLastId(), tqQuery.IdField);
            //}
            //catch
            //{ }
            return ilResult;
        }

        #endregion
    }
}
