using System;
using DiaryApplication.Utills;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.AddTask.Domain;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Utills.Command;

namespace DiaryApplication.Tasks.AddTask.Presentation
{
    public class AddTaskViewModel : BindableBase
    {
        private readonly SendTaskUseCase sendTaskUseCase;
        private readonly GetTypeUseCase getTypeUseCase;

        private string title;
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        private string subtitle;
        public string Subtitle
        {
            get => subtitle;
            set => Set(ref subtitle, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => Set(ref description, value);
        }

        private ObservableCollection<TypeEntity> types;
        public ObservableCollection<TypeEntity> Types
        {
            get => types;
            set => Set(ref types, value);
        }

        private bool showErrorTypes;

        public bool ShowErrorTypes
        {
            get => showErrorTypes;
            set => Set(ref showErrorTypes, value);
        }

        private ObservableCollection<TypeEntity> selectedTypes;

        private DiaryCommand createTaskCommand;
        public DiaryCommand CreateTaskCommand => createTaskCommand ?? (createTaskCommand =
                                                      new DiaryCommand(() => CreateTask()));

        public AddTaskViewModel(SendTaskUseCase sendTaskUseCase, GetTypeUseCase getTypeUseCase)
        {
            this.sendTaskUseCase = sendTaskUseCase;
            this.getTypeUseCase = getTypeUseCase;
            GetTaskType();
        }

        private async Task GetTaskType()
        {
            var response = await getTypeUseCase.Get();
            if (response is Success<List<TypeEntity>> responseWrapper)
            {
                showErrorTypes = false;
                Types = new ObservableCollection<TypeEntity>(responseWrapper.Data);
            }
            else
            {
                showErrorTypes = true;
            }
        }

        public void SetSelectedTypes(IList<object> list)
        {
            selectedTypes = new ObservableCollection<TypeEntity>(list.Select(obj => (TypeEntity)obj));
        }

        private async Task CreateTask()
        {
            try
            {
                if (Title.Length != 0 && Subtitle.Length != 0 && Description.Length != 0 && selectedTypes.Count > 0)
                {
                    var response = await sendTaskUseCase.Send(
                        Session.IdProfile,
                        new TaskEntity(
                            title: Title,
                            subtitle: Subtitle,
                            description: Description,
                            addTime: DateTime.Now,
                            lastChangeTime: DateTime.Now,
                            isClosed: false,
                            types: selectedTypes.ToList(),
                            intervals: null));
                    if (response is Success<bool> responseWrapper && responseWrapper.Data)
                    {
                        Title = "";
                        Subtitle = "";
                        Description = "";
                    }
                    else
                    {
                        // TODO: Всё не круто
                    }
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
