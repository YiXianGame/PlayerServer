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
            Frame frame = new Frame();
            frame.OwnerId = player.Id;
            frame.Selects = selects;
            frame.SkillCardId = skillCardId;
            frame.Category = Frame.FrameCategory.ActionFrame;
            lock (player.Room){
                player.Room.NowFrameGroup.Frames.Add(frame);
            }
            return true;
        }
        [RPCService]
        public List<FrameGroup> SyncFrame(Player player,long start,long end)
        {
            //null 请求失败或不存在该帧，存在List即存在该帧
            if (start >=0 && end>=0 && start < end && start % Core.Config.FrameRate == 0 && end % Core.Config.FrameRate == 0 && player.Room.NowFrameGroup.Timestamp  >= start && player.Room.NowFrameGroup.Timestamp >= end)
            {
                List<FrameGroup> frameGroups = new List<FrameGroup>();
                for (int i = 0; i < player.Room.HistoryFrameGroups.Count; i++)
                {
                    if (player.Room.HistoryFrameGroups[i].Timestamp >= start)
                    {
                        if (player.Room.HistoryFrameGroups[i].Timestamp < end)
                        {
                            frameGroups.Add(player.Room.HistoryFrameGroups[i]);
                        }
                        else break;
                    }
                    else continue;
                }
                return frameGroups;
            }
            return null;
        }
    }
}
