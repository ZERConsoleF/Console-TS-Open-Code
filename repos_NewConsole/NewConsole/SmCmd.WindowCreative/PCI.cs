using ConsoleG.Core.com.setting;
using ConsoleG.Core.net;
using ConsoleG.WindowG;
using RunLCJVM;
using RunLCJVM.Window;
using SmCmd.WindowCreative;
using SmPro.System;
using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string vc = SmPro.System.System.GetSystemLoad(sender);
            MainWindow pc = SmPro.System.System.GetSystemWindow(sender);
            if (vc == "load")
            {
                LoadInfoClass c = new LoadInfoClass();
                c.Comment = "Server WindowCreative";
                c.Copyright = "Copyright (C) SeeMods 2020";
                c.Package = "cw";
                c.NameLoad = "Show Load Window";
                c.ShowName = "Show Load (C)";
                c.Versign = "V1.0.0";
                return new object[] { 0, c };
            }
            if (vc == "loading")
            {
                FindMainWindowMenu u = new FindMainWindowMenu(pc);
                u.SetAMenu(1);
                ToolStripMenuItem pof = u.BackMenu();
                ToolStripMenuItem uy = new ToolStripMenuItem();
                uy.Name = "Click";
                uy.Text = FanYi.frome("menu.m2.l2", SmPro.System.System.GetSystemRun(sender).lauge);
                pof.DropDownItems.Add(uy);
                uy.Click += Uy_Click;
            }
            if (vc == "getcmd")
            {
                new RegeditCmd().RunInGet.AddRange(new RunCommandTo[] { new CreativeGetWindow() });
            }
            return new object[] { 0 };
        }

        private static void Uy_Click(object sender, EventArgs e)
        {
            new FormLessOne().ShowDialog();
        }
    }
}
