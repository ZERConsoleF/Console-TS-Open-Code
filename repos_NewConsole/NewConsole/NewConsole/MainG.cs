using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleG.Core.com.setting;
using SmProPub;
using RunLCJVM;
using System.Threading;
using ConsoleG.Core.com;

namespace NewConsole
{
    class MainG
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = SmProConst.GetThreadMainName;
            UtilPrintf p = new UtilPrintf(null);
            p.StartLinster();
            p.StartWrite();

            UtilPrintf.Printf(UtilControl.Info, ref p, FanYi.frome("console.start.str",null));
            LoadStatic io = new LoadStatic(args, ref p);
            UtilPrintf.Printf(UtilControl.Info, ref p, FanYi.frome("console.start.win",null));

            Thread.Sleep(1000);

            new SeeModsConsoleRun(io.argf,ref p);
            p.Stopping();

            Console.WriteLine(FanYi.frome("exit",null));
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
