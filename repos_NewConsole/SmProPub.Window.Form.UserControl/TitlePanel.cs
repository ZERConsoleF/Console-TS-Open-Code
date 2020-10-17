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
    public partial class TitlePanel : UserControl
    {
        public TitlePanel()
        {
            InitializeComponent();
            ButtonColor = SystemColors.Control;
            FreePutOffButton = 2;
            OffButtonText = 'x';
        }
        /// <summary>
        /// 产生的标题控件高度
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(29)]
        [Description("标题控件高度")]
        public int TitlePanelHeight { get { return panel1.Height; }set { panel1.Height = value; } }
        /// <summary>
        /// 标题列表的固定
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue(29)]
        [Description("标题列表的固定")]
        public DockStyle TitlePanelDock { get { return panel1.Dock; }set { 
                if (value == DockStyle.None || value == DockStyle.Fill) 
                    throw new SmException("已取消Fill,None绑定"); 
                panel1.Dock = value; }
        }
        /// <summary>
        /// 标题按钮默认的颜色
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        //[DefaultValue(29)]
        [Description("标题按钮默认的颜色")]
        public Color ButtonColor { get; set; }
        /// <summary>
        /// 将以几等分分配字符
        /// </summary>
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(2)]
        [Description("将以几等分分配字符")]
        public int FreePutOffButton { get; set; }
        /// <summary>
        /// 关闭按钮字符显示
        /// </summary>
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue('x')]
        [Description("关闭按钮字符显示")]
        public char OffButtonText { get; set; }
        /// <summary>
        /// 关闭时是否销毁用户控件
        /// </summary>
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("关闭时是否销毁用户控件")]
        public bool OffButtonDisControl { get; set; }
        List<ButtonDC> d = new List<ButtonDC>();
        ButtonDC ghl = null;
        /// <summary>
        /// 添加控件列表
        /// </summary>
        /// <param name="c">需要添加的控件</param>
        public void AddControl(Control c)
        {
            foreach (ButtonDC df in d)
            {
                if (df.con == c)
                {
                    if (ghl != null)
                    {
                        if (!ghl.IsDisposed)
                        {
                            ghl.con.Hide();
                        }
                    }
                    return;
                }
            }

            ButtonDC dg = new ButtonDC();
            dg.FlatStyle = FlatStyle.Flat;
            dg.FlatAppearance.BorderSize = 0;

            dg.AutoSize = true;
            panel1.Controls.Add(dg);
            if (panel1.Dock == DockStyle.Top || panel1.Dock == DockStyle.Bottom)
                dg.Dock = DockStyle.Left;
            if (panel1.Dock == DockStyle.Left || panel1.Dock == DockStyle.Right)
                dg.Dock = DockStyle.Top;
            panel1.DockChanged += (sender, e) => {
                if (panel1.Dock == DockStyle.Top || panel1.Dock == DockStyle.Bottom)
                    dg.Dock = DockStyle.Left;
                if (panel1.Dock == DockStyle.Left || panel1.Dock == DockStyle.Right)
                    dg.Dock = DockStyle.Top;
            };

            Button b = new Button();
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Size = new Size(dg.Height, dg.Height);
            dg.SizeChanged += (sender, e) => { b.Size = new Size(dg.Height, dg.Height); };
            b.MouseHover += (sender, e) => { b.Text = OffButtonText.ToString(); };
            b.MouseLeave += (sender, e) => { b.Text = " "; };
            b.Click += (sender, e) => { RemoveControl(c, OffButtonDisControl); };
            b.Dock = DockStyle.Right;
            dg.Controls.Add(b);
            b.Show();

            string addenpty = "";

            for (int x = 0; x <=  b.Width / FreePutOffButton; x++)
                addenpty += " ";

            dg.con = c;
            c.TextChanged += (sneder, e) => { dg.Text = c.Text + addenpty; };
            dg.Click += (sender, e) => {
                if (ghl != null)
                {
                    if (!ghl.IsDisposed)
                        ghl.con.Hide();
                }
                c.Show();
                if (ghl != null)
                {
                    ghl.BackColor = ButtonColor;
                }
                ghl = dg;
                ghl.BackColor = c.BackColor;
                ClickEvent?.Invoke(this, null);
            };
            c.BackColorChanged += (sender, e) => { dg.BackColor = c.BackColor; };
            dg.BackColor = c.BackColor;
            c.Disposed += (sender, e) => { RemoveButtonDC(dg); };
            dg.Text = c.Text + addenpty;
            dg.BackColor = ButtonColor;
            dg.Show();
            ghl = dg;

            panel2.Controls.Add(c);
            c.Show();
            dg.idx = d.Count;
            d.Add(dg);
        }
        /// <summary>
        /// 需要移除列表的控件
        /// </summary>
        /// <param name="c">移除的控件</param>
        /// <param name="discontrol">是否销毁控件</param>
        public void RemoveControl(Control c, bool discontrol)
        {
            int df = -1;
            ButtonDC dfgo = null;
            foreach (ButtonDC dfb in d)
            {
                if (dfb.con == c)
                {
                    df = dfb.idx;
                    dfgo = dfb;
                }
            }
            if (df < 0)
                throw new SmException("这个控件是无法找到的，控件确认失败", "解决控件没有", -40047, "mov ax,01,jnic,jmp<1", "执行逃出");
            CloseControlEvent e = new CloseControlEvent();
            e.CloseControl = dfgo.con;
            e.Idex = dfgo.idx;
            RemoveOrCloseEvent?.Invoke(this, e);
            for (int fg = df + 1; fg < d.Count; fg++)
            {
                d[fg].idx--;
            }
            d.Remove(dfgo);
            panel2.Controls.Remove(dfgo.con);
            if (discontrol)
                dfgo.con.Dispose();
            dfgo.Dispose();

            if (d.Count > 0)
            {
                d[d.Count - 1].con.Show();
            }
        }
        /// <summary>
        /// 控件标题向左移动
        /// </summary>
        /// <param name="c">移动控件</param>
        public void LeftMove(Control c)
        {
            ButtonDC b = SearchButtoDC(c);
            if (b.idx <= 0)
                return;
            ButtonDC a1 = d[b.idx--];
            d[b.idx--] = b;
            d[b.idx] = a1;
            b.idx--;
            a1.idx++;
            RefPanelTitleT();
        }
        /// <summary>
        /// 控件标题向右移动
        /// </summary>
        /// <param name="c">移动控件</param>
        public void RightMove(Control c)
        {
            ButtonDC b = SearchButtoDC(c);
            if (b.idx == d.Count - 1)
                return;
            ButtonDC a1 = d[b.idx++];
            d[b.idx++] = b;
            d[b.idx] = a1;
            b.idx++;
            a1.idx--;
            RefPanelTitleT();
        }
        /// <summary>
        /// 获取焦点的窗体
        /// </summary>
        /// <returns></returns>
        public Control GetFocusForm()
        {
            return ghl.con;
        }
        /// <summary>
        /// 获取显示控件容器
        /// </summary>
        /// <returns></returns>
        public Panel GetPanel()
        {
            return panel2;
        }
        /// <summary>
        /// 获取所有控件列表
        /// </summary>
        /// <returns></returns>
        public Control[] GetList()
        {
            List<Control> c = new List<Control>();
            foreach (ButtonDC df in d)
            {
                c.Add(df.con);
            }
            return c.ToArray();
        }

        /// <summary>
        /// 当点击标题时产生事件(无转化类型)
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("当点击标题时产生事件")]
        public event ObjectEventArg ClickEvent;
        /// <summary>
        /// 当控件被移除或标签被关闭(释放除外)(事件为<see cref="CloseControlEvent"/>)
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("当控件被移除或标签被关闭(释放除外)")]
        public event ObjectEventArg RemoveOrCloseEvent;

        protected void RefPanelTitleT()
        {
            foreach (ButtonDC df in d)
            {
                panel1.Controls.Add(df);
            }
        }
        protected void RemoveButtonDC(ButtonDC dfgo)
        {
            int df = dfgo.idx;
            for (int fg = df + 1; fg < d.Count; fg++)
            {
                d[fg].idx--;
            }
            d.Remove(dfgo);
            dfgo.Dispose();
        }
        protected ButtonDC SearchButtoDC(Control c)
        {
            foreach (ButtonDC fg in d)
            {
                if (fg.con == c)
                {
                    return fg;
                }
            }
            throw new SmException("搜索失败，没有此控件");
        }
        protected class ButtonDC : Button
        {
            public int idx;
            public Control con;
        }
    }
    public class CloseControlEvent : ObjectEvent
    {
        /// <summary>
        /// 被迫踢出的控件
        /// </summary>
        public Control CloseControl { get; set; }
        /// <summary>
        /// 标题位置引索
        /// </summary>
        public int Idex;
    }
}
