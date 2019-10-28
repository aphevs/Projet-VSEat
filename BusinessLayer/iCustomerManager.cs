using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface ICustomerManager
    {

        ICustomersDB CustomersDb { get; }

        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        Customer AddCustomer(Customer customer);

        int UpdatCustomer(Customer customer);

        int DeleteCustomer(int id);

    }
}