using System;
using System.Collections.Generic;
using System.Text;

namespace Material.Entity.Frame
{
    public class ActionFrame : Frame
    {
        private long ownerId;
        private List<long> selects;
        private long skillCardId;

        public long OwnerId { get => ownerId; set => ownerId = value; }
        public List<long> Selects { get => selects; set => selects = value; }
        public long SkillCardId { get => skillCardId; set => skillCardId = value; }
    }
}
