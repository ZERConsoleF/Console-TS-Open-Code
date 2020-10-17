using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SmProPub;

namespace SmPro.System
{
    /// <summary>
    /// 用于创建Window Form窗口
    /// </summary>
    public class FormMenu : ObjectClass<FormMenu>
    {
        public FormMenu()
        {
            IDX = SaveInMemory(this);
            CheckForms = new List<Control>();
        }
        /// <summary>
        /// 搜索在包中的窗体，如果没有则创建
        /// </summary>
        /// <typeparam name="T">窗体类型</typeparam>
        /// <param name="packname">准备新建包的名称</param>
        /// <param name="nameplacer">包中窗体名称</param>
        /// <param name="arg">标签</param>
        /// <returns></returns>
        public static Control CatchOrCreativePackControl<T>(string packname,string nameplacer,string arg)
        {
            int di = 0;
        J:
            if (di >= 3)
            {
                throw new SmException("包可以被正常启动，但窗体尝试3次无法捕获");
            }
            Control i = null;
            if (ObjectClass<T>.GetIndexl != null)
                foreach (T w in ObjectClass<T>.GetIndexl)
                {
                    if ((w as Control).Name == nameplacer)
                    {
                        i = w as Control;
                        break;
                    }
                }
            if (i == null)
            {
                foreach (FormMenu fu in GetIndexl)
                {
                    if (fu.PackName == packname)
                    {
                        fu.Arg = arg;
                        fu.ObjectClassArgL();
                        di++;
                        goto J;
                    }
                }
            }
            return i;
        }
        /// <summary>
        /// 搜索包
        /// </summary>
        /// <param name="packname">包名称</param>
        /// <returns></returns>
        public static FormMenu CatchPackName(string packname)
        {
            FormMenu m = null;
            foreach (FormMenu fu in GetIndexl)
            {
                if (fu.PackName == packname)
                {
                    m = fu;
                }
            }
            return m;
        }
        /*
        /// <summary>
     /// Save To Memory
     /// </summary>
        public new static FormMenu[] GetIndexl { get; set; }
        /// <summary>
        /// Save In Program
        /// </summary>
        /// <param name="obj"></param>
        public new void SaveInMemory(FormMenu obj)
        {
            if (GetIndexl == null)
            {
                List<FormMenu> Inv = new List<FormMenu>();
                IDX = 0;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
            else
            {
                List<FormMenu> Inv = new List<FormMenu>(GetIndexl);
                IDX = Inv.Count;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
        }
        */
        /// <summary>
        /// 通过PackName搜索
        /// </summary>
        /// <param name="packname"></param>
        /// <returns></returns>
        public static FormMenu SearchInPackName(string packname)
        {
            if (GetIndexl != null)
                foreach (FormMenu f in GetIndexl)
                {
                    if (f.PackName == "Console static")
                    {
                        return f;
                    }
                }
            return null;
        }
        /// <summary>
        /// 参数设计
        /// </summary>
        public virtual string Arg { get; set; }
        /// <summary>
        /// 包名称(null则显示在主菜单上)
        /// </summary>
        public virtual string Package { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public virtual string PackName { get; set; }
        /// <summary>
        /// 显示的图像
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// 是否只能创建一个
        /// </summary>
        public virtual bool YNCheck { get; set; }
        /// <summary>
        /// 当前是否单击
        /// </summary>
        public virtual bool Check { get; set; }
        /// <summary>
        /// 绑定的Control窗体
        /// </summary>
        public virtual Control CheckForm { get; set; }
        /// <summary>
        /// 在这个分配中任意挑选
        /// </summary>
        public virtual List<Control> CheckForms { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public virtual string Type { get; set; }
        /// <summary>
        /// CPP SD
        /// </summary>
        public ObjectClassArg ObjectClassArgL { get; set; }
    }
}
