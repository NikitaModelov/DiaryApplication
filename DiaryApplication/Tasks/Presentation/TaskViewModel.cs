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

        }
    }
}
