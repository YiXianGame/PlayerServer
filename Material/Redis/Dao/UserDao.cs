using Material.Entity;
using Material.Redis.Dao.Interface;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Material.Redis.Dao
{
    public class UserDao : IUserDao
    {
        IDatabase db;

        public UserDao(IDatabase db)
        {
            this.db = db;
        }
        public void SetAccount(User user)
        {
            db.HashSetAsync("UA" + user.Id, new HashEntry[]{ new HashEntry("username",user.Username),new HashEntry("nickname",user.Nickname),new HashEntry("password",user.Password),
                new HashEntry("upgrade_num",user.Upgrade_num),new HashEntry("create_num",user.Create_num),new HashEntry("money",user.Money),new HashEntry("personal_signature",user.PersonalSignature),
                new HashEntry("battle_count",user.BattleCount),new HashEntry("exp",user.Exp),new HashEntry("lv",user.Lv),new HashEntry("title",user.Title),new HashEntry("state",user.State.ToString()),
                new HashEntry("kills",user.Kills),new HashEntry("death",user.Deaths),new HashEntry("register_date",user.RegisterDate),new HashEntry("card_groups",JsonConvert.SerializeObject(user.CardGroups)),
                new HashEntry("attribute_update",user.Attribute_update),new HashEntry("card_repository_update", user.CardRepository_update),new HashEntry("head_image_update",user.HeadImage_update),new HashEntry("friend_update",user.Friend_update),new HashEntry("card_groups_update",user.CardGroups_update)});
        }
        public async Task<User> Query_User(long id, bool has_password = false)
        {
            RedisValue[] values = await db.HashGetAsync("UA" + id, new RedisValue[] { "username", "nickname","password", "upgrade_num", "create_num", "money", "personal_signature", "battle_count",
                "exp", "lv", "title","state","kills","deaths","register_date","attribute_update", "card_repository_update" , "head_image_update","card_groups","friend_update","card_groups_update" });
            User user = null;
            if (!values[0].IsNullOrEmpty)
            {
                user = new User();
                user.Id = id;
                user.Username = values[0];
                user.Nickname = values[1];
                if (has_password) user.Password = values[2];
                user.Upgrade_num = (int)values[3];
                user.Create_num = (int)values[4];
                user.Money = (long)values[5];
                user.PersonalSignature = values[6];
                user.BattleCount = (int)values[7];
                user.Exp = (long)values[8];
                user.Lv = (int)values[9];
                user.Title = values[10];
                user.State = (User.UserState)Enum.Parse(typeof(User.UserState), values[11]);
                user.Kills = (int)values[12];
                user.Deaths = (int)values[13];
                user.RegisterDate = (int)values[14];
                user.Attribute_update = (long)values[15];
                user.CardRepository_update = (long)values[16];
                user.HeadImage_update = (long)values[17];
                user.Friend_update = (long)values[19];
                user.CardGroups_update = (long)values[20];
                user.CardGroups = JsonConvert.DeserializeObject<List<CardGroup>>(values[18]);
            }
            return user;
        }
        public async Task<User> Query_UserAttribute(long id)
        {
            RedisValue[] values = await db.HashGetAsync("UA" + id, new RedisValue[] { "username", "nickname","password", "upgrade_num", "create_num", "money", "personal_signature", "battle_count",
                "exp", "lv", "title","state","kills","deaths","register_date","attribute_update"});
            User user = null;
            if (!values[0].IsNullOrEmpty)
            {
                user = new User();
                user.Id = id;
                user.Username = values[0];
                user.Nickname = values[1];
                user.Password = values[2];
                user.Upgrade_num = (int)values[3];
                user.Create_num = (int)values[4];
                user.Money = (long)values[5];
                user.PersonalSignature = values[6];
                user.BattleCount = (int)values[7];
                user.Exp = (long)values[8];
                user.Lv = (int)values[9];
                user.Title = values[10];
                user.State = (User.UserState)Enum.Parse(typeof(User.UserState), values[11]);
                user.Kills = (int)values[12];
                user.Deaths = (int)values[13];
                user.RegisterDate = (int)values[14];
                user.Attribute_update = (long)values[15];
            }
            return user;
        }
    }
}
