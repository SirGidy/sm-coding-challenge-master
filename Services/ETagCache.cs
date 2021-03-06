using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace sm_coding_challenge.Services
{
    public class ETagCache
    {
        private readonly IDistributedCache _cache;
        private readonly HttpContext _httpContext;
        public ETagCache(IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
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
                var cachedObjectJson = await _cache.GetStringAsync(cacheKey);

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
            if (!IsCacheable(objectToCache))
            {
                return true;
            }

            string requestETag = GetRequestedETag();
            string responseETag = objectToCache.Name;

            // Add the player details to the cache for 6 days  if not already in the cache
            if (objectToCache != null && responseETag != null)
            {
                string cacheKey = $"{cacheKeyPrefix}-{responseETag}";
                string serializedObjectToCache = JsonSerializer.Serialize(objectToCache);
               await _cache.SetStringAsync(cacheKey, serializedObjectToCache, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = timeToLive });
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