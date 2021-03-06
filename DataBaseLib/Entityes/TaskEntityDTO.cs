﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace DataBaseLib
{
    public class TaskEntityDTO
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public DateTime AddTime { get; private set; }
        public DateTime LastChangeTime { get; private set; }
        public bool IsClosed { get; private set; }
        public List<TypeDTO> Types { get; private set; }
        public List<IntervalDTO> Intervals { get; private set; }

        public TaskEntityDTO(
            int id,
            string title,
            string subtitle,
            string description,
            DateTime addTime,
            DateTime lastChangeTime,
            bool isClosed,
            List<TypeDTO> types,
            List<IntervalDTO> intervals)
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

        public void SetTypes(List<TypeDTO> types)
        {
            Types = types;
        }

        public void SetIntervals(List<IntervalDTO> intervals)
        {
            Intervals = intervals;
        }

        public TaskEntityDTO() { }
    }
}
