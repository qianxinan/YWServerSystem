using System;
using System.Collections.Generic;
using System.Text;

namespace FKServer
{
    public  static class ServerMain
    {
        public static SocketServer server;
        private static void Main(string[] args)
       {

            server = new SocketServer(2721);
            server.StartListen();

            while (true)
            {
                CommandHandel.Handel(Console.ReadLine());
            }
        }
    }
}
