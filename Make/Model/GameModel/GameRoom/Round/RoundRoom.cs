using Make.Model.GameModel;
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
            throw new NotImplementedException();
        }

        public override bool Enter(Player player,string roomSecretKey)
        {
            if (SecretKey.Equals(roomSecretKey))
            {
                foreach(Team team in Teams)
                {
                    if (team.Teammates.ContainsKey(player.Id))
                    {
                        team.Teammates.Remove(player.Id);
                        team.Teammates.Add(player.Id,player);
                        
                    }
                }
            }
            return false;
        }

        public override bool Force_Close()
        {
            throw new NotImplementedException();
        }

        public override bool Leave(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Raise_Stage()
        {
            throw new NotImplementedException();
        }

        public override void Result_Stage()
        {
            throw new NotImplementedException();
        }

        public override void Start_Stage()
        {
            throw new NotImplementedException();
        }
    }
}
