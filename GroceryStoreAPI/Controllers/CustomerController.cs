using GroceryStoreAPI.IRepository;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerService;
        public CustomerController(ICustomerRepository customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomer")]
        public List<Customer> GetAllCustomer()
        {
            return _customerService.GetAllCustomer();
        }
        [HttpGet("GetCustomerById")]
        public List<Customer> GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }
        [HttpPost("AddCustomer")]
        public bool AddCustomer(Customer customer)
        {
            return _customerService.AddCustomer(customer);
        }
        [HttpPost("UpdateCustomer")]
        public bool UpdateCustomer(Customer customer)
        {
            return _customerService.UpdateCustomer(customer);
        }
    }
}
