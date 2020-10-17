using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.SmProPub.Event;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmProPub.Endorce
{
    /// <summary>
    /// 对文件加密操作
    /// </summary>
    public sealed class FileEncoed
    {
        /// <summary>
        /// 新建加密操作
        /// </summary>
        public FileEncoed()
        {
            SystemTime = 10000;
            ThisRandom = new Random();
        }
        /// <summary>
        /// 加密的文件
        /// </summary>
        public string ThisPath { get; set; }
        /// <summary>
        /// 输出通过的加密文件
        /// </summary>
        public string AcceptPath { get; set; }
        /// <summary>
        /// 混析位置
        /// </summary>
        public int[] IDX { get; set; }
        /// <summary>
        /// 生成字节数
        /// </summary>
        public int[] IDX2 { get; set; }
        /// <summary>
        /// 生成的随机数
        /// </summary>
        public Random ThisRandom { get; set; }
        /// <summary>
        /// 用于计算时间的数
        /// </summary>
        public int SystemTime { get; set; }
        /// <summary>
        /// 开始对文件加密
        /// </summary>
        public void StartLock()
        {
            if (IDX.Length != IDX2.Length)
                throw new SmException("秘钥数量必须是一样的");
            FileStream a1 = File.Open(ThisPath, FileMode.Open, FileAccess.ReadWrite);
            FileStream a2 = File.Open(AcceptPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            EventFileLockEncoed e = new EventFileLockEncoed();
            e.TimeOpped = SystemTime;
            

            long findpa1 = 0;
            long findpa2 = 0;
            long xc = 0;
            int fggh = 0;
            bool finish = false;

            if (a2.Length > 0)
            {
                e.FileStatus = EventFileStatus.Find;
                long tmpfinda2 = a2.Length;
                while (true)
                {
                    e.ByteAllLock = a1.Length;
                    e.ByteLoadedLock = findpa1;
                    if (fggh >= IDX2.Length)
                        fggh = 0;
                    if (tmpfinda2 < IDX2[fggh])
                        break;
                    tmpfinda2 -= IDX2[fggh];
                    findpa2 += IDX2[fggh] - 1;
                    fggh++;
                    findpa1++;
                    FileControlEvent(this, e);
                }
            }
            a1.Position = findpa1;
            a2.Position = findpa2;
            e.FileStatus = EventFileStatus.LockControl;
            new Thread(() => {
                while (!finish)
                {
                    Thread.Sleep(1000);
                    e.TimeOppendByte = xc;
                    xc = 0;
                }
            }).Start();
            while (true)
            {
                if (FileControlEvent != null)
                {
                    e.ByteAllLock = a1.Length;
                    e.ByteLoadedLock = a1.Position;
                    FileControlEvent(this, e);
                }

                if (fggh >= IDX2.Length)
                    fggh = 0;
                if (a1.Length <= a1.Position)
                {
                    if (FileControlEvent != null)
                    {
                        e.FileStatus = EventFileStatus.Finish;
                        e.ByteAllLock = a1.Length;
                        e.ByteLoadedLock = a1.Position;
                        FileControlEvent(this, e);
                    }
                    break;
                }
                byte[] b1 = new byte[1];
                a1.Read(b1, 0, 1);
                byte[] b2 = Encoed.ByteLock(b1[0], IDX[fggh], IDX2[fggh], ThisRandom);
                a2.Write(b2, 0, b2.Length);

                fggh++;
                xc++;
            }

            finish = true;
            a1.Close();
            a2.Close();
        }
        /// <summary>
        /// 开始对文件解密
        /// </summary>
        public void StartUnLock()
        {
            if (IDX.Length != IDX2.Length)
                throw new SmException("秘钥数量必须是一样的");

            FileStream a2 = File.Open(ThisPath, FileMode.Open, FileAccess.ReadWrite);
            FileStream a1 = File.Open(AcceptPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            EventFileLockEncoed e = new EventFileLockEncoed();
            e.TimeOpped = SystemTime;

            long findpa1 = 0;
            long findpa2 = 0;
            long xc = 0;
            int fggh = 0;
            bool finish = false;

            if (a1.Length > 0)
            {
                e.FileStatus = EventFileStatus.Find;
                long tmpfinda2 = a1.Length;
                while (true)
                {
                    e.ByteAllLock = a2.Length;
                    e.ByteLoadedLock = findpa2;
                    if (fggh >= IDX2.Length)
                        fggh = 0;
                    if (findpa1 >= a1.Length)
                        break;
                    findpa2 += IDX2[fggh];
                    findpa1++;
                    fggh++;
                    /*
                    if (fggh >= IDX2.Length)
                        fggh = 0;
                    if (tmpfinda2 < IDX2[fggh])
                        break;
                    tmpfinda2 -= IDX2[fggh];
                    findpa2 += IDX2[fggh] - 1;
                    fggh++;
                    findpa1++;
                    */
                    FileControlEvent(this, e);
                }
            }
            a1.Position = findpa1;
            a2.Position = findpa2;
            e.FileStatus = EventFileStatus.UnLockControl;
            new Thread(() => {
                while (!finish)
                {
                    Thread.Sleep(1000);
                    e.TimeOppendByte = xc;
                    xc = 0;
                }
            }).Start();
            while (true)
            {
                if (FileControlEvent != null)
                {
                    e.ByteAllLock = a2.Length;
                    e.ByteLoadedLock = a2.Position;
                    FileControlEvent(this, e);
                }

                if (fggh >= IDX2.Length)
                    fggh = 0;
                //byte[] b1 = new byte[1];
                /*
                a1.Read(b1, 0, 1);
                byte[] b2 = Encoed.ByteLock(b1[0], IDX[fggh], IDX2[fggh], ThisRandom);
                a2.Write(b2, 0, b2.Length);
                */
                if (a2.Length <= a2.Position)
                {
                    if (FileControlEvent != null)
                    {
                        e.FileStatus = EventFileStatus.Finish;
                        e.ByteAllLock = a1.Length;
                        e.ByteLoadedLock = a1.Position;
                        FileControlEvent(this, e);
                    }
                    break;
                }
                byte[] b1 = new byte[IDX2[fggh]];
                a2.Read(b1, 0, b1.Length);
                byte b = Encoed.ByteUnLock(b1, IDX[fggh], IDX2[fggh]);
                a1.Write(new byte[] { b }, 0, 1);

                fggh++;
                xc++;
            }

            finish = true;
            a1.Close();
            a2.Close();
        }
        /// <summary>
        /// 异步开始对文件加密
        /// </summary>
        public Thread StartLockAnys()
        {
            Thread t = new Thread(() => {
                StartLock();
            });
            t.IsBackground = true;
            t.Start();
            return t;
        }
        /// <summary>
        /// 异步开始对文件解密
        /// </summary>
        public Thread StartUnLockAnys()
        {
            Thread t = new Thread(() => {
                StartUnLock();
            });
            t.IsBackground = true;
            t.Start();
            return t;
        }
        /// <summary>
        /// 在文件操作执行发生
        /// </summary>
        public event ObjectEventArg FileControlEvent;
    }
}
