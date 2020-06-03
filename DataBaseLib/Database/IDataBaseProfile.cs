using System.Threading.Tasks;

namespace DataBaseLib.Database
{
    public interface IDataBaseProfile<T, V> : IDatabase<T, V>
    {
        Task<V> Create(T newObject);
    }
}
