using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;

namespace DiaryApplication.Core
{
    public static class Statistic
    {
        public static double GetAverageRating(List<Interval> intervals)
        {
            double result = 0;
            foreach (var interval in intervals)
            {
                result += interval.Rating;
            }

            return result / intervals.Count;
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
    }
}
