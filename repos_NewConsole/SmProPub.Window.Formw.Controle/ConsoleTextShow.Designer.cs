namespace SmProPub.Window.Formw.Controle
{
    partial class ConsoleTextShow
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
            this.Conbcd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Conbcd
            // 
            this.Conbcd.AcceptsReturn = true;
            this.Conbcd.BackColor = System.Drawing.Color.Black;
            this.Conbcd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Conbcd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Conbcd.Location = new System.Drawing.Point(0, 0);
            this.Conbcd.Multiline = true;
            this.Conbcd.Name = "Conbcd";
            this.Conbcd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Conbcd.Size = new System.Drawing.Size(604, 475);
            this.Conbcd.TabIndex = 0;
            this.Conbcd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Conbcd_MouseClick);
            this.Conbcd.TextChanged += new System.EventHandler(this.Conbcd_TextChanged);
            this.Conbcd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Conbcd_KeyDown);
            this.Conbcd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Conbcd_KeyPress);
            // 
            // ConsoleTextShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Conbcd);
            this.Name = "ConsoleTextShow";
            this.Size = new System.Drawing.Size(604, 475);
            this.Load += new System.EventHandler(this.ConsoleTextShow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Conbcd;
    }
}
