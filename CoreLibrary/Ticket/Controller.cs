using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace CoreLibrary.Ticket
{
    public class Controller:ITicketService
    {

        #region Miembros de ITicketService

        public List<ServicesLibrary.Entities.Ticket> GetAll()
        {
            return ServiceFactory.GetTicketService().GetAll();
        }

        public List<ServicesLibrary.Entities.Ticket> GetAllByIdCompany(int ID)
        {
            return ServiceFactory.GetTicketService().GetAllByIdCompany(ID);
        }

        public List<ServicesLibrary.Entities.Ticket> GetAllByIdCompanyStatus(int ID, ServicesLibrary.Entities.Ticket.TicketStatusEnum Status)
        {
            return ServiceFactory.GetTicketService().GetAllByIdCompanyStatus(ID,Status);
        }

        public ServicesLibrary.Entities.Ticket SelectByID(int ID)
        {
            return ServiceFactory.GetTicketService().SelectByID(ID);
        }

        public int Save(ServicesLibrary.Entities.Ticket newTicket)
        {
            return ServiceFactory.GetTicketService().Save(newTicket);
        }
        public int GetLastID()
        {
            return ServiceFactory.GetTicketService().GetLastID();
        }

        #endregion
    }
}
