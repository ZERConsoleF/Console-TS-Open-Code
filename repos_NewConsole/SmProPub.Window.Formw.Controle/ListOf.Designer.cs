namespace SmProPub.Window.Formw.Controle
{
    partial class ListOf
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
            this.ListOc = new System.Windows.Forms.Panel();
            this.oldWScrollBar1 = new MyControlLibrary.OldWScrollBar();
            this.listSocer1 = new SmProPub.Window.Formw.Controle.ListSocer();
            this.oldScrollBar1 = new MyControlLibrary.OldScrollBar();
            this.SuspendLayout();
            // 
            // ListOc
            // 
            this.ListOc.Location = new System.Drawing.Point(0, 0);
            this.ListOc.Name = "ListOc";
            this.ListOc.Size = new System.Drawing.Size(556, 20);
            this.ListOc.TabIndex = 1;
            // 
            // oldWScrollBar1
            // 
            this.oldWScrollBar1.BackColor = System.Drawing.SystemColors.Control;
            this.oldWScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oldWScrollBar1.Location = new System.Drawing.Point(0, 452);
            this.oldWScrollBar1.Margin = new System.Windows.Forms.Padding(4);
            this.oldWScrollBar1.Name = "oldWScrollBar1";
            this.oldWScrollBar1.Rexc = this.listSocer1;
            this.oldWScrollBar1.Size = new System.Drawing.Size(559, 22);
            this.oldWScrollBar1.TabIndex = 3;
            // 
            // listSocer1
            // 
            this.listSocer1.BackColor = System.Drawing.Color.White;
            this.listSocer1.BackVied = System.Drawing.Color.White;
            this.listSocer1.ListName = "list";
            this.listSocer1.Location = new System.Drawing.Point(0, 20);
            this.listSocer1.LSFWH = 0;
            this.listSocer1.Name = "listSocer1";
            this.listSocer1.Size = new System.Drawing.Size(559, 437);
            this.listSocer1.TabIndex = 0;
            this.listSocer1.VCLOButO = new System.Drawing.Size(16, 16);
            this.listSocer1.Vied = System.Drawing.SystemColors.GradientActiveCaption;
            this.listSocer1.ViedC = System.Drawing.SystemColors.ActiveCaption;
            // 
            // oldScrollBar1
            // 
            this.oldScrollBar1.BackColor = System.Drawing.SystemColors.Control;
            this.oldScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.oldScrollBar1.Location = new System.Drawing.Point(559, 0);
            this.oldScrollBar1.Margin = new System.Windows.Forms.Padding(4);
            this.oldScrollBar1.MouseMoveLU = 10;
            this.oldScrollBar1.Name = "oldScrollBar1";
            this.oldScrollBar1.Rexc = this.listSocer1;
            this.oldScrollBar1.Size = new System.Drawing.Size(23, 474);
            this.oldScrollBar1.TabIndex = 2;
            // 
            // ListOf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oldWScrollBar1);
            this.Controls.Add(this.oldScrollBar1);
            this.Controls.Add(this.ListOc);
            this.Controls.Add(this.listSocer1);
            this.Name = "ListOf";
            this.Size = new System.Drawing.Size(582, 474);
            this.Load += new System.EventHandler(this.ListOf_Load);
            this.SizeChanged += new System.EventHandler(this.ListOf_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private MyControlLibrary.OldScrollBar oldScrollBar1;
        public System.Windows.Forms.Panel ListOc;
        public ListSocer listSocer1;
        private MyControlLibrary.OldWScrollBar oldWScrollBar1;
    }
}
