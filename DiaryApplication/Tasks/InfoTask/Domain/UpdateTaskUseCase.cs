﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Tasks.InfoTask.Data.Repository;

namespace DiaryApplication.Tasks.InfoTask.Domain
{
    public class UpdateTaskUseCase
    {
        private readonly IInfoTaskRepository repository;

        public UpdateTaskUseCase()
        {
            repository = new InfoTaskRepository();
        }

        public async Task<IResponseWrapper> Update(TaskEntity task)
        {
            return await Task.Run(() => repository.UpdateTask(task));
        }
    }
}
