using EtherealS.Attribute;
using Material.Entity;
using Material.Entity.Frame;

namespace Make.RPC.Request
{
    public interface GameRequest
    {
        [RPCRequest]
        public void SyncFrame(Player player,FrameGroup frameGroup);
    }
}
