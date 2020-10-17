using ConsoleG.Core.com.setting;
using RunLCJVM;
using RunLCJVM.Window;
using SmProPub.Window.Forms.UsersControl;
using SmProPub.Window.Formw.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramWindowLoad
{
    public partial class ViewWindowListMainTo : Form
    {
        SeeModsConsoleRun st = null;
        public ViewWindowListMainTo(SeeModsConsoleRun st)
        {
            InitializeComponent();
            this.st = st;
            //ListVerItemList t = new ListVerItemList();
            //ListVerItemLine l1 = new ListVerItemLine();
            //listVerList1.AddTitleItem();
            //oldScrollBar1.Rexc = itemList1.SubItemShow;
            SubItemVer v = new SubItemVer();
            v.Text = "Windows Find";
            SubItemPanel p = new SubItemPanel();
            
            p.GetSetControl = listVerList1;
            v.GetSetSubItemPanels.Add(p);
            //p = new SubItemPanel();
            //p.GetSetControl = oldScrollBar1;
            v.GetSetSubItemPanels.Add(p);
            //oldScrollBar1.Dock = DockStyle.Right;
            listVerList1.Dock = DockStyle.Fill;
            setWindowControl1.PutSaveButtonInControl = false;
            setWindowControl1.AddItem(v);
            //v.Control.AutoScroll = false;
            setWindowControl1.GetPanelShow.Controls.Add(button1);
            button1.Show();
            button1.Location = new Point(15, 45);
        }

        private Form[] FormSp(MainWindow ct)
        {
            List<Form> df = new List<Form>();
            foreach (Control cy in ct.Controls)
            {
                if (cy is Form)
                {
                    df.Add((Form)cy);
                }
            }
            return df.ToArray();
        }
        public NCKOLCTETU[] NCKOLCTETUSp(MainWindow ct)
        {
            List<NCKOLCTETU> df = new List<NCKOLCTETU>();
            foreach (Control cy in ct.Controls)
            {
                if (cy is NCKOLCTETU)
                {
                    df.Add((NCKOLCTETU)cy);
                }
            }
            return df.ToArray();
        }

        private void ViewWindowListMainTo_Load(object sender, EventArgs e)
        {
            ListVerItemList t = new ListVerItemList();
            t.Text = FanYi.fromepk("RC", "mv.title.controlA", SeeModsConsoleRun.GetainClass.lauge);
            t.Weight = 120;
            listVerList1.AddTitleItem(t);
            ListVerItemList t2 = new ListVerItemList();
            t2.Text = FanYi.fromepk("RC", "mv.title.controlB", SeeModsConsoleRun.GetainClass.lauge);
            listVerList1.AddTitleItem(t2);
            List<ListVerItemLine> st = new List<ListVerItemLine>();
            foreach (Form dp in FormSp(this.st.mi))
            {
                ListVerItemLine li = new ListVerItemLine();
                li.Image = Image.FromHbitmap(dp.Icon.ToBitmap().GetHbitmap());
                li.Text = dp.Text;
                li.SaveObject = dp;
                ListVerItemLine li2 = new ListVerItemLine();
                li2.Text = FanYi.fromepk("RC", "mv.control.show", SeeModsConsoleRun.GetainClass.lauge, dp.GetType().Name, dp.Handle.ToString(), dp.GetType().GUID);
                li2.SaveObject = dp;
                li.SubItem = li2;
                st.Add(li);
            }
            foreach (NCKOLCTETU dp in NCKOLCTETUSp(this.st.mi))
            {
                ListVerItemLine li = new ListVerItemLine();
                li.Image = Image.FromHbitmap(dp.Icon.ToBitmap().GetHbitmap());
                li.Text = dp.Text;
                li.SaveObject = dp;
                ListVerItemLine li2 = new ListVerItemLine();
                li2.Text = FanYi.fromepk("RC", "mv.control.show", SeeModsConsoleRun.GetainClass.lauge, dp.GetType().Name, dp.Handle.ToString(), dp.GetType().GUID);
                li2.SaveObject = dp;
                li.SubItem = li2;
                st.Add(li);
            }

            foreach (ListVerItemLine lop in st)
                listVerList1.AddSubItem(lop, t, true);

            /*
            TitleItem rt = new TitleItem();
            rt.Text = FanYi.fromepk("RC", "mv.title.controlA",SeeModsConsoleRun.GetainClass.lauge);
            rt.SubText.Add(FanYi.fromepk("RC", "mv.title.controlB", SeeModsConsoleRun.GetainClass.lauge));
            //rt.SizeText = new int[] { 128, 1496 };
            //itemList1.TitleItem = rt;

            List<SubItem> st = new List<SubItem>();
            
            foreach(Form dp in FormSp(this.st.mi))
            {
                SubItem sub = new SubItem();
                sub.Image = Image.FromHbitmap(dp.Icon.ToBitmap().GetHbitmap());
                sub.Text = dp.Text;
                Label bc = new Label();
                bc.Name = dp.Name + dp.ToString() + "0";
                bc.AutoSize = true;
                //bc.Text = "操作类:" + dp.GetType().Name + "|操作ID绑定:" + bc.Handle.ToString() + "|操作GUID:" + dp.GetType().GUID;
                bc.Text = FanYi.fromepk("RC","mv.control.show", SeeModsConsoleRun.GetainClass.lauge, dp.GetType().Name, bc.Handle.ToString(), dp.GetType().GUID);
                bc.Show();

                sub.SubObject.Add(bc);

                st.Add(sub);
            }
            foreach (NCKOLCTETU dp in NCKOLCTETUSp(this.st.mi))
            {
                SubItem sub = new SubItem();
                sub.Image = Image.FromHbitmap(dp.Icon.ToBitmap().GetHbitmap());
                sub.Text = dp.Text;
                Label bc = new Label();
                bc.Name = dp.Name + dp.ToString() + "0";
                bc.AutoSize = true;
                //bc.Text = "操作类:" + dp.GetType().Name + "|操作ID绑定:" + bc.Handle.ToString() + "|操作GUID:" + dp.GetType().GUID;
                bc.Text = FanYi.fromepk("RC", "mv.control.show", SeeModsConsoleRun.GetainClass.lauge, dp.GetType().Name, bc.Handle.ToString(), dp.GetType().GUID);
                bc.Show();

                sub.SubObject.Add(bc);

                st.Add(sub);
            }
            itemList1.SubItem = st.ToArray();

            itemList1.Invok();
            */
        }

        Control clictr;

        private void button1_Click(object sender, EventArgs e)
        {
                LessAbout ac = null;
                if (clictr is Form)
                    ac = new LessAbout((Form)clictr);
                else
                    ac = new LessAbout((NCKOLCTETU)clictr);

                ac.Show();
        }

        private void listVerList1_ClickItem(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            ListVerItemLine li = listVerList1.GetFouceItem();
            if (li == null)
                return;
            clictr =  (Control)li.SaveObject;
            button1.Enabled = true;
        }
    }
}
