using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface ICustomersDB
    {
    
        IConfiguration Configuration { get; }

        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        Customer AddCustomer(Customer costumer);

        int UpdateCustomer(Customer costumer);

        int DeleteCustomer(int id);


    }
}
