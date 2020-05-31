using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public interface IDataBaseTask<T, V> : IDatabase<T, V>
    {
        Task<List<T>> GetTaskByProfile(int idProfile);
        Task<V> Create(int idProfile, T newObject);

        Task<V> CloseTask(int idTask, bool isClosed);

    }
}
