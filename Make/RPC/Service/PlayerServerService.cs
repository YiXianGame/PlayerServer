using Material.Entity;
using Material.EtherealS.Annotation;
using Material.EtherealS.Extension.Authority;
using Material.EtherealS.Model;
using Model.GameModel.GameRoom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Make.RPC.Service
{
    public class PlayerServerService : IAuthoritable
    {
        public object Authority { get => 1; set { } }
        [RPCService]
        public bool CreateRoom(Player player,List<Team> teams, string roomType)
        {
            if (player.Id == 1)//服务端权限
            {
                if (Enum.TryParse(roomType, out Room.RoomType type))
                {
                    if (type == Room.RoomType.Round_Solo)
                    {
                        StringBuilder sb = new StringBuilder();
                        SoloRoom_Round room = new SoloRoom_Round();
                        foreach (Team team in teams)
                        {
                            foreach (Player item in team.Teammates.Values)
                            {
                                sb.Append(item.Id).Append("-");
                                player.GetTokens().TryRemove(item.Id, out BaseUserToken value);
                                player.GetTokens().TryAdd(item.Id, item);
                                item.Room = room;
                                item.Team = team;
                            }
                        }
                        room.Id = sb.ToString();
                        teams.ForEach(item => room.Teams.Add(item));
                        return true;
                    }
                }
            }
            return false;
        }

        [RPCService(Authority = 0)]
        public bool Login(Player player,string secretKey)
        {
            if (secretKey.Equals(Core.Config.SecretKey))
            {
                player.Authority = 1;
                return true;
            }
            else return false;
        }
    }
}
