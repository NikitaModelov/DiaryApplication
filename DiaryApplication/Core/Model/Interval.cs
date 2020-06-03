using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Core.Model
{
    public class Interval
    {
        public int Id { get; }
        public DateTime StartTime { get; }
        public DateTime FinishTime { get; }
        public double Rating { get; }

        public string StartDate
        {
            get => GetDate();
        }

        public Interval() { }

        public Interval(DateTime startTime, DateTime finishTime, double rating)
        {
            if (rating > 0)
            {
                Rating = rating;
            }
            else
            {
                throw new Exception("Недопустимый параметр rating");
            }
            StartTime = startTime;
            FinishTime = finishTime;
            
        }

        public Interval(int id, DateTime startTime, DateTime finishTime, double rating) : this(startTime, finishTime, rating)
        {
            if (id >= 0)
            {
                Id = id;
            }
            else
            {
                throw new Exception("Недопустимый параметр id");
            }
        }

        public string GetDate()
        {
            return StartTime.ToShortDateString();
        }
    }
}
