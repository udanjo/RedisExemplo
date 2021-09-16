using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisExemplo.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters);
    }
}