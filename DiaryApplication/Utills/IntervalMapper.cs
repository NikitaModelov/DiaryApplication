using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;
using DiaryApplication.Core.Model;

namespace DiaryApplication.Utills
{
    public static class IntervalMapper
    {
        public static IntervalDTO ConvertToDto(Interval interval)
        {
            return new IntervalDTO(
                id: interval.Id,
                startTime: interval.StartTime,
                finishTime: interval.FinishTime,
                rating: interval.Rating);
        }
        public static Interval ConvertFromDto(IntervalDTO interval)
        {
            return new Interval(
                id: interval.Id,
                startTime: interval.StartTime,
                finishTime: interval.FinishTime,
                rating: interval.Rating);
        }
        public static IEnumerable<IntervalDTO> ConvertToListDto(List<Interval> intervals)
        {
            return intervals?.Select(ConvertToDto);
        }
        public static IEnumerable<Interval> ConvertFromListDto(List<IntervalDTO> intervals)
        {
            return intervals?.Select(ConvertFromDto);
        }
    }
}
