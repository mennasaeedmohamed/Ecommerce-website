using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Dtos
{
    public class GetAllOrdersDto
    {
        public int OrderId { get; set; }
       
        public string OrderStatus { get; set; }
    }
}
