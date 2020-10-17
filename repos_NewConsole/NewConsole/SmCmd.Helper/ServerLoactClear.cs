using RunLCJVM;
using RunLCJVM.ServerStart;
using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.Helper
{
    public class ServerLoactClear : RunCommandToServer
    {
        public Exception Exception(int ex)
        {
            return new Exception();
        }

        public int Execute(string arg, SeeModsConsoleRunServer r, object obj)
        {
            Console.Clear();
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
