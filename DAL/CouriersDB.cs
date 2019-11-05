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
        public IConfiguration Configuration { get; }
        public CouriersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Courier> Couriers
        {
            get
            {
                List<Courier> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
                                courier.created_at = (DateTime)dr["created_at"];
                                courier.streetname = (string)dr["streetname"];
                                courier.IdCity = (int)dr["IdCity"];
                                courier.IdAccount = (int)dr["IdAccount"];


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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Courier where idCourier = @id ";
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
                            courier.created_at = (DateTime)dr["created_at"];
                            courier.streetname = (string)dr["streetname"];
                            courier.IdCity = (int)dr["IdCity"];
                            courier.IdAccount = (int)dr["IdAccount"];

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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Courier(name, created_at, streetname, idCity, idAccount) values(@name, @created_at, @streetname, @idCity, @idAccount); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", courier.name);
                    cmd.Parameters.AddWithValue("@created_at", courier.created_at);
                    cmd.Parameters.AddWithValue("@streetname", courier.streetname);
                    cmd.Parameters.AddWithValue("@IdCity", courier.IdCity);
                    cmd.Parameters.AddWithValue("@IdAccount", courier.IdAccount);


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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Courier SET name = @name, created_at =@created_at, streetname = @streetname, IdCity = @IdCity, IdAccount = @IdAccount WHERE IdCourier=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", courier.name);
                    cmd.Parameters.AddWithValue("@created_at", courier.created_at);
                    cmd.Parameters.AddWithValue("@streetname", courier.streetname);
                    cmd.Parameters.AddWithValue("@idCity", courier.IdCity);
                    cmd.Parameters.AddWithValue("@IdAccount", courier.IdAccount);

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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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

        List<Courier> ICouriersDB.GetCouriers()
        {
            throw new NotImplementedException();
        }

        Courier ICouriersDB.GetCourier(int id)
        {
            throw new NotImplementedException();
        }

        public List<Courier> GetCouriers()
        {
            throw new NotImplementedException();
        }


    }
}
