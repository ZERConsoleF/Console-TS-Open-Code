using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Core.com
{
    /// <summary>
    /// SmPro Console,SmProPub和ConsoleG控制台程序的常量值
    /// </summary>
    public static class SmProConst
    {
        /// <summary>
        /// 内存名称
        /// </summary>
        public static string GetMainMemoryName { get { return "LoadSmPro"; } }
        /// <summary>
        /// 程序的标签标识
        /// </summary>
        public static string GetMainArgName { get { return "mainarg"; } }
        /// <summary>
        /// 在程序中的公用内存分配名字
        /// </summary>
        public static string GetPublicMemoryName { get { return "publicname"; } }
        /// <summary>
        /// 菜单内存标识
        /// </summary>
        public static string GetMenuMemoryName { get { return "meunlt"; } }
        /// <summary>
        /// 获取主线程标识
        /// </summary>
        public static string GetThreadMainName { get { return "Client Run"; } }
        /// <summary>
        /// 获取系统临时储存
        /// </summary>
        public static string GetPathTempSave { get { return Path.GetTempPath() + "/$SeeMods.Temp.Cleart/"; } }
        /// <summary>
        /// 获取连接默认端口
        /// </summary>
        public static int GetSocketPort { get { return 4563; } }
        /// <summary>
        /// 获取服务器Name默认名称
        /// </summary>
        public static string GetServerSockName { get { return "Server AP"; } }
    }
}
