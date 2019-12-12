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
        public ICustomersDB CustomerDbObject { get; }

        public CustomerManager(ICustomersDB customersDB)
        {
            CustomerDbObject = customersDB;
        }

        public Customer GetCustomerByUsernamePassword(string login, string password)
        {
            return CustomerDbObject.GetCustomerByUsernamePassword(login,password);
        }



        //vérifie que le customer est dans la liste des customers
        public bool isCustomerValid(Customer cus)
        {         

            List<Customer> list = CustomerDbObject.GetCustomers();

            foreach (Customer customer in list)
            {
                if (cus.login.Equals(customer.login) && cus.password.Equals(customer.password))
                {
                    return true;
                }
                   
            }
            return false;

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

