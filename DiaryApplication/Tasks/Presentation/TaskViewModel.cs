using DiaryApplication.Utills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Tasks.Presentation
{
    public class TaskViewModel : BindableBase
    {
        private TaskEntity task;
        public TaskEntity Task
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

        public TaskViewModel()
        {
            tasks = new ObservableCollection<TaskEntity>()
            {
                new TaskEntity(1, "Title", "Subtitle", "Description", new DateTime(2020,5,27,21,7,45), new DateTime(2020,5,27,21,7,45), false),
                new TaskEntity(2, "Title", "Subtitle", "Description", new DateTime(2020,5,27,21,7,45), new DateTime(2020,5,27,21,7,45), false),
                new TaskEntity(3, "Title", "Subtitle", "Description", new DateTime(2020,5,27,21,7,45), new DateTime(2020,5,27,21,7,45), false),
                new TaskEntity(4, "Title", "Subtitle", "Description", new DateTime(2020,5,27,21,7,45), new DateTime(2020,5,27,21,7,45), false),
                new TaskEntity(5, "Title", "Subtitle", "Description", new DateTime(2020,5,27,21,7,45), new DateTime(2020,5,27,21,7,45), false),
            };
        }
    }
}
