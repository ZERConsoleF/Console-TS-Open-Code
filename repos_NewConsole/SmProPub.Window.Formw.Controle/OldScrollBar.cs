using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
         [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)] 
*/

namespace MyControlLibrary
{
    [ToolboxBitmap(typeof(HScrollBar))]

    public partial class OldScrollBar : UserControl
    {
       
        public OldScrollBar()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Mouse_WhellLoc);
            MouseMoveLU = 10;
        }

        #region
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("滑动控件(注意必须是是Control否则使用Senderessd)")]
        public Control Rexc { get; set; }
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("滑动控件Wheel事件的长短")]
        public int MouseMoveLU { get; set; }


        public delegate void ChatEvent(int cout, OldScrollBar sc);

        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Soctef")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("滑动控件的值")]
        public event ChatEvent MouseorWheelMoveTC;


        private void ScrollBar_Load(object sender, EventArgs e)
        {
            if (Rexc != null)
            {
                LoSocess();
                Control[] hp = sc();
                List<int> df = new List<int>();
                foreach (Control lo in hp)
                    df.Add(lo.Location.Y);
                co = df.ToArray();
                Rexc.ControlAdded += new ControlEventHandler(LG);
                Rexc.ControlRemoved += new ControlEventHandler(LG);
                Rexc.MouseWheel += new MouseEventHandler(Mouse_WhellLoc);
            }
        }
        private void Mouse_WhellLoc(object sender,MouseEventArgs e)
        {
            bool upl = e.Delta > 0;
            int xp = 0;
            if (upl)
                xp = -1 * MouseMoveLU;
            else
                xp = MouseMoveLU;

            if (this.SlideBar.Location.Y >= 0 && this.SlideBar.Location.Y <= Height - SlideBar.Height)
            {
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y + xp);
                if (this.SlideBar.Location.Y < 0)
                {
                    this.SlideBar.Location = new Point(this.SlideBar.Location.X, 0);
                }
                else if (this.SlideBar.Location.Y > Height - SlideBar.Height)
                {
                    this.SlideBar.Location = new Point(this.SlideBar.Location.X, Height - SlideBar.Height);
                }
                /*
                int xg = 0;
                if (this.SlideBar.Location.Y != 0)
                    xg = (int)(oc * 4 / (this.SlideBar.Location.Y));

                if (this.SlideBar.Location.Y + e.Y - pTop > y)
                {
                    Control[] h = sc();
                    foreach (Control c in h)
                        c.Location = new Point(c.Location.X, c.Location.Y - xg);
                }
                else if (this.SlideBar.Location.Y + e.Y - pTop < y)
                {
                    Control[] h = sc();
                    foreach (Control c in h)
                        c.Location = new Point(c.Location.X, c.Location.Y + xg);
                }

                y = this.SlideBar.Location.Y + e.Y - pTop;
                /*
                int io = SlideBar.Location.Y;

                Control[] h = sc();
                foreach (Control c in h)
                    c.Location = new Point(c.Location.X, c.Location.Y + y);
                */
                int df = ((int)od * this.SlideBar.Location.Y);
                Control[] h = sc();

                for (int i = 0; i < co.Length; i++)
                {
                    int f = co[i];
                    Control j = h[i];
                    j.Location = new Point(j.Location.X, f - df);
                }

                //this.SlideBar.Location = new Point(SlideBar.Location.X, this.SlideBar.Location.Y + e.Y - pTop);
            }
            /*
            else if (this.SlideBar.Location.Y < 0)
            {
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, 0);
            }
            else if (this.SlideBar.Location.Y > Height - SlideBar.Height)
            {
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, Height - SlideBar.Height);
            }
            */
            if (MouseorWheelMoveTC != null)
                MouseorWheelMoveTC(this.SlideBar.Location.Y, this);
        }
        private void LG(object sender,ControlEventArgs e)
        {
            Control[] hp = sc();
            List<int> df = new List<int>();
            foreach (Control lo in hp)
                df.Add(lo.Location.Y);
            co = df.ToArray();
            LoSocess();
        }
        private void LoSocess()
        {
            int xc = Rexc.Height;
            int xer = 0;
            Control h = new Control();
            foreach (Control s3 in sc())
            {
                xer += s3.Height;
                h = s3;
            }

            if (h.Location.Y < this.Height + h.Height)
            {
                xer = 0;
            }

            if (xer > xc)
            {
                int fg = xer - xc;
                oc = xer - xc;
                SlideBar.Height = Height - fg;
                od = oc / fg;
            }
            else
            {
                SlideBar.Height = Height;
            }
        }

        private Control[] sc()
        {
            List<Control> n8 = new List<Control>();
            foreach (Control cv in Rexc.Controls)
                n8.Add(cv);
            return n8.ToArray();
        }

        private void ScrollBar_SizeChanged(object sender, EventArgs e)
        {
            SlideBar.Width = Width;
            //LoSocess();
        }

        int y = 0;

        private void SlideBar_MouseClick(object sender, MouseEventArgs e)
        {
            pLeft = e.X;
            pTop = e.Y;
        }
        int pLeft = 0;
        int pTop = 0;
        double oc = 0;
        double od = 0;
        int[] co;
        private void SlideBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString().Equals("Left"))
            {
                //this指的是主窗口生成的对象
                //this.Left = this.Location.X + e.X - pLeft;

                if (this.SlideBar.Location.Y + e.Y - pTop >= 0 && this.SlideBar.Location.Y + e.Y - pTop <= Height - SlideBar.Height)
                {
                    /*
                    int xg = 0;
                    if (this.SlideBar.Location.Y != 0)
                        xg = (int)(oc * 4 / (this.SlideBar.Location.Y));

                    if (this.SlideBar.Location.Y + e.Y - pTop > y)
                    {
                        Control[] h = sc();
                        foreach (Control c in h)
                            c.Location = new Point(c.Location.X, c.Location.Y - xg);
                    }
                    else if (this.SlideBar.Location.Y + e.Y - pTop < y)
                    {
                        Control[] h = sc();
                        foreach (Control c in h)
                            c.Location = new Point(c.Location.X, c.Location.Y + xg);
                    }
                    
                    y = this.SlideBar.Location.Y + e.Y - pTop;
                    /*
                    int io = SlideBar.Location.Y;
                    
                    Control[] h = sc();
                    foreach (Control c in h)
                        c.Location = new Point(c.Location.X, c.Location.Y + y);
                    */
                    int df = ((int)od * this.SlideBar.Location.Y);
                    Control[] h = sc();

                    for (int i = 0; i < co.Length; i++)
                    {
                        int f = co[i];
                        Control j = h[i];
                        j.Location = new Point(j.Location.X, f - df);
                    }

                    this.SlideBar.Location = new Point(SlideBar.Location.X, this.SlideBar.Location.Y + e.Y - pTop);
                }
            }
            if (MouseorWheelMoveTC != null)
                MouseorWheelMoveTC(this.SlideBar.Location.Y, this);

        }
        private void Movelt(MouseEventArgs e)
        {
        }

        private void SlideBar_MouseDown(object sender, MouseEventArgs e)
        {
            pLeft = e.X;
            pTop = e.Y;
        }
        #endregion



        /*

        #region   DLL引入
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
       [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        const int EM_GETLINECOUNT = 0x00BA;//获取总行数
        const int EM_GETFIRSTVISIBLELINE = 0x00CE; //当前显示在textbox1中第一行的行号，0开始算
        /*      int totalLineCount = SendMessage(this.textBox1.Handle, EM_GETLINECOUNT, IntPtr.Zero, "");
                int currentLineNo = SendMessage(this.textBox1.Handle, EM_GETFIRSTVISIBLELINE, IntPtr.Zero, ""); */
        /*
#endregion

#region 私有成员
//private System.Windows.Forms.TextBox STextBox=null;
private Control _RelaPanel = null;
private Color _NormalColor=System.Drawing.SystemColors.ControlLight;
private Color _ActiveColor=System.Drawing.SystemColors.ControlDarkDark;
private Color _HoverColor = System.Drawing.SystemColors.ControlDark;
private System.Timers.Timer TimeDelegate = null;
private int TempCursor;
private bool SlideBarFlag=false ;
private bool ScrollBarFlag = false ;
private int SlideBarOpacity = 255;
#endregion

#region  滑动条最短长度
private int MinHeight = 30;
[System.ComponentModel.Browsable(true)]
[Localizable(true)]
[System.ComponentModel.Category("Appearance")]
[System.ComponentModel.DefaultValue(null)]
[System.ComponentModel.Description("滑动条最短长度")]
public int MinSlideBarLenght
{
    set
    {
        MinHeight = value;
    }
    get
    {
        return MinHeight;
    }
}
#endregion  

#region  要滑动的Panel
[System.ComponentModel.Browsable(true)]
[Localizable(true)]
[System.ComponentModel.Category("Appearance")]
[System.ComponentModel.DefaultValue(null)]
[System.ComponentModel.Description("要滚动的Panel")]
public Control RelaPanel
{
    set {
        _RelaPanel = value;
        ResizeSlideBar();
    }
    get {
        return _RelaPanel;
    }
}
#endregion  

#region 滑动条颜色
[System.ComponentModel.Browsable(true)]
[Localizable(true)]
[System.ComponentModel.Category("Appearance")]
[System.ComponentModel.DefaultValue(null)] 
public Color NormalColor
{
    set {
        _NormalColor = value;
        SlideBar.BackColor = value;
    }
    get {
        return _NormalColor;
    }
}
#endregion

#region 滑动条被按下颜色
[System.ComponentModel.Browsable(true)]
[Localizable(true)]
[System.ComponentModel.Category("Appearance")]
[System.ComponentModel.DefaultValue(null)]
[System.ComponentModel.Description("滑动条被按下的颜色")]
public Color ActiveColor
{
    set
    {
        _ActiveColor = value;
    }
    get
    {
        return _ActiveColor;
    }
}
#endregion

#region 鼠标进入滑动条颜色
[System.ComponentModel.Browsable(true)]
[Localizable(true)]
[System.ComponentModel.Category("Appearance")]
[System.ComponentModel.DefaultValue(null)]
[System.ComponentModel.Description("鼠标进入滑动条的颜色")]
public Color HoverColor
{
    set
    {
        _HoverColor = value;
    }
    get
    {
        return _HoverColor;
    }
}
#endregion

public int SlideStep { get { return RelaPanel.VerticalScroll.SmallChange; } }

public bool NeedSleep { get; set; }

public bool Active { get; set; }

private void This_Created(object sender, EventArgs e)
{
    this.SlideBar.Size = new Size(this.Width, 220);
    RelaPanel.MouseWheel += new MouseEventHandler(This_RelaPanel_MouseWheel);
    RelaPanel.MouseEnter += new EventHandler(ScrollBar_MouseEnter);
    RelaPanel.MouseLeave += new EventHandler(ScrollBar_MouseLeave);
    RelaPanel.ControlAdded += new ControlEventHandler(This_RelaPanel_ControlAdded);
    RelaPanel.ControlRemoved += new ControlEventHandler(This_RelaPanel_ControlRemoved);
}

private void ResizeSlideBar()
{
    double rate = (double)RelaPanel.Height / RelaPanel.DisplayRectangle.Height;
    SlideBar.Height = System.Math.Max((int)(rate * Height), MinHeight);
}

private void LocateSlideBar()
{
    double rate = (double)RelaPanel.VerticalScroll.Value / (RelaPanel.VerticalScroll.Maximum - RelaPanel.Height);
    SlideBar.Location = new Point(0, (int)(rate * (Height - SlideBar.Height)));
}

private void Wake()
{
    if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
    ResizeSlideBar();
    LocateSlideBar();
    SlideBarOpacity = 255;
}

private void ScrollBar_MouseEnter(object sender, EventArgs e)
{
    if (!Active) return;

    SlideBarFlag = true;
    Wake();
}

private void ScrollBar_MouseLeave(object sender, EventArgs e)
{
    if (!Active) return;

    ScrollBarFlag =false ;
    if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
    TimeDelegate = new System.Timers.Timer(10);
    TimeDelegate.AutoReset = true ;
    TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(ScrollBar_Leave_Delegate);
    TimeDelegate.Enabled = true;
}

private void ScrollBar_Leave_Delegate(object sender,System .Timers.ElapsedEventArgs e)
{
    TimeDelegate.Close();
    TimeDelegate = null;
    if (!ScrollBarFlag) this.SlideBar_Sleep();
}

private void SlideBar_Sleep()
{
    if (!Active) return;

    if (TimeDelegate != null) TimeDelegate.Close();
    TimeDelegate = new System.Timers.Timer(150);
    TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(SlideBar_Sleep_Delegate);
    TimeDelegate.AutoReset = true;
    TimeDelegate.Enabled = true;
}

private void SlideBar_Sleep_Delegate(object sender, System.Timers.ElapsedEventArgs e)
{
    if (!Active) return;

    if (NeedSleep)
    {
        this.SlideBarOpacity -= (256 - this.SlideBarOpacity);
        if (SlideBarOpacity <= 0)
        {
            TimeDelegate.Close();
            TimeDelegate = null;
            SlideBarOpacity = 0;
        }
        this.SlideBar.BackColor = System.Drawing.Color.FromArgb(SlideBarOpacity, this.NormalColor.R, this.NormalColor.G, this.NormalColor.B);
    }
}

private void SlideBar_MouseEnter(object sender, EventArgs e)
{
    if (!Active) return;

    this.ScrollBarFlag = true;
    Wake();
    this.SlideBar.BackColor = HoverColor;
}

private void SlideBar_MouseLeave(object sender, EventArgs e)
{
    if (!Active) return;

    this.SlideBar.BackColor = NormalColor;
    SlideBarFlag = false;
    if (TimeDelegate != null) TimeDelegate.Close();
    TimeDelegate = new System.Timers.Timer(10);
    TimeDelegate.AutoReset = true;
    TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(SlideBar_Leave_Delegate);
    TimeDelegate.Enabled = true;

}

private void SlideBar_Leave_Delegate(object sender, System.Timers.ElapsedEventArgs e)
{
    if (!Active) return;

    TimeDelegate.Close();
    TimeDelegate = null;
    if (!SlideBarFlag) this.SlideBar_Sleep();
    else this.SlideBar.BackColor = this.NormalColor;
}

private void SlideBar_MouseDown(object sender, MouseEventArgs e)
{
    if (!Active) return;

    this.SlideBar.BackColor = ActiveColor;
    TempCursor = Cursor.Position.Y;
     if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
    TimeDelegate = new System.Timers.Timer(1);
    TimeDelegate.AutoReset = true ;
    TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(Sliding_Delegate);
    TimeDelegate.Enabled = true;
    Control.CheckForIllegalCrossThreadCalls = false;
}

private void Sliding_Delegate(object sender,System.Timers.ElapsedEventArgs e)
{
    if (Cursor.Position.Y > TempCursor)
    {
        if (Cursor.Position.Y >= TempCursor + SlideStep)
        {
            TempCursor += SlideStep;
            if (this.SlideBar.Location.Y + SlideStep <= this.Height - SlideBar.Height)
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y + SlideStep);
            else
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, Height - this.SlideBar.Height);
            AdjustPanelVScroll();
        }
    }
    if (Cursor.Position.Y < TempCursor)
    {
        if (Cursor.Position.Y <= TempCursor - SlideStep)
        {
            TempCursor -= SlideStep;
            if (this.SlideBar.Location.Y - SlideStep >= 0)
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y - SlideStep);
            else
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, 0);
            AdjustPanelVScroll();
        }
    }
    System.Diagnostics.Debug.WriteLine(this.SlideBar.Location.ToString());
}

private void SlideBar_MouseUp(object sender, MouseEventArgs e)
{
    if (!Active) return;

    this.SlideBar.BackColor = HoverColor;
    if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
}

private void This_MouseWheel(object sender, MouseEventArgs e)
{
    if (!Active) return;

    if (e.Delta > 0)
    {
        if (this.SlideBar.Location.Y - SlideStep * SystemInformation.MouseWheelScrollLines >= 0)
            this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y
                - SlideStep * SystemInformation.MouseWheelScrollLines);
        else
            this.SlideBar.Location = new Point(this.SlideBar.Location.X, 0);
        AdjustPanelVScroll();
    }
    else
    {
        if (this.SlideBar.Location.Y + SlideStep * SystemInformation.MouseWheelScrollLines <= this.Height - SlideBar.Height)
            this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y
                + SlideStep * SystemInformation.MouseWheelScrollLines);
        else
            this.SlideBar.Location = new Point(this.SlideBar.Location.X, Height - this.SlideBar.Height);
        AdjustPanelVScroll();
    }
    System.Diagnostics.Debug.WriteLine("e.Location:" + e.Location.ToString());
    System.Diagnostics.Debug.WriteLine(this.SlideBar.Location.ToString());
}

private void AdjustPanelVScroll()
{
    double f = (double)SlideBar.Location.Y * (RelaPanel.VerticalScroll.Maximum - RelaPanel.Height) / (Height - SlideBar.Height);
    this.RelaPanel.VerticalScroll.Value = (int)f;
}

private void This_RelaPanel_MouseWheel(object sender, MouseEventArgs e)
{
    if (!Active) return;

    Wake();
    this.OnMouseWheel(e);
    SlideBar_Sleep();
}

private void This_RelaPanel_ControlAdded(object sender, ControlEventArgs e)
{
    AdjustPanelVScroll();
}

private void This_RelaPanel_ControlRemoved(object sender, ControlEventArgs e)
{
    AdjustPanelVScroll();
}

private void ScrollBar_SizeChanged(object sender, EventArgs e)
{
    SlideBar.Width = this.Width;
}

private void ScrollBar_VisibleChanged(object sender, EventArgs e)
{
    Active = Visible;
    if (Active)
    {
        Wake();
    }
}
*/
    }

}
