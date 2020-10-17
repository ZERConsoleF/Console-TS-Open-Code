using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class TextList : UserControl
    {
        public TextList()
        {
            InitializeComponent();
            SibeInButton = 5;
        }
        /// <summary>
        /// Button默认大小，可以计算TextBox大小
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("Button默认大小，可以计算TextBox大小")]
        public int SizeInButtonWeight { get { return button1.Size.Width; } set { button1.Size = new Size(value, button1.Size.Height); } }
        /// <summary>
        /// Button和TextBox间距大小(要使这个生效，需要调用RefreshSize())
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("Button和TextBox间距大小(要使这个生效，需要调用RefreshSize())")]
        public int SibeInButton { get; set; }
        /// <summary>
        /// 获取或设置控件的文本绑定
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("获取或设置控件的文本绑定")]
        public override string Text { get { return textBox1.Text; } set { textBox1.Text = value; } }

        #region
        /// <summary>
        /// 重置排序
        /// </summary>
        public void RefreshSize()
        {
            textBox1.Location = new Point(0, 0);
            Size s = textBox1.Size;
            int gh = SibeInButton + button1.Size.Width;
        }
        #endregion

        private void TextList_SizeChanged(object sender, EventArgs e)
        {
        }
    }
}
