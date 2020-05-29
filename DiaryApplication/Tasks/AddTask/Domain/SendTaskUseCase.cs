using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.AddTask.Data;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Tasks.AddTask.Domain
{
    public class SendTaskUseCase
    {
        private readonly IAddTaskRepository repository;

        public SendTaskUseCase()
        {
            repository = new AddTaskRepository();
        }

        public async Task<IResponseWrapper> Send(int idProfile, TaskEntity task)
        {
            return await Task.Run(() => repository.AddTask(idProfile, task));
        }
    }
}
