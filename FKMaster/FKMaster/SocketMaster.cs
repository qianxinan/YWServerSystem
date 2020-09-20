using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FKMaster
{

    public class SocketMaster
    {
        public Socket mySocket = null;
        private string _ip = "120.26.67.210";
        private int _port = 2721;
        public void Connect()
        {
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(_ip);
            IPEndPoint endPoint = new IPEndPoint(address, _port);
            mySocket.Connect(endPoint);
            Thread th = new Thread(ReceiveMsg);
            th.Start();

            List<string> data = new List<string>();
            data.Add("Hello");
            data.Add("Master");
            SendMessage(data);
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
                throw;
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

                   
                    DataHandel.Handel(s);

                }

                catch (Exception ex)

                {

                    MessageBox.Show(ex.Message);

                    break;

                }

            }
        }
    }
}
