using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> GetAll();

        List<Ticket> GetAllByIdCompany(int ID);

        List<Ticket> GetAllByIdCompanyStatus(int ID, Ticket.TicketStatusEnum Status);

        Ticket SelectByID(int ID);

        int Save(Ticket newTicket);

        int GetLastID();
    }
}
