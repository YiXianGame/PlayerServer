using Material.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Material.Entity.User;

namespace Material.MySQL.Dao.Interface
{
    public interface IUserDao
    {
        public Task<User> Query_UserByID(long id,bool has_password = false);
    }
}
