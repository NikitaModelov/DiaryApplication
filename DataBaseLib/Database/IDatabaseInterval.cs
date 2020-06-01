using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public interface IDatabaseInterval<T, V> : IDatabase<T, V>
    {
        Task<V> InsertInterval(int idTask, T interval);
    }
}
