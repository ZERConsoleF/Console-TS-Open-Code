using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProPub.Window.Formw.Controle
{
    public partial class ListOf : UserControl
    {
        public ListOf()
        {
            InitializeComponent();
            //TitleChage = new ItemTool();
        }
        /// <summary>
        /// 标题的Tool(必须设置，否则引发错误)
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SelectText")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("标题的Tool(必须设置，否则引发错误)")]
        public ItemTool TitleChage { get; set; }
        /// <summary>
        /// 子项的Tool(可以不设)
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("SelectText")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("子项的Tool(可以不设)")]
        public ItemTool[] SubItemChage { get; set; }

        private void ListOf_SizeChanged(object sender, EventArgs e)
        {
            ListOc.Size = new Size(this.Width - this.oldScrollBar1.Width, this.ListOc.Height);
            listSocer1.Size = new Size(this.Width - this.oldScrollBar1.Width, this.Height - this.ListOc.Height);
        }

        private Control InvokMake(ItemTool ic,Control ct)
        {
            Panel p = new Panel();
            p.Name = ct.Name + "-1";
            p.Size = ct.Size;
            p.Size = new Size(ic.SizeWidth, p.Size.Height);

            p.BorderStyle = BorderStyle.FixedSingle;

            if (ic.Con != new Control())
                p.Controls.Add(ic.Con);

            List<Control> ci = new List<Control>();
            ci.Add(p);

            int xcv = p.Width;

            foreach (ItemTool tc in ic.ItemChage)
            {
                if (tc.ItemChage != null && tc.ItemChage.Count > 0)
                {
                    SmException ec = new SmException();
                    ec.CodeLine = "mov 00,00;0xc000001";
                    ec.ID = -1281345638;
                    ec.message = "子项的子项不准有子项";
                    throw ec.RunSmProEx();
                }

                Control cy = InvokMake(tc, ct);

                /*
                int xgh = xcv;
                int hui = cy.Size.Width;

                Console.WriteLine(xgh +":"+ hui + ":" + ct.Size.Width);

                if (xgh + hui > ct.Size.Width)
                {
                    for (int gp = hui;gp >= 0;gp--)
                    {
                        if (xgh + gp <= ct.Size.Width)
                        {
                            hui = gp;
                            break;
                        }
                    }
                    p.Size = new Size(hui, p.Size.Height);
                }
                */
                cy.Location = new Point(xcv, 0);
                xcv += cy.Size.Width;
                ci.Add(cy);
            }

            foreach (Control yu in ci.ToArray())
            {
                ct.Controls.Add(yu);
                yu.Show();
            }

            return p;
            /*
            int xer = 0;
            foreach (Control s3 in sc(ct))
            {
                xer += s3.Width;
            }
            */
        }

        private Control[] sc(Control Rexc)
        {
            List<Control> n8 = new List<Control>();
            foreach (Control cv in Rexc.Controls)
                n8.Add(cv);
            return n8.ToArray();
        }

        private void ListOf_Load(object sender, EventArgs e)
        {
            ListOc.BackColor = this.listSocer1.BackColor;
            /*
            if (TitleChage == null)
            {
                SmException er = new SmException();
                er.CodeLine = "mov 0a,1t;0xc00296 &?& 0xc0073392";
                er.FailWhy = "都说了Title不可为空";
                er.Debug = "Tit df sp";
                er.ID = -9934432;
                er.message = "Eye";
                throw er.RunSmProEx();
            }
            */
            Invok();
        }
        public void Invok()
        {
            if (TitleChage != null)
            {
                InvokMake(TitleChage, ListOc);
            }
            List<Panel> pv = new List<Panel>();
            int x = 0;
            if (SubItemChage != null)
                foreach (ItemTool ft in SubItemChage)
                {
                    Panel po = new Panel();
                    po.Name = "panel" + x;
                    po.AutoSize = true;
                    po.Size = listSocer1.VCLOButO;
                    po.Controls.Add(InvokMake(ft, po));
                    pv.Add(po);
                    x++;
                }
            listSocer1.LSFCatMkdirTy = pv.ToArray();
            listSocer1.InvokLt();
        }
    }
    /// <summary>
    /// 绑定在控件的list列表
    /// </summary>
    public class ItemTool
    {
        /// <summary>
        /// 初始化ListTool分配
        /// </summary>
        public ItemTool()
        {
            Con = new Control();
            SizeWidth = 32;
        }
        /// <summary>
        /// 控件序列
        /// </summary>
        public Control Con { get; set; }
        /// <summary>
        /// 文本的子项(子项的ItemChage不可用)
        /// </summary>

        public List<ItemTool> ItemChage = new List<ItemTool>();
        /// <summary>
        /// 从第一个到最后一个颜色变化
        /// </summary>
        public List<Color> ListColor = new List<Color>();
        /// <summary>
        /// 设置每各列表的宽度
        /// </summary>
        public int SizeWidth { get; set; }
    }
}
