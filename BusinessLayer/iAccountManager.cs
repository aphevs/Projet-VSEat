using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface IAccountManager
    {

        IAccountsDB AccountsDb { get; }

        List<Account> GetAccounts();

        Account GetAccount(int id);

        Account AddAccount(Account account);

        int UpdateAccount(Account account);

        int DeleteAccount(int id);

    }
}