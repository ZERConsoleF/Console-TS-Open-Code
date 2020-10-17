using ConsoleG.Core.com;
using ConsoleG.Core.com.setting;
using ConsoleG.Core.net;
using ConsoleG.Core.net.RunExct;
using SmProPub;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunLCJVM.ServerStart
{
    /// <summary>
    /// 提供SeeMods Server启动
    /// </summary>
    public class SeeModsConsoleRunServer : ObjectClass<SeeModsConsoleRunServer>
    {
        public static SeeModsConsoleRunServer GetainClass { get; private set; }
        public GetServerArg args;
        //private List<ProcessNameMkst> po = new List<ProcessNameMkst>();
        public UtilPrintf p;
        private List<Thread> th = new List<Thread>();
        public string lauge;
        public Thread thisthread = Thread.CurrentThread;
        private List<RunLoct> ih = new List<RunLoct>();
        public string[] systemcps = new string[0];
        public string[] cps = new string[0];
        public bool FinishLoadMemory { get; private set; }
        public SeeModsConsoleRunServer(UtilPrintf p)
        {
            this.p = p;
            GetainClass = this;
        }
        public SeeModsConsoleRunServer(GetServerArg arg, ref UtilPrintf u)
        {
            this.p = u;
            this.args = arg;

            GetainClass = this;

            GC.KeepAlive(this);

                init();
        }
        public string Versign()
        {
            return "V1.0.0";
        }
        /// <summary>
        /// Server init memory
        /// </summary>
        public virtual void init()
        {
            try
            {
                SmProGC.ClearMemory();
                UtilPrintf.Printf(UtilControl.Warn, ref p, "[Sever] Sever Start");
                run = true;
                ShowRunFTAConsole = args.showextrinfo;
                //StartLoadAbout ut = new StartLoadAbout();
                //Thread th0 = new Thread(new ThreadStart(() => { Application.Run(ut); }));
                //th0.Start();
                //ut.LoadTextMessage.Text = "Wait Load System CP to memory";
                Thread.Sleep(1000);
                //ut.LoadTextMessage.Text = FanYi.frome("form.loadwindow.creat.maintitle", null) + args.CreatTitle;
                Thread.Sleep(1000);
                systemcps = new string[0];
                cps = new string[0];
                try
                {
                    systemcps = args.systemcp.ToArray();
                    cps = args.cp.ToArray();
                }
                catch (Exception ex)
                {
                    //ut.LoadTextMessage.Text = "Warning The Cp did't load,but is running";
                    UtilPrintf.Printf(UtilControl.Error, ref p, "[LoadInit /Thread] Exception message:" + ex.Message);
                }

                //ut.LoadTextMessage.Text = FanYi.frome("form.loadwindow.creat.mainwhli", null) + " x:" + args.weiht + " y:" + args.heigh;
                //UtilPrintf.Printf(UtilControl.Warn, ref p, FanYi.frome("form.loadwindow.creat.mainwhli", null) + " x:" + args.weiht + " y:" + args.heigh);

                //ut.LoadTextMessage.Text = "使用语言为:" + args.laugeAB;
                lauge = args.laugeAB;
                UtilPrintf.Printf(UtilControl.Warn, ref p, FanYi.frome("console.loadwindow.use.lauge", null) + " " + args.laugeAB);

                //ut.LoadTextMessage.Text = FanYi.frome("form.loadwindow.mainmax", lauge) + args.MaxWindow;
                //UtilPrintf.Printf(UtilControl.Warn, ref p, FanYi.frome("form.loadwindow.mainmax", lauge) + args.MaxWindow);
                //mi = new MainWindow(this);
                //ut.LoadTextMessage.Text = "Load About...(Use Console)";

                #region 注册是否有此路径更改

                List<string> regsyscp = new List<string>();
                foreach (string systemcp in systemcps)
                {
                    if (!Directory.Exists(systemcp))
                    {
                        if (Directory.Exists(args.sextr + "/" + systemcp))
                        {
                            regsyscp.Add(args.sextr + "/" + systemcp);
                            UtilPrintf.Printf(UtilControl.Warn, ref p, " [MakeArg] path " + systemcp + " to " + args.sextr + "/" + systemcp);
                        }
                        else
                        {
                            UtilPrintf.Printf(UtilControl.Error, ref p, " [MakeArg] path " + systemcp + " No find so remove it!");
                        }
                    }
                    else
                        regsyscp.Add(systemcp);
                }
                args.systemcp = regsyscp;

                List<string> regcp = new List<string>();
                foreach (string cp in cps)
                {
                    if (!Directory.Exists(cp))
                    {
                        if (Directory.Exists(args.sextr + "/" + cp))
                        {
                            regcp.Add(args.sextr + "/" + cp);
                            UtilPrintf.Printf(UtilControl.Warn, ref p, " [MakeArg] path " + cp + " to " + args.sextr + "/" + cp);
                        }
                        else
                        {
                            UtilPrintf.Printf(UtilControl.Error, ref p, " [MakeArg] path " + cp + " No find so remove it!");
                        }
                    }
                    else
                        regcp.Add(cp);
                }
                args.cp = regcp;

                #endregion

                systemcps = args.systemcp.ToArray();
                cps = args.cp.ToArray();

                Thread.Sleep(1000);

                //Load

                TaskListMG.AutoAdd("加载插件", "在Load中加载插件", null);

                #region
                List<RunLoct[]> fpolk = new List<RunLoct[]>();
                RunLoct[] fpi;
                List<object[][]> prto = new List<object[][]>();
                prto.Add(LoadALLCp(systemcps, "load", null, null, out fpi));
                fpolk.Add(fpi);
                prto.Add(LoadALLCp(cps, "load", null, null, out fpi));
                fpolk.Add(fpi);
                foreach (RunLoct[] tty in fpolk)
                    foreach (RunLoct lliu in tty)
                    {
                        lcass.Add(lliu);
                        foreach (object[][] yghj in prto)
                            if (yghj.Length > 0)
                            {
                                foreach (object[] objerty in yghj)
                                {
                                    if (objerty.Length > 0)
                                    {
                                        foreach (object rtyti in objerty)
                                        {
                                            if (rtyti is LoadInfoClass)
                                                lcinfo.Add(rtyti as LoadInfoClass);
                                        }
                                    }
                                }
                            }
                    }
                #endregion

                /*
                args.laugeAB = "en-us";
                new Rs().wreArgToMemory(args, SmProConst.GetMainArgName,SmProConst.GetMainMemoryName);
                CreativeMemoryty ty = new CreativeMemoryty(SmProConst.GetMainMemoryName);
                ty.Creativestr();
                Console.WriteLine(Encoding.Unicode.GetString(ty.returnAll()));
                */
                //mi.Size = new System.Drawing.Size(args.weiht, args.heigh);
                //mi.Location = new System.Drawing.Point(args.iw, args.ih);
                //ut.LoadTextMessage.Text = FanYi.frome("form.loadwindow.mainloadit", lauge);
                UtilPrintf.Printf(UtilControl.Info, ref p, FanYi.frome("form.loadwindow.mainloadit", null));
                //th.Add(th0);
                //th0 = null;
                Thread.Sleep(500);
                //mi.Size = new System.Drawing.Size(args.weiht, args.heigh);
                //mi.Location = new System.Drawing.Point(args.iw, args.ih);
                /*
                if (args.MaxWindow)
                {
                    mi.MaxsWindow();
                    mi.Location = new System.Drawing.Point(0, 0);
                }
                */

                //mi.Text = args.CreatTitle;
                //mi.lauge = lauge;

                //mi.WindowState = FormWindowState.Minimized;

                //ut.LoadTextMessage.Text = FanYi.frome("form.loadwindow.loadprocess", lauge);

                //loading
                TaskListMG.AutoAdd("加载插件", "在Sever-Loading中加载插件", null);

                LoadALLCp(systemcps, "sever-loading", null, null, out fpi);

                //mi.rc = this;
                /*

                foreach (ProcessNameMkst mkst in po.ToArray())
                {
                    mkst.poce.Start();
                    UtilPrintf.Printf(UtilControl.Warn, ref p, "Success Load the process " + mkst.Name);
                }
                */

                //ut.LoadTextMessage.Text = "Creative Menu Memory Loadt";

                /*
                CreativleMemorySetting set1 = new CreativleMemorySetting();
                set1.Class = SmProConst.GetMenuMemoryName;
                set1.size = 1024;
                set1.PD = false;

                CreativeMemoryty.CreativeMemory(ref p, set1);

                CreativeMemoryty tmenu = new CreativeMemoryty(SmProConst.GetMenuMemoryName);

                tmenu.Creativestr();

                tmenu.setValue(Encoding.Unicode.GetBytes(returnloadmenory()));
                tmenu.RunMake();
                */
                //ut.Close();

                //mi.md = po;

                //mi.ListMenuTs();
                //mi.WindowState = FormWindowState.Normal;
                //mi.CommentShow.Text = "SeeModsConsole活动完成,线程挂载";
                //mi.tc = thisthread;

                TaskListMG.AutoAdd("线程挂起", "休眠SeeModsConsoleRun发出的Thread", null);

                FinishLoadMemory = true;

                Thread.CurrentThread.Suspend();

                if (args.sleeption < 0)
                    return;

                int adse = args.sleeption;
                while (adse >= 0)
                {
                    string clort = "Close at " + adse;
                    Console.Write(clort);
                    foreach (char y in clort)
                        Console.Write("\b");
                    Thread.Sleep(1000);
                    adse--;
                }
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                throwex(ex);
            }
            Shutdown();
        }
        bool run = false;
        public void Shutdown()
        {
            if (!run)
                return;
            run = false;
            UtilPrintf.Printf(UtilControl.Warn, ref p, "正在运行Close插件方法");
            LoadALLCp(systemcps, "close", null, null, out RunLoct[] l);
            UtilPrintf.Printf(UtilControl.Warn, ref p, "Close Object");
            Dispose();
            thisthread.Resume();
        }
        /*
        public void Shutdown()
        {
            if (!run)
                return;
            run = false;
            mi.CommentShow.Text = "正在运行Close插件方法";
            LoadALLCp(systemcps, "close", null, null);
            mi.CommentShow.Text = "Close Object";
            Dispose();
        }
        */
        public override void Dispose()
        {
            SmProGC.ClearMemory();
            base.Dispose();
        }
        /*public string returnloadmenory()
        {
            /*
            LoadMenust of = new LoadMenust();
            of = new LoadMenust();

            // 文件 Regedit
            MenuCreat ct = new MenuCreat();
            ct.menuCreats = new List<MenuCreat>();
            ct.name = "menu.m1";
            ct.text = FanYi.frome(ct.name,lauge);

            // 文件下的所有子项引索
            MenuCreat ct1 = new MenuCreat();
            ct1.name = "menu.m1.l1";
            ct1.text = FanYi.frome(ct1.name,lauge);
            ct.menuCreats.Add(ct1);

            // Regedit
            of.cti = new List<MenuCreat>();
            of.cti.Add(ct);
            return JsonConvert.SerializeObject(of);
            
            GuiMenuList list = new GuiMenuList(lauge);
            // Regmenu1
            MenuCreat cy = list.returnSetMenu();
            cy.name = "menu.m1";
            cy.text = FanYi.frome(cy.name, lauge);
            list.setSetMenu(cy);
            LoadMenust std = new LoadMenust();
            List<MenuCreat> u = new List<MenuCreat>();
            MenuCreat ct;
            // reg1-1
            list.CreatReadPath("menu.m1.l1").BackList();
            // reg 1-2
            ct = list.CreatReadPath("menu.m1.l2").returnSetMenu();
            ct.underspite = true;
            list.setSetMenu(ct).BackList();
            // reg 1-3
            list.CreatReadPath("menu.m1.l3").BackList();
            // make
            MenuCreat c = list.ToArray();
            u.Add(c);
            std.cti = u;
            return JsonConvert.SerializeObject(std);
        }*/
        /// <summary>
        /// 当前的加载运行环境插件输出信息
        /// </summary>
        //public List<object[]> oc = new List<object[]>();
        /// <summary>
        /// 程序集的加载情况
        /// </summary>
        public List<RunLoct> lcass = new List<RunLoct>();
        /// <summary>
        /// 程序集的注册情况
        /// </summary>
        public List<LoadInfoClass> lcinfo = new List<LoadInfoClass>();

        public string CpArg(string[] ag, string fileorname)
        {
            string ylp4 = null;
            foreach (string jpr in ag)
            {
                MakeArggi aig = new MakeArggi();
                aig.run(ag, 0, '-', ':');
                ylp4 = aig.returnTi(fileorname);
            }

            return ylp4;
        }

        public object[][] LoadALLCp(string[] cps, string yb, string arg, string pasf, out RunLoct[] lcl, params object[] argp)
        {
            List<object[]> onbhrt = new List<object[]>();
            List<RunLoct> tryo = new List<RunLoct>();
            UtilPrintf.Printf(UtilControl.Info, ref p, "{0}[", yb);
            foreach (string jk in cps)
            {
                string yu = null;
                if (arg == null)
                {
                    string[] up = jk.Split('/');
                    yu = CpArg(args.exrarg, up[up.Length - 1]);
                }
                else
                    yu = arg;
                RunLoct loui;
                onbhrt.Add(RunFTA(jk, yb, yu, pasf, out loui, argp));
                tryo.Add(loui);
            }
            UtilPrintf.Printf(UtilControl.Info, ref p, "] * {0}", yb);
            lcl = tryo.ToArray();
            return onbhrt.ToArray();

            /*
            foreach (string sy in cps)
            {
                ProcessNameMkst n = new ProcessNameMkst();

                Process p = new Process();

                if (!File.Exists(sy + "\\Main.exe"))
                {
                    UtilPrintf.Printf(UtilControl.Error,ref this.p,"[LoadProgram] " + sy +" " + FanYi.frome("console.loadprogram.nomain",lauge));
                    goto G;
                }
                UtilPrintf.Printf(UtilControl.Info,ref this.p ,"[LoadProcess] Registry process " + sy);
                p.StartInfo.FileName = sy + "\\Main.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;

                n.Type = type;
                n.Name = ViJson.ReStrpath("name",sy + "\\AIL.ini");
                n.poce = p;
                n.StartUser = "System";
                po.Add(n);

                G:;
            }
            */
        }

        public bool ShowRunFTAConsole = true;
        public object[] RunFTA(string jk, string yc, string argd, string mainpack, out RunLoct lcp, params object[] argm)
        {
            RunLoct lc = new RunLoct();
            /*
            RunExctIcIf ifc = new RunExctIcIf();
            ifc.usingTm(jk + "\\Main.dll");
            Console.WriteLine(Path.GetFullPath(jk + "\\Main.dll"));
            ifc.save.Add(type);
            ifc.str.Add(Path.GetFullPath(jk + "\\Main.dll"));
            try
            {
                ifc.StAve();
                ifc.MKISTR();
            }
            catch (SmException df)
            {
                UtilPrintf.Printf(UtilControl.Error, ref p, df.Message);
                return new object[] { -1, df };
            }

            object[] op = ifc.runmk(new object[] { "loading", mi, this }, null);
            */
            List<object> opr = new List<object>(new object[] { yc, new object(), this });
            if (argm != null)
            {
                foreach (object ou in argm)
                    opr.Add(ou);
            }
            object[] op = lc.Locat(jk + "/Main.dll", opr.ToArray(), argd);
            //object[] oc = new object[0];

            try
            {
                if (op.Length > 0)
                {
                    List<object> oude = new List<object>();
                    if (op[0] is int)
                    {
                        for (int x = 1; x < op.Length; x++)
                        {
                            oude.Add(op[x]);
                        }
                        if (ShowRunFTAConsole)
                            UtilPrintf.Printf(UtilControl.Info, ref p, "[System plug-in unit] The package " + jk + " is sucess load to return " + op[0] + " at " + yc);
                        op = oude.ToArray();
                    }
                    else
                    {
                        if (ShowRunFTAConsole)
                            UtilPrintf.Printf(UtilControl.Warn, ref p, "[System plug-in unit] The package " + jk + " We did't not it is sucess load at " + yc);
                    }
                }
                /*
                if (op.Length > 0)
                {
                    if (op[0] is int)
                        if ((int)op[0] != 0)
                        {
                            SmException ec = (SmException)op[1];
                            Exception er = ec.RunSmProEx();
                            failPrint(jk + " package return " + (int)op[0], er.Message);
                        }
                    if (ShowRunFTAConsole)
                        UtilPrintf.Printf(UtilControl.Info, ref p, "[System plug-in unit] The package " + jk + " is sucess load to return " + (int)op[0] + " at " + yc);

                    foreach (object om in op)
                    {
                        if (om is LoadInfoClass)
                        {
                            lcinfo.Add((LoadInfoClass)om);
                        }
                    }
                }
                else
                {
                    if (ShowRunFTAConsole)
                        UtilPrintf.Printf(UtilControl.Warn, ref p, "[System plug-in unit] The package " + jk + " We did't not it is sucess load at " + yc);
                }
                */
            }
            catch (Exception ex)
            {
                failPrint("System Convent", ex.Message);
                op = new object[] { ex };
                goto F;
            }
            /*
            RunLoct[] ol = lcass.ToArray();
            lc.save.Add(yc);
            lc.save.Add(op[0]);
            if (oc.Length != 0)
                lc.save.Add(new object[] { ((LoadInfoClass)oc[0]).Package, oc[0] });
            else
                lc.save.Add(new object[0]);
            lc.save.Add(Path.GetFullPath(jk));
            lcass.Add(lc);
            */
            /*
            bool ggh = false;

            foreach (RunLoct l in lcass.ToArray())
            {
                if (l.LoadForm == jk)
                {
                    ggh = true;
                    break;
                }
            }
            if (!ggh)
            {
                lc.LoadForm = jk;
                lcass.Add(lc);
            }
            */

        /*
        RunLoct[] ol = lcass.ToArray();
        foreach (RunLoct oy in ol)
        {
            if (oy.LoadForm == jk)
            {
                if (mainpack != oy.SubLoct)
                {
                    oy.SubLoct = mainpack;
                }
                oy.save.Add(op);
                goto G;
            }
        }
        if (oc.Length != 0)
        {
            lc.name = ((LoadInfoClass)oc[0]).NameLoad;
            lc.LoadForm = jk;
            lc.save.Add(oc);
            lcass.Add(lc);
        }
    G:
        oc = new object[] { lc, op };
        */
        F:
            lcp = lc;
            return op;
        }
        public int IndexBackSp(string nameNameLoad)
        {
            int x = 0;
            foreach (RunLoct fq in lcass)
            {
                if (fq.name == nameNameLoad)
                {
                    return x;
                }
                x++;
            }
            return -1;
        }
        public List<string> failPrint(string soc, string why)
        {
            List<string> sp = new List<string>();
            sp.Add("\n======Exception======\n");
            sp.Add("#       This plug-in unit is fail to run\n");
            sp.Add("#       What happen?");
            sp.Add("# " + why + "\n#\n#\n");
            sp.Add("#       This Lg ac " + soc);

            string sp7 = "";
            foreach (string lo in sp.ToArray())
            {
                sp7 += lo;
            }
            UtilPrintf.Printf(UtilControl.Error, ref p, sp7);
            return sp;
        }
    }
}
