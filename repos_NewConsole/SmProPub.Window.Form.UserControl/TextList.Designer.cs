namespace SmProPub.Window.Forms.UsersControl
{
    partial class TextList
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listVerCs1 = new SmProPub.Window.Forms.UsersControl.ListVerCs();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 25);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listVerCs1
            // 
            this.listVerCs1.AutoScroll = true;
            this.listVerCs1.BackColor = System.Drawing.Color.White;
            this.listVerCs1.BorderPanel = System.Windows.Forms.BorderStyle.None;
            this.listVerCs1.CheckColor = System.Drawing.Color.Empty;
            this.listVerCs1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listVerCs1.Location = new System.Drawing.Point(3, 35);
            this.listVerCs1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listVerCs1.Name = "listVerCs1";
            this.listVerCs1.ReadlyCheckColor = System.Drawing.Color.Empty;
            this.listVerCs1.Size = new System.Drawing.Size(356, 316);
            this.listVerCs1.TabIndex = 2;
            // 
            // TextList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listVerCs1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "TextList";
            this.Size = new System.Drawing.Size(424, 355);
            this.SizeChanged += new System.EventHandler(this.TextList_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private ListVerCs listVerCs1;
    }
}
