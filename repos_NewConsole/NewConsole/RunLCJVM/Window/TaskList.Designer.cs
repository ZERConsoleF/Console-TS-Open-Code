namespace RunLCJVM.Window
{
    partial class TaskList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoLp = new System.Windows.Forms.Label();
            this.NameTitle = new System.Windows.Forms.Label();
            this.itemList1 = new SmProPub.Window.Formw.Controle.ItemList();
            this.oldScrollBar1 = new MyControlLibrary.OldScrollBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.InfoLp);
            this.panel1.Controls.Add(this.NameTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 1;
            // 
            // InfoLp
            // 
            this.InfoLp.AutoSize = true;
            this.InfoLp.Location = new System.Drawing.Point(155, 24);
            this.InfoLp.Name = "InfoLp";
            this.InfoLp.Size = new System.Drawing.Size(23, 15);
            this.InfoLp.TabIndex = 1;
            this.InfoLp.Text = "NC";
            // 
            // NameTitle
            // 
            this.NameTitle.AutoSize = true;
            this.NameTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameTitle.Location = new System.Drawing.Point(12, 5);
            this.NameTitle.Name = "NameTitle";
            this.NameTitle.Size = new System.Drawing.Size(137, 40);
            this.NameTitle.TabIndex = 0;
            this.NameTitle.Text = "任务视图";
            // 
            // itemList1
            // 
            this.itemList1.BackColor = System.Drawing.Color.White;
            this.itemList1.BoredColor = System.Drawing.Color.Empty;
            this.itemList1.ClickColor = System.Drawing.Color.Teal;
            this.itemList1.ClickOutColor = System.Drawing.Color.Turquoise;
            this.itemList1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemList1.Location = new System.Drawing.Point(0, 48);
            this.itemList1.Name = "itemList1";
            this.itemList1.Size = new System.Drawing.Size(800, 402);
            this.itemList1.TabIndex = 2;
            // 
            // oldScrollBar1
            // 
            this.oldScrollBar1.BackColor = System.Drawing.SystemColors.Control;
            this.oldScrollBar1.Location = new System.Drawing.Point(782, 48);
            this.oldScrollBar1.Margin = new System.Windows.Forms.Padding(4);
            this.oldScrollBar1.MouseMoveLU = 10;
            this.oldScrollBar1.Name = "oldScrollBar1";
            this.oldScrollBar1.Size = new System.Drawing.Size(18, 402);
            this.oldScrollBar1.TabIndex = 3;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.oldScrollBar1);
            this.Controls.Add(this.itemList1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskList_FormClosing);
            this.Load += new System.EventHandler(this.TaskList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NameTitle;
        private System.Windows.Forms.Label InfoLp;
        private SmProPub.Window.Formw.Controle.ItemList itemList1;
        private MyControlLibrary.OldScrollBar oldScrollBar1;
    }
}