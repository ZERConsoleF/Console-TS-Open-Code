using ConsoleG.Core.com.setting;
using ConsoleG.Core.net.RunExct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleG.Core.net;
using SmProPub.Window.Formw.Controle;

namespace RunLCJVM.Window
{
    public partial class TaskList : Form
    {
        public TaskList()
        {
            InitializeComponent();
            oldScrollBar1.Rexc = itemList1.SubItemShow;
        }

        private void TaskList_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            tv = new Thread(new ThreadStart(vc));
            tv.Start();
        }

        public RunLoct[] o = new RunLoct[0];
        public SeeModsConsoleRun opp;

        public void op()
        {
            TaskListMG mg = TaskListMG.GetTask();
            TitleItem i = new TitleItem();
            i.Text = "名称";
            i.SubText.Add("描述");
            i.SubText.Add("查看详细");
            i.SizeText = new int[] { 132, 370, 100 };
            itemList1.TitleItem = i;
            List<SubItem> sf = new List<SubItem>();
            int x = 0;
            foreach (object[] jk in mg.ToArray())
            {
                SubItem s = new SubItem();
                s.Text = (string)jk[0];
                Label ct = new Label();
                ct.Name = "hu45jo1" + x;
                ct.AutoSize = true;

                string st = (string)jk[1];
                if (st.Contains("\r\n"))
                    st = FanYi.frome("hs.fq",null);
                ct.Text = st;
                s.SubObject.Add(ct);
                Button bt = new Button();
                bt.Name = "Nc." + x;
                bt.Text = "查看详细";
                bt.Size = new Size(100, bt.Height);
                bt.FlatStyle = FlatStyle.Flat;
                bt.FlatAppearance.BorderSize = 0;
                bt.AutoSize = true;
                bt.Click += new EventHandler(Clicky);
                s.SubObject.Add(bt);
                sf.Add(s);
                x++;
            }
            itemList1.SubItem = sf.ToArray();
            itemList1.Invok();
            /*
            ItemTool it = new ItemTool();
            it.SizeWidth = 64;
            Label o = new Label();
            o.Name = "label-1";
            o.AutoSize = true;
            o.Text = "任务名字";
            it.Con = o;
            ItemTool op1 = new ItemTool();
            op1.SizeWidth = 450;
            o = new Label();
            o.Name = "label0";
            o.AutoSize = true;
            o.Text = "描述";
            op1.Con = o;
            it.ItemChage.Add(op1);
            op1 = new ItemTool();
            op1.SizeWidth = 64;
            o = new Label();
            o.Name = "label1";
            o.AutoSize = true;
            o.Text = "选择查看";
            op1.Con = o;
            it.ItemChage.Add(op1);
            listOf1.TitleChage = it;

            int x = 0;


            List<ItemTool> vop = new List<ItemTool>();
            foreach (object[] ty in mg.ToArray())
            {

                ItemTool subit = new ItemTool();
                subit.SizeWidth = 64;
                Label lc = new Label();
                lc.Name = "sublabel" + x;
                lc.AutoSize = true;
                lc.Text = (string)ty[0];
                subit.Con = lc;

                ItemTool tc = new ItemTool();
                tc.SizeWidth = 450;
                Label tm4 = new Label();
                tm4.Name = "sublabel" + x + 1;
                tm4.AutoSize = true;
                tm4.Text = (string)ty[1];
                tc.Con = tm4;
                subit.ItemChage.Add(tc);
                vop.Add(subit);
            }
            listOf1.SubItemChage = vop.ToArray();
            listOf1.Invok();

            /*
            TaskListMG mg = TaskListMG.GetTask();
            object[] op = mg.ToArray();
            //Console.WriteLine(op.Length);
            List<Panel> l2 = new List<Panel>();
            foreach (object[] p29 in op)
            {
                Panel t = panel2;
                t.Size = panel2.Size;
                Label i = ShowName;
                Label u = Pname;
                Label fy = fw;

                i.Text = "任务名称 :" + p29[0];
                u.Text = "说明 :" + p29[1];
                //fy.Text = "执行返回:" + ((int)p29.save[1]) + " 在 " + p29.save[0];
                t.Controls.Add(i);
                t.Controls.Add(u);
                t.Controls.Add(fy);
                l2.Add(t);
            }
            l2.Add(panel2);
            listSocer9.LSFCatMkdirTy = l2.ToArray();
            listSocer9.VCLOButO = panel2.Size;
            listSocer9.InvokLt();
            */

            /*
            if (o.Length <= 0)
                return;
            List<Panel> l2 = new List<Panel>();
            foreach (RunLoct p29 in o)
            {
                LoadInfoClass p;
                if (((object[])p29.save[2]).Length != 0)
                    p = (LoadInfoClass)((object[])p29.save[2])[1];
                else
                {
                    p = new LoadInfoClass();
                    p.ShowName = "未知的加载!";
                    p.NameLoad = (string)p29.save[3];
                }
                Panel t = panel2;
                t.Size = panel2.Size;
                Label i = ShowName;
                Label u = Pname;
                Label fy = fw;

                i.Text = "Show Name :" + p.ShowName;
                u.Text = "NameThread :" + p.NameLoad;
                fy.Text = "执行返回:" + ((int)p29.save[1]) + " 在 " + p29.save[0];
                t.Controls.Add(i);
                t.Controls.Add(u);
                t.Controls.Add(fy);
                l2.Add(t);
            }
            l2.Add(panel2);
            listSocer9.LSFCatMkdirTy = l2.ToArray();
            listSocer9.VCLOButO = panel2.Size;
            listSocer9.InvokLt();
            */
        }
        public void Clicky(object sender, EventArgs e)
        {
            string[] u = ((Control)sender).Name.Split('.');
            int cv = Convert.ToInt32(u[u.Length - 1]);
            object[] gh = (object[])TaskListMG.GetTask().ToArray()[cv];
            if (gh[2] is Control)
            {
                ((Control)gh[2]).Show();
            }
            if (gh[2] == null)
            {
                TaskListShowLLC i = new TaskListShowLLC();
                i.Text += "-" + gh[0];
                i.LessTme.Text = (string)gh[1];
                i.Show();
            }
        }


        Thread tv;
        void vc()
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate { op(); }));
                while (true)
                {
                    //InfoLp.Text = "Load...";
                    Thread.Sleep(100);
                    string st = SystemInfo.FormatSize(SystemInfo.GetUsedPhys());
                    string st1 = SystemInfo.returnCPU();
                    string st2 = Process.GetCurrentProcess().Threads.Count.ToString();
                    InfoLp.Text = FanYi.frome("etc.threadlc", null, st, st1, st2);
                }
            }
            catch (Exception ex)
            {
                //InfoLp.Text = ex.Message;
            }
        }

        private void TaskList_FormClosing(object sender, FormClosingEventArgs e)
        {
            tv.Interrupt();
            tv.Abort();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //this.Invoke(new MethodInvoker(delegate { op(); }));
            //listOf1.listSocer1.ClearList();
        }

        private void listOf1_Load(object sender, EventArgs e)
        {

        }
    }
}
