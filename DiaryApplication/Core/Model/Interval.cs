using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Core.Model
{
    public class Interval
    {
        public int Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime FinishTime { get; private set; }
        public double Rating { get; private set; }

        public string StartDate
        {
            get => GetDate();
        }

        public Interval() { }

        public Interval(int id, DateTime startTime, DateTime finishTime, double rating)
        {
            Id = id;
            StartTime = startTime;
            FinishTime = finishTime;
            Rating = rating;
        }

        public Interval(DateTime startTime, DateTime finishTime, double rating)
        {
            StartTime = startTime;
            FinishTime = finishTime;
            Rating = rating;
        }

        public string GetDate()
        {
            return StartTime.ToShortDateString();
        }
    }
}
