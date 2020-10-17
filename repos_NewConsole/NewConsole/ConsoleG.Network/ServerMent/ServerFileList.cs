using ConsoleG.Network.InShowClient;
using ConsoleG.Network.InShowServer;
using ConsoleG.Network.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    public class ServerFileList : RunAtAdd
    {
        public Exception BackException { get; set; }
        public SenderClassForm BackSenderClass { get; set; }

        public string ClassName()
        {
            return "ServerFileList";
        }

        public void Execute(NewConsoleNetSr sr, ServerSenderOveEvent s, SenderClassForm f)
        {
            if (f.GetRun == null)
            {
                f.SuccessRuned = false;
                BackSenderClass = f;
                BackException = new Exception("文件夹的值不可为null");
                return;
            }
            if (!Directory.Exists(f.GetRun))
            {
                f.SuccessRuned = false;
                BackSenderClass = f;
                BackException = new Exception("没能找到文件夹在 " + f.GetRun);
                return;
            }

            string[] ir = Directory.GetFiles(f.GetRun);
            string[] ia = Directory.GetDirectories(f.GetRun);

            SpDir d = new SpDir();
            List<string> so = new List<string>();
            foreach (string yyh in ir)
            {
                so.Add(Path.GetFileName(yyh));
            }
            d.FilePathName = so.ToArray();

            so.Clear();
            so = new List<string>();
            foreach (string yyh in ia)
            {
                so.Add(Path.GetFileName(yyh));
            }
            d.DirPathName = so.ToArray();
            d.PathC = f.GetRun;

            f.GetBytes = Class<SpDir>.Serialize(d);
            f.GetControlType = "0:200:ServerFileList";
            BackSenderClass = f;
            f.SuccessRuned = true;
        }
    }
    public class SpDir
    {
        public string PathC { get; set; }
        public string[] DirPathName { get; set; }
        public string[] FilePathName { get; set; }
    }
}
