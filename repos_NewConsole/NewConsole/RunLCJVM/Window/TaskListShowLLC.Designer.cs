namespace RunLCJVM.Window
{
    partial class TaskListShowLLC
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
            this.LessTme = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LessTme
            // 
            this.LessTme.BackColor = System.Drawing.Color.White;
            this.LessTme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LessTme.Location = new System.Drawing.Point(0, 0);
            this.LessTme.Multiline = true;
            this.LessTme.Name = "LessTme";
            this.LessTme.ReadOnly = true;
            this.LessTme.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LessTme.Size = new System.Drawing.Size(800, 450);
            this.LessTme.TabIndex = 0;
            // 
            // TaskListShowLLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LessTme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskListShowLLC";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TaskListShowLLC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox LessTme;
    }
}