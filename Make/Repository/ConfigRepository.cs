using Material.Entity.Config;
using Material.MySQL;
using Material.Redis;
using System.Threading.Tasks;

namespace Make.Repository
{
    public class ConfigRepository
    {
        #region --字段--
        private Redis redis;
        private MySQL mySQL;
        #endregion

        #region --方法--
        public ConfigRepository(Redis redis, MySQL mySQL)
        {
            this.redis = redis;
            this.mySQL = mySQL;
        }
        public async Task<bool> Insert(PlayerServerConfig config)
        {
            return await mySQL.configDao.Insert(config);
        }
        public async Task<bool> Update(PlayerServerConfig config)
        {
            return await mySQL.configDao.Update(config);
        }
        public async Task<PlayerServerConfig> Query(PlayerServerConfig.PlayerServerCategory category)
        {
            return await mySQL.configDao.Query(category);
        }
        public async Task<bool> Delete(PlayerServerConfig.PlayerServerCategory category)
        {
            return await mySQL.configDao.Delete(category);
        }
        #endregion

    }
}
