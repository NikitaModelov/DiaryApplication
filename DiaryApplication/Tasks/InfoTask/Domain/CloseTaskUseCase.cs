using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.InfoTask.Data.Repository;

namespace DiaryApplication.Tasks.InfoTask.Domain
{
    public class CloseTaskUseCase
    {
        private readonly IInfoTaskRepository repository;

        public CloseTaskUseCase()
        {
            repository = new InfoTaskRepository();
        }

        public async Task<IResponseWrapper> CloseTask(int idTask, bool isClose)
        {
            return await Task.Run(() => repository.CloseTask(idTask, isClose));
        }
    }
}
