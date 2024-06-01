using NS.STMS.Caching.Cachers.Abstract;
using NS.STMS.Caching.Managers.Abstract;
using System.Reflection;

namespace NS.STMS.Caching.Managers.Concrete
{
	public class CacheManager : ICacheService
	{

		#region CTOR

		private ICache _cache;

		public CacheManager(ICache cache)
		{
			_cache = cache;
		}

		#endregion

		public R ProcessAndGet<R, T>(string key, T refClass, string methodName, object[] parameters = null, TimeSpan? absoluteExpireTime = null)
		{
			bool objHasCached = _cache.Contains(key);

			if (objHasCached)
				return GetByCaching<R>(key);

			R result = GetByCalling<R, T>(refClass, methodName, parameters);

			if (result == null)
				return result;

			SetToCache(key, result, absoluteExpireTime);

			return result;
		}

		public void Set<T>(string key, T data, TimeSpan? absoluteExpireTime = null)
		{
			_cache.Set(key, data, absoluteExpireTime);
		}

		public T Get<T>(string key)
		{
			return _cache.Get<T>(key);
		}

		public bool Contains(string key)
		{
			return _cache.Contains(key);
		}

		public void Remove(string key)
		{
			_cache.Remove(key);
		}

		public void Clear() => _cache.Clear();

		#region Refactor

		private void SetToCache<T>(string key, T data, TimeSpan? absoluteExpireTime = null)
		{
			_cache.Set(key, data, absoluteExpireTime);
		}

		private R GetByCaching<R>(string key)
		{
			return _cache.Get<R>(key);
		}

		private R GetByCalling<R, T>(T refClass, string methodName, object[] parameters = null)
		{
			Type refType = refClass.GetType();

			MethodInfo refMethod = refType.GetMethod(methodName);
			object result = refMethod.Invoke(refClass, parameters);

			return (R)result;
		}

		#endregion

	}
}
