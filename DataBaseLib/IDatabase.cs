using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public interface IDatabase<T, V>
    {
        Task<List<T>> SelectAll(string command = "");
        Task<T> SelectById(int idTask);
        Task<V> Update(int id, T newObject);
        Task<V> Delete(int id);
    }
}
