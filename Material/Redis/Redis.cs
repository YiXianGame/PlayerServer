using Material.Redis.Dao;
using Material.Redis.Dao.Interface;
using StackExchange.Redis;

namespace Material.Redis
{
    public class Redis
    {
        private ConnectionMultiplexer redis;//连接到redis
        public IUserDao userDao;
        public IDatabase db;
        public Redis(string config)
        {
            redis = ConnectionMultiplexer.Connect(config);
            //0-用户库
            userDao = new UserDao(redis.GetDatabase(0));
        }
    }
}
