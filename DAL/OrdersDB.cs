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
        private string connectionString = null;
        public OrdersDB(IConfiguration configuration)
        {
            var config = configuration;
            connectionString = config.GetConnectionString("DefaultConnection");
        }




        public List<Order> GetOrders()
        {
            List<Order> results = null;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Order]";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.IdOrder = (int)dr["IdOrder"];
                            order.status = (string)dr["status"];
                            order.created_at = (DateTime)dr["created_at"];
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


        public List<Order> GetCustomerOrders()
        {
            List<Order> lOrder = null;

            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            { 
            using (SqlConnection cn = new SqlConnection(connectionString))
            {

                string query = "SELECT * FROM [Order] inner join Customer on [Order].IdCustomer=Customer.IdCustomer";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (lOrder == null)
                                lOrder = new List<Order>();

                        Order orderTemp = new Order();

                            orderTemp.IdOrder = (int)dr["IdOrder"];
                            orderTemp.status = (string)dr["status"];
                            orderTemp.created_at = (DateTime)dr["created_at"];
                            orderTemp.IdCustomer = (int)dr["IdCustomer"];
                            orderTemp.IdCourier = (int)dr["IdCourier"];
                            orderTemp.name = (string)dr["name"];
                            orderTemp.streetname = (string)dr["streetname"];
                            orderTemp.IdCity = (int)dr["IdCity"];

                            lOrder.Add(orderTemp);

                    }
                }
            }
            }
            catch (Exception e)
            {
                throw e;
            }

            return lOrder;
        }




        public Order GetOrder(int id)
        {
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            Order order = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Order] WHERE IdOrder = @id"; 
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
                            order.created_at = (DateTime)dr["created_at"];
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

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Order(IdOrder, status, created_at, IdCustomer, IdCourier) values(@IdOrder, @status, @created_at, @IdCustomer, @IdCourier); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOrder", order.IdOrder);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@created_at", order.created_at);
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
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [Order] SET status = @status, created_at = @created_at, IdCustomer = @IdCustomer, IdCourier = @IdCourier WHERE IdOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order.IdOrder);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@created_at", order.created_at);
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
