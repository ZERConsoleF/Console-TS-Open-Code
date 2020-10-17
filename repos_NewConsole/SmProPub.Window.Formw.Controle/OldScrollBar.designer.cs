namespace MyControlLibrary
{
    partial class OldScrollBar
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SlideBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SlideBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SlideBar
            // 
            this.SlideBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SlideBar.Location = this.Location;
            this.SlideBar.Margin = new System.Windows.Forms.Padding(4);
            this.SlideBar.Name = "SlideBar";
            this.SlideBar.Size = new System.Drawing.Size(19, 275);
            this.SlideBar.TabIndex = 0;
            this.SlideBar.TabStop = false;
            this.SlideBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SlideBar_MouseDown);
            this.SlideBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SlideBar_MouseMove);
            // 
            // OldScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.SlideBar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OldScrollBar";
            this.Size = new System.Drawing.Size(19, 519);
            this.Load += new System.EventHandler(this.ScrollBar_Load);
            this.SizeChanged += new System.EventHandler(this.ScrollBar_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.SlideBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SlideBar;
    }
}
