using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryScheduler.Model;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibraryScheduler.Dal
{
    public class DalScheduling
    {
        const string ConnectionString = @"Data Source=WINDEV2002EVAL\SQLEXPRESS;Initial Catalog=Estudos;Integrated Security=True";

        public List<ModelScheduling> Schedules()
        {
            List<ModelScheduling> ReturnList = new List<ModelScheduling>();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_ListSchesules";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelScheduling schedule = new ModelScheduling()
                        {
                            ClientName = reader["Name"].ToString(),
                            CrewName = reader["Name"].ToString(),
                            Title = reader["Title"].ToString(),
                            ScheduledStart = Convert.ToDateTime(reader["ScheduledStart"]),
                            ScheduledEnd = Convert.ToDateTime(reader["ScheduledEnd"])
                        };
                        ReturnList.Add(schedule);
                    }
                }
            }return ReturnList;
        }

        public void InsertSchedule(ModelScheduling model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_InsertScheduledTime";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ClientId", model.ClientId);
                    command.Parameters.AddWithValue("CrewId", model.CrewId);
                    command.Parameters.AddWithValue("Title", model.Title);
                    command.Parameters.AddWithValue("ScheduledStart", model.ScheduledStart);
                    command.Parameters.AddWithValue("ScheduledEnd", model.ScheduledEnd);
                    command.ExecuteNonQuery();
                }
            }
        }

        /*public void UpdateSchedule(ModelScheduling model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_InsertScheduledTime";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ClientName", model.ClientId);
                    command.Parameters.AddWithValue("CrewName", model.CrewId);
                    command.Parameters.AddWithValue("Title", model.Title);
                    command.Parameters.AddWithValue("ScheduledStart", model.ScheduledStart);
                    command.Parameters.AddWithValue("ScheduledEnd", model.ScheduledEnd);
                    command.ExecuteNonQuery();
                }
            }
        }*/

        public void DeleteSchedule(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_DeleteScheduledTime";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id",Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
