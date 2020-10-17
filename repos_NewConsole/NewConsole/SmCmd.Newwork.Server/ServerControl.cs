using ConsoleG.Network;
using ConsoleG.Network.Server;
using RunLCJVM;
using RunLCJVM.ServerStart;
using SmProPub.MakeRun;
using SmProPub.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace SmCmd.Newwork.Server
{
    public class ServerControl : RunCommandToServer
    {
        public Exception Exception(int ex)
        {
            return new Exception("出现的未知错误");
        }

        public int Execute(string arg, SeeModsConsoleRunServer r, object obj)
        {
            try
            {
                string[] args = String64.MakeArg(arg);

            if (args.Length <= 0)
            {
                Console.WriteLine("注意!服务器的参数必须在1以上，help查看！");
                return 0;
            }
                NewConsoleNetSr[] s = ObjectClass<NewConsoleNetSr>.GetIndexl;
                if (args[0].ToLower() == "-see-status")
                {
                    foreach (NewConsoleNetSr d in s)
                    {
                        Console.WriteLine("新建在这个Server:" + d.Name);
                        Console.WriteLine("Server Ip:" + d.GetThisSocket.LocalEndPoint.ToString());
                        Console.WriteLine("Server 使用内存:" + StringSearch.FormatIB(Process.GetCurrentProcess().PrivateMemorySize64, "0.00"));
                        Console.WriteLine("Server 当前使用人数:" + d.BackLongAllSocket());
                        Console.WriteLine("Server 使用最大人数:" + d.ListernAbout);
                        Console.WriteLine("Server 线程数量:" + Process.GetCurrentProcess().Threads.Count);
                        Console.WriteLine("Server 插件挂载项目:" + r.lcass.Count);
                    }
                }
                if (args[0].ToLower() == "-see-user")
                {
                    foreach (NewConsoleNetSr d in s)
                    {
                        Console.WriteLine("新建在这个Server:" + d.Name);
                        Console.WriteLine("Server Ip:" + d.GetThisSocket.LocalEndPoint.ToString());
                        Console.WriteLine("------------");
                        foreach (SaveServerSocket rop in d.GetSaveServerSockets())
                        {
                            Console.WriteLine("连接用户IP:" + rop.Sender.RemoteEndPoint.ToString());
                            Console.WriteLine("连接用户所使用的用户:" + rop.User.User);
                            Console.WriteLine("连接指纹:" + rop.USIn.UserIndex);
                            Console.WriteLine("------------");
                        }
                    }
                }
                if (args[0].ToLower() == "-c-close-ip")
                {
                    if (args.Length >= 2)
                    {
                        Console.WriteLine("Search Connent User IP...");

                        List<NewConsoleNetSr> spy = new List<NewConsoleNetSr>();
                        List<Socket> rtec = new List<Socket>();

                        foreach (NewConsoleNetSr d in s)
                        {
                            SaveServerSocket[] st = d.GetSaveServerSockets();
                            foreach (SaveServerSocket rtfg in st)
                            {
                                if (StringSearch.SearchStringInFormat(rtfg.Sender.RemoteEndPoint.ToString(), args[1]) > 0)
                                {
                                    rtec.Add(rtfg.Sender);
                                    spy.Add(d);
                                    break;
                                }
                            }
                        }
                        if (spy.Count > 0)
                        {
                            Console.WriteLine("**********查找在所有新建服务器中的服务(Find All new Server in Services)**********");
                            Console.WriteLine("* 关闭对象(Close Connent):" + args[1]);
                            Console.WriteLine("**********服务列表(Server List)**********");

                            int er = 0;

                            foreach (NewConsoleNetSr tf in spy)
                            {
                                Console.WriteLine("* [{0}] Server IP:{1} Name:{2}", er, tf.GetThisSocket.LocalEndPoint.ToString(), tf.Name);
                                er++;
                            }

                            Console.Write("输入一个操控数字来结束连接(退出q)\n(Please Write Number to end connent)(Quit:q):");
                            string wrint = Console.ReadLine();

                            if (wrint.ToLower() == "q")
                                goto Q;

                            if (int.TryParse(wrint,out int rt))
                            {
                                Console.WriteLine("Close");
                                rt = int.Parse(wrint);
                                spy[rt].Close(rtec[rt]);
                                Console.WriteLine(args[1] + " DisConnent!");
                            }
                            else
                            {
                                Console.WriteLine("***不是有效数字(It false number)***");
                            }
                        Q:;
                        }
                        else
                        {
                            Console.WriteLine("**********无法找到!(No Find)**********");
                        }
                    }
                    else
                    {
                        Console.WriteLine("**********Need at least 2 Options**********");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            End:

            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            string[] argh = { "使用SeeMods Server管理程序列表",
                "用法 .. <-option> [arg]",
            "",
            "其中option用法:",
            "-see系列:",
            "   -see-status 查看服务器状态",
            "   -see-user 查看服务器人数连接",
            "   ",
            "-c系列",
            "   -c-close-ip [ip] 根据ip关闭连接人",
            "   -c-close-user [user] 根据user关闭连接",
            "   -c-see-ip-sender [ip] 根据ip查看发送数据数目",
            "   -c-see-log 查看服务器日志文件"};
            return argh;
        }

        public string RunCommand()
        {
            return "serverrun";
        }
    }
}
