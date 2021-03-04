using Material.Entity;
using Material.RPCServer.Annotation;
using Model.GameModel.GameRoom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Make.RPC.Adapt
{
    public class PlayerServerAdapt
    {
        [RPCService]
        public string CreateRoom(List<long> redTeam,List<long> blueTeam,string roomType)
        {
            if (Enum.TryParse(roomType, out Room.RoomType type))
            {
                if (type == Room.RoomType.Round_Solo)
                {
                    SoloRoom_Round room = new SoloRoom_Round();
                    
                    StringBuilder sb = new StringBuilder();
                    redTeam.ForEach(item => sb.Append(item).Append("-"));
                    blueTeam.ForEach(item => sb.Append(item).Append("-"));
                    room.Id = sb.ToString();
                    Core.Rooms.Add(room.Id,room);
                    return room.Id;
                }
                else return "-2";
            }
            else return "-1";
        }
    }
}
