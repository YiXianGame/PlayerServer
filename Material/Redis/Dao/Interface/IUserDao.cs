using Material.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Material.Entity.User;

namespace Material.Redis.Dao.Interface
{
    public interface IUserDao
    {
        public void SetAccount(User user);
        public Task<User> Query_UserAttribute(long id);

        public Task<User> Query_User(long id, bool has_password = false);

    }
}
