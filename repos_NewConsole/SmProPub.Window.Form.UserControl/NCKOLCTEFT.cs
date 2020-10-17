using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class NCKOLCTEFT : UserControl
    {
        public static readonly int SideB = 3;
        public NCKOLCTEFT()
        {
            InitializeComponent();
            Icon = new Form().Icon;
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
        public bool LockWindow { get; set; }
        #endregion

        public Icon Icon { get; set; }

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
            if (LockWindow)
                return;
            if (e.Button.ToString().Equals("Left"))
            {
                //this指的是主窗口生成的对象
                this.Left = this.Location.X + e.X - pLeft;
                this.Top = this.Location.Y + e.Y - pTop;
            }
        }
        private void mouseRightForm_MouseDown(object sender, MouseEventArgs e)
        {
            //WindowState = FormWindowState.Normal;
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
            Hide();
            Dispose();
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TitleName_TextChanged(object sender, EventArgs e)
        {
            Text = TitleName.Text;
        }
    }
}
