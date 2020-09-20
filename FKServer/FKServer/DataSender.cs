using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace FKServer
{
    public static class DataSender
    {
        public static void SetMouse(int x,int y)
        {
            List<string> sendData = new List<string>();
            sendData.Add("SetMouse");
            sendData.Add(x.ToString());
            sendData.Add(y.ToString());
            ServerMain.server.BroadcastMessage(sendData);
        }
        public static void BroadcastMessage(string mes)
        {
            List<string> dataToSend = new List<string>();
            dataToSend.Add("Mes");
            dataToSend.Add(mes);
            ServerMain.server.BroadcastMessage(dataToSend);
        }
       
    
    }
}
