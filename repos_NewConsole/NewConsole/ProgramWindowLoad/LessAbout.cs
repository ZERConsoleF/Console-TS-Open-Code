using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramWindowLoad
{
    public partial class LessAbout : Form
    {
        Form lpr = null;
        NCKOLCTETU ltu = null;
        public LessAbout(Form v7)
        {
            InitializeComponent();
            lpr = v7;
            ddfrttgghg();
        }
        public LessAbout(NCKOLCTETU v7)
        {
            InitializeComponent();
            ltu = v7;
            ddfrttgghg();
        }

        public void ddfrttgghg()
        {
            SubItemVer v = new SubItemVer();
            v.Text = "Window Static";
            SubItemPanel p = new SubItemPanel();
            p.GetSetControl = textBox1;
            v.GetSetSubItemPanels.Add(p);
            textBox1.Dock = DockStyle.Fill;
            setWindowControl1.PutSaveButtonInControl = false;
            setWindowControl1.AddItem(v);
            v = new SubItemVer();
            v.Text = "Control Window";
            p = new SubItemPanel();
            p.GetSetControl = button1;
            v.GetSetSubItemPanels.Add(p);
            p = new SubItemPanel();
            p.GetSetControl = button2;
            v.GetSetSubItemPanels.Add(p);
            p = new SubItemPanel();
            p.GetSetControl = button3;
            v.GetSetSubItemPanels.Add(p);
            button1.Location = new Point(5,5);
            button2.Location = new Point(15, 5);
            button3.Location = new Point(25, 5);
            setWindowControl1.AddItem(v);
        }

        private void LessAbout_Load(object sender, EventArgs e)
        {
            if (lpr != null)
            {
                Text += lpr.Name;

                List<string> st = new List<string>();
                Type d = lpr.GetType();
                st.Add("操作类:" + d.FullName);
                st.Add("操控语句:" + lpr.Handle.ToString());
                st.Add("操控GUID:" + d.GUID);
                st.Add("属于:" + d.Namespace);
                st.Add("---");
                st.Add("显示状态:" + lpr.WindowState.ToString());
                st.Add("Title:" + lpr.Text);
                st.Add("Form Loction:" + lpr.Location.ToString());
                st.Add("Form Size:" + lpr.Size.ToString());

                foreach (string sp in st.ToArray())
                    textBox1.AppendText(sp + "\r\n");
            }
            else
            {
                List<string> st = new List<string>();
                Type d = ltu.GetType();
                st.Add("操作类:" + d.FullName);
                st.Add("操控语句:" + ltu.Handle.ToString());
                st.Add("操控GUID:" + d.GUID);
                st.Add("属于:" + d.Namespace);
                st.Add("---");
                st.Add("显示状态:" + ltu.WindowState.ToString());
                st.Add("Title:" + ltu.Text);
                st.Add("Form Loction:" + ltu.Location.ToString());
                st.Add("Form Size:" + ltu.Size.ToString());

                foreach (string sp in st.ToArray())
                    textBox1.AppendText(sp + "\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ltu != null)
            {
                ltu.WindowState = FormWindowState.Normal;
                return;
            }
            lpr.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ltu != null)
            {
                ltu.WindowState = FormWindowState.Minimized;
                return;
            }
            lpr.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ltu != null)
            {
                ltu.Close();
                return;
            }
            lpr.Close();
        }
    }
}
