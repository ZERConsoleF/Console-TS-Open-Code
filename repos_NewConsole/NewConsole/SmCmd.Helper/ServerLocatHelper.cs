using RunLCJVM.ServerStart;
using SmPro.System;
using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.Helper
{
    public class ServerLocatHelper : RunCommandToServer
    {
        public Exception Exception(int ex)
        {
            return new Exception("Not yet!About :" + ex);
        }

        public int Execute(string arg, SeeModsConsoleRunServer r, object obj)
        {
            arg = arg.Trim();
            if (arg.Length == 0)
            {
                try
                {
                    string[] libe = File.ReadAllLines("CmdReg/h.ini");
                    foreach (string fp in libe)
                    {
                        //cw.FortText = Color.Yellow;
                        Console.WriteLine(fp);
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
                if (RegeditCmdServer.GetIndexl != null)
                    foreach (RegeditCmdServer cf in RegeditCmdServer.GetIndexl)
                        foreach (RunCommandToServer pc in cf.RunInGet.ToArray())
                        {
                            if (p[0] == pc.RunCommand())
                            {
                                string[] cv = pc.HelpCommand(h);
                                //cw.FortText = Color.Yellow;
                                Console.WriteLine("About help -->" + pc.RunCommand());
                                foreach (string p4 in cv)
                                {
                                    //cw.FortText = Color.White;
                                    Console.WriteLine(p4);
                                }
                                break;
                            }
                        }
            }
            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            return new string[] { "关于组件help:", "无提示" };
        }

        public string RunCommand()
        {
            return "help";
        }
    }
}
