using SmProPub.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.LogSetup
{
    /// <summary>
    /// 设置或创建Log表达
    /// </summary>
    public class LogSetup : IDisposable
    {
        /// <summary>
        /// 从文本打开Log日志(临时寄存在内存)
        /// </summary>
        /// <param name="textfor">创建的文本表达</param>
        /// <param name="logControl">规定操控表达</param>
        /// <returns>标准的Log表达</returns>
        public static LogSetup OpenInString(string textfor,LogControl logControl)
        {
            if (logControl == LogControl.FileReadWrite)
            {
                SmException spo = new SmException("当以文本方式操控时，对于文件句柄无效!");
                spo.ID = 120472;
                throw spo;
            }    
            LogSetup s = new LogSetup();
            s.stringtext = textfor;
            s.logControl = logControl;
            return s;
        }
        /// <summary>
        /// 从文件打开Log日志(没有则创建)
        /// </summary>
        /// <param name="filefor">创建的位置</param>
        /// <returns>标准的Log表达</returns>
        [Obsolete("以文本方式读取，当前未完成")]
        public static LogSetup OpenInFile(string filefor)
        {
            throw new SmException("不可调用:当前关于这个的操控无效");
            LogSetup s = new LogSetup();
            s.fileStream = new FileStream(filefor, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            s.logControl = LogControl.FileReadWrite;
            return s;
        }

        /// <summary>
        /// 新建<see cref="LogSetup"/>表达
        /// </summary>
        protected LogSetup()
        {
            HandleLogTextWritePattern = new LogTextWritePattern();
            ByteConfigsnert = 2;
        }
        protected String64 stringtext;
        protected FileStream fileStream;
        protected LogControl logControl;
        protected long posites;

        /// <summary>
        /// 获取关于<see cref="LogControl"/>控制
        /// </summary>
        public LogControl GetLogControl { get { return logControl; } }
        /// <summary>
        /// 定位指针(当为文件读写时，则默认与<see cref="FileStream"/>同步)
        /// </summary>
        [Obsolete("不可调用:这个操控是无效的")]
        public long Position { get
            {
                if (fileStream != null)
                    return fileStream.Position; 
                else 
                    return posites;
            }
            set
            {
                if (fileStream != null)
                    fileStream.Position = value;
                else
                    posites = value;
            }
        }
        /// <summary>
        /// 获取文本或文件长度(当为文件读写时，则默认与<see cref="FileStream"/>同步)
        /// </summary>
        public long Length {
            get
            {
                if (fileStream != null)
                    return fileStream.Length;
                else
                    return stringtext.Length;
            }
        }
        /// <summary>
        /// 在String模式下的行列表
        /// </summary>
        public long Lines { get { return ((string)stringtext).Split('\n').LongLength; } }
        /// <summary>
        /// 绑定日志格式
        /// </summary>
        public LogTextWritePattern HandleLogTextWritePattern { get; set; }
        /// <summary>
        /// 字节校正
        /// </summary>
        public int ByteConfigsnert { get; set; }

        /// <summary>
        /// 添加Log内容
        /// </summary>
        /// <param name="obj">Pre Object</param>
        public void Add(params object[] obj)
        {
            if (obj == null)
                return;
            if (logControl == LogControl.FileReadWrite)
            {
                HandleLogTextWritePattern.WriteText(this, obj);
                byte[] bt = Encoding.Default.GetBytes(HandleLogTextWritePattern.Text);
                fileStream.Position = fileStream.Length - 1;
                fileStream.Write(bt, 0, bt.Length);
            }
            else
            {
                if (logControl == LogControl.Read)
                {
                    SmException s = new SmException("不允许在只读模式下写入任何东西");
                    s.ID = 90045;
                    throw s;
                }
                HandleLogTextWritePattern.WriteText(this, obj);
                foreach (char cg in HandleLogTextWritePattern.Text)
                {
                    stringtext.c_change((int)Position, cg);
                    Position++;
                }
            }
        }
        /// <summary>
        /// 移除哪一行
        /// </summary>
        /// <param name="textuploctre">移除行数</param>
        public void Remove(long textuploctre)
        {
            if (logControl == LogControl.FileReadWrite)
            {
                fileStream.Position = 0;
                long reline = 0;
                long textfrh = 0;
                while (true)
                {
                    if (reline >= textuploctre)
                    {
                        fileStream.Position++;
                        while (true)
                        {
                            byte[] bt = new byte[ByteConfigsnert];
                            fileStream.Read(bt, 0, bt.Length);
                            string ingrt = Encoding.Default.GetString(bt);
                            if (ingrt.Contains("\n"))
                            {
                                break;
                            }
                            if (textfrh < fileStream.Length)
                            {
                                fileStream.Write(new byte[1], 0, 1);
                                textfrh++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                    byte[] b = new byte[ByteConfigsnert];
                    fileStream.Read(b, 0, b.Length);
                    string ingt = Encoding.Default.GetString(b);
                    if (ingt.Contains("\n"))
                    {
                        reline++;
                    }
                    textfrh++;
                }
            }
            else
            {
                if (logControl == LogControl.Read)
                {
                    SmException s = new SmException("不允许在只读模式下写入任何东西");
                    s.ID = 90045;
                    throw s;
                }
                List<string> tu = new  List<string>(((string)stringtext).Split('\n'));
                tu.Remove(tu[(int)textuploctre]);
                string ytgh = "";

                foreach (string ty in tu)
                {
                    ytgh += ty + "\n";
                }
                ytgh.Trim('\n');
                stringtext = ytgh;
            }
        }
        /// <summary>
        /// 读取哪一行
        /// </summary>
        /// <param name="textuploctre"></param>
        /// <returns></returns>
        public string[] Read(long textuploctre)
        {
            if (logControl == LogControl.FileReadWrite)
            {
                fileStream.Position = 0;
                long reline = 0;
                long textfrh = 0;
                string getrt = "";
                while (true)
                {
                    if (reline >= textuploctre)
                    {
                        fileStream.Position++;
                        while (true)
                        {
                            byte[] bt = new byte[ByteConfigsnert];
                            fileStream.Read(bt, 1, bt.Length);
                            string ingrt = Encoding.Default.GetString(bt);
                            if (ingrt.Contains("\n"))
                            {
                                break;
                            }
                        }
                        break;
                    }
                    byte[] b = new byte[ByteConfigsnert];
                    fileStream.Read(b, 0, b.Length);
                    string ingt = Encoding.Default.GetString(b);
                    if (ingt == "\n")
                    {
                        reline++;
                    }
                    textfrh++;
                }
                HandleLogTextWritePattern.Text = getrt;
                HandleLogTextWritePattern.ReadText(this);
                return HandleLogTextWritePattern.GetStrings.ToArray();
            }
            else
            {
                if (logControl == LogControl.Write)
                {
                    SmException s = new SmException("不允许在只写模式下写入任何东西");
                    s.ID = 90045;
                    throw s;
                }
                List<string> tu = new List<string>(((string)stringtext).Split('\n'));
                HandleLogTextWritePattern.Text = tu[(int)textuploctre];
                HandleLogTextWritePattern.ReadText(this);
                return HandleLogTextWritePattern.GetStrings.ToArray();
            }
        }

        /// <summary>
        /// 释放关于所有的<see cref="LogSetup"/>
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    /// <summary>
    /// 控制Log的是否允许的操控
    /// </summary>
    public enum LogControl
    {
        /// <summary>
        /// 只允许阅读
        /// </summary>
        Read,
        /// <summary>
        /// 只允许写入
        /// </summary>
        Write,
        /// <summary>
        /// 允许读出和写入
        /// </summary>
        ReadAndWrite,
        /// <summary>
        /// 以文件读写方式控制
        /// </summary>
        FileReadWrite
    }
    /// <summary>
    /// 文本写入的方式格式
    /// </summary>
    public class LogTextWritePattern
    {
        /// <summary>
        /// 新建解决
        /// </summary>
        public LogTextWritePattern()
        {
            GetStrings = new List<string>();
            GetStringTitle = new List<string>();
            GetStringTitle.Add("Event Name");
            GetStringTitle.Add("Control Name");
            GetStringTitle.Add("Date");
            GetStringTitle.Add("Text");
        }
        /// <summary>
        /// 当前格式说明
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 获取格式正文
        /// </summary>
        public virtual List<string> GetStrings { get; set; }
        /// <summary>
        /// 获取正文可能对应的的Title
        /// </summary>
        public virtual List<string> GetStringTitle { get; set; }
        /// <summary>
        /// 获取可能的正文
        /// </summary>
        public virtual String64 Text { get; set; }
        /// <summary>
        /// 在写入时发生的调用事件(储存在<see cref="GetStrings"/>)
        /// </summary>
        /// <param name="textfor">即将处理类</param>
        /// <param name="stp">本体处理</param>
        public virtual void WriteText(LogSetup stp, params object[] textfor)
        {
            string yu = string.Format("[Socket] [{0}] [{1}] {2}", textfor);
            Text = yu;
        }
        /// <summary>
        /// 在读取时发生的调用事件(储存在<see cref="Text"/>)
        /// </summary>
        /// <param name="stp">本体处理</param>
        public virtual void ReadText(LogSetup stp)
        {

        }
    }
}
