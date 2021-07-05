using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services.interfaces;
using App.Data;

namespace App.Services.implementation
{
    public class OrderServices : IOrderServices
    {
        private readonly AppDbContext _context;

        public OrderServices(AppDbContext context)
        {
            _context = context;
        }
        public void CreateOrder()
        {
            //Ticket t = new Ticket();
            //t.Date = DateTime.Now;
            //t.Name = "Movie";

            //Order order = new Order();

            //order.Tickets.Add(t);
           
            //_context.Orders.Add(order);
        }
    }
}
