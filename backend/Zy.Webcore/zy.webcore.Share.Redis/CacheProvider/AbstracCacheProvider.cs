

namespace zy.webcore.Share.Redis.CacheProvider
{
    public abstract class AbstracCacheProvider : ICacheProvider
    {

        public abstract IOptions<CacheOptions> CacheOptions { get; }

        protected abstract bool BaseExists(string cacheKey);

        protected abstract Task<bool> BaseExistsAsync(string cacheKey);

        protected abstract void BaseFlush();

        protected abstract Task BaseFlushAsync();

        protected abstract CacheValue<T> BaseGet<T>(string cacheKey, Func<T> dataRetriever, TimeSpan expiration);

        protected abstract CacheValue<T> BaseGet<T>(string cacheKey);

        protected abstract IDictionary<string, CacheValue<T>> BaseGetAll<T>(IEnumerable<string> cacheKeys);

        protected abstract Task<IDictionary<string, CacheValue<T>>> BaseGetAllAsync<T>(IEnumerable<string> cacheKeys);

        protected abstract Task<CacheValue<T>> BaseGetAsync<T>(string cacheKey, Func<Task<T>> dataRetriever, TimeSpan expiration);

        protected abstract Task<object> BaseGetAsync(string cacheKey, Type type);

        protected abstract Task<CacheValue<T>> BaseGetAsync<T>(string cacheKey);

        protected abstract IDictionary<string, CacheValue<T>> BaseGetByPrefix<T>(string prefix);

        protected abstract Task<IDictionary<string, CacheValue<T>>> BaseGetByPrefixAsync<T>(string prefix);

        protected abstract int BaseGetCount(string prefix = "");

        protected abstract Task<int> BaseGetCountAsync(string prefix = "");

        protected abstract void BaseRemove(string cacheKey);

        protected abstract void BaseRemoveAll(IEnumerable<string> cacheKeys);

        protected abstract Task BaseRemoveAllAsync(IEnumerable<string> cacheKeys);

        protected abstract Task BaseRemoveAsync(string cacheKey);

        protected abstract void BaseRemoveByPrefix(string prefix);

        protected abstract Task BaseRemoveByPrefixAsync(string prefix);

        protected abstract void BaseSet<T>(string cacheKey, T cacheValue, TimeSpan expiration);

        protected abstract void BaseSetAll<T>(IDictionary<string, T> values, TimeSpan expiration);

        protected abstract Task BaseSetAllAsync<T>(IDictionary<string, T> values, TimeSpan expiration);

        protected abstract Task BaseSetAsync<T>(string cacheKey, T cacheValue, TimeSpan expiration);

        protected abstract bool BaseTrySet<T>(string cacheKey, T cacheValue, TimeSpan expiration);

        protected abstract Task<bool> BaseTrySetAsync<T>(string cacheKey, T cacheValue, TimeSpan expiration);

        protected abstract TimeSpan BaseGetExpiration(string cacheKey);

        protected abstract Task BaseKeyExpireAsync(IEnumerable<string> cacheKeys, int seconds);

        protected abstract Task<TimeSpan> BaseGetExpirationAsync(string cacheKey);

        public bool Exists(string cacheKey)
        {
            try
            {
                return BaseExists(cacheKey);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        public async Task<bool> ExistsAsync(string cacheKey)
        {
            try
            {
                var flag = await BaseExistsAsync(cacheKey);
                return flag;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public void Flush()
        {
            try
            {
                BaseFlush();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        public async Task FlushAsync()
        {

            try
            {
                await BaseFlushAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
        }

        public CacheValue<T> Get<T>(string cacheKey, Func<T> dataRetriever, TimeSpan expiration)
        {
            try
            {
                return BaseGet(cacheKey, dataRetriever, expiration);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public CacheValue<T> Get<T>(string cacheKey)
        {

            try
            {
                return BaseGet<T>(cacheKey);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public IDictionary<string, CacheValue<T>> GetAll<T>(IEnumerable<string> cacheKeys)
        {
            try
            {
                return BaseGetAll<T>(cacheKeys);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task<IDictionary<string, CacheValue<T>>> GetAllAsync<T>(IEnumerable<string> cacheKeys)
        {
            try
            {
                return await BaseGetAllAsync<T>(cacheKeys);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task<CacheValue<T>> GetAsync<T>(string cacheKey, Func<Task<T>> dataRetriever, TimeSpan expiration)
        {

            try
            {
                return await BaseGetAsync(cacheKey, dataRetriever, expiration);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task<object> GetAsync(string cacheKey, Type type)
        {
            try
            {
                return await BaseGetAsync(cacheKey, type);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task<CacheValue<T>> GetAsync<T>(string cacheKey)
        {
            try
            {
                return await BaseGetAsync<T>(cacheKey);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public IDictionary<string, CacheValue<T>> GetByPrefix<T>(string prefix)
        {
            try
            {
                return BaseGetByPrefix<T>(prefix);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            { }
        }

        public async Task<IDictionary<string, CacheValue<T>>> GetByPrefixAsync<T>(string prefix)
        {
            try
            {
                return await BaseGetByPrefixAsync<T>(prefix);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public int GetCount(string prefix = "")
        {
            return BaseGetCount(prefix);
        }

        public async Task<int> GetCountAsync(string prefix = "")
        {
            return await BaseGetCountAsync(prefix);
        }

        public void Remove(string cacheKey)
        {
            try
            {
                BaseRemove(cacheKey);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public void RemoveAll(IEnumerable<string> cacheKeys)
        {
            try
            {
                BaseRemoveAll(cacheKeys);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task RemoveAllAsync(IEnumerable<string> cacheKeys)
        {
            try
            {
                await BaseRemoveAllAsync(cacheKeys);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task RemoveAsync(string cacheKey)
        {
            try
            {
                await BaseRemoveAsync(cacheKey);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        public void RemoveByPrefix(string prefix)
        {
            try
            {
                BaseRemoveByPrefix(prefix);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task RemoveByPrefixAsync(string prefix)
        {
            try
            {
                await BaseRemoveByPrefixAsync(prefix);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public void Set<T>(string cacheKey, T cacheValue, TimeSpan expiration)
        {

            try
            {
                BaseSet(cacheKey, cacheValue, expiration);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        public void SetAll<T>(IDictionary<string, T> value, TimeSpan expiration)
        {
            try
            {
                BaseSetAll(value, expiration);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
            }
        }

        public async Task SetAllAsync<T>(IDictionary<string, T> value, TimeSpan expiration)
        {
            try
            {
                await BaseSetAllAsync(value, expiration);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task SetAsync<T>(string cacheKey, T cacheValue, TimeSpan expiration)
        {
            try
            {
                await BaseSetAsync(cacheKey, cacheValue, expiration);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public bool TrySet<T>(string cacheKey, T cacheValue, TimeSpan expiration)
        {
            try
            {
                return BaseTrySet(cacheKey, cacheValue, expiration);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public async Task<bool> TrySetAsync<T>(string cacheKey, T cacheValue, TimeSpan expiration)
        {
            try
            {
                return await BaseTrySetAsync(cacheKey, cacheValue, expiration);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        public TimeSpan GetExpiration(string cacheKey)
        {
            return BaseGetExpiration(cacheKey);
        }

        public async Task<TimeSpan> GetExpirationAsync(string cacheKey)
        {
            return await BaseGetExpirationAsync(cacheKey);
        }

        public async Task KeyExpireAsync(IEnumerable<string> cacheKeys, int seconds)
        {
            try
            {
                await BaseKeyExpireAsync(cacheKeys, seconds);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }
    }
}
