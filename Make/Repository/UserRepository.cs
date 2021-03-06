using Material.Entity;
using Material.ExceptionModel;
using Material.MySQL;
using Material.Redis;
using Material.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Make.Repository
{
    public class UserRepository
    {
        #region --字段--
        private Redis redis;
        private MySQL mySQL;
        #endregion

        #region --方法--
        public UserRepository(Redis redis, MySQL mySQL)
        {
            this.redis = redis;
            this.mySQL = mySQL;
        }
        public async Task<User> Login(long id,string password)
        {
            // null 账户不存在 -1密码错误
            User user;
            user = await redis.userDao.Query_User(id, true);
            //Redis中不存在
            if (user == null)
            {
                user = await Cache(id);
                //缓存之后还是没有
                if (user == null)
                {
                    return null;//账户不存在
                }
            }
            if (!user.Password.Equals(password))
            {
                user.Id = -1;//密码错误
                return user;
            }
            else
            {
                return user;
            }
        }
        //从Mysql缓存到Redis
        public async Task<User> Cache(long id)
        {
            //这里要到了密码!!注意密码的去向，User内部的密码序列化已经忽略。
            User user = await mySQL.userDao.Query_UserByID(id, true);
            if (user != null)//Mysql中有此用户的数据
            {
                redis.userDao.SetAccount(user);
                return user;
            }
            else return null;
        }
        #endregion
    }

}
