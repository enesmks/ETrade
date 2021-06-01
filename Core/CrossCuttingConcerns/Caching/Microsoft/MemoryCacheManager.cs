using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key,out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveBtPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            var cacheECollectionValue = new List<ICacheEntry>();
            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemvalue = cacheItem.GetProperty().GetType("value").GetValue(cacheItem, null);
                cacheECollectionValue.Add(cacheItemvalue);
            }
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            var keyToRemove = cacheECollectionValue.Where(x => regex.IsMatch(x.Key.ToString())).Select(x => x.Key);
            foreach (var key in keyToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
