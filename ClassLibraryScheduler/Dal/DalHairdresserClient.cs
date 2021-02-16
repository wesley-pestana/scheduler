using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryScheduler.Model;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace ClassLibraryScheduler.Dal
{
    public class DalHairdresserClient
    {
        const string ConnectionString = @"Data Source=WINDEV2002EVAL\SQLEXPRESS;Initial Catalog=Estudos;Integrated Security=True";

        public List<ModelClient> SearchClient(string Name)
        {
            List<ModelClient> ReturnList = new List<ModelClient>();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_ListHairdressingClient";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Name", Name);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelClient clients = new ModelClient()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = Convert.ToInt32(reader["Phone"]),
                            Email = reader["Email"].ToString()
                        };
                        ReturnList.Add(clients);
                    }
                    
                }
            }return ReturnList;
        }
        public List<ModelClient> SearchId(int Id)
        {
            List<ModelClient> ReturnList = new List<ModelClient>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_ListHairdressingClientId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", Id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelClient clients = new ModelClient()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = Convert.ToInt32(reader["Phone"]),
                            Email = reader["Email"].ToString()
                        };
                        ReturnList.Add(clients);
                    }

                }
            }
            return ReturnList;
        }
        public void UpdateClient(ModelClient model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_UpdateHairdressingClient";
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
        public void InsetClient(ModelClient model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_InsertHairdressingClient";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Name", model.Name);
                    command.Parameters.AddWithValue("Address", model.Address);
                    command.Parameters.AddWithValue("Phone", model.Phone);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClient(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SP_DeleteHairdressingClient";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
