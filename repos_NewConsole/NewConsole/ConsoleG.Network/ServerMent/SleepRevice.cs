using ConsoleG.Network.InShowClient;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    /// <summary>
    /// 如果服务开启了自动接收，使用此功能可以拖缓接收状态
    /// </summary>
    public class SleepRevice : SenderClassForm
    {
        public SleepRevice()
        {
            ControlClass = "sleeprv";
        }
        /// <summary>
        /// 休眠秒数
        /// </summary>
        public int Sleep { get { return m_sleep; } set { if (value < 0) throw new SmException("不可以休眠负数的秒数"); m_sleep = value; } }
        private int m_sleep;

        public override void Execute(NewConsoleNetCY c, RunTServerFP r)
        {
            GetRun = m_sleep.ToString();
        }
    }
}
