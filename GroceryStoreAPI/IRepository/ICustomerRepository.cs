using GroceryStoreAPI.Models;
using System.Collections.Generic;

namespace GroceryStoreAPI.IRepository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        List<Customer> GetCustomerById(int id);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
    }
}
