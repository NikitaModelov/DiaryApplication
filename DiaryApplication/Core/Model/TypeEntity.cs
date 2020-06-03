using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Core.Model
{
    public class TypeEntity
    {
        public int Id { get; }
        public string Title { get; }

        public TypeEntity(string title) 
        {
            if (title.Length > 0)
            {
                Title = title;
            }
            else
            {
                throw new Exception("Недопустимый параметр title");
            }
            
        }
        public TypeEntity(int id, string title) : this(title)
        {
            if (id >= 0)
            {
                Id = id;
            }
            else
            {
                throw new Exception("Недопустимый параметр id");
            }
            
        }
    }
}
