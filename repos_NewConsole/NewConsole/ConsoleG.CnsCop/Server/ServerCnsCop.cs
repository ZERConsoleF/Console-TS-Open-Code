using ConsoleG.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.CnsCop.Server
{
    /// <summary>
    /// 服务器执行操作
    /// </summary>
    public class ServerCnsCop
    {
        /// <summary>
        /// 服务器连接端(记录)
        /// </summary>
        private List<ServerSenderOveEvent> sp = new List<ServerSenderOveEvent>();

        private void MW()
        {
            SpWriteSg = 1000;
        }
        #region
        /// <summary>
        /// 是否开启写入
        /// </summary>
        public bool GetSetWriteSp { get; protected set; }
        /// <summary>
        /// 记录记录，超过这个数则读取并清空
        /// </summary>
        public long SpWriteSg { get; set; }
        #endregion

        public NewConsoleNetSr Infect { get; set; }
        public ServerCnsCop(NewConsoleNetSr sr)
        {
            Infect = sr;
            Infect.SenderByte += Infect_SenderByte1;
        }

        /// <summary>
        /// 设置记录写入
        /// </summary>
        public void SetWrite()
        {
            Infect.SenderByte += Infect_SenderByte;
            GetSetWriteSp = true;
        }
        /// <summary>
        /// 拒绝记录写入
        /// </summary>
        public void ReWrite()
        {
            Infect.SenderByte -= Infect_SenderByte;
            GetSetWriteSp = false;
        }

        /// <summary>
        /// 指定发送者发送数据到服务端
        /// </summary>
        /// <param name="sk"></param>
        /// <param name="cp"></param>
        public void SendP(Socket sk, SendClote cp)
        {
            Infect.Send(sk, Class<SendClote>.Serialize(cp));
        }

        private void Infect_SenderByte1(object sender, ObjectEvent o)
        {
            ServerSenderOveEvent p = (ServerSenderOveEvent)o;
            if (GetSenderLp != null)
            {
                GetSenderLp(Class<SendClote>.Deserialize(p.SenderOver), p);
            }
        }

        private void Infect_SenderByte(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            ServerSenderOveEvent u = (ServerSenderOveEvent)o;
            sp.Add(u);
            if (SpWriteSg <= sp.LongCount())
            {
                if (GetTakeDown != null)
                    GetTakeDown(sp,new ObjectEvent());
                sp.Clear();
            }
        }

        /// <summary>
        /// 获取溢出日志
        /// </summary>
        public event ObjectEventArg GetTakeDown;
        /// <summary>
        /// 获取发送者发来的消息(this为SendClote)
        /// </summary>
        public event ObjectEventArg GetSenderLp;
    }
}
