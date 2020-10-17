using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.SmProPub.ExClass;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class ListVebel : UserControl
    {
        public ObjectClass<ListVebel> ListIndex { get; set; }
        public ListVebel()
        {
            InitializeComponent();
            ListIndex = new ObjectClass<ListVebel>();
            ListIndex.IDX = ListIndex.SaveInMemory(this);
            //AddControl = new Control[0];
            SpForm = 0;
            CheckForIllegalCrossThreadCalls = false;
            Disposed += ListVebel_Disposed;
        }

        private void ListVebel_Disposed(object sender, EventArgs e)
        {
            ObjectClass<ListVebel>.DisopseInMemory(this);
        }
        #region Private
        List<Control> fc = new List<Control>();
        Control opd = null;
        #endregion
        #region 注册编辑
        /// <summary>
        /// 在窗体加载完成默认的窗体
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("ListFocusProcess")]
        [System.ComponentModel.DefaultValue(0)]
        [System.ComponentModel.Description("在窗体加载完成默认的窗体")]
        public int SpForm { get; set; }
        #endregion
        #region 用户操作
        /// <summary>
        /// 新建窗体在列表
        /// </summary>
        /// <param name="asp">窗体</param>
        public void AddFormSope(Control asp)
        {
            if (ShowAll.InvokeRequired)
            {
                //Monitor.Enter(ShowAll);
                ShowAll.BeginInvoke(new MethodInvoker(delegate { AddFormSope(asp); }));
                return;
            }
                //asp.TopLevel = false;

            newTaskBar1.AddName(asp.Text);
            void ssp() { ShowAll.Controls.Add(asp); }
            /*
            if (asp.InvokeRequired)
                asp.BeginInvoke(new MethodInvoker(ssp));
            else
                ssp();
            */
            ssp();
            //asp.WindowState = FormWindowState.Maximized;
            //asp.FormBorderStyle = FormBorderStyle.None;
            fc.Add(asp);
            asp.TextChanged += Asp_TextChanged;
            asp.Disposed += (object sender, EventArgs e)=> { RemoveFormSope(asp); };
            //asp.Hide();
            newTaskBar1.obv[newTaskBar1.GetTaskBarControl().Length - 1] = asp;
            //asp.Show();
            if (opd != null)
            {
                opd.Hide();
            }
            opd = asp;
        }

        /// <summary>
        /// 移除窗体
        /// </summary>
        /// <param name="asp"></param>
        public void RemoveFormSope(Control asp)
        {
            int x = 0;
            foreach (object yp in newTaskBar1.obv)
            {
                if (yp == asp)
                {
                    Control p = newTaskBar1.GetControl(x);
                    asp.TextChanged -= Asp_TextChanged;

                    newTaskBar1.RemoveControl(p);
                    fc.Remove(asp);
                    //asp.Hide();

                    //Console.WriteLine(newTaskBar1.GetTaskBarControl().Length);
                    int cf = newTaskBar1.GetTaskBarControl().Length - 1;
                    if (cf >= 0)
                        newTaskBar1.FocusControl(cf);

                    return;
                }
                x++;
            }
        }
        /// <summary>
        /// 获取所有窗体
        /// </summary>
        /// <returns></returns>
        public Control[] GetFormSp()
        {
            List<Control> v = new List<Control>();
            foreach (Control b in ShowAll.Controls)
            {
                v.Add(b);
            }
            return v.ToArray();
        }
        /// <summary>
        /// 获取窗体焦点
        /// </summary>
        /// <returns></returns>
        public Control GetFocusForm()
        {
            return opd;
        }
        /// <summary>
        /// 对当前焦点丢失
        /// </summary>
        public void LostFocusForm()
        {
            if (opd == null)
                return;
            opd.Hide();
            opd = null;
            newTaskBar1.LostFocusControl();
        }
        /// <summary>
        /// 对窗体焦点
        /// </summary>
        /// <param name="idx"></param>
        public void FocusForm(int idx)
        {
            newTaskBar1.FocusControl(idx);
        }
        /// <summary>
        /// 获取设置List任务栏
        /// </summary>
        /// <returns></returns>
        public NewTaskBar GetTaskBar()
        {
            return newTaskBar1;
        }
        /// <summary>
        /// 获取储存容器
        /// </summary>
        /// <returns></returns>
        public Panel GetPanel()
        {
            return ShowAll;
        }
        #endregion
        /// <summary>
        /// 向用户显示窗体
        /// </summary>
        public new void Show()
        {
            if (newTaskBar1.GetTaskBarControl().Length != 0)
                newTaskBar1.FocusControl(SpForm);
            base.Show();
        }
        private void Asp_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            foreach (object yp in newTaskBar1.obv)
            {
                if (yp == sender)
                {
                        Control cp = newTaskBar1.GetControl(x);
                    if (cp != null)
                        newTaskBar1.ChangeControlName(cp, (sender as Control).Text);
                }
                x++;
            }
        }

        private void newTaskBar1_ClickEvent(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            //new Thread(() =>
            //{
                Control fc = o.Save as Control;
                if (opd != null)
                {
                    if (opd == fc)
                        return;
                    opd.Hide();
                }
                opd = fc;
                fc.Show();
            //}).Start();
        }
    }
}
