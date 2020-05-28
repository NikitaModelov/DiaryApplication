using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Tasks.Domain
{
    public class GetTasksUseCase
    {
        private readonly ITasksRepository repository;

        public GetTasksUseCase()
        {
            repository = new TasksRepository();
        }

        public async Task<IResponseWrapper> Get(int idProfile)
        {
            return await Task.Run(() => repository.GetTasks(idProfile));
        }
    }
}