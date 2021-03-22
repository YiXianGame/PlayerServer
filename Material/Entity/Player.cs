using Material.Entity.EventArgs;
using Material.EtherealS.Extension.Authority;
using Material.EtherealS.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Material.Entity
{
    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
    public class Player : BaseUserToken, IAuthorityCheck
    {
        #region --Enum--
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UserState { Life,Death };
        #endregion

        #region --委托--
        public delegate void DeathDelegate(Object sender, DeathEventArgs args);
        #endregion

        #region --事件--
        public event DeathDelegate DeathEvent;
        #endregion

        #region --事件发生器--
        public void OnDeath(Object Sender, DeathEventArgs args) => DeathEvent(Sender, args);
        #endregion

        #region --字段--
        private long id;
        private string username = "";//玩家ID也是QQ号（-1时为机器人）
        private string nickname;//玩家昵称
        private string password;//用户密码
        private int hp;//血量
        private int mp;//能量
        private int hpMax = 100;//血量上限
        private int mpMax = 100;//仙气上限
        private string title = "炼气";//称号
        private int lv = 1;//等级
        private byte[] headImage;
        private Room room;//房间
        private Team team;//队友
        private CardGroup cardGroup;
        private HashSet<Buff> buffs = new HashSet<Buff>();
        #endregion

        #region --属性--
        public override object Key { get => id; set => id = (long)value; }
        public long Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        [JsonIgnore]
        public string Password { get => password; set => password = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }

        public string Title { get => title; set => title = value; }
        public int Lv { get => lv; set => lv = value; }
        [JsonIgnore]
        public byte[] HeadImage { get => headImage; set => headImage = value; }
        [JsonIgnore]
        public Room Room { get => room; set => room = value; }
        [JsonIgnore]
        public Team Team { get => team; set => team = value; }
        public CardGroup CardGroup { get => cardGroup; set => cardGroup = value; }

        [JsonIgnore]
        public HashSet<Buff> Buffs { get => buffs; set => buffs = value; }
        public int HpMax { get => hpMax; set => hpMax = value; }
        public int MpMax { get => mpMax; set => mpMax = value; }
        #endregion

        #region --Cache字段--

        private int authority = 0;

        #endregion

        #region --Cache属性--
        [JsonIgnore]
        public object Authority { get => authority; set => authority = (int)value; }


        #endregion

        #region --方法--
        public void SetAttribute(Player player)
        {
            this.id = player.id;
            this.hp = player.hp;
            this.mp = player.mp;
            this.buffs = player.buffs;
            this.username = player.username;
            this.nickname = player.nickname;
            this.lv = player.lv;
            this.title = player.title;
            this.cardGroup = player.cardGroup;
            this.room = player.room;
            this.team = player.team;
        }

        public bool Check(IAuthoritable authoritable)
        {
            return (int)Authority >= (int)authoritable.Authority;
        }

        #endregion
    }
}
