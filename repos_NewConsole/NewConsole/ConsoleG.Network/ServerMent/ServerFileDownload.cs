using ConsoleG.Network.InShowClient;
using ConsoleG.Network.InShowServer;
using ConsoleG.Network.Server;
using SmProPub.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    /// <summary>
    /// 服务器下载文件
    /// </summary>
    public class ServerFileDownload : RunAtAdd
    {
        public Exception BackException { get; set; }
        public SenderClassForm BackSenderClass { get; set; }

        public string ClassName()
        {
            return "FileDownload";
        }

        public void Execute(NewConsoleNetSr sr, ServerSenderOveEvent s, SenderClassForm f)
        {
            /*
            if (f.GetRun != null)
            {
                f.SuccessRuned = File.Exists(f.GetRun);
                if (!f.SuccessRuned)
                {
                    BackException = new Exception("没有文件!" + f.GetRun);
                    BackSenderClass = f;
                    return;
                }
            }
            else
            {
                f.SuccessRuned = false;
                BackException = new Exception("无法获取null路径");
                BackSenderClass = f;
                return;
            }
            f.SuccessRuned = true;
            f.GetBytes = File.ReadAllBytes(f.GetRun);
            /*
            new Thread(() => {
                byte[] bg = File.ReadAllBytes(f.GetRun);
                sr.ReviceByte();
                sr.Send(s.Sender, bg);
            }).Start();
            BackSenderClass = f;
            */
            //IPEndPoint i = (IPEndPoint)s.Sender.RemoteEndPoint;
            Thread t = new Thread(() => {
                try
                {
                    Socket sd = s.Sender;
                    sd.Send(new byte[1]);
                    byte[] b = new byte[1024];
                    sd.Receive(b);
                    b = ByteSearch.EmptyBytes(b);
                    string path = Encoding.UTF8.GetString(b);
                    if (!File.Exists(path))
                    {
                        f.GetException = new Exception("文件位置:" + path + " 不存在");
                        
                        return;
                    }
                    sd.Send(Encoding.UTF8.GetBytes(new FileInfo(path).Length.ToString()));
                    sd.Receive(new byte[1]);

                    FileStream fq = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
                    while (fq.Length > fq.Position)
                    {
                        byte[] bw = new byte[1];
                        fq.Read(bw, 0, 1);
                        sd.Send(bw);
                        sd.Receive(new byte[1]);
                    }
                    fq.Close();
                }
                catch (Exception ex)
                {
                    f.GetException = ex;
                }
            });
            t.IsBackground = true;
            t.Start();
            while (t.ThreadState == ThreadState.Running) Thread.Sleep(sr.WaitContiue);
            if (f.GetException == null)
                f.SuccessRuned = true;
            BackSenderClass = f;
        }
    }
}
