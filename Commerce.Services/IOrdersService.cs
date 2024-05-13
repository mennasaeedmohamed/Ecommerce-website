using Commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Services
{
    public interface IOrdersService
    {
        public List<GetAllOrdersDto> GetAll(int? customerId);
        public GetAllOrdersDto GetOne(int Id);
        public bool Create(CreateOrdersDto e);
        public bool Update(int Id, UpdateOrdersDto e);
        public bool Delete(int Id);
    }
}
