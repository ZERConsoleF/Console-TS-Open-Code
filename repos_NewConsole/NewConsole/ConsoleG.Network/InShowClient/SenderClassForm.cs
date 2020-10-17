using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.InShowClient
{
    /// <summary>
    /// 向服务器发送执行指令
    /// </summary>
    public class SenderClassForm
    {
        /// <summary>
        /// 服务器执行类
        /// </summary>
        public virtual string ControlClass { get; set; }
        /// <summary>
        /// 对执行说明
        /// </summary>
        public virtual string ControlComment { get; set; }
        /// <summary>
        /// 获取返回字节
        /// </summary>
        public virtual string GetRun { get; set; }
        /// <summary>
        /// 获取服务器回路
        /// </summary>
        public virtual byte[] GetBytes { get; set; }

        /// <summary>
        /// 获取指导操作文本
        /// </summary>
        public virtual string GetControlType { get; set; }
        /// <summary>
        /// 获取失败原因
        /// </summary>
        public virtual Exception GetException { get; set; }
        /// <summary>
        /// 获取是否执行成功
        /// </summary>
        public virtual bool SuccessRuned { get; set; }
        /// <summary>
        /// 处理执行
        /// </summary>
        public virtual void Execute(NewConsoleNetCY c, RunTServerFP r)
        {

        }
        /// <summary>
        /// 执行中的处理
        /// </summary>
        public virtual void Executing(NewConsoleNetCY c, RunTServerFP r)
        {

        }
        /// <summary>
        /// 发送执行后的处理
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        public virtual void ExecuteOver(NewConsoleNetCY c, RunTServerFP r)
        {

        }
    }
}
