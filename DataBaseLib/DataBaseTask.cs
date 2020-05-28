using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class DatabaseTask : IDataBaseTask<TaskEntityDTO, bool>
    {
        private readonly DatabaseConnection client;
        public DatabaseTask()
        {
            client = DatabaseConnection.Source;
        }

        public async Task<List<TaskEntityDTO>> SelectAll(string command = "SELECT * FROM Task")
        {
            var tasks = new List<TaskEntityDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
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
                            types: GetTypesTask(dataReader.GetInt32(0)), 
                            intervals: GetIntervalsTask(dataReader.GetInt32(0)));
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

        public async Task<TaskEntityDTO> SelectById(int idTask)
        {
            string commandSelect = $"SELECT * FROM Task WHERE ID = {idTask}";
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
                            types: GetTypesTask(dataReader.GetInt32(0)),
                            intervals: GetIntervalsTask(dataReader.GetInt32(0)));
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

        public async Task<List<TaskEntityDTO>> GetTaskByProfile(int id)
        {

            string commandGetTaskByProfile = "SELECT Task.ID, Task.Title, Task.Subtitle, Task.[Description], Task.AddTime, Task.LastChangeTime, Task.IsClosed " +
                                             "FROM [Profile_Task], Task " +
                                             $"WHERE Profile_Task.IDProfile = {id} AND Profile_Task.IDTask = Task.ID ";
            return await SelectAll(commandGetTaskByProfile);
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

        public async Task<bool> Create(int idProfile, TaskEntityDTO newObject)
        {
            string commandCreateTask = "INSERT Task VALUES" +
                                       $"('{newObject.Title}', " +
                                       $"'{newObject.Subtitle}', " +
                                       $"'{newObject.Description}', " +
                                       $"'{newObject.AddTime}', '{newObject.LastChangeTime}', " +
                                       $"'{newObject.IsClosed}')";
            string commandGetLastAddIndex = "SELECT IDENT_CURRENT('Task') AS [IDENT_CURRENT]";

            int? lastIndex = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(commandCreateTask, client.OpenConnection()))
                {
                    cmd.ExecuteNonQuery();
                }
                client.CloseConnection();
                using (SqlCommand cmd = new SqlCommand(commandGetLastAddIndex, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    lastIndex = dataReader.GetInt32(0);
                }
                client.CloseConnection();
                var insertTypeTask = InsertTypeTask(lastIndex, newObject.Types);
                var insertProfileTask = InsertProfileTask(idProfile);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
                client.CloseConnection();
                return false;
            }
        }

        // TODO: Получить все типы
        public Task<List<TypeDTO>> GetAllType()
        {
            throw new NotImplementedException();
        }

        private async Task<List<TypeDTO>> GetTypesTask(int id)
        {
            string commandGetTypesTask = "SELECT [Type].Title FROM [Type], Task, Type_Task " +
                                        $"WHERE[Type].ID = Type_Task.IDType AND Task.ID = Type_Task.IDTask AND Task.ID = {id}";
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
                Debug.WriteLine("[DataBaseTask.SelectAll()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        private async Task<List<IntervalDTO>> GetIntervalsTask(int id)
        {
            string commandGetIntervalsTask = "SELECT [Task_Interval].StartTime, [Task_Interval].FinishTime, [Task_Interval].Rating FROM Task_Interval " +
                                        $"WHERE [Task_Interval].IDTask = {id}";
            var intervals = new List<IntervalDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandGetIntervalsTask, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var type = new IntervalDTO(dataReader.GetDateTime(0), dataReader.GetDateTime(1), dataReader.GetDouble(2));
                        intervals.Add(type);
                    }
                }
                client.CloseConnection();
                return intervals;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DataBaseTask.GetIntervalsTask()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        private async Task<bool> InsertTypeTask(int? lastIndexTask, List<TypeDTO> types)
        {
            string commandInsertTypeTask = $"INSERT Type_Task (IDTask, IDType) VALUES (@IDTask, @IDType)";
           
            try
            {
                if (lastIndexTask != null)
                {
                    using (SqlCommand cmd = new SqlCommand(commandInsertTypeTask, client.OpenConnection()))
                    {
                        foreach (var type in types)
                        {
                            cmd.Parameters.AddWithValue("@IDTask", lastIndexTask);
                            cmd.Parameters.AddWithValue("@IDType", type.Id);
                            var row = await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    client.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
                client.CloseConnection();
                return false;
            }
        }

        private async Task<bool> InsertProfileTask(int idProfile)
        {
            string commandInsertProfileTask = $"INSERT Profile_Task VALUES ( 1, {idProfile} )";

            try
            {
                using (SqlCommand cmd = new SqlCommand(commandInsertProfileTask, client.OpenConnection()))
                {
                    cmd.ExecuteNonQuery();
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
