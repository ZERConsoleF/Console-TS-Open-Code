using RunLCJVM.Window;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleG.WindowG
{
    /// <summary>
    /// 获取NewConsole窗体的菜单名单
    /// </summary>
    public class FindMainWindowMenu
    {
        MainWindow cp;
        ToolStripMenuItem[] pw;
        ToolStripMenuItem repo;
        List<ToolStripMenuItem> tcx = new List<ToolStripMenuItem>();
        public FindMainWindowMenu(MainWindow w)
        {
            if (w == null)
            {
                throw new SmException("NewWindow不可为null","null -> Denull",-10241,"0xc410547","null <- NewClass");
            }
            cp = w;
            StartFind();
        }
        /// <summary>
        /// 查找/结果(替换)
        /// </summary>
        public void StartFind()
        {
            List<ToolStripMenuItem> p = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem ui in cp.menusp.Items)
            {
                p.Add(ui);
            }
            pw = p.ToArray();
            repo = null;
            tcx.Clear();
        }
        /// <summary>
        /// 从窗体取得Menu
        /// </summary>
        /// <param name="idx"></param>
        public void SetAMenu(int idx)
        {
            repo = pw[idx];
            tcx.Add(repo);
        }
        /// <summary>
        /// 子项引索子项
        /// </summary>
        /// <param name="idx"></param>
        public void SetSubMenu(int idx)
        {
            repo = (ToolStripMenuItem)repo.DropDownItems[idx];
            tcx.Add(repo);
        }
        /// <summary>
        /// 返回当前子项
        /// </summary>
        /// <returns></returns>
        public ToolStripMenuItem BackMenu()
        {
            return repo;
        }
        /// <summary>
        /// 返回套娃的项
        /// </summary>
        /// <returns></returns>
        public ToolStripMenuItem[] BackSubLenth()
        {
            return tcx.ToArray();
        }
        /// <summary>
        /// 返回一级
        /// </summary>
        public void BackSub()
        {
            tcx.Remove(repo);
            repo = tcx[tcx.Count - 1];
        }
    }
}
