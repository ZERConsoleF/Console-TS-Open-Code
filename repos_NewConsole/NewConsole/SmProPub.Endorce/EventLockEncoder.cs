using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.Event;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.Endorce
{
    /// <summary>
    /// 操作字节时产生输出
    /// </summary>
    public class EventLockEncoder : ObjectEvent
    {
        /// <summary>
        /// 已加密字节
        /// </summary>
        public long ByteLoadedLock { get; set; }
        /// <summary>
        /// 全部字节
        /// </summary>
        public long ByteAllLock { get; set; }
        /// <summary>
        /// 确定时间的形成
        /// </summary>
        public int TimeOpped { get; set; }
        /// <summary>
        /// 每秒读写测评
        /// </summary>
        public long TimeOppendByte { get; set; }
        /// <summary>
        /// 处理百分比
        /// </summary>
        public double ByteAcces { get { return (double)((double)ByteLoadedLock / (double)ByteAllLock * 100); } }
        /// <summary>
        /// 获取剩余时间
        /// </summary>
        public DateTime LastTime { get { return new DateTime((long)((ByteAllLock - ByteLoadedLock) * TimeOpped)); } }
    }
    /// <summary>
    /// 文件操作时产生的输出
    /// </summary>
    public class EventFileLockEncoed : ObjectEvent
    {
        /// <summary>
        /// 已加密字节
        /// </summary>
        public long ByteLoadedLock { get; set; }
        /// <summary>
        /// 全部字节
        /// </summary>
        public long ByteAllLock { get; set; }
        /// <summary>
        /// 确定时间的形成
        /// </summary>
        public int TimeOpped { get; set; }
        /// <summary>
        /// 每秒读写测评
        /// </summary>
        public long TimeOppendByte { get; set; }
        /// <summary>
        /// 处理百分比
        /// </summary>
        public double ByteAcces { get { return (double)((double)ByteLoadedLock / (double)ByteAllLock * 100); } }
        /// <summary>
        /// 获取剩余时间
        /// </summary>
        public DateTime LastTime { get { return new DateTime((long)((ByteAllLock - ByteLoadedLock) * TimeOpped)); } }
        /// <summary>
        /// 获取文件读写的状态
        /// </summary>
        public EventFileStatus FileStatus { get; set; }
    }
    /// <summary>
    /// 当前文件的操作状态
    /// </summary>
    public enum EventFileStatus
    {
        /// <summary>
        /// 通常在完成以后
        /// </summary>
        Finish,
        /// <summary>
        /// 通常表示正在加密执行
        /// </summary>
        LockControl,
        /// <summary>
        /// 通常表示正在解密执行
        /// </summary>
        UnLockControl,
        /// <summary>
        /// 通常表示正在寻找最后一次处理的标点
        /// </summary>
        Find
    }
}
