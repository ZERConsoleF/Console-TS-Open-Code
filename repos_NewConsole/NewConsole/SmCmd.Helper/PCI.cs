using ConsoleG.Core.net;
using SmPro.System;
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
        public static object[] Main(object[] sender,string arg)
        {
            string litxt = SmPro.System.System.GetSystemLoad(sender);
            if (litxt == "load")
            {
                LoadInfoClass ft = new LoadInfoClass();
                ft.ShowName = "RS";
                ft.NameLoad = "CmdRP";
                ft.Package = "Helper";
                ft.Versign = "V1.0.0";
                ft.Copyright = "Copyright (C) SeeMods 2020";
                return new object[] { 0, ft };
            }
            if (litxt == "getcmd")
            {
                new RegeditCmd().RunInGet.AddRange(new RunCommandTo[] { new SmCmd.Helper.LocatHelper(), new SmCmd.Helper.LoactClear() });
                new RegeditCmdServer().RunInGet.AddRange(new RunCommandToServer[] { new SmCmd.Helper.ServerLocatHelper(),new SmCmd.Helper.ServerLoactClear() });
            }
            return new object[] { 0 };
        }
    }
}
