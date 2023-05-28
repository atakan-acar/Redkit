using Redkit.Api.Configuration.Model;
using StackExchange.Redis;

namespace Redkit.Api.Configuration.Database
{
    public class RedisDatabase
    {
        private readonly RedisConfiguration _redisConfiguration;

        public RedisDatabase(RedisConfiguration redisConfiguration)
        {
            _redisConfiguration = redisConfiguration;
        }

        private ConnectionMultiplexer? Connect()
        {
            
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { _redisConfiguration.Endpoint } // Redis sunucusunun adresi ve portu
            };

            var connectionMultiplexer = ConnectionMultiplexer.
                Connect(configurationOptions);

            return connectionMultiplexer;
        }

        private IDatabase Database()
        {
            var connect = Connect();

            if (connect is null) throw new Exception("Database is not connected!"); 

            return connect.GetDatabase();   
        }



        public string GetValueFromKey(string key)
        { 
            IDatabase database = Database();

            var has = database.StringGet(key);

            return database.StringGet(key);
        }

        public bool SetValueWithKey(string key, string @object)
        {
            try
            {

                IDatabase db = Database();

                db.StringSet(key, @object);

                return true;
            }
            catch (Exception ex)
            { 
                throw new Exception("Error!");
            }
        }
    }
}
