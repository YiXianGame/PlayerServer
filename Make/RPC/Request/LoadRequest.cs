using EtherealS.Attribute;
using Material.Entity;
using System.Collections.Generic;

namespace Make.RPC.Request
{
    public interface LoadRequest
    {
        [RPCRequest]
        public void StartGame(Player player,int frameRate,int randomSeed);
        [RPCRequest]
        public void SyncRoom(Player player, string category, List<Team> teams);
    }
}
