using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.Tasks.InfoTask.Data.Local
{
    class InfoTaskLocalDataSource : IInfoTaskDataSource
    {
        private readonly IDataBaseTask<TaskEntityDTO, bool> dataBaseTask;
        private readonly IDatabaseInterval<IntervalDTO, bool> dataBaseInterval;

        public InfoTaskLocalDataSource()
        {
            dataBaseTask = new DatabaseTask();
            dataBaseInterval = new DatabaseInterval();
        }
        public async Task<TaskEntityDTO> GetTaskById(int idTask)
        {
            return await dataBaseTask.SelectById(idTask);
        }

        public async Task<bool> UpdateTask(TaskEntityDTO task)
        {
            return await dataBaseTask.Update(task);
        }

        public async Task<bool> AddInterval(int idTask, IntervalDTO interval)
        {
            return await dataBaseInterval.InsertInterval(idTask, interval);
        }

        public async Task<bool> DeleteInterval(int idInterval)
        {
            return await dataBaseInterval.Delete(idInterval);
        }

        public async Task<bool> CloseTask(int idTask, bool isClosed)
        {
            return await dataBaseTask.CloseTask(idTask, isClosed);
        }
    }
}
