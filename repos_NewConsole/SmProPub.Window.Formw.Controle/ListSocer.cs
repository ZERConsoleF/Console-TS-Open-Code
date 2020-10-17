using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProPub.Window.Formw.Controle
{
    public partial class ListSocer : UserControl
    {
        private string j1 = "System.IO.LP.List.Control.From?DFMemorySd";
        public ListSocer()
        {
            InitializeComponent();
            VCLOButO = new Size(32, 32);
            ListName = "gt";
            BackVied = SystemColors.Control;
            Vied = SystemColors.ControlText;
            ViedC = SystemColors.Control;
            pvo.Name = j1;
        }
        #region
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表的宽度(如果为列表则Width忽视)")]
        public Size VCLOButO { get; set; }
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表的形态,list为列表,gt为表格")]
        public string ListName { get; set; }
        /*
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表的标题名(在list时有效)")]
        public ListNamesuze[] LcvCat { get; set; }
        */
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表控件(在list时如果未达到程序标题的list设置则引发错误)")]
        public Panel[] LSFCatMkdirTy { get; set; }
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表控件间隔(List自动为列表间隙)")]
        public int LSFWH { get; set; }
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表控件背景")]
        public Color BackVied { get; set; }
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表控件预点背景")]
        public Color Vied { get; set; }
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置列表控件点击背景")]
        public Color ViedC { get; set; }
        #endregion

        private void ListVeled_Click(object sender, EventArgs e)
        {

        }
        public void InvokLt()
        {
            this.Controls.Clear();
            if (LSFCatMkdirTy == null)
            {
                Label ls = new Label();
                ls.AutoSize = true;
                ls.Text = "列表为空";
                ls.Location = new Point(2, 2);

                this.Controls.Add(ls);
                ls.Show();
                return;
            }
            if (ListName.ToLower() == "gt")
            {
                Size st = this.Size;

                int w = LSFWH;

                int dw = w;
                int dh = w;

                foreach (Panel lsf in LSFCatMkdirTy)
                {
                    Point pt = new Point(dw, dh);
                    lsf.Location = pt;
                    /*
                    lsf.MouseMove += new MouseEventHandler(Pa_Lt);
                    lsf.MouseLeave += new EventHandler(Pa_Lv);
                    lsf.Click += new EventHandler(Pa_Lc);
                    lsf.Size = VCLOButO;
                    ScMindert(lsf);
                    */
                    pvo = new Panel();
                    pvo.Name = j1 + "." + lsf.Name;
                    pvo.Size = lsf.Size;
                    pvo.Location = pt;
                    pvo.BackColor = Color.Transparent;
                    pvo.MouseMove += new MouseEventHandler(Pa_Lt);
                    pvo.MouseLeave += new EventHandler(Pa_Lv);
                    pvo.Click += new EventHandler(Pa_Lc);

                    lsf.BackColor = BackVied;

                    dw += lsf.Size.Width + w;

                    if (dw + lsf.Size.Width > this.Size.Width)
                    {
                        dw = w;
                        dh += lsf.Size.Height + w;
                    }



                    this.Controls.Add(lsf);
                    this.Controls.Add(pvo);
                    lsf.Show();
                    pvo.Show();
                    //ScColor(lsf, lsf.BackColor);
                }
            }
            if (ListName.ToLower() == "list")
            {
                Size st = this.Size;

                int w = LSFWH;

                int dh = w;

                foreach (Panel lsf in LSFCatMkdirTy)
                {
                    Point pt = new Point(0, dh);
                    /*
                    lsf.MouseMove += new MouseEventHandler(Pa_Lt);
                    lsf.MouseLeave += new EventHandler(Pa_Lv);
                    lsf.Click += new EventHandler(Pa_Lc);
                    lsf.Size = VCLOButO;
                    ScMindert(lsf);
                    */
                    pvo = new Panel();
                    pvo.Name = j1 + "." + lsf.Name;
                    pvo.Size = lsf.Size;
                    pvo.Location = pt;
                    //pvo.BackColor = Color.Transparent;
                    pvo.MouseMove += new MouseEventHandler(Pa_Lt);
                    pvo.MouseLeave += new EventHandler(Pa_Lv);
                    pvo.Click += new EventHandler(Pa_Lc);
                    
                    dh += lsf.Size.Height + w;

                    lsf.BackColor = BackVied;

                    this.Controls.Add(lsf);
                    this.Controls.Add(pvo);
                    lsf.Show();
                    pvo.Show();
                    //ScColor(lsf, lsf.BackColor);
                }
            }
        }

        private void ScMindert(Control cy)
        {
            foreach (Control st in cy.Controls)
            {
                /*
                st.MouseMove += new MouseEventHandler(Pa_Lt);
                st.MouseLeave += new EventHandler(Pa_Lv);
                st.Click += new EventHandler(Pa_Lc);
                */
                st.BackColor = Color.Transparent;
                ScMindert(st);
            }
        }

        private void ScColor(Control cp, Color ct)
        {
            foreach (Control st in cp.Controls)
            {
                st.BackColor = ct;
                ScColor(st, ct);
            }
        }

        private void Pa_Lt(object sender, MouseEventArgs e)
        {
            Control p = (Control)sender;
            p.BackColor = Vied;
            //ScColor(p, p.BackColor);
            //pvo = p;
        }
        private void Pa_Lv(object sender, EventArgs e)
        {
            Control p = (Control)sender;

            p.BackColor = BackVied;
            if (pcv.Name == p.Name)
                p.BackColor = ViedC;
            //ScColor(p, p.BackColor);
            //pvo = p;
        }
        private void Pa_Lc(object sender, EventArgs e)
        {
            pcv.BackColor = BackVied;
            Control p = (Control)sender;
            p.BackColor = ViedC;
            pcv = p;
            if (RkDir != null)
                RkDir(p);
            //ScColor(p, p.BackColor);
            //pvo = p;
        }

        /*
        private void lPa_Lt(object sender, MouseEventArgs e)
        {
            Control p = (Control)sender;
            p.BackColor = Vied;
            //ScColor(p, p.BackColor);
        }
        private void lPa_Lv(object sender, EventArgs e)
        {
            Control p = (Control)sender;

            p.BackColor = BackVied;
            if (pcv.Name == p.Name)
                p.BackColor = ViedC;
            //ScColor(p, p.BackColor);
        }
        private void lPa_Lc(object sender, EventArgs e)
        {
            pcv.BackColor = BackVied;
            Control p = (Control)sender;
            p.BackColor = ViedC;
            pcv = p;
            if (RkDir != null)
                RkDir(p);
            //ScColor(p, p.BackColor);
        }
        */

        Control pcv = new Control();
        Panel pvo = new Panel();
        /// <summary>
        /// 获取点击时的列表数,如果没有则返回-1;
        /// </summary>
        /// <returns></returns>
        public int returnClickPa()
        {
            int x = 0;
            foreach (Control lsf in LSFCatMkdirTy)
            {
                if (lsf == pcv)
                    return x;

                x++;
            }
            return -1;
        }
        /// <summary>
        /// 清空选择
        /// </summary>
        public void ClearList()
        {
            foreach (Control lsf in LSFCatMkdirTy)
            {
                lsf.BackColor = BackVied;
            }
            pcv = new Control();
        }
        public void ClearAll()
        {
            ClearList();
            LSFCatMkdirTy = new Panel[0];
            InvokLt();
        }
        /// <summary>
        /// 事件注册1
        /// </summary>
        /// <param name="sender"></param>
        public delegate void ElList(object sender);
        /// <summary>
        /// 获取点击列表
        /// </summary>
        [System.ComponentModel.Description("获取点击列表")]
        public event ElList RkDir;

        private void ListSocer_Load(object sender, EventArgs e)
        {
            InvokLt();
        }
    }
    public class ListNamesuze
    {
        public ListNamesuze()
        {
            col = SystemColors.Control;
            colt = Color.Black;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 大小(Heigh自动忽略)
        /// </summary>
        public Size st { get; set; }
        /// <summary>
        /// 控件颜色
        /// </summary>
        public Color col { get; set; }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color colt { get; set; }
    }
}
