using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Dtos
{
    public class CreateOrdersDto
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }

    }
}
