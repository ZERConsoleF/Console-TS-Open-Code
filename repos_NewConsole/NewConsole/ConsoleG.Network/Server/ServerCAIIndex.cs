using SmProPub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.Server
{
    /// <summary>
    /// 提供服务器验证
    /// </summary>
    public interface ServerCAIIndex
    {
        /// <summary>
        /// 失败原因
        /// </summary>
        SmException FailText { get; set; }
        /// <summary>
        /// 是否执行
        /// </summary>
        bool Success { get; set; }
        /// <summary>
        /// 失败编号
        /// </summary>
        int FailCount { get; set; }
        /// <summary>
        /// 执行验证
        /// </summary>
        /// <param name="c">本体</param>
        /// <param name="i">连接验证</param>
        /// <param name="s">证书</param>
        /// <param name="h">Server User</param>
        void Execute(NewConsoleNetSr c, InfeNewConsoleHup i, ServerIns s);
    }
}
