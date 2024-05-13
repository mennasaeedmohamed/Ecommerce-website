using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Models.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }
        public Orders? Orders { get; set; }
        public Products? Products { get; set; }
        public int ProductQuantity { get; set; }        
    }
}
