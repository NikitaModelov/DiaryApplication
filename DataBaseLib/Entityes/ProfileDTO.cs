using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class ProfileDTO
    {
        public int Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public List<TaskEntityDTO> Tasks { get; private set; }

        public ProfileDTO(int id, string firstName, string secondName, List<TaskEntityDTO> tasks)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Tasks = tasks;
        }
        public ProfileDTO(int id, string firstName, string secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Tasks = null;
        }
        public ProfileDTO(string firstName, string secondName, List<TaskEntityDTO> tasks)
        {
            Tasks = tasks;
            FirstName = firstName;
            SecondName = secondName;
        }

        public ProfileDTO(){}

        public void SetTasks(List<TaskEntityDTO> tasks)
        {
            Tasks = tasks;
        }
    }
}