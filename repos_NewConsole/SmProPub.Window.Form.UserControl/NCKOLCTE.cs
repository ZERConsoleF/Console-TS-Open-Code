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
    public partial class NCKOLCTE : Form
    {
        public static readonly int SideB = 3;

        public static NCKOLCTE[] GetIndexl { get; set; }
        /// <summary>
        /// Save In Program
        /// </summary>
        /// <param name="obj"></param>
        public void SaveInMemory(NCKOLCTE obj)
        {
            if (GetIndexl == null)
            {
                List<NCKOLCTE> Inv = new List<NCKOLCTE>();
                IDX = 0;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
            else
            {
                List<NCKOLCTE> Inv = new List<NCKOLCTE>(GetIndexl);
                IDX = Inv.Count;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
        }
        /// <summary>
        /// Save To Memory Name
        /// </summary>
        public int IDX { get; set; }
        public NCKOLCTE()
        {
            InitializeComponent();
            SaveInMemory(this);
            LockWindow = true;
            AsiPosInt = 5;
            Disposed += NCKOLCTE_Disposed;
        }
        private void NCKOLCTE_Disposed(object sender, EventArgs e)
        {
            List<NCKOLCTE> t = new List<NCKOLCTE>(GetIndexl);
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
            if (LockWindow)
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
        /// 在窗体关闭时是否只是隐藏不释放
        /// </summary>
        public bool WindowsCloseHide { get; set; }
        public int AsiPosInt { get; set; }
        #endregion
        /// <summary>
        /// 当窗体正在移动时候(不管是否锁定)
        /// </summary>
        public event ObjectEventArg FormMoving;

        public void AddControl(Control vt)
        {
            //Console.WriteLine(ShowIn.InvokeRequired);
            if (ShowIn.InvokeRequired)
                ShowIn.BeginInvoke(new MethodInvoker(delegate { ShowIn.Controls.Add(vt); }));
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
                if (NewMath.AdsoValueAtInt(Top) > AsiPosInt || NewMath.AdsoValueAtInt(Left) > AsiPosInt)
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
            WindowState = FormWindowState.Normal;
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
                List<NCKOLCTE> v = new List<NCKOLCTE>(GetIndexl);
                v.Remove(this);
                GetIndexl = v.ToArray();
                Close();
            }
            else
                Hide();
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
