using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.SmProPub.Event;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network
{
    /// <summary>
    /// Event传输
    /// </summary>
    public class NewSocketABEvent : ObjectEvent
    {
        /// <summary>
        /// 每秒钟发送(接收)的长度
        /// </summary>
        public long ByteSender { get; set; }
        /// <summary>
        /// 全部总字节
        /// </summary>
        public long AllByte { get; set; }
        /// <summary>
        /// 已传输字节
        /// </summary>
        public long ByteSended { get; set; }
        /// <summary>
        /// 传输百分比
        /// </summary>
        public double SenderPres { get; set; }
        /// <summary>
        /// 完成传输
        /// </summary>
        public bool Finish { get; set; }
        /// <summary>
        /// 获取返回的服务器操控类
        /// </summary>
        public ServerBackAs AsB { get; set; }
        /// <summary>
        /// 缓冲字节大小
        /// </summary>
        public int ASBtye { get; set; }
        /// <summary>
        /// 处理返回结果
        /// </summary>
        public ServerBackAs ServerBackAs { get; set; }
        /// <summary>
        /// 是接收还是发送(<see langword="true"/>接收,<see langword="false"/>发送)
        /// </summary>
        public bool SenderRivice { get; set; }
    }
    /// <summary>
    /// 在发送无效指定的计划关闭
    /// </summary>
    public class NetWorkExceptionClosed : ObjectEvent
    {
        /// <summary>
        /// 获取触发事件的连接点
        /// </summary>
        public IPEndPoint IPAddress { get; set; }
    }
    /// <summary>
    /// 当指定用户关闭连接时
    /// </summary>
    public class NewWorkServerClosed : ObjectEvent
    {
        /// <summary>
        /// 获取触发事件的连接点
        /// </summary>
        public IPEndPoint IPAddress { get; set; }
    }
}
