﻿using System;
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
        Task<bool> AddInterval(int idTask, IntervalDTO interval);
        Task<bool> DeleteInterval(int idInterval);
        Task<bool> CloseTask(int idTask, bool isClosed);
    }
}
