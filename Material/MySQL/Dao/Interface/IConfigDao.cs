using Material.Entity;
using Material.Entity.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Material.MySQL.Dao.Interface
{
    public interface IConfigDao
    {
        Task<bool> Insert(PlayerServerConfig config);
        Task<bool> Delete(PlayerServerConfig.PlayerServerCategory category);
        Task<bool> Update(PlayerServerConfig config);
        Task<PlayerServerConfig> Query(PlayerServerConfig.PlayerServerCategory category);
    }
}
