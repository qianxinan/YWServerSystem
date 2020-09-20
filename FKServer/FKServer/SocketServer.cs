using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace FKServer
{
    public class SocketServer
    {
        private string _ip = string.Empty;
        private int _port = 0;
        private Socket Mysocket = null;
        private byte[] buffer = new byte[838860800];

        public List<SocketData> client_List = new List<SocketData>();
        public Socket masterClient;

        byte[] inOptionValues = new byte[Marshal.SizeOf(0) * 3];

        public SocketServer(int port)
        {
            this._ip = "0.0.0.0";
            this._port = port;
        }
        public void StartListen()
        {
            try
            {
                Mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress address = IPAddress.Parse(_ip);

                IPEndPoint endPoint = new IPEndPoint(address, _port);

                Mysocket.Bind(endPoint);

                Mysocket.Listen(int.MaxValue);
                P.i("FK服务器启动成功，IP:" + Mysocket.LocalEndPoint.ToString());

                Thread thread = new Thread(ListenClientConnect);
                thread.Start();

                System.Timers.Timer t = new System.Timers.Timer(20000);   //实例化Timer类，设置间隔时间为10000毫秒；   
                t.Elapsed += new System.Timers.ElapsedEventHandler(CheckBeat); //到达时间的时候执行事件；   
                t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
                t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
                t.Start();


            }
            catch (Exception ex)
            {

            }
        }
        private void ListenClientConnect()
        {
            try
            {
                while (true)
                {
                    //Socket创建的新连接
                    Socket clientSocket = Mysocket.Accept();
                    clientSocket.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);
                    //clientSocket.Send(Encoding.UTF8.GetBytes("服务端发送消息:"));
                    Thread thread = new Thread(ReceiveMessage);
                    P.i("收到新的客户端连接，IP为"+clientSocket.RemoteEndPoint.ToString());
                    thread.Start(clientSocket);
                }
            }
            catch (Exception)
            {
            }
        }
        private void ReceiveMessage(object socket)
        {
            Socket clientSocket = (Socket)socket;
            while (true)
            {
                try
                {
                    int length = clientSocket.Receive(buffer);
                    if (Encoding.UTF8.GetString(buffer, 0, length) == "")
                    {
                        return;
                    }
                    P.d("接收到客户端:"+ clientSocket.RemoteEndPoint.ToString()+"的消息:"+ Encoding.UTF8.GetString(buffer, 0, length));
                    DataHandel.Handle(clientSocket,buffer, length);
                    P.d(length.ToString());
                }
                catch (Exception ex)
                {
                    CheckinSocket();
                    P.e(ex.Message);
                    clientSocket.Close();
                    break;
                }
            }
        }

        public SocketData FindSocketDataBySocket(Socket socket)
        {
            int co = 0;
            SocketData data = null;
            foreach (SocketData item in client_List)
            {
                if (item.socket.Equals(socket))
                {
                    co++;
                    data = item;
                }
            }
            if(co == 1)
            {
                P.d("成功从Socket寻找到SocketData");
                return data;
            }
            else if(co == 0)
            {
                P.w("没有从Socket中遍历到SocketData");
                return null;
            }
            else
            {
                P.e(" FindSocketDataBySocket中遍历到多个SocketData");
                return data;
            }

        }
        public void SendMessage(Socket socket,List<string> data)
        {
            if(socket == null)
            {
                return;
            }
            string mes = "";
            foreach (string item in data)
            {
                mes += item;
                mes += "|";
            }
            try
            {
                socket.Send(Encoding.UTF8.GetBytes(mes));
            }
            catch (Exception e)
            {
                CheckinSocket();
                P.e(e.Message);
                throw;
            }

        }

        public void BroadcastMessage(List<string> data)
        {
            foreach (SocketData item in client_List)
            {
                SendMessage(item.socket, data);
            }
        }

        public void SendMessageToMaster(List<string> data)
        {
            if (masterClient != null && masterClient.Connected == true)
            {
                SendMessage(masterClient, data);
            }
        }

        public void AddClientToList(Socket socket)
        {
           SocketData socketData = new SocketData(socket);
            client_List.Add(socketData);
        }
        public void SetMasterServer(Socket socket)
        {
            masterClient = socket;
        }
        public void CheckBeat(object source, System.Timers.ElapsedEventArgs e)
        {
            P.d("检测心跳");
            for (int i = 0; i < client_List.Count; i++)
            {
                if(client_List[i].socket == null || client_List[i].socket.Connected == false)
                {
                    client_List.Remove(client_List[i]);
                    return;
                }
                TimeSpan ts = DateTime.UtcNow - client_List[i].lastHeatTime;
                if (ts.TotalSeconds >= 20)
                {
                    P.w(client_List[i].socket.RemoteEndPoint.ToString() + "掉线");
                    client_List[i].socket.Shutdown(SocketShutdown.Both);
                    client_List[i].socket.Close();

                    client_List.Remove(client_List[i]);
                }

            }
        }
        public void CheckinSocket()
        {
            for (int i = 0; i < client_List.Count; i++)
            {
                if (client_List[i] == null || client_List[i].socket.Connected != true)
                {
                    P.w("客户端发生断开");
                    client_List.RemoveAt(i);
                }
                if (masterClient == null || masterClient.Connected != true)
                {
                    P.w("管理器脱离连接");
                    masterClient = null;
                }
            }
        }

    }
}
