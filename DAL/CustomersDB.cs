using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class CustomersDB : ICustomersDB
    {
        public IConfiguration Configuration { get; }
        //public CustomersDB(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        private string connectionString = null;
        public CustomersDB(IConfiguration configuration)
        {
            //var config = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public List<Customer> GetCustomers()
        {
            
            {
                List<Customer> results = null;

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Customer";
                        SqlCommand cmd = new SqlCommand(query, cn);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<Customer>();

                                Customer customer = new Customer();

                                customer.IdCustomer = (int)dr["IdCustomer"];
                                customer.name = (string)dr["name"];
                                customer.lastname = (string)dr["lastname"];
                                customer.streetname = (string)dr["streetname"];
                                customer.login = (string)dr["login"];
                                customer.password = (string)dr["password"];
                                customer.IdCity = (int)dr["IdCity"];


                                results.Add(customer);
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
        public Customer GetCustomerByUsernamePassword(string login, string password)
        {
            Customer customer = null;

            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "Select * from Customer where login = @login and @password = password";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer = new Customer();

                            customer.IdCustomer = (int)dr["IdCustomer"];
                            customer.name = (string)dr["name"];
                            customer.lastname = (string)dr["lastname"];
                            customer.streetname = (string)dr["streetname"];
                            customer.login = (string)dr["login"];
                            customer.password = (string)dr["password"];
                            customer.IdCity = (int)dr["IdCity"];


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }



    }
}
