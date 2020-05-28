using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Local;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Utills;

namespace DiaryApplication.Tasks.Data
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TasksLocalDataSource localDataSource;

        public TasksRepository()
        {
            localDataSource = new TasksLocalDataSource();
        }

        public async Task<IResponseWrapper> GetTasks(int idProfile)
        {
            try
            {
                var response = await localDataSource.GetTasks(idProfile);
                return new Success<List<TaskEntity>>(TaskMapper.ConvertFromListDto(response).ToList());
            }
            catch (Exception e)
            {
                Debug.WriteLine("[TasksRepository.GetTasks()] Error: " + e.Message);
                return new Error(e.Message);
            }
        }
    }
}
