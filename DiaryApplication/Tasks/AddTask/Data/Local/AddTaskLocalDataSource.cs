using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLib;
using DataBaseLib.Database;


namespace DiaryApplication.Tasks.AddTask.Data.Local
{
    public class AddTaskLocalDataSource : IAddTaskDataSource
    {
        private readonly IDataBaseTask<TaskEntityDTO, bool> dataBaseTask;
        private readonly IDatabaseType<TypeDTO, bool> databaseType;

        public AddTaskLocalDataSource()
        {
            dataBaseTask = new DatabaseTask();
            databaseType = new DatabaseType();
        }
        public async Task<bool> AddTask(int idProfile, TaskEntityDTO task)
        {
            return await dataBaseTask.Create(idProfile, task);
        }

        public async Task<List<TypeDTO>> GetTypes()
        {
            return await databaseType.SelectAll();
        }
    }
}
