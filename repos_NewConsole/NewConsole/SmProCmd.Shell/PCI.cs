using ConsoleG.Core.net;
using RunLCJVM;
using SmPro.System;
using SmProCmd.Shell;
using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class PCI
    {
        public static object[] Main(object[] sender, string arg)
        {
            SeeModsConsoleRun r = SmPro.System.System.GetSystemRun(sender);
            string load = SmPro.System.System.GetSystemLoad(sender);
            if (load == "load")
            {
                LoadInfoClass ft = new LoadInfoClass();
                ft.ShowName = "Shell";
                ft.NameLoad = "SmPro.cmd.shell";
                ft.Package = "Shell";
                ft.Versign = "V1.0.0";
                ft.Copyright = "Copyright (C) SeeMods 2020";
                return new object[] { 0, ft };
            }
            if (load == "getcmd")
            {
                new RegeditCmd().RunInGet.AddRange(new RunCommandTo[] { new Shell() });
            }
            return new object[] { 0 };
        }
    }
}
