namespace SmProPub.Window.Forms.UsersControl
{
    partial class NCKOLCTEFT
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
            this.ShowIn = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Panel();
            this.MinButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TitleName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShowIn);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 0;
            // 
            // ShowIn
            // 
            this.ShowIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowIn.Location = new System.Drawing.Point(0, 24);
            this.ShowIn.Name = "ShowIn";
            this.ShowIn.Size = new System.Drawing.Size(776, 402);
            this.ShowIn.TabIndex = 2;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.MediumTurquoise;
            this.Title.Controls.Add(this.MinButton);
            this.Title.Controls.Add(this.CloseButton);
            this.Title.Controls.Add(this.TitleName);
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(776, 24);
            this.Title.TabIndex = 1;
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseDown);
            this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseMove);
            // 
            // MinButton
            // 
            this.MinButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinButton.FlatAppearance.BorderSize = 0;
            this.MinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinButton.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinButton.Location = new System.Drawing.Point(728, 0);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(24, 24);
            this.MinButton.TabIndex = 7;
            this.MinButton.Text = "-";
            this.MinButton.UseVisualStyleBackColor = true;
            this.MinButton.Click += new System.EventHandler(this.MinButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseButton.Location = new System.Drawing.Point(752, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 24);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TitleName
            // 
            this.TitleName.AutoSize = true;
            this.TitleName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleName.Location = new System.Drawing.Point(4, 1);
            this.TitleName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.TitleName.Name = "TitleName";
            this.TitleName.Size = new System.Drawing.Size(56, 20);
            this.TitleName.TabIndex = 1;
            this.TitleName.Text = "Form1";
            this.TitleName.TextChanged += new System.EventHandler(this.TitleName_TextChanged);
            this.TitleName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseDown);
            this.TitleName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseMove);
            // 
            // NCKOLCTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NCKOLCTE";
            ///this.ShowInTaskbar = false;
            this.Text = "NewSeeModsControl";
            this.Load += new System.EventHandler(this.NCKOLCTE_Load);
            this.SizeChanged += new System.EventHandler(this.NCKOLCTE_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseRightForm_MouseMove);
            this.panel1.ResumeLayout(false);
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel Title;
        public System.Windows.Forms.Label TitleName;
        public System.Windows.Forms.Panel ShowIn;
        public System.Windows.Forms.Button MinButton;
        public System.Windows.Forms.Button CloseButton;
    }
}