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
using System.Threading;
//using SmProPub.System.Event;

namespace SmProPub.Window.Formw.Controle
{
    [ToolboxBitmap(typeof(ListView))]
    public partial class ItemList : UserControl
    {
        public ItemList()
        {
            InitializeComponent();
            SubItemHeight = 16;
            ClickOutColor = Color.Turquoise;
            BoredColor = new Color();
            sc = new List<SCP>();
        }
        #region
        /// <summary>
        /// 有病没病都来试一试<para>Change ObjectChange</para>
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Change ObjectChange")]
        public event ObjectEventArg AllChange;
        /// <summary>
        /// 在点击时发生<para>Change ClickChange</para>
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Change ClickChange")]
        public event ObjectEventArg ClickChange;
        /// <summary>
        /// 预点击的颜色
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue()]
        [Description("预点击的颜色")]
        public Color ClickOutColor { get; set; }
        /// <summary>
        /// 应当是否有边框
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("应当是否有边框")]
        public BorderStyle FixedSys { get; set; }
        /// <summary>
        /// 颜色变化(由BackColor与BoredColor交替显示)
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue(null)]
        [Description("颜色变化(由BackColor与BoredColor交替显示)")]
        public Color BoredColor { get; set; }
        /// <summary>
        /// 点击的颜色
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue()]
        [Description("点击的颜色")]
        public Color ClickColor { get; set; }
        /// <summary>
        /// 绑定他的标题
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("绑定标题")]
        public TitleItem TitleItem { get; set; }
        /// <summary>
        /// 绑定他的子项
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("绑定子项")]
        public SubItem[] SubItem { get; set; }
        /// <summary>
        /// 绑定他的子项的高度
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(16)]
        [Description("绑定子项的高度")]
        public int SubItemHeight { get; set; }
        #endregion

        #region Private Member
        private List<SCP> sc { get; set; }
        #endregion

        int redom0 = 0;

        /// <summary>
        /// 立刻执行，绘制项目
        /// </summary>
        public void Invok()
        {
            redom0 = 0;
            TitleList.Controls.Clear();
            SubItemShow.Controls.Clear();
            if (TitleItem == null)
                return;
            if (BoredColor == new Color())
                BoredColor = this.BackColor;
            #region 注册Title

            int[] xv = TitleItem.SizeText;

            if (xv.Length < TitleItem.SubText.Count + 1)
            {
                List<int> cy = new List<int>(xv);
                for (int fgh = xv.Length; fgh < TitleItem.SubText.Count + 1; fgh++)
                    cy.Add(xv[0]);
                TitleItem.SizeText = cy.ToArray();
            }

            List<Control> Controles = new List<Control>();

            int x = 0;
            int y = 0;

            Color col = this.BackColor;

            if (redom0 == 1)
            {
                col = BoredColor;
                redom0 = 0;
            }
            else
                redom0 = 1;

            Control t = MakePanel(col, "TitleName", x, y, TitleItem.SizeText[0], this.TitleList.Height, 0);
            Control l = MakeLabel(t.BackColor, "TitleLabel", true, TitleItem.Text, 0, 0, 0);
            //l.Location = new Point(l.Location.X, t.Height - l.Height);
            t.Controls.Add(l);
            l.Show();
            Controles.Add(t);

            x +=t.Width;

            for (int i = 1; i < TitleItem.SubText.Count + 1; i++)
            {
                if (redom0 == 1)
                {
                    col = BoredColor;
                    redom0 = 0;
                }
                else
                    redom0 = 1;
                //Console.WriteLine(x);
                t = MakePanel(col, "TitleName", x, y, TitleItem.SizeText[i], this.TitleList.Height, i);
                l = MakeLabel(t.BackColor, "TitleLabel", true, TitleItem.SubText[i - 1], 0, 0, i);
                //l.Location = new Point(l.Location.X, t.Height - l.Height);
                t.Controls.Add(l);
                l.Show();

                Controles.Add(t);

                x += t.Width;
            }

            foreach (Control cu in Controles.ToArray())
            {
                TitleList.Controls.Add(cu);
                cu.Show();
            }
            TitleList.Size = new Size(x, TitleList.Height);
            #endregion
            #region 注册子项
            redom0 = 0;
            if (SubItem == null)
                return;


            foreach (SubItem st in SubItem)
            {
                AddItem(st);
            }
            #endregion
        }
        int m0 = 0;
        private Control MakePanel(Color col, string name, int x, int y, int w, int h, int cout)
        {
            Panel p = new Panel();
            p.Name = name + "." + cout;
            p.BorderStyle = FixedSys;
            p.BackColor = col;

            p.Location = new Point(x, y);
            p.Size = new Size(w, h);
            return p;
        }
        private Control MakeLabel(Color col, string name, bool aut, string text,int x,int y, int cout)
        {
            Label l = new Label();
            l.Name = name + "." + cout;
            l.AutoSize = aut;
            l.Text = text;
            l.Font = this.Font;
            l.ForeColor = this.ForeColor;
            l.BackColor = col;

            l.Location = new Point(x, y);

            return l;
        }
        #region 事件注册
        private void ClickqcColor(object sender, MouseEventArgs e)
        {
            Control ct = (Control)sender;
            if (ui.Name != ct.Name)
                ct.BackColor = ClickOutColor;
        }
        private void ClickqwColor(object sender, EventArgs e)
        {
            Control ct = (Control)sender;
            if (ui.Name != ct.Name)
                ct.BackColor = BackColor;
        }
        private void ClickwcCl(object sender, MouseEventArgs e)
        {
            FocusItem((Control)sender);
        }
        /// <summary>
        /// 在已知的基础上选择FocusItem(Control)
        /// <para>异常:<para>引索超出了此界限</para></para>
        /// </summary>
        /// <param name="idx">值</param>
        public void FocusItem(int idx)
        {
            if (idx < 0)
                idx = 0;
            foreach(Control ci in sc[idx].ct[0].Controls)
            {
                if (ci is Label)
                {
                    FocusItem(ci);
                }
            }
        }
        /// <summary>
        /// 通过Label(在已知的的标题控件)控件选择它
        /// <para>异常:<para>无法转化为Label类</para></para>
        /// </summary>
        /// <param name="sender">可以转化为Label的Control</param>
        public void FocusItem(Control sender)
        {
            Control ct = sender;
            ui.BackColor = this.BackColor;
            if (xt != -1)
            {
                Color upp = BoredColor;
                BoredColor = this.BackColor;
                SelectLLo(this.BackColor, ui.Name);
                BoredColor = upp;
                
            }
            ct.BackColor = ClickColor;
            Color up = BoredColor;
            BoredColor = ClickColor;
            SelectLLo(ClickColor, ((Label)sender).Name);
            BoredColor = up;
            ui = ct;
            if (ClickChange != null)
            {
                ObjectEvent tr = new ObjectEvent();
                tr.Name = typeof(ItemList).Name + "::" + xt;
                tr.Comment = "SenderClickeve";
                tr.Save = xt;
                ClickChange(ui, tr);
            }

        }
        private void SelectLLo(Color hp,string tg)
        {
            for (int x = 0; x < sc.Count; x++)
            {
                SCP yo = sc[x];
                if (yo.name == tg)
                {
                    xt = x;
                    redom0 = 0;
                    foreach (Control i in yo.ct)
                        CloorContrl(hp, i);
                    break;
                }
            }
        }
        private void CloorContrl(Color cu,Control g)
        {
            Color col = cu;

            if (redom0 == 1)
            {
                col = BoredColor;
                redom0 = 0;
            }
            else
                redom0 = 1;
            g.BackColor = col;
            foreach (Control jk in g.Controls)
                CloorContrl(col, jk);
        }

        int xt = -1;
        Control ui = new Control();
        List<Control> cpe = new List<Control>();
        #endregion
        #region  用户操控
        /// <summary>
        /// 清空所有项目(包含选择但不释放)
        /// </summary>
        public void Clear()
        {
            ClearSelect();
            SubItem = null;
            TitleItem = null;
            sc = new List<SCP>();
            Invok();
            xt = -1;
            ui = new Control();
            x = y = m0 = 0;
        }
        int x, y = 0;
        /// <summary>
        /// 添加子项在后面
        /// </summary>
        /// <param name="st">项</param>
        public void AddItem(SubItem st)
        {
            List<Control> Controles = new List<Control>();
            SCP cv = new SCP();

            Color col = this.BackColor;

            if (redom0 == 1)
            {
                col = BoredColor;
                redom0 = 0;
            }
            else
                redom0 = 1;

            PictureBox pc = new PictureBox();
            pc.Size = new Size(SubItemHeight, SubItemHeight);
            pc.Location = new Point(0, 0);
            pc.SizeMode = PictureBoxSizeMode.StretchImage;

            if (st.Image != null)
                pc.Image = st.Image;
            Control t = MakePanel(col, "SubName", x, y, TitleItem.SizeText[0], SubItemHeight, 0 + m0);
            Control l = MakeLabel(t.BackColor, "SubLabel", true, st.Text, SubItemHeight + 5, 0, 0 + m0);

            l.MouseMove += new MouseEventHandler(ClickqcColor);
            l.MouseLeave += new System.EventHandler(ClickqwColor);
            //t.MouseMove += new MouseEventHandler(ClickqcColor);
            //t.MouseLeave += new System.EventHandler(ClickqwColor);
            l.MouseClick += new MouseEventHandler(ClickwcCl);
            //l.Location = new Point(l.Location.X, t.Height - l.Height);
            t.Controls.Add(l);
            t.Controls.Add(pc);
            pc.Show();
            l.Show();
            Controles.Add(t);
            cpe.Add(t);
            cv.name = l.Name;
            cv.ct.Add(t);

            x += t.Width;

            for (int i = 1; i < TitleItem.SubText.Count + 1; i++)
            {
                if (redom0 == 1)
                {
                    col = BoredColor;
                    redom0 = 0;
                }
                else
                    redom0 = 1;
                //Console.WriteLine(x);
                t = MakePanel(col, "SubName", x, y, TitleItem.SizeText[i], SubItemHeight, i + m0);
                l = st.SubObject[i - 1];
                //l.Location = new Point(l.Location.X, t.Height - l.Height);
                t.Controls.Add(l);
                l.Show();

                Controles.Add(t);
                cv.ct.Add(t);

                x +=t.Width;
            }

            x = 0;
            y += SubItemHeight;

            foreach (Control cu in Controles.ToArray())
            {
                SubItemShow.Controls.Add(cu);
                cu.Show();
            }
            sc.Add(cv);
            m0++;
        }
        /// <summary>
        /// 清空选择
        /// </summary>
        public void ClearSelect()
        {
            if (xt != -1)
            {
                SelectLLo(this.BackColor, sc[xt].name);
                ui = new Control();
            }
            xt = -1;
        }
        /// <summary>
        /// 返回选择的所有控件
        /// </summary>
        /// <returns>Client All</returns>
        public List<Control> BackSelectControl()
        {
            return sc[xt].ct;
        }
        /// <summary>
        /// 返回选择的项目编号
        /// </summary>
        /// <returns></returns>
        public int ClickInt()
        {
            return xt;
        }
        /// <summary>
        /// 返回指定控件的控件列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public List<Control> ReturnPanelControl(int idx)
        {
            SCP l = sc[idx];
            return l.ct;
        }
        /// <summary>
        /// 返回控件标题
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public string ReturnPanelName(int idx)
        {
            SCP l = sc[idx];
            return l.name;
        }
        /// <summary>
        /// 返回控件在列表的列数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int FSInt(string name)
        {
            int x = 0;
            foreach (SCP l in sc)
            {
                if (l.name == name)
                    return x;
                x++;
            }
            return -1;
        }
        /// <summary>
        /// 向前移动一格
        /// </summary>
        /// <param name="name"></param>
        public void UpA(string name)
        {
            ClearSelect();
            int x = 0;
            foreach (SCP l in sc)
            {
                if (l.name == name)
                {
                    break;
                }
                x++;
            }
            if (x <= 0)
                return;
            SCP aup = sc[x - 1];
            SCP adthis = sc[x];

            Control bup = cpe[x - 1];
            Control bthis = cpe[x];

            Point cup = bup.Location;
            Point cthis = bthis.Location;

            bup.Location = cthis;
            bthis.Location = cup;
            sc[x - 1] = adthis;
            sc[x] = aup;
        }
        /// <summary>
        /// 向后移动一格
        /// </summary>
        /// <param name="name"></param>
        public void DownB(string name)
        {
            ClearSelect();
            int x = 0;
            foreach (SCP l in sc)
            {
                if (l.name == name)
                {
                    break;
                }
                x++;
            }
            if (x >= sc.Count)
                return;
            SCP aup = sc[x + 1];
            SCP adthis = sc[x];

            Control bup = cpe[x + 1];
            Control bthis = cpe[x];

            Point cup = bup.Location;
            Point cthis = bthis.Location;

            bup.Location = cthis;
            bthis.Location = cup;
            sc[x - 1] = adthis;
            sc[x] = aup;
        }

        #endregion
    }
    /// <summary>
    /// 配合在ItemList中的Title
    /// </summary>
    public class TitleItem
    {
        /// <summary>
        /// 初始分配空的Title
        /// </summary>
        public TitleItem()
        {
            SubText = new List<string>();
            SizeText = new int[] { 128 };
        }
        /// <summary>
        /// Text文本标题
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Text文本标题")]
        public string Text { get; set; }
        /// <summary>
        /// SubText文本
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[System.ComponentModel.DefaultValue()]
        [Description("SubText文本")]
        public List<string> SubText { get; set; }
        /// <summary>
        /// Text/SubText文本设置宽度(如果少于则自动补充，多余忽略)
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[System.ComponentModel.DefaultValue()]
        [Description("Text/SubText文本设置宽度(如果少于则自动补充，多余忽略)")]
        public int[] SizeText { get; set; }
    }
    /// <summary>
    /// 配合在ItemList中的SubItem
    /// </summary>
    public class SubItem
    {
        /// <summary>
        /// 初始化分配
        /// </summary>
        public SubItem()
        {
            SubObject = new List<Control>();
        }
        /// <summary>
        /// 显示在正文的图片
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("显示在正文的图片")]
        public Image Image { get; set; }
        /// <summary>
        /// Text文本标题
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Text文本标题")]
        public string Text { get; set; }
        /// <summary>
        /// SubItem项
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[System.ComponentModel.DefaultValue()]
        [Description("SubItem项")]
        public List<Control> SubObject { get; set; }
    }
    class SCP
    {
        public string name { get; set; }
        public List<Control> ct = new List<Control>();
    }
}
