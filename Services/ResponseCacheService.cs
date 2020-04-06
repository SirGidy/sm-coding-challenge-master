using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using sm_coding_challenge.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace sm_coding_challenge.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly HttpContext _httpContext;

        public ResponseCacheService(IDistributedCache distributedCache, IHttpContextAccessor httpContextAccessor)
        {
            _distributedCache = distributedCache;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<T> GetCachedObject<T>(string cacheKeyPrefix)
        {
            string requestETag = GetRequestedETag();

            if (!string.IsNullOrEmpty(requestETag))
            {
                // Construct the key for the cache 
                string cacheKey = $"{cacheKeyPrefix}-{requestETag}";

                // Get the cached item
                var cachedObjectJson = await _distributedCache.GetStringAsync(cacheKey);

                // If there was a cached item then deserialise this 
                if (!string.IsNullOrEmpty(cachedObjectJson))
                {
                    T cachedObject = JsonSerializer.Deserialize<T>(cachedObjectJson);
                    return cachedObject;
                }
            }

            return default(T);
        }

        public async Task<bool> SetCachedObject(string cacheKeyPrefix, dynamic objectToCache, TimeSpan timeToLive)
        {
            string requestETag = GetRequestedETag();
            string responseETag = Guid.NewGuid().ToString();

            // Add the player details to the cache for 6 days  if not already in the cache
            if (objectToCache != null && responseETag != null)
            {
                string cacheKey = $"{cacheKeyPrefix}-{responseETag}";
                string serializedObjectToCache = JsonSerializer.Serialize(objectToCache);
                await _distributedCache.SetStringAsync(cacheKey, serializedObjectToCache, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = timeToLive });
            }

            // Add the current ETag to the HTTP header
            _httpContext.Response.Headers.Add("ETag", responseETag);

            bool IsModified = !(_httpContext.Request.Headers.ContainsKey("If-None-Match") && responseETag == requestETag);
            return IsModified;

        }

        private string GetRequestedETag()
        {
            if (_httpContext.Request.Headers.ContainsKey("If-None-Match"))
            {
                return _httpContext.Request.Headers["If-None-Match"].First();
            }
            return "";
        }

        private bool IsCacheable(dynamic objectToCache)
        {
            var type = objectToCache.GetType();
            return type.GetProperty("Name") != null;
        }
    }
}