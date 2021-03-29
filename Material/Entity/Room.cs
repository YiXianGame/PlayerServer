using Material.Entity.Frame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Material.Entity
{
    public abstract class Room
    {
        public enum RoomType { RealTimeSolo };
        public enum RoomStage { Wait,Start, Raise, Action, Result,Close };
        #region --字段--
        protected string id;
        protected List<Team> teams = new List<Team>();
        protected RoomStage stage = RoomStage.Wait;//房间阶段
        protected RoomType type = RoomType.RealTimeSolo;//房间类型
        protected int deaths = 0;//死亡总数
        protected int max_players = 10;//最大玩家数
        protected int min_players = 10;//最少玩家数
        protected int hp_max = 100;
        protected int mp_max = 20;
        protected int readyCount = 0;
        protected int randomSeed;
        protected Random random;
        protected FrameGroup nowFrameGroup = new FrameGroup();
        protected Timer timer;
        protected List<FrameGroup> historyFrameGroups = new List<FrameGroup>();
        #endregion

        #region --属性--
        public RoomStage Stage { get => stage; set => stage = value; }
        public RoomType Type { get => type; set => type = value; }
        public int Deaths { get => deaths; set => deaths = value; }
        public int Max_players { get => max_players; set => max_players = value; }
        public int Min_players { get => min_players; set => min_players = value; }
        public string Id { get => id; set => id = value; }
        public List<Team> Teams { get => teams; set => teams = value; }
        public int Hp_max { get => hp_max; set => hp_max = value; }
        public int Mp_max { get => mp_max; set => mp_max = value; }
        public int ReadyCount { get => readyCount; set => readyCount = value; }
        public Timer Timer { get => timer; set => timer = value; }
        public FrameGroup NowFrameGroup { get => nowFrameGroup; set => nowFrameGroup = value; }
        public List<FrameGroup> HistoryFrameGroups { get => historyFrameGroups; set => historyFrameGroups = value; }
        public int RandomSeed { get => randomSeed; set => randomSeed = value; }
        public Random Random { get => random; set => random = value; }

        #endregion

        #region --虚方法--

        #endregion

        #region --抽象方法--
        public virtual void Start_Stage()
        {
            stage = RoomStage.Start;
            random = new Random(RandomSeed);
        }
        public virtual void Action_Stage()
        {
            stage = RoomStage.Action;
        }
        public virtual void Raise_Stage()
        {
            stage = RoomStage.Raise;
        }
        public virtual void Result_Stage()
        {
            stage = RoomStage.Result;
        }
        public virtual void Close_Stage()
        {
            stage = RoomStage.Close;
        }
        public virtual bool Enter(Player player)
        {
            return true;
        }
        public virtual bool Leave(Player player)
        {
            return true;
        }
        public virtual void Action(Frame.Frame actionFrame)
        {

        }

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
