using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.Utills;

namespace DiaryApplication.SignIn.Data.Local
{
    public class DataBaseProfile
    {
        private string commandAdd = "INSERT INTO Profile" +
                                    "(FirstName, SecondName) VALUES(@FirstName, @SecondName)";

        private string commandGetAll = "SELECT * FROM Profile";

        private readonly DataBaseClient client;
        
        public DataBaseProfile()
        {
            client = DataBaseClient.Source;
        }

        public async Task<bool> InsertProfile(Profile profile)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandAdd, client.OpenConnection()))
                {
                    cmd.Parameters.AddWithValue("@FirstName", profile.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", profile.SecondName);
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

        public async Task<List<Profile>> GetAllProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandGetAll, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var profile = new Profile(
                            dataReader.GetInt32(0),
                            dataReader.GetString(1), 
                            dataReader.GetString(2));
                        profiles.Add(profile);
                    }
                }
                client.CloseConnection();
                return profiles;
            }
            catch(Exception exception)
            {
                Debug.WriteLine("[DataBaseProfile.GetAllProfiles()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }
    }
}
