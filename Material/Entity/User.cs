using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Material.Entity
{
    [JsonObject(MemberSerialization.OptOut)]
    public class User
    {
        #region --Enum--
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UserState { Leisure, Ready, Queue, Gaming, Offline };
        #endregion

        #region --字段--

        private long id;
        private string username;
        private string password;
        private byte[] headImage;
        private string nickname;
        private int upgrade_num = 0;
        private int create_num = 0;
        private long money = 0;
        private string personalSignature;
        private int battleCount;//战斗场次
        private long exp;//经验
        private int lv = 1;//等级
        private string title = "炼气";//称号
        private UserState state = UserState.Offline;//玩家当前游戏状态
        private int kills;//击杀数
        private int deaths;//死亡数
        private List<CardGroup> cardGroups;//技能卡组
        private long registerDate;//注册日期
        private long attribute_update;//个人信息更新日期
        private long cardRepository_update;//卡牌更新日期
        private long headImage_update;//头像更新日期
        private long friend_update;//好友更新日期
        private long cardGroups_update;//技能卡组更新日期
        #endregion

        #region --属性--

        public long Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        [JsonIgnore]
        public string Password { get => password; set => password = value; }
        public byte[] HeadImage { get => headImage; set => headImage = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public int Upgrade_num { get => upgrade_num; set => upgrade_num = value; }
        public int Create_num { get => create_num; set => create_num = value; }
        public long Money { get => money; set => money = value; }
        public string PersonalSignature { get => personalSignature; set => personalSignature = value; }
        public int BattleCount { get => battleCount; set => battleCount = value; }
        public long Exp { get => exp; set => exp = value; }
        public int Lv { get => lv; set => lv = value; }
        public string Title { get => title; set => title = value; }
        public UserState State { get => state; set => state = value; }
        public int Kills { get => kills; set => kills = value; }
        public int Deaths { get => deaths; set => deaths = value; }
        public long RegisterDate { get => registerDate; set => registerDate = value; }
        public long Attribute_update { get => attribute_update; set => attribute_update = value; }
        public long CardRepository_update { get => cardRepository_update; set => cardRepository_update = value; }
        public long HeadImage_update { get => headImage_update; set => headImage_update = value; }
        public List<CardGroup> CardGroups { get => cardGroups; set => cardGroups = value; }
        public long Friend_update { get => friend_update; set => friend_update = value; }
        public long CardGroups_update { get => cardGroups_update; set => cardGroups_update = value; }
        #endregion

        #region --方法--
        public void SetAttribute(User user)
        {
            this.id = user.id;
            this.username = user.username;
            this.nickname = user.nickname;
            this.upgrade_num = user.upgrade_num;
            this.create_num = user.create_num;
            this.money = user.money;
            this.personalSignature = user.personalSignature;
            this.battleCount = user.battleCount;
            this.exp = user.exp;
            this.lv = user.lv;
            this.title = user.title;
            this.state = user.state;
            this.kills = user.kills;
            this.deaths = user.deaths;
            this.registerDate = user.registerDate;
            this.attribute_update = user.attribute_update;
            this.cardRepository_update = user.cardRepository_update;
            this.headImage_update = user.headImage_update;
            this.friend_update = user.friend_update;
            this.cardGroups_update = user.CardGroups_update;
        }
        #endregion
    }
}
