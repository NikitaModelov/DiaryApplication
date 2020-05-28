using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.Tasks.Data.Local
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
