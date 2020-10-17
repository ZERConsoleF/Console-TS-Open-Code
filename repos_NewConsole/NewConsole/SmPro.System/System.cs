using RunLCJVM;
using RunLCJVM.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RunLCJVM.ServerStart;

namespace SmPro.System
{
    /// <summary>
    /// 获取当前SmPro系统的焦点
    /// </summary>
    public class System
    {
        /// <summary>
        /// 获取系统当前执行状态
        /// </summary>
        /// <param name="oc">入口点的object[]</param>
        /// <returns></returns>
        public static string GetSystemLoad(object[] oc)
        {
            return (string)oc[0];
        }
        /// <summary>
        /// 获取系统窗口的From
        /// </summary>
        /// <param name="od">入口点的object[]</param>
        /// <returns></returns>
        public static MainWindow GetSystemWindow(object[] od)
        {
            return (MainWindow)od[1];
        }
        /// <summary>
        /// 获取程序的执行类
        /// </summary>
        /// <param name="oc">入口点的object[]</param>
        /// <returns></returns>
        public static SeeModsConsoleRun GetSystemRun(object[] oc)
        {
            return (SeeModsConsoleRun)oc[2];
        }
        /// <summary>
        /// 返回一个与自定义的类有关(如果有多个，则返回第一个)，否则为null
        /// </summary>
        /// <typeparam name="T">需要比较的类</typeparam>
        /// <param name="ov">入口点的object[]</param>
        /// <returns></returns>
        public static object GetReturnOther<T>(object[] ov)
        {
            foreach (object ok in ov)
            {
                if (ok is T)
                {
                    return ok;
                }
            }
            return null;
        }
        /// <summary>
        /// 将窗口显示在另一个窗口
        /// </summary>
        /// <param name="fa">目标窗口</param>
        /// <param name="fb">嵌入目标</param>
        /// <param name="show">是否显示</param>
        public static void SetWindowToPanel(Form fa,Form fb,bool show)
        {
            fb.TopLevel = false;

            if (fa.InvokeRequired)
            {
                fa.Invoke(new MethodInvoker(delegate { fa.Controls.Add(fb); }));
            }
            else
                fa.Controls.Add(fb);

            if (show)
                new Thread(new ThreadStart(() => { Application.Run(fb); })).Start();
        }
    }
    /// <summary>
    /// 获取ServerSystem加载项目
    /// </summary>
    public class SystemServer
    {
        /// <summary>
        /// 判断是否为Server项目
        /// </summary>
        /// <param name="oc">入口点的object[]</param>
        /// <returns></returns>
        public static bool IsServer(object[] oc)
        {
            return oc[2] is SeeModsConsoleRunServer;
        }
        /// <summary>
        /// 获取系统当前执行状态
        /// </summary>
        /// <param name="oc">入口点的object[]</param>
        /// <returns></returns>
        public static string GetSystemLoad(object[] oc)
        {
            return (string)oc[0];
        }
        /// <summary>
        /// 获取程序的执行类
        /// </summary>
        /// <param name="oc">入口点的object[]</param>
        /// <returns></returns>
        public static SeeModsConsoleRunServer GetSystemRun(object[] oc)
        {
            return (SeeModsConsoleRunServer)oc[2];
        }
    }
    /// <summary>
    /// 获取系统信息
    /// </summary>
    public class SystemInfo
    {
        #region CPU获取
        /// <summary>
        /// Return CPU
        /// </summary>
        /// <returns></returns>
        public static string returnCPU()
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");



            return cpuCounter.NextValue().ToString();
            //Console.WriteLine("电脑可使用内存：" + ramCounter.NextValue() + "MB");
            //Console.WriteLine();
        }

        #endregion
        #region 获得内存信息API
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORY_INFO mi);

        //定义内存的信息结构
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength; //当前结构体大小
            public uint dwMemoryLoad; //当前内存使用率
            public ulong ullTotalPhys; //总计物理内存大小
            public ulong ullAvailPhys; //可用物理内存大小
            public ulong ullTotalPageFile; //总计交换文件大小
            public ulong ullAvailPageFile; //总计交换文件大小
            public ulong ullTotalVirtual; //总计虚拟内存大小
            public ulong ullAvailVirtual; //可用虚拟内存大小
            public ulong ullAvailExtendedVirtual; //保留 这个值始终为0
        }
        #endregion

        #region 格式化容量大小
        /// <summary>
        /// 格式化容量大小
        /// </summary>
        /// <param name="size">容量（B）</param>
        /// <returns>已格式化的容量</returns>
        public static string FormatSize(double size)
        {
            double d = (double)size;
            int i = 0;
            while ((d > 1024) && (i < 5))
            {
                d /= 1024;
                i++;
            }
            string[] unit = { "B", "KB", "MB", "GB", "TB" };
            return (string.Format("{0} {1}", Math.Round(d, 2), unit[i]));
        }
        #endregion

        #region 获得当前内存使用情况
        /// <summary>
        /// 获得当前内存使用情况
        /// </summary>
        /// <returns></returns>
        public static MEMORY_INFO GetMemoryStatus()
        {
            MEMORY_INFO mi = new MEMORY_INFO();
            mi.dwLength = (uint)Marshal.SizeOf(mi);
            GlobalMemoryStatusEx(ref mi);
            return mi;
        }
        #endregion

        #region 获得当前可用物理内存大小
        /// <summary>
        /// 获得当前可用物理内存大小
        /// </summary>
        /// <returns>当前可用物理内存（B）</returns>
        public static ulong GetAvailPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullAvailPhys;
        }
        #endregion

        #region 获得当前已使用的内存大小
        /// <summary>
        /// 获得当前已使用的内存大小
        /// </summary>
        /// <returns>已使用的内存大小（B）</returns>
        public static ulong GetUsedPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return (mi.ullTotalPhys - mi.ullAvailPhys);
        }
        #endregion

        #region 获得当前总计物理内存大小
        /// <summary>
        /// 获得当前总计物理内存大小
        /// </summary>
        /// <returns&amp;gt;总计物理内存大小（B）&amp;lt;/returns&amp;gt;
        public static ulong GetTotalPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullTotalPhys;
        }
        #endregion
    }
}
