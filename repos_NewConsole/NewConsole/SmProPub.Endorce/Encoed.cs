using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Resources;
using System.Runtime.InteropServices;
using System.SmProPub.Event;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmProPub.Endorce
{
    /// <summary>
    /// 加密类,通过藏匿方法加密
    /// </summary>
    public sealed class Encoed
    {
        /// <summary>
        /// 16进制表中的字母
        /// </summary>
        public static readonly string[] String16F = { "A", "B", "C", "D", "E", "F" };
        /// <summary>
        /// 16进制表中的数字
        /// </summary>
        public static readonly int[] Int16F = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        /// <summary>
        /// 16进制表中的所有
        /// </summary>
        public static string[] All16F { get { List<string> s = new List<string>(); foreach (int g in Int16F) s.Add(g.ToString()); s.AddRange(String16F); return s.ToArray(); } }
        /// <summary>
        /// 新建加密
        /// </summary>
        public Encoed()
        {
            SystemTime = 100000;
            ThisRandom = new Random();
        }
        /// <summary>
        /// 产生的随机数
        /// </summary>
        public Random ThisRandom { get; private set; }
        /// <summary>
        /// 开启线程
        /// </summary>
        [Obsolete("开启线程操控虽然在一定程度上加快速度，但数据可能会错位(使用此方法请添加延迟)")]
        public bool OpenThread { get; set; }
        /// <summary>
        /// 开启线程，执行下一个程序时暂定特定时间
        /// </summary>
        public int ThreadSleep { get; set; }
        /// <summary>
        /// 系统时间
        /// </summary>
        public int SystemTime { get; private set; }
        /*
        /// <summary>
        /// 16F表查询位置0~9 A~F
        /// </summary>
        /// <param name="c">16F文本</param>
        /// <returns></returns>
        public static int Get16FInChar(char c)
        {
            int xf = 0;
            foreach (string f in All16F)
            {
                if (c == f.ToCharArray()[0])
                {
                    return xf;
                }
                xf++;
            }
            return -1;
        }
        /// <summary>
        /// 确定位置，对他混析
        /// </summary>
        /// <param name="c">初始位置</param>
        /// <param name="idx">混析位置</param>
        /// <returns></returns>
        public static char GetIntIn16F(int c, int idx)
        {
            char chart = '0';
            if (idx > 0)
            {
                int fg = c;//0;
                for (int i = 0; i <= idx; i++)
                {
                    if (fg >= All16F.Length)
                    {
                        fg = 0;
                    }
                    chart = All16F[fg].ToCharArray()[0];
                    fg++;
                }
            }
            if (idx < 0)
            {
                int fg = c;//All16F.Length;
                for (int i = -idx; i >= 0; i--)
                {
                    if (fg < 0)
                    {
                        fg = All16F.Length - 1;
                    }
                    chart = All16F[fg].ToCharArray()[0];
                    fg--;
                }
            }
            return chart;
        }
        /// <summary>
        /// 从初始位置，对他混析
        /// </summary>
        /// <param name="idx">混析位置</param>
        /// <returns></returns>
        public static char GetIntAt16F(int idx)
        {
            /*
            if (idx > 16 && idx < 1)
            {
                throw new SmException("请声明在1~16的数");
            }
            char chart = '0';
            if (idx > 0)
            {
                int fg = 0;
                for (int i = 0; i <= idx; i++)
                {
                    if (fg >= All16F.Length)
                    {
                        fg = 0;
                    }
                    chart = All16F[fg].ToCharArray()[0];
                    fg++;
                }
            }
            if (idx < 0)
            {
                int fg = All16F.Length;
                for (int i = -idx; i >= 0; i--)
                {
                    if (fg < 0)
                    {
                        fg = All16F.Length - 1;
                    }
                    chart = All16F[fg].ToCharArray()[0];
                    fg--;
                }
            }
            return chart;
        }
        */
        /// <summary>
        /// 对单个字符加密
        /// </summary>
        /// <param name="bt">字节</param>
        /// <param name="idx">藏匿位置</param>
        /// <param name="idx2">生成字节数</param>
        /// <param name="ra">需要的随机数</param>
        /// <returns></returns>
        public static byte[] ByteLock(byte bt, int idx, int idx2, Random ra)
        {
            if (idx >= idx2)
                throw new SmException("藏匿位置必须与生成随机数的字节小于");
            byte[] b = new byte[idx2];
            ra.NextBytes(b);
            b[idx] = bt;
            return b;
        }
        /// <summary>
        /// 对单个字符解密
        /// </summary>
        /// <param name="bt">字节</param>
        /// <param name="idx">藏匿位置</param>
        /// <param name="idx2">分割</param>
        /// <returns></returns>
        public static byte ByteUnLock(byte[] bt, int idx, int idx2)
        {
            if (idx >= idx2)
                throw new SmException("藏匿位置必须与生成随机数的字节小于");
            //Console.WriteLine(bt.Length + " " + idx2);
            if (bt.Length < idx2)
                throw new SmException("小于分割线");
            byte[] bc = new byte[idx2];
            if (bt.Length == idx2)
                bc = bt;
            else
            {
                for (int i = 0; i < idx2; i++)
                    bc[i] = bt[i];
            }
            return bc[idx];
        }
        /// <summary>
        /// 整体转化
        /// </summary>
        /// <param name="bt">总字节</param>
        /// <param name="idx">藏匿位置组</param>
        /// <param name="idx2">生成字节数组</param>
        /// <returns></returns>
        public byte[] BytesLock(byte[] bt, int[] idx, int[] idx2)
        {
            if (idx.Length != idx2.Length)
                throw new SmException("秘钥数量必须是一样的");
            List<byte> b = new List<byte>();
            int xl = 0;
            long xr = 0;
            long xc = 0;
            bool finish = false;
            bool sp = false;
            EventLockEncoder r = new EventLockEncoder();
            if (OpenThread)
                SystemTime = (SystemTime / 10) + (ThreadSleep * 1000);
            new Thread(() => {
                while (!finish)
                {
                    Thread.Sleep(1000);
                    r.TimeOppendByte = xc;
                    xc = 0;
                }
            }).Start();
            
            foreach (byte b4 in bt)
            {
                if (ControlByte != null)
                {
                    r.ByteAllLock = bt.LongCount();
                    r.ByteLoadedLock = xr + 1;
                    r.TimeOpped = SystemTime;
                    ControlByte(this, r);
                }
                void Sp()
                {
                    if (sp)
                        throw new SmException("在这个线程中，与另一个线程发生冲突，请添加ThreadSleep尝试解决");
                    sp = true;
                    if (xl >= idx.Length)
                        xl = 0;
                    b.AddRange(ByteLock(b4, idx[xl], idx2[xl], this.ThisRandom));
                    xl++;
                    xr++;
                    xc++;
                    sp = false;
                }
                if (OpenThread)
                {
                    new Thread(Sp).Start();
                    Thread.Sleep(ThreadSleep);
                }
                else
                {
                    Sp();
                }
            }
            finish = true;
            return b.ToArray();
        }
        /// <summary>
        /// 整体反转化
        /// </summary>
        /// <param name="bt">总字节</param>
        /// <param name="idx">藏匿位置组</param>
        /// <param name="idx2">生成字节数组</param>
        /// <returns></returns>
        public byte[] DeBytesLock(byte[] bt, int[] idx, int[] idx2)
        {
            if (idx.Length != idx2.Length)
                throw new SmException("秘钥数量必须是一样的");
            List<byte> b = new List<byte>();
            int xl = 0;
            long xr = 0;
            long xc = 0;
            bool finish = false;
            bool sp = false;
            List<byte> bbh = new List<byte>();
            EventLockEncoder r = new EventLockEncoder();
            if (OpenThread)
                SystemTime = (SystemTime / 10) + (ThreadSleep * 1000);
            new Thread(() => {
                while (!finish)
                {
                    Thread.Sleep(1000);
                    r.TimeOppendByte = xc;
                    xc = 0;
                }
            }).Start();
            foreach (byte b4 in bt)
            {
                if (ControlByte != null)
                {
                    r.ByteAllLock = bt.LongCount();
                    r.ByteLoadedLock = xr + 1;
                    r.TimeOpped = SystemTime;
                    ControlByte(this, r);
                }
                void Sp()
                {
                    if (sp)
                        throw new SmException("在这个线程中，与另一个线程发生冲突，请添加ThreadSleep尝试解决");
                    sp = true;
                    if (xl >= idx.Length)
                        xl = 0;
                    bbh.Add(b4);
                    if (idx2[xl] <= bbh.Count)
                    {
                        b.Add(ByteUnLock(bbh.ToArray(), idx[xl], idx2[xl]));
                        xl++;
                        bbh.Clear();
                    }
                    xr++;
                    xc++;
                    sp = false;
                }
                if (OpenThread)
                {
                    new Thread(Sp).Start();
                    Thread.Sleep(ThreadSleep);
                }
                else
                {
                    Sp();
                }
            }
            finish = true;
            return b.ToArray();
        }

        /// <summary>
        /// 获取操控字节情况
        /// </summary>
        public event ObjectEventArg ControlByte;
    }
}
