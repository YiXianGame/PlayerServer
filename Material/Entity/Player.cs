using Material.Entity;
using Material.Entity.EventArgs;
using Material.RPCServer.TCP_Async_Event;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Material.Entity
{
    public class Player : BaseUserToken
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
        private int hp;//血量
        private int mp;//能量
        private int hp_max;//血量上限
        private int mp_max;//仙气上限
        private string title = "炼气";//称号
        private int lv = 1;//等级
        private byte[] headImage;
        private Room room;//房间
        private Team teammates;//队友
        private CardGroup cardGroup;
        #endregion

        #region --属性--
        public override object Key { get => id; set => id = (long)value; }
        public long Id { get => id; set => id = value; }

        #endregion
    }
}
