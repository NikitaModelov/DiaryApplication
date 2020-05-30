using DiaryApplication.Utills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Tasks.InfoTask.Domain;

namespace DiaryApplication.Tasks.InfoTask.Presentation
{
    public class InfoTaskViewModel : BindableBase
    {
        private readonly GetTaskByIdUseCase getTaskByIdUseCase;

        private ObservableCollection<TypeEntity> types;

        public ObservableCollection<TypeEntity> Types
        {
            get => types;
            set => Set(ref types, value);
        }

        private ObservableCollection<Interval> intervals;

        private TaskEntity _taskEntity;
        public TaskEntity TaskEntity
        {
            get => _taskEntity;
            set => Set(ref _taskEntity, value);
        }

        public InfoTaskViewModel(int idTask, GetTaskByIdUseCase getTaskByIdUseCase)
        {
            this.getTaskByIdUseCase = getTaskByIdUseCase;
            GetTask(idTask);
        }

        private async Task GetTask(int idTask)
        {
            try
            {
                var response = await getTaskByIdUseCase.Get(idTask);
                if (response is Success<TaskEntity> responseWrapper)
                {
                    TaskEntity = responseWrapper.Data;
                    Types = new ObservableCollection<TypeEntity>(TaskEntity.Types);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
