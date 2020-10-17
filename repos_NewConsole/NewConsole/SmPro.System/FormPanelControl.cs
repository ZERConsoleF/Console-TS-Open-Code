using RunLCJVM.Window;
using SmProPub;
using SmProPub.Text;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmPro.System
{
    /// <summary>
    /// 窗体合并器(仅限于SeeModsConsoleRun所有)
    /// </summary>
    public class FormPanelControl : ObjectClass<FormPanelControl>
    {
        MainWindow w;
        /// <summary>
        /// 新建窗体合并器
        /// </summary>
        /// <param name="w">SeeMods窗体管理</param>
        public FormPanelControl(MainWindow w)
        {
            this.w = w;
            IDX = SaveInMemory(this);
            AsiPosInt = 150;
            Name = "Name." + nameof(FormPanelControl) + "." + IDX;
            Text = "Text." + nameof(FormPanelControl) + "." + IDX;
        }
        List<FormPanelItems> ghl = new List<FormPanelItems>();
        List<Control> ctp = new List<Control>();
        List<NCKOLCTETU> ncktup = new List<NCKOLCTETU>();
        /// <summary>
        /// 判断幅度
        /// </summary>
        public int AsiPosInt { get; set; }
        /// <summary>
        /// 默认的文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 是否开始执行
        /// </summary>
        public bool StartOpend { get; protected set; }
        /// <summary>
        /// 是否正在改变窗体
        /// </summary>
        public bool IsSizeLocationChanging { get; protected set; }

        /// <summary>
        /// 向执行区添加项目
        /// </summary>
        /// <param name="item">窗体项目</param>
        public void Add(FormPanelItems item)
        {
            ghl.Add(item);
            if (StartOpend)
            {
                Open(item);
            }
            /*
            foreach (Control hg in item.AddInNCKOLCTE.ToArray())
                ctp.Add(hg);
            foreach (Control hg in item.AddInNCKOLCTETU.ToArray())
                ctp.Add(hg);
            */
        }
        /// <summary>
        /// 向缓冲区添加项目
        /// </summary>
        /// <param name="c">窗体项目</param>
        public void Add(Control c)
        {
            ctp.Add(c);
        }
        /// <summary>
        /// 向执行区移除项目
        /// </summary>
        /// <param name="item"></param>
        public void Remove(FormPanelItems item)
        {
            ghl.Remove(item);
        }
        /// <summary>
        /// 向缓冲区移除项目
        /// </summary>
        /// <param name="c"></param>
        public void Remove(Control c)
        {
            ctp.Remove(c);
        }
        /// <summary>
        /// 清空执行区和缓存区所有(不会对项目释放)
        /// </summary>
        public void Clear()
        {
            ctp.Clear();
            ghl.Clear();
        }

        /// <summary>
        /// 合并窗体
        /// </summary>
        /// <param name="c">控件1</param>
        /// <param name="c1">控件2</param>
        /// <param name="it">一个新的item</param>
        public void InAdd(Control c,FormPanelItems it)
        {
            bool b1 = false;
            //bool b2 = false;
            foreach (Control g in ctp.ToArray())
            {
                if (g == c)
                {
                    b1 = true;
                }
                /*
                if (g == c1)
                {
                    b2 = true;
                }
                */
            }
            if (!b1)// && b2)
            {
                throw new SmException("控件必须在缓冲区");
            }

            FormPanelAsForm ac = GetFormType(c);
            //FormPanelAsForm ac1 = GetFormType(c1);

            if (ac == FormPanelAsForm.NCKOLCTE)
            {
                it.AddInNCKOLCTE.Add(c as NCKOLCTE);
            }
            else
            {
                it.AddInNCKOLCTETU.Add(c as NCKOLCTETU);
            }
            /*
            if (ac1 == FormPanelAsForm.NCKOLCTE)
            {
                it.AddInNCKOLCTE.Add(c1 as NCKOLCTE);
            }
            else
            {
                it.AddInNCKOLCTETU.Add(c1 as NCKOLCTETU);
            }
            */
            Open(it);
            ctp.Remove(c);
            //ctp.Remove(c1);
        }
        /// <summary>
        /// 分离窗体
        /// </summary>
        /// <param name="it">项目分离</param>
        /// <param name="c">分离目标</param>
        public void InRemove(FormPanelItems it, Control c)
        {
            InRemove(it, c, false, true);
        }
        /// <summary>
        /// 分离窗体,并且这个窗体是否释放
        /// </summary>
        /// <param name="it">项目分离</param>
        /// <param name="c">分离目标</param>
        /// <param name="disclose">是否释放目标</param>
        /// <param name="Packwindowdis">窗体容器是否释放</param>
        public void InRemove(FormPanelItems it, Control c,bool disclose,bool Packwindowdis)
        {
            it.InListVebel.RemoveControl(c, false);
            ctp.Add(c);
            if (!disclose)
            {
                string name = c.Name;
                c.Name += new Random().Next();
                w.AddControlInvoke(c);
                c.Name = name;
                c.Location = it.InNCKOLCTETU.Location;
            }

            FormPanelAsForm ac = GetFormType(c);

            if (ac == FormPanelAsForm.NCKOLCTE)
            {
                (c as NCKOLCTE).Title.Height = 20;
                (c as NCKOLCTE).LockWindow = false;
                it.AddInNCKOLCTE.Remove(c as NCKOLCTE);
            }
            else
            {
                (c as NCKOLCTETU).Title.Height = 20;
                (c as NCKOLCTETU).Dock = DockStyle.None;
                (c as NCKOLCTETU).LockWindow = false;
                it.AddInNCKOLCTETU.Remove(c as NCKOLCTETU);
            }

            if (it.AddInNCKOLCTE.Count + it.AddInNCKOLCTETU.Count <= 0)
            {
                if (Packwindowdis)
                {
                    Thread tt = new Thread(() =>
                    {
                        while (true)
                        {
                        //Console.WriteLine("\n\n" + 1);
                        if (it.InListVebel.IsHandleCreated)
                            {
                                it.InListVebel.Dispose();
                                break;
                            }
                        }
                    });
                    tt.IsBackground = true;
                    tt.Start();
                    Thread t = new Thread(() =>
                    {
                        while (true)
                        {
                        //Console.WriteLine("\n\n" + 1);
                        if (it.InNCKOLCTETU.IsHandleCreated)
                            {
                                it.InNCKOLCTETU.Close();
                                break;
                            }
                        }
                    });
                    t.IsBackground = true;
                    t.Start();
                    ghl.Remove(it);
                }
            }
            if (disclose)
            {
                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        //Console.WriteLine("\n\n"+1);
                        if (!c.IsHandleCreated)
                        {
                            c.Dispose();
                            break;
                        }
                    }
                });
                t.IsBackground = true;
                t.Start();
            }
        }

        /// <summary>
        /// 开始生效或重置生效
        /// </summary>
        public void Open()
        {
            foreach (NCKOLCTETU tyh in ncktup.ToArray())
                tyh.Dispose();
            ncktup.Clear();
            StartOpend = true;
            foreach (FormPanelItems i in ghl.ToArray())
            {
                Open(i);
            }
        }
        /// <summary>
        /// 开始对这个项目生效
        /// </summary>
        /// <param name="i">窗体项目</param>
        public void Open(FormPanelItems i)
        {
            NCKOLCTETU t = null;
            if (i.InNCKOLCTETU != null && i.InNCKOLCTETU.IsDisposed)
            {
                GC.SuppressFinalize(i.InNCKOLCTETU);
            }
            if (i.InNCKOLCTETU == null)
            {
                t = new NCKOLCTETU();
                t.Name = Name + ncktup.Count + ".listvercsf";
                t.Text = "Windows Panel " + ncktup.Count;
                t.FormMoving += T_FormMoving;
                t.AsiPosInt = this.AsiPosInt;
                //Console.WriteLine(AsiPosInt);
                //SetOwenerWindowToSystem sr = new SetOwenerWindowToSystem(w);
                t.Size = i.Size;
                t.Location = i.Loaction;
            }
            else
                t = i.InNCKOLCTETU;

            TitlePanel p = null;
            if (i.InListVebel != null && i.InListVebel.IsDisposed)
            {
                GC.SuppressFinalize(i.InListVebel);
            }
            if (i.InListVebel == null)
            {
                p = new TitlePanel();
                p.Name = Name + ncktup.Count + ".NCKOLCTE.panel";
            }
            else
            {
                p = i.InListVebel;
            }

            t.Show();
            p.Show();

            foreach (NCKOLCTE tg in i.AddInNCKOLCTE.ToArray())
            {
                t.Text = Text + " - " + tg.Text;
                tg.Title.Height = 0;
                tg.Size = p.GetPanel().Size;
                p.GetPanel().SizeChanged += (object sender, EventArgs e) => { tg.Size = p.GetPanel().Size; };
                if (!tg.IsDisposed)
                    p.AddControl(tg);
                else
                    i.AddInNCKOLCTE.Remove(tg);
            }
            foreach (NCKOLCTETU tg in i.AddInNCKOLCTETU.ToArray())
            {
                t.Text = Text + " - " + tg.Text;
                tg.Title.Height = 0;
                tg.Dock = DockStyle.Fill;
                if (!tg.IsDisposed)
                    p.AddControl(tg);
                else
                    i.AddInNCKOLCTETU.Remove(tg);
            }
            p.ClickEvent += (object sender, ObjectEvent e) => { t.Text = Text + " - " + p.GetFocusForm().Text; };
            t.ShowIn.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            w.AddControlInvoke(t);
            i.InListVebel = p;
            i.InNCKOLCTETU = t;
            p.Disposed += (object sender, EventArgs e) => { i.InListVebel = null; };
            t.Disposed += (object sender, EventArgs e) => { i.InNCKOLCTETU = null; ghl.Remove(i); p.Dispose(); GC.SuppressFinalize(p); };
            ncktup.Add(t);
        }

        /// <summary>
        /// 获取添加的项目
        /// </summary>
        /// <returns></returns>
        public FormPanelItems[] GetFormPanelItems()
        {
            return ghl.ToArray();
        }
        /// <summary>
        /// 获取缓冲区项目
        /// </summary>
        /// <returns></returns>
        public Control[] GetControlsAtTemp()
        {
            return ctp.ToArray();
        }
        /// <summary>
        /// 获取这个窗体在引索<see cref="FormPanelAsForm"/>中官方窗体位置
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static FormPanelAsForm GetFormType(Control c)
        {
            if (c is NCKOLCTE && c is NCKOLCTETU)
                throw new SmException("必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            if (c is NCKOLCTE)
                return FormPanelAsForm.NCKOLCTE;
            else
                return FormPanelAsForm.NCKOLCTETU;
        }
        /// <summary>
        /// 获取这个窗体的所有子控件
        /// </summary>
        /// <param name="l">一个官方窗体</param>
        /// <returns></returns>
        public static Control[] GetFormControls(Control c)
        {
            if (c is NCKOLCTE && c is NCKOLCTETU)
                throw new SmException("必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            List<Control> v = new List<Control>();

            if (c is NCKOLCTE)
            {
                foreach (Control gh in (c as NCKOLCTE).ShowIn.Controls)
                    v.Add(gh);
            }
            if (c is NCKOLCTETU)
            {
                foreach (Control gh in (c as NCKOLCTETU).ShowIn.Controls)
                    v.Add(gh);
            }
            return v.ToArray();
        }

        /*
        /// <summary>
        /// 添加窗体(必须是官方的窗体NCKOLCTE,NCKOLCTETU)
        /// </summary>
        /// <param name="c">新建控件</param>
        public virtual void Add(Control c)
        {
            if (c is NCKOLCTE && c is NCKOLCTETU)
                throw new SmException("必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            ghl.Add(c);

            c.SizeChanged += C_SizeChanged;
            c.LocationChanged += C_LocationChanged;
        }

        public virtual void Remove(Control c)
        {
            if (c is NCKOLCTE && c is NCKOLCTETU)
                throw new SmException("必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            ghl.Remove(c);

            c.SizeChanged -= C_SizeChanged;
            c.LocationChanged -= C_LocationChanged;
        }
        
        

        /// <summary>
        /// 返回这个窗体在横坐标(头)最近控件
        /// </summary>
        /// <param name="c">操控控件</param>
        /// <returns></returns>
        public Control BeginWeightLocationNearest(Control c)
        {
            Point d = c.Location;
            Control vb = null;
            int xl = AsiPosInt + 1;
            foreach (Control k in ghl.ToArray())
            {
                int lastgho = (int)NewMath.AdsoValueAtInt((k.Location.X + k.Width) - c.Location.X);
                if (lastgho <= AsiPosInt)
                {
                    if (lastgho < xl)
                    {
                        xl = lastgho;
                        vb = k;
                    }
                }
            }
            return vb;
        }
        /// <summary>
        /// 返回这个窗体在横坐标(尾)最近控件
        /// </summary>
        /// <param name="c">操控控件</param>
        /// <returns></returns>
        public Control EndWeightLocationNearest(Control c)
        {
            Point d = c.Location;
            Control vb = null;
            int xl = AsiPosInt + 1;
            foreach (Control k in ghl.ToArray())
            {
                int lastgho = (int)NewMath.AdsoValueAtInt(k.Location.X - (c.Location.X + c.Width));
                if (lastgho <= AsiPosInt)
                {
                    if (lastgho < xl)
                    {
                        xl = lastgho;
                        vb = k;
                    }
                }
            }
            return vb;
        }
        /// <summary>
        /// 返回这个窗体在纵坐标(头)最近控件
        /// </summary>
        /// <param name="c">操控控件</param>
        /// <returns></returns>
        public Control BeginHeightLocationNearest(Control c)
        {
            Point d = c.Location;
            Control vb = null;
            int xl = AsiPosInt + 1;
            foreach (Control k in ghl.ToArray())
            {
                int lastgho = (int)NewMath.AdsoValueAtInt((k.Location.Y + k.Height) - c.Location.Y);
                if (lastgho <= AsiPosInt)
                {
                    if (lastgho < xl)
                    {
                        xl = lastgho;
                        vb = k;
                    }
                }
            }
            return vb;
        }
        /// <summary>
        /// 返回这个窗体在纵坐标(尾)最近控件
        /// </summary>
        /// <param name="c">操控控件</param>
        /// <returns></returns>
        public Control EndHeightLocationNearest(Control c)
        {
            Point d = c.Location;
            Control vb = null;
            int xl = AsiPosInt + 1;
            foreach (Control k in ghl.ToArray())
            {
                int lastgho = (int)NewMath.AdsoValueAtInt(k.Location.Y - (c.Location.Y + c.Height));
                if (lastgho <= AsiPosInt)
                {
                    if (lastgho < xl)
                    {
                        xl = lastgho;
                        vb = k;
                    }
                }
            }
            return vb;
        }

        /// <summary>
        /// 获取这个窗体在引索<see cref="FormPanelAsForm"/>中官方窗体位置
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static FormPanelAsForm GetFormType(Control c)
        {
            if (c is NCKOLCTE && c is NCKOLCTETU)
                throw new SmException("必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            if (c is NCKOLCTE)
                return FormPanelAsForm.NCKOLCTE;
            else
                return FormPanelAsForm.NCKOLCTETU;
        }
        /// <summary>
        /// 获取这个窗体的所有子控件
        /// </summary>
        /// <param name="l">一个官方窗体</param>
        /// <returns></returns>
        public static Control[] GetFormControls(Control c)
        {
            if (c is NCKOLCTE && c is NCKOLCTETU)
                throw new SmException("必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            List<Control> v = new List<Control>();

            if (c is NCKOLCTE)
            {
                foreach (Control gh in (c as NCKOLCTE).ShowIn.Controls)
                    v.Add(gh);
            }
            if (c is NCKOLCTETU)
            {
                foreach (Control gh in (c as NCKOLCTETU).ShowIn.Controls)
                    v.Add(gh);
            }
            return v.ToArray();
        }
        /*
        /// <summary>
        /// 合并窗体
        /// </summary>
        /// <param name="l">一个官方窗体/带有官方默认的ListVerCs的官方窗体(统一默认参数)</param>
        /// <param name="f">一个官方窗体</param>
        public void MeshForm(Control l,Control f)
        {
            if (l is NCKOLCTE && l is NCKOLCTETU)
                throw new SmException("l参数:必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            if (f is NCKOLCTE && f is NCKOLCTETU)
                throw new SmException("f参数:必须是官方的窗体NCKOLCTE,NCKOLCTETU");
            ListVebel cdo = null;

            foreach (Control cppl in GetFormControls(l))
            {
                if (cppl is ListVebel)
                {
                    cdo = cppl as ListVebel;
                    break;
                }
            }

            bool isNew = false;

            if (cdo == null)
            {
                cdo = new ListVebel();
                cdo.Name = Name + "." + (ObjectClass<ListVerCs>.GetIndexl.Length - 1);
                if (l is NCKOLCTE)
                {
                    NCKOLCTE tu = new NCKOLCTE();
                    tu.Name = Name + ".FormAt" + tu.IDX;
                    tu.Text = Text + " - " + tu.Text;
                    tu.Location = l.Location;
                    tu.Size = l.Size;

                    tu.AddControl(cdo);
                    w.AddControlInvoke(tu);
                    new Thread(() => { Application.Run(tu); }).Start();
                }
                if (l is NCKOLCTETU)
                {
                    NCKOLCTETU tu = new NCKOLCTETU();
                    tu.Name = Name + ".FormAt" + tu.IDX;
                    tu.Text = Text + " - " + tu.Text;
                    tu.Location = l.Location;
                    tu.Size = l.Size;

                    tu.AddControl(cdo);
                    w.AddControlInvoke(tu);
                    tu.Show();
                }
                isNew = true;
            }

            Panel p = new Panel();
            p.Name = Name + ".panelfp.pci";
            if (isNew)
            {
                Panel pdl = new Panel();
                pdl.Name = Name + ".panelfotl,pci";
                pdl.TextChanged += (object sender, EventArgs e) => { pdl.Text = l.Text; };
                pdl.Text = l.Text;
                pdl.Dock = DockStyle.Fill;
                cdo.AddFormSope(pdl);

                foreach (Control ffhn in GetFormControls(l))
                {
                    pdl.Controls.Add(ffhn);
                }
                pdl.Show();
                if (l is NCKOLCTE)
                {
                    NCKOLCTE tu = l as NCKOLCTE;
                    tu.Hide();
                }
                if (l is NCKOLCTETU)
                {
                    NCKOLCTETU tu = l as NCKOLCTETU;
                    tu.Hide();
                }
            }

            p.TextChanged += (object sender, EventArgs e) => { p.Text = f.Text; };
            p.Text = f.Text;
            p.Dock = DockStyle.Fill;
            cdo.AddFormSope(p);

            foreach (Control ffhn in GetFormControls(f))
            {
                p.Controls.Add(ffhn);
            }
            p.Show();
            if (f is NCKOLCTE)
            {
                NCKOLCTE tu = f as NCKOLCTE;
                tu.Hide();
            }
            if (f is NCKOLCTETU)
            {
                NCKOLCTETU tu = f as NCKOLCTETU;
                tu.Hide();
            }

        }
        private void C_SizeChanged(object sender, EventArgs e)
        {
            Control l = sender as Control;
        }
        private void C_LocationChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        */
        #region Event

        private void T_FormMoving(object sender, ObjectEvent o)
        {
            NCKOLCTETU thisi = sender as NCKOLCTETU;
            if (!thisi.LockWindow) return;
            foreach (FormPanelItems iu in ghl.ToArray())
            {
                if (iu.InNCKOLCTETU == thisi)
                {
                    InRemove(iu, iu.InListVebel.GetFocusForm());
                    break;
                }
            }
        }
        /*
    int pLeft = 0;
    int pTop = 0;
    private void mouseRightForm_MouseMove(object sender, MouseEventArgs e)
    {
        NCKOLCTETU thisi = sender as NCKOLCTETU;
        if (thisi.LockWindow) return;

        if (e.Button.ToString().Equals("Left"))
        {
            //this指的是主窗口生成的对象
            int top = thisi.Location.X + e.X - pLeft;
            int left = thisi.Location.Y + e.Y - pTop;
            if (NewMath.AdsoValueAtInt(top) > AsiPosInt || NewMath.AdsoValueAtInt(left) > AsiPosInt)
            {
                foreach(FormPanelItems iu in ghl.ToArray())
                {
                    if (iu.InNCKOLCTETU == thisi)
                    {
                        InRemove(iu, iu.InListVebel.GetFocusForm());
                        break;
                    }
                }
            }
        }
    }
    private void mouseRightForm_MouseDown(object sender, MouseEventArgs e)
    {
        pLeft = e.X;
        pTop = e.Y;
    }
    */
        #endregion
    }
    /// <summary>
    /// 提供官方窗体名称
    /// </summary>
    public enum FormPanelAsForm
    {
        NCKOLCTE,NCKOLCTETU
    }
    /// <summary>
    /// 融合<see cref="FormPanelItems"/>绑定窗体
    /// </summary>
    public enum FormPanelControlAt
    {
        /// <summary>
        /// 绑定在左边
        /// </summary>
        Left,
        /// <summary>
        /// 绑定在右边
        /// </summary>
        Right,
        /// <summary>
        /// 全局绑定(其他控件就不会参与)
        /// </summary>
        File,
        /// <summary>
        /// 绑定在底部
        /// </summary>
        Bottom,
        /// <summary>
        /// 绑定在顶部
        /// </summary>
        Top
    }
    /// <summary>
    /// 融合官方主要容器
    /// </summary>
    public class FormPanelItems
    {
        /// <summary>
        /// 新建容器
        /// </summary>
        public FormPanelItems()
        {
            AddInNCKOLCTE = new List<NCKOLCTE>();
            AddInNCKOLCTETU = new List<NCKOLCTETU>();
        }
        /// <summary>
        /// 控件统一名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 控件在声明默认大小
        /// </summary>
        public Size Size { get; set;}
        /// <summary>
        /// 控件在声明默认位置
        /// </summary>
        public Point Loaction { get; set; }
        /// <summary>
        /// 配合AI优先绑定
        /// </summary>
        public FormPanelItems Dock { get; set; }

        /// <summary>
        /// 新建在<see cref="NCKOLCTE"/>中的容器
        /// </summary>
        public List<NCKOLCTE> AddInNCKOLCTE { get; set; }
        /// <summary>
        /// 新建在<see cref="NCKOLCTETU"/>中的容器
        /// </summary>
        public List<NCKOLCTETU> AddInNCKOLCTETU { get; set; }
        /// <summary>
        /// 这个所在的容器<para>通常是<see cref="FormPanelControl"/>声明</para>
        /// </summary>
        public NCKOLCTETU InNCKOLCTETU { get; set; }
        /// <summary>
        /// 这个所在的容器列表<para>通常是<see cref="FormPanelControl"/>声明</para>
        /// </summary>
        public TitlePanel InListVebel { get; set; }
    }
}
