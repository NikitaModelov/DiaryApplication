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
        private readonly IDataBaseTask<TaskEntityDTO, bool> dataBase;

        public InfoTaskLocalDataSource()
        {
            dataBase = new DatabaseTask();
        }
        public async Task<TaskEntityDTO> GetTaskById(int idTask)
        {
            return await dataBase.SelectById(idTask);
        }

        public Task<bool> UpdateTask(TaskEntityDTO task)
        {
            throw new NotImplementedException();
        }
    }
}
