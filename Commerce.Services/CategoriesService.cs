using AutoMapper;
using Commerce.Repositories.Contract;
using Commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commerce.Repositories.Repository;
using Commerce.Models.Models;

namespace Commerce.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesService( ICategoriesRepository categoriesRepository, IMapper mapper)
        {
           
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }


        public List<GetAllCategoriesDto> GetAll()
        {
            var categories = _categoriesRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<GetAllCategoriesDto>>(categories);
            return dtos;
        }


        public GetAllCategoriesDto GetOne(int Id)
        {
            var category = _categoriesRepository.GetAll().FirstOrDefault(u => u.CategoryId == Id);
            var dto = _mapper.Map<GetAllCategoriesDto>(category);
            return dto;
        }


        public bool Create(CreateOrUpdateCategoriesDto e)
        {
            var category = _mapper.Map<Categories>(e);
            _categoriesRepository.Create(category);
            return true;
        }

        public bool Update(int Id, CreateOrUpdateCategoriesDto e)
        {
            var existingCategory = _categoriesRepository.GetAll().FirstOrDefault(c => c.CategoryId == Id);
            if (existingCategory == null)
                return false;

            _mapper.Map(e, existingCategory);
            _categoriesRepository.Update(existingCategory);
            return true;
        }

        public bool Delete(int Id)
        {
            var categoryToDelete = _categoriesRepository.GetAll().FirstOrDefault(c => c.CategoryId == Id);
            if (categoryToDelete == null)
                return false;

            _categoriesRepository.Delete(categoryToDelete);
            return true;
        }
    }
}
