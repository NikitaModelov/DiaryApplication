using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public interface IDatabase<T, V>
    {
        Task<List<T>> SelectAll();
        Task<T> SelectById(int id);
        Task<V> Update(int id, T newObject);
        Task<V> Delete(int id);
        Task<V> Create(T newObject);


    }
}
