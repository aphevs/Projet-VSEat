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


        //We don't need this method because we use postal code as Id for the table City
        // A SUPPRIMER ALEX ALEX ALEX ALEX
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



        public List<Dish> Dishes
        {
            get
            {
                List<Dish> results = null;
                //string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Dish";
                        SqlCommand cmd = new SqlCommand(query, cn);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<Dish>();

                                Dish dish = new Dish();

                                dish.IdDish = (int)dr["IdDish"];
                                dish.nameDish = (string)dr["nameDish"];
                                dish.price = (int)dr["price"];
                                dish.description = (string)dr["description"];
                                dish.IdRestaurant = (int)dr["IdRestaurant"];



                                results.Add(dish);
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

        public Dish AddDish(Dish dish)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Dish(nameDish, price, description, IdRestaurant) values(@nameDish, @price, @description, @IdRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nameDish", dish.nameDish);
                    cmd.Parameters.AddWithValue("@price", dish.price);
                    cmd.Parameters.AddWithValue("@description", dish.description);
                    cmd.Parameters.AddWithValue("@IdRestaurant", dish.IdRestaurant);


                    cn.Open();

                    dish.IdDish = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public int UpdateDish(Dish dish)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Dish SET nameDish = @nameDish, price = @price, description = @description, IdRestaurant = @IdRestaurant WHERE IdDish=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nameDish", dish.nameDish);
                    cmd.Parameters.AddWithValue("@price", dish.price);
                    cmd.Parameters.AddWithValue("@description", dish.description);
                    cmd.Parameters.AddWithValue("@IdRestaurant", dish.IdRestaurant);

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

        public int DeleteDish(int id)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Dish WHERE IdDish=@id";
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

        public List<Dish> GetDishes()
        {
            throw new NotImplementedException();
        }

        public Dish AddCustomer(Dish dish)
        {
            throw new NotImplementedException();
        }


    }
    }
