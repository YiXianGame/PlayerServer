using System;
using System.Collections.Generic;

namespace Material.Entity
{
    public abstract class Room
    {
        public enum RoomType { Round_Solo, Round_Team, Round_BattleRoyale, RealTime_Solo, RealTime_Team, RealTime_BattleRoyale };
        public enum RoomStage { Wait,Start, Raise, Action, Result };
        #region --字段--
        protected string id;
        protected int time = 0;//房间时间
        protected List<Team> teams = new List<Team>();
        protected RoomStage stage = RoomStage.Wait;//房间阶段
        protected RoomType type = RoomType.Round_Solo;//房间类型
        protected int deaths = 0;//死亡总数
        protected DateTime latest_Date = DateTime.Now;//房间最新时间
        protected int max_players = 10;//最大玩家数
        protected int min_players = 10;//最少玩家数
        protected int hp_max = 100;
        protected int mp_max = 20;
        protected int readyCount = 0;
        #endregion

        #region --属性--
        public RoomStage Stage { get => stage; set => stage = value; }
        public RoomType Type { get => type; set => type = value; }
        public int Deaths { get => deaths; set => deaths = value; }
        public DateTime Latest_Date { get => latest_Date; set => latest_Date = value; }
        public int Max_players { get => max_players; set => max_players = value; }
        public int Min_players { get => min_players; set => min_players = value; }
        public int Time { get => time; set => time = value; }
        public string Id { get => id; set => id = value; }
        public List<Team> Teams { get => teams; set => teams = value; }
        public int Hp_max { get => hp_max; set => hp_max = value; }
        public int Mp_max { get => mp_max; set => mp_max = value; }
        public int ReadyCount { get => readyCount; set => readyCount = value; }
        #endregion

        #region --方法--
        public abstract void Start_Stage();
        public abstract void Action_Stage();
        public abstract void Raise_Stage();
        public abstract void Result_Stage();
        public abstract bool Enter(Player player);
        public abstract bool Leave(Player player);
        public abstract bool Force_Close();
        public abstract bool Action(Player player);

        public virtual void Foreach(Action<Player> action)
        {
            foreach(Team team in teams)
            {
                foreach(Player player in team.Teammates.Values)
                {
                    action(player);
                }
            }
        }
        #endregion
    }
}
