using RunLCJVM;
using RunLCJVM.ServerStart;
using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmCmd.SystemControl
{
    public class ServerExitSystem : RunCommandToServer
    {
        public Exception Exception(int ex)
        {
            return new Exception("未知错误");
        }

        public int Execute(string arg, SeeModsConsoleRunServer r, object obj)
        {
            r.Shutdown();
            /*
            if (r.args.Server)
            {
                r.SeverShutdown();
                r.thisthread.Resume();
                return 0;
            }
            new Thread(() => { Thread.Sleep(1200); cw.ConsoleWriteLine("Close!"); r.mi.Close(); }).Start();
            cw.FortText = Color.Red;
            cw.ConsoleWriteLine("Close Window");
            */
            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            return new string[] { "Exit the System" };
        }

        public string RunCommand()
        {
            return "exit";
        }
    }
}
