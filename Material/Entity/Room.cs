using Make.Model.GameModel;
using System;
using System.Collections.Generic;

namespace Material.Entity
{
    public abstract class Room
    {
        public enum RoomType { Round_Solo, Round_Team, Round_BattleRoyale, RealTime_Solo, RealTime_Team, RealTime_BattleRoyale };
        public enum RoomStage { Wait, Raise, Action, Result };
        #region --字段--
        protected int time = 0;//房间时间
        protected Dictionary<long, Player> redTeam = new Dictionary<long, Player>();//房间内的玩家
        protected Dictionary<long, Player> blueTeam = new Dictionary<long, Player>();//房间内的玩家
        protected RoomStage stage = RoomStage.Wait;//房间阶段
        protected RoomType type = RoomType.Round_Solo;//房间类型
        protected int deaths = 0;//死亡总数
        protected DateTime latest_Date = DateTime.Now;//房间最新时间
        protected int max_players = 10;//最大玩家数
        protected int min_players = 2;//最少玩家数
        private string secretKey;
        #endregion

        #region --属性--
        public RoomStage Stage { get => stage; set => stage = value; }
        public RoomType Type { get => type; set => type = value; }
        public int Deaths { get => deaths; set => deaths = value; }
        public DateTime Latest_Date { get => latest_Date; set => latest_Date = value; }
        public int Max_players { get => max_players; set => max_players = value; }
        public int Min_players { get => min_players; set => min_players = value; }
        public int Time { get => time; set => time = value; }
        public Dictionary<long, Player> RedTeam { get => redTeam; set => redTeam = value; }
        public Dictionary<long, Player> BlueTeam { get => blueTeam; set => blueTeam = value; }
        public string SecretKey { get => secretKey; set => secretKey = value; }
        #endregion

        #region --方法--
        public Room()
        {
            SecretKey = Utils.SecretKey.Generate(10);
        }
        public abstract void Start_Stage();
        public abstract void Action_Stage();
        public abstract void Raise_Stage();
        public abstract void Result_Stage();
        public abstract bool Enter(Player player, string roomSecretKey);
        public abstract bool Leave(Player player);
        public abstract bool Force_Close();
        public abstract bool Action(Player player);
        #endregion
    }
}
