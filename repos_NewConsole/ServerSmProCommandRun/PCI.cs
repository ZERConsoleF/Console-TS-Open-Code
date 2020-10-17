using ConsoleG.Core.com;
using ConsoleG.Core.net;
using ConsoleG.Core.net.RunExct;
using RunLCJVM.ServerStart;
using SmPro.System;
using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class PCI
    {
        static string NameLoad = "CmdRP";
        public static object[] Main(object[] sender, string arg)
        {
            string vc = SmPro.System.SystemServer.GetSystemLoad(sender);
            if (vc == "load")
            {
                LoadInfoClass ft = new LoadInfoClass();
                ft.ShowName = "CR";
                ft.NameLoad = NameLoad;
                ft.Package = "Helper";
                ft.Versign = "V1.0.0";
                ft.Copyright = "Copyright (C) SeeMods 2020";
                return new object[] { 0, ft };
            }
            SeeModsConsoleRunServer fg = SmPro.System.SystemServer.GetSystemRun(sender);
            fg.ShowRunFTAConsole = false;
            if (vc == "load")
            {
                LoadInfoClass ft = new LoadInfoClass();
                ft.ShowName = "Sever Command";
                ft.NameLoad = NameLoad;
                ft.Package = "cmd";
                ft.Versign = "V1.0.0";
                ft.Copyright = "Copyright (C) SeeMods 2020";
                return new object[] { 0, ft };
            }
            if (vc == "sever-loading")
            {
                setsave(fg, arg);
                //return new object[] { 0, "getmf", File.ReadAllLines("CmdReg/l.ini"), "getcmdf", setsave(fg.cps, fg, arg) };
            }
            /*if (vc == "runload")
            {
                setsave(fg, arg);
                    foreach (string g in File.ReadAllLines("CmdReg/l.ini"))
                    {
                        bool v = fg.ShowRunFTAConsole;
                        fg.ShowRunFTAConsole = false;
                        string[] fp = fg.cps;
                        //ConsoleShowWindow p = sender[4] as ConsoleShowWindow;

                        string[] h = g.Split(' ');
                        string ht = string.Empty;

                        for (int x = 1; x < h.Length; x++)
                        {
                            ht += h[x] + " ";
                        }


                        if (getsp(fp, fg, ht, h[0], sender))
                            goto F;

                        //p.FortText = Color.Red;
                        Console.WriteLine("The command not find,please use \"help\" can help you -->" + sender[3].ToString());
                    //UtilPrintf.Printf(UtilControl.Error, ref fg.p, "The command not find,please use \"help\" can help you -->" + sender[3].ToString());
                    F:
                        fg.ShowRunFTAConsole = v;
                    }
                /*
                string[] fr = new string[0];
                RunLoct rp = fg.lcass[fg.IndexBackSp(NameLoad)];
                foreach (object rt in rp.save.ToArray())
                {
                    object[] up = (object[])rt;
                    if (up[1].ToString() == "getmf")
                    {
                        fr = (string[])up[2];
                    }
                }
                string[] fp = fg.cps;
                ConsoleShowWindow p = sender[4] as ConsoleShowWindow;
                object c = fg.SaveObject;

                foreach (string v4 in fr)
                {
                    string[] arg4 = v4.Split(' ');
                    string h = string.Empty;

                    for (int x = 1; x < arg4.Length; x++)
                    {
                        h += arg4[x] + " ";
                    }
                    if (getsp(fp, p, fg, h, arg4[0], sender))
                        goto F;
                    p.FortText = Color.Red;
                    p.ConsoleWriteLine("The command not find,please use \"help\" can help you -->" + v4);
                F:;
                }

                fg.SaveObject = c;
                
            }
        */
            if (vc == "run")
            {
                bool v = fg.ShowRunFTAConsole;
                fg.ShowRunFTAConsole = false;
                string[] fp = fg.cps;
                //ConsoleShowWindow p = sender[4] as ConsoleShowWindow;

                if (getsp(fp, fg, arg, sender[3].ToString(), sender))
                    goto F;

                //p.FortText = Color.Red;
                Console.WriteLine("The command not find,please use \"help\" can help you -->" + sender[3].ToString());
            //UtilPrintf.Printf(UtilControl.Error, ref fg.p, "The command not find,please use \"help\" can help you -->" + sender[3].ToString());
            F:
                fg.ShowRunFTAConsole = v;
            }
            return new object[] { 0 };
        }
        public static void setsave(SeeModsConsoleRunServer fg, string arg)
        {
            foreach (string fw in fg.cps)
            {
                fg.RunFTA(fw, "getcmd", arg, "cmd", out RunLoct l);
            }
            foreach (string fw in fg.systemcps)
            {
                fg.RunFTA(fw, "getcmd", arg, "cmd", out RunLoct l);
            }
        }

        public static bool getsp(string[] fp, SeeModsConsoleRunServer fg, string arg, string v, object[] sender, params object[] obk)
        {
            /*
            List<object[]> fw7 = new List<object[]>();
            List<RunCommandTo[]> cv = new List<RunCommandTo[]>();
            RunLoct rp = fg.lcass[fg.IndexBackSp(NameLoad)];
            object[] rtt = new object[0];
            foreach (object rt in rp.save.ToArray())
            {
                object[] up = (object[])rt;
                if (up.Length < 4)
                    continue;
                if (up[3].ToString() == "getcmdf")
                {
                    rtt = (object[])up[4];
                }
            }
            foreach (object fw in rtt)
            {
                object[] f8 = (object[])fw;
                fw7.Add(f8);
                cv.Add((f8[1] as object[])[1] as RunCommandTo[]);
            }
            foreach (object[] f in RegeditCmd.GetIndexl)
            {
                object[] h = f[1] as object[];
                if (h[1] is RunCommandTo[])
                {
                    RunCommandTo[] sv = (h[1] as RunCommandTo[]);
                    foreach (RunCommandTo fq in sv)
                    {
                        //Console.WriteLine();
                        if (fq.RunCommand() == v)
                        {
                            p.ShowText.ReadOnly = true;
                            int x = fq.Execute(arg, fg, p, new object[] { cv.ToArray(), sender, obk });
                            if (x != 0)
                            {
                                Exception ex = fq.Exception(x);
                                p.ConsoleWriteLine(ex.ToString());
                            }

                            p.ShowText.ReadOnly = false;
                            return true;
                        }
                    }
                }
            }
            */
            if (RegeditCmdServer.GetIndexl != null)
            {
                List<RunCommandToServer> t = new List<RunCommandToServer>();
                foreach (RegeditCmdServer cdf in RegeditCmdServer.GetIndexl)
                    foreach (RunCommandToServer fq in cdf.RunInGet.ToArray())
                    {
                        t.Add(fq);
                    }
                foreach (RunCommandToServer fq in t.ToArray())
                {
                    //Console.WriteLine();
                    if (fq.RunCommand() == v)
                    {
                        //p.ShowText.ReadOnly = true;
                        int x = fq.Execute(arg, fg, new object[] { t.ToArray(), sender, obk });
                        if (x != 0)
                        {
                            Exception ex = fq.Exception(x);
                            Console.WriteLine(ex.ToString());
                        }

                        //p.ShowText.ReadOnly = false;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
