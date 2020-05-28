using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class IntervalDTO
    {
        public int Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime FinishTime { get; private set; }
        public double Rating { get; private set; }

        public IntervalDTO() { }

        public IntervalDTO(int id, DateTime startTime, DateTime finishTime, double rating)
        {
            Id = id;
            StartTime = startTime;
            FinishTime = finishTime;
            Rating = rating;
        }

        public IntervalDTO(DateTime startTime, DateTime finishTime, double rating)
        {
            StartTime = startTime;
            FinishTime = finishTime;
            Rating = rating;
        }
    }
}
