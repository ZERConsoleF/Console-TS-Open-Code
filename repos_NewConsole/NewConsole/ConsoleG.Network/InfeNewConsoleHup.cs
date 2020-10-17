using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network
{
    /// <summary>
    /// 连接的凭证
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class InfeNewConsoleHup
    {
        /// <summary>
        /// 新建连接密码
        /// </summary>
        public InfeNewConsoleHup()
        {
            User = "fes@get";
            Passworld = "4f9c4a5a0a1a0440z024d07g0d8s0ht2s70g4d1sggff001504454f02d1g0g2f1d0gfd46fd1hg";
            IndexProgres = "00";
            UnIndex = "4";
        }
        /// <summary>
        /// 新建连接密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="pwd">密码</param>
        public InfeNewConsoleHup(string user, string pwd)
        {
            User = user;
            Passworld = pwd;
            IndexProgres = "00";
            UnIndex = "4";
        }
        /// <summary>
        /// 新建连接密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="pwd">密码</param>
        /// <param name="inp">连接证书</param>
        /// <param name="uni">指纹</param>
        public InfeNewConsoleHup(string user, string pwd, string inp, string uni)
        {
            User = user;
            Passworld = pwd;
            IndexProgres = inp;
            UnIndex = uni;
        }
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Passworld { get; set; }
        /// <summary>
        /// 证书指纹(由服务器生成)
        /// </summary>
        public string IndexProgres { get; set; }
        /// <summary>
        /// 指纹采集码
        /// </summary>
        public string UnIndex { get; set; }
    }
    /// <summary>
    /// User Cns(标记为*登录时产生影响)
    /// </summary>
    public class ServerLogUp
    {
        /// <summary>
        /// 新建操作
        /// </summary>
        public ServerLogUp()
        {
            ServerName = "SeeMods Console LogSave";
            UserSave = new List<ServerUserControl>();
        }
        #region 登录
        /// <summary>
        /// 注册用户
        /// </summary>
        public List<ServerUserControl> UserSave { get; set; }
        #endregion
        /// <summary>
        /// 服务器名称(*)
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 用户证书保存
        /// </summary>
        public List<ServerIns> InsUSer { get; set; }
        /// <summary>
        /// 服务器的算法
        /// </summary>
        public string ServerCAI { get; set; }
        /// <summary>
        /// 服务器类型
        /// </summary>
        public string ServerInsIndex { get; set; }
    }
    /// <summary>
    /// 服务器用户连接
    /// </summary>
    public class SaveServerSocket
    {
        public SaveServerSocket()
        {
            SaveObject = new List<object>();
            SaveBytes = new List<byte[]>();
            SaveTime = new List<DateTime>();
        }
        /// <summary>
        /// 使用者
        /// </summary>
        public Socket Sender { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public ServerUserControl User { get; set; }
        /// <summary>
        /// 证书
        /// </summary>
        public ServerIns USIn { get; set; }
        /// <summary>
        /// 服务引索
        /// </summary>
        public int SenderIndex { get; set; }
        /// <summary>
        /// 储存发送类
        /// </summary>
        public List<object> SaveObject { get; set; }
        /// <summary>
        /// 储存发送字节
        /// </summary>
        public List<byte[]> SaveBytes { get; set; }
        /// <summary>
        /// 储存发送时间
        /// </summary>
        public List<DateTime> SaveTime { get; set; }
    }
    /// <summary>
    /// 服务器连接凭证操作
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ServerIns
    {
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 服务器类型
        /// </summary>
        public string ServerIndex { get; set; }
        /// <summary>
        /// CAI算法
        /// </summary>
        public string CAIIndex { get; set; }

        /// <summary>
        /// 用户绑定
        /// </summary>
        public ServerUserControl UserFA { get; set; }
        /// <summary>
        /// 用户的其他证书
        /// </summary>
        public string[] UserETCIndex { get; set; }
        /// <summary>
        /// 用户的指纹采集
        /// </summary>
        public string UserIndex { get; set; }

        /// <summary>
        /// 制作证书
        /// </summary>
        /// <returns></returns>
        public string MakeOne()
        {
            try
            {
                byte[] bc = Class<ServerIns>.Serialize(this);
                string t = string.Empty;
                foreach (byte hj in bc)
                    t += hj.ToString("x") + " ";
                return t.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 解析证书
        /// </summary>
        /// <param name="tc"></param>
        /// <returns></returns>
        public static ServerIns DeMake(string tc)
        {
            try
            {
                string[] dp = tc.Split(' ');
                List<byte> b = new List<byte>();
                foreach (string gp in dp)
                {
                b.Add(byte.Parse(gp, System.Globalization.NumberStyles.AllowHexSpecifier));
                }
                return Class<ServerIns>.Deserialize(b.ToArray());
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    /// <summary>
    /// 服务器(用户注册)算法登录操作
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ServerUserControl
    {
        /// <summary>
        /// 初始化一个值
        /// </summary>
        public ServerUserControl()
        {
            UserName = "fes.asexpet";
            User = "fes@get";
            Passworld = "4f9c4a5a0a1a0440z024d07g0d8s0ht2s70g4d1sggff001504454f02d1g0g2f1d0gfd46fd1hg";
        }
        /// <summary>
        /// 定义它
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        public ServerUserControl(string name,string user,string pwd)
        {
            UserName = name;
            User = user;
            Passworld = pwd;
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Passworld { get; set; }
        /// <summary>
        /// 其他绑定
        /// </summary>
        public object ETC { get; set; }
        /// <summary>
        /// 其他绑定
        /// </summary>
        public UserETCControl ETCConSo { get; set; }
    }
    /// <summary>
    /// 其他控制在绑定用户
    /// </summary>
    public class UserETCControl
    {
        /// <summary>
        /// 服务器这个用户等级
        /// </summary>
        public int levelAs { get; protected set; }
        /// <summary>
        /// 用户其他操控
        /// </summary>
        public string ETCControl { get; protected set; }
    }
    /// <summary>
    /// 服务器标准回答(发送)Class
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ServerBackAs
    {
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string SeverName { get; set; }
        /// <summary>
        /// 服务器的数据类型
        /// </summary>
        public string ServerSenderObject { get; set; }
        /// <summary>
        /// 服务器(回答)状态
        /// </summary>
        public string ServerStatic { get; set; }
        /// <summary>
        /// 服务器连接返回
        /// </summary>
        public int ServerConnented { get; set; }

        /// <summary>
        /// 发送者的名称
        /// </summary>
        public string ThisName { get; set; }
        /// <summary>
        /// 发送的数据类型
        /// </summary>
        public string ThisSenderObject { get; set; }

        /// <summary>
        /// 发送的字节长度
        /// </summary>
        public long SenderLenth { get; set; }
        /// <summary>
        /// 发送的缓冲大小
        /// </summary>
        //public int SenderBc { get; set; }
    }
    /// <summary>
    /// 占用等待线路
    /// </summary>
    public class SenderReiveSleep
    {
        /// <summary>
        /// 执行者名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 发送者
        /// </summary>
        public Socket Socket { get; set; }
        /// <summary>
        /// 占用数
        /// </summary>
        public int SleepTake { get; set; }
        /// <summary>
        /// 正在执行
        /// </summary>
        public bool SenderReiving { get; set; }
        /// <summary>
        /// 发送头
        /// </summary>
        public ServerBackAs ServerBackAs { get; set; }
        /// <summary>
        /// 取消操控
        /// </summary>
        public bool Canel { get; set; }
    }
}
