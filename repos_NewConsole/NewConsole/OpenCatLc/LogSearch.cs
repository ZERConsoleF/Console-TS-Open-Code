using SmProPub.Text;
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

namespace OpenCatLc
{
    public partial class LogSearch : NCKOLCTE
    {
        public LogSearch()
        {
            InitializeComponent();
        }
        public string SearchText { get; set; }
        public void Format()
        {
            listVerList1.Clear();
            ListVerItemList l1 = new ListVerItemList();
            l1.Text = "事件发出者";
            l1.Weight = 120;
            ListVerItemList l2 = new ListVerItemList();
            l2.Text = "时间";
            l2.Weight = 180;
            ListVerItemList l3 = new ListVerItemList();
            l3.Text = "用户发送者";
            l3.Weight = 160;
            ListVerItemList l4 = new ListVerItemList();
            l4.Text = "事件";
            l4.Weight = 250;
            listVerList1.AddTitleItem(l1);
            listVerList1.AddTitleItem(l2);
            listVerList1.AddTitleItem(l3);
            listVerList1.AddTitleItem(l4);
            foreach (string fgr in SearchText.Split('\n'))
            {
                try
                {
                    string[] f = StringSearch.FormatString(fgr, ' ', '[', ']', 3);
                    int g = int.Parse(textBox4.Text);

                    ListVerItemLine i1 = new ListVerItemLine();
                    i1.Text = f[0];
                    if (textBox2.Text != "" && g > StringSearch.SearchStringInFormat(f[0], textBox2.Text) * 100)
                        continue;
                    ListVerItemLine i2 = new ListVerItemLine();
                    i2.Text = f[1];
                    if (textBox5.Text != "" && g > StringSearch.SearchStringInFormat(f[1], textBox5.Text) * 100)
                        continue;
                    i1.SubItem = i2;
                    ListVerItemLine i3 = new ListVerItemLine();
                    i3.Text = f[2];
                    if (textBox1.Text != "" && g > StringSearch.SearchStringInFormat(f[2], textBox1.Text) * 100)
                        continue;
                    i2.SubItem = i3;
                    ListVerItemLine i4 = new ListVerItemLine();
                    i4.Text = f[3];
                    //Console.WriteLine(StringSearch.SearchStringInFormat(f[3], textBox3.Text) * 100);
                    if (textBox3.Text != "" && g > StringSearch.SearchStringInFormat(f[3], textBox3.Text) * 100)
                        continue;
                    i3.SubItem = i4;
                    listVerList1.AddSubItem(i1, l1, true);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Format();
        }
    }
}
