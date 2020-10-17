using RunLCJVM;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmPro.System
{
    public static class CreativeWindow
    {
        public static FormMenu CreativeListName(int Idx)
        {
            foreach (FormMenu m in FormMenu.GetIndexl)
            {
                if (m.IDX == Idx)
                {
                    //new Thread(() => { m.ObjectClassArgL(); }).Start();
                    return m;
                }
            }
            return null;
        }
        public static NCKOLCTE CreativeInWindow(string name)
        {
            NCKOLCTE t = new NCKOLCTE();
            //t.Name = name + ".spwindow" + new Random().Next();
            t.Text = name;
            t.TitleName.Text = name;
            //ObjectClass<Form> c = new ObjectClass<Form>();
            //c.SaveInMemory(t);
            t.TopLevel = false;
            SeeModsConsoleRun.GetainClass.mi.AddControlInvoke(t);
            t.Location = new Point(0, SeeModsConsoleRun.GetainClass.mi.TitlePan.Height);
            return t;
        }
    }
}
