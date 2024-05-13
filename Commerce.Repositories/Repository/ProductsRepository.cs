using Commerce.Context.Context;
using Commerce.Models.Models;
using Commerce.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Repositories.Repository
{
    public class ProductsRepository : GenericRepository<Products> , IProductsRepository
    {
        CommerceDbContext commerceDbContext;
        public ProductsRepository(CommerceDbContext _commerceDbContext) : base(_commerceDbContext)
        {
            commerceDbContext = _commerceDbContext;
        }
    }

}
