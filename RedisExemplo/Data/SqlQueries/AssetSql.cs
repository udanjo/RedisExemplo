namespace RedisExemplo.Data.UnitOfWorks.SqlQueries
{
    public static class AssetSql
    {
        public const string sqlGet = @"SELECT ticker, name, [type], sector, price, dy, max, min, dpa, fair_price, within_fair_price, created_at
                                        FROM ProjectSend.dbo.assets";
    }
}