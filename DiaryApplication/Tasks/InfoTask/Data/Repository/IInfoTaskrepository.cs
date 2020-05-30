using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Tasks.InfoTask.Data.Repository
{
    public interface IInfoTaskRepository
    {
        Task<IResponseWrapper> GetTaskById(int idTask);
        Task<IResponseWrapper> UpdateTask(TaskEntity task);
    }
}
