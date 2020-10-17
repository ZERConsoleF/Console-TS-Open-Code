using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmProPub.Text;

namespace SmProPub.Window.Formw.Controle
{
    public partial class ConsoleShowAdd : UserControl
    {
        public ConsoleShowAdd()
        {
            InitializeComponent();
            ArrawShow = true;
            IntInd = 3;
        }

        private void ConsoleShowAdd_Load(object sender, EventArgs e)
        {

        }
        #region
        /// <summary>
        /// 是否显示光标的位置
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appinstion")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("是否显示光标的位置")]
        public bool ArrawShow { get; set; }

        /// <summary>
        /// 文本的间隔长度
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appinstion")]
        [System.ComponentModel.DefaultValue(3)]
        [System.ComponentModel.Description("文本的间隔长度")]
        public int IntInd { get; set; }
        #endregion

        int y = 0;
        List<Control> tcad = new List<Control>();

        public void ConsoleWrite(string str, params object[] obj)
        {
            if (str == null)
            {
                SmException st = new SmException();
                st.Debug = "The 'str' is Null";
                st.FailWhy = "NULL值";
                st.CodeLine = "mov 58,0t;mov 64,1t,0xc0000001";
                st.message = "在执行ConsoleWrite写入时出现错误";
                throw st.RunSmProEx();
            }
            string rt = string.Format(str, obj);

            string[] ur = rt.Split('\n');

            string[] dr = rt.Split('\b');


            if (ur.Length  >= 1)
            {
                foreach (string it in ur)
                {
                    Panel pc = new Panel();
                    pc.Name = "panel." + tcad.Count;
                    pc.Paint += Publc_Paint;


                    pc.Location = new Point(IntInd, y);
                    pc.AutoSize = true;
                    Label ty = new Label();
                    ty.Name = "label." + tcad.Count;
                    ty.Text = it;

                    ShowLess.Controls.Add(pc);
                    tcad.Add(pc);
                    pc.Show();
                    y += pc.Height + IntInd;
                }
            }
            if (dr.Length >= 1)
            {
                foreach (string it in ur)
                {
                    if (tcad.Count > 0)
                    {
                        Control ipo = tcad[tcad.Count - 1];
                        Label oc = LabelSp(ipo);
                        if (oc == null)
                            return;
                        string fpw = oc.Text;
                        string sp = new string(SIBB<char>.DeleteLastOB(fpw.ToCharArray()));
                        oc.Text = sp;
                        ipo.Refresh();
                    }
                }
            }
        }
        private Label LabelSp(Control ct)
        {
            foreach (Control cy in ct.Controls)
            {
                if (cy is Label)
                {
                    return (Label)cy;
                }
            }
            return null;
        }
        public void ConsoleWriteLine(string str, params object[] obj)
        {
            ConsoleWrite(str + "\n",obj);
        }
        private void Publc_Paint(object sender, PaintEventArgs e)
        {
            Label ty = LabelSp((Control)sender);
            if (ty == null)
            {
                return;
            }

            Graphics text = e.Graphics;


            Brush brush = new SolidBrush(this.ForeColor);
            Font font = this.Font;

            text.DrawString(ty.Text, font, brush, 0, 0);
            ShowLess.Location = new Point(0, 0);
            ShowLess.AutoSize = true;
        }
    }
}
