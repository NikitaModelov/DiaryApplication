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

        public ProfileDTO(int id, string firstName, string secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
        }

        public ProfileDTO(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public ProfileDTO(){}
    }
}