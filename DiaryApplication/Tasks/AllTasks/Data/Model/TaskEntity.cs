using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;

namespace DiaryApplication.Tasks.Data.Model
{
    public class TaskEntity
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public DateTime AddTime { get; private set; }
        public DateTime LastChangeTime { get; private set; }
        public bool IsClosed { get; private set; }
        public List<TypeEntity> Types { get; private set; }
        public List<Interval> Intervals { get; private set; }

        public TaskEntity(
            int id, 
            string title, 
            string subtitle, 
            string description, 
            DateTime addTime,
            DateTime lastChangeTime,
            bool isClosed,
            List<TypeEntity> types,
            List<Interval> intervals)
        {
            Id = id;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            AddTime = addTime;
            LastChangeTime = lastChangeTime;
            IsClosed = isClosed;
            Types = types;
            Intervals = intervals;
        }

        public TaskEntity(
            string title,
            string subtitle,
            string description,
            DateTime addTime,
            DateTime lastChangeTime,
            bool isClosed,
            List<TypeEntity> types,
            List<Interval> intervals)
        {
            Title = title;
            Subtitle = subtitle;
            Description = description;
            AddTime = addTime;
            LastChangeTime = lastChangeTime;
            IsClosed = isClosed;
            Types = types;
            Intervals = intervals;
        }

        public TaskEntity(
            int id,
            string title,
            string subtitle,
            string description,
            DateTime lastChangeTime,
            bool isClosed,
            List<TypeEntity> types)
        {
            Id = id;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            LastChangeTime = lastChangeTime;
            IsClosed = isClosed;
            Types = types;
        }

        public TaskEntity CloseTask()
        {
            IsClosed = true;
            return this;
        }
    }
}
