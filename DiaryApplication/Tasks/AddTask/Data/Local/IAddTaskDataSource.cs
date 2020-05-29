using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.Tasks.AddTask.Data.Local
{
    public interface IAddTaskDataSource
    {
        Task<bool> AddTask(int idProfile, TaskEntityDTO task);
        Task<List<TypeDTO>> GetTypes();
    }
}
