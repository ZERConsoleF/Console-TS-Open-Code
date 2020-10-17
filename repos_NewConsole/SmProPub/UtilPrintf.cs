using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmProPub
{
    /// <summary>
    /// 系统的输出
    /// </summary>
    public class UtilPrintf
    {
        private Process poy = null;
        private Thread logwrite;
        private int threads = 12000;
        private string dateab = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + ".log";
        private bool theend = false;
        private string ost { get; set; }
        public int ConsoleColorId = -1;

        /// <summary>
        /// 重置颜色
        /// </summary>
        public void RestColor()
        {
            ConsoleColorId = -1;
        }
        /// <summary>
        /// 初始化值
        /// </summary>
        public UtilPrintf()
        {
            Console.WriteLine("如果使用，建议全程都用UtilPrintf，这样我们好写入日志\n如果不想显示，请在代码初始化的new为new UtilPrintf(null)");
        }
        /// <summary>
        /// 初始化值（不会显示）
        /// </summary>
        public UtilPrintf(object o)
        {

        }
        /// <summary>
        /// 在此程序开启日志监听
        /// </summary>
        public void StartLinster()
        {
            ost = "";
        }
        /// <summary>
        /// 指定监听程序
        /// </summary>
        /// <param name="po"></param>
        public void StartLinster(Process po)
        {
            poy = po;
        }
        /// <summary>
        /// 设置监听等待流入秒数
        /// </summary>
        /// <param name="max"></param>
        public void SetThreadsecond(int max)
        {
            threads = max;
        }
        /// <summary>
        /// 设置文件（默认为时间）
        /// </summary>
        /// <param name="file"></param>
        public void SetFilesAboutWrite(string file)
        {
            if (!File.Exists(file))
            {
                SmException sm = new SmException();
                sm.Debug = file + ":重新定义！";
                sm.CodeLine = "0xc0000012, 0xc2021304, 4x01uid0";
                sm.FailWhy = "未找到文件" + file;
                sm.ID = -4450124;
                throw sm.RunSmProEx();
            }
            dateab = file;
        }
        /// <summary>
        /// 执行监听！
        /// </summary>
        public void StartWrite()
        {
            if (theend)
            {
                SmException sm = new SmException();
                sm.Debug = ":出现了二次执行！";
                sm.CodeLine = "0xc0000012, 0xc2431304, 4x01uid0";
                sm.FailWhy = "Thread Error";
                sm.ID = -4457803;
                throw sm.RunSmProEx();
            }
            if (ost == null && poy == null)
            {
                SmException sm = new SmException();
                sm.Debug = ":出现了NULL！";
                sm.CodeLine = "0xc0000012, 0xc24311304, 7x01uid0";
                sm.FailWhy = "String Error";
                sm.ID = -4457033;
                throw sm.RunSmProEx();
            }
            theend = true;
                logwrite = new Thread(new ThreadStart(ThreadAboutAto));
            logwrite.Start();
        }
        /// <summary>
        /// 立刻停止，并写入结尾
        /// </summary>
        public void Stopping()
        {
            WriteLogAbout();
            theend = false;
            logwrite.Interrupt();
            logwrite.Abort();
            ost = "";
        }
        private static string Dateim()
        {
            return DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }
        private static string PrintWhy(int outint)
        {
            string retun = "Info";
            switch(outint)
            {
                case 0:
                    retun = "Info";
                    break;
                case 1:
                    retun = "Warn";
                    break;
                case 2:
                    retun = "Error";
                    break;
                default:
                    break;
            }
            return retun;
        }

        /// <summary>
        /// 可执行log,使用Console方法，输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <param name="u"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static void Printf(UtilControl u, ref UtilPrintf f, string message, params object[] args)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(u.GetHashCode());
            ConsoleColor c = Console.ForegroundColor;
            switch (u.GetHashCode())
            {
                case 0:
                    c = ConsoleColor.White;
                    break;
                case 1:
                    c = ConsoleColor.Yellow;
                    break;
                case 2:
                    c = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            ConsoleColor ct = Console.ForegroundColor;
            if (f.ConsoleColorId != -1)
                c = (ConsoleColor)f.ConsoleColorId;
            Console.ForegroundColor = c;
            string ub = "[" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] [" + Thread.CurrentThread.Name + "/Thread] " + message;
            Console.WriteLine(ub, args);
            string sf = string.Format(ub, args);
            f.ost += sf + "\n";
            Console.ForegroundColor = ct;
        }

        /// <summary>
        /// 执行Log写入，并输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="u"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static void Printf(string message, UtilControl u, ref UtilPrintf f)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(u.GetHashCode());
            ConsoleColor c = Console.ForegroundColor;
            switch (u.GetHashCode())
            {
                case 0:
                    c = ConsoleColor.White;
                    break;
                case 1:
                    c = ConsoleColor.Yellow;
                    break;
                case 2:
                    c = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            ConsoleColor ct = Console.ForegroundColor;
            if (f.ConsoleColorId != -1)
                c = (ConsoleColor)f.ConsoleColorId;
            Console.ForegroundColor = c;
            string ub = "[" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] [" + Thread.CurrentThread.Name + "/Thread] " + message;
            Console.WriteLine(ub);
            f.ost += ub + "\n";
            Console.ForegroundColor = ct;
        }
        /// <summary>
        /// 执行Log,并输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static void Printf(string message, ref UtilPrintf f)
        {
            Printf(message, 0, ref f);
        }
        /// <summary>
        /// 可执行log,使用Console方法，输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <param name="u"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static void Printf(string message, string args, UtilControl u, ref UtilPrintf f)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(u.GetHashCode());
            ConsoleColor c = Console.ForegroundColor;
            switch (u.GetHashCode())
            {
                case 0:
                    c = ConsoleColor.White;
                    break;
                case 1:
                    c = ConsoleColor.Yellow;
                    break;
                case 2:
                    c = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            ConsoleColor ct = Console.ForegroundColor;
            if (f.ConsoleColorId != -1)
                c = (ConsoleColor)f.ConsoleColorId;
            Console.ForegroundColor = c;
            string ub = "[" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] [" + Thread.CurrentThread.Name + "/Thread] " + message;
            Console.WriteLine(ub, args);
            f.ost += ub + "\n";
            Console.ForegroundColor = ct;
        }

        // regedit 弃用的方法

        /// <summary>
        /// Printf输出(无标识默认Info)（不会计入日志）
        /// </summary>
        /// <param name="message"></param>
        [Obsolete("由于此类可能会使指针假死，即将淘汰")]
        public static void Printf(string message)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(0);
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            string ub = "![" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] " + message;
            Console.WriteLine(ub);
            Console.ForegroundColor = x;
        }
        /// <summary>
        /// Printf输出(无标识默认Info)（不会计入日志）
        /// </summary>
        /// <param name="message"></param>
        [Obsolete("由于此类可能会使指针假死，即将淘汰")]
        public static void Printf(int message)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(0);
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            string ub = "![" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] " + message;
            Console.WriteLine(ub);
            Console.ForegroundColor = x;
        }
        /// <summary>
        /// Printf输出(无标识默认Info)（不会计入日志）
        /// </summary>
        /// <param name="message"></param>
        [Obsolete("由于此类可能会使指针假死，即将淘汰")]
        public static void Printf(bool message)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(0);
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            string ub = "![" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] " + message;
            Console.WriteLine(ub);
            Console.ForegroundColor = x;
        }
        /// <summary>
        /// Printf输出(设置标识UtilControl的输出)（不会计入日志）
        /// </summary>
        /// <param name="message"></param>
        [Obsolete("由于此类可能会使指针假死，即将淘汰")]
        public static void Printf(string message, UtilControl u)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(u.GetHashCode());
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            string ub = "![" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] " + message;
            Console.WriteLine(ub);
            Console.ForegroundColor = x;
        }
        /// <summary>
        /// Printf输出(设置标识UtilControl的输出)（不会计入日志）
        /// </summary>
        /// <param name="message"></param>
        [Obsolete("由于此类可能会使指针假死，即将淘汰")]
        public static void Printf(int message, UtilControl u)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(u.GetHashCode());
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            string ub = "![" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] " + message;
            Console.WriteLine(ub);
            Console.ForegroundColor = x;
        }
        /// <summary>
        /// Printf输出(设置标识UtilControl的输出)（不会计入日志）
        /// </summary>
        /// <param name="message"></param>
        [Obsolete("由于此类可能会使指针假死，即将淘汰")]
        public static void Printf(bool message, UtilControl u)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(u.GetHashCode());
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            string ub = "![" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] " + message;
            Console.WriteLine(ub);
            Console.ForegroundColor = x;
        }
        /// <summary>
        /// Printf输出(设置标识UtilControl的输出，Object建议不要)（不会计入日志）
        /// </summary>
        /// <param name="message"></param>
        [Obsolete("由于此类可能会使指针假死，即将淘汰")]
        public static void Printf(object message, UtilControl u)
        {
            Process p = Process.GetCurrentProcess();
            string insho = PrintWhy(u.GetHashCode());
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            string ub = "![" + Dateim() + "] [" + p.ProcessName + "/" + insho + "] " + message;
            Console.WriteLine(ub);
            Console.ForegroundColor = x;
        }

        // endregit


        /// <summary>
        /// 立刻写入缓存
        /// </summary>
        public void WriteLogAbout()
        {
            string getuo = ost;
            if (poy != null)
                getuo = poy.StandardOutput.ReadToEnd();
            WriteLog(getuo);
            ost = "";
        }
        private void ThreadAboutAto()
        {
            try
            {
                while (theend)
                {
                    Thread.Sleep(threads);
                    WriteLogAbout();
                }
            }
            catch { }
        }
        private void WriteLog(string ui)
        {
            if (!Directory.Exists("LogNew"))
                Directory.CreateDirectory("LogNew");
            if (File.Exists("LogNew/" + dateab))
            {
                string[] a1s = File.ReadAllLines("LogNew/" + dateab);
                List<string> a2s = new List<string>();
                foreach (string a3s in a1s)
                {
                    a2s.Add(a3s);
                }
                a2s.Add(ui);
                File.WriteAllLines("LogNew/" + dateab, a2s.ToArray());
                return;
            }
            else
            {
                File.Create("LogNew/" + dateab).Dispose();
                string about = "#Console Printf about side\n#       Code Memory this...\n#       WriteTime about (s)" + DateTime.Now.Second + "\n#\n#Endl\n";
                File.WriteAllText("LogNew/" + dateab, about + ui);
                return;
            }
        }
    }
    /// <summary>
    /// 系统的输出标识
    /// </summary>
    public enum UtilControl
    {
        /// <summary>
        /// 标准的信息
        /// </summary>
        Info = 0,
        /// <summary>
        /// 标准的警告
        /// </summary>
        Warn = 1,
        /// <summary>
        /// 标准的错误
        /// </summary>
        Error = 2
    }
}
