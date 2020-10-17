namespace ProgramWindowLoad
{
    partial class ViewWindowListMainTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewWindowListMainTo));
            this.button1 = new System.Windows.Forms.Button();
            this.setWindowControl1 = new SmProPub.Window.Forms.UsersControl.SetWindowControl();
            this.listVerList1 = new SmProPub.Window.Forms.UsersControl.ListVerList();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(941, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "SeeMore";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setWindowControl1
            // 
            this.setWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.setWindowControl1.Name = "setWindowControl1";
            this.setWindowControl1.SaveButtonText = null;
            this.setWindowControl1.SaveButtonToRightButtom = new System.Drawing.Point(5, 5);
            this.setWindowControl1.ShowPP = new System.Drawing.Size(619, 544);
            this.setWindowControl1.Size = new System.Drawing.Size(1097, 544);
            this.setWindowControl1.TabIndex = 3;
            // 
            // listVerList1
            // 
            this.listVerList1.AutoScroll = true;
            this.listVerList1.BackColor1 = System.Drawing.SystemColors.Control;
            this.listVerList1.BackColor2 = System.Drawing.Color.White;
            this.listVerList1.CheckColor = System.Drawing.Color.Aqua;
            this.listVerList1.ClickMore = false;
            this.listVerList1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listVerList1.Location = new System.Drawing.Point(779, 49);
            this.listVerList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listVerList1.Name = "listVerList1";
            this.listVerList1.ReadyCheckColor = System.Drawing.Color.AliceBlue;
            this.listVerList1.Size = new System.Drawing.Size(306, 295);
            this.listVerList1.TabIndex = 5;
            this.listVerList1.ClickItem += new System.SmProPub.Event.ObjectEventArg(this.listVerList1_ClickItem);
            // 
            // ViewWindowListMainTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listVerList1);
            this.Controls.Add(this.setWindowControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewWindowListMainTo";
            this.Text = "Find Window";
            this.Load += new System.EventHandler(this.ViewWindowListMainTo_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private SmProPub.Window.Forms.UsersControl.SetWindowControl setWindowControl1;
        private System.Windows.Forms.Button button1;
        private SmProPub.Window.Forms.UsersControl.ListVerList listVerList1;
    }
}