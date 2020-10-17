using SmProPub.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class NCKOLCTETU : UserControl
    {
        public static readonly int SideB = 3;

        public static NCKOLCTETU[] GetIndexl { get; set; }
        /// <summary>
        /// Save In Program
        /// </summary>
        /// <param name="obj"></param>
        public void SaveInMemory(NCKOLCTETU obj)
        {
            if (GetIndexl == null)
            {
                List<NCKOLCTETU> Inv = new List<NCKOLCTETU>();
                IDX = 0;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
            else
            {
                List<NCKOLCTETU> Inv = new List<NCKOLCTETU>(GetIndexl);
                IDX = Inv.Count;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
        }
        /// <summary>
        /// Save To Memory Name
        /// </summary>
        public int IDX { get; set; }
        public NCKOLCTETU()
        {
            InitializeComponent();
            SaveInMemory(this);
            LockWindow = true;
            Icon = new Form().Icon;
            AsiPosInt = 5;
            Disposed += NCKOLCTETU_Disposed;
        }

        private void NCKOLCTETU_Disposed(object sender, EventArgs e)
        {
            List<NCKOLCTETU> t = new List<NCKOLCTETU>(GetIndexl);
            t.Remove(this);
            GetIndexl = t.ToArray();
        }
        #region Private
        #endregion
        #region Window移动
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
            if (LockWindow && !CanChangeSizeAtLockWindows)
            {
                base.WndProc(ref m);
                return;
            }
            switch (m.Msg)
            {
                case WM_NCHITTEST:
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
        #endregion
        #region 决定窗体状态
        /// <summary>
        /// 是否锁定窗体位置状态
        /// </summary>
        public bool LockWindow { get { return checkBox1.Checked; } set { checkBox1.Checked = value; } }
        /// <summary>
        /// 在窗体锁定是否允许调整窗体大小
        /// </summary>
        public bool CanChangeSizeAtLockWindows { get; set; }
        /// <summary>
        /// 在窗体关闭时是否只是隐藏不释放
        /// </summary>
        public bool WindowsCloseHide { get; set; }
        #endregion

        public Icon Icon { get; set; }
        public int AsiPosInt { get; set; }
        FormWindowState WindowStateG;

        public FormWindowState WindowState
        {
            get { return WindowStateG; }
            set
            {
                switch (value)
                {
                    case FormWindowState.Normal:
                        Show();
                        break;
                    case FormWindowState.Minimized:
                        Hide();
                        break;
                    case FormWindowState.Maximized:
                        throw new SmException("在这个特殊的Form容器，最大化已被禁用!");
                }
                WindowStateG = value;
            }
        }


        /// <summary>
        /// 在关闭时发生(WindowsCloseHide必须为false才能触发)
        /// </summary>
        public event ObjectEventArg Closing;
        /// <summary>
        /// 当窗体正在移动时候(不管是否锁定)
        /// </summary>
        public event ObjectEventArg FormMoving;

        public new void Show()
        {

            WindowStateG = FormWindowState.Normal;
            base.Show();
        }
        public new void Hide()
        {
            WindowStateG = FormWindowState.Minimized;
            base.Hide();
        }
        public void Close()
        {
            Hide();
            if (!WindowsCloseHide)
                Dispose();
        }
        public new void Dispose()
        {
            if (Closing != null)
                Closing(this, new System.SmProPub.Event.ObjectEvent());
            base.Dispose();
        }

        public void AddControl(Control vt)
        {
            //Console.WriteLine(ShowIn.InvokeRequired);
            if (ShowIn.InvokeRequired)
                ShowIn.Invoke(new MethodInvoker(delegate { ShowIn.Controls.Add(vt); }));
            else
            {
                ShowIn.Controls.Add(vt);
            }
        }
        public Control[] GetControl()
        {
            List<Control> l = new List<Control>();
            foreach (Control k in ShowIn.Controls)
            {
                l.Add(k);
            }
            return l.ToArray();
        }

        private void NCKOLCTE_SizeChanged(object sender, EventArgs e)
        {
            Size y = Size;
            Point p = new Point(SideB, SideB);

            panel1.Size = new Size(y.Width - (SideB * 2), y.Height - (SideB * 2));
            panel1.Location = p;
        }
        int pLeft = 0;
        int pTop = 0;
        private void mouseRightForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString().Equals("Left"))
            {
                //this指的是主窗口生成的对象
                int Left = this.Location.X + e.X - pLeft;
                int Top = this.Location.Y + e.Y - pTop;
                if (NewMath.AdsoValueAtInt(e.X - pLeft) > AsiPosInt || NewMath.AdsoValueAtInt(e.Y - pTop) > AsiPosInt)
                    if (FormMoving != null)
                        FormMoving(this, new ObjectEvent());
                if (LockWindow)
                    return;
                this.Top = Top;
                this.Left = Left;
            }
        }
        private void mouseRightForm_MouseDown(object sender, MouseEventArgs e)
        {
            Show();
            Focus();
            pLeft = e.X;
            pTop = e.Y;
        }

        private void NCKOLCTE_Load(object sender, EventArgs e)
        {
            NCKOLCTE_SizeChanged(null, new EventArgs());
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (!WindowsCloseHide)
            {
                List<NCKOLCTETU> v = new List<NCKOLCTETU>(GetIndexl);
                v.Remove(this);
                GetIndexl = v.ToArray();
                Dispose();
            }
            else
                Hide();
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TitleName_TextChanged(object sender, EventArgs e)
        {
            //Text = TitleName.Text;
        }

        private void NCKOLCTE_TextChanged(object sender, EventArgs e)
        {
            TitleName.Text = Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
