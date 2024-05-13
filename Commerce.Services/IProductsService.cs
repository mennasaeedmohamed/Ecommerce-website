using Commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Services
{
    public interface IProductsService
    {
        public List<GetAllProductsDto> GetAll(int? categoryId);
        public GetAllProductsDto GetOne(int Id);
        public bool Create(CreateOrUpdateProductsDto e);
        public bool Update(int Id,CreateOrUpdateProductsDto e);
        public bool Delete(int Id);
    }
}
