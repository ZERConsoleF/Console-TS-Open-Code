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
using System.SmProPub.ExClass;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class ListVerCs : UserControl
    {
        public ListVerCs()
        {
            InitializeComponent();
            FsWriteLQ = 10;
            BorderPanel = BorderStyle.None;
            ObjectClass<ListVerCs> v = new ObjectClass<ListVerCs>();
            v.IDX = v.SaveInMemory(this);
            Disposed += ListVerCs_Disposed;
        }

        private void ListVerCs_Disposed(object sender, EventArgs e)
        {
            ObjectClass<ListVerCs>.DisopseInMemory(this);
        }
        #region
        /// <summary>
        /// 边界编辑
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(10)]
        [Description("边界编辑")]
        public int FsWriteLQ { get; set; }
        /// <summary>
        /// 边框式样
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue(2)]
        [Description("边框式样")]
        public BorderStyle BorderPanel { get; set; }
        /// <summary>
        /// 预点击颜色
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue(2)]
        [Description("预点击颜色")]
        public Color ReadlyCheckColor { get; set; }
        /// <summary>
        /// 点击颜色
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue(2)]
        [Description("点击颜色")]
        public Color CheckColor { get; set; }
        /// <summary>
        /// 是否为多点击项
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("是否为多点击项")]
        public bool CheckMore { get; set; }
        /// <summary>
        /// 在项目点击时发生
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("在项目点击时发生")]
        public event ObjectEventArg ClickItem;
        /// <summary>
        /// 在项目被展开时发生
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("在项目被展开时发生")]
        public event ObjectEventArg DevelopItem;
        /// <summary>
        /// 正在释放时发生
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("正在释放时发生")]
        public new event ObjectEventArg Disposing;
        /// <summary>
        /// 项目创建时发生(请使用GetItemCreating()方法获取正在创建项)
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("项目创建时发生")]
        public event ObjectEventArg CreatIteming;
        #endregion
        #region
        int lsadd = 0;
        ItemListCs chlod = null;
        ItemListCs devechlod = null;
        PanelMemov vx = null;
        ItemListCs vckk = null;
        ItemListCs creatit = null;
        List<ItemListCs> csSave = new List<ItemListCs>();
        List<ItemListCs> CheckMoredl = new List<ItemListCs>();
        #endregion
        #region
            /*
        /// <summary>
        /// 新建一个项
        /// </summary>
        public void AddItem(ItemListCs co,Control ch)
        {
            Panel p = new Panel();
            p.AutoSize = true;
            //lg.Add(co);
            p.Dock = DockStyle.Top;
            p.Name = co.Name + ".it1";
            Panel p1 = new Panel();
            p1.Name = co.Name + ".it2";
            p1.AutoSize = true;
            p.Controls.Add(p1);
            p1.Show();
            if (co.Con == null)
            {
                ButtonMemov v = new ButtonMemov();
                v.Name = co.Name + ".vt1";
                v.Location = new Point(co.FsWritePS + FsWriteLQ, 0);
                v.AutoSize = true;
                v.UpCheck = "-";

                Label l = new Label();
                l.Name = co.Name + ".lt1";
                l.Text = co.Text;
                l.AutoSize = true;

                l.Location = new Point(co.FsWritePS + FsWriteLQ, 0);
                p1.Controls.Add(l);
                l.Show();

                co.CW = p;
            }
            else if (co.Con != null)
            {
                int d = 0;
                foreach (Control cd in co.Con.ToArray())
                {
                    cd.Name = co.Name + ".ct" + d;
                    cd.Location = new Point(cd.Location.X + FsWriteLQ, cd.Location.Y);
                    p1.Controls.Add(cd);
                    cd.Show();
                    d++;
                }
            }
            p.BorderStyle = BorderStyle.Fixed3D;
            p.Location = new Point(p.Location.X, ch.Location.Y);
            p.Dock = DockStyle.None;
            ch.Controls.Add(p);
            Console.WriteLine(ch.ToString());
            p.Show();
        }
        /// <summary>
        /// 从特定位置添加(如果从主项添加，则cr 为null)
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="cr"></param>
        public void AddItemI(ItemListCs cl, ItemListCs cr)
        {
            if (cr == null)
            {
                AddItem(cl, this);
                
                foreach (ItemListCs cg in cl.SubItems.ToArray())
                    AddItemI(cg, cl);
                return;
            }
            AddItem(cl, cr.CW);
            foreach (ItemListCs cg in cl.SubItems)
                AddItemI(cg, cl);
        }
        */
        /// <summary>
        /// 添加位置
        /// </summary>
        /// <param name="cf">添加项</param>
        /// <param name="cg">起始位置，如果从第一个添加，请声明null</param>
        public void AddItem(ItemListCs cf,Control cg)
        {
            int ftmp = lsadd;
            lsadd = 0;
            bool sub = false;
            if (cg == null)
            {
                cg = this;
            }
            else
                sub = true;
            
            PanelMemov p = new PanelMemov();
            p.Name = cf.Name + ".p1";
            p.BorderStyle = BorderPanel;
            p.Height = cf.Hight;
            p.AutoSize = true;
            p.Dock = DockStyle.Top;
            p.Chieck = cf;
            p.DownCheck = cg.BackColor;
            p.UpCheck = CheckColor;
            p.MouseHover += P_MouseHover;
            p.MouseLeave += P_MouseLeave;
            p.Click += P_Click;
            p.Show();
            p.ContextMenuStrip = cf.MenuStrip;

            int hg = cf.FsWritePS;

            if (vckk != null)
                cf.FsWritePS = vckk.FsWritePS + cf.FsWritePS + FsWriteLQ;
            if (cf.Con == null)
            {
                LabelMemov l = new LabelMemov();
                l.Name = cf.Name + ".l1";
                l.Text = cf.Text;
                l.AutoSize = true;
                p.Controls.Add(l);
                l.ContextMenuStrip = cf.MenuStrip;
                l.Show();
                if (cf.Image != null)
                {
                    //l.ImageAlign = ContentAlignment.MiddleLeft;
                    //l.Image = cf.Image;
                    PictureBox b = new PictureBox();
                    b.Name = cf.Name + ".gfzs";
                    b.SizeMode = PictureBoxSizeMode.StretchImage;
                    b.Image = cf.Image;
                    p.Controls.Add(b);
                    b.Show();

                    b.Size = new Size(l.Height, l.Height);
                    b.Location = new Point(cf.FsWritePS, 0);
                    cf.FsWritePS += l.Height + 2;
                    //hg += p.Height + 2;
                }
                l.Location = new Point(cf.FsWritePS, l.Location.Y);
                l.Chieck = cf;
                l.Pan = p;
                l.DownCheck = cg.BackColor;
                l.UpCheck = CheckColor;
                l.MouseHover += L_MouseHover;
                l.MouseLeave += L_MouseLeave;
                l.Click += L_Click;
                cf.Con = new List<Control>(new Control[] { l });
                p.Label = l;
            }
            else
            {
                foreach (Control l in cf.Con.ToArray())
                {
                    l.Name = cf.Name + "." + l.Name;
                    //l.Text = cf.Text;
                    l.Location = new Point(cf.FsWritePS, l.Location.Y);
                    l.AutoSize = true;
                    p.Controls.Add(l);
                    l.Show();
                }
            }
            if (CheckMore)
            {
                CheckBoxMemov l = new CheckBoxMemov();
                l.Name = cf.Name + ".c1";
                l.Dock = DockStyle.Right;
                l.AutoSize = true;
                l.Chieck = cf;
                l.Pan = p;
                p.Controls.Add(l);
                l.Show();
                l.DownCheck = cg.BackColor;
                l.UpCheck = CheckColor;
                p.CheckBox = l;
                l.MouseHover += L_MouseHover1;
                l.MouseLeave += L_MouseLeave1;
                l.Click += L_Click1;
            }
            ButtonMemov v = new ButtonMemov();
            v.Name = cf.Name + ".spac5";
            v.UpCheck = "-";
            v.DownCheck = "+";
            v.Text = v.DownCheck;
            v.Click += V_Click;
            v.AutoSize = true;
            v.Size = new Size(10, p.Height);
            v.Dock = DockStyle.Right;
            if (p.Label != null)
                v.Font = new Font("", p.Label.Height / 2);
            else
                v.Font = new Font("", p.Height / 2);
            v.Chieck = cf;
            p.Controls.Add(v);
            v.Show();

            Panel pl = new Panel();
            pl.Name = cf.Name + ".p2";
            pl.BorderStyle = BorderPanel;
            pl.Height = cf.Hight;
            pl.AutoSize = true;
            pl.Dock = DockStyle.Top;
            pl.Show();
            pl.Controls.Add(p);
            Panel pll = new Panel();
            pll.Name = cf.Name + ".p3";
            pll.BorderStyle = BorderStyle;
            pll.AutoSize = true;
            pll.Dock = DockStyle.Top;
            pll.Show();
            pl.Controls.Add(pll);

            cg.Controls.Add(pl);
            if (!sub)
                csSave.Add(cf);
            cf.CW = pl;
            cf.CD = p;
            cf.CS = pll;
            cf.CB = v;

            cf.FsWritePS = hg;
            vckk = cf;

            pl.AutoSize = true;
            Size pi = pl.Size;
            pl.AutoSize = false;
            pi.Height = p.Height;
            pl.Size = pi;
            foreach (ItemListCs cgi in cf.SubItems.ToArray())
            {
                vckk = cf;
                AddItem(cgi, pll);
                lsadd++;
            }

            //cf.FsWritePS = vckk.FsWritePS + cf.FsWritePS + FsWriteLQ;

            //p.BorderStyle = BorderStyle.FixedSingle;
            //pl.BorderStyle = BorderStyle.FixedSingle;
            LeastControls(pl);
            LeastControls(cg);
            lsadd = ftmp;
            cf.Idexs = lsadd;
            lsadd++;
            if (CreatIteming != null)
            {
                creatit = cf;
                CreatIteming(this, new ObjectEvent());
                creatit = null;
            }
            vckk = null;
        }

        /// <summary>
        /// 在这个位置下添加子项并写入
        /// </summary>
        /// <param name="idx">位置</param>
        /// <param name="cp">添加项</param>
        public void AddSubItem(int[] idx,ItemListCs cp)
        {
            ItemListCs hn = GetIntdItem(idx);
            vckk = hn;
            hn.SubItems.Add(cp);
            AddItem(cp, hn.CS);
            if (!(hn.CB as ButtonMemov).CheckOne)
            {
                Panel p = hn.CD as Panel;
                Panel pl = hn.CW as Panel;
                Size pi = pl.Size;
                pl.AutoSize = false;
                pi.Height = p.Height;
                pl.Size = pi;
            }
            else
            {
                Panel pl = hn.CW as Panel;
                pl.AutoSize = true;
            }
        }
        /// <summary>
        /// 在这个位置移除项并指定是否移除他的子项
        /// </summary>
        /// <param name="idx">位置</param>
        /// <param name="ftRemoveItem">是否删除位置</param>
        public void RemoveItem(int[] idx,bool ftRemoveItem)
        {
            if (idx.Length < 1)
                return;
            ItemListCs vh = GetIntdItem(idx);
            //Console.WriteLine(vh.Name);
            List<int> dix2 = new List<int>();
            for (int x = 0; x < idx.Length - 1; x++)
                dix2.Add(idx[x]);
            Control c2 = vh.CW;
            ItemListCs i1 = null;
            if (dix2.Count > 0)
            {
                i1 = GetIntdItem(dix2.ToArray());
            }
            c2.Hide();
            c2.Dispose();
            //vh.CB.Dispose();
            //vh.CD.Dispose();
            //vh.CS.Dispose();
            if (ftRemoveItem)
            {
                if (i1 == null)
                {
                    csSave.Remove(vh);
                }
                else
                {
                    i1.SubItems.Remove(vh);
                }
            }
        }
        /// <summary>
        /// 在这个位置更改项目(更改会移除并重新添加)
        /// </summary>
        /// <param name="idx">位置</param>
        /// <param name="vh">更改项</param>
        public void ChangeItem(int[] idx,ItemListCs vh)
        {
            RemoveItem(idx, true);
            List<int> dix2 = new List<int>();
            for (int x = 0; x < idx.Length - 1; x++)
                dix2.Add(idx[x]);
            ItemListCs i1 = null;
            if (dix2.Count > 0)
            {
                i1 = GetIntdItem(dix2.ToArray());
            }
            if (i1 == null)
            {
                AddItem(vh, null);
            }
            else
            {
                AddItem(vh, i1.CW);
            }
        }
        /// <summary>
        /// 在这个位置仅更改他的文本
        /// </summary>
        /// <param name="change">文本更改</param>
        /// /<param name="idx">位置</param>
        public void ChangeTextItem(int[] idx,string change)
        {
            ItemListCs v = GetIntdItem(idx);
            (v.CD as PanelMemov).Label.Text = change;
            v.Text = change;
        }
        /// <summary>
        /// 寻找项目在保存列表中(确保Name每各不重复)
        /// </summary>
        /// <param name="vh">寻找项目</param>
        /// <param name="idx">起始位置，如果全部搜索，请声明null</param>
        /// <returns></returns>
        public int[] FindThisItem(ItemListCs vh,int[] idx)
        {
            List<int> indf = new List<int>();

            if (idx == null)
            {
                int css = 0;
                foreach (ItemListCs vhk in csSave.ToArray())
                {
                    if (vhk == vh)
                    {
                        indf.Add(css);
                        break;
                    }
                    int[] cdf = FindThisItem(vh, new int[] { css });
                    if (cdf.Length > 0)
                    {
                        indf.Add(css);
                        foreach (int FK in cdf)
                        {
                            indf.Add(FK);
                        }
                        break;
                    }
                    css++;
                }
            }
            else
            {
                int css = 0;
                foreach (ItemListCs vhk in GetIntdItem(idx).SubItems.ToArray())
                {
                    if (vhk == vh)
                    {
                        indf.Add(css);
                        break;
                    }
                    List<int> fgxcd = new List<int>(idx);
                    fgxcd.Add(css);
                    int[] cdf = FindThisItem(vh, fgxcd.ToArray());
                    if (cdf.Length > 0)
                    {
                        indf.Add(css);
                        foreach (int FK in cdf)
                        {
                            indf.Add(FK);
                        }
                        break;
                    }
                    css++;
                }
            }

            return indf.ToArray();
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
        /// 获取点击的项
        /// </summary>
        /// <returns></returns>
        public ItemListCs GetCheckItem()
        {
            return chlod;
        }
        /// <summary>
        /// 获取最后一次展开项
        /// </summary>
        /// <returns></returns>
        public ItemListCs GetDevelopItem()
        {
            return devechlod;
        }
        /// <summary>
        /// 获取多项运动Check
        /// </summary>
        /// <returns></returns>
        public ItemListCs[] GetCheckItems()
        {
            return CheckMoredl.ToArray();
        }
        /// <summary>
        /// 通过项目数字引索项目
        /// </summary>
        /// <param name="idx"></param>
        public ItemListCs GetIntdItem(int[] idx)
        {
            List<ItemListCs> gu = csSave;
            ItemListCs g = null;
            foreach (int fs in idx)
            {
                g = gu[fs];
                gu = g.SubItems;
            }
            return g;
        }
        /// <summary>
        /// 通过项目数字引索项目并焦距
        /// </summary>
        /// <param name="idex"></param>
        public void Focus(int[] idex)
        {
            ItemListCs ck = GetIntdItem(idex);
            (ck.CD as PanelMemov).CheckOne = true;
        }
        /// <summary>
        /// 通过项目数字引索项目并失去焦距
        /// </summary>
        /// <param name="idex"></param>
        public void LoseFocus(int[] idex)
        {
            ItemListCs ck = GetIntdItem(idex);
            (ck.CD as PanelMemov).CheckOne = false;
        }
        /// <summary>
        /// 通过项目数字引索项目并焦距展开
        /// </summary>
        /// <param name="idx">位置</param>
        public void Develop(int[] idx)
        {
            ItemListCs f = GetIntdItem(idx);
            (f.CB as ButtonMemov).CheckOne = true;
            /*
            Panel j = f.CW as Panel;
            j.AutoSize = true;
            */
        }
        /// <summary>
        /// 通过项目数字引索项目并失去焦距展开
        /// </summary>
        /// <param name="idx">位置</param>
        public void LoseDevelop(int[] idx)
        {
            ItemListCs f = GetIntdItem(idx);
            (f.CB as ButtonMemov).CheckOne = false;
            /*
            Panel pl = f.CW as Panel;
            Panel p = f.CD as Panel;
            Size pi = pl.Size;
            pl.AutoSize = false;
            pi.Height = p.Height;
            pl.Size = pi;
            */
        }
        /// <summary>
        /// 通过项目数字引索项目并获取焦距
        /// </summary>
        /// <param name="idex"></param>
        public bool GetFocus(int[] idex)
        {
            ItemListCs ck = GetIntdItem(idex);
            return (ck.CD as PanelMemov).CheckOne;
        }
        /// <summary>
        /// 获取正在创建的项
        /// </summary>
        /// <returns></returns>
        public ItemListCs GetItemCreating()
        {
            return creatit;
        }

        /// <summary>
        /// 释放系统所有资源
        /// </summary>
        public new void Dispose()
        {
            if (Disposing != null)
                Disposing(this, new ObjectEvent());
            base.Dispose();
        }
        #endregion
        private void V_Click(object sender, EventArgs e)
        {
            ButtonMemov i = sender as ButtonMemov;
            if (i.CheckOne)
            {
                Panel j = i.Chieck.CW as Panel;
                devechlod = i.Chieck;
                j.AutoSize = true;
                if (DevelopItem != null)
                    DevelopItem(this, new ObjectEvent());
                /*
                int x = 0;
                foreach (Control vb in j.Controls)
                {
                    x += vb.Height;
                }
                Size pi = j.Size;
                pi.Height = x;
                j.Size = pi;
                j.AutoSize = true;
                */
            }
            else
            {
                Panel pl = i.Chieck.CW as Panel;
                Panel p = i.Chieck.CD as Panel;
                Size pi = pl.Size;
                pl.AutoSize = false;
                pi.Height = p.Height;
                pl.Size = pi;
            }
        }
        private void L_MouseHover(object sender, EventArgs e)
        {
            LabelMemov g = sender as LabelMemov;
            if (!g.CheckOne)
            {
                g.BackColor = ReadlyCheckColor;
                g.Pan.BackColor = ReadlyCheckColor;
            }
        }
        private void L_MouseLeave(object sender, EventArgs e)
        {
            LabelMemov g = sender as LabelMemov;
            if (g.CheckOne)
            {
                return;
            }
            g.BackColor = BackColor;
            g.Pan.BackColor = BackColor;
        }
        private void L_Click(object sender, EventArgs e)
        {
            LabelMemov g = sender as LabelMemov;
            if (!g.CheckOne)
            {
                chlod = null;
                return;
            }
            chlod = g.Chieck;
        }
        private void P_MouseHover(object sender, EventArgs e)
        {
            PanelMemov g = sender as PanelMemov;
            if (!g.CheckOne)
            {
                g.BackColor = ReadlyCheckColor;
                if (g.Label != null)
                {
                    g.Label.BackColor = ReadlyCheckColor;
                }
            }
        }
        private void P_MouseLeave(object sender, EventArgs e)
        {
            PanelMemov g = sender as PanelMemov;
            if (g.CheckOne)
            {
                return;
            }
            g.BackColor = BackColor;
            if (g.Label != null)
            {
                g.Label.BackColor = BackColor;
            }
        }
        private void P_Click(object sender, EventArgs e)
        {
            PanelMemov g = sender as PanelMemov;
            /*
            if (vx == g)
            {
                //vx = null;
                goto End;
            }
            */
            if (!g.CheckOne)
            {
                chlod = null;
                goto End;
            }
            if (!CheckMore)
            {
                if (vx != null)
                {
                    if (vx != g)
                        vx.CheckOne = false;
                }
            }
            vx = g;
            chlod = g.Chieck;
        End:
            if (ClickItem != null)
                ClickItem(this, new ObjectEvent());
        }
        private void L_MouseHover1(object sender, EventArgs e)
        {
            CheckBoxMemov g = sender as CheckBoxMemov;
            if (!g.CheckOne)
            {
                g.BackColor = ReadlyCheckColor;
                g.Pan.BackColor = ReadlyCheckColor;
            }
        }
        private void L_MouseLeave1(object sender, EventArgs e)
        {
            CheckBoxMemov g = sender as CheckBoxMemov;
            if (g.CheckOne)
            {
                return;
            }
            g.BackColor = BackColor;
            g.Pan.BackColor = BackColor;
        }
        private void L_Click1(object sender, EventArgs e)
        {
            CheckBoxMemov g = sender as CheckBoxMemov;
            if (!g.CheckOne)
            {
                CheckMoredl.Remove(g.Chieck);
                return;
            }
            CheckMoredl.Add(g.Chieck);
        }

    }
    /// <summary>
    /// 用于新建项类
    /// </summary>
    public class ItemListCs
    {
        /// <summary>
        /// 构建新的参数
        /// </summary>
        public ItemListCs()
        {
            SubItems = new List<ItemListCs>();
            EtcStrings = new List<string>();
        }
        /// <summary>
        /// 标记点击时序号(在同一目录下，不可重复)
        /// </summary>
        public int Idexs { get; set; }
        /// <summary>
        /// 这个项的Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 初始化的统一标题
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文本(如果Con没有数)
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 图像(如果Con没有数)
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// 当前控件高度
        /// </summary>
        public int Hight { get; set; }
        /// <summary>
        /// 是否选择
        /// </summary>
        public bool Check { get; set; }
        /// <summary>
        /// 初始或设置边界
        /// </summary>
        public int FsWritePS { get; set; }
        /// <summary>
        /// 声明所在控件
        /// </summary>
        public Control CW { get; set; }
        /// <summary>
        /// 声明标题所在容器
        /// </summary>
        public Control CD { get; set; }
        /// <summary>
        /// 声明所在的子容器
        /// </summary>
        public Control CS { get; set; }
        /// <summary>
        /// 声明操控展开控件
        /// </summary>
        public Control CB { get; set; }
        /// <summary>
        /// 控件右键菜单
        /// </summary>
        public ContextMenuStrip MenuStrip { get; set; }
        /// <summary>
        /// 设置文本内容(初始为null,设置则Text无用)
        /// </summary>
        public List<Control> Con { get; set; }
        /// <summary>
        /// 获取设置子项(初始为new)
        /// </summary>
        public List<ItemListCs> SubItems { get; set; }
        /// <summary>
        /// 这个项目其他绑定
        /// </summary>
        public string EtcString { get; set; }
        /// <summary>
        /// 这个项目更多描述
        /// </summary>
        public List<string> EtcStrings { get; set; }
    }
    public class CheckBoxMemov : CheckBox
    {
        public CheckBoxMemov()
        {
            base.Click += ButtonMemov_Click;
        }

        /// <summary>
        /// 单击时发生
        /// </summary>
        public new event System.EventHandler Click;
        public string Type { get; set; }
        public Color UpCheck { get; set; }
        public Color DownCheck { get; set; }
        public void ButtonMemov_Click(object sender, EventArgs e)
        {
            //base.Checked = !base.Checked;
            BackColor = base.Checked ? UpCheck : DownCheck;
            if (Pan != null)
            {
                Pan.BackColor = BackColor;
                Pan.OnlyChangeCheck(base.Checked);
            }
            if (Click != null)
                Click(sender, e);
        }

        public ItemListCs Chieck { get; set; }
        public bool CheckOne { get { return base.Checked; } set { base.Checked = value; ButtonMemov_Click(this, new EventArgs()); } }
        public PanelMemov Pan { get; set; }
    }
    public class PictureBoxMemov : PictureBox
    {

    }
    public class LabelMemov : Label
    {
        public LabelMemov()
        {
            base.Click += ButtonMemov_Click;
        }

        /// <summary>
        /// 单击时发生
        /// </summary>
        public new event System.EventHandler Click;
        public string Type { get; set; }
        public Color UpCheck { get; set; }
        public Color DownCheck { get; set; }
        private void ButtonMemov_Click(object sender, EventArgs e)
        {
            Check = !Check;
            BackColor = Check ? UpCheck : DownCheck;
            if (Pan != null)
            {
                Pan.BackColor = BackColor;
                Pan.OnlyChangeCheck(Check);
            }
            if (Click != null)
                Click(sender, e);
        }

        public ItemListCs Chieck { get; set; }
        private bool Check;
        public bool CheckOne { get { return Check; } set { Check = !value; ButtonMemov_Click(this, new EventArgs()); } }
        public PanelMemov Pan { get; set; }
    }
    public class PanelMemov : Panel
    {
        public PanelMemov()
        {
            base.Click += ButtonMemov_Click;
        }

        /// <summary>
        /// 单击时发生
        /// </summary>
        public new event System.EventHandler Click;
        public string Type { get; set; }
        public Color UpCheck { get; set; }
        public Color DownCheck { get; set; }
        private void ButtonMemov_Click(object sender, EventArgs e)
        {
            Check = !Check;
            BackColor = Check ? UpCheck : DownCheck;
            if (CheckBox != null)
            {
                CheckBox.CheckOne = Check;
            }
            if (Click != null)
                Click(sender, e);
            if (Label != null)
            {
                Label.CheckOne = Check;
            }
        }

        public void OnlyChangeCheck(bool ft)
        {
            Check = ft;
            Click(this,new EventArgs());
        }
        public ItemListCs Chieck { get; set; }
        private bool Check;
        public bool CheckOne { get { return Check; } set { Check = !value; ButtonMemov_Click(this, new EventArgs()); } }
        public CheckBoxMemov CheckBox { get; set; }
        public LabelMemov Label { get; set; }
    }
    public class ButtonMemov : Button
    {
        public ButtonMemov()
        {
            base.Click += ButtonMemov_Click;
            base.FlatStyle = FlatStyle.Flat;
            base.FlatAppearance.BorderSize = 0;
        }

        /// <summary>
        /// 单击时发生
        /// </summary>
        public new event System.EventHandler Click;
        public string Type { get; set; }
        public string UpCheck { get; set; }
        public string DownCheck { get; set; }
        private void ButtonMemov_Click(object sender, EventArgs e)
        {
            Check = !Check;
            Text = Check ? UpCheck : DownCheck;
            if (Click != null)
                Click(sender, e);
        }

        public ItemListCs Chieck { get; set; }
        private bool Check;
        public bool CheckOne { get { return Check; } set { Check = !value; ButtonMemov_Click(this, new EventArgs()); } }
    }
}
