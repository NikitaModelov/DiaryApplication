using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.Tasks.InfoTask.Data
{
    interface IInfoTaskDataSource
    {
        Task<TaskEntityDTO> GetTaskById(int idTask);
        Task<bool> UpdateTask(TaskEntityDTO task);
        
    }
}
