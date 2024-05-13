using Commerce.Dtos;
using Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoriesService CategoriesService;
        public CategoriesController(ICategoriesService _categoriesService)
        {
            CategoriesService = _categoriesService;
        }



        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAll()
        {
            var query = CategoriesService.GetAll();
            return Ok(query);
        }


        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin,User")]

        public IActionResult GetOne(int Id)
        {
            var query = CategoriesService.GetOne(Id);
            return Ok(query);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Create(CreateOrUpdateCategoriesDto dto)
        {
            var result = CategoriesService.Create(dto);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Failed to create category.");
        }


        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Update(int Id, CreateOrUpdateCategoriesDto dto)
        {
            var result = CategoriesService.Update(Id, dto);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Failed to update category.");
        }


        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int Id)
        {
            var result = CategoriesService.Delete(Id);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Failed to delete category.");
        }
    }
}
