using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services.interfaces;
using App.Data;

namespace App.Services.implementation
{
    public class TicketServices : ITicketServices
    {
        private readonly AppDbContext _context;

        public TicketServices(AppDbContext context)
        {
            _context = context;
        }
        public void CreateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Where(x => x.TicketID == id).FirstOrDefault();

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
            else
                return;
        }

        public Ticket Details(int id)
        {
            Ticket ticket = new Ticket();

            ticket = _context.Tickets.Where(x => x.TicketID == id).FirstOrDefault();

            if(ticket == null) 
            {
                return null;
            }

            return ticket;
        }

        public List<Ticket> GetAllTickets()
        {
            List<Ticket> tickets = _context.Tickets.ToList<Ticket>();

            if(tickets == null)
            {
                return null;
            }

            return tickets;
        }

        public void UpdateExisting(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
