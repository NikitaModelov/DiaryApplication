using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using DataBaseLib;
using DataBaseLib.Database;

namespace GenerateDatebaseApp
{
    public class GenerateIntervals
    {
        private readonly IDatabaseInterval<IntervalDTO, bool> databaseInterval;
        private readonly IDataBaseTask<TaskEntityDTO, bool> dataBaseTask;

        private Random random = new Random();

        public GenerateIntervals()
        {
            databaseInterval = new DatabaseInterval();
            dataBaseTask = new DatabaseTask();
            Generate();
        }

        private async Task<bool> Generate()
        {
            var tasks = await dataBaseTask.SelectAll();
            var dateTimeFrom = DateTime.Now;

            for (int i = 0; i < tasks.Count; i++)
            {
                Debug.WriteLine($"Задача {i}: ");
                var dateTimeTo = dateTimeFrom.AddHours(3);
                var randomCountIntervals = random.Next(1, 10);

                for (int j = 0; j < randomCountIntervals; j++)
                {
                    var interval = new IntervalDTO(
                        startTime: GenRandomDateTime(dateTimeFrom, dateTimeTo),
                        finishTime: GenRandomDateTime(dateTimeFrom.AddHours(3), dateTimeTo.AddHours(3)),
                        rating: Math.Round(random.NextDouble() * 4 + 1, 2));

                    if (await databaseInterval.InsertInterval(tasks[i].Id, interval))
                    {
                        Debug.WriteLine($"{interval} - Insert is Success");
                    }
                    else
                    {
                        throw new Exception($"{interval} - Insert is Error");
                    }

                    Debug.WriteLine($"{j}. " + interval);

                    dateTimeFrom = dateTimeFrom.AddDays(2);
                    dateTimeTo = dateTimeFrom.AddHours(3);
                }
            }

            return true;
        }


        private DateTime GenRandomDateTime(DateTime from, DateTime to)
        {
            if (from >= to)
            {
                throw new Exception("Параметр \"from\" должен быть меньше параметра \"to\"!");
            }
            if (random == null)
            {
                random = new Random();
            }
            TimeSpan range = to - from;
            var randTs = new TimeSpan((long)(random.NextDouble() * range.Ticks));
            return from + randTs;
        }
    }
}
