using System;
using System.Collections.Generic;

namespace Material.Entity
{
    public abstract class Room
    {
        public enum RoomType { Round_Solo, Round_Team, Round_BattleRoyale, RealTime_Solo, RealTime_Team, RealTime_BattleRoyale };
        public enum RoomStage { Wait, Raise, Action, Result };
        #region --字段--
        protected string id;
        protected int time = 0;//房间时间
        protected HashSet<Team> teams = new HashSet<Team>();
        protected RoomStage stage = RoomStage.Wait;//房间阶段
        protected RoomType type = RoomType.Round_Solo;//房间类型
        protected int deaths = 0;//死亡总数
        protected DateTime latest_Date = DateTime.Now;//房间最新时间
        protected int max_players = 10;//最大玩家数
        protected int min_players = 2;//最少玩家数
        protected string secretKey;
        #endregion

        #region --属性--
        public RoomStage Stage { get => stage; set => stage = value; }
        public RoomType Type { get => type; set => type = value; }
        public int Deaths { get => deaths; set => deaths = value; }
        public DateTime Latest_Date { get => latest_Date; set => latest_Date = value; }
        public int Max_players { get => max_players; set => max_players = value; }
        public int Min_players { get => min_players; set => min_players = value; }
        public int Time { get => time; set => time = value; }
        public string SecretKey { get => secretKey; set => secretKey = value; }
        public string Id { get => id; set => id = value; }
        public HashSet<Team> Teams { get => teams; set => teams = value; }
        #endregion

        #region --方法--
        public abstract void Start_Stage();
        public abstract void Action_Stage();
        public abstract void Raise_Stage();
        public abstract void Result_Stage();
        public abstract bool Enter(Player player, string roomSecretKey = null);
        public abstract bool Leave(Player player);
        public abstract bool Force_Close();
        public abstract bool Action(Player player);
        #endregion
    }
}
