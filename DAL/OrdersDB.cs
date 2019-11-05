using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class OrdersDB : IOrdersDB
    {
        public IConfiguration Configuration { get; }
        public OrdersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Order> GetOrders()
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.IdOrder= (int)dr["IdOrder"];
                            order.status = (string)dr["status"];
                            order.placetodeliver = (string)dr["placetodeliver"];
                            order.comment = (string)dr["comment"];
                            order.IdCustomer = (int)dr["IdCustomer"];
                            order.IdCourier = (int)dr["IdCourier"];

                            results.Add(order);
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

        public Order GetOrder(int id)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order WHERE IdOrder = @id "; 
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Order();

                            order.IdOrder = (int)dr["IdOrder"];
                            order.status = (string)dr["status"];
                            order.placetodeliver = (string)dr["placetodeliver"];
                            order.comment = (string)dr["comment"];
                            order.IdCustomer = (int)dr["IdCustomer"];
                            order.IdCourier = (int)dr["IdCourier"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public Order AddOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Order(IdOrder, status, created_at, placedeliver, comment, IdCustomer, IdCourier) values(@IdOrder, @status, @created_at, @placetodeliver, @comment, @IdCustomer, @IdCourier); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOrder", order.IdOrder);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@created_at", order.created_at);
                    cmd.Parameters.AddWithValue("@placetodeliver", order.placetodeliver);
                    cmd.Parameters.AddWithValue("@comment", order.comment);
                    cmd.Parameters.AddWithValue("@IdCustomer", order.IdCustomer);
                    cmd.Parameters.AddWithValue("@IdCourier", order.IdCourier);
                    cn.Open();

                    order.IdOrder = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Restaurant SET IdRestaurant = @Idrestaurant, created_at = @created_at, IdCity = @IdCity, name = @name, IdSchedule = @IdSchedule WHERE IdRestaurant=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Idrestaurant", order.IdOrder);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@created_at", order.created_at);
                    cmd.Parameters.AddWithValue("@placetodeliver", order.placetodeliver);
                    cmd.Parameters.AddWithValue("@comment", order.comment);
                    cmd.Parameters.AddWithValue("@IdCustomer", order.IdCustomer);
                    cmd.Parameters.AddWithValue("@IdCourier", order.IdCourier);
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

        public int DeleteOrder(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Order WHERE IdOrder=@id";
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

    }
}
