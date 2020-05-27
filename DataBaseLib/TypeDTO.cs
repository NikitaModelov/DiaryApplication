using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class TypeDTO
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public TypeDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
