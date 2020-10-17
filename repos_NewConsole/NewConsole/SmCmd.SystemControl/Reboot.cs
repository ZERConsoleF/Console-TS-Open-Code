using RunLCJVM;
using SmProPub;
using SmProPub.MakeRun;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.SystemControl
{
    public class Reboot : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            return new SmException("执行出现错误，可能已经输出");
        }
        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            try
            {
                Process.Start("NewConsole.exe", Environment.CommandLine);
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                cw.FortText = Color.Red;
                cw.ConsoleWriteLine(ex.Message);
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
