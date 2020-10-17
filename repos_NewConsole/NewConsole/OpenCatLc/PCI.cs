using ConsoleG.Core.com;
using ConsoleG.Core.com.setting;
using ConsoleG.Core.net;
using ConsoleG.WindowG;
using OpenCatLc;
using RunLCJVM;
using RunLCJVM.Window;
using SmPro.System;
using SmProPub;
using SmProPub.Net;
using SmProPub.Window.Forms.UsersControl;
using SmProPub.Window.Formw.Controle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.SmProPub.ExClass.ObjectClass<SmPro.System.FormMenu>;
using SmProPub.Text;
using ConsoleG.Core.net.RunExct;
using SmProPub.LogSetup;

namespace Main
{
    public class PCI
    {
        static SeeModsConsoleRun r;
        public static object[] Main(object[] sender, string arg)
        {
            try
            {
                string vc = SmPro.System.System.GetSystemLoad(sender);
                r = SmPro.System.System.GetSystemRun(sender);
                if (vc == "load")
                {
                    LoadInfoClass ft = new LoadInfoClass();
                    ft.ShowName = "Open Server";
                    ft.NameLoad = "Server Regedit";
                    ft.Package = "sr";
                    ft.Versign = "V1.0.0";
                    ft.Copyright = "Copyright (C) SeeMods 2020";
                    return new object[] { 0, ft };
                }

                if (vc == "loading")
                {
                    
                    FormPanelControl fp = new FormPanelControl(r.mi);
                    fp.Name = "Windows Control";
                    fp.Text = "SeeMods";
                    fp.AsiPosInt = 20;
                    fp.Open();

                    SettingPackage.InitPackage(SettingPackage.PK_SmPro_Name, false);
                    SettingPackage pw = new SettingPackage(SettingPackage.PK_SmPro_Name);
                    SettingWindow h = new SettingWindow();
                    pw.Read(h);
                    //string fils = File.ReadAllText("WindowsStart.ini");
                    //WindowsHaneld h = JsonConvert.DeserializeObject<WindowsHaneld>(fils);

                    FormMenu mk = new FormMenu();
                    mk.PackName = "Console area";
                    mk.CheckForm = new NCKOLCTETU();

                    mk.ObjectClassArgL += new ObjectClass<FormMenu>.ObjectClassArg(() =>
                    {
                        NCKOLCTETU t = mk.CheckForm as NCKOLCTETU;
                        t.TabIndex = mk.CheckForms.Count;
                        t.Text = FanYi.fromepk("RC", "form.loadwindow.Creative.MainConsole", r.lauge);
                        t.Name = "nckti.";
                        mk.CheckForm = new NCKOLCTETU();

                        ConsoleShowWindow p = new ConsoleShowWindow();
                        p.Name = "y7";
                        p.Text = "Console";
                        p.BackText += P_BackText;
                        t.Text += p.ReturnText;
                        t.AddControl(p);
                        p.Show();

                        mk.CheckForms.Add(t);
                        r.mi.AddControlInvoke(t);
                        t.Name += mk.CheckForms.Count;
                        t.Show();
                        SetETCWindowToSystem ty = new SetETCWindowToSystem(r.mi);
                        ty.SetLocationUp(t);
                        ty.SetFocusMain(t);
                        //p.ShowText.GotFocus += (object senderp, EventArgs e) => { ty.SetFocusMain(t); };
                        //ty.SetFocusEvent(t, null);

                        //Thread.Sleep(100);
                        //Console.WriteLine(p.InvokeRequired);
                        p.Dock = DockStyle.Fill;
                        p.ShowText.SelectionColor = Color.Green;
                        p.ConsoleWrite("SeeMods Console\r\nCopyright (C) SeeMods 2020 ToCompe\r\n\r\n");
                        p.ShowText.ReadOnly = false;
                        p.ReadKeepAlie = true;
                        //p.Dock = DockStyle.Fill;
                        object[] y9 = r.RunFTA(r.args.extr + "/cmd", "runload", null, "ConsoleTc", out RunLoct l, null, p);
                        if (y9.Length > 0)
                            if (y9[0] is Exception)
                            {
                                p.FortText = Color.Red;
                                p.ConsoleWriteLine("Exception : for " + (y9[0] as Exception).ToString());
                            }
                        p.ShowText.SelectionColor = Color.Green;
                        p.ConsoleWrite("\r\n[C#] : ");
                        //fp.Add(t);
                    });

                    FormMenu mb = new FormMenu();
                    mb.PackName = "Console static";
                    mb.CheckForm = new NCKOLCTETU();
                    mb.ObjectClassArgL += new ObjectClass<FormMenu>.ObjectClassArg(() => {
                        NCKOLCTETU t = mb.CheckForm as NCKOLCTETU;
                        t.TabIndex = mb.CheckForms.Count;
                        t.Text = FanYi.fromepk("RC", "form.loadwindow.Creative.ControlMain", r.lauge);
                        t.Name = "ncktpai.";
                        mb.CheckForm = new NCKOLCTETU();

                        ConsoleShowWindow p = new ConsoleShowWindow();
                        p.Name = "y7staticr";
                        t.ShowIn.Controls.Add(p);
                        p.Show();

                        mb.CheckForms.Add(t);
                        r.mi.AddControlInvoke(t);
                        t.Name += mb.CheckForms.Count;
                        t.Show();

                        p.Dock = DockStyle.Fill;
                        p.FortText = Color.Aqua;
                        p.ConsoleWriteLine("SeeMods Static Show");
                        p.AllowPase = false;
                        fp.Add(t);
                        t.Disposed += (senderp, e) => { fp.Remove(t);mb.CheckForms.Remove(t); };
                    });

                    FormMenu mb1 = new FormMenu();
                    mb1.PackName = "Console view";
                    mb1.CheckForm = new NCKOLCTETU();
                    mb1.ObjectClassArgL += new ObjectClass<FormMenu>.ObjectClassArg(() => {
                        NCKOLCTETU t = mb1.CheckForm as NCKOLCTETU;
                        t.TabIndex = mb1.CheckForms.Count;
                        t.Text = FanYi.fromepk("RC", "form.loadwindow.Creative.ViewConsole", r.lauge);
                        t.Name = "y7staticf-";
                        t.BackColor = Color.AliceBlue;
                        mb1.CheckForm = null;
                        mb1.CheckForm = new NCKOLCTETU();

                        ListVerCs p = null;
                        p = new ListVerCs();
                        p.Name = "y7staticr-";
                        t.ShowIn.Controls.Add(p);
                        p.Dock = DockStyle.Fill;
                        p.Show();

                        mb1.CheckForms.Add(t);
                        r.mi.AddControlInvoke(t);
                        t.Show();

                        string[] sp = new string[0];


                        if (mb1.Arg != null)
                            sp = String64.MakeArg(mb1.Arg);


                        Size poi = new Size();
                        Point pok = new Point();

                        try
                        {
                            poi = new Size(int.Parse(sp[0].Split(',')[0]), int.Parse(sp[0].Split(',')[1]));
                            pok = new Point(int.Parse(sp[1].Split(',')[0]), int.Parse(sp[1].Split(',')[1]));
                        }
                        catch
                        {
                        }
                        try
                        {
                            t.Text = sp[2];
                        }
                        catch
                        {

                        }
                        /*
                        FormPanelItems ipg = null;

                        foreach (FormPanelItems u in fp.GetFormPanelItems())
                        {
                            if (u.Name == "Server View")
                            {
                                ipg = u;
                                break;
                            }
                        }
                        if (ipg != null)
                        {
                            fp.Add(t);
                            void vvr() { fp.InAdd(t, ipg); };
                            if (t.InvokeRequired)
                                t.BeginInvoke(new MethodInvoker(delegate { vvr(); }));
                            else
                                vvr();
                        }
                        else
                        {
                            ipg = new FormPanelItems();
                            ipg.Size = poi;
                            ipg.Loaction = pok;
                            ipg.Name = "Server View";
                            ipg.AddInNCKOLCTETU.Add(t);
                            void vvr() { fp.Add(ipg); };
                            if (t.InvokeRequired)
                                t.BeginInvoke(new MethodInvoker(delegate { vvr(); }));
                            else
                                vvr();
                        }
                        void Sef(object senderp, ObjectEvent e)
                        {
                            //Console.WriteLine(t.IsDisposed);
                            if (t.IsDisposed)
                                return;
                                void vvr() { fp.InRemove(ipg, t, true, false); };
                            if (p.InvokeRequired && !p.IsHandleCreated)
                                p.BeginInvoke(new MethodInvoker(delegate { vvr(); }));
                            else
                                vvr();
                        }
                        */
                        //t.Closing += Sef;
                        p.Text = t.Text;
                        p.TextChanged += (object senderp, EventArgs e) => { t.Text = p.Text; };//ipg.InListVebel.GetTaskBar().ResetButtonLocation(); };
                        mb1.Arg = null;
                    });

                    FormMenu mb2 = new FormMenu();
                    mb2.PackName = "Log Look";
                    mb2.CheckForm = new NCKOLCTETU();
                    mb2.ObjectClassArgL += new ObjectClass<FormMenu>.ObjectClassArg(() => {
                        LogSearch sw = new LogSearch();
                        sw.Name = "logupy7-";
                        sw.SearchText = mb2.Arg;
                        //r.mi.AddControlInvoke(sw);
                        sw.Format();
                        new Thread(() =>
                        {
                            Application.Run(sw);
                            GC.SuppressFinalize(sw);
                        }).Start();
                    });

                    r.mi.MainShow.ControlAdded += (senderp, e) => {
                        gfhw(e.Control,e.Control);
                        //Console.WriteLine(1);
                        foreach (SunWindows s in h.windowsHaneld.SunWindows)
                        {
                            if (s.Name == e.Control.Name)
                            {
                                if (!s.StartThis)
                                    continue;
                                e.Control.Size = s.Size;
                                e.Control.Location = s.Point;
                            }
                        }
                        foreach (SubWindowsHaneldPackage s in h.windowsHaneld.SubWindowsHaneldPackage)
                        {
                            if (!s.StartThis)
                                continue;
                            foreach (string f in s.Names)
                            {
                                if (f == e.Control.Name)
                                {
                                    FormPanelItems ipg = null;

                                    foreach (FormPanelItems u in fp.GetFormPanelItems())
                                    {
                                        if (u.Name == s.PackName)
                                        {
                                            ipg = u;
                                            break;
                                        }
                                    }
                                    if (ipg != null)
                                    {
                                        fp.Add(e.Control);
                                        //e.Control.Disposed += (senderpp, eq) => { fp.InRemove(ipg, e.Control, false, true); };
                                        void vvr() { fp.InAdd(e.Control, ipg); };
                                        //if (e.Control.InvokeRequired)
                                            //e.Control.BeginInvoke(new MethodInvoker(delegate { vvr(); }));
                                        //else
                                            vvr();
                                        ipg.InNCKOLCTETU.Dock = s.DockStyle;
                                        ipg.InNCKOLCTETU.Title.Height = s.TitleSet;
                                        ipg.InNCKOLCTETU.BackColor = s.BackGround;
                                        ipg.InListVebel.TitlePanelDock = s.UnderDockStyle;
                                        ipg.InNCKOLCTETU.LockWindow = s.Lock;
                                        ipg.InNCKOLCTETU.CanChangeSizeAtLockWindows = s.CanChangeAfterLock;
                                    }
                                    else
                                    {
                                        ipg = new FormPanelItems();
                                        ipg.Size = s.Size;
                                        ipg.Loaction = s.Point;
                                        ipg.Name = s.PackName;
                                        //ipg.AddInNCKOLCTETU.Add(t);
                                        //e.Control.Disposed += (senderpp, eq) => { fp.InRemove(ipg, e.Control, false, true); };
                                        void vvr() { fp.Add(ipg); fp.Add(e.Control); fp.InAdd(e.Control, ipg); };
                                        //if (e.Control.InvokeRequired)
                                            //e.Control.BeginInvoke(new MethodInvoker(delegate { vvr(); }));
                                        //else
                                            vvr();
                                        ipg.InNCKOLCTETU.Dock = s.DockStyle;
                                        ipg.InNCKOLCTETU.Title.Height = s.TitleSet;
                                        ipg.InNCKOLCTETU.BackColor = s.BackGround;
                                        ipg.InListVebel.TitlePanelDock = s.UnderDockStyle;
                                        ipg.InNCKOLCTETU.LockWindow = s.Lock;
                                        ipg.InNCKOLCTETU.CanChangeSizeAtLockWindows = s.CanChangeAfterLock;
                                    }
                                    //e.Control.Disposed += (senderpp, eq) => { fp.InRemove(ipg, e.Control, false, true); };
                                    //e.Control.TextChanged += (senderpp, eq) => { ipg.InListVebel.GetTaskBar().ResetButtonLocation(); };
                                    break;
                                }
                            }
                        }
                    };

                    if (h.windowsHaneld.StartThis)
                    {
                        new Thread(() =>
                        {
                            while (!r.FinishLoadMemory) ;
                            Thread.Sleep(500);

                            r.mi.Location = h.windowsHaneld.Point;
                            r.mi.Size = h.windowsHaneld.Size;

                            //Console.WriteLine(h.Size.Width + " " + h.Size.Height);
                            //Console.WriteLine(h.Point.X + " " + h.Point.Y);

                            if (h.windowsHaneld.FileScreen)
                                r.mi.MaxsWindow();
                            else
                                r.mi.MinsWindow();
                        }).Start();
                        foreach (SunItemWindowsPackage s in h.windowsHaneld.SunItemWindowsPackages)
                        {
                            if (!s.IsShow)
                                continue;
                            if (FormMenu.GetIndexl != null)
                            {
                                foreach (FormMenu f in FormMenu.GetIndexl)
                                {
                                    if (f.PackName == s.PackName)
                                    {
                                        f.Arg = s.Arg;
                                        for (int i = 0; i < s.HasAdd; i++)
                                            f.ObjectClassArgL();
                                    }
                                }
                            }
                        }
                    }

                    /*
                    FormMenu mb2 = new FormMenu();
                    mb2.PackName = "Console Server View";
                    mb2.CheckForm = new NCKOLCTETU();
                    mb2.ObjectClassArgL += new ObjectClass<FormMenu>.ObjectClassArg(() => {
                        NCKOLCTETU t = mb2.CheckForm as NCKOLCTETU;
                        t.Text = FanYi.fromepk("RC", "form.loadwindow.Creative.ViewConsole", r.lauge);
                        t.Name = "ncktstservercode." + mb.CheckForms.Count;
                        mb2.CheckForm = new NCKOLCTETU();
                    });
                    
                    try
                    {
                        Thread t = new Thread(() =>
                        {
                            while (!r.FinishLoadMemory) Thread.Sleep(1000);
                            fp.AsiPosInt = h.AsiPosInt;
                            if (h.StartThis)
                            {
                                if (h.Point != null)
                                    r.mi.Location = h.Point;
                                if (h.Size != null)
                                    r.mi.Size = h.Size;
                                if (h.FileScreen)
                                    r.mi.MaxsWindow();
                                else
                                    r.mi.MinsWindow();
                                if (h.TitleAt != null)
                                    r.mi.Text = h.TitleAt;
                                foreach (SunItemWindowsPackage s in h.SunItemWindowsPackages.ToArray())
                                    foreach (FormMenu m in FormMenu.GetIndexl)
                                    {
                                        if (m.PackName == s.PackName)
                                        {
                                            if (s.IsShow)
                                            {
                                                for (int x = 1; x <= s.HasAdd; x++)
                                                    m.ObjectClassArgL();
                                            }
                                        }
                                    }
                                List<Control> cp = new List<Control>();
                                foreach (SunWindows st in h.SunWindows.ToArray())
                                {
                                    if (st.StartThis)
                                    {
                                        if (st.HasPackName != null)
                                        {
                                            foreach (FormMenu m in FormMenu.GetIndexl)
                                            {
                                                if (m.PackName == st.HasPackName)
                                                {
                                                    m.Arg = st.Arg;
                                                    m.ObjectClassArgL();
                                                }
                                            }
                                        }
                                    }
                                }
                                foreach (Control c in r.mi.Controls)
                                {
                                    if (!(c is NCKOLCTE) && !(c is NCKOLCTETU))
                                        continue;
                                    cp.Add(c);
                                }
                                foreach (SunWindows st in h.SunWindows.ToArray())
                                {
                                    if (st.StartThis)
                                    {
                                        foreach (Control cpo in cp.ToArray())
                                        {
                                            if (cpo.Name == st.Name)
                                            {
                                                cpo.Size = st.Size;
                                                cpo.Location = st.Point;
                                            }
                                        }
                                    }
                                }
                                foreach (SubWindowsHaneldPackage s in h.SubWindowsHaneldPackage.ToArray())
                                {
                                    if (!s.StartThis)
                                        continue;
                                    foreach (string name in s.Names.ToArray())
                                    {
                                        foreach (Control cg in cp.ToArray())
                                        {
                                            if (cg.Name == name)
                                            {
                                                FormPanelItems i = new FormPanelItems();
                                                i.Name = "ap";
                                                i.Loaction = s.Point;
                                                i.Size = s.Size;
                                                if (i.Loaction == default)
                                                {
                                                    i.Loaction = new Point(0, r.mi.TitlePan.Height);
                                                }
                                                if (i.Size == default)
                                                {
                                                    i.Size = new Size(800, 600);
                                                }
                                                //fp.InAdd(cg, i);
                                                cg.Invoke(new MethodInvoker(delegate { fp.Add(i); fp.InAdd(cg, i); }));
                                            }
                                        }
                                    }
                                }
                            }
                            r.mi.ControlAdded += (senderp, e) => {
                                Control ff = e.Control;
                                if (ff is NCKOLCTE && ff is NCKOLCTETU)
                                {
                                    foreach (SunWindows st in h.SunWindows.ToArray())
                                    {
                                        if (st.StartThis)
                                        {
                                            if (ff.Name == st.Name)
                                            {
                                                ff.Size = st.Size;
                                                ff.Location = st.Point;
                                            }
                                        }
                                    }
                                }

                            };
                        });
                        t.IsBackground = true;
                        t.Start();
                    }
                    catch (Exception ex)
                    {
                        UtilPrintf.Printf(UtilControl.Error, ref r.p, "[Windows Control Fail] " + ex.Message);
                    }
                    */
                }
                if (vc == "sever-loading")
                {
                    ConsoleShowWindow w = new ConsoleShowWindow();
                    w.ConsoleS = true;
                    RunCommandSerd.Start(w, r);
                    ConsoleControlPCER rty = new ConsoleControlPCER(null);
                    rty.ConsoleShowWrite = "[C#] : ";
                    rty.ChangeThread(new Thread(() => {
                        while (true)
                            if (r.FinishLoadMemory)
                            {
                                w.FortText = Color.Green;
                                w.ConsoleWriteLine("\n");
                                w.ConsoleWrite(rty.ConsoleShowWrite);
                                break;
                            }
                        while (true)
                        {
                            w.FortText = Color.Green;
                            string h = w.ConsoleReadLine();
                            RunCommandSerd.RunCommand(w, h, true);
                        }
                    }));
                    rty.Name = "Main";
                    rty.GetThread.Start();
                }
                    return new object[] { 0 };
            }
            catch (Exception ex)
            {
                SmException sc = new SmException();
                sc.message = ex.Message;
                return new object[] { -1296, sc };
            }
        }
        private static void gfhw(Control sub,Control e)
        {
            sub.GotFocus += (senderp, ep) => { SeeModsConsoleRun.GetainClass.mi.CommentShow.Text = "Ready!Click Window " + sub.Text; };
            sub.GotFocus += (senedrpp, ep) => {
                List<Control> c = new List<Control>();
                foreach (Control fg in r.mi.Controls)
                {
                    c.Add(fg);
                }
                if (c[0] == e)
                    return;
                int f = 0;
                foreach (Control r in c)
                {
                    if (r == e)
                    {
                        break;
                    }
                    f++;
                }
                if (f >= c.Count)
                    return;
                c[f] = c[0];
                c[0] = e;
                foreach (Control fg in c)
                    r.mi.Controls.Add(fg);
            };
            foreach (Control ffg in sub.Controls)
                gfhw(ffg, e);
        }

        private static void P_BackText(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            ConsoleShowWindow y = o.Save as ConsoleShowWindow;
            new Thread(() => { RunCommandSerd.RunCommand(y, sender.ToString(), true); }).Start();
        }
    }
}
