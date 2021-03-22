using Material.Entity;
using Material.Entity.Frame;
using Material.EtherealS.Annotation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Make.RPC.Request
{
    public interface GameRequest
    {
        [RPCRequest]
        public void SyncFrame(Player player,FrameGroup frameGroup);
    }
}
