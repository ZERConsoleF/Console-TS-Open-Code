using ConsoleG.Core.net;
using RunLCJVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmCmd.Newwork.Server;
using ConsoleG.Network.Server;
using System.Net;
using ConsoleG.Network.InShowServer;
using ConsoleG.Network;
using System.SmProPub.Event;
using System.Diagnostics;
using ConsoleG.Core.com;
using SmProPub.MakeRun;
using SmPro.System;
using RunLCJVM.ServerStart;

namespace Main
{
    public class PCI
    {
        public static object[] Main(object[] sender, string arg)
        {
            string ve = SmPro.System.System.GetSystemLoad(sender);
            SeeModsConsoleRunServer r = SmPro.System.SystemServer.GetSystemRun(sender);
            if (ve == "load")
            {
                LoadInfoClass c = new LoadInfoClass();
                c.Comment = "Server Start";
                c.Copyright = "Copyright (C) SeeMods 2020";
                c.Package = "SPC";
                c.NameLoad = "Server Start";
                c.ShowName = "Server Start";
                c.Versign = "V1.0.0";
                return new object[] { 0, c };
            }
            //string ifq = JsonConvert.SerializeObject(new ServerStartIP());
            //File.WriteAllText("ThisServer/ServerStart.ini",ifq);
            if (ve == "loading")
            {
                StartVoid(r);
            }
            if (ve == "sever-loading")
            {
                StartVoid(r);
            }
            if (ve == "getcmd")
            {
                new RegeditCmdServer().RunInGet.AddRange(new RunCommandToServer[] { new ServerControl() });
            }
            return new object[] { 0 };
        }
        private static void StartVoid(SeeModsConsoleRunServer r)
        {
            string Lp = File.ReadAllText("ThisServer/ServerStart.ini");
            ServerStartIP i = JsonConvert.DeserializeObject<ServerStartIP>(Lp);
            NewConsoleNetSr s = new NewConsoleNetSr();
            s.Name = SmProConst.GetServerSockName;
            IPEndPoint p = null;

            if (i.IPStart == null)
            {
                p = new IPEndPoint(IPAddress.Any.Address, int.Parse(i.Port));
            }
            else
                p = new IPEndPoint(IPAddress.Parse(i.IPStart).Address, int.Parse(i.Port));
            s.IPBlind = p;
            s.ListernAbout = i.ListernNumber;
            s.ServerBindAbout = i.ServerLogUpUserControl;
            s.WaitContiue = i.WaitContiue;
            s.WaitTime = i.WaitTime;
            s.ThisName = Environment.MachineName;
            s.ServerBindAbout.ServerName = i.ServerLogUpUserControl.ServerName;
            s.ByteGetS = i.ByteIndex;
            s.Blind();
            s.StartConnentAnys();
            
            RunTAtServer sp = new RunTAtServer(s);
            sp.GetRegeditMD();
            sp.GetAutuoRegeditMD();
            s.NewSender += (object sender, ObjectEvent e) => {
                ServerSenderAdd a = (ServerSenderAdd)e;
                NewConsoleNetSr et = sender as NewConsoleNetSr;
                DateTime g = DateTime.Now;
                string filename = string.Format("Socket_Add.{0}-{1}-{2}.{3}.log", g.Year, g.Month, g.Day, g.Hour);
                string filepath = "ThisServer/Log/" + filename;

                FileStream stfile = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                stfile.Position = stfile.Length;
                byte[] bppn = Encoding.Default.GetBytes(string.Format("[Socket] [{0}] [{1}] {2}", DateTime.Now.ToString(), ((IPEndPoint)a.Sender.RemoteEndPoint).Address.ToString(), "Socket Blind | User :" + et.FindSaveServerSocketSocket(a.Sender).User.User) + "\n");
                stfile.Write(bppn, 0, bppn.Length);
                stfile.Close();
                stfile.Dispose();
            };
            s.ExceptionHappen += (object sender, ObjectEvent e) => {
                NewConsoleNetSr et = sender as NewConsoleNetSr;
                DateTime g = DateTime.Now;
                string filename = string.Format("Exception.{0}-{1}-{2}.{3}.log", g.Year, g.Month, g.Day, g.Hour);
                string filepath = "ThisServer/Log/" + filename;

                FileStream stfile = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                stfile.Position = stfile.Length;
                byte[] bppn = Encoding.Default.GetBytes(et.Exception[et.Exception.Length - 1].Message + "\n");
                stfile.Write(bppn, 0, bppn.Length);
                stfile.Close();
                stfile.Dispose();
                //Console.WriteLine(et.Exception[et.Exception.Length - 1]);
            };
            s.SenderByte += (object sender, ObjectEvent e) => {
                ServerSenderOveEvent a = (ServerSenderOveEvent)e;
                NewConsoleNetSr et = sender as NewConsoleNetSr;
                DateTime g = DateTime.Now;
                string filename = string.Format("Socket_SenderByte.{0}-{1}-{2}.{3}.log", g.Year, g.Month, g.Day, g.Hour);
                string filepath = "ThisServer/Log/" + filename;

                FileStream stfile = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                stfile.Position = stfile.Length;
                byte[] bppn = Encoding.Default.GetBytes(string.Format("[Socket] [{0}] [{1}] {2}", DateTime.Now.ToString(), ((IPEndPoint)a.Sender.RemoteEndPoint).Address.ToString(), "Sender Byte Length:" + a.SenderOver.LongLength) + "\n");
                stfile.Write(bppn, 0, bppn.Length);
                stfile.Close();
                stfile.Dispose();
            };
            s.ExceptionClosed += (object sender, ObjectEvent e) =>
            {
                NetWorkExceptionClosed c = (NetWorkExceptionClosed)e;
                DateTime g = DateTime.Now;
                string filename = string.Format("Socket_Closed.{0}-{1}-{2}.{3}.log", g.Year, g.Month, g.Day, g.Hour);
                string filepath = "ThisServer/Log/" + filename;

                FileStream stfile = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                stfile.Position = stfile.Length;
                byte[] bppn = Encoding.Default.GetBytes(string.Format("[Socket] [{0}] [{1}] Exception Close", DateTime.Now.ToString(), c.IPAddress.Address.ToString()) + "\n");
                stfile.Write(bppn, 0, bppn.Length);
                stfile.Close();
                stfile.Dispose();
            };
            s.Closed += (object sender, ObjectEvent e) => {
                NewWorkServerClosed c = (NewWorkServerClosed)e;
                DateTime g = DateTime.Now;
                string filename = string.Format("Socket_Closed.{0}-{1}-{2}.{3}.log", g.Year, g.Month, g.Day, g.Hour);
                string filepath = "ThisServer/Log/" + filename;

                FileStream stfile = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                stfile.Position = stfile.Length;
                byte[] bppn = Encoding.Default.GetBytes(string.Format("[Socket] [{0}] [{1}] Dis Close", DateTime.Now.ToString(), c.IPAddress.Address.ToString()) + "\n");
                stfile.Write(bppn, 0, bppn.Length);
                stfile.Close();
                stfile.Dispose();
            };
            AutuoClass.Regedit();

            /*
            ServerIns sq = new ServerIns();
            sq.CAIIndex = "1f12d1212a1011s70d57e0d4s0a05z04d0e025s02d5e0a10d0f45e0d5s6a000d55e2s02d93e65d4e04s0d1e5s0e41d0w5d01s02a02a05d0sj17h4g10h12f54502hy21h02r1";
            sq.ServerIndex = "4";
            sq.ServerName = i.ServerLogUpUserControl.ServerName;
            //Console.WriteLine(sq.MakeOne());
            //ServerIns.DeMake(sq.MakeOne());
            */
        }
    }
}
