using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Core
{
    public static class Statistic
    {
        public static double GetAverageRating(List<Interval> intervals)
        {
            double result = 0;
            foreach (var interval in intervals)
            {
                if (interval.Rating != 0)
                    result += interval.Rating;
            }

            if (result == 0)
            {
                return 0;
            }
            return Math.Round(result / intervals.Count, 2);
        }

        public static TimeSpan GetAllTime(List<Interval> intervals)
        {
            TimeSpan time = TimeSpan.Zero;
            foreach (var interval in intervals)
            {
                time = time.Add(interval.FinishTime.Subtract(interval.StartTime));
            }

            return time;
        }

        public static TimeSpan GetAverageTime(List<Interval> intervals)
        {
            TimeSpan allTime = GetAllTime(intervals);
            return new TimeSpan(allTime.Ticks / intervals.Count);
        }

        public static double GetAllAverageRating(List<TaskEntity> tasks)
        {
            List<double> avgRatings = new List<double>();
            foreach (var task in tasks)
            {
                avgRatings.Add(GetAverageRating(task.Intervals));
            }

            double result = avgRatings[0] / avgRatings.Count;
            for(int i = 1; i < avgRatings.Count; i++)
            {
                result += avgRatings[i] / avgRatings.Count;
            }

            return Math.Round(result, 2);
        }

        public static TimeSpan GetAllTimeByTasks(List<TaskEntity> tasks)
        {
            TimeSpan result = TimeSpan.Zero;
            foreach (var task in tasks)
            {
                result = result.Add(GetAllTime(task.Intervals));
            }

            return result;
        }

        public static TimeSpan GetAllAverageTime(List<TaskEntity> tasks)
        {
            TimeSpan allTime = GetAllTimeByTasks(tasks);
            return new TimeSpan(allTime.Ticks / tasks.Count);
        }
    }
}
