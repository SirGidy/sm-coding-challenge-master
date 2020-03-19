using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;

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

        public T GetCachedObject<T>(string cacheKeyPrefix)
        {
            string requestETag = GetRequestedETag();

            if (!string.IsNullOrEmpty(requestETag))
            {
                // Construct the key for the cache 
                string cacheKey = $"{cacheKeyPrefix}-{requestETag}";

                // Get the cached item
                string cachedObjectJson = _cache.GetString(cacheKey);

                // If there was a cached item then deserialise this 
                if (!string.IsNullOrEmpty(cachedObjectJson))
                {
                    T cachedObject = JsonConvert.DeserializeObject<T>(cachedObjectJson);
                    return cachedObject;
                }
            }

            return default(T);
        }

        public bool SetCachedObject(string cacheKeyPrefix, dynamic objectToCache)
        {
            if (!IsCacheable(objectToCache))
            {
                return true;
            }

            string requestETag = GetRequestedETag();
            string responseETag = objectToCache.Name;

            // Add the player details to the cache for 6 days mins if not already in the cache
            if (objectToCache != null && responseETag != null)
            {
                string cacheKey = $"{cacheKeyPrefix}-{responseETag}";
                string serializedObjectToCache = JsonConvert.SerializeObject(objectToCache);
                _cache.SetString(cacheKey, serializedObjectToCache, new DistributedCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddDays(6) });
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