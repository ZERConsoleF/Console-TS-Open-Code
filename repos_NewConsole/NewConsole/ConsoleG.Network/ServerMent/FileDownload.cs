using ConsoleG.Network.InShowClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.SmProPub.Event;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    /// <summary>
    /// 向服务器下载指定文件
    /// </summary>
    public class FileDownload : SenderClassForm
    {
        public FileDownload()
        {
            ControlClass = "FileDownload";
        }
        /// <summary>
        /// 服务器接收状态
        /// </summary>
        public NewSocketABEvent ObjectGetInsp { get; protected set; }
        /// <summary>
        /// 对方服务器下载文件
        /// </summary>
        public string FilePathDownload { get; set; }
        /// <summary>
        /// 保存文件夹路径
        /// </summary>
        public string SavePathDirectory { get; set; }
        /// <summary>
        /// 保存的文件名
        /// </summary>
        public string SavePath { get; set; }
        private Thread t_thread;
        /// <summary>
        /// 服务器后处理服务
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        public override void Execute(NewConsoleNetCY c, RunTServerFP r)
        {
            t_thread = new Thread(()=> {
                Socket thu = c.GetThisSocket;
                thu.Receive(new byte[1]);
                thu.Send(Encoding.UTF8.GetBytes(FilePathDownload));
                byte[] b = new byte[1024];
                thu.Receive(b);
                long lo = long.Parse(Encoding.UTF8.GetString(b));
                long lop = 0;
                if (!Directory.Exists(SavePathDirectory))
                    Directory.CreateDirectory(SavePathDirectory);
                FileStream ft = File.Open(SavePathDirectory + SavePath,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                thu.Send(new byte[1]);
                while (lop < lo)
                {
                    byte[] by = new byte[1];
                    thu.Receive(by);
                    ft.Write(by, 0, by.Length);
                    lop++;
                    thu.Send(new byte[1]);
                }
                ft.Close();
            });
            //GetRun = new Random().Next(IPEndPoint.MinPort, IPEndPoint.MaxPort).ToString();
            /*
            SenderClassForm cr = r.GetBackHandleClassSender;
            SuccessRuned = cr.SuccessRuned;
            GetException = cr.GetException;

            if (!cr.SuccessRuned)
            {
                return;
            }
            else
            {
                if (BackMessageAnys != null)
                    new Thread(() => { BackMessageAnys(this, new ObjectEvent()); }).Start();
                c.SenderReviceStatic += C_SenderReviceStatic;
                //GetBytes = c.ReviceByte();
            }
            */
        }
        public override void Executing(NewConsoleNetCY c, RunTServerFP r)
        {
            t_thread.Start();
            while (t_thread.ThreadState == ThreadState.Running) Thread.Sleep(1000) ;
        }
        public override void ExecuteOver(NewConsoleNetCY c, RunTServerFP r)
        {
            if (!r.GetBackHandleClassSender.SuccessRuned)
            {
                t_thread.Abort();
                throw r.GetBackHandleClassSender.GetException;
                //Console.WriteLine(r.GetBackHandleClassSender.GetException);
            }
        }
        private void C_SenderReviceStatic(object sender, ObjectEvent o)
        {
            ObjectGetInsp = o as NewSocketABEvent;
            if (BackMessageAnys != null)
                new Thread(() => { BackMessageAnys(this, new ObjectEvent()); }).Start();
            
        }

        /// <summary>
        /// 返回消息时触发(线程操控)
        /// </summary>
        public event ObjectEventArg BackMessageAnys;
    }
}
