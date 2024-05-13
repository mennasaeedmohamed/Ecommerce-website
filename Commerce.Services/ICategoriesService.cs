using Commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Services
{
    public interface ICategoriesService
    {
        public List<GetAllCategoriesDto> GetAll();
        public GetAllCategoriesDto GetOne(int Id);
        public bool Create(CreateOrUpdateCategoriesDto e);
        public bool Update(int Id, CreateOrUpdateCategoriesDto e);
        public bool Delete(int Id);
    }
}
