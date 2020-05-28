using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Utills
{
    public static class TaskMapper
    {
        public static TaskEntityDTO ConvertToDto(TaskEntity taskEntity)
        {
            return new TaskEntityDTO(
                id:taskEntity.Id,
                title: taskEntity.Title,
                subtitle: taskEntity.Subtitle,
                description: taskEntity.Description,
                addTime: taskEntity.AddTime,
                lastChangeTime: taskEntity.LastChangeTime,
                isClosed: taskEntity.IsClosed,
                types: TypeMapper.ConvertToListDto(taskEntity.Types).ToList(),
                intervals: IntervalMapper.ConvertToListDto(taskEntity.Intervals).ToList());
        }
        public static TaskEntity ConvertFromDto(TaskEntityDTO task)
        {
            return new TaskEntity(
                id: task.Id,
                title: task.Title,
                subtitle: task.Subtitle,
                description: task.Description,
                addTime: task.AddTime,
                lastChangeTime: task.LastChangeTime,
                isClosed: task.IsClosed,
                types: TypeMapper.ConvertFromListDto(task.Types).ToList(),
                intervals: IntervalMapper.ConvertFromListDto(task.Intervals).ToList());
        }
        public static IEnumerable<TaskEntityDTO> ConvertToListDto(List<TaskEntity> tasks)
        {
            return tasks?.Select(ConvertToDto);
        }
        public static IEnumerable<TaskEntity> ConvertFromListDto(List<TaskEntityDTO> tasks)
        {
            return tasks?.Select(ConvertFromDto);
        }
    }
}
