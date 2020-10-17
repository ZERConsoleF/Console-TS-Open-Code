using ConsoleG.Core.com.setting;
using ConsoleG.Core.net;
using ConsoleG.Network;
using ConsoleG.Network.InShowClient;
using ConsoleG.Network.ServerMent;
using Newtonsoft.Json;
using OpenCatLc;
using RunLCJVM;
using SmCmd.Newwork.Client;
using SmCmd.Newwork.Server;
using SmPro.System;
using SmProPub.LogSetup;
using SmProPub.MakeRun;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public class PCI
    {
        public static object[] Main(object[] sender, string arg)
        {
            string staticve = SmPro.System.System.GetSystemLoad(sender);
            SeeModsConsoleRun r = SmPro.System.System.GetSystemRun(sender);
            if (staticve == "load")
            {
                LoadInfoClass ft = new LoadInfoClass();
                ft.ShowName = "clientNet";
                ft.NameLoad = "NetworkClient";
                ft.Package = "HPC";
                ft.Versign = "V1.0.0";
                ft.Copyright = "Copyright (C) SeeMods 2020";
                return new object[] { 0, ft };
            }
            if (staticve == "loading")
            {
                new Thread(() => {
                    while (!r.FinishLoadMemory) ;
                    Thread.Sleep(2500);
                    try
                    {
                        /*
                        ListVerCs c = null;
                        if (ObjectClass<ListVerCs>.GetIndexl != null)
                            foreach (ListVerCs b in ObjectClass<ListVerCs>.GetIndexl)
                                if (b.Name == "cto2")
                                {
                                    c = b;
                                    break;
                                }
                        */
                        /*
                        NewConsoleNetCY y = new NewConsoleNetCY();
                        string Lp = File.ReadAllText("ThisServer/ServerStart.ini");
                        ServerStartIP i = JsonConvert.DeserializeObject<ServerStartIP>(Lp);
                        IPEndPoint p = null;

                        if (i.IPStart == null)
                        {
                            p = new IPEndPoint(IPAddress.Any.Address, int.Parse(i.Port));
                        }
                        else
                            p = new IPEndPoint(IPAddress.Parse(i.IPStart).Address, int.Parse(i.Port));
                        y.IPBlind = p;
                        y.Connent();
                        y.AddBlind = new InfeNewConsoleHup("Admin", "Admin", File.ReadAllText("43.conmp"), "4");
                        y.LogUp();
                        */
                        /*
                        ConsoleShowWindow[] s = ObjectClass<ConsoleShowWindow>.GetIndexl;
                        ConsoleShowWindow lm = null;
                        foreach (ConsoleShowWindow w in s)
                        {
                            if (w.Name.ToLower() == "Static area".ToLower())
                            {
                                lm = w;
                                break;
                            }
                        }
                        
                        //lm.ConsoleWriteLine("Connent 127.0.0.1 Loading...");
                        RunTServerFP f = new RunTServerFP(y);
                        SenderClassForm fr = new SenderClassForm();
                        fr.ControlClass = "MainSearch";
                        f.HandleClassSender = fr;
                        //Thread.Sleep(2630);
                        //Console.WriteLine("45f0fe");
                        f.Sender();
                        //lm.ConsoleWriteLine("127.0.0.1 Back byte");
                        fr = f.GetBackHandleClassSender;


                        ItemListCs g = Class<ItemListCs>.Deserialize(fr.GetBytes);
                        /*
c.FsWriteLQ = 10;
c.ReadlyCheckColor = Color.AliceBlue;
c.CheckColor = Color.Aqua;
//lm.ConsoleWriteLine("127.0.0.1 finish search");
//Console.WriteLine(g.Text);
if (c.InvokeRequired)
    c.Invoke(new MethodInvoker(delegate { c.AddItem(g, null); }));
else
    c.AddItem(g, null);

//c.Develop(new int[] { 0 });

ListVebel k = null;

if (ObjectClass<ListVebel>.GetIndexl != null)
    foreach (ListVebel l in ObjectClass<ListVebel>.GetIndexl)
    {
        if (l.Name.ToLower() == "Code Core List".ToLower())
        {
            k = l;
        }
    }
ConsoleShowWindow wsg = new ConsoleShowWindow();
wsg.Name = "Code Info";
wsg.Text = "Info";
k.AddFormSope(wsg);

wsg.Show();

new Thread(() =>
{
    Thread.Sleep(100);
    wsg.FortText = Color.Aqua;

    wsg.Dock = DockStyle.Fill;
    wsg.ConsoleWriteLine("None");
}).Start();

c.ClickItem += (object sender1, ObjectEvent e) => {
    ItemListCs cg = c.GetCheckItem();
    if (cg != null)
    {

        try
        {
            //Thread.Sleep(100);
            //Console.WriteLine(1);
            wsg.ConsoleClear();
            wsg.FortText = Color.Aqua;
            List<string> ggh = new List<string>();
            ggh.Add("Server IP:" + p.ToString());
            ggh.Add("");
            ggh.Add("--Item Info--");
            ggh.Add("Item Type:" + cg.Type);
            ggh.Add("Item Control Text:" + cg.EtcString);
            ggh.Add("Item Text" + cg.Text);
            ggh.Add("");
            ggh.Add("--Server Info--");
            ggh.Add("Server LogUp Info:");
            ggh.Add("  User:" + y.AddBlind.User);
            ggh.Add("  User Inidx:" + y.AddBlind.UnIndex);
            ggh.Add("Server Up:" + y.LogUped);
            ggh.Add("Server Exception:");

            foreach (Exception erb in y.Exception)
            {
                ggh.Add("  " + erb.Message);
            }
            //Console.WriteLine(2);

            foreach (string ggm in ggh.ToArray())
            {
                wsg.FortText = Color.Aqua;
                wsg.ConsoleWriteLine(ggm);
            }
            GC.SuppressFinalize(ggh);

        }
        catch (Exception ex)
        {

        }

    }
};
*/
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("连接错误:" + ex.Message, "SeeMods Client Connent", MessageBoxButtons.OK);
                    }
                });
                ItemRegedit i = new ItemRegedit();
                i.Name = "0";
                ObjectEvent o;
                o = new ObjectEvent();
                o.ObjectEventArg += (object senderp, ObjectEvent e) => {
                    HasServerConEvent h = e as HasServerConEvent;
                    ItemListCs iu = h.ItemListCs;
                    NewConsoleNetCY c = h.NewConsoleCY as NewConsoleNetCY;
                    if (iu.MenuStrip == null)
                    {
                        iu.MenuStrip = new ContextMenuStrip();
                        ToolStripMenuItem i1 = new ToolStripMenuItem();
                        i1.Text = "Disopse Connent In " + c.GetThisSocket.RemoteEndPoint.ToString();

                        i1.Click += (object senderpp, EventArgs eu) => { new Thread(() => {
                            DisConnentOneSp s = new DisConnentOneSp();
                            ConsoleShowWindow pt = (ConsoleShowWindow)FormMenu.CatchOrCreativePackControl<ConsoleShowWindow>("Console static", "y7staticr", null);
                            s.Execute(c.GetThisSocket.RemoteEndPoint.ToString(), r, pt, new object());
                        }).Start(); };

                        iu.MenuStrip.Items.Add(i1);

                        iu.MenuStrip.Items.Add(new ToolStripSeparator());

                        i1 = new ToolStripMenuItem();
                        i1.Text = "Refresh";
                        i1.Click += (object senderpp, EventArgs eu) => {
                            new Thread(() => {
                                h.ConsoleShowWindow.FortText = Color.Aqua;
                                h.ConsoleShowWindow.ConsoleWriteLine("Ref...");
                                try
                                {
                                    RunTServerFP f = new RunTServerFP(c);
                                    SenderClassForm fr = new SenderClassForm();
                                    fr.ControlClass = "MainSearch";
                                    f.HandleClassSender = fr;
                                    //Thread.Sleep(2630);
                                    //Console.WriteLine("45f0fe");
                                    //f.Sender();
                                    //lm.ConsoleWriteLine("127.0.0.1 Back byte");
                                    //fr = f.GetBackHandleClassSender;

                                    SearchClass op = new SearchClass(f);

                                    SearchOpp ppu = SearchOpp.GetClass;
                                    /*
                                    ObjectEvent rpp = new ObjectEvent();
                                    rpp.Name = "MainSearch";
                                    rpp.ObjectEventArg += (object sender, ObjectEvent e) => {
                                        op.GetSenderClassFormHandle();

                                    };
                                    */

                                    op.Sender();
                                    fr = op.GetSenderClassFormHandle();

                                    ItemListCs g = Class<ItemListCs>.Deserialize(fr.GetBytes);
                                    h.ListVerCs.RemoveItem(h.ListVerCs.FindThisItem(iu, null), true);
                                    h.ListVerCs.Invoke(new MethodInvoker(() => { h.ListVerCs.AddItem(g, null); }));
                                }
                                catch (Exception ex)
                                {
                                    h.ConsoleShowWindow.ConsoleWriteLine("Exception :" + ex.Message);
                                }
                            }).Start();
                        };

                        iu.MenuStrip.Items.Add(i1);

                        (iu.CD as PanelMemov).ContextMenuStrip = iu.MenuStrip;
                        if ((iu.CD as PanelMemov).Label != null)
                            (iu.CD as PanelMemov).Label.ContextMenuStrip = iu.MenuStrip;
                    }
                };
                i.ObjectEvents = o;
                i = new ItemRegedit();
                i.Name = "item.user";
                o = new ObjectEvent();
                o.ObjectEventArg += (senderp, e) => {
                    HasServerConEvent h = e as HasServerConEvent;
                    ItemListCs iu = h.ItemListCs;
                    NewConsoleNetCY c = h.NewConsoleCY as NewConsoleNetCY;

                    if (h.Iinfo == "GetDevelopItem" && (iu.CB as ButtonMemov).CheckOne)
                    {
                        new Thread(() =>
                        {
                            foreach (ItemListCs gghu in iu.SubItems.ToArray())
                                h.ListVerCs.RemoveItem(h.ListVerCs.FindThisItem(gghu, null), true);

                            ContextMenuStrip s = new ContextMenuStrip();
                            ToolStripMenuItem ti = new ToolStripMenuItem();
                            ti.Text = "Server User or Info...";


                            h.ConsoleShowWindow.FortText = Color.Aqua;
                            h.ConsoleShowWindow.ConsoleWriteLine("Search in " + c.GetThisSocket.RemoteEndPoint.ToString());
                            RunTServerFP f = new RunTServerFP(c);
                            UserBack u = new UserBack();
                            f.HandleClassSender = u;
                            f.Sender();
                            List<ItemListCs> ggt = new List<ItemListCs>();
                            foreach (ServerUserControl t in u.GetServerUserControl)
                            {
                                ItemListCs ttg = new ItemListCs();
                                ttg.Hight = iu.Hight;
                                ttg.FsWritePS = iu.FsWritePS;
                                ttg.Name = t.User;
                                ttg.Text = "Name:" + t.UserName + " ID:" + t.User;
                                ggt.Add(ttg);
                            }

                            int[] ddf = h.ListVerCs.FindThisItem(iu, null);

                            if (ddf.Length <= 0)
                            {
                                h.ConsoleShowWindow.ConsoleWriteLine("Search Fail");
                                return;
                            }

                            h.ListVerCs.Invoke(new MethodInvoker(() => { foreach (ItemListCs ffr in ggt.ToArray()) h.ListVerCs.AddSubItem(ddf, ffr); }));
                            h.ConsoleShowWindow.ConsoleWriteLine("Search Finished");
                        }).Start();
                    }
                };
                i.ObjectEvents = o;
                i = new ItemRegedit();
                i.Name = "item.serverlogsee";
                o = new ObjectEvent();
                o.ObjectEventArg += (senderp, e) => {
                    HasServerConEvent h = e as HasServerConEvent;
                    ItemListCs iu = h.ItemListCs;
                    NewConsoleNetCY c = h.NewConsoleCY as NewConsoleNetCY;

                    if (h.Iinfo == "GetDevelopItem" && (iu.CB as ButtonMemov).CheckOne)
                    {
                        h.ConsoleShowWindow.FortText = Color.Aqua;
                        h.ConsoleShowWindow.ConsoleWriteLine("LogSearching...");
                        new Thread(() =>
                        {
                            foreach (ItemListCs gghu in iu.SubItems.ToArray())
                                h.ListVerCs.RemoveItem(h.ListVerCs.FindThisItem(gghu, null), true);
                            RunTServerFP f = new RunTServerFP(c);
                            FileList l = new FileList();
                            l.Directory = "ThisServer/Log";
                            f.HandleClassSender = l;
                            f.Sender();
                            List<ItemListCs> ggt = new List<ItemListCs>();
                            foreach (string s in l.SpDir.FilePathName)
                            {
                                ItemListCs ttg = new ItemListCs();
                                ttg.Hight = iu.Hight;
                                ttg.FsWritePS = iu.FsWritePS;
                                ttg.Name = "log";
                                ttg.Image = Image.FromFile("Ico/e7b536dc90d10edbd0bec8aad3d40b3f.jpg");
                                ttg.Text = s;
                                ggt.Add(ttg);
                            }

                            int[] ddf = h.ListVerCs.FindThisItem(iu, null);

                            if (ddf.Length <= 0)
                            {
                                h.ConsoleShowWindow.ConsoleWriteLine("Log Search Fail");
                                return;
                            }

                            h.ConsoleShowWindow.ConsoleWriteLine("LogSearch Finish");
                            h.ListVerCs.Invoke(new MethodInvoker(() => { foreach (ItemListCs ffr in ggt.ToArray()) h.ListVerCs.AddSubItem(ddf, ffr); }));
                        }).Start();
                    }
                };
                i.ObjectEvents = o;
                i = new ItemRegedit();
                i.Name = "log";
                o = new ObjectEvent();
                o.ObjectEventArg += (senderp, e) => {
                    HasServerConEvent h = e as HasServerConEvent;
                    ItemListCs iu = h.ItemListCs;
                    NewConsoleNetCY c = h.NewConsoleCY as NewConsoleNetCY;

                    if (h.Iinfo == "GetDevelopItem" && (iu.CB as ButtonMemov).CheckOne)
                    {
                        new Thread(() =>
                        {
                            h.ConsoleShowWindow.FortText = Color.Aqua;
                            h.ConsoleShowWindow.ConsoleWriteLine("Download");
                            RunTServerFP f = new RunTServerFP(c);
                            FileDownload d = new FileDownload();
                            if (File.Exists("download/serverlog/" + iu.Text))
                                File.Delete("download/serverlog/" + iu.Text);
                            d.FilePathDownload = "ThisServer/Log/" + iu.Text;
                            d.SavePathDirectory = "download/serverlog/";
                            d.SavePath = iu.Text;
                            f.HandleClassSender = d;
                            f.Sender();
                            /*d.BackMessageAnys += (senderpp, ep) =>
                            {
                                string u = d.ObjectGetInsp.SenderPres.ToString();
                                string hgh = u + "%";
                                if (d.ObjectGetInsp.Finish)
                                {
                                    h.ConsoleShowWindow.ConsoleWrite("\r\n");
                                    return;
                                }
                                //h.ConsoleShowWindow.ConsoleKeyBack(hgh.Length);
                                h.ConsoleShowWindow.ConsoleWrite(hgh);
                            };
                            */
                            h.ConsoleShowWindow.ConsoleWriteLine("Finish Download...");
                            FormMenu m = FormMenu.CatchPackName("Log Look");
                            m.Arg = Encoding.Default.GetString(File.ReadAllBytes("download/serverlog/" + iu.Text));
                            m.ObjectClassArgL();
                        }).Start();
                    }
                };
                i.ObjectEvents = o;
                /*
                foreach (FormMenu f in FormMenu.GetIndexl)
                {
                    if (f.CheckForm.Name == "f3")
                    {
                        foreach (Control l in f.CheckForm.Controls)
                        {
                            if (l is ListVebel)
                            {
                                ListVebel v = (ListVebel)l;
                                v.GetFormSp();
                            }
                        }
                        break;
                    }
                }
                */
            }
            if (staticve == "getcmd")
            {
                new RegeditCmd().RunInGet.AddRange(new RunCommandTo[] { new ConnentOneSp(), new DisConnentOneSp() });
            }
            return new object[] { 0 };
        }
    }
}
