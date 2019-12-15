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

        //Méthode vérifiant que customer n'est pas nul et donc valide
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


    }
}

