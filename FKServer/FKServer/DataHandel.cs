using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FKServer
{
    public  static class DataHandel
    {
        public static void Handle(Socket _socket,byte[] b,int length)
        {
            string mes = Encoding.UTF8.GetString(b, 0, length);
            if (mes == "")
            {
                return;
            }
            string[] data = mes.Split("|");
            //Console.WriteLine();
            switch (data[0])
            {
                case "Hello":
                    Hello(_socket, data);
                    break;
                case "Desktop":
                    Desktop(_socket, data);
                    break;
                case "SendMessage":
                    SendMessage(_socket,data);
                    break;
                case "SetMouse":
                    DataSender.SetMouse(int.Parse(data[1]) ,int.Parse(data[2]));
                    break;
                case "Beat":
                    Beat(_socket);
                    break;
                default:
                    P.e("收到了未知的协议"+mes);
                    break;
            }
        }

       static void Hello(Socket socket,string[] data)
        {
            P.i("新客户端连接，类型："+data[1]);
            switch (data[1])
            {
                case "Client":
                    ServerMain.server.AddClientToList(socket);
                    break;
                case "Master":
                    ServerMain.server.SetMasterServer(socket);
                    break;
                default:
                    break;
            }
            List<string> sendData= new List<string>();
            sendData.Add("Welcome");
            sendData.Add("Success");
            ServerMain.server.SendMessage(socket,sendData);
        }

        static void Desktop(Socket socket,string[] data)
        {
            P.d("GetDesktop："+ Encoding.UTF8.GetBytes(data[1]).Length);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data[1]));
            Image img = Image.FromStream(ms);
            P.i("W:"+img.Width);
            img.Save("C:\\test11.bmp",ImageFormat.Bmp);
        }

        static void SendMessage(Socket socket,string[] data)
        {
            if(socket != ServerMain.server.masterClient)
            {
                P.e("非管理端尝试执行特殊操作");
                return;
            }
            if (data[1].Equals("Broadcast"))
            {
                DataSender.BroadcastMessage(data[2]);
            }
            else if (data[1].Equals("Single"))
            {
                //TODO
                
            }
            else
            {
                P.e("收到未知协议 In DataHandel at Message();");
            }
        }
        static void Beat(Socket socket)
        {
           SocketData sd= ServerMain.server.FindSocketDataBySocket(socket);
            sd.lastHeatTime = DateTime.UtcNow;
            P.d("收到来自:"+socket.RemoteEndPoint.ToString()+"的心跳");
        }
    }
}
