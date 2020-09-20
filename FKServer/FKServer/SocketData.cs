using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace FKServer
{
    public class SocketData
    {
        public Socket socket;
        public DateTime lastHeatTime;

        public SocketData(Socket _socket)
        {
            this.socket = _socket;
            lastHeatTime = DateTime.UtcNow;
        }
    }
}
