using GroceryStoreAPI.IRepository;
using GroceryStoreAPI.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace GroceryStoreAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger = null;

        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (StreamReader r = new StreamReader("database.json"))
                {
                    string json = r.ReadToEnd();
                    customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                }
            }
            catch(Exception ex)
            {
                //Exception Logging 
            }
            return customers;
        }

        public List<Customer> GetCustomerById(int id)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (StreamReader r = new StreamReader("database.json"))
                {
                    string json = r.ReadToEnd();
                    customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                }
                customers = customers.Where(a=> a.id == id).ToList();
            }
            catch(Exception ex)
            {
                //implement Exception Logging 
            }
            return customers;
        }

        public bool AddCustomer(Customer customer)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                if (customer.id == 0 && customer.name == "")
                {
                    return false;
                }

                using (StreamReader r = new StreamReader("database.json"))
                {
                    Customer newCustomer = new Customer();
                    newCustomer.id = customer.id;
                    newCustomer.name = customer.name;

                    string json = r.ReadToEnd();
                    customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                    customers.Add(newCustomer);

                    json = JsonConvert.SerializeObject(customers);
                    File.WriteAllText("database.json", json);
                }
            }
            catch(Exception ex)
            {
                //implement Exception Logging
                return false;
            }
            return true;
        }
        public bool UpdateCustomer(Customer customer) 
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                if(customer.id == 0 && customer.name=="" )
                {
                    return false;
                }
                using (StreamReader r = new StreamReader("database.json"))
                {
                    string json = r.ReadToEnd();
                    customers = JsonConvert.DeserializeObject<List<Customer>>(json);

                    //filter by id 
                    customers.Where(a => a.id == customer.id).ToList().ForEach(c => c.name = customer.name) ;

                    json = JsonConvert.SerializeObject(customers);
                    File.WriteAllText("database.json", json);
                }
            }
            catch(Exception ex)
            {
                //implement Exception Logging
                return false;
            }
            return true;
        }
    }
}
