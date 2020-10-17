using ConsoleG.Core.net;
using OpenCatLc;
using RunLCJVM.ServerStart;
using SmPro.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    public class PCI
    {
        public static object[] Main(object[] sender, string arg)
        {
            string ve = SmPro.System.SystemServer.GetSystemLoad(sender);
            SeeModsConsoleRunServer r = SmPro.System.SystemServer.GetSystemRun(sender);

            if (ve == "load")
            {
                LoadInfoClass ft = new LoadInfoClass();
                ft.ShowName = "Open Server cmd";
                ft.NameLoad = "Server Regedit";
                ft.Package = "runcmd";
                ft.Versign = "V1.0.0";
                ft.Copyright = "Copyright (C) SeeMods 2020";
                return new object[] { 0, ft };
            }

            if (ve == "sever-loading")
            {
                ConsoleControlPCER rty = new ConsoleControlPCER(null);
                rty.ConsoleShowWrite = "[C#] : ";
                rty.ChangeThread(new Thread(() => {
                    while (!r.FinishLoadMemory) ;
                    while (true)
                    {
                        Console.Write(rty.ConsoleShowWrite);
                        string rt = Console.ReadLine();
                        RunCommandSerdServer.RunCommand(rt, false);
                    }
                }));
                rty.Name = "Main";
                rty.GetThread.Start();
            }

            return new object[] { 0 };
        }
    }
}
