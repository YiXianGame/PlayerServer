using Material.Entity;
using Material.EtherealS.Annotation;
using System;
using System.Collections.Generic;
using System.Text;

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
