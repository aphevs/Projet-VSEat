using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class RestaurantsDB : IRestaurantsDB
    {
 
        private string connectionString=null;

        public RestaurantsDB(IConfiguration configuration)
        {
           
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();
                            
                           
                            Restaurant restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurant.created_at = (DateTime)dr["created_at"];
                            restaurant.name = (string)dr["name"];
                            restaurant.IdCity = (int)dr["IdCity"];

                            results.Add(restaurant);
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





        public List<Restaurant> GetRestaurantsFromCity(int id)
        {
            List<Restaurant> results = null;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant where IdCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();


                            Restaurant restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurant.created_at = (DateTime)dr["created_at"];
                            restaurant.name = (string)dr["name"];
                            restaurant.IdCity = (int)dr["IdCity"];

                            results.Add(restaurant);
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



        public List<Restaurant> GetRestaurantDishes(int id)
        {
            List<Restaurant> results = null;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant inner join Dish on Restaurant.IdRestaurant = Dish.IdRestaurant WHERE Restaurant.IdRestaurant = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurant.created_at = (DateTime)dr["created_at"];
                            restaurant.name = (string)dr["name"];
                            restaurant.IdCity = (int)dr["IdCity"];
                            restaurant.IdDish = (int)dr["IdDish"];
                            restaurant.nameDish = (string)dr["nameDish"];
                            restaurant.price = (decimal)dr["price"];
                            restaurant.description = (string)dr["description"];

                            results.Add(restaurant);

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
}
