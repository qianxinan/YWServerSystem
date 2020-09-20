using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FKServer
{
    public static class CommandHandel
    {
        public static void Handel(string mes)
        {
            string[] vs = mes.Split(' ');
            switch (vs[0])
            {
                case "SetMouse":
                    DataSender.SetMouse(int.Parse(vs[1]),int.Parse(vs[2]));
                    P.p("Send SetMouse X:"+vs[1]+"Y:"+vs[2]);
                    break;
                case "lc":
                    ListClient();
                    break;
                default:
                    P.e("请输入正确的命令");
                    break;
            }
            //DataSender.SetMouse();
        }
        public static void ListClient()
        {
            Console.WriteLine("列举在线客户端：");
            for (int i = 0; i < ServerMain.server.client_List.Count; i++)
            {
                if (ServerMain.server.client_List[i] == null || ServerMain.server.client_List[i].socket.Connected != true)
                {
                     P.w("客户端发生断开");
                    ServerMain.server.client_List.RemoveAt(i);
                    return;
                }
                Console.WriteLine("{0}：IP：{1}",i+1, ((IPEndPoint)ServerMain.server.client_List[i].socket.RemoteEndPoint).Address.ToString());
            }
            if(ServerMain.server.masterClient != null)
            {
                Console.WriteLine("[管理器-{0}-目前在线]", ((IPEndPoint)ServerMain.server.masterClient.RemoteEndPoint).Address.ToString());
            }
            else
            {
                Console.WriteLine("[管理器没有在线]");
            }
        }
    }
}
