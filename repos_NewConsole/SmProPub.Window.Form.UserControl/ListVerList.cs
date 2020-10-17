using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.SmProPub.Event;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class ListVerList : UserControl
    {
        public ListVerList()
        {
            InitializeComponent();
            ItemHeight = 20;
            ItemFreeWight = 5;
            MoveFree = 4;
            BackColor1 = SystemColors.Control;
            BackColor2 = Color.White;
            CheckColor = Color.Aqua;
            ReadyCheckColor = Color.AliceBlue;
            CheckForIllegalCrossThreadCalls = false;
        }
        #region
        /// <summary>
        /// 统一高度
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(20)]
        [Description("统一高度")]
        public int ItemHeight { get; set; }
        /// <summary>
        /// 统一预留宽度
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(5)]
        [Description("统一预留宽度")]
        public int ItemFreeWight { get; set; }
        /// <summary>
        /// 移动时给予的空闲空间
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(4)]
        [Description("移动时给予的空闲空间")]
        public int MoveFree { get; set; }

        /// <summary>
        /// Item背景颜色1
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Item背景颜色1")]
        public Color BackColor1 { get; set; }
        /// <summary>
        /// Item背景颜色2
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Item背景颜色2")]
        public Color BackColor2 { get; set; }
        /// <summary>
        /// Check Color
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Check Color")]
        public Color CheckColor { get; set; }
        /// <summary>
        ///  Free Check Color
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Free Check Color")]
        public Color ReadyCheckColor { get; set; }
        /// <summary>
        /// (可以转换为<see cref="ObjectCheckEvent"/>)点击的项目事件
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [Description("点击的项目事件")]
        public event ObjectEventArg ClickItem;
        /// <summary>
        /// (可以转换为<see cref="ObjectCheckEvent"/>)预点击的项目事件
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [Description("预点击的项目事件")]
        public event ObjectEventArg ReadyClickItem;
        /// <summary>
        /// 是否多项点击
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("是否多项点击")]
        public bool ClickMore { get; set; }
        #endregion
        #region
        List<ListVerItemList> riyetr = new List<ListVerItemList>();
        List<ListVerItemLine> riyetle = new List<ListVerItemLine>();
        List<ListVerItemLine> riroyetle = new List<ListVerItemLine>();
        int xfd = 0;
        PanelMoveList vdfc;
        List<PanelMoveList> vdrt = new List<PanelMoveList>();
        #endregion
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="c"></param>
        public void AddTitleItem(ListVerItemList c)
        {
            Control r = this;

            PanelMoveList p = new PanelMoveList();
            p.BackColor = c.BackColor;
            p.Name = "titlepanel." + c.Name;
            p.Width = c.Weight;
            p.Dock = DockStyle.Left;
            Size y = p.Size;
            //p.AutoSize = true;
            //p.AutoSize = false;
            //p.Size = y;

            TopControlAdd(r, p);
            p.Show();

            PanelMoveList l = new PanelMoveList();
            l.Name = "panelmlisttxt." + c.Name;
            l.Dock = DockStyle.Top;
            l.AutoSize = true;
            void fgrv() { p.Controls.Add(l); }
            /*
            if (p.InvokeRequired)
                p.BeginInvoke(new MethodInvoker(fgrv));
            else
                */
                fgrv();
            l.Show();
            l.MouseMove += P_MouseMove;
            l.MouseMove += P_MouseMove1;
            l.MouseDown += P_MouseDown;
            l.PanelMoveLisist = p;
            l.Height = ItemHeight;


            LabelMoveList li = new LabelMoveList();
            li.Name = "labeltext." + c.Name;
            li.Text = c.Text;
            li.AutoSize = true;
            void fghyt(){ l.Controls.Add(li); }
            /*
            if (l.InvokeRequired)
                l.BeginInvoke(new MethodInvoker(fghyt));
            else
                */
                fghyt();
            li.Show();
            li.PanelMoveLisist = p;
            l.LabelText = li;
            li.MouseMove += Li_MouseMove;

            PanelMoveList pr = new PanelMoveList();
            pr.Name = "sighfr." + c.Name;
            pr.BackColor = SystemColors.Control;
            pr.Dock = DockStyle.Right;
            pr.Width = 1;
            pr.Show();
            //pr.MouseMove += P_MouseMove;
            //pr.MouseMove += P_MouseMove1;
            //pr.MouseDown += P_MouseDown;
            pr.PanelMoveLisist = p;
            void dft() { l.Controls.Add(pr); }
            /*
            if (l.InvokeRequired)
                l.BeginInvoke(new MethodInvoker(dft));
            else
                */
                dft();

            li.Dock = DockStyle.Top;
            li.Location = new Point(ItemFreeWight, (l.Height - li.Height) / 2);
            riyetr.Add(c);
            c.CD = l;
            c.CB = p;

            foreach (ListVerItemLine e in c.SubItem)
                AddSubItem(e, c, false);
        }
        /// <summary>
        /// 添加子项
        /// </summary>
        /// <param name="c">子项</param>
        /// <param name="c1">标题</param>
        /// <param name="hasmr">是否进行添加到标题</param>
        public void AddSubItem(ListVerItemLine c,ListVerItemList c1,bool hasmr)
        {
            PanelMoveList t = new PanelMoveList();
            c.CD = t;
            t.Name = "gt." + c.Name;
            t.Dock = DockStyle.Top;
            t.Height = ItemHeight;
            //c1.CB.Controls.Add(t);
            TopControlAdd(c1.CB, t);
            t.Show();
            t.Click += T_Click;
            t.MouseHover += T_MouseHover;
            t.MouseLeave += T_MouseLeave;

            t.ListVerItemLine = c;
            //LeastControls(c1.CB);

            if (c.Controls.Count <= 0)
            {
                int gh = ItemFreeWight;
                if (c.Image != null)
                {
                    PictureBox p = new PictureBox();
                    p.Name = "picturebods." + c.Name;
                    p.Image = c.Image;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Size = new Size(t.Height, t.Height);
                    p.Left = gh;
                    t.Controls.Add(p);
                    p.Show();
                    gh += p.Width + ItemFreeWight;
                }

                LabelMoveList l = new LabelMoveList();
                l.Name = "Labelhtdser7." + c.Name;
                l.Text = c.Text;
                l.Click += L_Click;
                l.MouseHover += L_MouseHover;
                l.MouseLeave += L_MouseLeave;
                l.Left = gh;

                l.AutoSize = true;
                //l.Location = new Point(gh, (c1.CB.Height - l.Height) / 2);
                void dfrt(){ t.Controls.Add(l); }
                /*
                if (t.InvokeRequired)
                    t.BeginInvoke(new MethodInvoker(dfrt));
                else
                    */
                    dfrt();
                l.Show();
                l.PanelMoveLisist = t;
                c.CT = l;
            }
            else
            {
                foreach (Control fgt in c.Controls)
                {
                    void dfrt() { t.Controls.Add(fgt); }
                    /*
                    if (t.InvokeRequired)
                        t.BeginInvoke(new MethodInvoker(dfrt));
                    else
                        */
                        dfrt();
                }
            }

            t.BackColor = (xfd == 0) ? BackColor1 : BackColor2;
            t.ReadBackColor = t.BackColor;

            if (c.SubItem == null)
            {
                xfd = (xfd == 0) ? 1 : 0;
            }
            else
            {
                int fgh = 0;
                foreach (ListVerItemList li in riyetr)
                {
                    if (li == c1)
                    {
                        break;
                    }
                    fgh++;
                }
                if (fgh + 1 < riyetr.Count)
                {
                    AddSubItem(c.SubItem, riyetr[fgh + 1], false);
                    c.CD.PanelMoveLists.Add(c.SubItem.CD);
                    c.SubItem.CD.PanelMoveListsy.Add(c.CD);
                }

            }

            if (hasmr)
            {
                c1.SubItem.Add(c);
            }
            riyetle.Add(c);
        }
        /// <summary>
        /// 移除项目
        /// </summary>
        /// <param name="c"></param>
        public void RemoveTitleItem(ListVerItemList c)
        {
            c.CB.Dispose();
            riyetr.Remove(c);
        }
        /// <summary>
        /// 移除他的项目
        /// </summary>
        /// <param name="c"></param>
        public void RemoveSubItem(ListVerItemLine c)
        {
            c.CD.Dispose();
            RemoveSubItem(c.SubItem);
            riyetle.Remove(c.SubItem);
        }
        /// <summary>
        /// 移除所有子项
        /// </summary>
        public void ClearSub()
        {
            foreach (ListVerItemLine e in riyetle)
            {
                e.CD.Dispose();
            }
            riyetle.Clear();
        }
        /// <summary>
        /// 移除所有主项和子项
        /// </summary>
        public void Clear()
        {
            ClearSub();
            foreach (ListVerItemList l in riyetr)
            {
                l.CB.Dispose();
            }
            riyetr.Clear();
        }

        /// <summary>
        /// 获取注册在这的的标题
        /// </summary>
        /// <returns></returns>
        public ListVerItemList[] GetTitleItem()
        {
            return riyetr.ToArray();
        }
        /// <summary>
        /// 注册在这的子项目
        /// </summary>
        /// <returns></returns>
        public ListVerItemLine[] GetSubItem()
        {
            return riyetle.ToArray();
        }
        /// <summary>
        /// 获取点击的项目
        /// </summary>
        /// <returns></returns>
        public ListVerItemLine GetFouceItem()
        {
            if (vdfc != null)
                return vdfc.ListVerItemLine;
            else
                return null;
        }
        /// <summary>
        /// 获取多项目点击
        /// </summary>
        /// <returns></returns>
        public ListVerItemLine[] GetFouceItems()
        {
            PanelMoveList[] t = vdrt.ToArray();
            List<ListVerItemLine> uh = new List<ListVerItemLine>();

            foreach (PanelMoveList tyt in t)
                uh.Add(tyt.ListVerItemLine);
            return uh.ToArray();
        }
        /// <summary>
        /// 焦点或失去焦点
        /// </summary>
        /// <param name="c"></param>
        public void FoucesLostItem(ListVerItemLine c)
        {
            Vitr(c.CD, null);
        }

        private void T_MouseLeave(object sender, EventArgs e)
        {
            PanelMoveList yt = sender as PanelMoveList;
            if (!yt.CheckOne)
                Vitc(yt, true,null);
        }

        private void T_MouseHover(object sender, EventArgs e)
        {
            PanelMoveList yt = sender as PanelMoveList;
            if (!yt.CheckOne)
                Vitc(yt, false,null);
        }

        private void L_MouseLeave(object sender, EventArgs e)
        {
            LabelMoveList l = sender as LabelMoveList;
            if (!l.PanelMoveLisist.CheckOne)
                Vitc(l.PanelMoveLisist, true,null);
        }

        private void L_MouseHover(object sender, EventArgs e)
        {
            LabelMoveList l = sender as LabelMoveList;
            if (!l.PanelMoveLisist.CheckOne)
                Vitc(l.PanelMoveLisist, false,null);
        }

        private void L_Click(object sender, EventArgs e)
        {
            LabelMoveList l = sender as LabelMoveList;

            Vitr(l.PanelMoveLisist,null);
        }

        private void T_Click(object sender, EventArgs e)
        {
            PanelMoveList yt = sender as PanelMoveList;

            Vitr(yt,null);
        }
        private void VitrFG(PanelMoveList hytb, PanelMoveList hytb1)
        {
            hytb.BackColor = hytb.ReadBackColor;
            hytb.CheckOne = false;

            foreach (PanelMoveList ttr in hytb.PanelMoveLists)
            {
                if (ttr == hytb1)
                    continue;
                VitrFG(ttr, hytb);
            }
            foreach (PanelMoveList ttr in hytb.PanelMoveListsy)
            {
                if (ttr == hytb1)
                    continue;
                VitrFG(ttr, hytb);
            }
        }
        private void Vitr(PanelMoveList hytb, PanelMoveList hytb1)
        {
            if (hytb == vdfc)
                return;
            if (!ClickMore)
            {
                if (vdfc != null)
                    VitrFG(vdfc, null);
            }
            hytb.BackColor = hytb.CheckOne ? hytb.ReadBackColor : CheckColor;
            hytb.CheckOne = !hytb.CheckOne;

            if (ClickMore)
                if (hytb.CheckOne)
                {
                    vdrt.Add(hytb);
                }
                else
                {
                    vdrt.Remove(hytb);
                }

            foreach (PanelMoveList ttr in hytb.PanelMoveLists)
            {
                if (ttr == hytb1)
                    continue;
                Vitr(ttr, hytb);
            }
            foreach (PanelMoveList ttr in hytb.PanelMoveListsy)
            {
                if (ttr == hytb1)
                    continue;
                Vitr(ttr, hytb);
            }


            if (hytb.CheckOne)
                vdfc = hytb;
            else
                vdfc = null;
            if (ClickItem != null)
            {
                ObjectCheckEvent c = new ObjectCheckEvent();
                c.ListVerItemLine = hytb.ListVerItemLine;
                ClickItem(this, c);
            }
        }
        private void Vitc(PanelMoveList hytb,bool hsdd, PanelMoveList hytb1)
        {
            hytb.BackColor = hsdd ? hytb.ReadBackColor : ReadyCheckColor;
            //hytb.CheckOne = !hytb.CheckOne;

            foreach (PanelMoveList ttr in hytb.PanelMoveLists)
            {
                if (ttr == hytb1)
                    continue;
                Vitc(ttr, hsdd,hytb);
            }
            foreach (PanelMoveList ttr in hytb.PanelMoveListsy)
            {
                if (ttr == hytb1)
                    continue;
                Vitc(ttr, hsdd,hytb);
            }
            if (ReadyClickItem != null)
            {
                ObjectCheckEvent c = new ObjectCheckEvent();
                c.ListVerItemLine = hytb.ListVerItemLine;
                ReadyClickItem(this, c);
            }
        }

        private void Li_MouseMove(object sender, MouseEventArgs e)
        {
            LabelMoveList dff = sender as LabelMoveList;

            if (dff.PanelMoveLisist.Width > dff.Left + dff.Width + 10)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int l = dff.PanelMoveLisist.Width;
                dff.PanelMoveLisist.Width = l + (e.X - el);
                el = e.X;
                if (dff.PanelMoveLisist.Width < MoveFree)
                    dff.PanelMoveLisist.Width = MoveFree;
            }
        }

        int el = 0;
        private void P_MouseDown(object sender, MouseEventArgs e)
        {
            el = e.X;
        }

        private void P_MouseMove1(object sender, MouseEventArgs e)
        {
            PanelMoveList dff = sender as PanelMoveList;
            if (e.Button == MouseButtons.Left)
            {
                int l = dff.PanelMoveLisist.Width;
                dff.PanelMoveLisist.Width = l + (e.X - el);
                el = e.X;
                if (dff.PanelMoveLisist.Width < MoveFree)
                    dff.PanelMoveLisist.Width = MoveFree;
            }
        }

        private void P_MouseMove(object sender, MouseEventArgs e)
        {
            PanelMoveList dff = sender as PanelMoveList;
            if (e.X > dff.Width - 10)
            {
                dff.Cursor = Cursors.NoMoveHoriz;
            }
            else
            {
                dff.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 将显示顺序翻转
        /// </summary>
        public void LeastControls()
        {
            List<Control> v = new List<Control>();
            for (int x = Controls.Count - 1; x >= 0; x--)
            {
                v.Add(Controls[x]);
            }
            foreach (Control l in v.ToArray())
            {
                Controls.Add(l);
            }
        }
        /// <summary>
        /// 将这个控件下的显示翻转
        /// </summary>
        /// <param name="cg"></param>
        public void LeastControls(Control cg)
        {
            List<Control> v = new List<Control>();
            for (int x = cg.Controls.Count - 1; x >= 0; x--)
            {
                v.Add(cg.Controls[x]);
            }
            foreach (Control l in v.ToArray())
            {
                cg.Controls.Add(l);
            }
        }
        /// <summary>
        /// 顶级添加控件
        /// </summary>
        /// <param name="thiscontrol">这个Control</param>
        /// <param name="addcontrol">准备添加Control</param>
        public void TopControlAdd(Control thiscontrol,Control addcontrol)
        {

            List<Control> c = new List<Control>();
            c.Add(new Control());

            foreach(Control rt in thiscontrol.Controls)
            {
                c.Add(rt);
            }
            c.Remove(addcontrol);
            c[0] = addcontrol;

            foreach(Control gh in c)
            {
                void dfg() { thiscontrol.Controls.Add(gh); }
                /*
                if (thiscontrol.InvokeRequired)
                    thiscontrol.BeginInvoke(new MethodInvoker(dfg));
                else
                    */
                    dfg();
            }
        }

        private void ListVerList_SizeChanged(object sender, EventArgs e)
        {

        }
    }
    /// <summary>
    /// <see cref="ListVerList"/>点击或预点击发生事件
    /// </summary>
    public class ObjectCheckEvent : ObjectEvent
    {
        public ListVerItemLine ListVerItemLine { get; set; }
    }
    public class PanelMoveList : Panel
    {
        public PanelMoveList()
        {
            PanelMoveLists = new List<PanelMoveList>();
            PanelMoveListsy = new List<PanelMoveList>();
        }
        public bool CheckOne { get; set; }
        public List<PanelMoveList> PanelMoveLists { get; set; }
        public List<PanelMoveList> PanelMoveListsy { get; set; }
        public PanelMoveList PanelMoveLisist { get; set; }
        public ListVerItemLine ListVerItemLine { get; set; }
        public ListVerItemList ListVerItemList { get; set; }
        public Label LabelText { get; set; }
        public Color ReadBackColor { get; set; }
    }
    public class LabelMoveList : Label
    {
        public LabelMoveList()
        {
            PanelMoveLists = new List<PanelMoveList>();
        }
        public bool CheckOne { get; set; }
        public List<PanelMoveList> PanelMoveLists { get; set; }
        public PanelMoveList PanelMoveLisist { get; set; }
        public Label LabelText { get; set; }
    }
    public class ListVerItemList
    {
        public ListVerItemList()
        {
            SubItem = new List<ListVerItemLine>();
            Weight = 100;
        }
        /// <summary>
        /// 绑定子列表
        /// </summary>
        public List<ListVerItemLine> SubItem { get; set; }
        /// <summary>
        /// 控件绑定文档
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标题文档
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 标题铜线
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// 标题颜色
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// 控件在内的容器
        /// </summary>
        public PanelMoveList CD { get; set; }
        /// <summary>
        /// 控件容器的容器
        /// </summary>
        public PanelMoveList CB { get; set; }
        public object SaveObject { get; set; }
    }
    public class ListVerItemLine
    {
        public ListVerItemLine()
        {
            Controls = new List<Control>();
        }

        /// <summary>
        /// 控件添加(添加这个Text不可用)
        /// </summary>
        public List<Control> Controls { get; set; }
        /// <summary>
        /// 绑定子项
        /// </summary>
        public ListVerItemLine SubItem { get; set; }
        /// <summary>
        /// 控件文本文档
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 控件绑定文档
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图像新建
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// 控件在内的容器
        /// </summary>
        public PanelMoveList CD { get; set; }
        /// <summary>
        /// 控件容器的容器
        /// </summary>
        //public PanelMoveList CB { get; set; }
        /// <summary>
        /// 控件Label
        /// </summary>
        public LabelMoveList CT { get; set; }
        public object SaveObject { get; set; }
    }
}
