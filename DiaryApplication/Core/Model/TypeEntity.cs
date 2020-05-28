using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Core.Model
{
    public class TypeEntity
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public TypeEntity(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public TypeEntity(string title)
        {
            Title = title;
        }
    }
}
