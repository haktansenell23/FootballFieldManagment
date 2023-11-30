using StackExchange.Redis;

namespace FootballFieldManagmentAngularJS.Cache
{
    public class RedisService
    {
        private readonly string _connectionString;
        private readonly ConnectionMultiplexer _redis;

        public RedisService(string connectionString)
        {
            _connectionString = connectionString;
            _redis = ConnectionMultiplexer.Connect(_connectionString);
        }
        public IDatabase db { get; set; }   
        public IDatabase GetDb(int db)
        {
            return _redis.GetDatabase(db);  
        }
    }
}
