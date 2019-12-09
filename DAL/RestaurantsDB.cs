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

        public Restaurant GetRestaurant(int id)
        {
            Restaurant restaurant = null;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant WHERE IdRestaurant = @id "; 
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurant.created_at = (DateTime)dr["created_at"];
                            restaurant.IdCity = (int)dr["IdCity"];
                            restaurant.name = (string)dr["name"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Restaurant(IdRestaurant, created_at, IdCity, name) values(@IdRestaurant, @created_at, @IdCity, @name); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRestaurant", restaurant.IdRestaurant);
                    cmd.Parameters.AddWithValue("@created_at", restaurant.created_at);
                    cmd.Parameters.AddWithValue("@IdCity", restaurant.IdCity);
                    cmd.Parameters.AddWithValue("@name", restaurant.name);
                    cn.Open();

                    restaurant.IdRestaurant = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            int result = 0;
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPiguetBerthouzoz;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Restaurant SET created_at = @created_at, IdCity = @IdCity, name = @name WHERE IdRestaurant=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurant.IdRestaurant);
                    cmd.Parameters.AddWithValue("@created_at", restaurant.created_at);
                    cmd.Parameters.AddWithValue("@IdCity", restaurant.IdCity);
                    cmd.Parameters.AddWithValue("@name", restaurant.name);

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

        public int DeleteRestaurant(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Restaurant WHERE IdRestaurant=@id";
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
