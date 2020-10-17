using RunLCJVM;
using SmProPub.MakeRun;
using SmProPub.Text;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleG.Network;
using System.IO;
using System.Net;
using System.SmProPub.ExClass;
using ConsoleG.Network.InShowClient;
using System.Windows.Forms;
using Newtonsoft.Json;
using ConsoleG.Core.com;
using SmPro.System;
using System.Threading;
using System.SmProPub.Event;
using SmProPub;

namespace SmCmd.Newwork.Client
{
    public class ConnentOneSp : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            return new Exception("无法知道的错误");
        }

        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            string[] args = String64.MakeArg(arg);
            cw.FortText = Color.Aqua;

            if (args.Length < 5)
            {
                cw.ConsoleWriteLine("参数缺少，请用help查看");
                return 0;
            }
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
                cw.FortText = Color.Aqua;
                cw.ConsoleWriteLine("新建连接\r\nCopyright (C) SeeMods 2020 版权所有");
                cw.ConsoleWriteLine("Connent...");
                if (r.args.Server)
                {
                    cw.ConsoleWriteLine("在服务器，Connent不可用...");
                    return 0;
                }
                NewConsoleNetCY y = new NewConsoleNetCY();
                //string Lp = File.ReadAllText("ThisServer/ServerStart.ini");
                //ServerStartIP i = JsonConvert.DeserializeObject<ServerStartIP>(Lp);
                IPEndPoint p = null;

                string[] ipadd = args[0].Split(':');

                if (ipadd.Length <= 1)
                {
                    p = new IPEndPoint(IPAddress.Parse(ipadd[0]).Address, SmProConst.GetSocketPort);
                }
                else
                {
                    p = new IPEndPoint(IPAddress.Parse(ipadd[0]).Address, int.Parse(ipadd[1]));
                }
                y.IPBlind = p;

                if (NewConsoleNetCY.GetSocketInName("Conent>" + p.ToString()) != null)
                {
                    cw.ConsoleWriteLine("已被连接，请注销操作!");
                    ObjectClass<NewConsoleNetCY>.DisopseInMemory(y);
                    return 0;
                }

                y.Name = "Conent>" + p.ToString();
                y.Connent();
                y.AddBlind = new InfeNewConsoleHup(args[1], args[2], File.ReadAllText(args[3]), args[4]);
                y.LogUp();
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
                */
                //lm.ConsoleWriteLine("Connent 127.0.0.1 Loading...");
                cw.ConsoleWriteLine("Search...");
                RunTServerFP f = new RunTServerFP(y);
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
                void drr(object senderpp,ObjectEvent e) {
                    NewSocketABEvent rt = (NewSocketABEvent)e;
                    r.mi.CommentShow.Text = "正在执行:" + rt.ByteSended + "/" + rt.AllByte + " 处理速度:" + StringSearch.FormatIB(rt.ByteSender,"0.00") + "/s" + " - " + (rt.SenderPres * 100).ToString("0.0") + "% - " + (rt.SenderRivice ? "接收" : "发送" + " - " + (senderpp as NewConsoleNetCY).GetThisSocket.LocalEndPoint.ToString());
                    if (rt.Finish)
                        r.mi.CommentShow.Text = "网络执行成功! - " + (senderpp as NewConsoleNetCY).GetThisSocket.LocalEndPoint.ToString() + " (最后字节处理" + StringSearch.FormatIB(rt.ByteSender, "0.00") + "/s)";
                }
                y.SenderReviceStatic += drr;
                op.Sender();
                //y.SenderReviceStatic -= drr;
                fr = op.GetSenderClassFormHandle();

                cw.ConsoleWriteLine("Make...");

                ItemListCs g = Class<ItemListCs>.Deserialize(fr.GetBytes);

                ListVerCs ppl = null;

            T:

                if (ObjectClass<ListVerCs>.GetIndexl != null)
                    foreach (ListVerCs apr in ObjectClass<ListVerCs>.GetIndexl)
                    {
                        if (apr.Name == "y7staticr-")
                        {
                            ppl = apr;
                            break;
                        }
                    }

                if (ppl == null)
                {
                    if (FormMenu.GetIndexl != null)
                        foreach (FormMenu o in FormMenu.GetIndexl)
                        {
                            if (o.PackName == "Console view")
                            {
                            o.Arg = "785,541 0,31";
                                o.ObjectClassArgL();
                                goto T;
                            }
                        }
                }
            if (NCKOLCTETU.GetIndexl != null)
                foreach (NCKOLCTETU tu in NCKOLCTETU.GetIndexl)
                {
                    if (tu.Name == "y7staticf-")
                    {
                        tu.Name += p.ToString();
                        break;
                    }
                }
                J:
                /*
                ConsoleShowWindow i = (ConsoleShowWindow)FormMenu.CatchOrCreativePackControl<ConsoleShowWindow>("Console static", "y7staticr", null);
                if (ObjectClass<ConsoleShowWindow>.GetIndexl != null)
                    foreach (ConsoleShowWindow w in ObjectClass<ConsoleShowWindow>.GetIndexl)
                    {
                        if (w.Name == "y7staticr")
                        {
                            i = w;
                            break;
                        }
                    }
                if (i == null)
                {
                    foreach (FormMenu fu in FormMenu.GetIndexl)
                    {
                        if (fu.PackName == "Console static")
                        {
                            fu.ObjectClassArgL();
                            goto J;
                        }
                    }
                }
                */
                ppl.ClickItem += (object senderp, ObjectEvent e) => {
                    if (ppl.GetCheckItem() != null)
                    {
                        ConsoleShowWindow i = (ConsoleShowWindow)FormMenu.CatchOrCreativePackControl<ConsoleShowWindow>("Console static", "y7staticr", null);
                        Listr(ppl.GetCheckItem(), y, i, ppl, "GetCheckItem");
                    }
                };
                ppl.CreatIteming += (object senderp, ObjectEvent e) => {
                    ConsoleShowWindow i = (ConsoleShowWindow)FormMenu.CatchOrCreativePackControl<ConsoleShowWindow>("Console static", "y7staticr", null);
                    Listr(ppl.GetItemCreating(), y, i, ppl, "GetItemCreating");
                };
                ppl.DevelopItem += (object sender, ObjectEvent e) => {
                    ItemListCs ipp = ppl.GetDevelopItem();
                    ConsoleShowWindow i = (ConsoleShowWindow)FormMenu.CatchOrCreativePackControl<ConsoleShowWindow>("Console static", "y7staticr", null);
                    Listr(ipp, y, i, ppl, "GetDevelopItem");
                    /*
                    if (ppl.GetDevelopItem() != null)
                    {
                        if (ipp.EtcString != null)
                        {
                            ServerSenderOppo o = JsonConvert.DeserializeObject<ServerSenderOppo>(ipp.EtcString);
                            if (o != null)
                            {
                                if (o.GetNewSender != null)
                                {
                                    SenderClassForm s = JsonConvert.DeserializeObject<SenderClassForm>(o.GetNewSender);
                                    if (s != null)
                                    {
                                        op.SetSenderClass(s);
                                        op.Sender();
                                        ppl.Invoke(new MethodInvoker(() => { try { ppl.AddItem(Class<ItemListCs>.Deserialize(op.GetSenderClassFormHandle().GetBytes), null); } catch (Exception ex) { UtilPrintf.Printf(UtilControl.Warn, ref r.p, "[Server Control In] " + ex.Message); } }));
                                    }
                                }
                            }
                        }
                    }
                    */
                };
                ppl.ReadlyCheckColor = Color.AliceBlue;
                ppl.CheckColor = Color.Aqua;
                ppl.Name += p.ToString();
                ppl.Text += p.ToString();
                //g.MenuStrip = new ContextMenuStrip();
                //g.MenuStrip.Items.Add("Reset");
                ppl.Invoke(new MethodInvoker(() => { ppl.AddItem(g, null); }));
                
                
                /*
                NewConsoleNetCY y = new NewConsoleNetCY();
                IPEndPoint p = null;

                string[] ipadd = args[0].Split(':');

                if (ipadd.Length <= 1)
                    p = new IPEndPoint(IPAddress.Parse(ipadd[0]).Address, 4563);
                else
                    p = new IPEndPoint(IPAddress.Parse(ipadd[0]).Address, int.Parse(ipadd[1]));
                y.IPBlind = p;
                y.Connent();
                y.AddBlind = new InfeNewConsoleHup(args[1], args[2], File.ReadAllText(args[3]), args[4]);
                y.LogUp();

                ConsoleShowWindow[] s = ObjectClass<ConsoleShowWindow>.GetIndexl;
                ConsoleShowWindow lm = null;
                ListVerCs c = new ListVerCs();
                foreach (ConsoleShowWindow w in s)
                {
                    if (w.Name.ToLower() == "Static area".ToLower())
                    {
                        lm = w;
                        break;
                    }
                }
                lm.ConsoleWriteLine("Connent " + args[0] + " Loading...");
                //Console.WriteLine("45f0fe");
                RunTServerFP f = new RunTServerFP(y);
                SenderClassForm fr = new SenderClassForm();
                fr.ControlClass = "MainSearch";
                f.HandleClassSender = fr;
                //Thread.Sleep(2630);
                //Console.WriteLine("45f0fe");
                f.Sender();
                lm.ConsoleWriteLine(args[0] + " Back byte");
                fr = f.GetBackHandleClassSender;


                ItemListCs g = Class<ItemListCs>.Deserialize(fr.GetBytes);
                c.FsWriteLQ = 10;
                c.ReadlyCheckColor = Color.AliceBlue;
                c.CheckColor = Color.Aqua;
                lm.ConsoleWriteLine(args[0] + " finish search");
                //Console.WriteLine(g.Text);
                if (c.InvokeRequired)
                    c.Invoke(new MethodInvoker(delegate { c.AddItem(g, null); }));
                else
                    c.AddItem(g, null);

                ListVebel k = null;

                if (ObjectClass<ListVebel>.GetIndexl != null)
                    foreach (ListVebel l in ObjectClass<ListVebel>.GetIndexl)
                    {
                        if (l.Name.ToLower() == "Code Core List-ipcontrol".ToLower())
                        {
                            k = l;
                        }
                    }

                c.Text = args[0] + "Server Connent";
                k.AddFormSope(c);
                */
                cw.ConsoleWriteLine("执行成功，并且成功连接了 " + p.ToString());
            }
            catch (Exception ex)
            {
                cw.ConsoleWriteLine("执行失败:" + ex.Message);
            }

            return 0;
        }

        public void Listr(ItemListCs ccf,NewConsoleNetCY c,ConsoleShowWindow sw,ListVerCs d,string iinfo)
        {
            if (ItemRegedit.GetIndexl != null)
            {
                foreach (ItemRegedit i in ItemRegedit.GetIndexl)
                {
                    if (i.Name == ccf.Name || i.Name == null)
                    {
                        HasServerConEvent h = new HasServerConEvent();
                        h.ItemListCs = ccf;
                        h.NewConsoleCY = c;
                        h.ListVerCs = d;
                        h.ConsoleShowWindow = sw;
                        h.Iinfo = iinfo;
                        i.ObjectEvents.SenderMsg(this, h);
                        break;
                    }
                }
            }
        }
        public string[] HelpCommand(string arg)
        {
            List<string> s = new List<string>();
            s.Add("连接服务器，启动一个窗口管理");
            s.Add("");
            s.Add("用法: ... <连接服务器的IP[:端口]> <连接用户> <连接密码> <连接证书的路径> <指纹(不会参与验证，但有些插件需要)>");
            return s.ToArray();
        }

        public string RunCommand()
        {
            return "connent";
        }
    }
}
