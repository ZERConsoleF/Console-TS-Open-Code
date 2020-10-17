namespace SmProPub.Window.Forms.UsersControl
{
    partial class ConsoleShowWindow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ShowText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.paseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowText
            // 
            this.ShowText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShowText.ContextMenuStrip = this.contextMenuStrip1;
            this.ShowText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowText.Location = new System.Drawing.Point(0, 0);
            this.ShowText.Name = "ShowText";
            this.ShowText.ReadOnly = true;
            this.ShowText.Size = new System.Drawing.Size(609, 472);
            this.ShowText.TabIndex = 0;
            this.ShowText.Text = "";
            this.ShowText.TextChanged += new System.EventHandler(this.ShowText_TextChanged);
            this.ShowText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShowText_KeyDown);
            this.ShowText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShowText_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paseToolStripMenuItem,
            this.markToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 80);
            // 
            // paseToolStripMenuItem
            // 
            this.paseToolStripMenuItem.Name = "paseToolStripMenuItem";
            this.paseToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.paseToolStripMenuItem.Text = "Pase";
            this.paseToolStripMenuItem.Click += new System.EventHandler(this.paseToolStripMenuItem_Click);
            // 
            // markToolStripMenuItem
            // 
            this.markToolStripMenuItem.Name = "markToolStripMenuItem";
            this.markToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.markToolStripMenuItem.Text = "Mark - Copy";
            this.markToolStripMenuItem.Click += new System.EventHandler(this.markToolStripMenuItem_Click);
            // 
            // ConsoleShowWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.ShowText);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "ConsoleShowWindow";
            this.Size = new System.Drawing.Size(609, 472);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox ShowText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem paseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markToolStripMenuItem;
    }
}
