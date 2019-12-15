using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class DishesDB : IDishesDB
    {

        //public IConfiguration Configuration { get; }
        //public DishesDB(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        private string connectionString = null;
        public DishesDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }


        //Attribute the right courier in the right city
        public int GetIdCityRestaurant(int id)
        {
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT r.IdCity " +
                                    "FROM Dish d, Restaurant r " +
                                    "WHERE d.IdRestaurant= r.IdRestaurant " +
                                    "AND d.IdDish = @id";
                                    

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        //Get the price of the dish
        public decimal GetPrice(int id)
        {
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Price " +
                                    "FROM Dish " +
                                    "WHERE IdDish=@id";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();
                    return (decimal)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public Dish GetDish(int id)
        {
            Dish dish = null;
           // string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dish where idDish = @id ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dish = new Dish();

                            dish.IdDish = (int)dr["IdDish"];
                            dish.nameDish = (string)dr["nameDish"];
                            dish.price = (decimal)dr["price"];
                            dish.description = (string)dr["description"];
                            dish.IdRestaurant = (int)dr["IdRestaurant"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }



    }
    }
