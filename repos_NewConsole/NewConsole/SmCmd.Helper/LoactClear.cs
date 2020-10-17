using RunLCJVM;
using SmProPub.MakeRun;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.Helper
{
    public class LoactClear : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            return new Exception();
        }

        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            cw.ConsoleClear();
            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            return new string[] { "clear screen" };
        }

        public string RunCommand()
        {
            return "clear";
        }
    }
}
