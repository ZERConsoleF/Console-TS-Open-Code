using ConsoleG.Core.com;
using ConsoleG.Core.com.setting;
using SmProPub.Window.Formw.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RunLCJVM.Window.TsIm;
using System.IO;
using System.Threading;
using ConsoleG.Core.com.LoadProgram;

namespace RunLCJVM.Window
{
    public partial class MainWindow : Form
    {
        public string TitleName = "";
        public GetArg arg;
        public string lauge = "";
        //public List<ProcessNameMkst> md = new List<ProcessNameMkst>();
        private List<ToolStripMenuItem> itmn = new List<ToolStripMenuItem>();
        public List<MenuCreat> mn = new List<MenuCreat>();
        public SeeModsConsoleRun rc;
        public Thread tc;
        
        /// <summary>
        /// 是否初始化完毕
        /// </summary>
        public bool FinishInitLoad { get; protected set; }
        public new Control.ControlCollection Controls { get { if (!FinishInitLoad) return base.Controls; else return MainShow.Controls; } }
        public MainWindow(SeeModsConsoleRun arg)
        {
            InitializeComponent();
            FinishInitLoad = true;
            this.arg = arg.args;
            rc = arg;
        }
        public new void Close()
        {
            CommentShow.Text = "已通知SeeModsConsoleRun.Shutdown()运行";
            rc.Shutdown();

            if (tc != null && tc.ThreadState != ThreadState.Running)
                tc.Resume();
            base.Close();
        }
        /// <summary>
        /// 获取系统的剩余分配大小
        /// </summary>
        /// <returns></returns>
        public Size GetWindowGCLty()
        {
            int w = this.Width;
            int h = this.Height - (this.TitlePan.Size.Height + this.UnDownPan.Size.Height);
            return new Size(w, h);
        }
        [Obsolete("强行向主窗口添加控件，会导致排版错误")]
        public void AddControlInvokeInMain(Control e)
        {
            if (InvokeRequired)
            {

                Invoke(new MethodInvoker(delegate { AddControlInvokeInMain(e); }));
            }
            else
            {
                base.Controls.Add(e);
            }
        }
        [Obsolete("可以引索当前控件的列表，但是强行修改会导致排版错误")]
        public Control.ControlCollection GetControlsInMain()
        {
            return base.Controls;
        }

        public void AddControlInvoke(Control e)
        {
            if (InvokeRequired)
            {

                Invoke(new MethodInvoker(delegate { AddControlInvoke(e); }));
            }
            else
            {
                Controls.Add(e);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            menusp.Renderer = new CPMenuSpitre(this.BackColor);
        }


        #region
        bool MaxWindow = false;
        System.Drawing.Size sizepo = new Size(800, 600);
        System.Drawing.Point loctsi = new Point(0, 0);
        public void MaxsWindow()
        {
            /*
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(MaxsWindow));
                return;
            }
            */
            if (MaxWindow)
                return;
            loctsi = this.Location;
            sizepo = this.Size;
            this.Location = new System.Drawing.Point(0, 0);
            WindowState = FormWindowState.Maximized;
            int h = Height;//Screen.PrimaryScreen.Bounds.Height;
            int w = Width;//Screen.PrimaryScreen.Bounds.Width;
            WindowState = FormWindowState.Normal;
            int o = SystemInformation.MenuHeight;
            this.Size = new System.Drawing.Size(w, h - o - 10);
            MaxWindow = true;
        }
        public void MinsWindow()
        {
            if (!MaxWindow)
                return;
            this.Size = sizepo;
            //Console.WriteLine(sizepo.Width + " " + sizepo.Height);
            this.Location = loctsi;
            //Console.WriteLine(loctsi.X + " " + loctsi.Y);
            MaxWindow = false;
        }
        private void MaxButton_Click(object sender, EventArgs e)
        {

            if (!MaxWindow)
            {
                MaxsWindow();
            }
            else
            {
                MinsWindow();
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
        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        public void ListMenuTs()
        {
            menusp.Items.Clear();
            CreativeMemoryty tmenu = new CreativeMemoryty(SmProConst.GetMenuMemoryName);
            tmenu.Creativestr();
            LoadMenust jsd = JsonConvert.DeserializeObject<LoadMenust>(Encoding.Unicode.GetString(tmenu.returnValeByte()));
            List<ToolStripMenuItem> it = new List<ToolStripMenuItem>();
            foreach (MenuCreat ig in jsd.cti.ToArray())
                it.Add(loadsd(ig));
            menusp.Items.AddRange(it.ToArray());
        }

        public ToolStripMenuItem loadsd(MenuCreat ct)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.AutoSize = true;
            item.Name = ct.name;
            item.Text = ct.text;
            if (File.Exists(ct.imagefile))
                item.Image = Image.FromFile(ct.imagefile);
            List<ToolStripItem> idu = new List<ToolStripItem>();

            if (ct.menuCreats != null)
                foreach (MenuCreat ctr in ct.menuCreats.ToArray())
                {
                    idu.Add(loadsd(ctr));
                    if (ctr.underspite)
                        idu.Add(new ToolStripSeparator());
                }
            item.DropDownItems.AddRange(idu.ToArray());
            itmn.Add(item);
            mn.Add(ct);

            return item;
        }

        private void MenuRunSte()
        {
            for (int xc = 0; xc < mn.Count; xc++)
            {
                MenuCreat ci = mn.ToArray()[xc];
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ListMenuTs();
        }

        private void TaskListButton_Click(object sender, EventArgs e)
        {
            TaskList li = new TaskList();
            li.o = rc.lcass.ToArray();
            li.opp = rc;
            li.ShowDialog();
        }
    }
}
