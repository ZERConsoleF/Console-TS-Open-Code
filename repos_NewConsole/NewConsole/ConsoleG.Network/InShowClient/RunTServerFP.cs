using ConsoleG.Network.Server;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleG.Network.InShowClient
{
    /// <summary>
    /// 对服务器新建查询
    /// </summary>
    public class RunTServerFP
    {
        NewConsoleNetCY p;
        /// <summary>
        /// 新建查询
        /// </summary>
        /// <param name="cy">服务器必须是连接状态，否则无效</param>
        public RunTServerFP(NewConsoleNetCY cy)
        {
            if (!cy.LogUped)
                throw new SmException("服务器连接失败，查询失败");
            p = cy;
            //p.AutuoRevice();
            //p.SenderByteCY += P_SenderByteCY;
        }


        private void P_SenderByteCY(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            /*
                ServerSenderOveEvent e = (ServerSenderOveEvent)o;
                GetBackTime = DateTime.Now;
                GetBackHandleClassSender = Class<SenderClassForm>.Deserialize(e.SenderOver);
                HandleClassSender = null;
            */
        }


        /// <summary>
        /// 获取服务器连接状态
        /// </summary>
        public bool GetServerConnented { get { return p.LogUped; } }

        /// <summary>
        /// 绑定发送者
        /// </summary>
        public SenderClassForm HandleClassSender { get; set; }
        /// <summary>
        /// 获取返回的发送者
        /// </summary>
        public SenderClassForm GetBackHandleClassSender { get; protected set; }
        /// <summary>
        /// 获取返回最后一次时间
        /// </summary>
        public DateTime GetBackTime { get; protected set; }

        /// <summary>
        /// 向服务器发送查询
        /// </summary>
        public void Sender()
        {
            try
            {
                GetBackHandleClassSender = null;
                //Console.WriteLine(2);
                HandleClassSender.Execute(p, this);
                p.Sender(Class<SenderClassForm>.Serialize(HandleClassSender));
                HandleClassSender.Executing(p, this);
                byte[] b = p.ReviceByte();
                GetBackHandleClassSender = Class<SenderClassForm>.Deserialize(b);
                HandleClassSender.ExecuteOver(p, this);
                HandleClassSender = null;
            }
            catch (Exception ex)
            {
                if (ex is SmException)
                {
                    SmException er = (SmException)ex;
                    er.message = "查询失败:" + er.message;
                    throw er;
                }

                SmException s = new SmException(ex);
                s.message = "查询失败:" + s.message;
                throw s; 
                //throw new SmException("查询失败:" + ex.Message);
            }
        }
    }
}
