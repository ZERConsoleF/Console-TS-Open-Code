using RunLCJVM.ServerStart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.MakeRun
{
    /// <summary>
    /// 运行SeeModsConsoleRunServer控制台指令(可确保它是工作的)
    /// </summary>
    public interface RunCommandToServer
    {
        /// <summary>
        /// 返回运行的命令参数头
        /// </summary>
        /// <returns>参数头</returns>
        string RunCommand();
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="arg">带入参数(需要自己去空格)</param>
        /// <returns>执行命令的返回，默认0</returns>
        int Execute(string arg, SeeModsConsoleRunServer r, object obj);
        /// <summary>
        /// 解释命令
        /// </summary>
        /// <param name="arg">执行返回的参数</param>
        /// <returns>命令列表</returns>
        string[] HelpCommand(string arg);
        /// <summary>
        /// 如果执行返回其他的，则查找对应的参数
        /// </summary>
        /// <param name="ex">参数返回值</param>
        /// <returns>一个错误</returns>
        Exception Exception(int ex);
    }
}
