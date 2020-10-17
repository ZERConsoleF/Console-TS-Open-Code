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
    /// 类操控
    /// </summary>
    public interface RunAtAdd
    {
        /// <summary>
        /// 操控类名称查询
        /// </summary>
        /// <returns></returns>
        string ClassName();
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sr">服务器类本体</param>
        /// <param name="s">发送者</param>
        /// <param name="f">发送者请求</param>
        /// <returns></returns>
        void Execute(NewConsoleNetSr sr,ServerSenderOveEvent s, SenderClassForm f);
        /// <summary>
        /// 对于服务器执行错误返回
        /// </summary>
        Exception BackException { get; set; }
        /// <summary>
        /// 返回发送者
        /// </summary>
        SenderClassForm BackSenderClass { get; set; }
    }
    /// <summary>
    /// 注册指令
    /// </summary>
    public class RegeditThis : ObjectClass<RegeditThis>
    {
        /// <summary>
        /// 注册新的指令系统调用
        /// </summary>
        public RegeditThis()
        {
        }
        /// <summary>
        /// 锁定保存写入
        /// </summary>
        public void Regedit()
        {
            IDX = SaveInMemory(this);
        }
        /// <summary>
        /// 多指令注册
        /// </summary>
        public RunAtAdd[] RegRuns { get; set; }
    }
}
