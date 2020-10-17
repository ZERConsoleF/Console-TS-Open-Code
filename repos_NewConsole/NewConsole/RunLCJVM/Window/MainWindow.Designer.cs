using ConsoleG.Core.com;

namespace RunLCJVM.Window
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.TitlePan = new System.Windows.Forms.Panel();
            this.MinButton = new System.Windows.Forms.Button();
            this.MaxButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.menusp = new System.Windows.Forms.MenuStrip();
            this.IconT = new System.Windows.Forms.PictureBox();
            this.UnDownPan = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ShowCommentPan = new System.Windows.Forms.Panel();
            this.CommentShow = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ShowTaskbarPan = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TaskButtonbarShow = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TaskListButton = new System.Windows.Forms.Button();
            this.MainShow = new System.Windows.Forms.Panel();
            this.TitlePan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconT)).BeginInit();
            this.UnDownPan.SuspendLayout();
            this.panel6.SuspendLayout();
            this.ShowCommentPan.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePan
            // 
            this.TitlePan.Controls.Add(this.MinButton);
            this.TitlePan.Controls.Add(this.MaxButton);
            this.TitlePan.Controls.Add(this.CloseButton);
            this.TitlePan.Controls.Add(this.menusp);
            this.TitlePan.Controls.Add(this.IconT);
            this.TitlePan.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePan.Location = new System.Drawing.Point(0, 0);
            this.TitlePan.Name = "TitlePan";
            this.TitlePan.Size = new System.Drawing.Size(1439, 39);
            this.TitlePan.TabIndex = 0;
            this.TitlePan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseDown);
            this.TitlePan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseMove);
            // 
            // MinButton
            // 
            this.MinButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinButton.FlatAppearance.BorderSize = 0;
            this.MinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinButton.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinButton.Location = new System.Drawing.Point(1313, 0);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(42, 39);
            this.MinButton.TabIndex = 4;
            this.MinButton.Text = "-";
            this.MinButton.UseVisualStyleBackColor = true;
            this.MinButton.Click += new System.EventHandler(this.MinButton_Click);
            // 
            // MaxButton
            // 
            this.MaxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaxButton.FlatAppearance.BorderSize = 0;
            this.MaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaxButton.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaxButton.Location = new System.Drawing.Point(1355, 0);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(42, 39);
            this.MaxButton.TabIndex = 3;
            this.MaxButton.Text = "*";
            this.MaxButton.UseVisualStyleBackColor = true;
            this.MaxButton.Click += new System.EventHandler(this.MaxButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseButton.Location = new System.Drawing.Point(1397, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(42, 39);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // menusp
            // 
            this.menusp.Dock = System.Windows.Forms.DockStyle.None;
            this.menusp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menusp.Location = new System.Drawing.Point(38, 5);
            this.menusp.Name = "menusp";
            this.menusp.Size = new System.Drawing.Size(202, 24);
            this.menusp.TabIndex = 1;
            this.menusp.Text = "menuStrip1";
            // 
            // IconT
            // 
            this.IconT.Image = ((System.Drawing.Image)(resources.GetObject("IconT.Image")));
            this.IconT.Location = new System.Drawing.Point(3, 3);
            this.IconT.Name = "IconT";
            this.IconT.Size = new System.Drawing.Size(32, 32);
            this.IconT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconT.TabIndex = 1;
            this.IconT.TabStop = false;
            // 
            // UnDownPan
            // 
            this.UnDownPan.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.UnDownPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnDownPan.Controls.Add(this.panel6);
            this.UnDownPan.Controls.Add(this.panel4);
            this.UnDownPan.Controls.Add(this.panel5);
            this.UnDownPan.Controls.Add(this.panel3);
            this.UnDownPan.Controls.Add(this.TaskListButton);
            this.UnDownPan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UnDownPan.Location = new System.Drawing.Point(0, 500);
            this.UnDownPan.Name = "UnDownPan";
            this.UnDownPan.Size = new System.Drawing.Size(1439, 33);
            this.UnDownPan.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ShowCommentPan);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(103, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(281, 31);
            this.panel6.TabIndex = 7;
            // 
            // ShowCommentPan
            // 
            this.ShowCommentPan.Controls.Add(this.CommentShow);
            this.ShowCommentPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowCommentPan.Location = new System.Drawing.Point(0, 0);
            this.ShowCommentPan.Name = "ShowCommentPan";
            this.ShowCommentPan.Size = new System.Drawing.Size(281, 31);
            this.ShowCommentPan.TabIndex = 2;
            // 
            // CommentShow
            // 
            this.CommentShow.AutoSize = true;
            this.CommentShow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CommentShow.ForeColor = System.Drawing.Color.White;
            this.CommentShow.Location = new System.Drawing.Point(3, 5);
            this.CommentShow.Name = "CommentShow";
            this.CommentShow.Size = new System.Drawing.Size(66, 20);
            this.CommentShow.TabIndex = 1;
            this.CommentShow.Text = "活动中...";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ShowTaskbarPan);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(384, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(709, 31);
            this.panel4.TabIndex = 6;
            // 
            // ShowTaskbarPan
            // 
            this.ShowTaskbarPan.Location = new System.Drawing.Point(14, 3);
            this.ShowTaskbarPan.Name = "ShowTaskbarPan";
            this.ShowTaskbarPan.Size = new System.Drawing.Size(689, 25);
            this.ShowTaskbarPan.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 25);
            this.panel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TaskButtonbarShow);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1093, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(331, 31);
            this.panel5.TabIndex = 3;
            // 
            // TaskButtonbarShow
            // 
            this.TaskButtonbarShow.Location = new System.Drawing.Point(14, 3);
            this.TaskButtonbarShow.Name = "TaskButtonbarShow";
            this.TaskButtonbarShow.Size = new System.Drawing.Size(311, 25);
            this.TaskButtonbarShow.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 25);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1424, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(13, 31);
            this.panel3.TabIndex = 5;
            // 
            // TaskListButton
            // 
            this.TaskListButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskListButton.FlatAppearance.BorderSize = 0;
            this.TaskListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TaskListButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TaskListButton.Location = new System.Drawing.Point(0, 0);
            this.TaskListButton.Name = "TaskListButton";
            this.TaskListButton.Size = new System.Drawing.Size(103, 31);
            this.TaskListButton.TabIndex = 0;
            this.TaskListButton.Text = "视图按钮";
            this.TaskListButton.UseVisualStyleBackColor = true;
            this.TaskListButton.Click += new System.EventHandler(this.TaskListButton_Click);
            // 
            // MainShow
            // 
            this.MainShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainShow.Location = new System.Drawing.Point(0, 39);
            this.MainShow.Name = "MainShow";
            this.MainShow.Size = new System.Drawing.Size(1439, 461);
            this.MainShow.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1439, 533);
            this.Controls.Add(this.MainShow);
            this.Controls.Add(this.UnDownPan);
            this.Controls.Add(this.TitlePan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.TitlePan.ResumeLayout(false);
            this.TitlePan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconT)).EndInit();
            this.UnDownPan.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ShowCommentPan.ResumeLayout(false);
            this.ShowCommentPan.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox IconT;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MaxButton;
        private System.Windows.Forms.Button MinButton;
        private System.Windows.Forms.Button TaskListButton;
        public System.Windows.Forms.MenuStrip menusp;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label CommentShow;
        public System.Windows.Forms.Panel TitlePan;
        public System.Windows.Forms.Panel ShowCommentPan;
        private System.Windows.Forms.Panel ShowTaskbarPan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel TaskButtonbarShow;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Panel UnDownPan;
        public System.Windows.Forms.Panel MainShow;
    }
}