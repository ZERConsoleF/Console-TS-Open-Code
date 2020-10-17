using ConsoleG.Network.InShowClient;
using ConsoleG.Network.InShowServer;
using ConsoleG.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    public class ServerUserBack : RunAtAdd
    {
        public Exception BackException { get; set; }
        public SenderClassForm BackSenderClass { get; set; }

        public string ClassName()
        {
            return "userback";
        }

        public void Execute(NewConsoleNetSr sr, ServerSenderOveEvent s, SenderClassForm f)
        {
            ServerLogUp l = sr.ServerBindAbout;
            f.SuccessRuned = true;
            f.GetBytes = Class<ServerLogUp>.Serialize(l);
            BackSenderClass = f;
        }
    }
}
