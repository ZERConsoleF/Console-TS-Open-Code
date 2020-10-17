using ConsoleG.Network.Server;
using SmProPub;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleG.Network
{
    /// <summary>
    /// 连接由NewConsole发出的服务器
    /// </summary>
    public class NewConsoleNetCY
    {
        protected Socket sp;
        /// <summary>
        /// 配合Socket连接(服务器默认连接为TCP)
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <param name="socketType"></param>
        /// <param name="protocolType"></param>
        public NewConsoleNetCY(AddressFamily addressFamily,SocketType socketType,ProtocolType protocolType)
        {
            sp = new Socket(addressFamily, socketType, protocolType);
            AddBlind = new InfeNewConsoleHup();
            SaveInMemory(this);
            ASB();
        }
        /// <summary>
        /// 使用默认的连接方式(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        /// </summary>
        public NewConsoleNetCY()
        {
            sp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ASB();
            SaveInMemory(this);
        }

        #region 注册A
        private Thread autuocatchre = null;
        private List<Exception> sre = new List<Exception>();
        protected ServerBackAs bcs = null;
        protected Thread sleep_m_tsd = null;
        protected int m_see_sock_wa = 0;
        protected int m_see_sock_sa = 0;
        protected void ASB()
        {
            AddBlind = new InfeNewConsoleHup();
            ByteGetS = 1024;
            ByteToSp = 512;
            WaitTime = 60;
            LogUpThis = false;
            ThisName = Environment.UserName + "@" + Environment.UserDomainName;
            Server = true;
            WaitContiue = 200;
            //SenderSleeps = new List<SenderReiveSleep>();
            //ReviceSleeps = new List<SenderReiveSleep>();
        }
        protected bool LogUpThis = false;
        protected void ThrowLogUpThis()
        {
            if (sleep_m_tsd != null && sleep_m_tsd != Thread.CurrentThread)
            {
                throw new Exception(11.ToString());
                while (sleep_m_tsd != null)
                {
                    Thread.Sleep(WaitContiue);
                }
            }
            if (!LogUpThis)
            {
                throw new SmException("Fail:请登录服务器");
            }
        }
        protected bool T200(ServerBackAs fp)
        {
            if (BackNoSuccess)
            {
                if (fp.ServerConnented != 200)
                {
                    bcs = fp;
                    return false;
                }
            }
            bcs = null;
            return true;
        }
        protected void SaveInMemory(NewConsoleNetCY c)
        {
            ObjectClass<NewConsoleNetCY> v = new ObjectClass<NewConsoleNetCY>();
            v.Name = Name;
            v.IDX = v.SaveInMemory(c);
            IDX = v.IDX;
        }
        #endregion

        /// <summary>
        /// 获取在内存中的Class
        /// </summary>
        public ObjectClass<NewConsoleNetCY> GetObjectClass { get; set; }
        /// <summary>
        /// 接收窗口占用数
        /// </summary>
        public int ReviewReviceByte { get { return m_see_sock_wa; } }
        /// <summary>
        /// 发送窗口占用数
        /// </summary>
        public int ReviewSend { get { return m_see_sock_sa; } }
        /// <summary>
        /// 获取在这个声明的<see cref="Socket"/>对象
        /// </summary>
        public Socket GetThisSocket { get { return sp; } }
        /// <summary>
        /// 声明标识
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 项目注册排名
        /// </summary>
        public int IDX { get; set; }
        /// <summary>
        /// 是服务器还是客户端
        /// </summary>
        public bool Server { get; protected set; }
        /// <summary>
        /// 是否登录
        /// </summary>
        public bool LogUped { get { return LogUpThis; } }
        /// <summary>
        /// 发送名
        /// </summary>
        public string ThisName { get; set; }
        /// <summary>
        /// 如果服务器返回非200将跳出操作
        /// </summary>
        public bool BackNoSuccess { get; set; }
        /// <summary>
        /// 超时时间(超过此时间自动跳出,引发异常)
        /// </summary>
        public int WaitTime { get; set; }
        /// <summary>
        /// 服务器等待时间(请在200~10000选择，否则影响系统正常发送)
        /// </summary>
        public int WaitContiue { get; set; }
        /// <summary>
        /// 服务器字节缓冲大小
        /// </summary>
        public long ByteGetS { get; set; }
        /// <summary>
        /// 每毫秒钟发送字节
        /// </summary>
        public int ByteToSp { get; set; }
        /// <summary>
        /// 服务器连接的参数
        /// </summary>
        public InfeNewConsoleHup AddBlind { get; set; }
        /// <summary>
        /// 连接服务器参数
        /// </summary>
        public IPEndPoint IPBlind { get; set; }
        /// <summary>
        /// 记录在操作时出现的错误
        /// </summary>
        public Exception[] Exception { get { return sre.ToArray(); } }
        /// <summary>
        /// 获取发送占用等待线路
        /// </summary>
        //public List<SenderReiveSleep> SenderSleeps { get; protected set; }
        /// <summary>
        /// 获取接收占用等待线路
        /// </summary>
        //public List<SenderReiveSleep> ReviceSleeps { get; protected set; }
        /// <summary>
        /// 当前是否为后台挂载
        /// </summary>
        public bool IsBackTaskSender { get; protected set; }

        /// <summary>
        /// 尝试连接到服务器(不登录)
        /// </summary>
        /// <returns></returns>
        public bool Connent()
        {
            //StartTimeTS("超时连接!", "Connent");
            sp.Connect(IPBlind);
            //StopTimeTS("Connent");
            return sp.Connected;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public void LogUp()
        {
            byte[] sf = Class<InfeNewConsoleHup>.Serialize(AddBlind);
            sp.Send(Encoding.Unicode.GetBytes(sf.Length.ToString()));
            Thread.Sleep(1000 + WaitContiue);
            sp.Send(sf);

            byte[] vs = new byte[1024];

            sp.Receive(vs);

            ServerBackAs ae = Class<ServerBackAs>.Deserialize(vs);

            if (ae.ServerConnented != 200)
            {
                throw new SmException(ae.ServerConnented + ":" + ae.ServerStatic);
            }

            LogUpThis = true;
        }
        /// <summary>
        /// 指定一个接收者发送
        /// <para>异常:</para>(<see cref="SmException"/>)在发送文件头出现的错误，通常表示连接断开
        /// <para>(<see cref="SmException"/>)在发送数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="af"></param>
        /// <param name="sender"></param>
        protected void Sender(Socket sp,EndPoint ipen, ServerBackAs af, byte[] sender)
        {
            ThrowLogUpThis();
            //SenderReiveSleep serg = new SenderReiveSleep();
            /*
            serg.Name = new Random().Next().ToString();
            serg.Socket = sp;
            serg.ServerBackAs = af;
            SenderSleeps.Add(serg);

            while(true)
            {
                List<SenderReiveSleep> hsrd = new List<SenderReiveSleep>();
                foreach (SenderReiveSleep s in SenderSleeps)
                {
                    if (s.Socket == sp)
                    {
                        hsrd.Add(s);
                    }
                }
                int fg = 0;
                SenderReiveSleep ty = null;
                foreach (SenderReiveSleep gt in hsrd)
                {
                    if (gt == serg)
                    {
                        gt.SleepTake = fg;
                        ty = gt;
                        //serg = gt;
                    }
                    fg++;
                }
                if (ty.Canel)
                    return;
                if (fg <= 0)
                    break;
                Thread.Sleep(WaitContiue + 1000);
            }
            serg.SenderReiving = true;
            */

            m_see_sock_sa++;

            Thread.Sleep(WaitContiue + 1500);
            af.SenderLenth = sender.LongCount();
            byte[] fgq = Class<ServerBackAs>.Serialize(af);
            try
            {
                sp.SendTo(fgq, ipen);
            }
            catch (SocketException se)
            {
                SmException s = new SmException("在发送文件头出现的错误，通常表示连接断开 (SocketException)ErrorCode:" + se.ErrorCode);
                s.ID = se.ErrorCode;
                throw s;
            }


            long sr = 0;
            long spr = 0;
            bool finish = false;
            NewSocketABEvent e = new NewSocketABEvent();
            new Thread(() =>
            {
                while (true)
                {
                    sr = 0;
                    Thread.Sleep(1000);
                    e.ByteSender = sr;
                    e.ServerBackAs = af;
                    e.SenderPres = (double)((double)spr / (double)sender.LongLength);
                    e.AllByte = sender.LongLength;
                    e.ByteSended = spr;
                        //e.ASBtye = afe.SenderBc;

                        if (SenderReviceStatic != null)
                        SenderReviceStatic(this, e);

                    if (finish)
                    {
                        e.Finish = true;
                        e.ByteSender = sr;
                        if (SenderReviceStatic != null)
                            SenderReviceStatic(this, e);
                        break;
                    }
                }
            }).Start();
            /*
            if (!Server)
                sp.Send(new byte[1]);
            else
                sp.Receive(new byte[1]);
                */
            try
            {
                foreach (byte bg in sender)
                {
                    sp.SendTo(new byte[] { bg }, ipen);
                    //Thread.Sleep(WaitContiue + 300);
                    sr += 1;
                    spr += 1;
                    sp.ReceiveFrom(new byte[1], ref ipen);
                    //Console.WriteLine(11);
                }
            }
            catch (SocketException se)
            {
                finish = true;
                SmException s = new SmException("在发送数据出现的错误，通常表示连接断开 (SocketException)ErrorCode:" + se.ErrorCode);
                s.ID = se.ErrorCode;
                throw s;
            }
            //Console.WriteLine("s:" + DateTime.Now.ToString());
            finish = true;
            m_see_sock_sa--;
            //SenderSleeps.Remove(serg);
        }
        /// <summary>
        /// 指定一个接收者发送
        /// <para>异常:</para>(<see cref="SmException"/>)在发送文件头出现的错误，通常表示连接断开
        /// <para>(<see cref="SmException"/>)在发送数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="af"></param>
        /// <param name="sender"></param>
        protected void Sender(Socket sp, ServerBackAs af, byte[] sender)
        {
            if (sp.LocalEndPoint != null)
                Sender(sp, sp.LocalEndPoint, af, sender);
            else
                Sender(sp, sp.RemoteEndPoint, af, sender);
        }
        /// <summary>
        /// 发送数据到服务器
        /// <para>异常:</para>(<see cref="SmException"/>)在发送文件头出现的错误，通常表示连接断开
        /// <para>(<see cref="SmException"/>)在发送数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="af">自定义状态回答</param>
        public void Sender(ServerBackAs af, byte[] sender)
        {
            Sender(sp, af, sender);
        }
        /// <summary>
        /// 发送数据，指定状态
        /// <para>异常:</para>(<see cref="SmException"/>)在发送文件头出现的错误，通常表示连接断开
        /// <para>(<see cref="SmException"/>)在发送数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="sender">发送数据</param>
        /// <param name="conted">服务器返回的数值</param>
        /// <param name="spind">状态回答</param>
        /// <param name="senderobject">数据类型</param>
        public void Sender(byte[] sender, int conted, string spind, string senderobject)
        {
            ServerBackAs df = new ServerBackAs();
            df.SenderLenth = sender.LongLength;
            //df.SenderBc = ByteToSp;
            df.ServerConnented = conted;
            df.ServerStatic = spind;
            df.ThisSenderObject = senderobject;
            df.ThisName = ThisName;
            Sender(df, sender);
        }
        /// <summary>
        /// 简单的发送数据
        /// <para>异常:</para>(<see cref="SmException"/>)在发送文件头出现的错误，通常表示连接断开
        /// <para>(<see cref="SmException"/>)在发送数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="sender">数据包</param>
        public void Sender(byte[] sender)
        {
            ServerBackAs df = new ServerBackAs();
            df.SenderLenth = sender.LongLength;
            //df.SenderBc = ByteToSp;
            df.ServerConnented = 200;
            df.ServerStatic = "Ok";
            Sender(df, sender);
        }
        /// <summary>
        /// 指定一个发送者接收
        /// <para>异常:</para>(<see cref="SmException"/>)无法解析null响应头,通常表示服务断开！
        /// <para>(<see cref="SmException"/>)在接收数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        protected byte[] ReviceByte(Socket sp, EndPoint point)
        {
            //SenderReiveSleep serg = new SenderReiveSleep();
            ThrowLogUpThis();
            /*
            serg.Socket = sp;
            ReviceSleeps.Add(serg);

            while (true)
            {
                List<SenderReiveSleep> hsrd = new List<SenderReiveSleep>();
                foreach (SenderReiveSleep s in ReviceSleeps)
                {
                    if (s.Socket == sp)
                    {
                        hsrd.Add(s);
                    }
                }
                int fg = 0;
                foreach (SenderReiveSleep gt in hsrd)
                {
                    if (gt == serg)
                    {
                        serg.SleepTake = fg;
                    }
                    fg++;
                }
                if (serg.Canel)
                    return new byte[0];
                if (serg.SleepTake <= 0)
                    break;
                Thread.Sleep(WaitContiue + 1000);
            }
            serg.SenderReiving = true;
            */

            m_see_sock_wa++;

            byte[] se = new byte[ByteGetS];
            sp.ReceiveFrom(se, ref point);
            ServerBackAs afe = Class<ServerBackAs>.Deserialize(se);
            if (afe == null)
            {
                SmException ser = new SmException("无法解析null响应头,通常表示服务断开！");
                ser.ID = 404;
                throw ser;
            }
            long r = afe.SenderLenth;
            se = null;
            //GC.SuppressFinalize(se);
            //Console.WriteLine(afe.SenderLenth);
            if (!T200(afe))
                return new byte[0];

            long sr = 0;
            long spr = 0;
            //int timeopen = 0;
            bool finish = false;
            NewSocketABEvent e = new NewSocketABEvent();
            e.SenderRivice = true;
            new Thread(() =>
            {
                while (!finish)
                {

                }
            }).Start();
            new Thread(() =>
            {
                while (true)
                {
                    sr = 0;
                    Thread.Sleep(1000);
                        /*
                        if (WaitTime <= timeopen)
                        {
                            //throw new SmException("超时任务! 接收无法进行 当前超时时间(S):" + WaitTime);
                        }
                        */
                    e.ByteSender = sr;
                        //timeopen++;
                        e.ServerBackAs = afe;
                    e.SenderPres = (double)((double)spr / (double)r);
                    e.AllByte = r;
                    e.ByteSended = spr;
                        //e.ASBtye = afe.SenderBc;

                        if (SenderReviceStatic != null)
                        SenderReviceStatic(this, e);

                    if (finish)
                    {
                        e.Finish = true;
                        e.ByteSender = sr;
                        if (SenderReviceStatic != null)
                            SenderReviceStatic(this, e);
                        break;
                    }
                }
            }).Start();

            //long df = 1;
            byte[] vp = new byte[afe.SenderLenth];
            //List<byte> vp = new List<byte>();
            //vp.Capacity = (int)afe.SenderLenth;
            /*5
            if (!Server)
                sp.Receive(new byte[1]);
            else
                sp.Send(new byte[1]);
            */
            //ttctime.Add(t);

            try
            {
                while (spr < afe.SenderLenth)
                {
                    byte[] bc = new byte[1];
                    //Console.WriteLine(spr + "/" + afe.SenderLenth + " " + (spr < afe.SenderLenth));
                    sp.ReceiveFrom(bc, ref point);
                    vp[spr] = bc[0];
                    //vp.AddRange(bc);
                    //GC.SuppressFinalize(bc);
                    sr += 1;
                    spr += 1;
                    //timeopen = 0;
                    sp.SendTo(bc, point);
                    bc = null;
                    //Thread.Sleep(150);
                    //Console.WriteLine(spr + " " + afe.SenderLenth);
                }
            }
            catch (SocketException set)
            {
                finish = true;
                SmException s = new SmException("在接收数据出现的错误，通常表示连接断开 (SocketException)ErrorCode:" + set.ErrorCode);
                s.ID = 404;
                throw s;
            }
            finish = true;

            m_see_sock_wa--;

            //ttctime.Remove(t);
            //Console.WriteLine("r:" + DateTime.Now.ToString());
            //ReviceSleeps.Remove(serg);
            return vp;
        }
        /// <summary>
        /// 指定一个发送者接收
        /// <para>异常:</para>(<see cref="SmException"/>)无法解析null响应头,通常表示服务断开！
        /// <para>(<see cref="SmException"/>)在接收数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        protected byte[] ReviceByte(Socket sp)
        {
            if (sp.RemoteEndPoint != null)
                return ReviceByte(sp, sp.RemoteEndPoint);
            else
                return ReviceByte(sp, sp.LocalEndPoint);
        }
        /// <summary>
        /// 从服务器接收数据
        /// <para>异常:</para>(<see cref="SmException"/>)无法解析null响应头,通常表示服务断开！
        /// <para>(<see cref="SmException"/>)在接收数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <returns></returns>
        public byte[] ReviceByte()
        {
            return ReviceByte(sp);
        }
        /// <summary>
        /// 接收服务器消息
        /// <para>异常:</para>(<see cref="SmException"/>)无法解析null响应头,通常表示服务断开！
        /// <para>(<see cref="SmException"/>)在接收数据出现的错误，通常表示连接断开</para>
        /// </summary>
        /// <param name="bc">可以传递的变量</param>
        /// <returns></returns>
        public long Revice(ref byte[] bc)
        {
            bc = ReviceByte();
            return bc.LongLength;
        }


        /// <summary>
        /// 获取最后一次没有返回200的状态(成功为null)
        /// </summary>
        /// <returns></returns>
        public ServerBackAs GetLastNoSuccess()
        {
            return bcs;
        }
        /// <summary>
        /// 自动捕获发送的数据
        /// </summary>
        public void AutuoRevice()
        {
            autuocatchre = new Thread(() => {
                int ider = 0;
                IPEndPoint tiy = (IPEndPoint)sp.LocalEndPoint;
                while(true)
                {
                    try
                    {
                        byte[] ty = ReviceByte();
                        if (SenderByteCY != null)
                        {
                            ServerSenderOveEvent ov = new ServerSenderOveEvent();
                            ov.Sender = sp;
                            ov.SenderList = 0;
                            ov.SenderOver = ty;
                            ov.SenderTime = DateTime.Now;

                            SenderByteCY(this, ov);
                        }
                        ider = 0;
                    }
                    catch (Exception ex)
                    {
                        if (ex is SmException)
                        {
                            SmException sep = (SmException)ex;
                            if (sep.ID == 404)
                            {
                                NetWorkExceptionClosed tun = new NetWorkExceptionClosed();
                                tun.IPAddress = tiy;
                                ExceptionClosed?.Invoke(this, tun);
                                break;
                            }
                        }
                        if (ider >= 3)
                        {
                            ExceptionAdd(ex);
                            LogUpThis = false;
                            sp.Close();
                            break;
                        }
                        else
                        {
                            ider++;
                        }
                    }
                }
            });
            autuocatchre.IsBackground = true;
            autuocatchre.Start();
        }
        /// <summary>
        /// 停止自动捕获发送的数据
        /// </summary>
        public void StopAutuoRevice()
        {
            if (autuocatchre != null)
            {
                autuocatchre.Interrupt();
                autuocatchre.Abort();
                autuocatchre = null;
            }
        }
        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="add">错误描述</param>
        public void ExceptionAdd(Exception add)
        {
            sre.Add(add);
            if (ExceptionHappen != null) ExceptionHappen(this, new ObjectEvent());
        }

        /// <summary>
        /// 在后面发送的<see cref="Socket">对象必须等待此线程结束后执行
        /// </summary>
        /// <param name="t">等待线程</param>
        public void WaitForThisThreadAtSocket(Thread t)
        {
            if (t == null)
                throw new SmException("线程无效，无法获取null线程", "None", -65011, "jnic 02", "move r7");
            if (sleep_m_tsd != null)
                throw new SmException("已有线程被等待", "None", -65012, "jnic 10", "move 4o");
            sleep_m_tsd = t;
        }
        /// <summary>
        /// 获取等待对象的线程
        /// </summary>
        /// <returns></returns>
        public Thread GetWaitForThisThreadAtSocket()
        {
            return sleep_m_tsd;
        }
        /// <summary>
        /// 强行结束等待此线程结束后执行任务
        /// </summary>
        /// <param name="dis">是否终止线程</param>
        public void StopWaitForThisThreadAtSocket(bool dis)
        {
            if (sleep_m_tsd == null)
                return;
            if (dis)
                sleep_m_tsd.Abort();
            sleep_m_tsd = null;
        }

        /// <summary>
        /// 通过搜索Name值返回
        /// </summary>
        /// <param name="name">Name Text</param>
        /// <returns></returns>
        public static NewConsoleNetCY GetSocketInName(string name)
        {
            foreach (NewConsoleNetCY d in ObjectClass<NewConsoleNetCY>.GetIndexl)
            {
                if (d.Name == name)
                {
                    return d;
                }
            }
            return null;
        }
        /// <summary>
        /// 通过搜索IDX值返回
        /// </summary>
        /// <param name="idx">IDX Number</param>
        /// <returns></returns>
        public static NewConsoleNetCY GetSocketInIDX(int idx)
        {
            foreach (NewConsoleNetCY d in ObjectClass<NewConsoleNetCY>.GetIndexl)
            {
                if (d.IDX == idx)
                {
                    return d;
                }
            }
            return null;
        }

        /// <summary>
        /// 关闭连接(连接释放)
        /// </summary>
        public void Close()
        {
            LogUpThis = false;
            bcs = null;
            if (sp != null)
                sp.Close();
            sp = null;
            if (Closed != null)
                Closed(this, null);
        }
        /// <summary>
        /// 释放关于这个的所有进程占用
        /// </summary>
        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 挂载连接(后台挂载)<para>关闭现有连接，但不释放，再登陆时无需登录</para>
        /// </summary>
        [Obsolete("没有完工，调用将会无效")]
        public void VirtualClose()
        {
            return;
            if (!IsBackTaskSender)
                return;
            Sender(Encoding.Default.GetBytes("Sleep.VirtualClose()"));
            sp.Disconnect(true);
            IsBackTaskSender = true;
        }
        /// <summary>
        /// 重新恢复后台连接
        /// </summary>
        [Obsolete("没有完工，调用将会无效")]
        public void VirtualConnent()
        {
            return;
            if (!IsBackTaskSender)
                return;
            sp.Connect(IPBlind);
            IsBackTaskSender = false;
        }

        #region
        /// <summary>
        /// 当有Exception引发时出现
        /// </summary>
        public event ObjectEventArg ExceptionHappen;
        /// <summary>
        /// 发送或接收状态的事件(事件为<see cref="NewSocketABEvent">)
        /// </summary>
        public event ObjectEventArg SenderReviceStatic;
        /// <summary>
        /// 当有服务器数据发送过来触发(sender为this)
        /// </summary>
        public event ObjectEventArg SenderByteCY;
        /// <summary>
        /// 关闭连接发生
        /// </summary>
        public event ObjectEventArg Closed;
        /// <summary>
        /// 当接收或发送出现错误时(或强制关闭时)(事件为<see cref="NetWorkExceptionClosed">)
        /// </summary>
        public event ObjectEventArg ExceptionClosed;
        #endregion
    }
}
