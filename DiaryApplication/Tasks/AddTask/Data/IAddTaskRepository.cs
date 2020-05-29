using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Tasks.AddTask.Data
{
    public interface IAddTaskRepository
    {
        Task<IResponseWrapper> AddTask(int idProfile, TaskEntity task);
        Task<IResponseWrapper> GetTypes();
    }
}
