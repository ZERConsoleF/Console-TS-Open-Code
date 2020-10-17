using RunLCJVM.Window;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProgramWindowLoad;
using ConsoleG.Core.com.setting;
using RunLCJVM;
using ConsoleG.Core.net;
using SmProPub;
using System.Runtime.InteropServices;
using SmProPub.Window.Formw.Controle;
using System.Threading;
using SmPro.System;

namespace Main
{
    public class PCI
    {
        public static object[] Main(object[] sender,string arg)
        {
            try
            {
                string runmake = SmPro.System.System.GetSystemLoad(sender);
                if (runmake == "load")
                {
                    LoadInfoClass ft = new LoadInfoClass();
                    ft.ShowName = FanYi.fromepk("RC", "mv.lo", null);
                    ft.NameLoad = "Window Regedit";
                    ft.Package = "mo";
                    ft.Versign = "V1.0.0";
                    ft.Copyright = "Copyright (C) SeeMods 2020";

                    return new object[] { 0, ft };
                }
                if (runmake == "loading")
                {
                    //Console.WriteLine(arg);

                    MainWindow w = SmPro.System.System.GetSystemWindow(sender);
                    SeeModsConsoleRun rc = SmPro.System.System.GetSystemRun(sender);

                    /*
                    new Thread(() => {
                        BitForm p7 = new BitForm(new TaskList());
                        p7.ShowInvokeToForm(w);
                        p7.Location = new System.Drawing.Point(0, w.TitlePan.Height);
                        Application.Run(p7);
                    }).Start();
                    */

                    /*
                    object[] op = rc.oc.ToArray();
                    foreach (object[] ui in op)
                    {
                        Console.WriteLine(((LoadInfoClass)ui[0]).ShowName);
                    }
                    */

                    ToolStripMenuItem i = new ToolStripMenuItem();

                    Memuseopenisty Mem = new Memuseopenisty(rc);
                    ToolStripItemCollection cob = Mem.menuStrip1.Items;

                    List<ToolStripMenuItem> o = new List<ToolStripMenuItem>();

                    foreach (ToolStripMenuItem iy in cob)
                    {
                        o.Add(df(iy));
                    }

                    w.menusp.Items.AddRange(o.ToArray());

                    //w.Size = Mem.menuStrip1.Size;

                    /*
                    GF p = new GF();
                    p.st = "456";

                    Class<GF>.Java.Finl(p);

                    GF op = Class<GF>.Java.Finl(p.ToString());
                    Console.WriteLine(op.st);
                    */
                }


                return new object[] { 0 };
            }
            catch (Exception ex)
            {
                SmException exc = new SmException();
                exc.CodeLine = "mov 00,0t";
                exc.FailWhy = ex.Message;
                exc.ID = -13;
                return new object[] { exc.ID, exc };
            }
        }
        private static ToolStripMenuItem df(ToolStripMenuItem iy)
        {
            ToolStripItemCollection cob = iy.DropDownItems;
            iy.Text = FanYi.frome(iy.Text,SeeModsConsoleRun.GetainClass.lauge);

            List<ToolStripItem> iyo = new List<ToolStripItem>();
            foreach (ToolStripItem u2 in cob)
            {
                if (u2 is ToolStripMenuItem)
                    iyo.Add(df((ToolStripMenuItem)u2));
                else
                    iyo.Add(u2);
            }
            iy.DropDownItems.Clear();
            iy.DropDownItems.AddRange(iyo.ToArray());
            return iy;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public class GF
    {
        public string st { get; set; }
    }
}
