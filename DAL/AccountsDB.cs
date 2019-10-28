using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class AccountsDB : IAccountsDB
    {
        public IConfiguration Configuration { get; }
        public AccountsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Account> Accounts
        {
            get
            {
                List<Account> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Account";
                        SqlCommand cmd = new SqlCommand(query, cn);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<Account>();

                                Account account = new Account();

                                account.IdAccount = (int)dr["IdAccount"];
                                account.login = (string)dr["login"];
                                account.password = (string)dr["password"];
                                account.IdCourier = (int)dr["IdCourier"];
                                account.IdCustomer = (int)dr["IdCustomer"];
                                account.customerAccount = (int)dr["customerAccount"];



                                results.Add(account);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return results;
            }
        }

        public Account GetAccount(int id)
        {
            Account account = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Account where idAccount = @id ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            account = new Account();

                            account.IdAccount = (int)dr["IdAccount"];
                            account.login = (string)dr["login"];
                            account.password = (string)dr["password"];
                            account.IdCourier = (int)dr["IdCourier"];
                            account.IdCustomer = (int)dr["IdCustomer"];
                            account.customerAccount = (int)dr["customerAccount"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return account;
        }

        public Account AddAccount(Account account)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Account(login, password, IdCourier, IdCustomer, customerAccount) values(@login, @password, @IdCourier, @IdCustomer); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", account.login);
                    cmd.Parameters.AddWithValue("@password", account.password);
                    cmd.Parameters.AddWithValue("@IdCourier", account.IdCourier);
                    cmd.Parameters.AddWithValue("@IdCustomer", account.IdCustomer);
                    cmd.Parameters.AddWithValue("@customerAccount", account.customerAccount);


                    cn.Open();

                    account.IdAccount = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return account;
        }

        public int UpdateAccount(Account account)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Account SET login = @login, password =@password, IdCourier = @IdCourier, IdCustomer = @IdCustomer, customerAccount = @customerAccount WHERE IdCustomer=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", account.login);
                    cmd.Parameters.AddWithValue("@password", account.password);
                    cmd.Parameters.AddWithValue("@IdCourier", account.IdCourier);
                    cmd.Parameters.AddWithValue("@IdCustomer", account.IdCustomer);
                    cmd.Parameters.AddWithValue("@customerAccount", account.customerAccount);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public int DeleteAccount(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Account WHERE IdAccount=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);                  

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        List<Account> IAccountsDB.GetAccounts()
        {
            throw new NotImplementedException();
        }

        Account IAccountsDB.GetAccount(int id)
        {
            throw new NotImplementedException();
        }

    }
}
