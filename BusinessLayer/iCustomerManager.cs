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
        Customer GetCustomerByUsernamePassword(string login, string password);


        bool isCustomerValid(Customer cus);


    }
}