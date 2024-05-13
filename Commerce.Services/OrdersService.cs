using AutoMapper;
using Commerce.Dtos;
using Commerce.Models.Models;
using Commerce.Repositories.Contract;
using Commerce.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomersRepository _customersRepository;
        private readonly IProductsRepository _productsRepository;

        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, ICustomersRepository customersRepository, IProductsRepository productsRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _customersRepository = customersRepository;
            _productsRepository = productsRepository;

            _mapper = mapper;
        }




        public List<GetAllOrdersDto> GetAll(int? customerId = null)
        {
            IQueryable<Orders> query = _ordersRepository.GetAll();

            if (customerId.HasValue)
            {
                
                query = query.Where(o => o.Customers.CustomerId == customerId.Value);
            }

            var orders = query.ToList();
            var dtos = _mapper.Map<List<GetAllOrdersDto>>(orders);
            return dtos;
        }









        public GetAllOrdersDto GetOne(int Id)
        {
            var order = _ordersRepository.GetAll().FirstOrDefault(u => u.OrderId == Id);
            var dto = _mapper.Map<GetAllOrdersDto>(order);
            return dto;
        }









        public bool Create(CreateOrdersDto dto)
        {
            // Find or create the customer
            var customer = _customersRepository.GetAll().FirstOrDefault(c => c.CustomerName == dto.CustomerName);
            if (customer == null)
            {
                customer = new Customers { CustomerName = dto.CustomerName };
                _customersRepository.Create(customer);
            }

            // Find the product
            var product = _productsRepository.GetAll().FirstOrDefault(p => p.ProductName == dto.ProductName);
            if (product == null)
            { 
                return false;
            }
            // Create the order
            var order = new Orders
            {
                Customers = customer,
                OrderStatus = "Pending" 
            };
            _ordersRepository.Create(order);

            // Create order product
            var orderProduct = new OrderProducts
            {
                Orders = order,
                Products = product,
                ProductQuantity = dto.ProductQuantity
            };
            order.OrderProducts = new List<OrderProducts> { orderProduct };

            _ordersRepository.Update(order);
            return true;
        }





        public bool Update(int orderId, UpdateOrdersDto dto)
        {
            var order = _ordersRepository.GetAll().FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return false;
            }
            order.OrderStatus = dto.OrderStatus;
            _ordersRepository.Update(order);

            return true;
        }


        public bool Delete(int orderId)
        {
            var orderToDelete = _ordersRepository.GetAll().FirstOrDefault(o => o.OrderId == orderId);
            if (orderToDelete == null)
            {
                return false;
            }
            _ordersRepository.Delete(orderToDelete);
            return true;
        }




    }

}
