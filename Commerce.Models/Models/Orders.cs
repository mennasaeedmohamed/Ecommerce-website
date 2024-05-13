using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Models.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public Customers? Customers { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderProducts> OrderProducts { get; set; }
    }
}
