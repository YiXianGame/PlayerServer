using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Material.Entity.Frame
{
    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
    public class Frame
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FrameCategory { TimeFrame,ActionFrame }

        protected FrameCategory category = FrameCategory.TimeFrame;
        private long ownerId;
        private List<long> selects;
        private long skillCardId;
        public long OwnerId { get => ownerId; set => ownerId = value; }
        public List<long> Selects { get => selects; set => selects = value; }
        public long SkillCardId { get => skillCardId; set => skillCardId = value; }
        public FrameCategory Category { get => category; set => category = value; }
    }
}
