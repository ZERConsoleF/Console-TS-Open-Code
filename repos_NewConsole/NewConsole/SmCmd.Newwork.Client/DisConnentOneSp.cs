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

namespace SmCmd.Newwork.Client
{
    public class DisConnentOneSp : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            return new Exception("无法知道的错误");
        }

        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            string[] args = String64.MakeArg(arg);
            cw.FortText = Color.Aqua;

            if (args.Length < 1)
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
                cw.ConsoleWriteLine("注销连接\r\nCopyright (C) SeeMods 2020 版权所有");
                cw.ConsoleWriteLine("Disconnent...");
                if (r.args.Server)
                {
                    cw.ConsoleWriteLine("在服务器，Disconnent不可用...");
                    return 0;
                }
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
                NewConsoleNetCY c = NewConsoleNetCY.GetSocketInName("Conent>" + p.ToString());
                if (c == null)
                {
                    cw.ConsoleWriteLine("没有寻找到连接!");
                    return 0;
                }
                c.StopAutuoRevice();
                c.Close();
                ObjectClass<NewConsoleNetCY>.DisopseInMemory(c);
                /*
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
                */
                if (NCKOLCTETU.GetIndexl != null)
                    foreach (NCKOLCTETU tu in NCKOLCTETU.GetIndexl)
                    {
                        if (tu.Name == "y7staticf-" + p.ToString())
                        {
                            tu.Dispose();
                        }
                    }
                        /*
                        ListVerCs ppl = null;

                    if (ObjectClass<ListVerCs>.GetIndexl != null)
                        foreach (ListVerCs apr in ObjectClass<ListVerCs>.GetIndexl)
                        {
                            if (apr.Name == "y7staticr-" + p.ToString())
                            {
                                ppl = apr;
                                break;
                            }
                        }

                    if (ppl == null)
                    {
                        goto K;
                    }
                    ObjectClass<ListVerCs>.DisopseInMemory(ppl);
                    ppl.Dispose();
                    */


                        //ppl.Invoke(new MethodInvoker(() => { ppl.AddItem(g, null); }));
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
                        /*
                        foreach (FormPanelControl fp in FormPanelControl.GetIndexl)
                        {
                            if (fp.Name == "Windows Control")
                            {
                                FormPanelItems ipg = null;

                                foreach (FormPanelItems u in fp.GetFormPanelItems())
                                {
                                    if (u.Name == "Server View")
                                    {
                                        ipg = u;
                                        break;
                                    }
                                }
                                if (ipg == null)
                                {
                                    foreach (FormMenu o in FormMenu.GetIndexl)
                                    {
                                        if (o.PackName == "Console view")
                                        {
                                            o.Arg = "785,541 0,31";
                                            o.ObjectClassArgL();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        */
                        K:
                cw.ConsoleWriteLine("执行成功，并且成功关闭了 " + p.ToString());
            }
            catch (Exception ex)
            {
                cw.ConsoleWriteLine("执行失败:" + ex.Message + " 它可能被关闭了，但是已从内存记录中删除");
            }

            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            List<string> s = new List<string>();
            s.Add("注销连接，关闭管理窗口");
            s.Add("");
            s.Add("用法: ... <连接服务器的IP[:端口]>");
            return s.ToArray();
        }

        public string RunCommand()
        {
            return "disconnent";
        }
    }
}
