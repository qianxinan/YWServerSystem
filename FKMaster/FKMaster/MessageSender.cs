using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKMaster
{
    public static class MessageSender
    {
        public static void SendMessage(string mes)
        {
            List<string> vs = new List<string>();
            vs.Add("SendMessage");
            vs.Add("Broadcast");
            vs.Add(mes);
            FKFrom1.socketMaster.SendMessage(vs);
        }
        public static void SetMouse(int x,int y)
        {
            List<string> vs = new List<string>();
            vs.Add("SetMouse");
            vs.Add(x.ToString());
            vs.Add(y.ToString());
            FKFrom1.socketMaster.SendMessage(vs);
        }
    }
}
