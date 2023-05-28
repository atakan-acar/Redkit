using Newtonsoft.Json;
using Redkit.Api.Configuration.Database;

namespace Redkit.Api.Configuration.Service
{
    public class RedisService : IRedisService
    {
        private RedisDatabase redisDatabase;

        public RedisService(RedisDatabase _redisDatabase)
        {
            redisDatabase = _redisDatabase;
        }
        public string GetValueFromKey(string key)
        {
            return redisDatabase.GetValueFromKey(key);
        }
        public void SetValue(string key, string @value)
        {  
            bool result = redisDatabase.SetValueWithKey(key, value);
        }
    }
}
