using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.AddTask.Data.Local;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Utills;

namespace DiaryApplication.Tasks.AddTask.Data
{
    public class AddTaskRepository : IAddTaskRepository
    {
        private readonly IAddTaskDataSource localDataSource;

        public AddTaskRepository()
        {
            localDataSource = new AddTaskLocalDataSource();
        }

        public async Task<IResponseWrapper> AddTask(int idProfile, TaskEntity task)
        {
            try
            {
                var response = await localDataSource.AddTask(idProfile, TaskMapper.ConvertToDto(task));
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                return new Error(e.Message);
            }
            
        }

        public async Task<IResponseWrapper> GetTypes()
        {
            try
            {
                var response = await localDataSource.GetTypes();
                return new Success<List<TypeEntity>>(TypeMapper.ConvertFromListDto(response).ToList());
            }
            catch (Exception e)
            {
                return new Error(e.Message);
            }
        }
    }
}
