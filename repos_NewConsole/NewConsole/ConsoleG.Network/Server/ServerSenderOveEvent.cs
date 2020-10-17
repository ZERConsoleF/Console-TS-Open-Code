using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.SmProPub.Event;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.Server
{
    /// <summary>
    /// 处理发送的数据
    /// </summary>
    public class ServerSenderOveEvent : ObjectEvent
    {
        /// <summary>
        /// 发送的数据包
        /// </summary>
        public byte[] SenderOver { get; set; }
        /// <summary>
        /// 发送者
        /// </summary>
        public Socket Sender { get; set; }
        /// <summary>
        /// 发送者位于服务器的区块
        /// </summary>
        public int SenderList { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SenderTime { get; set; }
    }
    /// <summary>
    /// 当这个IP连接登录时
    /// </summary>
    public class ServerSenderAdd : ObjectEvent
    {
        /// <summary>
        /// 发送者
        /// </summary>
        public Socket Sender { get; set;}
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LogUp { get; set; }
        /// <summary>
        /// 它的证书
        /// </summary>
        public ServerIns InsSP { get; set; }
        /// <summary>
        /// 在服务器位置
        /// </summary>
        public int Index { get; set; }

    }
}
