using SmPro.System;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleG.Network.Server
{
    /// <summary>
    /// NewConsole服务器控制
    /// </summary>
    public class NewConsoleNetSr : NewConsoleNetCY
    {
        /// <summary>
        /// 配合Socket连接(服务器默认连接为TCP)
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <param name="socketType"></param>
        /// <param name="protocolType"></param>
        public NewConsoleNetSr(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            sp = new Socket(addressFamily, socketType, protocolType);
            AddBlind = new InfeNewConsoleHup();
            ASB();
        }
        /// <summary>
        /// 使用默认的连接方式(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        /// </summary>
        public NewConsoleNetSr()
        {
            sp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ASB();
        }

        private Thread fs;
        //private ServerIns i;
        protected List<SaveServerSocket> sip = new List<SaveServerSocket>();
        //protected List<object[]> ipob = new List<object[]>();
        protected bool bcl = false;
        protected new void ASB()
        {
            ListernAbout = 500;
            SaveAp = false;
            ServerBindAbout = new ServerLogUp();
            base.ASB();
            Server = true;
            FailReset = 10;
            ServerCAIIndices = new List<ServerCAIIndex>(new ServerCAIIndex[] { new ServerUserCCPwd() });
            SaveInMemory(this);
        }
        protected void SaveInMemory(NewConsoleNetSr c)
        {
            ObjectClass<NewConsoleNetSr> v = new ObjectClass<NewConsoleNetSr>();
            v.Name = Name;
            v.IDX = v.SaveInMemory(c);
            IDX = v.IDX;
        }

        /// <summary>
        /// 监听人数
        /// </summary>
        public int ListernAbout { get; set; }
        /// <summary>
        /// 保存每各人发送数据
        /// </summary>
        public bool SaveAp { get; set; }
        /// <summary>
        /// 服务器测试产生
        /// </summary>
        public ServerLogUp ServerBindAbout { get; set; }
        /// <summary>
        /// 失败重新尝试次数
        /// </summary>
        public int FailReset { get; set; }
        public List<ServerCAIIndex> ServerCAIIndices { get; set; }

        /// <summary>
        /// 开始连接
        /// </summary>
        public void Blind()
        {
            sp.Bind(IPBlind);
            sp.Listen(ListernAbout);
            bcl = LogUpThis = true;
            //Connmsd();
        }
        /// <summary>
        /// 异步开始自动接纳连接者<para>问题:</para>将永远占用主发送区(事件除外)直到最后一个<see cref="Socket"/>断开
        /// </summary>
        public void StartConnentAnys()
        {
            Connmsd();
        }
        /// <summary>
        /// 停止异步开始自动接纳<para>注意:</para>即使停止，在这之前的<see cref="Socket"/>任然在此运行
        /// </summary>
        public void StopConnentAnys()
        {
            if (fs.ThreadState == ThreadState.Running)
            {
                fs.Interrupt();
                fs.Abort();
            }
        }
        
        /// <summary>
        /// 开始接受用户申请并产生登录活动<para>注意:如果用户登录成功则返回登录用户，失败或其他因素则返回<see langword="null"/></para>
        /// </summary>
        /// <returns></returns>
        public Socket Accept()
        {
            Socket soe = sp.Accept();
            int idxs = sip.Count;
            if (LogUp(soe, idxs))
                return soe;
            return null;
        }
        protected void Connmsd()
        {
            fs = new Thread(() => {
                while(bcl)
                {
                    Socket soe = null;
                    bool bv = false;
                    int idxs = sip.Count;
                    try
                    {
                        soe = sp.Accept();
                        //SaveServerSocket s = null;
                        /*
                        foreach (SaveServerSocket sk in sip.ToArray())
                        {
                            if (sk.Sender.end)
                        }
                        */
                        if (LogUp(soe, idxs))
                        {
                            //ipob.Add(new object[] { soe, new List<object[]>() });
                            bv = true;
                            Revoices(soe, idxs);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (soe != null)
                        {
                            if (bv)
                            {
                                sip.Remove(FindSaveServerSocketSocket(soe));
                                //ipob.Remove(ipob.ToArray()[yu]);
                            }
                        }
                        ExceptionAdd(new System.Exception(string.Format("[Socket] [{0}] {1}",DateTime.Now.ToString(),ex.Message)));
                    }
                }
            });
            fs.Start();
        }
        private bool LogUp(Socket so,int idx)
        {
            int exp = 436;
            try
            {
                byte[] bce = new byte[ByteGetS];
                so.Receive(bce);
                //Console.WriteLine(Encoding.Unicode.GetString(bce));
                byte[] bp = new byte[ByteGetS + int.Parse(Encoding.Unicode.GetString(bce))];
                GC.SuppressFinalize(bce);
                InfeNewConsoleHup h = null;
                so.Receive(bp);
                h = Class<InfeNewConsoleHup>.Deserialize(bp);
                ServerIns cont = ServerIns.DeMake(h.IndexProgres);

                foreach (ServerCAIIndex ii in ServerCAIIndices)
                {
                    ii.Execute(this, h, cont);
                    if (!ii.Success)
                    {
                        exp = ii.FailCount;
                        throw ii.FailText;
                    }
                }

                /*
                bool spo = false;
                ServerUserControl pok = null;
                foreach (ServerUserControl cp in ServerBindAbout.UserSave.ToArray())
                {
                    if (cp.User == h.User)
                    {
                        if (cp.Passworld == h.Passworld)
                        {
                            spo = true;
                            pok = cp;
                            break;
                        }
                    }
                }
                if (!spo)
                {
                    exp = 5009;
                    throw new Exception("用户/密码问题");
                }
                exp = 701;

                spo = false;

                if (cont.CAIIndex == ServerBindAbout.ServerCAI)
                    if (cont.ServerIndex == ServerBindAbout.ServerInsIndex)
                        spo = true;

                exp = 703;
                if (!spo)
                {
                    throw new Exception("检验证书出错");
                }
                */

                ServerBackAs d = new ServerBackAs();
                d.ServerConnented = 200;
                d.ServerStatic = "Ok";
                try
                {
                    so.Send(Class<ServerBackAs>.Serialize(d));
                }
                catch (Exception exq)
                {
                    throw exq;
                }
                //cont.UserFA = pok;
                //i = cont;

                SaveServerSocket o = new SaveServerSocket();
                o.Sender = so;
                o.User = cont.UserFA;
                o.USIn = cont;
                o.SenderIndex = idx;
                sip.Add(o);

                if (NewSender != null)
                {
                    ServerSenderAdd oi = new ServerSenderAdd();
                    oi.LogUp = DateTime.Now;
                    oi.InsSP = cont;
                    oi.Index = idx;
                    oi.Sender = so;
                    NewSender(this, oi);
                }
            }
            catch (Exception ex)
            {
                ExceptionAdd(ex);
                ServerBackAs d = new ServerBackAs();
                d.ServerConnented = exp;
                d.ServerStatic = ex.Message;
                try
                {
                    so.Send(Class<ServerBackAs>.Serialize(d));
                    so.Close();
                }
                catch (Exception exq)
                {
                    ExceptionAdd(exq);
                }
                return false;
            }
            return true;
        }

        private void Revoices(Socket so,int idx)
        {
            Thread s = new Thread(() =>{
                Socket sor = so;
                int hasfail = 0;
                IPEndPoint piut = (IPEndPoint)sor.RemoteEndPoint;
                S:
                try
                {
                    while (true)
                    {
                        //Thread ty = new Thread(() =>
                        //{
                            int whi = idx;
                            byte[] vpe = ReviceByte(sor);
                            if (SenderByte != null)
                            {
                                ServerSenderOveEvent ov = new ServerSenderOveEvent();
                                ov.Sender = sor;
                                ov.SenderList = whi;
                                ov.SenderOver = vpe;
                                ov.SenderTime = DateTime.Now;

                                try
                                {
                                    SenderByte(this, ov);
                                }
                                catch (Exception ex)
                                {
                                    ExceptionAdd(new System.Exception(string.Format("[Socket Event] [{0}] [{1}] {2}", DateTime.Now.ToString(), piut.Address.ToString(), ex.Message)));
                                }
                            }
                            hasfail = 0;
                            if (SaveAp)
                            {
                                //object[] f = ipob[idx];
                                //List<object[]> gh = f[1] as List<object[]>;
                                //gh.Add(new object[] { DateTime.Now, vpe });
                                //object[] obji = new object[] { sor, gh };
                                //ipob[idx] = obji;
                                SaveServerSocket k = sip[idx];
                                k.SaveTime.Add(DateTime.Now);
                                k.SaveBytes.Add(vpe);
                            }
                        //});
                        //ty.Start();
                        //while (ty.ThreadState == ThreadState.Running)
                            //Thread.Sleep(WaitContiue);
                        //Console.WriteLine(1);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is SmException)
                    {
                        SmException sep = (SmException)ex;
                        if (sep.ID == 404)
                        {
                            NetWorkExceptionClosed tun = new NetWorkExceptionClosed();
                            tun.IPAddress = piut;
                            ExceptionClosed?.Invoke(this, tun);
                            sip.Remove(FindSaveServerSocketSocket(sor));
                            return;
                        }
                    }
                    if (hasfail < FailReset)
                    {
                        hasfail++;
                        goto S;
                    }
                    ExceptionAdd(new System.Exception(string.Format("[Socket] [{0}] [{1}] {2} - [Close]Client MayBe Close", DateTime.Now.ToString(), piut.Address.ToString(), ex.Message.ToString())));
                    sip.Remove(FindSaveServerSocketSocket(sor));
                }
            });
            s.IsBackground = true;
            s.Start();
        }
        /// <summary>
        /// 指定发送者发送字节(指定状态)
        /// </summary>
        public void Send(Socket so, byte[] sender, int conted, string spind,string senderobject)
        {
            ServerBackAs df = new ServerBackAs();
            df.SenderLenth = sender.LongLength;
            df.SeverName = ServerBindAbout.ServerName;
            df.ServerSenderObject = senderobject;
            //df.SenderBc = ByteToSp;
            df.ServerConnented = conted;
            df.ServerStatic = spind;
            Sender(so, df, sender);
        }
        /// <summary>
        /// 指定发送者发送
        /// </summary>
        /// <param name="so"></param>
        /// <param name="sender"></param>
        public void Send(Socket so,byte[] sender)
        {
            Send(so, sender, 200, "Ok", null);
        }

        /// <summary>
        /// 通过在服务器列表中查找
        /// </summary>
        /// <returns></returns>
        public Socket FindSocketList(int idx)
        {
            try
            {
                return sip[idx].Sender;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 查找发送者在服务器位置
        /// </summary>
        /// <param name="sk"></param>
        /// <returns></returns>
        public long FindMoreSockList(Socket sk)
        {
            long x = 0;
            foreach (SaveServerSocket gh in sip.ToArray())
            {
                if (gh.Sender == sk)
                    return x;
                x++;
            }
            return -1;
        }
        /// <summary>
        /// 查找通过用户的登陆者
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public SaveServerSocket[] FindSaveServerSocketUse(string username)
        {
            try
            {
                List<SaveServerSocket> p = new List<SaveServerSocket>();
                foreach (SaveServerSocket uf in sip.ToArray())
                {
                    if (uf.User.User == username)
                        p.Add(uf);
                }
                return p.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 返回服务器人数
        /// </summary>
        /// <returns></returns>
        public long BackLongAllSocket()
        {
            return sip.LongCount();
        }
        /// <summary>
        /// 获取服务器所有登录用户
        /// </summary>
        /// <returns></returns>
        public SaveServerSocket[] GetSaveServerSockets()
        {
            return sip.ToArray();
        }
        /// <summary>
        /// 通过发送者查找储存
        /// </summary>
        /// <param name="sk"></param>
        /// <returns></returns>
        public SaveServerSocket FindSaveServerSocketSocket(Socket sk)
        {
            foreach (SaveServerSocket k in sip.ToArray())
            {
                if (k.Sender == sk)
                    return k;
            }
            return null;
        }

        /// <summary>
        /// 关闭服务器并释放连接
        /// </summary>
        public new void Close()
        {
            if (!bcl)
                return;
            if (fs.ThreadState == ThreadState.Running)
            {
                fs.Interrupt();
                fs.Abort();
            }
            bcl = LogUpThis = false;
            sp.Close();
            sip.Clear();
            //ipob.Clear();
            base.Close();
        }
        /// <summary>
        /// 指定关闭的人关闭连接
        /// </summary>
        /// <param name="sk"></param>
        public void Close(Socket sk)
        {
            long yu = FindMoreSockList(sk);
            sip.Remove(FindSaveServerSocketSocket(sk));
            //ipob.Remove(ipob.ToArray()[yu]);
            NewWorkServerClosed c = new NewWorkServerClosed();
            c.IPAddress = (IPEndPoint)sk.RemoteEndPoint;
            sk.Close();
            Closed?.Invoke(this, c);
        }

        #region Event
        /// <summary>
        /// 当有数据发送过来触发(sender为this)(事件为<see cref="ServerSenderOveEvent">)
        /// </summary>
        public event ObjectEventArg SenderByte;
        /// <summary>
        /// 当接收或发送出现错误时(或强制关闭时)(事件为<see cref="NetWorkExceptionClosed">)
        /// </summary>
        public new event ObjectEventArg ExceptionClosed;
        /// <summary>
        /// 当有连接时触发
        /// </summary>
        public event ObjectEventArg NewSender;
        /// <summary>
        /// 关闭连接发生(事件为<see cref="NewWorkServerClosed"/>)
        /// </summary>
        public new event ObjectEventArg Closed;
        #endregion
    }

    public class ServerUserCCPwd : ServerCAIIndex
    {
        public SmException FailText { get; set; }
        public bool Success { get; set; }
        public int FailCount { get; set; }

        public void Execute(NewConsoleNetSr c, InfeNewConsoleHup i, ServerIns s)
        {
            bool spo = false;
            ServerUserControl pok = null;
            foreach (ServerUserControl cp in c.ServerBindAbout.UserSave.ToArray())
            {
                if (cp.User == i.User)
                {
                    if (cp.Passworld == i.Passworld)
                    {
                        spo = true;
                        pok = cp;
                        break;
                    }
                }
            }
            if (!spo)
            {
                FailCount = 5009;
                Success = false;
                FailText = new SmException("用户/密码问题");
                return;
            }

            spo = false;

            if (s.CAIIndex == c.ServerBindAbout.ServerCAI)
                if (s.ServerIndex == c.ServerBindAbout.ServerInsIndex)
                    spo = true;

            FailCount = 703;
            if (!spo)
            {
                Success = false;
                FailText = new SmException("检验证书出错");
                return;
            }

            s.UserFA = pok;
            s.UserIndex = i.UnIndex;
            //i = cont;

            Success = true;
        }
    }
}
