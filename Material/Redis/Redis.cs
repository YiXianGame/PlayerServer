﻿using Material.Redis.Dao;
using Material.Redis.Dao.Interface;
using StackExchange.Redis;

namespace Material.Redis
{
    public class Redis
    {
        private ConnectionMultiplexer redis;//连接到redis
        public IUserDao userDao;
        public ISkillCardDao skillCardDao;
        public IDatabase db;
        public Redis(string config)
        {
            redis = ConnectionMultiplexer.Connect(config);
            //0-用户库
            userDao = new UserDao(redis.GetDatabase(0));
            //1-卡库
            skillCardDao = new SkillCardDao(redis.GetDatabase(1));
        }
    }
}
