using SmProPub.MakeRun;
using ConsoleG.Core.com;
using ConsoleG.Core.net;
using RunLCJVM;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ConsoleG.Core.net.RunExct;
using SmProPub;
using SmPro.System;

namespace Main
{
    public class PCI
    {
        static string NameLoad = "CmdRP";
        public static object[] Main(object[] sender, string arg)
        {
            string vc = SmPro.System.System.GetSystemLoad(sender);
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
            SeeModsConsoleRun fg = SmPro.System.System.GetSystemRun(sender);
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
            if (vc == "loading")
            {
                //return new object[] { 0, "getmf", File.ReadAllLines("CmdReg/l.ini"), "getcmdf", setsave(fg.cps, fg, arg) };
            }
            if (vc == "runload")
            {
                setsave(fg, arg);
                if (!fg.args.Server)
                    foreach (string g in File.ReadAllLines("CmdReg/l.ini"))
                    {
                        bool v = fg.ShowRunFTAConsole;
                        fg.ShowRunFTAConsole = false;
                        string[] fp = fg.cps;
                        ConsoleShowWindow p = sender[4] as ConsoleShowWindow;

                        string[] h = g.Split(' ');
                        string ht = string.Empty;

                        for (int x = 1; x < h.Length; x++)
                        {
                            ht += h[x] + " ";
                        }


                        if (getsp(fp, p, fg, ht, h[0], sender))
                            goto F;

                        p.FortText = Color.Red;
                        p.ConsoleWriteLine("The command not find,please use \"help\" can help you -->" + sender[3].ToString());
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
                */
            }
            if (vc == "run")
            {
                bool v = fg.ShowRunFTAConsole;
                fg.ShowRunFTAConsole = false;
                string[] fp = fg.cps;
                ConsoleShowWindow p = sender[4] as ConsoleShowWindow;

                if (getsp(fp, p, fg, arg, sender[3].ToString(), sender))
                    goto F;

                p.FortText = Color.Red;
                p.ConsoleWriteLine("The command not find,please use \"help\" can help you -->" + sender[3].ToString());
            //UtilPrintf.Printf(UtilControl.Error, ref fg.p, "The command not find,please use \"help\" can help you -->" + sender[3].ToString());
            F:
                fg.ShowRunFTAConsole = v;
            }

            return new object[] { 0 };
        }
        public static void setsave(SeeModsConsoleRun fg,string arg)
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
        
        public static bool getsp(string[] fp, ConsoleShowWindow p, SeeModsConsoleRun fg, string arg, string v, object[] sender, params object[] obk)
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
            if (RegeditCmd.GetIndexl != null)
            {
                List<RunCommandTo> t = new List<RunCommandTo>();
                foreach (RegeditCmd cdf in RegeditCmd.GetIndexl)
                    foreach (RunCommandTo fq in cdf.RunInGet.ToArray())
                    {
                        t.Add(fq);
                    }
                foreach (RunCommandTo fq in t.ToArray())
                {
                    //Console.WriteLine();
                    if (fq.RunCommand() == v)
                    {
                        p.ShowText.ReadOnly = true;
                        int x = fq.Execute(arg, fg, p, new object[] { t.ToArray(), sender, obk });
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
            return false;
        }
    }
}
