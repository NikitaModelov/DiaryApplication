using DiaryApplication.Utills;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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


        private DiaryCommand addIntervalCommand;

        public DiaryCommand AddIntervalCommand =>
            addIntervalCommand ?? new DiaryCommand(() => AddInterval());

        public InfoTaskViewModel(int idTask, GetTaskByIdUseCase getTaskByIdUseCase, AddIntervalUseCase addIntervalUseCase)
        {
            this.getTaskByIdUseCase = getTaskByIdUseCase;
            this.addIntervalUseCase = addIntervalUseCase;
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

        private DateTime ParseOfOffset(DateTimeOffset date, TimeSpan time)
        {
            var str = $"{date.Date.ToShortDateString().ToString()} {time.ToString()}";
            return DateTime.Parse(str);
        }
    }
}
