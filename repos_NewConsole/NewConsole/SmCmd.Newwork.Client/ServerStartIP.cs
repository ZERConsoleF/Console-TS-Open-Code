using ConsoleG.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.Newwork.Server
{
    public class ServerStartIP
    {
        public ServerStartIP()
        {
            IPStart = "127.0.0.1";
            ServerLogUpUserControl = new ServerLogUp();
        }
        public string IPStart { get; set; }
        public string Port { get; set; }
        public ServerLogUp ServerLogUpUserControl { get; set; }
        public int ListernNumber { get; set; }
        public int WaitContiue { get; set; }
        public int WaitTime { get; set; }
    }
}
