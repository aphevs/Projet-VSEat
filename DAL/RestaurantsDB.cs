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
        //option2
        //private string connectioNString=null;
        private IConfiguration Configuration { get; }
        public RestaurantsDB(IConfiguration configuration)
        {
            //var config = configuration;
            //connectionString = configuration.GetConnectionString("DefaultConnection")
            Configuration = configuration;
        }

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPB;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
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
                            restaurant.IdSchedule = (int)dr["IdSchedule"];

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
           // string connectionString = Configuration.GetConnectionString("DefaultConnection");
             string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPB;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant WHERE IdRestaurant = @id ";  //si plusieurs resultats, on va lire dr.Read pour les voir: location = Sion
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
                            restaurant.IdSchedule = (int)dr["IdSchedule"];
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
           // string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPB;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Restaurant(IdRestaurant, created_at, IdCity, name, IdSchedule) values(@IdRestaurant, @created_at, @IdCity, @name, @IdSchedule); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRestaurant", restaurant.IdRestaurant);
                    cmd.Parameters.AddWithValue("@created_at", restaurant.created_at);
                    cmd.Parameters.AddWithValue("@IdCity", restaurant.IdCity);
                    cmd.Parameters.AddWithValue("@name", restaurant.name);
                    cmd.Parameters.AddWithValue("@IdSchedule", restaurant.IdSchedule);

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
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string connectionString = "Data Source=153.109.124.35;Initial Catalog=VsEatPB;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Restaurant SET created_at = @created_at, IdCity = @IdCity, name = @name, IdSchedule = @IdSchedule WHERE IdRestaurant=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurant.IdRestaurant);
                    cmd.Parameters.AddWithValue("@created_at", restaurant.created_at);
                    cmd.Parameters.AddWithValue("@IdCity", restaurant.IdCity);
                    cmd.Parameters.AddWithValue("@name", restaurant.name);
                    cmd.Parameters.AddWithValue("@IdSchedule", restaurant.IdSchedule);

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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
