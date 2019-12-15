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

        //It will INSERT the new order into the DB.
        //First, into the table 'Order', then into the 'Order_Dish'
        void IOrdersDB.SetOrder(Dictionary<int, int> dishes, int idCustomer, DateTime date, int idCourier)
        {
            int id_pk = 0;
            int result = 0;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO [Order] (IdCustomer, status,created_at, timeToDeliver, IdCourier) " +
                                    "OUTPUT Inserted.IdOrder " + // Retrieve id of the order
                                    "VALUES (@idCustomer, @status, @date,@created_at, @idCourier)";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@idCustomer", idCustomer);
                    cmd.Parameters.AddWithValue("@status", "non delivered");
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@idCourier", idCourier);

                    cn.Open();

                    // Insert data in 'Order' table and get the id of the order
                    id_pk = (Int32)cmd.ExecuteScalar();

                    // Insert data in Order_Dishes table
                    foreach (var dish in dishes)
                    {
                        if (dish.Value != 0)
                        {
                            query = "INSERT INTO Order_Dish (IdOrder, IdDish, quantity) " +
                                 "VALUES (@idOrder, @idDish, @quantity)";

                            SqlCommand cmd2 = new SqlCommand(query, cn);

                            cmd2.Parameters.AddWithValue("@idOrder", id_pk);
                            cmd2.Parameters.AddWithValue("@idDish", dish.Key);
                            cmd2.Parameters.AddWithValue("@quantity", dish.Value);

                            result = cmd2.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
          
        }

        public int CountCourierOrders(DateTime date, int idCourier)
        {
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT count(*) " +
                                    "FROM [Order] " +
                                    "WHERE IdCourier=@id " +
                                    "AND timeToDeliver = @date " +
                                    "OR timeToDeliver = @date_after " +
                                    "OR timeToDeliver = @date_after_after";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@id", idCourier);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@date_after", date.AddMinutes(15));
                    cmd.Parameters.AddWithValue("@date_after_after", date.AddMinutes(30));

                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //With this, it will show only the orders that are linked to the courier logged
        public List<Order> GetCustomerOrdersWithIdCourier(int IdGiven)
        {
            List<Order> lOrder = null;

            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "SELECT * FROM [Order] inner join Customer on [Order].IdCustomer=Customer.IdCustomer WHERE [Order].IdCourier = @IdGiven";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdGiven", IdGiven);
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
                            orderTemp.timeToDeliver = (DateTime)dr["timeToDeliver"];
                            //orderTemp.totalprice = (decimal)dr["totalprice"];
                            orderTemp.IdCustomer = (int)dr["IdCustomer"];
                            orderTemp.IdCourier = (int)dr["IdCourier"];
                            orderTemp.name = (string)dr["name"];
                            orderTemp.lastname = (string)dr["lastname"];
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

        public List<Order> GetMyOrdersWithIdCustomer(int IdGiven)
        {
            List<Order> lOrder = null;

            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "SELECT * FROM [Order] inner join Customer on [Order].IdCustomer=Customer.IdCustomer WHERE [Order].IdCustomer = @IdGiven";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdGiven", IdGiven);
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
                            orderTemp.timeToDeliver = (DateTime)dr["timeToDeliver"];
                            //orderTemp.totalprice = (decimal)dr["totalprice"];
                            orderTemp.IdCustomer = (int)dr["IdCustomer"];
                            orderTemp.IdCourier = (int)dr["IdCourier"];
                            orderTemp.name = (string)dr["name"];
                            orderTemp.lastname = (string)dr["lastname"];
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
                            order.timeToDeliver = (DateTime)dr["timeToDeliver"];
                            //order.totalprice = (decimal)dr["totalprice"];
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



        public Order GetCustomerOrder(int id)
        {
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            Order order = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Order] inner join Customer on [Order].IdCustomer=Customer.IdCustomer WHERE IdOrder = @id";
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
                            order.timeToDeliver = (DateTime)dr["timeToDeliver"];
                           // order.totalprice = (decimal)dr["totalprice"];
                            order.IdCustomer = (int)dr["IdCustomer"];
                            order.IdCourier = (int)dr["IdCourier"];
                            order.name = (string)dr["name"];
                            order.lastname = (string)dr["lastname"];
                            order.streetname = (string)dr["streetname"];
                            order.IdCity = (int)dr["IdCity"];


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




        public int SetDelivered(Order order)
        {
            int result = 0;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [Order] SET status = @status WHERE IdOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order.IdOrder);
                    cmd.Parameters.AddWithValue("@status", order.status);

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
