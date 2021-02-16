using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryScheduler.Model;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibraryScheduler.Dal
{
    public class DalHairdresserCrew
    {
        const string ConnectionString = @"Data Source=WINDEV2002EVAL\SQLEXPRESS;Initial Catalog=Estudos;Integrated Security=True";

        public List<ModelHairdresserCrew> SearchCrew(string Name)
        {
            List<ModelHairdresserCrew> ReturnList = new List<ModelHairdresserCrew>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_ListHairdressingCrew";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Name", Name);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelHairdresserCrew crew = new ModelHairdresserCrew()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = Convert.ToInt32(reader["Phone"]),
                            Email = reader["Email"].ToString()
                        };
                        ReturnList.Add(crew);
                    }

                }
            }
            return ReturnList;
        }
        public List<ModelHairdresserCrew> SearchId(int Id)
        {
            List<ModelHairdresserCrew> ReturnList = new List<ModelHairdresserCrew>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_ListHairdressingCrewId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", Id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelHairdresserCrew crew = new ModelHairdresserCrew()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = Convert.ToInt32(reader["Phone"]),
                            Email = reader["Email"].ToString()
                        };
                        ReturnList.Add(crew);
                    }

                }
            }
            return ReturnList;
        }
        public void UpdateCrew(ModelHairdresserCrew model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_UpdateHairdressingCrew";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", model.Id);
                    command.Parameters.AddWithValue("Name", model.Name);
                    command.Parameters.AddWithValue("Address", model.Address);
                    command.Parameters.AddWithValue("Phone", model.Phone);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsetCrew(ModelHairdresserCrew model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_InsertHairdressingCrew";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Name", model.Name);
                    command.Parameters.AddWithValue("Address", model.Address);
                    command.Parameters.AddWithValue("Phone", model.Phone);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCrew(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_DeleteHairdressingCrew";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
