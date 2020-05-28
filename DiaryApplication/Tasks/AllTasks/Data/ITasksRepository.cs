using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Tasks.Data
{
    public interface ITasksRepository
    {
        Task<IResponseWrapper> GetTasks(int idProfile);
    }
}
