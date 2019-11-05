using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public class SchedulesDB : ISchedulesDB
    {
        public IConfiguration Configuration { get; }
        public SchedulesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        

        public Schedule GetSchedule(int id)
        {
            Schedule schedule = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Schedule WHERE IdSchedule = @id "; 
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            schedule = new Schedule();

                            schedule.IdSchedule = (int)dr["IdSchedule"];
                            schedule.openingTime = (DateTime)dr["openingTime"];
                            schedule.closingTime = (DateTime)dr["closingTime"];
                         
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return schedule;
        }



    }
}
