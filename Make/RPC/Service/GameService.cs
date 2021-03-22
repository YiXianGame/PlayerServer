using Material.Entity;
using Material.Entity.Frame;
using Material.EtherealS.Annotation;
using Material.EtherealS.Extension.Authority;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Make.RPC.Service
{
    public class GameService : IAuthoritable
    {
        public object Authority { get => 1; set { } }

        [RPCService]
        public bool Action(Player player,long skillCardId,List<long> selects)
        {
            ActionFrame frame = new ActionFrame();
            frame.OwnerId = player.Id;
            frame.Selects = selects;
            frame.SkillCardId = skillCardId;
            lock (player.Room){
                player.Room.NowFrameGroup.Frames.Add(frame);
                return true;
            }
        }
        [RPCService]
        public List<FrameGroup> SyncFrame(Player player,long start,long end)
        {
            if (start % Core.Config.FrameRate == 0 && end % Core.Config.FrameRate == 0)
            {
                List<FrameGroup> frameGroups = new List<FrameGroup>();

                return frameGroups;
            }
            return null;
        }
    }
}
