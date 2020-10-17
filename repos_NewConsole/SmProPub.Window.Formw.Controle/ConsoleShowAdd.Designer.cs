namespace SmProPub.Window.Formw.Controle
{
    partial class ConsoleShowAdd
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
            this.oldScrollBar1 = new MyControlLibrary.OldScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowLess = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oldScrollBar1
            // 
            this.oldScrollBar1.BackColor = System.Drawing.SystemColors.Control;
            this.oldScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.oldScrollBar1.Location = new System.Drawing.Point(519, 0);
            this.oldScrollBar1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.oldScrollBar1.MouseMoveLU = 10;
            this.oldScrollBar1.Name = "oldScrollBar1";
            this.oldScrollBar1.Rexc = this.panel1;
            this.oldScrollBar1.Size = new System.Drawing.Size(22, 440);
            this.oldScrollBar1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShowLess);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 440);
            this.panel1.TabIndex = 0;
            // 
            // ShowLess
            // 
            this.ShowLess.Location = new System.Drawing.Point(3, 4);
            this.ShowLess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowLess.Name = "ShowLess";
            this.ShowLess.Size = new System.Drawing.Size(535, 432);
            this.ShowLess.TabIndex = 0;
            // 
            // ConsoleShowAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.oldScrollBar1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConsoleShowAdd";
            this.Size = new System.Drawing.Size(541, 440);
            this.Load += new System.EventHandler(this.ConsoleShowAdd_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MyControlLibrary.OldScrollBar oldScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ShowLess;
    }
}
