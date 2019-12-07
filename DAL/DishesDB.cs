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
                                dish.name = (string)dr["name"];
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
                            dish.name = (string)dr["name"];
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
                    string query = "Insert into Dish(name, price, description, IdRestaurant) values(@name, @price, @description, @IdRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.name);
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
                    string query = "UPDATE Dish SET name = @name, price = @price, description = @description, IdRestaurant = @IdRestaurant WHERE IdDish=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.name);
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
