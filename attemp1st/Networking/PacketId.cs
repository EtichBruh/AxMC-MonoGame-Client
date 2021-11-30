using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attemp1st.Networking
{
    public enum PacketId : byte
    {
        HEALTH = 0,
        POSITION = 1,
        SHOT = 2,
    }
}
