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
                if (RedTeam.ContainsKey(player.Id))
                {
                    RedTeam.Remove(player.Id);
                    RedTeam.Add(player.Id, player);
                }
                else
                {
                    BlueTeam.Remove(player.Id);
                    BlueTeam.Add(player.Id, player);
                }
                bool flag = true;
                foreach(Player item in RedTeam.Values)
                {
                    if (item == null) flag = false;
                }
                foreach (Player item in BlueTeam.Values)
                {
                    if (item == null) flag = false;
                }
                if (flag)
                {
                    Start_Stage();
                }
                return true;
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
