namespace SmProPub.Window.Forms.UsersControl
{
    partial class SetWindowControl
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
            this.ShowPanel = new System.Windows.Forms.Panel();
            this.ShowComment = new System.Windows.Forms.Panel();
            this.ShowList = new SmProPub.Window.Forms.UsersControl.ListVerCs();
            this.SuspendLayout();
            // 
            // ShowPanel
            // 
            this.ShowPanel.AutoScroll = true;
            this.ShowPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShowPanel.Location = new System.Drawing.Point(169, 0);
            this.ShowPanel.Name = "ShowPanel";
            this.ShowPanel.Size = new System.Drawing.Size(489, 576);
            this.ShowPanel.TabIndex = 0;
            // 
            // ShowComment
            // 
            this.ShowComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ShowComment.Location = new System.Drawing.Point(0, 419);
            this.ShowComment.Name = "ShowComment";
            this.ShowComment.Size = new System.Drawing.Size(169, 157);
            this.ShowComment.TabIndex = 1;
            // 
            // ShowList
            // 
            this.ShowList.AutoScroll = true;
            this.ShowList.BackColor = System.Drawing.SystemColors.Control;
            this.ShowList.BorderPanel = System.Windows.Forms.BorderStyle.None;
            this.ShowList.CheckColor = System.Drawing.Color.Empty;
            this.ShowList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowList.Location = new System.Drawing.Point(0, 0);
            this.ShowList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowList.Name = "ShowList";
            this.ShowList.ReadlyCheckColor = System.Drawing.Color.Empty;
            this.ShowList.Size = new System.Drawing.Size(169, 419);
            this.ShowList.TabIndex = 2;
            this.ShowList.ClickItem += new System.SmProPub.Event.ObjectEventArg(this.ShowList_ClickItem);
            // 
            // SetWindowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShowList);
            this.Controls.Add(this.ShowComment);
            this.Controls.Add(this.ShowPanel);
            this.Name = "SetWindowControl";
            this.Size = new System.Drawing.Size(658, 576);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ShowPanel;
        private System.Windows.Forms.Panel ShowComment;
        private ListVerCs ShowList;
    }
}
