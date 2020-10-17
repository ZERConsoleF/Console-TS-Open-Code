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
using System.SmProPub.ExClass;

namespace SmProPub.Window.Forms.UsersControl
{
    [ToolboxBitmap(typeof(TextBox))]
    public partial class ConsoleShowWindow : UserControl
    { 
        public ConsoleShowWindow()
        {
            InitializeComponent();

            ObjectClass<ConsoleShowWindow> w = new ObjectClass<ConsoleShowWindow>();
            w.IDX = w.SaveInMemory(this);

            Disposed += ConsoleShowWindow_Disposed;

            //FortText = Color.Green;
            //CheckForIllegalCrossThreadCalls = false;
            ConsoleS = false;
            AllowPase = true;
            /*
            if (GetIndex == null)
            {
                List<ConsoleShowWindow> Inv = new List<ConsoleShowWindow>();
                this.Handex = 0;
                Inv.Add(this);
                GetIndex = Inv.ToArray();
            }
            else
            {
                List<ConsoleShowWindow> Inv = new List<ConsoleShowWindow>(GetIndex);
                this.Handex = Inv.Count;
                Inv.Add(this);
                GetIndex = Inv.ToArray();
            }
            */
        }

        private void ConsoleShowWindow_Disposed(object sender, EventArgs e)
        {
            ObjectClass<ConsoleShowWindow>.DisopseInMemory(this);
        }
        #region
        /// <summary>
        /// 控件Memory Name ID Save
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("控件Memory Name ID Save")]
        public int Handex { get; set; }
        /// <summary>
        /// 控件返回的文本
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("控件返回的文本")]
        public event ObjectEventArg BackText;

        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("控件的背景颜色(重载)")]
        public new Color BackColor { get { return ShowText.BackColor; }set { if (ConsoleS) ConsoleColor = (ConsoleColor)GetColorConsole(value); ShowText.BackColor = value;base.BackColor = value; } }
        /// <summary>
        /// 显示的前景色
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("显示的前景色")]
        public Color FortText { get { return ShowText.SelectionColor; } set {
                if (ConsoleS)
                    ConsoleFontColor = (ConsoleColor)GetColorConsole(value);
                //if (ShowText.InvokeRequired)
                    //ShowText.BeginInvoke(new MethodInvoker(delegate { ShowText.SelectionColor = value; }));
                //else
                    ShowText.SelectionColor = value;
            } }
        /// <summary>
        /// 获取输出的文本
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("获取输出的文本")]
        public string ReturnText { get { return returnlls; } }
        /// <summary>
        /// 是否开启输入
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("是否开启输入")]
        public bool ReadText { get { return !ShowText.ReadOnly; } set { ShowText.ReadOnly = !value; } }
        /// <summary>
        /// 是否恒定开启输入
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("是否恒定开启输入")]
        public bool ReadKeepAlie { get; set; }
        /// <summary>
        /// 是否为控制台窗口
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("是否为控制台窗口")]
        public bool ConsoleS { get; set; }
        /// <summary>
        /// 主控制颜色
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("主控制颜色")]
        public ConsoleColor ConsoleColor { get { return Console.BackgroundColor; } set { Console.BackgroundColor = value; } }
        /// <summary>
        /// 主控制字颜色
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("主控制字颜色")]
        public ConsoleColor ConsoleFontColor { get { return Console.ForegroundColor; } set { Console.ForegroundColor = value; } }
        /// <summary>
        /// 是否允许粘贴选项开启
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("是否允许粘贴选项开启")]
        public bool AllowPase { get; set; }
        /// <summary>
        /// 当前是否有文本输出
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("当前是否有文本输出")]
        public bool HasSteamText { get; protected set; }
        /// <summary>
        /// 是否临时停用BackText事件
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("是否临时停用BackText事件")]
        public bool DisTextOutEvent { get; set; }
        /*
        /// <summary>
        /// 在操控时，这些字符不会继续操控
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("AppConsole")]
        [System.ComponentModel.Description("在操控时，这些字符不会继续操控")]
        public Keys[] NextKeys { get; set; }
        */
        #endregion
        #region
        List<string> surutext = new List<string>();
        int textlist;

        public int GetColorConsole(Color value)
        {
            int f = 0;
            foreach (Color h in l)
            {
                if (h == value)
                    return f;
                f++;
            }
            return 15;
        }
        #endregion
        int startselect = 0;
        string returnlls;
        Color[] l = {
                Color.Black,
                Color.DarkBlue,
                Color.DarkGreen,
                Color.DarkCyan,
                 Color.DarkRed,
                Color.DarkMagenta,
                Color.YellowGreen,
                Color.Gray,
                Color.DarkGray,
                Color.Blue,
                Color.Green,
                Color.Cyan,
                Color.Red,
                Color.Magenta,
                Color.Yellow,
                Color.White
            };
        #region
        /// <summary>
        /// 通过名称获取Console
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ConsoleShowWindow GetConsoleShowWindowInName(string name)
        {
            if (ObjectClass<ConsoleShowWindow>.GetIndexl != null)
                foreach (ConsoleShowWindow w in ObjectClass<ConsoleShowWindow>.GetIndexl)
                {
                    if (w.Name == name)
                    {
                        return w;
                    }
                }
            return null;
        }

        /// <summary>
        /// 清空控制台
        /// </summary>
        public void ConsoleClear()
        {
            if (ConsoleS)
            {
                Console.Clear();
                return;
            }
            if (ShowText.InvokeRequired)
                ShowText.Invoke(new MethodInvoker(delegate { ShowText.Text = ""; }));
            else
                ShowText.Text = "";
        }
        /// <summary>
        /// 控制台输入
        /// </summary>
        /// <param name="value"></param>
        /// <param name="obj"></param>
        public void ConsoleWrite(string value, params object[] obj)
        {
            if (ConsoleS)
            {
                Console.Write(value, obj);
                return;
            }
            //if (ShowText.InvokeRequired)
            //{
            //ShowText.BeginInvoke(new MethodInvoker(delegate { ConsoleWrite(value, obj); }));
            //}
            //else
            //{
            //Console.WriteLine(ShowText.InvokeRequired);
                Color c = FortText;
                string sy = string.Format(value, obj);
                ShowText.SelectionStart = ShowText.TextLength;
                string p = string.Empty;
                foreach (char p7 in sy)
                {
                    if (p7 == '\b')
                        ConsoleKeyBack();
                    else
                        p += p7;
                }
                
                ShowText.AppendText(p);
                startselect = ShowText.Text.Length;
            FortText = c;
            //}
        }
        /// <summary>
        /// 控制台输入行
        /// </summary>
        /// <param name="value"></param>
        /// <param name="obj"></param>
        public void ConsoleWriteLine(string value,params object[] obj)
        {
            ConsoleWrite(value + "\r\n", obj);
        }
        /// <summary>
        /// 可以当做键盘输入
        /// </summary>
        /// <param name="value"></param>
        public void ConsoleKeyWrite(string value)
        {
            //if (ShowText.InvokeRequired)
            //{
                //ShowText.Invoke(new MethodInvoker(delegate { ConsoleKeyWrite(value); }));
            //}
            //else
            //{
                if (ReadText)
                {
                    string p = string.Empty;
                    foreach (char p7 in value)
                    {
                        if (p7 == '\b')
                            ConsoleKeyBack();
                        else
                            p += p7;
                    }
                    ShowText.AppendText(p);
                }
            //}
        }
        /// <summary>
        /// 删除在一行的文本一个字符
        /// </summary>
        public void ConsoleKeyBack()
        {
            string text = ShowText.Text;
            if (text.Length <= 0)
                return;
            if (text[text.Length - 1] == '\n')
                return;

            ShowText.SelectionStart = ShowText.TextLength - 1;
            ShowText.SelectionLength = 1;
            ShowText.SelectedText = "";

            if (ShowText.Text.Length <= startselect)
            {
                startselect = ShowText.TextLength;
            }
        }
        /// <summary>
        /// 删除多少的文字
        /// </summary>
        /// <param name="idx">删除数</param>
        public void ConsoleKeyBack(int idx)
        {
            if (idx < 0)
                return;
            while (idx > 0)
            {
                ConsoleKeyBack();
                idx--;
            }
        }
        /// <summary>
        /// 删除用户写入(全部)
        /// </summary>
        public void ConsoleKeyBackRead()
        {
            if (ReadText)
            {
                ShowText.SelectionStart = startselect;
                ShowText.SelectionLength = ShowText.TextLength;
                ShowText.SelectedText = "";
            }
        }
        /// <summary>
        /// 控制主窗口获取输入
        /// </summary>
        /// <returns></returns>
        public string ConsoleReadLine()
        {
            if (!ConsoleS)
            {
                while (!HasSteamText) ;
                return returnlls;
                //throw new SmException("获取失败，定义不到-1的窗口，它不是控制台");
            }
            return Console.ReadLine();
        }
        #endregion
        #region
        /// <summary>
        /// 删除记录
        /// </summary>
        public void ClearTakeDown()
        {
            surutext.Clear();
            textlist = 0;
        }
        /// <summary>
        /// 返回记录
        /// </summary>
        /// <returns></returns>
        public string[] ReturnTakeDown()
        {
            return surutext.ToArray();
        }
        /// <summary>
        /// 标记记录
        /// </summary>
        public void Mark()
        {
            //ApartmentState s = Thread.CurrentThread.GetApartmentState();
            //Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            bool hasppe = ShowText.ReadOnly;
            ShowText.ReadOnly = true;

            string showtxt = "* [Marking...] *";

            ConsoleWrite(showtxt);

            ShowText.SelectionStart = 0;

            ShowText.KeyDown += ShowText_KeyDown1;
            while (!markend) ;
            ShowText.KeyDown -= ShowText_KeyDown1;
            ShowText.ReadOnly = hasppe;
            ShowText.SelectionStart = ShowText.TextLength;
            ConsoleKeyBack(showtxt.Length);
            markend = false;
            //Thread.CurrentThread.SetApartmentState(s);
        }

        bool markend = false;
        private void ShowText_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Thread t = new Thread(() => { Clipboard.SetData(DataFormats.Text, ShowText.SelectedText); });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                markend = true;
            }
            e.Handled = true;
        }
        #endregion

        private void ShowText_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ShowText.ReadOnly)
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (ShowText.Text.Length == startselect)
                        e.Handled = true;
                    return;
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    return;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (surutext.Count != 0)
                    {
                        string fp = surutext[textlist];
                        ConsoleKeyBackRead();
                        ConsoleKeyWrite(fp);
                        if (textlist > 0)
                            textlist--;
                    }
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (surutext.Count != 0)
                    {
                        string fp = surutext[textlist];
                        ConsoleKeyBackRead();
                        ConsoleKeyWrite(fp);
                        if (textlist < surutext.Count - 1)
                            textlist++;
                    }
                    e.Handled = true;
                }
                if (ShowText.SelectionStart >= startselect && e.KeyCode != Keys.Enter)
                    return;
                ShowText.SelectionStart = ShowText.TextLength;
                if (e.KeyCode == Keys.Enter)
                {
                    Color u = ShowText.SelectionColor;
                    string sp = ShowText.Text;
                    string sq = string.Empty;
                    //Console.WriteLine("{0}/{1}", startselect, ShowText.Text.Length);
                    for (; startselect < ShowText.Text.Length; startselect++)
                    {
                        sq += sp[startselect];
                    }
                    returnlls = sq;
                    HasSteamText = true;
                    if (BackText != null && !DisTextOutEvent)
                    {
                        ObjectEvent f = new ObjectEvent();
                        f.Name = "System.Form.ConsoleShowWindow(Control)";
                        f.Save = this;
                        BackText(sq, f);
                    }
                    surutext.Add(sq);
                    HasSteamText = false;
                    textlist = surutext.Count - 1;
                    startselect += sq.Length - 1;
                    ShowText.ReadOnly = !ReadKeepAlie;
                    returnlls = string.Empty;
                    startselect = ShowText.Text.Length;
                    ShowText.SelectionColor = u;
                    e.Handled = true;
                }
            }
        }

        private void ShowText_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void ShowText_TextChanged(object sender, EventArgs e)
        {
        }

        private void markToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Mark);
            t.IsBackground = true;
            t.Start();
        }

        private void paseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AllowPase)
                return;
            if (ShowText.SelectionStart < startselect)
                ShowText.SelectionStart = ShowText.TextLength;
            Thread t = new Thread(() => { ShowText.AppendText(Clipboard.GetText()); });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
    }
}
