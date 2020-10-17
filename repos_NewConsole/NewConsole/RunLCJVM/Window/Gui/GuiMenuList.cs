using ConsoleG.Core.com.setting;
using RunLCJVM.Window.TsIm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunLCJVM.Window.Gui
{
    public class GuiMenuList
    {

        /// <summary>
        /// 返回当前是第几个，没有为-1
        /// </summary>
        public int returnIndex { get { return path.Count - 1; } }
        public string lauge = "";
        private List<MenuCreat> cy = new List<MenuCreat>();
        private MenuCreat ct = new MenuCreat();
        private List<MenuCreat> path = new List<MenuCreat>();
        /// <summary>
        /// 序列化GuiMenuList
        /// </summary>
        public GuiMenuList(string lauge)
        {
            this.lauge = lauge;
            ct.menuCreats = new List<MenuCreat>();
            path.Add(ct);
        }

        /// <summary>
        /// 搜寻在此列表出现的值，没有则创建一个
        /// </summary>
        /// <param name="name"></param>
        public GuiMenuList CreatReadPath(string name)
        {
            foreach (MenuCreat cui in ct.menuCreats.ToArray())
            {
                if (cui.name.ToLower() == name.ToLower())
                {
                    if (!path.Contains(cui))
                        path.Add(cui);
                    ct = cui;
                    return this;
                }
            }
            MenuCreat vc = new MenuCreat();
            vc.name = name;
            vc.text = FanYi.frome(vc.name,lauge);
            vc.menuCreats = new List<MenuCreat>();
            path.Add(ct);
            ct = vc;

            return this;
        }
        /// <summary>
        /// 返回上一级，如果是上一级则忽略
        /// </summary>
        /// <returns></returns>
        public GuiMenuList BackList()
        {
            if (path.Count > 1)
            {
                int endl = path.Count - 1;
                MenuCreat cop = path.ToArray()[endl];
                cop.menuCreats.Add(ct);
                ct = cop;
                path.Remove(cop);
            }

            return this;
        }
        /// <summary>
        /// 返回一个设置
        /// </summary>
        /// <returns></returns>
        public MenuCreat returnSetMenu()
        {
            return ct;
        }
        /// <summary>
        /// 设置设置
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public GuiMenuList setSetMenu(MenuCreat ci)
        {
            ct = ci;
            return this;
        }
        /// <summary>
        /// 封装它
        /// </summary>
        /// <returns></returns>
        public MenuCreat ToArray()
        {
            for (int x = path.Count; x >= 0; x--)
            {
                BackList();
            }
            return ct;
        }
    }
}
