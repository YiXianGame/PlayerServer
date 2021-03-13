using Make;
using Material.Entity;
using System;
using System.Collections.Generic;

namespace Model.GameModel.GameRoom
{
    public abstract class RoundRoom : Room
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
                player.Buffs = new List<Buff>();
                readyCount++;
                if(readyCount >= min_players)
                {
                    teams.ForEach((team)=> { 
                        foreach(Player item in team.Teammates.Values)
                        {
                            Core.LoadRequest.StartGame(item);
                        }
                    });
                    Start_Stage();
                }
            }
            else
            {
                Core.LoadRequest.StartGame(player);
            }
            return true;
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
        }
    }
}
