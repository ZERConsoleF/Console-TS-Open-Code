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
    /// 提交执行类，由服务器执行
    /// </summary>
    public interface SendClass
    {
        /// <summary>
        /// 服务器执行接口
        /// </summary>
        string SQP { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        string RunFs { get; set; }
        /// <summary>
        /// 服务器返回结果
        /// </summary>
        byte[] BK { get; set; }
        /// <summary>
        /// 服务器执行结果处理
        /// </summary>
        void Execute();
    }
}
