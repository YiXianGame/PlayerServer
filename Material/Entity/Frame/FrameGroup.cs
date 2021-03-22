using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Material.Entity.Frame
{
    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
    public class FrameGroup : IComparable<FrameGroup>
    {
        private List<Frame> frames = new List<Frame>();

        private long timestamp = 0;

        public List<Frame> Frames { get => frames; set => frames = value; }
        public long Timestamp { get => timestamp; set => timestamp = value; }
        public int CompareTo([AllowNull] FrameGroup other)
        {
            if (timestamp < other.timestamp) return -1;
            else if (timestamp == other.timestamp) return 0;
            else return 1;
        }
    }
}
