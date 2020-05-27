using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using DiaryApplication.Core.DataBase;

namespace DataBaseLib
{
    public class DataBaseProfile : IDatabase<ProfileDTO, bool>
    {
        private string commandCreate = "INSERT INTO Profile" +
                                    "(FirstName, SecondName) VALUES(@FirstName, @SecondName)";

        private string commandSelect = "SELECT * FROM Profile";

        private readonly DataBaseClient client;
        
        public DataBaseProfile()
        {
            client = DataBaseClient.Source;
        }

        public async Task<List<ProfileDTO>> SelectAll()
        {
            List<ProfileDTO> profiles = new List<ProfileDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandSelect, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var profile = new ProfileDTO(
                            dataReader.GetInt32(0),
                            dataReader.GetString(1),
                            dataReader.GetString(2));
                        profiles.Add(profile);
                    }
                }
                client.CloseConnection();
                return profiles;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseProfile.GetAllProfiles()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<ProfileDTO> SelectById(int id)
        {
            string commandSelectById = $"SELECT * FROM Profile WHERE ID = {id}";
            ProfileDTO profile = new ProfileDTO();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandSelectById, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        profile = new ProfileDTO(
                            dataReader.GetInt32(0),
                            dataReader.GetString(1),
                            dataReader.GetString(2));
                    }
                }
                client.CloseConnection();
                return profile;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseProfile.GetAllProfiles()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<bool> Update(int id, ProfileDTO newObject)
        {
            string updateCommand =
                $"UPDATE Profile SET FirstName='{newObject.FirstName}', SecondName='{newObject.SecondName}' " +
                $"FROM (SELECT * FROM Profile WHERE ID = {id}) AS Selected WHERE Profile.ID = Selected.ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(updateCommand, client.OpenConnection()))
                {
                    cmd.ExecuteNonQuery();
                }
                client.CloseConnection();
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseProfile.Update()] Error: " + exception.Message);
                client.CloseConnection();
                return false;
            }
            
        }

        public Task<ProfileDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(ProfileDTO newObject)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandCreate, client.OpenConnection()))
                {
                    cmd.Parameters.AddWithValue("@FirstName", newObject.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", newObject.SecondName);
                    var row = await cmd.ExecuteNonQueryAsync();
                    Debug.WriteLine("[DataBaseProfile.InsertProfile()]: Rows: " + row);
                }
                client.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
                client.CloseConnection();
                return false;
            }
        }
    }
}
