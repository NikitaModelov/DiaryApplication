using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.InfoTask.Data.Repository;
using DiaryApplication.Utills;

namespace DiaryApplication.Tasks.InfoTask.Domain
{
    public class AddIntervalUseCase
    {
        private readonly IInfoTaskRepository repository;

        public AddIntervalUseCase()
        {
            repository = new InfoTaskRepository();
        }

        public async Task<IResponseWrapper> AddInterval(int idTask, Interval interval)
        {
            return await Task.Run(() => repository.AddInterval(idTask, interval));
        }

    }
}
