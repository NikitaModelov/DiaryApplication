using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.InfoTask.Data.Repository;

namespace DiaryApplication.Tasks.InfoTask.Domain
{
    public class DeleteIntervalUseCase
    {
        private readonly IInfoTaskRepository repository;

        public DeleteIntervalUseCase()
        {
            repository = new InfoTaskRepository();
        }

        public async Task<IResponseWrapper> DeleteInterval(int id)
        {
            return await Task.Run(() => repository.DeleteInterval(id));
        }
    }
}
