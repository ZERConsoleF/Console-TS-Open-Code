using ConsoleG.Core.net.RunExct;
using RunLCJVM.ServerStart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCatLc
{
    /// <summary>
    /// 执行命令
    /// </summary>
    public static class RunCommandSerdServer
    {
        /*
        /// <summary>
        /// 初始化命令注册
        /// </summary>
        /// <param name="p"></param>
        /// <param name="r"></param>
        public static void Start(ConsoleShowWindow p, SeeModsConsoleRunServer r)
        {
            object[] y9 = r.RunFTA(r.args.extr + "/cmd", "runload", null, "ConsoleTc", null, p);
            if (y9.Length > 0)
                if (y9[0] is Exception)
                {
                    //p.FortText = Color.Red;
                    p.ConsoleWriteLine("Exception : for " + (y9[0] as Exception).ToString());
                }
        }
        */
        /// <summary>
        /// 运行指令
        /// </summary>
        /// <param name="r"></param>
        /// <param name="y"></param>
        /// <param name="sender"></param>
        public static bool RunCommand(string sender,bool hasendon)
        {
            //bool hasre = y.ReadText;
            //y.ReadText = false;
            SeeModsConsoleRunServer r = SeeModsConsoleRunServer.GetainClass;
            if (sender.ToString().Trim() == "")
            {
                
                if (hasendon)
                    Console.Write("[C#] : ");
                //y.ReadText = hasre;
                
                return false;
            }

            string[] p = (sender as string).Split(' ');
            string h = string.Empty;

            for (int x = 1; x < p.Length; x++)
            {
                h += p[x] + " ";
            }
            Console.WriteLine("\r\nRun Cmd : " + p[0]);
            r.ShowRunFTAConsole = false;

            object[] y9 = r.RunFTA(r.args.sextr + "/cmd", "run", h, "ConsoleTc", out RunLoct l, p[0]);
            if (y9.Length > 0)
                if (y9[0] is Exception)
                {
                    //y.FortText = Color.Red;
                    Console.WriteLine("Exception : for " + (y9[0] as Exception).ToString());
                    return false;
                }

            //y.ShowText.SelectionColor = Color.Green;
            if (hasendon)
                Console.Write("\r\n[C#] : ");
            //y.ReadText = hasre;
            return true;
        }
    }
}
