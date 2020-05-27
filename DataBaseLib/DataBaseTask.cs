using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.DataBase;

namespace DataBaseLib
{
    public class DataBaseTask : IDatabase<TaskEntityDTO, bool>
    {
        private readonly DataBaseClient client;
        public DataBaseTask()
        {
            client = DataBaseClient.Source;
        }
        public async Task<List<TaskEntityDTO>> SelectAll()
        {
            string commandSelect = "SELECT * FROM Task";
            var tasks = new List<TaskEntityDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandSelect, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var task = new TaskEntityDTO(
                            id: dataReader.GetInt32(0),
                            title: dataReader.GetString(1),
                            subtitle: dataReader.GetString(2),
                            description: dataReader.GetString(3),
                            addTime: dataReader.GetDateTime(4),
                            lastChangeTime: dataReader.GetDateTime(5),
                            isClosed: dataReader.GetByte(6) ==  1,
                            types: GetTypesTask(dataReader.GetInt32(0)));
                        tasks.Add(task);
                    }
                }
                client.CloseConnection();
                return tasks;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseTask.SelectAll()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<TaskEntityDTO> SelectById(int id)
        {
            string commandSelect = $"SELECT * FROM Task WHERE ID = {id}";
            var task = new TaskEntityDTO();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandSelect, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        task = new TaskEntityDTO(
                            id: dataReader.GetInt32(0),
                            title: dataReader.GetString(1),
                            subtitle: dataReader.GetString(2),
                            description: dataReader.GetString(3),
                            addTime: dataReader.GetDateTime(4),
                            lastChangeTime: dataReader.GetDateTime(5),
                            isClosed: dataReader.GetByte(6) == 1,
                            types: GetTypesTask(dataReader.GetInt32(0)));
                    }
                }
                client.CloseConnection();
                return task;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseTask.SelectById()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<bool> Update(int id, TaskEntityDTO newObject)
        {
            string updateCommand = "UPDATE Task " +
                                   $"SET Title = '{newObject.Title}', " +
                                   $"Subtitle = '{newObject.Subtitle}', " +
                                   $"[Description] = '{newObject.Description}', " +
                                   $"LastChangeTime = '{newObject.LastChangeTime}', " +
                                   $"IsClosed = {newObject.IsClosed} " +
                                   $"FROM(SELECT * FROM Task WHERE ID = {id}) AS Selected WHERE Task.ID = Selected.ID";

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

        public async Task<bool> Delete(int id)
        {
            string commandDelete = $"DELETE Type_Task WHERE IDTask = {id}; DELETE Task WHERE Task.ID = {id}";
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandDelete, client.OpenConnection()))
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

        public Task<bool> Create(TaskEntityDTO newObject)
        {
            throw new NotImplementedException();
        }

        public Task<List<TypeDTO>> GetAllType()
        {
            throw new NotImplementedException();
        }

        private List<TypeDTO> GetTypesTask(int id)
        {
            string commanGetTypesTask = "SELECT [Type].Title FROM [Type], Task, Type_Task " +
                                        $"WHERE[Type].ID = Type_Task.IDType AND Task.ID = Type_Task.IDTask AND Task.ID = {id}";
            var types = new List<TypeDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commanGetTypesTask, client.OpenConnection()))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
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
                Debug.WriteLine("[DataBaseTask.SelectAll()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }

        }
    }
}
