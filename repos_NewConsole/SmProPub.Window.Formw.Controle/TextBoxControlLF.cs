using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmProPub;
using System.Runtime.InteropServices;

namespace SmProPub.Window.Formw.Controle
{
    [ToolboxBitmap(typeof(TextBox))]
    public partial class TextBoxControlLF : UserControl
    {
        public TextBoxControlLF()
        {
            InitializeComponent();
            LoctionText = new Point(2, 2);
            font = this.Font;
            SizeText = new Size(0, 0);
        }
        private string AdTxt = "";
        private string WaterText = "";

        private List<Control> txt = new List<Control>();
        #region
        /// <summary>
        /// 设置文本
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置文本")]
        public string AText
        {
            get { return AdTxt; }
            set { AdTxt = value; InvokText(); }
        }
        /// <summary>
        /// 设置水印
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置水印")]
        public string AWaterText
        {
            get { return WaterText; }
            set { WaterText = value; InvokWaterText(); }
        }
        /// <summary>
        /// 设置文本的字体
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置文本的字体")]
        public Font font { get; set; }
        /// <summary>
        /// 设置间隔
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置间隔")]
        public Point LoctionText { get; set; }
        /// <summary>
        /// 设置文本显示的大小统一(0, 0为自动大小)
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置文本显示的大小统一")]
        public Size SizeText { get; set; }
        /// <summary>
        /// 设置文本选择时的背景
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Text")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("设置文本选择时的背景")]
        public Color TextSelectColor { get; set; }
        #endregion

        /// <summary>
        /// 重载Text文本(一般自动，如果没有设置请手动引用此方法)
        /// </summary>
        public void InvokText()
        {
            if (AdTxt == null)
            {
                SmException er = new SmException();
                er.CodeLine = "0xc000005;0xc000007;mov 0t,1c;mov 3c,10";
                er.Debug = "Text在内存它不能为null";
                er.FailWhy = "在 Mov.(" + er.CodeLine + ") 中的引用指令出错,GC回收！";
                er.message = "引用了意想不到的错误指令在 B5 字节";
                throw er.RunSmProEx();
            }
            InvokDt(this.ForeColor);
        }
        /// <summary>
        /// 重载水印文本(一般自动，如果没有设置请手动引用此方法)
        /// </summary>
        public void InvokWaterText()
        {
            if (AdTxt == null)
            {
                SmException er = new SmException();
                er.CodeLine = "0xc000005;0xc000007;mov 0t,9c;mov 3a,5b";
                er.Debug = "WaterText在内存它不能为null";
                er.FailWhy = "在 Mov.(" + er.CodeLine + ") 中的引用指令出错,GC回收！";
                er.message = "引用了意想不到的错误指令在 A6 字节";
                throw er.RunSmProEx();
            }
            InvokDt(SystemColors.ButtonFace);
        }

        private void InvokDt(Color back)
        {
            txt.Clear();
            int xcb = 0;
            int bx = LoctionText.X;
            int by = LoctionText.Y;

            FontStyle fontStyle = FontStyle.Regular;
            float fontSize = 0;
            int lblWidth = 0;

            foreach (char ch in AText)
            {
                Label lc = new Label();
                lc.Name = "wl." + xcb;
                lc.Font = font;

                if (ch == '\n')
                {
                    bx = LoctionText.X;
                    by += lc.Height;
                }
                else
                {
                    lc.Text = ch.ToString();
                    if (SizeText.Width == 0 && SizeText.Height == 0)
                    {
                        lblWidth = lc.Width;
                        fontSize = lc.Font.Size;
                        fontStyle = lc.Font.Style;

                        string content = lc.Text.Trim();
                        FontFamily ff = new FontFamily(lc.Font.Name);
                        lc.Font = new Font(ff, fontSize, fontStyle, GraphicsUnit.World);
                        float size = lc.Font.Size;

                        //lc.AutoSize = true;
                        lc.Text = content;
                        while (lc.Width > lblWidth)
                        {
                            size -= 0.25F;
                            lc.Font = new Font(ff, size, fontStyle, GraphicsUnit.World);
                        }
                        lc.AutoSize = false;
                        lc.Width = lblWidth;
                    }
                    else
                        lc.Size = SizeText;
                }

                if (bx + LoctionText.X > this.Width)
                {
                    bx = LoctionText.X;
                    by += lc.Height;
                }
                lc.Location = new Point(bx, by);
                bx += lc.Width;

                lc.BackColor = BackColor;
                lc.ForeColor = back;
                lc.MouseMove += new MouseEventHandler(TextBoxControlLF_MouseMove);

                txt.Add(lc);
                this.Controls.Add(lc);
                lc.Show();

                xcb++;
            }
        }

        private void TextBoxControlLF_Load(object sender, EventArgs e)
        {
            
        }

        private void TextBoxControlLF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void TextBoxControlLF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }
    }
}
