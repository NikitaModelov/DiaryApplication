using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.InfoTask.Data.Repository;

namespace DiaryApplication.Tasks.InfoTask.Domain
{
    public class GetTaskByIdUseCase
    {
        private readonly IInfoTaskRepository repository;

        public GetTaskByIdUseCase()
        {
            repository = new InfoTaskRepository();
        }

        public async Task<IResponseWrapper> Get(int idTask)
        {
            return await Task.Run(() => repository.GetTaskById(idTask));
        }
    }
}
