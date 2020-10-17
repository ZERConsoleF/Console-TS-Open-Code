using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SmProPub.Window.Formw.Controle
{
    public partial class ConsoleTextShow : UserControl
    {
        public ConsoleTextShow()
        {
            InitializeComponent();
            this.ForeColor = Color.Green;
            KeepReadKey = false;
        }
        /// <summary>
        /// 获取一个值，是否读入字符
        /// </summary>
        public bool ReadKey = false;
        string txt = "";
        bool ReadTextForBytes = false;
        /// <summary>
        /// 获取一个值，是否有输出引发
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Locked Control")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("获取一个值，是否有输出引发(无法编辑)")]
        public bool ReadTextIf { get { return ReadTextForBytes; } }
        /// <summary>
        /// 获取一个值，在事件APassGet引发时输出文本(在此之后有100毫秒缓冲，然后清除)
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Locked Control")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("获取一个值，在事件APassGet引发时输出文本(在此之后有100毫秒缓冲，然后清除)(无法编辑)")]
        public string ReadTextReturn { get { return txt; } }

        int lfg = 0;

        public delegate void KeyChatPass(string arg);
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Event Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("当敲下回车时输出文本")]
        public event KeyChatPass APassGet;
        /// <summary>
        /// 当敲下回车时是否继续读写
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Event Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("当敲下回车时是否继续读写")]
        public bool KeepReadKey { get; set; }

        /// <summary>
        /// 写入控制
        /// </summary>
        /// <param name="st"></param>
        /// <param name="obj"></param>
        public void Console_Write(string st,params object[] obj)
        {
            try
            {
                this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
                string hu = string.Format(st, obj);
                this.Conbcd.Text += hu;
                this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
            }
            catch
            (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        /// <summary>
        /// 写入控制
        /// </summary>
        /// <param name="st"></param>
        /// <param name="obj"></param>
        public void Console_WriteLine(string st, params object[] obj)
        {
            this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
            string hu = string.Format(st, obj);
            this.Conbcd.Text += hu + "\r\n";
            this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
        }
        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        public void Console_DeleteText()
        {
            /*
            if (txt.Length > 0)
            {
                
                string ui = "";
                for (int xc = 0; xc < txt.Length - 1; xc++)
                {
                    ui += txt[xc];
                }
                txt = ui;
                Console.WriteLine(txt);
                string yu = this.Conbcd.Text;
                ui = "";
                for (int xc = 0; xc < yu.Length - 1; xc++)
                {
                    ui += yu[xc];
                }
                this.Conbcd.Text = ui;
                this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
                
            }
            */

            if (lfg > 0)
            {
                 string ui = "";
                string yu = this.Conbcd.Text;
                ui = "";
                for (int xc = 0; xc < yu.Length - 1; xc++)
                {
                    ui += yu[xc];
                }
                this.Conbcd.Text = ui;
                this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
                lfg--;
            }
        }

        private void Conbcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                while (lfg > 0)
                {
                    Console_DeleteText();
                }

                e.Handled = true;
            }
        }

        private void Conbcd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ReadKey)
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    /*
                    if (txt.Length <= 0)
                        e.Handled = true;
                    else
                    {
                        if (txt.Length > 0)
                        {
                            string ui = "";
                            for (int xc = 0; xc < txt.Length - 1; xc++)
                            {
                                ui += txt[xc];
                            }
                            txt = ui;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    */
                    if (lfg <= 0)
                        e.Handled = true;
                    else
                        lfg--;
                }
                else if (chagetext)
                {
                    //txt += this.Conbcd.Text[this.Conbcd.Text.Length - 1];
                    lfg++;
                    chagetext = false;
                }
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
                    e.Handled = true;

                    int ct = this.Conbcd.Text.Length - lfg;

                    txt = "";

                    for (int xcv = ct + 1; xcv < this.Conbcd.Text.Length; xcv++)
                    {
                        txt += this.Conbcd.Text[xcv];
                    }

                    this.Conbcd.Text += "\r\n";
                    this.Conbcd.SelectionStart = this.Conbcd.Text.Length;

                    ReadTextForBytes = true;
                    if (APassGet != null)
                        APassGet(txt);
                    Thread.Sleep(100);
                    ReadTextForBytes = false;
                    lfg = 0;

                    txt = "";
                    ReadKey = KeepReadKey;
                }
                this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
            }
            else
            {
                e.Handled = true;
            }
            this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
        }
        private bool chagetext = false;

        private void Conbcd_TextChanged(object sender, EventArgs e)
        {
            chagetext = true;
            this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
        }

        private void Conbcd_MouseClick(object sender, MouseEventArgs e)
        {
            this.Conbcd.SelectionStart = this.Conbcd.Text.Length;
        }

        private void ConsoleTextShow_Load(object sender, EventArgs e)
        {
            this.Conbcd.Font = this.Font;
            this.Conbcd.ForeColor = this.ForeColor;
            this.Conbcd.BackColor = this.BackColor;
        }
    }
}
