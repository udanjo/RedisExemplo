using RedisExemplo.Data.UnitOfWorks;
using RedisExemplo.Data.UnitOfWorks.SqlQueries;
using RedisExemplo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisExemplo.Asset
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<AssetModel>> Get()
        {
            return (IList<AssetModel>)await _unitOfWork.QueryAsync<AssetModel>(AssetSql.sqlGet, "");
        }
    }
}