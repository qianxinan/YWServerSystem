using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FKClient
{

    public class SocketClient
    {
        public Socket mySocket = null;
        //private string _ip = "120.26.67.210";
        private string _ip = "127.0.0.1";
        private int _port = 2721;
        private bool isSendDesktop = true;
        public void Connect()
        {
            try
            {
                mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress address = IPAddress.Parse(_ip);
                IPEndPoint endPoint = new IPEndPoint(address, _port);
                mySocket.Connect(endPoint);
                Thread th = new Thread(ReceiveMsg);
                th.Start();                             
                List<string> data = new List<string>();
                data.Add("Hello");
                data.Add("Client");
                SendMessage(data);

                Thread th_Desktop = new Thread(new ThreadStart(SendDesktop));
                th_Desktop.IsBackground = true;

                System.Timers.Timer t = new System.Timers.Timer(10000);   //实例化Timer类，设置间隔时间为10000毫秒；   
                t.Elapsed += new System.Timers.ElapsedEventHandler(SendBeat); //到达时间的时候执行事件；   
                t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
                t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
                t.Start();

               
            }
            catch (Exception)
            {
                Connect();
            }
        }

        public void SendMessage(List<string> data)
        {
            string mes = "";
            foreach (string item in data)
            {
                mes += item;
                mes += "|";
            }
            try
            {
                mySocket.Send(Encoding.UTF8.GetBytes(mes));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Connect();
                //throw;
            }

        }

        void ReceiveMsg()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int n = mySocket.Receive(buffer);
                    string s = Encoding.UTF8.GetString(buffer, 0, n);
                    if(s == "")
                    {
                        return;
                    }
                   
                    DataHandel.Handel(s);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Connect();
                    break;

                }

            }
        }
        private void SendDesktop()
        {
            try
            {
                while (isSendDesktop)
                {
                    MemoryStream ms = new MemoryStream();
                    DesktopSetter.GetScreenCapture().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    List<string> sendData= new List<string>();
                    byte[] b = ms.ToArray();
                    sendData.Add("Desktop");
                    sendData.Add(b.ToString());
                    SendMessage(sendData);
                    Thread.Sleep(1000);//我这里设置1秒发送一次
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }
        }
        public void SendBeat(object source, System.Timers.ElapsedEventArgs e)
        {
            List<string> vs = new List<string>();
            vs.Add("Beat");
            SendMessage(vs);
        }
    }
}
