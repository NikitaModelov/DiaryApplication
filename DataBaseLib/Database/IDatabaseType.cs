using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public interface IDatabaseType<T, V> : IDatabase<T, V>
    {
    }
}
