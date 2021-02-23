﻿using Material.RPCServer.TCP_Async_Event;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Material.Entity
{
    [JsonObject(MemberSerialization.OptOut)]
    public class User:BaseUserToken
    {
        #region --Enum--
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UserState { Leisure, Ready, Queue, Gaming, Offline };
        #endregion

        #region --字段--

        long id;

        string username;

        string password;

        byte[] headImage;

        string nickname;

        int upgrade_num = 0;

        int create_num = 0;

        long money = 0;

        string personalSignature;

        int battleCount;//战斗场次

        long exp;//经验

        int lv = 1;//等级

        string title = "炼气";//称号

        UserState state = UserState.Offline;//玩家当前游戏状态

        int kills;//击杀数

        int deaths;//死亡数

        List<CardGroup> cardGroups;//技能卡组

        long registerDate;//注册日期

        long attribute_update;//个人信息更新日期

        long skillCard_update;//卡牌更新日期

        long headImage_update;//头像更新日期

        long friend_update;//好友更新日期

        long cardGroups_update;//技能卡组更新日期
        #endregion

        #region --属性--

        public long Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }

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
        public long SkillCard_update { get => skillCard_update; set => skillCard_update = value; }
        public long HeadImage_update { get => headImage_update; set => headImage_update = value; }
        public List<CardGroup> CardGroups { get => cardGroups; set => cardGroups = value; }
        public long Friend_update { get => friend_update; set => friend_update = value; }
        public long CardGroups_update { get => cardGroups_update; set => cardGroups_update = value; }
        public override object Key { get => id; set => id = (long)value; }

        #endregion

    }
}
