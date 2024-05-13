using AutoMapper;
using Commerce.Dtos;
using Commerce.Models.Models;
using Commerce.Repositories.Contract;
using Commerce.Repositories.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }




        //public List<GetAllProductsDto> GetAll()
        //{
        //    var products = _productsRepository.GetAll().ToList();
        //    var dtos = _mapper.Map<List<GetAllProductsDto>>(products);
        //    return dtos;
        //}

        public List<GetAllProductsDto> GetAll(int? categoryId = null)
        {
            IEnumerable<Products> products;

            if (categoryId.HasValue)
            {
                products = _productsRepository.GetAll().Where(p => p.Categories.CategoryId == categoryId.Value);
            }
            else
            {
                products = _productsRepository.GetAll();
            }

            var dtos = _mapper.Map<List<GetAllProductsDto>>(products);
            return dtos;
        }





        public GetAllProductsDto GetOne(int Id)
        {
            var product = _productsRepository.GetAll().FirstOrDefault(u => u.ProductId == Id);
            var dto = _mapper.Map<GetAllProductsDto>(product);
            return dto;
        }








        public bool Create(CreateOrUpdateProductsDto e)
        {
            var alreadyExists = _productsRepository.GetAll().FirstOrDefault(u => u.ProductName == e.ProductName);
            if (alreadyExists != null)
            {
                return false;
            }

            var category = _categoriesRepository.GetAll().FirstOrDefault(c => c.CategoryName == e.CategoryName);
            if (category == null)
            {
                return false;
            }

            Products prod = _mapper.Map<CreateOrUpdateProductsDto, Products>(e);
            prod.Categories = category;
            _productsRepository.Create(prod);
            return true;


        }





        public bool Update(int Id, CreateOrUpdateProductsDto e)
        {
            var existingProduct = _productsRepository.GetAll().FirstOrDefault(p => p.ProductId == Id);
            if (existingProduct == null)
            {
                return false;
            }

            var alreadyExists = _productsRepository.GetAll().FirstOrDefault(u => u.ProductName == e.ProductName && u.ProductId != Id);
            if (alreadyExists != null)
            {
                return false;
            }

            _mapper.Map(e, existingProduct);

            if (!string.IsNullOrEmpty(e.CategoryName))
            {
                var category = _categoriesRepository.GetAll().FirstOrDefault(c => c.CategoryName == e.CategoryName);
                if (category == null)
                {
                    return false;
                }

                existingProduct.Categories = category;
            }

            _productsRepository.Update(existingProduct);
            return true;
        }











        public bool Delete(int Id)
        {
            var producttodelete = _productsRepository.GetAll().FirstOrDefault(e => e.ProductId == Id);
            if (producttodelete != null)
            {
                _productsRepository.Delete(producttodelete);
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}

