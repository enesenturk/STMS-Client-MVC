namespace NS.STMS.Caching.Managers.Abstract
{
	public interface ICacheService
	{

		R ProcessAndGet<R, T>(string key, T refClass, string methodName, object[] parameters = null, TimeSpan? absoluteExpireTime = null);
		void Set<T>(string key, T data, TimeSpan? absoluteExpireTime = null);
		T Get<T>(string key);
		bool Contains(string key);
		void Remove(string key);
		void Clear();

	}
}
