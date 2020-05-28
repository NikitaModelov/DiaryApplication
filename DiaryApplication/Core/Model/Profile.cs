using System.Collections.Generic;
using DiaryApplication.Tasks.Data.Model;

namespace DiaryApplication.Core.Model
{
    public class Profile
    {
        public int Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public List<TaskEntity> Tasks { get; private set; }

        public Profile(string firstName, string secondName, List<TaskEntity> tasks)
        {
            FirstName = firstName;
            SecondName = secondName;
            Tasks = tasks;
        }
        public Profile(int id, string firstName, string secondName, List<TaskEntity> tasks)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Tasks = tasks;
        }
        public override string ToString()
        {
            return $"{FirstName} {SecondName}";
        }
    }
}
