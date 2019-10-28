using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class CustomerManager
    {
        public ICustomersDB CustomerDB { get; }


        public CustomerManager(IConfiguration configuration)
        {
            CustomerDB = new CustomersDB(configuration);
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDB.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerDB.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDB.AddCustomer(customer);
        }


        public int UpdateCustomer(Customer customer)
        {
            return CustomerDB.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomerDB.DeleteCustomer(id);
        }



    }
}

