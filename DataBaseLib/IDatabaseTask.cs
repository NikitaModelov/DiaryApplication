using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public interface IDataBaseTask<T, V> : IDatabase<T, V>
    {
        Task<List<T>> GetTaskByProfile(int id);
        Task<V> Create(int idProfile, T newObject);
    }
}
