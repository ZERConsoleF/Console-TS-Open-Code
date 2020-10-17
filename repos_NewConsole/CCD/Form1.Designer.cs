namespace CCD
{
    partial class Form1
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
            this.listVerList1 = new SmProPub.Window.Forms.UsersControl.ListVerList();
            this.listVerCs1 = new SmProPub.Window.Forms.UsersControl.ListVerCs();
            this.SuspendLayout();
            // 
            // listVerList1
            // 
            this.listVerList1.AutoScroll = true;
            this.listVerList1.Location = new System.Drawing.Point(25, 44);
            this.listVerList1.Name = "listVerList1";
            this.listVerList1.Size = new System.Drawing.Size(631, 360);
            this.listVerList1.TabIndex = 1;
            // 
            // listVerCs1
            // 
            this.listVerCs1.AutoScroll = true;
            this.listVerCs1.BackColor = System.Drawing.Color.White;
            this.listVerCs1.BorderPanel = System.Windows.Forms.BorderStyle.None;
            this.listVerCs1.CheckColor = System.Drawing.Color.Olive;
            this.listVerCs1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listVerCs1.Location = new System.Drawing.Point(123, 35);
            this.listVerCs1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listVerCs1.Name = "listVerCs1";
            this.listVerCs1.ReadlyCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listVerCs1.Size = new System.Drawing.Size(476, 383);
            this.listVerCs1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listVerList1);
            this.Controls.Add(this.listVerCs1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SmProPub.Window.Forms.UsersControl.ListVerCs listVerCs1;
        private SmProPub.Window.Forms.UsersControl.ListVerList listVerList1;
    }
}