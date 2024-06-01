using NS.STMS.Caching.Cachers.Abstract;
using System.Runtime.Caching;

namespace NS.STMS.Caching.Cachers.Concrete.MemoryCache
{
	[Serializable]
	public class MemoryCacher : ICache
	{

		#region CTOR

		private ObjectCache _cache;

		public MemoryCacher()
		{
			_cache = System.Runtime.Caching.MemoryCache.Default;
		}

		#endregion

		public void Set<T>(string key, T source, TimeSpan? absoluteExpireTime = null)
		{
			// 60 secs expiration by default
			DateTimeOffset absoluteExpiration = absoluteExpireTime != null
				? DateTime.Now.Add(absoluteExpireTime.Value)
				: DateTime.Now.AddSeconds(60);

			var policy = new CacheItemPolicy
			{
				AbsoluteExpiration = absoluteExpiration
			};

			_cache.Add(key, source, policy);
		}

		public T Get<T>(string key)
		{
			return (T)_cache.Get(key);
		}

		public bool Contains(string key)
		{
			return _cache.Contains(key);
		}

		public void Remove(string key)
		{
			_cache.Remove(key);
		}

		public void Clear()
		{
			List<string> cacheKeys = System.Runtime.Caching.MemoryCache.Default.Select(x => x.Key).ToList();

			foreach (string cacheKey in cacheKeys)
				Remove(cacheKey);
		}

	}
}
