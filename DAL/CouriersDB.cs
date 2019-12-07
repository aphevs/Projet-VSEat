using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class CouriersDB : ICouriersDB
    {
        //public IConfiguration Configuration { get; }
        //public CouriersDB(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        private string connectionString = null;
        public CouriersDB(IConfiguration configuration)
        {
            var config = configuration;
            connectionString = config.GetConnectionString("DefaultConnection");
        }


        public List<Courier> GetCouriers()
        {
            
            {
                List<Courier> results = null;
                //string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Courier";
                        SqlCommand cmd = new SqlCommand(query, cn);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<Courier>();

                                Courier courier = new Courier();

                                courier.IdCourier = (int)dr["IdCourier"];
                                courier.name = (string)dr["name"];
                                courier.login = (string)dr["login"];
                                courier.password = (string)dr["password"];
                                courier.IdCity = (int)dr["IdCity"];


                                results.Add(courier);
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

        public Courier GetCourier(int id)
        {
            Courier courier = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Courier WHERE IdCourier = @id ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            courier = new Courier();

                            courier.IdCourier = (int)dr["IdCourier"];
                            courier.name = (string)dr["name"];
                            courier.login = (string)dr["login"];
                            courier.password = (string)dr["password"];
                            courier.IdCity = (int)dr["IdCity"];
                           
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return courier;
        }

        public Courier AddCourier(Courier courier)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Courier(IdCourier, name, login, password, IdCity) values(@IdCourier, @name, @login, @password, @IdCity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", courier.name);
                    cmd.Parameters.AddWithValue("@login", courier.login);
                    cmd.Parameters.AddWithValue("@password", courier.password);
                    cmd.Parameters.AddWithValue("@IdCity", courier.IdCity);

                    cn.Open();

                    courier.IdCourier = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return courier;
        }

        public int UpdateCourier(Courier courier)
        {
            int result = 0;
           // string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Courier SET name = @name, login =@login, password = @password, IdCity = @IdCity WHERE IdCourier=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", courier.IdCourier);
                    cmd.Parameters.AddWithValue("@name", courier.name);
                    cmd.Parameters.AddWithValue("@login", courier.login);
                    cmd.Parameters.AddWithValue("@password", courier.password);
                    cmd.Parameters.AddWithValue("@IdCity", courier.IdCity);


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

        public int DeleteCourier(int id)
        {
            int result = 0;
           // string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Courier WHERE IdCourier=@id";
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
