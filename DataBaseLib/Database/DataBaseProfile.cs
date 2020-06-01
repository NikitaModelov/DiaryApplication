﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class DatabaseProfile : IDataBaseProfile<ProfileDTO, bool>
    {
        private readonly DatabaseConnection client;

        public DatabaseProfile()
        {
            client = DatabaseConnection.Source;
        }

        public async Task<List<ProfileDTO>> SelectAll()
        {
            var command = "SELECT * FROM Profile";
            List<ProfileDTO> profiles = new List<ProfileDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var profile = new ProfileDTO(
                            id: dataReader.GetInt32(0),
                            firstName: dataReader.GetString(1),
                            secondName: dataReader.GetString(2));
                        profiles.Add(profile);
                    }
                }
                client.CloseConnection();
                return profiles;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseProfile.SelectAll()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<ProfileDTO> SelectById(int idObject)
        {
            string commandSelectById = $"SELECT * FROM Profile WHERE ID = {idObject}";
            ProfileDTO profile = new ProfileDTO();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandSelectById, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        var firstName = dataReader.GetString(1);
                        var secondName = dataReader.GetString(2);

                        profile = new ProfileDTO(id, firstName, secondName, null);
                    }

                    profile.SetTasks(await GetTasks(profile.Id));

                }
                client.CloseConnection();
                return profile;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseProfile.SelectById()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<bool> Update(ProfileDTO newObject)
        {
            string updateCommand =
                $"UPDATE Profile SET FirstName='{newObject.FirstName}', SecondName='{newObject.SecondName}' " +
                $"FROM (SELECT * FROM Profile WHERE ID = {newObject.Id}) AS Selected WHERE Profile.ID = Selected.ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(updateCommand, client.OpenConnection()))
                {
                    var row = await cmd.ExecuteNonQueryAsync();
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

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(ProfileDTO newObject)
        {
            string commandCreate = "INSERT INTO Profile" +
                                       "(FirstName, SecondName) VALUES(@FirstName, @SecondName)";
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

        private async Task<List<TaskEntityDTO>> GetTasks(int id)
        {
            var clientTask = new DatabaseTask();
            return await clientTask.GetTaskByProfile(id);
        }
    }
}