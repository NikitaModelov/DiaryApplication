using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Tasks.InfoTask.Data.Local;
using DiaryApplication.Utills;

namespace DiaryApplication.Tasks.InfoTask.Data.Repository
{
    public class InfoTaskRepository : IInfoTaskRepository
    {
        private readonly IInfoTaskDataSource localDataSource;

        public InfoTaskRepository()
        {
            localDataSource = new InfoTaskLocalDataSource();
        }

        public async Task<IResponseWrapper> GetTaskById(int idTask)
        {
            try
            {
                var response = await localDataSource.GetTaskById(idTask);
                return new Success<TaskEntity>(TaskMapper.ConvertFromDto(response));
            }
            catch (Exception e)
            {
                return new Error(e.Message);
            }
        }

        public async Task<IResponseWrapper> UpdateTask(TaskEntity task)
        {
            try
            {
                var response = await localDataSource.UpdateTask(TaskMapper.ConvertToDto(task));
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                return new Error(e.Message);
            }
        }

        public async Task<IResponseWrapper> AddInterval(int idTask, Interval interval)
        {
            try
            {
                var response = await localDataSource.AddInterval(idTask, IntervalMapper.ConvertToDto(interval));
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                return new Error(e.Message);

            }
        }

        public async Task<IResponseWrapper> DeleteInterval(int idInterval)
        {
            try
            {
                var response = await localDataSource.DeleteInterval(idInterval);
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                return new Error(e.Message);

            }
        }

        public async Task<IResponseWrapper> CloseTask(int idTask, bool isClosed)
        {
            try
            {
                var response = await localDataSource.CloseTask(idTask, isClosed);
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                return new Error(e.Message);

            }
        }
    }
}
