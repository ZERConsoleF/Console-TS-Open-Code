using ConsoleG.Network.InShowClient;
using ConsoleG.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.InShowServer
{
    /// <summary>
    /// 服务器操作
    /// </summary>
    public class RunTAtServer : ObjectClass<RunTAtServer>
    {
        NewConsoleNetSr p;
        /// <summary>
        /// 新建操作
        /// </summary>
        /// <param name="sr"></param>
        public RunTAtServer(NewConsoleNetSr sr)
        {
            p = sr;
            p.SenderByte += P_SenderByte;
            SetClassControls = new List<RunAtAdd>();
            //RegeditThis.StaticSaveAdd += RegeditThis_StaticSaveAdd;
            IDX = SaveInMemory(this);
        }

        private void RegeditThis_StaticSaveAdd(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            foreach (RunAtAdd t in ((RegeditThis)sender).RegRuns)
            {
                SetClassControls.Add(t);
            }
        }

        private void P_SenderByte(object sender, System.SmProPub.Event.ObjectEvent o)
        {
            ServerSenderOveEvent e = (ServerSenderOveEvent)o;
            SenderClassForm f = Class<SenderClassForm>.Deserialize(e.SenderOver);

            foreach (RunAtAdd a in SetClassControls.ToArray())
            {
                if (a.ClassName().ToLower() == f.ControlClass.ToLower())
                {
                    a.Execute(p, e, f);
                    SenderClassForm fl = a.BackSenderClass;
                    fl.GetException = a.BackException;
                    p.Send(e.Sender, Class<SenderClassForm>.Serialize(fl));
                    break;
                }
            }
        }
        /// <summary>
        /// 将注册类添加
        /// </summary>
        public void GetRegeditMD()
        {
            if (RegeditThis.GetIndexl != null)
            {
                foreach (RegeditThis t in RegeditThis.GetIndexl)
                {
                    foreach (RunAtAdd a in t.RegRuns)
                    {
                        SetClassControls.Add(a);
                    }
                }
            }
        }
        /// <summary>
        /// 添加事件自动注册
        /// </summary>
        public void GetAutuoRegeditMD()
        {
            RegeditThis.StaticSaveAdd += RegeditThis_StaticSaveAdd;
        }

        /// <summary>
        /// 获取添加操控类
        /// </summary>
        public List<RunAtAdd> SetClassControls { get; set; }
    }
}
