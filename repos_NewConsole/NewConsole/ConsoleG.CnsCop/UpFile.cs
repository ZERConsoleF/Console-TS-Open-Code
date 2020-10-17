using ConsoleG.Network;
using ConsoleG.Network.Server;
using RunLCJVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.CnsCop
{
    /// <summary>
    /// 配合服务器文件操作
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class UpFile : SendClote
    {
        public override byte[] BK { get; set; }
        public override ServerBackAs MSWE { get; set; }
        public override void Execute()
        {
            
        }
    }
}
