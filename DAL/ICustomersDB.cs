using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface ICustomersDB
    {
    
        //IConfiguration Configuration { get; }

        List<Customer>GetCustomerAccount();

        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        Customer AddCustomer(Customer customer);

        int UpdateCustomer(Customer customer);

        int DeleteCustomer(int id);


    }
}
