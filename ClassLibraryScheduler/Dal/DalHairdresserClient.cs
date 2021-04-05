using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryScheduler.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassLibraryScheduler.Dal
{
    public class DalHairdresserClient
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ConnectionString;

        public List<ModelClient> SearchClient(string Name)
        {
            try
            {
                List<ModelClient> ReturnList = new List<ModelClient>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
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
                }
                return ReturnList;
            }
            catch (Exception)
            {

                throw;
            }            
        }
        public List<ModelClient> SearchId(int Id)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
            
        }
        public void UpdateClient(ModelClient model)
        {
            try
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
            catch (Exception)
            {

                throw;
            }            
        }
        public void InsetClient(ModelClient model)
        {
            try
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
            catch (Exception)
            {

                throw;
            }            
        }

        public void DeleteClient(int Id)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
