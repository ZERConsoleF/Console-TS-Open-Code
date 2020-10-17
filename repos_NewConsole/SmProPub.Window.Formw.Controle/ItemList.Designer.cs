namespace SmProPub.Window.Formw.Controle
{
    partial class ItemList
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
            this.TitleList = new System.Windows.Forms.Panel();
            this.SubItemShow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TitleList
            // 
            this.TitleList.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleList.Location = new System.Drawing.Point(0, 0);
            this.TitleList.Name = "TitleList";
            this.TitleList.Size = new System.Drawing.Size(713, 16);
            this.TitleList.TabIndex = 0;
            // 
            // SubItemShow
            // 
            this.SubItemShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubItemShow.Location = new System.Drawing.Point(0, 16);
            this.SubItemShow.Name = "SubItemShow";
            this.SubItemShow.Size = new System.Drawing.Size(713, 394);
            this.SubItemShow.TabIndex = 1;
            // 
            // ItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SubItemShow);
            this.Controls.Add(this.TitleList);
            this.Name = "ItemList";
            this.Size = new System.Drawing.Size(713, 410);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel TitleList;
        public System.Windows.Forms.Panel SubItemShow;
    }
}
