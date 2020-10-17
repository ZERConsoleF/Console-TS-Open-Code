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
using System.Security.Policy;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class NewTaskBar : UserControl
    {
        public NewTaskBar()
        {
            InitializeComponent();
            //AddControl = new Control[0];
            Index = 2;
            obv = new List<object>();
        }
        #region Private
        Control ph7 = null;
        int xl = 0;
        int axl = 0;
        int asw = 0;

        int pLeft = 0;
        int pTop = 0;
        #endregion
        #region 注册插件
        /// <summary>
        /// 在点击时字体显示
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SoreConsoleProcess")]
        [System.ComponentModel.Description("在点击时字体显示")]
        public Color FortFop { get; set; }
        /// <summary>
        /// 在点击时(默认)背景显示
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SoreConsoleProcess")]
        [System.ComponentModel.Description("在点击时背景显示")]
        public Color FortBack { get; set; }
        /// <summary>
        /// 翻页跨度
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SoreConsoleProcess")]
        [System.ComponentModel.DefaultValue(2)]
        [System.ComponentModel.Description("翻页跨度")]
        public int Index { get; set; }
        /// <summary>
        /// 保存在这的数据(与TaskButton相对应，就是说当TaskButton位置改变，他也会改变(如果释放，它自动从这移除))
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SoreConsoleProcess")]
        [System.ComponentModel.Description("保存在这的数据(与TaskButton相对应，就是说当TaskButton位置改变，他也会改变(如果释放，它自动从这移除))")]
        public List<object> obv { get; set; }

        #endregion
        #region 事件注册
        /// <summary>
        /// 当点击时触发事件
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SoreConsoleEvent")]
        [System.ComponentModel.Description("当点击时触发事件")]
        public event ObjectEventArg ClickEvent;
        /// <summary>
        /// 当任务标移动时触发事件
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SoreConsoleEvent")]
        [System.ComponentModel.Description("当任务标移动时触发事件")]
        public event ObjectEventArg MoveButton;
        #endregion
        #region 用户注册使用
        /// <summary>
        /// 添加一个任务显示在控制栏上
        /// </summary>
        public void AddName(string name)
        {
            Button lc = new Button();

            int cp = 0;

            foreach(Control ct in ShowLsf.Controls)
            {
                if (ct.Text == name)
                    cp++;
            }
            if (cp == 0)
                lc.Text = name;
            else
                lc.Text = name + "(" + cp + ")";
            lc.Name = "Text." + name + ShowLsf.Controls.Count;
            lc.TabIndex = ShowLsf.Controls.Count;
            lc.AutoSize = true;
            lc.Location = new Point(xl, 0);
            xl = axl += lc.Size.Width;
            lc.FlatStyle = FlatStyle.Flat;
            lc.FlatAppearance.BorderSize = 0;
            lc.BackColor = ShowLsf.BackColor;
            lc.Click += Lc_Click;
            lc.MouseDown += Lc_MouseDown;
            lc.MouseMove += Lc_MouseMove;
            if (ShowLsf.InvokeRequired)
                ShowLsf.Invoke(new MethodInvoker(() => { ShowLsf.Controls.Add(lc); }));
            else
                ShowLsf.Controls.Add(lc);
            lc.Show();
            if (axl > ShowLsf.Width)
                ShowLes_RightButton.Enabled = true;
            obv.Add(new object());
        }
        /// <summary>
        /// 指定控件移除
        /// </summary>
        /// <param name="fs">控件</param>
        public void RemoveControl(Control fs)
        {
            int x = fs.TabIndex;
            while(x < ShowLsf.Controls.Count)
            {
                MoveRight(fs);
                x++;
            }
            int fp = fs.TabIndex;
            object p7 = obv[fp];
            obv.Remove(p7);
            ShowLsf.Controls.Remove(fs);
            fs.Dispose();
        }
        /// <summary>
        /// 指定控件名字更改(如果此<see cref="NewTaskBar"/>被其他控件使用，会影响他的输出)
        /// </summary>
        /// <param name="cp">控件</param>
        /// <param name="po">名字</param>
        public void ChangeControlName(Control lc, string name)
        {
            int cp = 0;

            foreach (Control ct in ShowLsf.Controls)
            {
                if (ct.Text == name)
                    cp++;
            }
            if (cp == 0)
                lc.Text = name;
            else
                lc.Text = name + "(" + cp + ")";
        }
        /// <summary>
        /// 获取在任务栏的Button
        /// </summary>
        /// <param name="idx">数值</param>
        public Control GetControl(int idx)
        {
            for (int x = 0; x < ShowLsf.Controls.Count; x++)
            {
                Control vp = ShowLsf.Controls[x];
                if (vp.TabIndex == idx)
                    return vp;
            }
            return null;
            /*
            SmException s = new SmException();
            s.CodeLine = "0xc0049";
            s.FailWhy = "超出字符限制";
            s.message = "计数溢出";
            s.ID = -110380;
            s.Debug = "<e>p";
            throw s.RunSmProEx();
            */
        }
        /// <summary>
        /// 获取任务Button总值
        /// </summary>
        /// <returns></returns>
        public Control[] GetTaskBarControl()
        {
            List<Control> ty = new List<Control>();
            foreach (Control fg in ShowLsf.Controls)
                ty.Add(fg);
            return ty.ToArray();
        }
        /// <summary>
        /// 获取他在任务栏中位置
        /// </summary>
        /// <param name="ep"></param>
        /// <returns></returns>
        public int GetIndexControl(Control ep)
        {
            return ep.TabIndex;
        }
        /// <summary>
        /// 重置按钮位置排序
        /// </summary>
        public void ResetButtonLocation()
        {
            int xxd = 0;
            foreach (Control c in ShowLsf.Controls)
            {
                c.Location = new Point(xxd, c.Location.Y);
                xxd += c.Width;
            }
        }

        /// <summary>
        /// 这个控件向左移动
        /// </summary>
        /// <param name="ec">控件</param>
        public bool MoveLeft(Control ec)
        {
            if (ec.TabIndex == 0)
                return false;
            int xc = ec.TabIndex;
            Control a1 = ShowLsf.Controls[xc - 1];
            Control a2 = ec;
            Point p1 = a1.Location;
            Point p2 = a2.Location;
            object o1 = obv[xc - 1];
            object o2 = obv[xc];
            a2.Location = p1;
            a1.Location = new Point(a2.Location.X + a2.Width, 0);
            a1.TabIndex++;
            a2.TabIndex--;
            obv[xc - 1] = o2;
            obv[xc] = o1;
            return true;
        }
        /// <summary>
        /// 这个控件向右移动
        /// </summary>
        /// <param name="ec">控件</param>
        public bool MoveRight(Control ec)
        {
            if (ec.TabIndex >= ShowLsf.Controls.Count)
                return false;
            if (ShowLsf.Controls.Count <= 1)
                return false;
            int xc = ec.TabIndex;
            if (xc < 1)
                return false;
            Control a2 = ShowLsf.Controls[xc - 1];
            Control a1 = ec;
            object o2 = obv[xc - 1];
            object o1 = obv[xc];
            Point p1 = a1.Location;
            Point p2 = a2.Location;
            a2.Location = p1;
            a1.Location = new Point(a2.Location.X + a2.Width, 0);
            a1.TabIndex++;
            a2.TabIndex--;
            obv[xc - 1] = o2;
            obv[xc] = o1;
            return true;
        }

        /// <summary>
        /// 翻页(左负右正)
        /// </summary>
        public bool CauseLeft(int idx)
        {
            int xr = axl - ShowLsf.Width;
            if (xr <= 0)
                return false;
            if (asw >= xr && idx > 0)
                return false;
            if (asw <= 0 && idx < 0)
                return false;

            if (idx > 0 && asw + idx > xr)
                idx = xr - asw;
            if (idx < 0 && asw + idx < xr)
            {
                int p = asw + idx;
                idx = idx - p;
            }

            foreach (Control cp in ShowLsf.Controls)
            {
                cp.Location = new Point(cp.Location.X - idx, 0);
            }
            asw += idx;
            //Console.WriteLine("{0} {1} {2}",asw,xr,idx);
            return true;
        }
        /// <summary>
        /// 对他进行焦点
        /// </summary>
        /// <param name="idx"></param>
        public void FocusControl(int idx)
        {
            Control gp = GetControl(idx);
            Lc_Click(gp, new EventArgs());
        }
        /// <summary>
        /// 获取已经焦点的Button
        /// </summary>
        public Control GetFocusControl()
        {
            return ph7;
        }
        /// <summary>
        /// 对当前焦点的Button失去焦点
        /// </summary>
        public void LostFocusControl()
        {
            if (ph7 == null)
                return;
            ph7.BackColor = BackColor;
            ph7.ForeColor = ForeColor;
            ph7 = null;
        }

        private void Lc_MouseMove(object sender, MouseEventArgs e)
        {
            Control fp = sender as Control;
            if (e.Button.ToString().Equals("Left"))
            {
                //this指的是主窗口生成的对象
                //int Left = fp.Location.X + e.X - pLeft;
                //this.Top = this.Location.Y + e.Y - pTop;
                bool sd = false;
                if (e.Location.X < 5)
                {
                    sd = MoveLeft(sender as Control);
                }
                if (e.Location.X > (sender as Control).Width - 5)
                { 
                    sd = MoveRight(sender as Control);
                }
                if (sd)
                {
                    if (MoveButton != null)
                    {
                        ObjectEvent ec = new ObjectEvent();
                        ec.Save = ShowLsf.Controls;
                        MoveButton(sender, ec);
                    }
                }
            }
        }

        private void Lc_MouseDown(object sender, MouseEventArgs e)
        {
            pLeft = e.X;
            pTop = e.Y;
        }

        private void Lc_Click(object sender, EventArgs e)
        {
            Control cp = sender as Control;
            if (ph7 != null)
            {
                ph7.BackColor = BackColor;
                ph7.ForeColor = ForeColor;
            }
            cp.BackColor = FortBack;
            cp.ForeColor = FortFop;
            ph7 = cp;
            if (ClickEvent != null)
            {
                ObjectEvent obj = new ObjectEvent();
                obj.Name = cp.Name;
                obj.Save = obv[GetIndexControl(sender as Control)];
                ClickEvent(sender, obj);
            }
        }

        private void ShowLes_RightButton_Click(object sender, EventArgs e)
        {
            bool ty = CauseLeft(Index);
            ShowLes_LeftButton.Enabled = true;
            ShowLes_RightButton.Enabled = ty;
        }

        private void ShowLes_LeftButton_Click(object sender, EventArgs e)
        {
            bool ty = CauseLeft(-1 * Index);
            ShowLes_LeftButton.Enabled = ty;
            ShowLes_RightButton.Enabled = true;
        }
        #endregion

        /*
        /// <summary>
        /// 向控件填写或设置(在加载前填写，否则用方法Add,Remove等字样添加移除)
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SoreConsoleProcess")]
        [System.ComponentModel.Description("向控件填写或设置(在加载前填写，否则用方法Add,Remove等字样添加移除)")]
        public Control[] AddControl { get; set; }
        #endregion
        #region 注册用户使用方法
        /// <summary>
        /// 开始绘制或重置绘制(Like Refrces)
        /// </summary>
        public void Refuse()
        {
            ShowLsf.Controls.Clear();
            cy.Clear();

            int xy = 0;
            List<Control> fg = new List<Control>();

            foreach (Control ct in AddControl)
            {
                Button cp = new Button();
                cp.Name = "button." + ct.Name;
                cp.FlatStyle = FlatStyle.Flat;
                cp.FlatAppearance.BorderSize = 0;

                cp.Text = ct.Text;
                cp.AutoSize = true;

                #region Foreach Add Item in Control[]
                // While add
                cp.Location = new Point(xy, 0);
                cp.Size = new Size(cp.Width, ShowLsf.Height);

                if (cp.Location.X + cp.Width > ShowLsf.Width)
                {
                    cy.Add(fg.ToArray());
                    fg.Clear();
                    xy = 0;
                    cp.Location = new Point(xy, 0);
                    ShowLsf.Enabled = true;
                }

                fg.Add(cp);
                cp.Show();
                xy += cp.Width;
                #endregion
            }
        }
        */
    }
}
