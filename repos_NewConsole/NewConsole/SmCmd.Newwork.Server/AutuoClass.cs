using ConsoleG.Core.com.setting;
using ConsoleG.Network.InShowClient;
using ConsoleG.Network.InShowServer;
using ConsoleG.Network.Server;
using ConsoleG.Network.ServerMent;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RunLCJVM;
using RunLCJVM.ServerStart;
using SmPro.System;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmCmd.Newwork.Server
{
    public static class AutuoClass
    {
        public static void Regedit()
        {
            RegeditThis t = new RegeditThis();
            t.RegRuns = new RunAtAdd[] { new ClientList(), new ServerFileDownload(), new ServerFileList(), new ServerUserBack(), new ServerSleepRevice() };
            t.Regedit();
        }
    }

    /// <summary>
    /// 显示基础操控
    /// </summary>
    public class ClientList : RunAtAdd
    {
        public Exception BackException { get; set; }
        public SenderClassForm BackSenderClass { get; set; }

        public string ClassName()
        {
            return "MainSearch";
        }

        public void Execute(NewConsoleNetSr sr, ServerSenderOveEvent s, SenderClassForm f)
        {
            string pkFanYi = "ServerFP";
            ItemListCs c = new ItemListCs();
            c.Type = "Main";
            c.Name = "0";
            string ip = sr.GetThisSocket.LocalEndPoint.ToString();
            try
            {
                IPAddress ServerIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                ip = ServerIp.ToString(); //获得字符串形式的IP值
            }
            catch
            {

            }
            c.Text = FanYi.fromepk(pkFanYi, "item.main", SeeModsConsoleRunServer.GetainClass.lauge, ip);
            c.Hight = 10;
            //c.MenuStrip = new ContextMenuStrip();
            //c.MenuStrip.Items.Add("0");

            //List<string> regedit = new List<string>();
            //regedit.Add(FanYi.fromepk(pkFanYi, "item.username", SeeModsConsoleRun.GetainClass.lauge));
            //regedit.Add(FanYi.fromepk(pkFanYi, "item.serverset", SeeModsConsoleRun.GetainClass.lauge));

            //List<ItemListCs> cs = new List<ItemListCs>();

            //int d = 1;
            ItemListCs[] cs = JsonConvert.DeserializeObject<ItemRegedit>(File.ReadAllText("ThisServer/MainSearch.ini")).Items;
            foreach (ItemListCs nb in cs)
            {
                nb.Text = FanYi.fromepk(pkFanYi, nb.Text, SeeModsConsoleRunServer.GetainClass.lauge);
                //ItemListCs c2 = new ItemListCs();
                //c2.Type = "Dir";
                //c2.Name = d.ToString();
                //c2.Text = nb;

                //c2.Hight = 4;
                //cs.Add(c2);
                //d++;
            }
            c.SubItems = new List<ItemListCs>(cs);
            if (ServerItemRegedit.ServerItemRegeditr != null)
                c.SubItems.AddRange(ServerItemRegedit.ServerItemRegeditr.ItemListCs.ToArray());
            f.GetBytes = Class<ItemListCs>.Serialize(c);
            f.GetControlType = "0:200:ItemListCs";
            f.SuccessRuned = true;
            BackSenderClass = f;
        }
    }
    public class ItemRegedit
    {
        public ItemListCs[] Items { get; set; }
    }
}
