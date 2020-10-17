namespace SmProPub.Window.Forms.UsersControl
{
    partial class LessInForm
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
            this.Inshotat = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Inshotat.SuspendLayout();
            this.SuspendLayout();
            // 
            // Inshotat
            // 
            this.Inshotat.Controls.Add(this.panel1);
            this.Inshotat.Location = new System.Drawing.Point(3, 3);
            this.Inshotat.Name = "Inshotat";
            this.Inshotat.Size = new System.Drawing.Size(532, 437);
            this.Inshotat.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // LessInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Inshotat);
            this.Name = "LessInForm";
            this.Size = new System.Drawing.Size(538, 443);
            this.SizeChanged += new System.EventHandler(this.LessInForm_SizeChanged);
            this.Inshotat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Inshotat;
        private System.Windows.Forms.Panel panel1;
    }
}
