using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }
        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        

        public City GetCity(int id)
        {
            City city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM City WHERE IdCity = @id ";  //si plusieurs resultats, on va lire dr.Read pour les voir: location = Sion
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            city = new City();

                            city.IdCity = (int)dr["IdCity"];
                            city.code = (int)dr["code"];
                            city.name = (string)dr["name"];
                         
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;
        }



    }
}
