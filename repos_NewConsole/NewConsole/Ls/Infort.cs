using ConsoleG.Core.com.setting;
using RunLCJVM;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ls
{
    public class Infort
    {
        public void rk(ref UtilPrintf p,LoadStatic oi)
        {
            UtilPrintf.Printf(UtilControl.Info, ref p, FanYi.frome("console.start.win",null));
            new SeeModsConsoleRun(oi.argf,ref p);
        }
    }
}
