using RunLCJVM.Window;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleG.WindowG
{
    /// <summary>
    /// 设置窗体BV
    /// </summary>
    public class SetETCWindowToSystem
    {
        MainWindow w;
        /// <summary>
        /// 新建查询
        /// </summary>
        /// <param name="w"></param>
        public SetETCWindowToSystem(MainWindow w)
        {
            this.w = w;
        }
        /// <summary>
        /// 绑定到下面
        /// </summary>
        /// <param name="f"></param>
        public void SetLocationDown(Control f)
        {
            int wy = w.Height - w.UnDownPan.Height - f.Height;
            f.Location = new Point(f.Location.X, wy);
        }
        /// <summary>
        /// 设置成同宽
        /// </summary>
        /// <param name="f"></param>
        public void SetWeightToSystem(Control f)
        {
            f.Size = new Size(w.Width, f.Height);
        }
        /// <summary>
        /// 获取窗体的宽度
        /// </summary>
        /// <returns></returns>
        public int GetWeightToSystem()
        {
            return w.Width;
        }
        /// <summary>
        /// 绑定到上面
        /// </summary>
        /// <param name="f"></param>
        public void SetLocationUp(Control f)
        {
            int wy = w.TitlePan.Height;
            f.Location = new Point(f.Location.X, wy);
        }
        /// <summary>
        /// 设置同高
        /// </summary>
        /// <param name="f"></param>
        public void SetHeightToSystem(Control f)
        {
            f.Size = new Size(f.Width, w.Height - w.TitlePan.Height - w.UnDownPan.Height);
        }
        /// <summary>
        /// 获取窗体高度
        /// </summary>
        /// <returns></returns>
        public int GetHeightToSystem()
        {
            
            return w.Height - w.TitlePan.Height - w.UnDownPan.Height;
        }
        /// <summary>
        /// 绑定到左边
        /// </summary>
        /// <param name="f"></param>
        public void SetLocationLeft(Control f)
        {
            f.Location = new Point(0, 0);
        }
        /// <summary>
        /// 绑定到右边
        /// </summary>
        /// <param name="f"></param>
        public void SetLocationRight(Control f)
        {
            f.Location = new Point(w.Width - f.Width, 0);
        }
        /// <summary>
        /// 尝试用Form标题寻找
        /// </summary>
        /// <param name="text">Form的Text文本</param>
        /// <returns></returns>
        public Form SearchWindowInText(string text)
        {
            foreach (Form l in SearchWindowInAll())
            {
                if (l.Text == text)
                {
                    return l;
                }
            }
            return null;
        }
        /// <summary>
        /// 尝试用Foem标记寻找
        /// </summary>
        /// <param name="name">窗体的Name标记</param>
        /// <returns></returns>
        public Form SearchWindowInName(string name)
        {
            foreach (Form l in SearchWindowInAll())
            {
                if (l.Name == name)
                {
                    return l;
                }
            }
            return null;
        }
        /// <summary>
        /// 尝试在所有范围寻找Form
        /// </summary>
        /// <returns></returns>
        public Form[] SearchWindowInAll()
        {
            List<Form> f = new List<Form>();
            foreach (Control l in w.Controls)
            {
                if (l is Form)
                {
                    f.Add(l as Form);
                }
            }
            return f.ToArray();
        }

        /// <summary>
        /// 寻找NCKOLCTETU配置窗体
        /// </summary>
        /// <returns></returns>
        public NCKOLCTETU[] SearchNCKOLCTETUInAll()
        {
            List<NCKOLCTETU> f = new List<NCKOLCTETU>();
            foreach (Control l in w.Controls)
            {
                if (l is NCKOLCTETU)
                {
                    f.Add(l as NCKOLCTETU);
                }
            }
            return f.ToArray();
        }

        /// <summary>
        /// 将这个控件获取点击并放置在前
        /// </summary>
        /// <param name="cq">St Screh</param>
        public void SetFocusMain(Control cq)
        {
            List<Control> cp = new List<Control>();
            foreach (Control c in w.Controls)
            {
                if (!(c is NCKOLCTE) && !(c is NCKOLCTETU))
                    continue;
                cp.Add(c);
            }
            cq.Focus();
            if (cp.Count > 0)
            {
                Control q1 = cp[0];
                Control q2 = null;

                foreach (Control c in cp.ToArray())
                {
                    if (c == cq)
                    {
                        q2 = c;
                    }
                }
                if (q2 != null)
                {
                    cp[0] = q2;
                    cp[cp.Count - 1] = q1;
                }

                foreach (Control ci in cp.ToArray())
                {
                    w.Controls.Add(ci);
                }
            }
        }
        /*
        /// <summary>
        /// 将这个控件全部设置焦点控件
        /// </summary>
        /// <param name="cp">控件</param>
        public void SetFocusEvent(Control cp,Control vvf)
        {
            if (vvf == null) vvf = cp;
            cp.GotFocus += (object sender, EventArgs e) => { SetFocusMain(vvf); };
            foreach (Control fg in cp.Controls)
                SetFocusEvent(fg,vvf);
        }
        /// <summary>
        /// 将这个控件全部设置焦点控件无效
        /// </summary>
        /// <param name="cp">控件</param>
        public void CanelFocusEvent(Control cp, Control vvf)
        {
            if (vvf == null) vvf = cp;
            cp.GotFocus -= (object sender, EventArgs e) => { SetFocusMain(vvf); };
            foreach (Control fg in cp.Controls)
                CanelFocusEvent(fg,vvf);
        }
        */
    }
}
