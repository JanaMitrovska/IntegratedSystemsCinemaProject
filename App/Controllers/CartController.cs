using App.Services.Helpers;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using App.Data;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public CartController(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        // GET: CartController
        [Authorize(Roles = "admin,standard" )]
        public ActionResult Index()
        {
            List<Ticket> tickets = HttpContext.Session.GetObjectAsJson<List<Ticket>>("cart");

            if(tickets != null)
            {
                return View(tickets);
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        // GET: AddToCart
        [Authorize(Roles = "admin,standard")]
        public ActionResult AddToCart(int? id)
        {
            if(SessionHelper.GetObjectAsJson<List<Ticket>>(HttpContext.Session, "cart") == null)
            {
                List<Ticket> cart = new List<Ticket>();

                Ticket ticket = _context.Tickets.Where(ob => ob.TicketID == id).FirstOrDefault();

                cart.Add(ticket);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Ticket> cart = SessionHelper.GetObjectAsJson<List<Ticket>>(HttpContext.Session, "cart");

                Ticket ticket = _context.Tickets.Where(ob => ob.TicketID == id).FirstOrDefault();

                if (!isExist(ticket.TicketID))
                {
                    cart.Add(ticket);
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin,standard")]
        public ActionResult Remove(int id)
        {
            List<Ticket> cart = SessionHelper.GetObjectAsJson<List<Ticket>>(HttpContext.Session, "cart");

            Ticket ticket = _context.Tickets.Where(x => x.TicketID == id).FirstOrDefault();

            cart.RemoveAll(x => x.TicketID == id);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin,standard")]
        public ActionResult Checkout()
        {
            return View("Checkout");
        }

        //[HttpPost]
        [Authorize(Roles = "admin,standard")]
        public async Task<ActionResult> PlaceOrder()
        {
            Order order = new Order();

            List<Ticket> cart = SessionHelper.GetObjectAsJson<List<Ticket>>(HttpContext.Session, "cart");

            if(cart != null)
            {
                order.Total = cart.Sum(item => item.Price);

                ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

                order.User = applicationUser;
                order.Tickets = cart;

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

            }
            else
            {
                return RedirectToAction("Index");
            }

            //TODO: Email confirmation

            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
        private bool isExist(int id)
        {
            List<Ticket> cart = SessionHelper.GetObjectAsJson<List<Ticket>>(HttpContext.Session, "cart");

            foreach(var ticket in cart)
            {
                if (ticket.TicketID == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
