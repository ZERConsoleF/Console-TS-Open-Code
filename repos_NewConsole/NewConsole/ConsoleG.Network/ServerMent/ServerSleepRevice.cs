using ConsoleG.Network.InShowClient;
using ConsoleG.Network.InShowServer;
using ConsoleG.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    public class ServerSleepRevice : RunAtAdd
    {
        public Exception BackException { get; set; }
        public SenderClassForm BackSenderClass { get; set; }

        public string ClassName()
        {
            return "sleeprv";
        }

        public void Execute(NewConsoleNetSr sr, ServerSenderOveEvent s, SenderClassForm f)
        {
            Thread.Sleep(int.Parse(f.GetRun));
        }
    }
}
