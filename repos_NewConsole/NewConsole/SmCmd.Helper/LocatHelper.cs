using RunLCJVM;
using SmPro.System;
using SmProPub.MakeRun;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.Helper
{
    public class LocatHelper : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            return new Exception("Not yet!About :" + ex);
        }

        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            arg = arg.Trim();
            if (arg.Length == 0)
            {
                try
                {
                    string[] libe = File.ReadAllLines("CmdReg\\h.ini");
                    foreach (string fp in libe)
                    {
                        cw.FortText = Color.Yellow;
                        cw.ConsoleWriteLine(fp);
                    }
                }
                catch (Exception ex)
                {
                    return ex.HResult;
                }
            }
            if (arg.Length > 0)
            {
                string[] p = arg.Split(' ');
                string h = string.Empty;

                for (int x = 1; x < p.Length; x++)
                {
                    h += p[x] + " ";
                }
                if (RegeditCmd.GetIndexl != null)
                    foreach (RegeditCmd cf in RegeditCmd.GetIndexl)
                        foreach (RunCommandTo pc in cf.RunInGet.ToArray())
                        {
                            if (p[0] == pc.RunCommand())
                            {
                                string[] cv = pc.HelpCommand(h);
                                cw.FortText = Color.Yellow;
                                cw.ConsoleWriteLine("About help -->" + pc.RunCommand());
                                foreach (string p4 in cv)
                                {
                                    cw.FortText = Color.White;
                                    cw.ConsoleWriteLine(p4);
                                }
                                break;
                            }
                        }
            }
            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            return new string[] { "关于组件help:","无提示" };
        }

        public string RunCommand()
        {
            return "help";
        }
    }
}
