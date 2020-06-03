using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLib;
using DataBaseLib.Database;

namespace DiaryApplication.Tasks.AllTasks.Data.Local
{
    public class TasksLocalDataSource
    {
        private readonly IDataBaseTask<TaskEntityDTO, bool> database;

        public TasksLocalDataSource()
        {
            database = new DatabaseTask();
        }

        public async Task<List<TaskEntityDTO>> GetTasks(int idProfile)
        {
            return await database.GetTaskByProfile(idProfile);
        }
    }
}
