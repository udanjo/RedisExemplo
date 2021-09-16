using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisExemplo.Repositories;
using System;
using System.Threading.Tasks;

namespace RedisExemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        [HttpGet]
        public ContentResult Get([FromServices] IAssetRepository repository,
                                 [FromServices] IDistributedCache cache)
        {
            string valueJson = cache.GetString("assets");
            if (valueJson == null)
            {
                var result = repository.Get().Result;
                valueJson = JsonConvert.SerializeObject(result);

                DistributedCacheEntryOptions optCache = new();
                optCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                cache.SetString("assets", valueJson, optCache);
            }

            return Content(valueJson, "application/json");
        }
    }
}