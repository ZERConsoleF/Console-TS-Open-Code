using ConsoleG.Network;
using ConsoleG.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.CnsCop
{
    /// <summary>
    /// 执行连接命令
    /// </summary>
    public class CnsCop
    {
        /// <summary>
        /// 操控端
        /// </summary>
        public NewConsoleNetCY Infect { get; set; }
        /// <summary>
        /// 将创建基类
        /// </summary>
        /// <param name="cy">一个被成功连接的连接端</param>
        public CnsCop(NewConsoleNetCY cy)
        {
            Infect = cy;
            Infect.SenderByteCY += Infect_SenderByteCY;
        }

        /// <summary>
        /// 检查是否登录
        /// </summary>
        public bool LogUp { get => Infect.LogUped; }
        /// <summary>
        /// 发送类，在服务器执行
        /// </summary>
        public SendClote SendClass { get; set; }
        /// <summary>
        /// 返回的Byte
        /// </summary>
        public byte[] RetureOver { get; set; }
        /// <summary>
        /// 返回的结果
        /// </summary>
        public SendClote ReturnClass { get; set; }
        /// <summary>
        /// 转化最后发送结果的操作类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetTRetureFS<T>()
        {
            return Class<T>.Deserialize(RetureOver);
        }
        #region
        /// <summary>
        /// 把类提交给服务器执行
        /// </summary>
        public void SendClassFor()
        {
            byte[] dc = Class<SendClote>.Serialize(SendClass);
            Infect.Sender(dc);
        }
        #endregion

        #region
        private void Infect_SenderByteCY(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            ServerSenderOveEvent on = (ServerSenderOveEvent)o;
            byte[] cp = on.SenderOver;
            RetureOver = cp;
            ReturnClass = GetTRetureFS<SendClote>();
            if (RetureSender != null)
                RetureSender(this, new ObjectEvent());
        }
        #endregion
        #region
        /// <summary>
        /// 当返回结果触发(sender为this)
        /// </summary>
        public event ObjectEventArg RetureSender;
        #endregion
    }
}
