using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Models.Models
{
    public class Customers 
    {
        [Key]
        public int CustomerId { get; set; }     
        public string CustomerName { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
