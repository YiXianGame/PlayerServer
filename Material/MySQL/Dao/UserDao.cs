using Material.Entity;
using Material.ExceptionModel;
using Material.MySQL.Dao.Interface;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Material.MySQL.Dao
{
    public class UserDao : IUserDao
    {
        string ConnectionString;
        public UserDao(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public MySqlConnection GetConnection(out MySqlConnection connection)
        {
            connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public async Task<User> Query_UserByID(long id,bool has_password = false)
        {
            GetConnection(out MySqlConnection connection);
            try
            {
                MySqlDataReader reader = await MySqlHelper.ExecuteReaderAsync(connection, $"SELECT username,nickname,password,upgrade_num,create_num,money,personal_signature," +
                    $"battle_count,exp,lv,title,state,kills,deaths,register_date,attribute_update,card_repository_update,head_image_update,friend_update,card_groups_update FROM user WHERE id={id}");
                User user = null;
                if (reader.Read())
                {
                    user = new User();
                    user.Id = id;
                    user.Username = reader.GetString("username");
                    user.Nickname = reader.GetString("nickname");
                    user.Password = reader.GetString("password");
                    user.Upgrade_num = reader.GetInt32("upgrade_num");
                    user.Create_num = reader.GetInt32("create_num");
                    user.Money = reader.GetInt32("money");
                    user.PersonalSignature = reader.GetString("personal_signature");
                    user.BattleCount = reader.GetInt32("battle_count");
                    user.Exp = reader.GetInt64("exp");
                    user.Lv = reader.GetInt32("lv");
                    user.Title = reader.GetString("title");
                    user.State = (User.UserState)Enum.Parse(typeof(User.UserState), reader.GetString("state"));
                    user.Kills = reader.GetInt32("kills");
                    user.Deaths = reader.GetInt32("deaths");
                    user.RegisterDate = reader.GetInt64("register_date");
                    user.Attribute_update = reader.GetInt64("attribute_update");
                    user.CardRepository_update = reader.GetInt64("card_repository_update");
                    user.HeadImage_update = reader.GetInt64("head_image_update");
                    user.Friend_update = reader.GetInt64("friend_update");
                    user.CardGroups = JsonConvert.DeserializeObject<List<CardGroup>>(reader.GetString("card_groups"));
                    user.CardGroups_update = reader.GetInt64("card_groups_update");
                }
                return user;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
