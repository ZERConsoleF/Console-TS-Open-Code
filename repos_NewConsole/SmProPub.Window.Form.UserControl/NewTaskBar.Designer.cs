namespace SmProPub.Window.Forms.UsersControl
{
    partial class NewTaskBar
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
            this.ShowLes_RightButton = new System.Windows.Forms.Button();
            this.ShowLes_LeftButton = new System.Windows.Forms.Button();
            this.ShowLsf = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ShowLes_RightButton
            // 
            this.ShowLes_RightButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShowLes_RightButton.Enabled = false;
            this.ShowLes_RightButton.FlatAppearance.BorderSize = 0;
            this.ShowLes_RightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowLes_RightButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowLes_RightButton.Location = new System.Drawing.Point(929, 0);
            this.ShowLes_RightButton.Name = "ShowLes_RightButton";
            this.ShowLes_RightButton.Size = new System.Drawing.Size(27, 30);
            this.ShowLes_RightButton.TabIndex = 3;
            this.ShowLes_RightButton.Text = ">";
            this.ShowLes_RightButton.UseVisualStyleBackColor = true;
            this.ShowLes_RightButton.Click += new System.EventHandler(this.ShowLes_RightButton_Click);
            // 
            // ShowLes_LeftButton
            // 
            this.ShowLes_LeftButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShowLes_LeftButton.Enabled = false;
            this.ShowLes_LeftButton.FlatAppearance.BorderSize = 0;
            this.ShowLes_LeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowLes_LeftButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowLes_LeftButton.Location = new System.Drawing.Point(902, 0);
            this.ShowLes_LeftButton.Name = "ShowLes_LeftButton";
            this.ShowLes_LeftButton.Size = new System.Drawing.Size(27, 30);
            this.ShowLes_LeftButton.TabIndex = 4;
            this.ShowLes_LeftButton.Text = "<";
            this.ShowLes_LeftButton.UseVisualStyleBackColor = true;
            this.ShowLes_LeftButton.Click += new System.EventHandler(this.ShowLes_LeftButton_Click);
            // 
            // ShowLsf
            // 
            this.ShowLsf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowLsf.Location = new System.Drawing.Point(0, 0);
            this.ShowLsf.Name = "ShowLsf";
            this.ShowLsf.Size = new System.Drawing.Size(902, 30);
            this.ShowLsf.TabIndex = 5;
            // 
            // NewTaskBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ShowLsf);
            this.Controls.Add(this.ShowLes_LeftButton);
            this.Controls.Add(this.ShowLes_RightButton);
            this.Name = "NewTaskBar";
            this.Size = new System.Drawing.Size(956, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowLes_RightButton;
        private System.Windows.Forms.Button ShowLes_LeftButton;
        private System.Windows.Forms.Panel ShowLsf;
    }
}
