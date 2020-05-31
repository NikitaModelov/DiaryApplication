using DiaryApplication.Utills;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Tasks.Data.Model;
using DiaryApplication.Tasks.InfoTask.Domain;
using DiaryApplication.Utills.Command;

namespace DiaryApplication.Tasks.InfoTask.Presentation
{
    public class InfoTaskViewModel : BindableBase
    {
        private readonly GetTaskByIdUseCase getTaskByIdUseCase;
        private readonly AddIntervalUseCase addIntervalUseCase;
        private readonly UpdateTaskUseCase updateTaskUseCase;
        private readonly CloseTaskUseCase closeTaskUseCase;
        private readonly DeleteIntervalUseCase deleteIntervalUseCase;

        private ObservableCollection<Interval> intervals;
        public ObservableCollection<Interval> Intervals
        {
            get => intervals;
            set => Set(ref intervals, value);
        }

        private ObservableCollection<TypeEntity> types;
        public ObservableCollection<TypeEntity> Types
        {
            get => types;
            set => Set(ref types, value);
        }

        private TaskEntity _taskEntity;
        public TaskEntity TaskEntity
        {
            get => _taskEntity;
            set => Set(ref _taskEntity, value);
        }

        private double rating;
        public double Rating
        {
            get => rating;
            set => Set(ref rating, value);
        }

        private DateTimeOffset dateNow = DateTimeOffset.Now;
        public DateTimeOffset DateNow
        {
            get => dateNow;
            set => Set(ref dateNow, value);
        }

        private TimeSpan startTimeOffset;
        public TimeSpan StartTimeOffset
        {
            get => startTimeOffset;
            set
            {
                Set(ref startTimeOffset, value);
            }
        }

        private TimeSpan finishTimeOffset;
        public TimeSpan FinishTimeOffset
        {
            get => finishTimeOffset;
            set
            {
                Set(ref finishTimeOffset, value);
            }
        }

        private Interval selectedInterval;
        public Interval SelectedInterval
        {
            get => selectedInterval;
            set => Set(ref selectedInterval, value);
        }

        private TimeSpan allTime;
        public TimeSpan AllTime
        {
            get => allTime;
            set => Set(ref allTime, value);
        }

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

        private DiaryCommand addIntervalCommand;
        public DiaryCommand AddIntervalCommand =>
            addIntervalCommand ?? new DiaryCommand(() => AddInterval());

        private DiaryCommand deleteIntervalCommand;
        public DiaryCommand DeleteIntervalCommand =>
            deleteIntervalCommand ?? new DiaryCommand(() => DeleteInterval(selectedInterval));

        private DiaryCommand updateTaskCommand;
        public DiaryCommand UpdateTaskCommand => updateTaskCommand ??
                                                 new DiaryCommand(() => UpdateTask());

        private DiaryCommand closeTaskCommand;

        public DiaryCommand CloseTaskCommand => closeTaskCommand ??
                                                new DiaryCommand(() => CloseTask());

        public InfoTaskViewModel(
            int idTask,
            GetTaskByIdUseCase getTaskByIdUseCase, 
            AddIntervalUseCase addIntervalUseCase,
            DeleteIntervalUseCase deleteIntervalUseCase,
            UpdateTaskUseCase updateTaskUseCase,
            CloseTaskUseCase closeTaskUseCase)
        {
            this.updateTaskUseCase = updateTaskUseCase;
            this.closeTaskUseCase = closeTaskUseCase;
            this.getTaskByIdUseCase = getTaskByIdUseCase;
            this.addIntervalUseCase = addIntervalUseCase;
            this.deleteIntervalUseCase = deleteIntervalUseCase;
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
                    Intervals = new ObservableCollection<Interval>(TaskEntity.Intervals);
                    AllTime = Statistic.GetAllTime(TaskEntity.Intervals);
                    Rating = Statistic.GetAverageRating(TaskEntity.Intervals);

                    Title = TaskEntity.Title;
                    Subtitle = TaskEntity.Subtitle;
                    Description = TaskEntity.Description;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task AddInterval()
        {
            DateTime startTime = ParseOfOffset(DateNow, StartTimeOffset);
            DateTime finishTime = ParseOfOffset(DateNow, FinishTimeOffset);
            var response =
                await addIntervalUseCase.AddInterval(TaskEntity.Id, new Interval(startTime, finishTime, Rating));
            if (response is Success<bool> responseWrapper && responseWrapper.Data)
            {
                await GetTask(TaskEntity.Id);
            }
            else
            {
                // TODO: я Ошибка
            }
        }

        private async Task DeleteInterval(Interval interval)
        {
            var response =
                await deleteIntervalUseCase.DeleteInterval(interval.Id);
            if (response is Success<bool> responseWrapper && responseWrapper.Data)
            {
                await GetTask(TaskEntity.Id);
            }
            else
            {
                // TODO: я Ошибка
            }
        }

        private async Task UpdateTask()
        {
            if (Title.Length != 0 && Subtitle.Length != 0 && Description.Length != 0)
            {
                var response =
                    await updateTaskUseCase.Update(new TaskEntity(
                        id: TaskEntity.Id,
                        title: Title,
                        subtitle: Subtitle,
                        description: Description,
                        lastChangeTime: DateTime.Now,
                        isClosed: false,
                        types: TaskEntity.Types));
                if (response is Success<bool> responseWrapper && responseWrapper.Data)
                {
                    await GetTask(TaskEntity.Id);
                }
                else
                {
                    // TODO: я Ошибка
                }
            }
        }

        private async Task CloseTask()
        {
            var response =
                await closeTaskUseCase.CloseTask(TaskEntity.Id, true);
            if (response is Success<bool> responseWrapper && responseWrapper.Data)
            {
                // TODO: успех
            }
            else
            {
                // TODO: я Ошибка
            }
        }

        private DateTime ParseOfOffset(DateTimeOffset date, TimeSpan time)
        {
            var str = $"{date.Date.ToShortDateString().ToString()} {time.ToString()}";
            return DateTime.Parse(str);
        }
    }
}
