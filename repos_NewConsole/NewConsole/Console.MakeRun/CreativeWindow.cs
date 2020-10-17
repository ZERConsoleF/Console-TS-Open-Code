using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SmProPub.MakeRun
{
    /// <summary>
    /// 新建窗体使用
    /// </summary>
    public interface CreativeWindow
    {
        /// <summary>
        /// 获取他在视图栏中的程序名称
        /// </summary>
        /// <returns></returns>
        string GetMenuName();
        /// <summary>
        /// 是否只能创建一次
        /// </summary>
        /// <returns></returns>
        bool GetCreativeOne();
        /// <summary>
        /// 创建一个子项，将他放在此
        /// </summary>
        /// <returns></returns>
        string MenuEtc();
        /// <summary>
        /// 菜单的项图标
        /// </summary>
        /// <returns></returns>
        Image ImageMenuName();
        /// <summary>
        /// 子项图标(可以重复设置，但无法取消)
        /// </summary>
        /// <returns></returns>
        Image ImageMentEtc();
        /// <summary>
        /// 在添加时执行此事件
        /// </summary>
        void RunException();
        /// <summary>
        /// 创建标题时的名称
        /// </summary>
        /// <returns></returns>
        string CreativeText();
    }
}
