using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class Ticket
    {
        public enum TicketStatusEnum
        { 
            Abierto,
            Cerrado
        };

        private int _IdTicket;

        public int IdTicket
        {
            get { return _IdTicket; }
            set { _IdTicket = value; }
        }

        private Category _Category;

        public Category Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private UserInfo _AssignedTo;

        public UserInfo AssignedTo
        {
            get { return _AssignedTo; }
            set { _AssignedTo = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private DateTime _CreatedOn;

        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }

        private DateTime? _ClosedOn;

        public DateTime? ClosedOn
        {
            get { return _ClosedOn; }
            set { _ClosedOn = value; }
        }

        private DateTime _ClosedOnByUser;

        public DateTime ClosedOnByUser
        {
            get { return _ClosedOnByUser; }
            set { _ClosedOnByUser = value; }
        }

        private string _CloseDescription;

        public string CloseDescription
        {
            get { return _CloseDescription; }
            set { _CloseDescription = value; }
        }

        private int _IdPrioriy;

        public int IdPrioriy
        {
            get { return _IdPrioriy; }
            set { _IdPrioriy = value; }
        }

        private UserInfo _CreatedBy;

        public UserInfo CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        private TicketStatusEnum _TicketStatus;

        public TicketStatusEnum TicketStatus
        {
            get { return _TicketStatus; }
            set { _TicketStatus = value; }
        }
    }
}
