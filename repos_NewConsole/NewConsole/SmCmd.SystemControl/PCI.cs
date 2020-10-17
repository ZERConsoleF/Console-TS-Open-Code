using ConsoleG.Core.net;
using RunLCJVM;
using SmCmd.SystemControl;
using SmPro.System;
using SmProPub.MakeRun;
using SmProPub.Window.Forms.UsersControl;
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
            string vc = SmPro.System.System.GetSystemLoad(sender);

            if (vc == "getcmd")
            {
                new RegeditCmd().RunInGet.AddRange(new RunCommandTo[] { new ExitSystem(), new FindWindow(), new Reboot() });
                new RegeditCmdServer().RunInGet.AddRange(new RunCommandToServer[] { new ServerExitSystem(),new ServerReboot() });
;
            }

            return new object[] { 0 };
        }
    }
}
