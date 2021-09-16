using RedisExemplo.Asset;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisExemplo.Repositories
{
    public interface IAssetRepository
    {
        Task<IList<AssetModel>> Get();
    }
}