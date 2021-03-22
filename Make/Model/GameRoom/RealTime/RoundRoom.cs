using Make;
using Material.Entity;
using Material.Entity.Frame;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Model.GameRoom.Round
{
    public abstract class RealTimeRoom : Room
    {
        public override bool Action(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Action_Stage()
        {
            stage = RoomStage.Action;
        }
        public override bool Enter(Player player)
        {
            if (stage == RoomStage.Wait)
            {
                player.Hp = Hp_max;
                player.Mp = 0;
                player.Buffs = new HashSet<Buff>();
                readyCount++;
                if (readyCount >= min_players)
                {
                    teams.ForEach((team) => {
                        foreach (Player item in team.Teammates.Values)
                        {
                            Core.LoadRequest.StartGame(item,Core.Config.FrameRate);
                        }
                    });
                    Start_Stage();
                }
            }
            else
            {
                Core.LoadRequest.StartGame(player,Core.Config.FrameRate);
            }
            return true;
        }
        public void SyncFrame(object state)
        {
            //房间已经关闭
            if (stage == RoomStage.Close)
            {
                timer.Dispose();
                return;
            }
            lock (this)
            {
                Foreach(player => Core.GameRequest.SyncFrame(player, nowFrameGroup));
                if(NowFrameGroup.Frames.Count != 0)HistoryFrameGroups.Add(nowFrameGroup);
                FrameGroup frameGroup = new FrameGroup();
                frameGroup.Timestamp = nowFrameGroup.Timestamp + 60;
                nowFrameGroup = frameGroup;
            }
        }
        public override bool Force_Close()
        {
            teams.ForEach((item) =>
            {
                item.Foreach(player => Leave(player));
            });
            return true;
        }

        public override bool Leave(Player player)
        {
            player.Hp = 0;
            player.Mp = 0;
            player.Buffs = null;
            player.CardGroup = null;
            player.Team = null;
            player.Room = null;
            return true;
        }

        public override void Raise_Stage()
        {
            stage = RoomStage.Raise;
        }

        public override void Result_Stage()
        {
            stage = RoomStage.Result;
        }

        public override void Start_Stage()
        {
            stage = RoomStage.Start;
            timer = new Timer(SyncFrame, null, 0, Core.Config.FrameRate);
        }
    }
}
