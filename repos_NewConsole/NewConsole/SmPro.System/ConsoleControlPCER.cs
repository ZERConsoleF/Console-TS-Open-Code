using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmPro.System
{
    /// <summary>
    /// Console记录
    /// </summary>
    public sealed class ConsoleControlPCER
    {
        /// <summary>
        /// 获取所有记录控制台
        /// </summary>
        public static ConsoleControlPCER[] GetConsoles { get { return takedown.ToArray(); } }
        private static List<ConsoleControlPCER> takedown = new List<ConsoleControlPCER>();
        /// <summary>
        /// 移除记录
        /// </summary>
        /// <param name="obj">obj记录点</param>
        public static void Remove(ConsoleControlPCER obj)
        {
            takedown.Remove(obj);
        }
        
        /// <summary>
        /// 添加控制台记录事件，并创建新的ConEvent
        /// </summary>
        /// <param name="t">记录pr</param>
        public ConsoleControlPCER(Thread t)
        {
            GetThread = t;
        }
        /// <summary>
        /// name获取
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取控制台所在线程
        /// </summary>
        public Thread GetThread { get; private set; }
        /// <summary>
        /// 决定控制台输出
        /// </summary>
        public string ConsoleShowWrite { get; set; }
        /// <summary>
        /// 强制改变线程
        /// </summary>
        /// <param name="t">改变后的线程</param>
        [Obsolete("注意！强制改变线程会导致当前线程的错误释放！")]
        public void ChangeThread(Thread t)
        {
            GetThread = t;
        }
    }
}
