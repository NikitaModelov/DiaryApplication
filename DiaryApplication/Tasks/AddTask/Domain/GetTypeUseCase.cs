using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.AddTask.Data;

namespace DiaryApplication.Tasks.AddTask.Domain
{
    public class GetTypeUseCase
    {
        private readonly IAddTaskRepository repository;

        public GetTypeUseCase()
        {
            repository = new AddTaskRepository();
        }

        public async Task<IResponseWrapper> Get()
        {
            return await Task.Run(() => repository.GetTypes());
        }
    }
}
