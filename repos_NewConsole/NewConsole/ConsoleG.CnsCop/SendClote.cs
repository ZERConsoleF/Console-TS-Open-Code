using ConsoleG.Network;
using ConsoleG.Network.Server;
using RunLCJVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.SmProPub.Event;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.CnsCop
{
    /// <summary>
    /// 示范的发送者
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class SendClote : SendClass
    {
        public virtual string SQP { get; set; }
        public virtual string RunFs { get; set; }
        public virtual byte[] BK { get; set; }
        /// <summary>
        /// 其他说明
        /// </summary>
        public virtual string ETCOther { get; set; }
        /// <summary>
        /// 来自服务器的基础信息
        /// </summary>
        public virtual ServerBackAs MSWE { get; set; }
        /// <summary>
        /// 服务器返回，指导操控者
        /// </summary>
        public virtual string ReturnLess { get; set; }

        public virtual void Execute()
        {
        }
        /// <summary>
        /// 执行权限(0开始)
        /// </summary>
        /// <returns></returns>
        public virtual int SetLevel()
        {
            return 0;
        }

        /// <summary>
        /// 当服务器发送服务时数据下载情况
        /// </summary>
        public event ObjectEventArg DownLoadP03;
        /// <summary>
        /// 在MSFW重新写入时触发
        /// </summary>
        public event ObjectEventArg RefMSWE;
    }
}
