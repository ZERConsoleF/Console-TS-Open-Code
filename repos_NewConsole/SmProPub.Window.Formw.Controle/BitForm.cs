using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProPub.Window.Formw.Controle
{
    public partial class BitForm : Form
    {
        public BitForm()
        {
            InitializeComponent();
        }
        public BitForm(Form p)
        {
            InitializeComponent();
            p.SizeChanged += new EventHandler(P_SizeChanged);
            p.LocationChanged += new EventHandler(P_LocationChanged);
            p.TextChanged += new EventHandler(P_TextChanged);
            p.TopLevel = false;
            p.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            u = p;
            if (SetNe.InvokeRequired)
            {
                Thread tc = new Thread(new ThreadStart(() => { SetNe.Invoke(new MethodInvoker(delegate { SetNe.Controls.Add(p); })); }));
                tc.IsBackground = true;
                tc.Start();
            }
            else
                SetNe.Controls.Add(p);
            p.Show();
            TitleName.Text = p.Text;
            this.SizeChanged += new System.EventHandler(this.BitForm_SizeChanged);
            //Size p9 = this.Size;
            //u.Size = new Size(p9.Width - 5, p9.Height + Title.Height - 5);
            p.Size = this.SetNe.Size;
            this.Text = p.Text;
        }

        public new Icon Icon { 
            get 
            {
                if (u != null)
                    return u.Icon;
                else
                    return base.Icon;
            } set { if (u != null) u.Icon = value;
                base.Icon = value; } }
        public new string Text { get { if (u != null) return u.Text; else return base.Text; } set { if (u != null) u.Text = value;
                base.Text = value; } }

        /// <summary>
        /// 如果需要用Invoke添加，则调用此方法(即使不需要)
        /// </summary>
        /// <param name="ty"></param>
        public void ShowInvokeToForm(Form ty)
        {
            if (ty.InvokeRequired)
            {
                Thread tc = new Thread(new ThreadStart(() => { ty.Invoke(new MethodInvoker(delegate { ty.Controls.Add(this); })); }));
                tc.IsBackground = true;
                tc.Start();
            }
            else
                ty.Controls.Add(this);
        }

        private void P_LocationChanged(object sender, EventArgs e)
        {
            /*
            Form t = (Form)sender;
            this.Location = t.Location;
            t.Location = new Point(this.Location.X,this.Location.Y + this.Title.Height);
            */
            Form t = (Form)sender;
            this.Location = t.Location;
            t.Location = new Point(0, 0);
        }

        private void P_SizeChanged(object sender, EventArgs e)
        {
            /*
            Point y = this.Location;
            Form t = (Form)sender;
            Size p = t.Size;
            this.Size = new Size(p.Width - 5, p.Height + Title.Height - 5);
            this.Location = y;
            */
            Form t = (Form)sender;
            SetNe.Size = t.Size;
        }
        private void P_TextChanged(object sender, EventArgs e)
        {
            Form t = (Form)sender;
            TitleName.Text = t.Text;
            this.Text = t.Text;
        }

        Form u;
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        bool MaxWindow = false;
        System.Drawing.Size sizepo;
        System.Drawing.Point loctsi;
        public void MaxsWindow()
        {
            int h = Screen.PrimaryScreen.Bounds.Height;
            int w = Screen.PrimaryScreen.Bounds.Width;
            loctsi = Location;
            sizepo = Size;
            this.Location = new System.Drawing.Point(0, 0);
            int o = SystemInformation.MenuHeight;
            this.Size = new System.Drawing.Size(w, h - o - 10);
            MaxWindow = true;
        }
        private void MaxButton_Click(object sender, EventArgs e)
        {

            if (!MaxWindow)
            {
                MaxsWindow();
            }
            else
            {
                this.Size = sizepo;
                this.Location = loctsi;
                MaxWindow = false;
            }
        }

        int pLeft = 0;
        int pTop = 0;
        private void mouseRightForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString().Equals("Left"))
            {
                if (MaxWindow)
                {
                    this.Size = sizepo;
                    MaxWindow = false;
                }
                //this指的是主窗口生成的对象
                this.Left = this.Location.X + e.X - pLeft;
                this.Top = this.Location.Y + e.Y - pTop;
            }
        }
        private void mouseRightForm_MouseDown(object sender, MouseEventArgs e)
        {

            pLeft = e.X;
            pTop = e.Y;
        }
        
        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;      //左边界
        const int HTRIGHT = 11;     //右边界
        const int HTTOP = 12;       //上边界
        const int HTTOPLEFT = 13;   //左上角
        const int HTTOPRIGHT = 14;  //右上角
        const int HTBOTTOM = 15;    //下边界
        const int HTBOTTOMLEFT = 0x10;    //左下角
        const int HTBOTTOMRIGHT = 17;     //右下角
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if (MaxWindow)
                        return;
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 20)
                        if (vPoint.Y <= 20)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 20)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 20)
                        if (vPoint.Y <= 20)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 20)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 20)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 20)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        

        private void Sirtlp()
        {
            int x = 5;
            int y = Title.Height;
            SetNe.Size = new Size(this.Width - (x * 2), this.Height - this.Title.Height - x);
            SetNe.Location = new Point(x, this.Title.Height);
        }

        private void BitForm_SizeChanged(object sender, EventArgs e)
        {
            /*
            Size p = this.Size;
            u.Size = new Size(p.Width - 5, p.Height + Title.Height - 5);
            */
            Form t = u;
            t.Size = SetNe.Size;
        }

        private void BitForm_Load(object sender, EventArgs e)
        {
            Sirtlp();
        }

        private void BitForm_SizeChanged_1(object sender, EventArgs e)
        {
            Sirtlp();
        }
    }
}
