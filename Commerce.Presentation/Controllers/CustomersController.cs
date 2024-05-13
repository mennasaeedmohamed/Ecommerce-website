using Commerce.Dtos;
using AutoMapper;
using Commerce.Models.Models;
using Commerce.Repositories.Contract;
using Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomersRepository CustomersRepository;
        private readonly IMapper _mapper;
        public CustomersController(ICustomersRepository _customersRepository, IMapper mapper)
        {
            CustomersRepository = _customersRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult GetAll()
        {
            var query = CustomersRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<GetAllCustomersDto>>(query);
            return Ok(dtos);
        }
    }
}
