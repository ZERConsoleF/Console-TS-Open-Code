using ConsoleG.Core.com;
using ConsoleG.Core.com.setting;
using RunLCJVM.ServerStart;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerNewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = SmProConst.GetThreadMainName;
            UtilPrintf p = new UtilPrintf(null);
            p.StartLinster();
            p.StartWrite();

            UtilPrintf.Printf(UtilControl.Info, ref p, FanYi.frome("console.start.str", null));
            ServerLoadStatic io = new ServerLoadStatic(args, ref p);
            UtilPrintf.Printf(UtilControl.Info, ref p, FanYi.frome("console.start.win", null));

            Thread.Sleep(1000);

            new SeeModsConsoleRunServer(io.argf, ref p);
            p.Stopping();

            Console.WriteLine(FanYi.frome("exit", null));
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
