using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.interfaces
{
    public interface ITicketServices
    {
        void CreateTicket(Ticket ticket);
        void UpdateExisting(Ticket ticket);
        void DeleteTicket(int id);
        Ticket Details(int id);
        List<Ticket> GetAllTickets();
    }
}