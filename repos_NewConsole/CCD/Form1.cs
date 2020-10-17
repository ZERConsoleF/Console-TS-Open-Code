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

namespace CCD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListVerItemList l1 = new ListVerItemList();
            l1.Text = "测试A";
            listVerList1.AddTitleItem(l1);
            ListVerItemList l2 = new ListVerItemList();
            l2.Text = "测试B";
            listVerList1.AddTitleItem(l2);
            ListVerItemLine i1 = new ListVerItemLine();
            i1.Text = "项目A";
            ListVerItemLine i2 = new ListVerItemLine();
            i2.Text = "项目B";
            i1.SubItem = i2;
            listVerList1.AddSubItem(i1, l1, true);

            ItemListCs c = new ItemListCs();
            c.Name = "np";
            c.Text = "fg";
            c.Hight = 4;
            ItemListCs ci = new ItemListCs();
            ci.Name = "np141";
            ci.Text = "fp";
            ci.Hight = 4;
            c.SubItems.Add(ci);
            ItemListCs cii = new ItemListCs();
            cii.Name = "np14j";
            cii.Text = "fkp";
            cii.Hight = 4;
            //ci.SubItems.Add(cii);
            listVerCs1.AddItem(c, null);
            listVerCs1.AddSubItem(new int[] { 0 }, cii);
        }
    }
}
