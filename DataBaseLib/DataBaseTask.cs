using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<List<TaskEntityDTO>> SelectAll()
        {
            var command = "SELECT * FROM Task";
            var tasks = new List<TaskEntityDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        var title = dataReader.GetString(1);
                        var subtitle = dataReader.GetString(2);
                        var description = dataReader.GetString(3);
                        var addTime = dataReader.GetDateTime(4);
                        var lastChangeTime = dataReader.GetDateTime(5);
                        var isClosed = dataReader.GetBoolean(6);

                        var task = new TaskEntityDTO(id, title, subtitle, description, addTime, lastChangeTime, isClosed, null, null);
                        tasks.Add(task);
                    }
                }
                
                foreach (var task in tasks)
                {
                    task.SetTypes(await GetTypesTask(task.Id));
                    task.SetIntervals(await GetIntervalsTask(task.Id));
                }
                client.CloseConnection();
                return tasks;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DatabaseTask.SelectAll()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<TaskEntityDTO> SelectById(int idObject)
        {
            string commandSelect = $"SELECT * FROM Task WHERE ID = {idObject}";
            var task = new TaskEntityDTO();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandSelect, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        var title = dataReader.GetString(1);
                        var subtitle = dataReader.GetString(2);
                        var description = dataReader.GetString(3);
                        var addTime = dataReader.GetDateTime(4);
                        var lastChangeTime = dataReader.GetDateTime(5);
                        var isClosed = dataReader.GetBoolean(6);

                        task = new TaskEntityDTO(id, title, subtitle, description, addTime, lastChangeTime, isClosed, null, null);
                    }
                }
                task.SetTypes(await GetTypesTask(task.Id));
                task.SetIntervals(await GetIntervalsTask(task.Id));
                client.CloseConnection();
                return task;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DatabaseTask.SelectById()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<List<TaskEntityDTO>> GetTaskByProfile(int idProfile)
        {
            client.CloseConnection();
            string command = "SELECT Task.ID, Task.Title, Task.Subtitle, Task.[Description], Task.AddTime, Task.LastChangeTime, Task.IsClosed " +
                                             "FROM [Profile_Task], Task " +
                                             $"WHERE Profile_Task.IDProfile = {idProfile} AND Profile_Task.IDTask = Task.ID ";

            var tasks = new List<TaskEntityDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        var title = dataReader.GetString(1);
                        var subtitle = dataReader.GetString(2);
                        var description = dataReader.GetString(3);
                        var addTime = dataReader.GetDateTime(4);
                        var lastChangeTime = dataReader.GetDateTime(5);
                        var isClosed = dataReader.GetBoolean(6);

                        var task = new TaskEntityDTO(id, title, subtitle, description, addTime, lastChangeTime, isClosed, null, null);
                        tasks.Add(task);
                    }
                }

                foreach (var task in tasks)
                {
                    task.SetTypes(await GetTypesTask(task.Id));
                    task.SetIntervals(await GetIntervalsTask(task.Id));
                }
                client.CloseConnection();
                return tasks;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DatabaseTask.SelectAll()] Error: " + exception.Message);
                client.CloseConnection();
                return null;
            }
        }

        public async Task<bool> Update(TaskEntityDTO newObject)
        {
            string updateCommand = "UPDATE Task " +
                                   $"SET Title = '{newObject.Title}', " +
                                   $"Subtitle = '{newObject.Subtitle}', " +
                                   $"[Description] = '{newObject.Description}', " +
                                   $"LastChangeTime = '{newObject.LastChangeTime}', " +
                                   $"IsClosed = {newObject.IsClosed} " +
                                   $"FROM(SELECT * FROM Task WHERE ID = {newObject.Id}) AS Selected WHERE Task.ID = Selected.ID";

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
                Debug.WriteLine("[DatabaseTask.Update()] Error: " + exception.Message);
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
                    var row = await cmd.ExecuteNonQueryAsync();
                }
                client.CloseConnection();
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("[DatabaseTask.Delete()] Error: " + exception.Message);
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

            decimal? lastIndex = null;

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
                    while (dataReader.Read())
                    {
                        lastIndex = dataReader.GetDecimal(0);
                    }
                }
                client.CloseConnection();
                var insertTypeTask = InsertTypeTask((int?)lastIndex, newObject.Types);
                var insertProfileTask = InsertProfileTask(idProfile, (int?)lastIndex);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
                client.CloseConnection();
                return false;
            }
        }

        private async Task<List<TypeDTO>> GetTypesTask(int taskId)
        {
            var databaseType = new DatabaseType();
            return await databaseType.GetTypesTask(taskId);
        }

        private async Task<List<IntervalDTO>> GetIntervalsTask(int id)
        {
            client.CloseConnection();
            string commandGetIntervalsTask = "SELECT [Task_Interval].ID, [Task_Interval].StartTime, [Task_Interval].FinishTime, [Task_Interval].Rating FROM Task_Interval " +
                                             $"WHERE [Task_Interval].IDTask = {id}";
            var intervals = new List<IntervalDTO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandGetIntervalsTask, client.OpenConnection()))
                {
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        var type = new IntervalDTO(dataReader.GetInt32(0), dataReader.GetDateTime(1), dataReader.GetDateTime(2), dataReader.GetDouble(3));
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
            try
            {
                if (lastIndexTask != null)
                {
                    foreach (var type in types)
                    {
                        string commandInsertTypeTask = $"INSERT Type_Task VALUES ({lastIndexTask}, {type.Id})";
                        using (SqlCommand cmd = new SqlCommand(commandInsertTypeTask, client.OpenConnection()))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        client.CloseConnection();
                    }
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

        private async Task<bool> InsertProfileTask(int idProfile, int? idTask)
        {
            client.CloseConnection();
            string commandInsertProfileTask = $"INSERT Profile_Task VALUES ( {idProfile}, {idTask} )";

            try
            {
                using (SqlCommand cmd = new SqlCommand(commandInsertProfileTask, client.OpenConnection()))
                {
                    var row = await cmd.ExecuteNonQueryAsync();
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
