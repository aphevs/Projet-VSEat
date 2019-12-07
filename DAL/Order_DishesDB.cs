using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class Order_DishesDB : IOrder_DishesDB
    {
        //public IConfiguration Configuration { get; }
        //public Order_DishesDB(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}


        private string connectionString = null;

        public Order_DishesDB(IConfiguration configuration)
        {

            connectionString = configuration.GetConnectionString("DefaultConnection");

        }



        public Order_Dish GetOrder_Dish(int id)
        {
            Order_Dish order_dish = null;
           // string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order_Dish WHERE IdOrder = @id ";  
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order_dish = new Order_Dish();
                            order_dish.IdOrder = (int)dr["IdOrder"];
                            order_dish.quantity = (int)dr["quantity"];
                            order_dish.IdDish = (int)dr["IdDish"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order_dish;
        }


    }
}
