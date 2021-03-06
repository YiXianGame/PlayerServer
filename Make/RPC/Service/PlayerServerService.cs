using Material.Entity;
using Material.RPCServer.Annotation;
using Material.RPCServer.TCP_Async_Event;
using Model.GameModel.GameRoom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Make.RPC.Service
{
    public class PlayerServerService
    {
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
    }
}
