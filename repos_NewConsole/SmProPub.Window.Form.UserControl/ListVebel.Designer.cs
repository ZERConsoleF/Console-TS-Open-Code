namespace SmProPub.Window.Forms.UsersControl
{
    partial class ListVebel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListVebel));
            this.ShowLes = new System.Windows.Forms.Panel();
            this.ShowAll = new System.Windows.Forms.Panel();
            this.newTaskBar1 = new SmProPub.Window.Forms.UsersControl.NewTaskBar();
            this.ShowLes.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowLes
            // 
            this.ShowLes.Controls.Add(this.newTaskBar1);
            this.ShowLes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ShowLes.Location = new System.Drawing.Point(0, 425);
            this.ShowLes.Name = "ShowLes";
            this.ShowLes.Size = new System.Drawing.Size(731, 27);
            this.ShowLes.TabIndex = 0;
            // 
            // ShowAll
            // 
            this.ShowAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowAll.Location = new System.Drawing.Point(0, 0);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(731, 425);
            this.ShowAll.TabIndex = 1;
            // 
            // newTaskBar1
            // 
            this.newTaskBar1.BackColor = System.Drawing.Color.White;
            this.newTaskBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newTaskBar1.FortBack = System.Drawing.Color.Empty;
            this.newTaskBar1.FortFop = System.Drawing.Color.Empty;
            this.newTaskBar1.Location = new System.Drawing.Point(0, 0);
            this.newTaskBar1.Name = "newTaskBar1";
            this.newTaskBar1.obv = ((System.Collections.Generic.List<object>)(resources.GetObject("newTaskBar1.obv")));
            this.newTaskBar1.Size = new System.Drawing.Size(731, 27);
            this.newTaskBar1.TabIndex = 0;
            this.newTaskBar1.ClickEvent += new System.SmProPub.Event.ObjectEventArg(this.newTaskBar1_ClickEvent);
            // 
            // ListVebel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.ShowLes);
            this.Name = "ListVebel";
            this.Size = new System.Drawing.Size(731, 452);
            this.ShowLes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ShowLes;
        private System.Windows.Forms.Panel ShowAll;
        private NewTaskBar newTaskBar1;
    }
}
