using SmPro.System;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmCmd.WindowCreative
{
    public partial class FormLessOne : Form
    {
        public FormLessOne()
        {
            InitializeComponent();
        }

        private void FormLessOne_Load(object sender, EventArgs e)
        {
            ItemListCs c = new ItemListCs();
            c.Text = "All Windows(Search)";
            c.Name = c.Text + ".hgh";
            c.Hight = 4;
            c.Type = "Main";
            c.Image = Image.FromFile("Ico/6e6224b3792212a3574218ba9889a844.jpg");
            listVerCs1.AddItem(c, null);
            if (FormMenu.GetIndexl != null)
                foreach (FormMenu m in FormMenu.GetIndexl)
                {
                    Screajo(m);
                }
        }
        private void Screajo(FormMenu m)
        {
            ItemListCs c = new ItemListCs();
            c.Text = m.PackName;
            c.Name = c.Text + ".hgh";
            c.Hight = 4;
            c.Type = "Form";
            if (c.Image == null)
                c.Image = Image.FromFile("Ico/e7b536dc90d10edbd0bec8aad3d40b3f.jpg");
            listVerCs1.AddSubItem(new int[] { 0 }, c);
        }

        private void listVerCs1_ClickItem(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            ItemListCs c = listVerCs1.GetCheckItem();
            if (c == null)
            {
                label1.Text = "None";
                button1.Enabled = false;
                textBox1.Text = "";
                textBox1.Enabled = false;
                label2.Text = "None";
                cvg = null;
                return;
            }
            if (c.Type != "Form")
            {
                label1.Text = "ClickName" + c.Text + ",but this is [ " + c.Type + " ]";
                label2.Text = "Refuse adds";
                cvg = null;
                button1.Enabled = false;
                textBox1.Text = "";
                textBox1.Enabled = false;

                if (cvg != null)
                {
                    if (cvg.YNCheck)
                    {
                        if (cvg.Check)
                        {
                            label2.Text = "Have a add";
                            button1.Enabled = false;
                        }
                        else
                            label2.Text = "Can adds";
                    }
                    else
                        label2.Text = "Can adds";
                }
                else
                    label2.Text = "Can adds";

                return;
            }
            else
            {
                label1.Text = "ClickName" + c.Text + ",Control Form";
                textBox1.Enabled = true;
                foreach (FormMenu m in FormMenu.GetIndexl)
                {
                    if (m.PackName == c.Text)
                    {
                        if (m.CheckForm != null)
                        {
                            textBox1.Text = m.CheckForm.Text;
                            cvg = m;
                        }
                    }
                }

                button1.Enabled = true;

                if (cvg != null)
                {
                    if (cvg.YNCheck)
                    {
                        if (cvg.Check)
                        {
                            label2.Text = "Have a add";
                            button1.Enabled = false;
                        }
                        else
                            label2.Text = "Can adds";
                    }
                    else
                        label2.Text = "Can adds";
                }
                else
                    label2.Text = "Can adds";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemListCs c = listVerCs1.GetCheckItem();
            foreach (FormMenu m in FormMenu.GetIndexl)
            {
                if (m.PackName == c.Text)
                {
                   m.ObjectClassArgL();
                }
            }
        }

        FormMenu cvg = null;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cvg != null)
            {
                cvg.CheckForm.Text = textBox1.Text;
            }
        }
    }
}
