using System;
using System.Threading.Tasks;

namespace TodoCache.Services
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeLive);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
