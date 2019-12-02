using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IAccountsDB
    {

        //IConfiguration Configuration { get; }

        //List<Account> GetCustomerAccount();

        List<Account> GetAccounts();

        Account GetAccount(int id);

        Account AddAccount(Account account);

        int UpdateAccount(Account account);

        int DeleteAccount(int id);


    }
}
