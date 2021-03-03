using Make.Model;
using Make.Model.GameModel;
using Material.Entity;
using Material.RPCServer.Annotation;
using Model.GameModel.GameRoom;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Make.RPC.Adapt
{
    public class PlayerServerAdapt
    {
        [RPCAdapt]
        public string CreateRoom(List<long> redTeam,List<long> blueTeam,string roomType)
        {
            if (Enum.TryParse(roomType, out Room.RoomType type))
            {
                if (type == Room.RoomType.Round_Solo)
                {
                    SoloRoom_Round room = new SoloRoom_Round();
                    foreach (long item in redTeam) room.RedTeam.Add(item, null);
                    foreach (long item in blueTeam) room.BlueTeam.Add(item, null);
                    return room.SecretKey;
                }
                else return "-2";
            }
            else return "-1";
        }
    }
}
