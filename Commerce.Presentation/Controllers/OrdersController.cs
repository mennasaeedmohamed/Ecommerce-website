using Commerce.Dtos;
using Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersService OrdersService;
        public OrdersController(IOrdersService _ordersService)
        {
            OrdersService = _ordersService;
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult GetAllOrders(int? customerId)
        {
            var orders = OrdersService.GetAll(customerId);
            return Ok(orders);
        }



        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult GetOne(int Id)
        {
            var query = OrdersService.GetOne(Id);
            return Ok(query);
        }


        [HttpPost]
        [Authorize(Roles = "User")]

        public IActionResult Create(CreateOrdersDto dto)
        {
            var result = OrdersService.Create(dto);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Failed to create order.");
        }



        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult UpdateOrder(int id, UpdateOrdersDto dto)
        {
            var result = OrdersService.Update(id, dto);

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

        public IActionResult DeleteOrder(int id)
        {
            var result = OrdersService.Delete(id);

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
