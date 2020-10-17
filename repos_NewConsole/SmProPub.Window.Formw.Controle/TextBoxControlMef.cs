using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProPub.Window.Formw.Controle
{
    [ToolboxBitmap(typeof(TextBox))]
    public partial class TextBoxControlMef : TextBox
    {
        //设置Rect消息
        private const int EM_SETRECT = 179;
        //获取Rect消息
        private const int EM_GETRECT = 178;
        //粘贴消息
        private const int WM_PASTE = 0x0302;

        private Color borderColor = Color.Black;
        private float leftBorderSize = 1;
        private float rightBorderSize = 1;
        private float topBorderSize = 1;
        private float bottomBorderSize = 1;
        private Padding textPadding = new Padding(1);
        private bool allowReturn = false;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rectangle lParam);


        //画边框
        private void DrawBorder(IntPtr hDC)
        {
            Graphics g = Graphics.FromHdc(hDC);

            #region 左边框
            if (leftBorderSize > 0)
            {
                Pen penLeft = new Pen(borderColor, leftBorderSize);
                Point[] pointLeft = new Point[2];
                pointLeft[0] = new Point(0, 0);
                pointLeft[1] = new Point(0, this.Width - 1);
                g.DrawLine(penLeft, pointLeft[0], pointLeft[1]);
            }
            #endregion

            #region 右边框
            if (rightBorderSize > 0)
            {
                Pen penRight = new Pen(borderColor, rightBorderSize);
                Point[] pointRight = new Point[2];
                pointRight[0] = new Point(this.Width - 1, 0);
                pointRight[1] = new Point(this.Width - 1, this.Height - 1);
                g.DrawLine(penRight, pointRight[0], pointRight[1]);
            }
            #endregion

            #region 上边框
            if (topBorderSize > 0)
            {
                Pen penTop = new Pen(borderColor, topBorderSize);
                Point[] pointTop = new Point[2];
                pointTop[0] = new Point(0, 0);
                pointTop[1] = new Point(this.Width - 1, 0);
                g.DrawLine(penTop, pointTop[0], pointTop[1]);
            }
            #endregion

            #region 下边框
            if (bottomBorderSize > 0)
            {
                Pen penBottom = new Pen(borderColor, bottomBorderSize);
                Point[] pointBottom = new Point[2];
                pointBottom[0] = new Point(0, this.Height - 1);
                pointBottom[1] = new Point(this.Width - 1, this.Height - 1);
                g.DrawLine(penBottom, pointBottom[0], pointBottom[1]);
            }
            #endregion
        }

        public void SetTextDispLayout()
        {
            if (Text == "")
                return;
            //当允许多行和禁止会车时，Paddin有效
            if (this.Multiline && (!this.WordWrap))
            {
                Rectangle rect = new Rectangle();
                SendMessage(this.Handle, EM_GETRECT, (IntPtr)0, ref rect);
                //SizeF size = CreateGraphics().MeasureString(Text, Font);
                //rect.Y = (int)(Height - size.Height) / 2 + TextPadding.Top;
                rect.Y = textPadding.Top;
                rect.X = textPadding.Left;
                rect.Height = Height;
                rect.Width = Width - textPadding.Right - textPadding.Left;
                SendMessage(this.Handle, EM_SETRECT, IntPtr.Zero, ref rect);
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void WndProc(ref Message m)
        {
            //string str = "";
            //bool flag = false;
            //int i = 0;
            //if (m.Msg == 0x0204)
            //    i++;
            //if (!AllowReturn
            //    && m.Msg == WM_PASTE
            //    && System.Windows.Forms.Clipboard.ContainsText())
            //{
            //    str = System.Windows.Forms.Clipboard.GetText();
            //    System.Windows.Forms.Clipboard.Clear();
            //    string nstr = str.Replace(char.ConvertFromUtf32((int)Keys.Return), "").Replace(char.ConvertFromUtf32((int)Keys.LineFeed), "");
            //    System.Windows.Forms.Clipboard.SetText(nstr);
            //    if (str.Length > 0) flag = true;
            //}

            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                    return;

                DrawBorder(hDC);

                //返回结果
                m.Result = IntPtr.Zero;
                //释放
                ReleaseDC(m.HWnd, hDC);
            }

            //if (flag)
            //{
            //    flag = false;
            //    System.Windows.Forms.Clipboard.SetText(str);
            //    str = "";
            //}
        }

        #region 属性
        [Description("边框颜色"), Category("自定义属性")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }
        [Description("左边框宽度"), Category("自定义属性")]
        public float LeftBorderSize
        {
            get { return leftBorderSize; }
            set { leftBorderSize = value; this.Invalidate(); }
        }
        [Description("右边框宽度"), Category("自定义属性")]
        public float RightBorderSize
        {
            get { return rightBorderSize; }
            set { rightBorderSize = value; this.Invalidate(); }
        }
        [Description("上边框宽度"), Category("自定义属性")]
        public float TopBorderSize
        {
            get { return topBorderSize; }
            set { topBorderSize = value; this.Invalidate(); }
        }
        [Description("下边框宽度"), Category("自定义属性")]
        public float BottomBorderSize
        {
            get { return bottomBorderSize; }
            set { bottomBorderSize = value; this.Invalidate(); }
        }
        [/*DisplayName("內邊距")*/Description("文本内边距，当允许多行和禁止回车时有效"), Category("自定义属性")]
        public Padding TextPadding
        {
            get { return textPadding; }
            set { textPadding = value; SetTextDispLayout(); }
        }
        [/*DisplayName("允許回車")*/Description("是否允许回车"), Category("自定义属性")]
        public bool AllowReturn
        {
            get { return allowReturn; }
            set { allowReturn = value; this.Invalidate(); }
        }
        #endregion

        #region 事件
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //如果不允许回车 屏蔽回车 换行键值
            if (!AllowReturn
 && ((int)e.KeyChar == (int)Keys.Return || (int)e.KeyChar == (int)Keys.LineFeed))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            SetTextDispLayout();
        }
        #endregion
    }
}
