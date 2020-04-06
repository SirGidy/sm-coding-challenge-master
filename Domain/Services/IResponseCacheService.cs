using System;
using System.Threading.Tasks;

namespace sm_coding_challenge.Domain.Services
{
    public interface IResponseCacheService
    {
        Task<bool> SetCachedObject(string cacheKeyPrefix, dynamic objectToCache, TimeSpan timeToLive);
        Task<T> GetCachedObject<T>(string cacheKeyPrefix);
    }
}