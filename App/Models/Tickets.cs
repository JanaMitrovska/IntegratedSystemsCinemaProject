using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public int Price { get; set; }

        //public virtual Order Order { get; set; }
    }
}