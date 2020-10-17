using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmProPub.IO
{
    /// <summary>
    /// 提供运行环境的接口
    /// </summary>
    /// <param name="path">返回的执行环境</param>
    public delegate object RunEnvVoid(string path,params object[] arg);
    /// <summary>
    /// 在一个线程中用两个环境(会高占用CPU)(执行时会开启线程)
    /// </summary>
    public class EnvironmentRunTemp
    {
        RunEnvVoid doc;
        object ret;
        /// <summary>
        /// 执行时的返回类
        /// </summary>
        public string RunPath { get; set; }
        /// <summary>
        /// 是否为后台线程
        /// </summary>
        public bool IsBackThread { get; set; }
        /// <summary>
        /// 执行时是否阻塞线程
        /// </summary>
        public bool Aty { get; set; }
        /// <summary>
        /// 设置等待超时
        /// </summary>
        public int Str { get; set; }
        /// <summary>
        /// 声明初始化
        /// </summary>
        /// <param name="vc">声明返回</param>
        /// <param name="path">环境执行</param>
        public EnvironmentRunTemp(string path, RunEnvVoid vc)
        {
            doc = vc;
            RunPath = path;
        }
        /// <summary>
        /// 绑定线程
        /// </summary>
        /// <returns>返回参数</returns>
        public object RunStart(params object[] arg)
        {
            if (RunPath == null)
            {
                SmException sc = new SmException();
                sc.CodeLine = "25,53,55";
                sc.Debug = "解决为null";
                sc.ID = -25740;
                sc.message = "运行出错";
                sc.FailWhy = "Nothing";
                throw sc.RunSmProEx();
            }
            object iop = null;
            Thread tc = new Thread(new ThreadStart(() => { iop = doc.Invoke(RunPath, arg); }));
            tc.IsBackground = IsBackThread;
            tc.Start();
            if (Aty)
            {
                if (Str != 0)
                {
                    while (tc.ThreadState == ThreadState.Running)
                    {
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    while (tc.ThreadState == ThreadState.Running)
                    {
                        Thread.Sleep(1000);
                        if (Str > 0)
                            Str--;
                        else
                        {
                            try
                            {
                                tc.Interrupt();
                                //tc.Abort();
                            }
                            catch { }
                            break;
                        }
                    }
                }
            }
            return iop;
        }
    }
}
