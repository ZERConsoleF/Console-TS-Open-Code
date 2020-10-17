using RunLCJVM;
using RunLCJVM.ServerStart;
using SmProPub;
using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.SystemControl
{
    public class ServerReboot : RunCommandToServer
    {
        public Exception Exception(int ex)
        {
            return new SmException("执行出现错误，可能已经输出");
        }
        public int Execute(string arg, SeeModsConsoleRunServer r, object obj)
        {
            try
            {
                Process.Start("ServerNewConsole.exe", Environment.CommandLine);
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                //cw.FortText = Color.Red;
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            return new string[] { "重启软件" };
        }

        public string RunCommand()
        {
            return "reboot";
        }
    }
}
