using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App.DTOs
{
    public class CheckoutModel
    {
        [Required]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        [Required]
        [RegularExpression("([0-9][0-9][0-9])", ErrorMessage = "Please enter a valid 3 digit number")]
        public string SecurityCode { get; set; }
    }
}
