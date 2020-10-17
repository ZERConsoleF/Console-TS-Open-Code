using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.SmProPub.ExClass;
using System.SmProPub.Event;

namespace SmProPub.Window.Forms.UsersControl
{
    public partial class SetWindowControl : UserControl
    {
        public SetWindowControl()
        {
            InitializeComponent();
            ObjectClass<SetWindowControl> o = new ObjectClass<SetWindowControl>();
            o.SaveInMemory(this);
            Disposed += SetWindowControl_Disposed;
            PutSaveButtonInControl = true;
            SaveButtonToRightButtom = new Point(5, 5);
            ShowList.CheckColor = Color.Aqua;
            ShowList.ReadlyCheckColor = Color.AliceBlue;
        }
        /// <summary>
        /// 获取ShowList
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("获取ShowList")]
        public ListVerCs GetListVerCs { get { return ShowList; } }
        /// <summary>
        /// 获取主显示容器大小
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("获取主显示容器大小")]
        public Size ShowPP { get => ShowPanel.Size; set => ShowPanel.Size = value; }
        /// <summary>
        /// 获取项目
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("获取项目")]
        public SubItemVer[] GetSubItemVer { get { return subItemVers.ToArray(); } }
        /// <summary>
        /// 获取项目解释窗口
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(false)]
        [Description("获取项目解释窗口")]
        public Panel GetPanelShow { get { return ShowComment; } }
        /// <summary>
        /// 是否放置SaveButton按钮
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(true)]
        [Description("是否放置SaveButton按钮")]
        public bool PutSaveButtonInControl { get; set; }
        /// <summary>
        /// 按钮距离右下角的距离
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue(true)]
        [Description("按钮距离右下角的距离")]
        public Point SaveButtonToRightButtom { get; set; }
        /// <summary>
        /// 按钮的文本
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue("Save")]
        [Description("按钮的文本")]
        public string SaveButtonText { get; set; }
        /// <summary>
        /// 当点击Save按钮时<para><see cref="ButtonSave"/>类型</para>
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [Category("AppearanceEvent")]
        [DefaultValue("Save")]
        [Description("当点击Save按钮时")]
        public event ObjectEventArg CheckSaveButtoned;

        private List<SubItemVer> subItemVers = new List<SubItemVer>();
        private Control ddf;

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="v">项目Devt</param>
        public void AddItem(SubItemVer v)
        {
            
            if (v.HasHandle)
            {
                throw new SmException("无法对已处理的消息进行操控,控件被锁定!");
            }
            /*
            if (v.Control == null)
            {
                throw new SmException("SubItemVer.Control为null");
            }
            */
            v.MakeIn();

            ItemListCs ff = new ItemListCs();

            ff.Text = v.Text;
            ff.Name = v.Name;
            ff.Hight = 5;

            ShowList.AddItem(ff, null);

            subItemVers.Add(v);
            ShowPanel.Controls.Add(v.Control);
            if (ddf != null)
                ddf.Hide();
            ddf = v.Control;
            ddf.Show();
            if (PutSaveButtonInControl)
            {
                Button b = new Button();
                b.Name = v.Name + ".buttonEr";
                b.Text = SaveButtonText;
                b.AutoSize = true;
                ddf.Height += b.Height + SaveButtonToRightButtom.Y;
                b.Location = new Point(ddf.Width - b.Width - SaveButtonToRightButtom.X, ddf.Height - b.Height - SaveButtonToRightButtom.Y);
                ddf.Controls.Add(b);
                b.Click += B_Click;
                v.SaveButton = b;
                b.Show();
            }
        }
        /// <summary>
        /// 移除项目
        /// </summary>
        /// <param name="v"></param>
        public void RemoveItem(SubItemVer v)
        {
            int f = -1;
            foreach(SubItemVer ffgt in subItemVers)
            {
                f++;
                if (ffgt == v)
                    break;
            }
            subItemVers.Remove(v);
            v.Control.Dispose();
            ShowList.RemoveItem(new int[] { f }, true);
        }

        private void B_Click(object sender, EventArgs e)
        {
            SubItemVer v = null;

            foreach(SubItemVer vg in GetSubItemVer)
            {
                if (vg.SaveButton == sender)
                {
                    v = vg;
                    break;
                }
            }
            if (v != null && CheckSaveButtoned != null)
            {
                ButtonSave h = new ButtonSave();
                h.GetItemVer = v;
                CheckSaveButtoned(this, h);
            }
        }

        private void SetWindowControl_Disposed(object sender, EventArgs e)
        {
            ObjectClass<SetWindowControl>.DisopseInMemory(this);
        }

        private void ShowList_ClickItem(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            ItemListCs c = ShowList.GetCheckItem();
            if (c != null)
            {
                int[] fs = ShowList.FindThisItem(c, null);
                if (fs.Length > 0)
                {
                    int f = fs[0];

                    SubItemVer v = subItemVers[f];
                    if (ddf != null)
                    {
                        ddf.Hide();
                    }
                    ddf = v.Control;
                    ddf.Show();
                }
            }
        }
    }
    public class ButtonSave : ObjectEvent
    {
        public SubItemVer GetItemVer { get; set; }

    }
    /// <summary>
    /// 项目新建总称
    /// </summary>
    public class SubItemVer
    {
        public SubItemVer()
        {
            GetSetSubItemPanels = new List<SubItemPanel>();
            GetSetLocationInc = 5;
        }
        /// <summary>
        /// 窗体总控件
        /// </summary>
        public Panel Control { get; set; }
        /// <summary>
        /// 获取SaveButton
        /// </summary>
        public Button SaveButton { get; set; }
        /// <summary>
        /// 窗体名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 获取设置设置容器
        /// </summary>
        public List<SubItemPanel> GetSetSubItemPanels { get; set; }
        /// <summary>
        /// 已处理
        /// </summary>
        public bool HasHandle { get; protected set; }
        /// <summary>
        /// 窗体空格大小
        /// </summary>
        public int GetSetLocationInc { get; set; }
        /// <summary>
        /// 制造控件
        /// </summary>
        public void MakeIn()
        {
            int lo = 0;
            int si = GetSetLocationInc;
            HasHandle = true;
            Control = new Panel();
            Control.AutoScroll = true;
            Control.Dock = DockStyle.Fill;
            Control.Text = Text;
            Control.Name = Name;

            foreach (SubItemPanel p in GetSetSubItemPanels)
            {
                Control c = p.GetSetControl;
                c.Location = new Point(GetSetLocationInc, si);
                Control.Controls.Add(c);
                si += c.Height + GetSetLocationInc;
            }
        }
    }
    /// <summary>
    /// 项目控件添加
    /// </summary>
    public class SubItemPanel
    {
        /// <summary>
        /// 获取或设置子项容器新建
        /// </summary>
        public virtual Control GetSetControl { get; set; }
        /// <summary>
        /// 控件文本
        /// </summary>
        public virtual string Text { get; set; }
        /// <summary>
        /// 控件新建名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 控件大小
        /// </summary>
        public virtual Size Size { get; set; }
        /// <summary>
        /// 控件移动位置
        /// </summary>
        public virtual int LocationPPC { get; set; }
        /// <summary>
        /// 获取是否是子项
        /// </summary>
        public virtual SubItemType SubItemType { get; set; }
    }
    /// <summary>
    /// 获取类型
    /// </summary>
    public enum SubItemType
    {
        Title,Sub,SubNormal
    }
    /// <summary>
    /// 项目<see cref="Label">的处理
    /// </summary>
    public class SunItemLabel : SubItemPanel
    {
        public SunItemLabel()
        {
            GetSetControl = new Label();
            SubItemType = SubItemType.Title;
            GetSetControl.Font = new Font("默认字体", 32);
        }
        public override Size Size { get => GetSetControl.Size; set => GetSetControl.Size = value; }
        public override string Name { get => GetSetControl.Name; set => GetSetControl.Name = value; }
        public override string Text { get => GetSetControl.Text; set => GetSetControl.Text = value; }
    }
    public class SunItemButton : SubItemPanel
    {
        public SunItemButton()
        {
            GetSetControl = new Button();
        }
        public override Size Size { get => GetSetControl.Size; set => GetSetControl.Size = value; }
        public override string Text { get => GetSetControl.Text; set => GetSetControl.Text = value; }
        public override string Name { get => GetSetControl.Name; set => GetSetControl.Name = value; }
    }
    public class SunItemTextBox : SubItemPanel
    {
        public SunItemTextBox()
        {
            GetSetControl = new TextBox();
        }
        public override Size Size { get => GetSetControl.Size; set => GetSetControl.Size = value; }
        public override string Text { get => GetSetControl.Text; set => GetSetControl.Text = value; }
        public override string Name { get => GetSetControl.Name; set => GetSetControl.Name = value; }
    }
    public class SunItemList : SubItemPanel
    {
        public SunItemList()
        {
            GetSetControl = new ListVerList();
        }
        public override Size Size { get => GetSetControl.Size; set => GetSetControl.Size = value; }
        public override string Text { get => GetSetControl.Text; set => GetSetControl.Text = value; }
        public override string Name { get => GetSetControl.Name; set => GetSetControl.Name = value; }
    }
}
