using RunLCJVM.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmPro.System
{
    /// <summary>
    /// 新建菜单栏视图
    /// </summary>
    public class MenuPackage
    {
        MainWindow main;
        /// <summary>
        /// 新建服务
        /// </summary>
        public MenuPackage(MainWindow main)
        {
            this.main = main;
        }
        List<MenuSubTitle> s_menu = new List<MenuSubTitle>();

        /// <summary>
        /// 引索标题值数
        /// </summary>
        /// <param name="idx">一个整数且不超过值的数</param>
        /// <returns>标题容器</returns>
        public MenuSubTitle this[int idx] { get { return s_menu[idx]; } set { s_menu[idx] = value; } }
        /// <summary>
        /// 当前编辑的标题总数值
        /// </summary>
        public int Lenght { get { return s_menu.Count; } }
        /// <summary>
        /// 把菜单转化为<see cref="MenuPackage"/><para>(注意)会清空现有的编辑菜单</para>
        /// </summary>
        public void MakeToMenu()
        {
            s_menu.Clear();
            foreach (ToolStripItem it in main.menusp.Items)
            {
                MenuSubTitle tyu = new MenuSubTitle();
                tyu.ChoseTools = it;
                if (it is ToolStripMenuItem)
                {
                    foreach (ToolStripItem utyt in ((ToolStripMenuItem)it).DropDownItems)
                    {
                        tyu.SubItem.Add(makemmenu(utyt));
                    }
                }
                s_menu.Add(tyu);
            }
        }
        /// <summary>
        /// 应用到菜单<para>(注意)会清空现有的菜单</para>
        /// </summary>
        public void WriteObject()
        {
            main.menusp.Items.Clear();
            List<ToolStripItem> items = new List<ToolStripItem>();
            foreach (MenuSubTitle ity in s_menu)
            {
                if (ity.ChoseTools is ToolStripMenuItem)
                {
                    List<ToolStripItem> iye = new List<ToolStripItem>();
                    foreach (MenuSubItem iytr in ity.SubItem)
                    {
                        iye.Add(makememus(iytr));
                    }
                    ((ToolStripMenuItem)ity.ChoseTools).DropDownItems.AddRange(iye.ToArray());
                }
                items.Add(ity.ChoseTools);
            }
            main.menusp.Items.AddRange(items.ToArray());
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu">添加的菜单标题</param>
        public void Add(MenuSubTitle menu)
        {
            s_menu.Add(menu);
        }
        /// <summary>
        /// 移除菜单
        /// </summary>
        /// <param name="menu">移除的菜单标题</param>
        public void Remove(MenuSubTitle menu)
        {
            s_menu.Remove(menu);
        }
        /// <summary>
        /// 添加菜单组
        /// </summary>
        /// <param name="menu"></param>
        public void AddRange(MenuSubTitle[] menu)
        {
            s_menu.AddRange(menu);
        }
        /// <summary>
        /// 获取编辑列表
        /// </summary>
        /// <returns>一个<see cref="List{T}"/>的值</returns>
        public List<MenuSubTitle> GetMenus()
        {
            return s_menu;
        }

        private MenuSubItem makemmenu(ToolStripItem it)
        {
            MenuSubItem i = new MenuSubItem();
            i.ChoseTools = it;
            if (it is ToolStripMenuItem)
            {
                foreach (ToolStripItem utyt in ((ToolStripMenuItem)it).DropDownItems)
                {
                    i.SubItem.Add(makemmenu(utyt));
                }
            }
            return i;
        }
        private ToolStripItem makememus(MenuSubItem it)
        {
            ToolStripItem item = it.ChoseTools;
            if (item is ToolStripMenuItem)
            {
                List<ToolStripItem> iye = new List<ToolStripItem>();
                foreach (MenuSubItem iytr in it.SubItem)
                {
                    iye.Add(makememus(iytr));
                }
                ((ToolStripMenuItem)item).DropDownItems.AddRange(iye.ToArray());
            }
            return item;
        }
    }
    /// <summary>
    /// 新建在菜单的菜单栏标题
    /// </summary>
    public class MenuSubTitle
    {
        public MenuSubTitle()
        {
            ChoseTools = new ToolStripMenuItem();
            SubItem = new List<MenuSubItem>();
        }
        /// <summary>
        /// 绑定的控件
        /// </summary>
        public virtual ToolStripItem ChoseTools { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get { return ChoseTools.Name; } set { ChoseTools.Name = value; } }
        /// <summary>
        /// 显示文本
        /// </summary>
        public virtual string Text { get { return ChoseTools.Text; } set { ChoseTools.Text = value; } }
        /// <summary>
        /// 新建的子项
        /// </summary>
        public List<MenuSubItem> SubItem { get; set; }
    }
    /// <summary>
    /// 新建的运行说明
    /// </summary>
    public delegate void RunItemSunOryt();
    /// <summary>
    /// 新建窗体子项
    /// </summary>
    public class MenuSubItem
    {
        public MenuSubItem()
        {
            ChoseTools = new ToolStripMenuItem();
            SubItem = new List<MenuSubItem>();
        }
        /// <summary>
        /// 绑定的控件
        /// </summary>
        public virtual ToolStripItem ChoseTools { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get { return ChoseTools.Name; } set { ChoseTools.Name = value; } }
        /// <summary>
        /// 显示文本
        /// </summary>
        public virtual string Text { get { return ChoseTools.Text; } set { ChoseTools.Text = value; } }
        /// <summary>
        /// 新建的子项
        /// </summary>
        public List<MenuSubItem> SubItem { get; set; }
    }
    /// <summary>
    /// 在<see cref="MenuPackage"/>操作的<see cref="ToolStripSeparator"/>
    /// </summary>
    public class MenuSubSeparator : MenuSubItem
    {
        public MenuSubSeparator()
        {

            ChoseTools = new ToolStripSeparator();
            SubItem = new List<MenuSubItem>();
        }
    }
}
