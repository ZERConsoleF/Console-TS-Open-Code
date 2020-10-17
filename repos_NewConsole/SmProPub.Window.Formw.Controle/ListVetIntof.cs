using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace SmProPub.Window.Formw.Controle
{
    public partial class ListVetIntof : UserControl
    {
        public ListVetIntof()
        {
            InitializeComponent();
            IfListForZeroSoShowText = "列表为零！";
            IndexSetListDownW = this.Width / 2;
            IndexSetListDownH = 3;
            color = SystemColors.Control;
            JotColor = SystemColors.ControlDark;
            TBackColor = Color.White;
        }
        #region
        [System.ComponentModel.Description("Panel控件列表")]
        public Panel[] Panels { get; set; }
        [System.ComponentModel.Description("如果列表为零，显示")]
        public string IfListForZeroSoShowText { get; set; }
        [System.ComponentModel.Description("每各列表的底线的长度")]
        public int IndexSetListDownW { get; set; }
        [System.ComponentModel.Description("每各列表的底线的宽度")]
        public int IndexSetListDownH { get; set; }
        [System.ComponentModel.Description("每各列表的底线的颜色")]
        public Color color { get; set; }
        [System.ComponentModel.Description("在列表被点击时颜色")]
        public Color JotColor { get; set; }
        [System.ComponentModel.Description("列表背景色")]
        public Color TBackColor { get; set; }
        #endregion

        private void UserControl1_Load(object sender, EventArgs e)
        {
            Invok();
        }
        /// <summary>
        /// 重新定义
        /// </summary>
        public void Invok()
        {
            Controls.Clear();
            if (Panels == null || Panels.Length == 0)
            {
                Label label = new Label();
                label.Name = "lable1";
                label.Text = IfListForZeroSoShowText;
                int a1 = (this.Width - label.Width) / 2;
                int a2 = 1;
                label.Location = new Point(a1, a2);
                label.AutoSize = true;
                Controls.Add(label);
                label.Show();
                return;
            }
            int pointlist = 0;
            foreach (Panel ped in Panels)
            {
                ped.Location = new Point(0, pointlist);
                ped.Width = this.Width;
                ped.BackColor = TBackColor;
                pointlist += ped.Height;
                ped.MouseClick += new System.Windows.Forms.MouseEventHandler(Ped_MouseClick);
                Panel poinjju = new Panel();
                poinjju.Size = new Size(IndexSetListDownW, IndexSetListDownH);
                poinjju.BackColor = color;
                poinjju.Location = new Point(0, pointlist);
                pointlist += IndexSetListDownH;
                Controls.Add(ped);
                Controls.Add(poinjju);
            }
        }
        private void Ped_MouseClick(object sender, MouseEventArgs e)
        {
            Panel yu = (Panel)sender;
            if (uub != null)
            {
                uub.BackColor = TBackColor;
            }
            uub = yu;
            Inisert = yu.Name;
            yu.BackColor = JotColor;
        }
        private Panel uub = null;
        private string Inisert = null;
        /// <summary>
        /// 获取点击的控件Name
        /// </summary>
        /// <returns></returns>
        public string GetClickString()
        {
            return Inisert;
        }
        /// <summary>
        /// 获取点击的控件Panel
        /// </summary>
        /// <returns></returns>
        public Panel GetClickPanel()
        {
            return uub;
        }
        /// <summary>
        /// 清除选择
        /// </summary>
        public void ClearInvok()
        {
            if (uub == null)
                return;
            uub.BackColor = TBackColor;
            uub = null;
            Inisert = null;
        }

        private void ListVetIntof_MouseClick(object sender, MouseEventArgs e)
        {
            ClearInvok();
        }
    }
}
