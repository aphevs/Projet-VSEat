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
        public CustomersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Customer> GetCustomerAccount()
        {
            List<Customer> lCustomer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "SELECT * FROM Customer inner join Account on Customer.IdAccount=Account.IdAccount";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (lCustomer == null)
                                lCustomer = new List<Customer>();

                            Customer accountTemp = new Customer();
                            accountTemp.IdCustomer = (int)dr["IdCustomer"];
                            accountTemp.name = (string)dr["name"];
                            accountTemp.created_at = (DateTime)dr["created_at"];
                            accountTemp.streetname = (string)dr["streetname"];
                            accountTemp.IdCity = (int)dr["IdCity"];
                            accountTemp.IdAccount = (int)dr["IdAccount"];
                            accountTemp.login = (string)dr["login"];
                            accountTemp.password = (string)dr["password"];
                            accountTemp.customerAccount = (bool)dr["customerAccount"];
                           
                           

                            lCustomer.Add(accountTemp);

                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return lCustomer;
        }






        public List<Customer> Customers
        {
            get
            {
                List<Customer> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
                                customer.created_at = (DateTime)dr["created_at"];
                                customer.streetname = (string)dr["streetname"];
                                customer.IdCity = (int)dr["IdCity"];
                                customer.IdAccount = (int)dr["IdAccount"];


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

        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Costumer where idCustomer = @id ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer = new Customer();

                            customer.IdCustomer = (int)dr["IdCustomer"];
                            customer.name = (string)dr["name"];
                            customer.created_at = (DateTime)dr["created_at"];
                            customer.streetname = (string)dr["streetname"];
                            customer.IdCity = (int)dr["IdCity"];
                            customer.IdAccount = (int)dr["IdAccount"];

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

        public Customer AddCustomer(Customer customer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Customer(name, created_at, streetname, idCity, idAccount) values(@name, @created_at, @streetname, @idCity, @idAccount); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", customer.name);
                    cmd.Parameters.AddWithValue("@created_at", customer.created_at);
                    cmd.Parameters.AddWithValue("@streetname", customer.streetname);
                    cmd.Parameters.AddWithValue("@IdCity", customer.IdCity);
                    cmd.Parameters.AddWithValue("@IdAccount", customer.IdAccount);


                    cn.Open();

                    customer.IdCustomer = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public int UpdateCustomer(Customer customer)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customer SET name = @name, created_at =@created_at, streetname = @streetname, IdCity = @IdCity, IdAccount = @IdAccount WHERE IdCustomer=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", customer.name);
                    cmd.Parameters.AddWithValue("@created_at", customer.created_at);
                    cmd.Parameters.AddWithValue("@streetname", customer.streetname);
                    cmd.Parameters.AddWithValue("@idCity", customer.IdCity);
                    cmd.Parameters.AddWithValue("@IdAccount", customer.IdAccount);

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

        public int DeleteCustomer(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Customer WHERE IdCustomer=@id";
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

        List<Customer> ICustomersDB.GetCustomers()
        {
            throw new NotImplementedException();
        }

        Customer ICustomersDB.GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }


    }
}
