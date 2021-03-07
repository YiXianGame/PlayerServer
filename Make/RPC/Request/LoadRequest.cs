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
        public void StartGame(Player player,List<Team> team);
    }
}
