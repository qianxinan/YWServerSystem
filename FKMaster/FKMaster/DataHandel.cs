using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FKMaster
{
    public static class  DataHandel
    {
        public static void Handel(string mes)
        {
            string[] data = mes.Split('|');
            //Console.WriteLine();
            switch (data[0])
            {
                case "Welcome":
                    Welcome(data);
                    break;
                case "SetMouse":
                    SetMouse(data);
                    break;
                default:
                    MessageBox.Show("收到了未知的协议:{0}", mes);
                    break;
            }
        }
        public static void Welcome(string[] data)
        {
            if(data[1].Equals("Success"))
            {
                MessageBox.Show("服务器相互连接已经建立");
            }
        }
        private static void SetMouse(string[] data)
        {
            MouseSetter.MoveMouseToPoint(new Point(int.Parse(data[1]),int.Parse(data[2])));
        }
    }
}
