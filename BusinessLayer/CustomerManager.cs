using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class CustomerManager : ICustomerManager
    {
        private ICustomersDB CustomerDbObject { get; }

        public CustomerManager(ICustomersDB customersDB)
        {
            CustomerDbObject = customersDB;
        }


        public List<Customer> GetCustomers()
        {
            return CustomerDbObject.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerDbObject.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDbObject.AddCustomer(customer);
        }


        public int UpdateCustomer(Customer customer)
        {
            return CustomerDbObject.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomerDbObject.DeleteCustomer(id);
        }



    }
}

