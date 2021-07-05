using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using App.Areas.Identity.Data;

namespace App.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int Total { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}