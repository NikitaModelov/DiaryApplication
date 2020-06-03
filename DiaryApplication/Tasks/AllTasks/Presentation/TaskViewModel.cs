using DiaryApplication.Utills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Tasks.Domain;

namespace DiaryApplication.Tasks.Presentation
{
    public class TaskViewModel : BindableBase
    {
        private GetTasksUseCase getTasksUseCase;

        private TaskEntity task;
        public TaskEntity TaskEntity
        {
            get => task;
            set
            {
                if (value != null)
                {
                    Set(ref task, value);
                }
            }
        }

        private ObservableCollection<TaskEntity> tasks;

        public ObservableCollection<TaskEntity> Tasks
        {
            get => tasks;
            set
            {
                Set(ref tasks, value);
            }
        }

        public TaskViewModel(GetTasksUseCase getTasksUseCase)
        {
            this.getTasksUseCase = getTasksUseCase;
            GetTasks();
        }

        private async Task GetTasks()
        {
            try
            {
                var response = await getTasksUseCase.Get(Session.IdProfile);
                if (response is Success<List<TaskEntity>> responseWrapper)
                {
                    Tasks = new ObservableCollection<TaskEntity>(responseWrapper.Data);
                }
                else
                {
                    var errorMessage = (response as Error).Message;
                    Debug.WriteLine("[TaskViewModel.GetTasks()] Error: " + errorMessage);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            
        }
    }
}
