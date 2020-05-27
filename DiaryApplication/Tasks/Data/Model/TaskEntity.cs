using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public TaskEntity(
            int id, 
            string title, 
            string subtitle, 
            string description, 
            DateTime addTime,
            DateTime lastChangeTime,
            bool isClosed)
        {
            Id = id;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            AddTime = addTime;
            LastChangeTime = lastChangeTime;
            IsClosed = isClosed;
        }
    }
}
