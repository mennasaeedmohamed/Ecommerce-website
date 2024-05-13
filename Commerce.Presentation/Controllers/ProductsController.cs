using Commerce.Dtos;
using Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsService ProductsService;
        public ProductsController(IProductsService _productsService)
        {
            ProductsService = _productsService;
        }



        [HttpGet]
        [Authorize(Roles = "Admin,User")]

        //public IActionResult GetAll()
        //{
        //    var query = ProductsService.GetAll();
        //    return Ok(query);
        //}

        public IActionResult GetAllProducts(int? categoryId = null)
        {
            var products = ProductsService.GetAll(categoryId);
            return Ok(products);
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin,User")]

        public IActionResult GetOne(int Id )
        {
            var query = ProductsService.GetOne(Id);
            return Ok(query);
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Create(CreateOrUpdateProductsDto e)
        {
            if (ModelState.IsValid)
            {
                var res = ProductsService.Create(e);
                if (res)
                    return Created();
                else
                    return StatusCode(500, "Already Exist");
            }
            else
                return BadRequest();

        }



        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Update(int id, CreateOrUpdateProductsDto u)
        {
            var result = ProductsService.Update(id, u);

            if (result)
            {
                return Ok(); 
            }
            else
            {
                return NotFound(); 
            }
        }






        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {
            var result = ProductsService.Delete(id);

            if (result)
            {
                return NoContent(); 
            }
            else
            {
                return NotFound(); 
            }
        }


    }
}
