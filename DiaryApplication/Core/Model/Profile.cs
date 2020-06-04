using System;
using System.Collections.Generic;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Core.Model
{
    public class Profile
    {
        public int Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public List<TaskEntity> Tasks { get; }

        public Profile(string firstName, string secondName, List<TaskEntity> tasks) 
        {
            if (firstName.Trim().Length > 0 && secondName.Trim().Length > 0)
            {
                FirstName = firstName.Trim();
                SecondName = secondName.Trim();
                Tasks = tasks;
            }
            else
            {
                throw new Exception("Недопустимый параметры");
            }
        }

        public Profile(int id, string firstName, string secondName, List<TaskEntity> tasks) 
            : this(firstName, secondName, tasks)
        {
            if (id >= 0)
            {
                Id = id;
            }
            else
            {
                throw new Exception("Недопустимый параметры");
            }

        }
        public override string ToString()
        {
            return $"{FirstName} {SecondName}";
        }
    }
}
