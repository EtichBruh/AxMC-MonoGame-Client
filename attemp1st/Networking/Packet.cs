using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attemp1st.Networking
{
    public abstract class Packet
    {
        public static Dictionary<PacketId, Packet> Packets = new Dictionary<PacketId, Packet>();
        public static Dictionary<PacketId, int> packetCount = new Dictionary<PacketId, int>();

        public abstract PacketId ID { get; }
        public abstract Packet CreateInstance();
    }
}
