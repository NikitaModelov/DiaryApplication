using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class DatabaseType : IDatabaseType<TypeDTO, bool>
    {
        private readonly DatabaseConnection client;
        public DatabaseType()
        {
            client = DatabaseConnection.Source;
        }

        public async Task<List<TypeDTO>> SelectAll()
        {
            var command = "SELECT * FROM [Type]";

            var types = new List<TypeDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var type = new TypeDTO(dataReader.GetInt32(0), dataReader.GetString(1));
                        types.Add(type);
                    }
                }
                client.CloseConnection();
                return types;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DatabaseType.SelectAll()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<TypeDTO> SelectById(int idObject)
        {
            string commandSelectById = $"SELECT * FROM [Type] WHERE [Type].ID = {idObject}"; 
            var type = new TypeDTO();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandSelectById, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        type = new TypeDTO(dataReader.GetInt32(0), dataReader.GetString(1));
                    }
                }
                client.CloseConnection();
                return type;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DatabaseType.SelectById()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<bool> Update(TypeDTO newObject)
        {
            string updateCommand =
                $"UPDATE [Type] SET Title='{newObject.Title}' " +
                $"FROM (SELECT * FROM [Type] WHERE ID = {newObject.Id}) AS Selected WHERE [Type].ID = Selected.ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(updateCommand, client.OpenConnection()))
                {
                    await cmd.ExecuteNonQueryAsync();
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

        public async Task<bool> Delete(int id)
        {
            string commandDelete = $"DELETE Type_Task WHERE IDType = {id}; DELETE [Type] WHERE ID = {id}";
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandDelete, client.OpenConnection()))
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

        public async Task<List<TypeDTO>> GetTypesTask(int idTask)
        {
            client.CloseConnection();
            string commandGetTypesTask = "SELECT [Type].ID, [Type].Title FROM [Type], Task, Type_Task " +
                                         $"WHERE[Type].ID = Type_Task.IDType AND Task.ID = Type_Task.IDTask AND Task.ID = {idTask}";
            var types = new List<TypeDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandGetTypesTask, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var type = new TypeDTO(dataReader.GetInt32(0), dataReader.GetString(1));
                        types.Add(type);
                    }
                }
                client.CloseConnection();
                return types;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DatabaseType.GetTypesTask()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }
    }
}
