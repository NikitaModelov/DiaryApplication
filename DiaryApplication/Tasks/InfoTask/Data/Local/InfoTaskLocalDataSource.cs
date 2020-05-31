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

        public Task<bool> UpdateTask(TaskEntityDTO task)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddInterval(int idTask, IntervalDTO interval)
        {
            return await dataBaseInterval.InsertInterval(idTask, interval);
        }
    }
}
