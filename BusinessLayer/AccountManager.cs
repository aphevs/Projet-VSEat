using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class AccountManager
    {
        public IAccountsDB AccountDB { get; }


        public AccountManager(IConfiguration configuration)
        {
            AccountDB = new AccountsDB(configuration);
        }

        public List<Account> GetAccounts()
        {
            return AccountDB.GetAccounts();
        }

        public Account GetAccount(int id)
        {
            return AccountDB.GetAccount(id);
        }

        public Account AddAccount(Account account)
        {
            return AccountDB.AddAccount(account);
        }


        public int UpdateAccount(Account account)
        {
            return AccountDB.UpdateAccount(account);
        }

        public int DeleteAccount(int id)
        {
            return AccountDB.DeleteAccount(id);
        }



    }
}

