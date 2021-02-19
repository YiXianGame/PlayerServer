using Material.Entity;
using Material.Entity.Config;
using Material.MySQL.Dao.Interface;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Material.MySQL.Dao
{
    public class ConfigDao : IConfigDao
    {
        string ConnectionString;
        public ConfigDao(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public MySqlConnection GetConnection(out MySqlConnection connection)
        {
            connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }


        public async Task<bool> Insert(PlayerServerConfig config)
        {
            GetConnection(out MySqlConnection connection);
            try
            {
                string sqlcommand = "INSERT INTO player_server(category,ip,port,token) VALUES(@category,@ip,@port,@token)";
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("@category", config.Category.ToString()));
                parameters.Add(new MySqlParameter("@ip", config.Ip));
                parameters.Add(new MySqlParameter("@port", config.Port));
                parameters.Add(new MySqlParameter("@token", config.Token));
                int result = await MySqlHelper.ExecuteNonQueryAsync(connection, sqlcommand, parameters.ToArray());
                if (result == 1)
                {
                    return true;
                }
                else return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public async Task<bool> Delete(PlayerServerConfig.PlayerServerCategory category)
        {
            GetConnection(out MySqlConnection connection);
            try
            {
                string sqlcommand = "DELETE FROM player_server WHERE category=@category";
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("@category", category.ToString()));
                int result = await MySqlHelper.ExecuteNonQueryAsync(connection, sqlcommand, parameters.ToArray());
                if (result == 1)
                {
                    return true;
                }
                else return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public async Task<bool> Update(PlayerServerConfig config)
        {
            GetConnection(out MySqlConnection connection);
            try
            {
                string sqlcommand = "UPDATE player_server SET ip=@ip,port=@port,token=@token WHERE category=@category";
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("@category", config.Category.ToString()));
                parameters.Add(new MySqlParameter("@ip", config.Ip));
                parameters.Add(new MySqlParameter("@port", config.Port));
                parameters.Add(new MySqlParameter("@token", config.Token));
                int result = await MySqlHelper.ExecuteNonQueryAsync(connection, sqlcommand, parameters.ToArray());
                if (result == 1)
                {
                    return true;
                }
                else return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public async Task<PlayerServerConfig> Query(PlayerServerConfig.PlayerServerCategory category)
        {
            GetConnection(out MySqlConnection connection);
            try
            {
                string sqlcommand = "SELECT ip,port,token FROM player_server WHERE category=@category";
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("@category", category.ToString()));

                MySqlDataReader reader = await MySqlHelper.ExecuteReaderAsync(connection, sqlcommand, parameters.ToArray());
                if (reader.Read())
                {
                    PlayerServerConfig config = new PlayerServerConfig();
                    config.Category = category;
                    config.Ip = reader.GetString("ip");
                    config.Port = reader.GetString("port");
                    config.Token = reader.GetString("token");
                    return config;
                }
                else return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
