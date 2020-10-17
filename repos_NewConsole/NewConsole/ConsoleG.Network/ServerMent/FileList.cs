using ConsoleG.Network.InShowClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    /// <summary>
    /// 向服务器发送指定消息，返回文件List
    /// </summary>
    public class FileList : SenderClassForm
    {
        public FileList()
        {
            
            ControlClass = "ServerFileList";
        }
        /// <summary>
        /// 获取或设置查询文件位置
        /// </summary>
        public string Directory { get { return GetRun; } set { GetRun = value; } }
        /// <summary>
        /// 获取返回文件查询结果
        /// </summary>
        public SpDir SpDir { get; protected set; }
        public override void ExecuteOver(NewConsoleNetCY c, RunTServerFP r)
        {
            if (GetException == null)
                SpDir = Class<SpDir>.Deserialize(r.GetBackHandleClassSender.GetBytes);
        }
    }
}
