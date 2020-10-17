using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmProPub;

namespace SmProPub.IO.Drive
{
    /// <summary>
    /// 磁盘类型
    /// </summary>
    public enum DriveType
    {
        Drive,USB,HD_Drive,ETC
    }
    /// <summary>
    /// 创建磁盘的信息
    /// </summary>
    public class CreatVirDrive
    {
        /// <summary>
        /// 磁盘信息，通常为磁盘的型号
        /// </summary>
        public string DriveInfo { get; set; }
        /// <summary>
        /// 磁盘卷号
        /// </summary>
        public string DrivePrInfo { get; set; }
        /// <summary>
        /// 磁盘是属于哪一个类型的
        /// </summary>
        public DriveType DrivePCPRInfo { get; set; }
        /// <summary>
        /// 磁盘的大小(KB单位)
        /// </summary>
        public long BytesDriveMe { get; set; }
        /// <summary>
        /// 磁盘的特别标注
        /// </summary>
        public string ETC { get; set; }
    }
    /// <summary>
    /// VirDrive Object Creative or WR
    /// </summary>
    public class VirDrive
    {
        /// <summary>
        /// 预留的磁盘填写信息
        /// </summary>
        public static readonly int CreatIC = 460;
        /// <summary>
        /// 创建磁盘
        /// </summary>
        /// <returns>空磁盘分区</returns>
        public static byte[] CreativeCTDR(CreatVirDrive cty)
        {
            string sy = JsonConvert.SerializeObject(cty);
            byte[] bc = new byte[CreatIC + cty.BytesDriveMe * 1024];
            byte[] cp = Encoding.Unicode.GetBytes(sy);
            if (cp.Length > CreatIC)
            {
                SmException ec = new SmException();
                ec.CodeLine = "mov 0t,00;xc sd,fffff";
                ec.Debug = "请减小某些变量的值长度";
                ec.FailWhy = "执行时出现溢出 " + cp.Length + "/" + CreatIC;
                ec.message = "这个错误导致整个新建终止";
                ec.ID = -102496;
                throw ec.RunSmProEx();
            }
            for (int x = 0; x < cp.Length; x++)
            {
                bc[x] = cp[x];
            }
            return bc;
        }

        #region
        bool readnotDis { get; set; }
        CreatVirDrive preatVirDrive;
        byte[] tempme;
        long poxc;
        /// <summary>
        /// 获取或设置读取的指针位置
        /// </summary>
        public long PointerDrive { get { return poxc - CreatIC; } 
            set 
            {
            if (value >= tempme.LongLength - CreatIC)
                {
                    SmException ec = new SmException();
                    ec.CodeLine = "mov at,96;ccccc";
                    ec.Debug = "自行解决";
                    ec.FailWhy = "超出字节组范围";
                    ec.message = "这个错误使指针错误定向，但未写入";
                    ec.ID = -705;
                    throw ec.RunSmProEx();
                }
                poxc = value + CreatIC;
            } 
        }
        #endregion

        private void CloseEx()
        {
            if (!readnotDis)
            {
                SmException ec = new SmException();
                ec.message = "这个类已经将类分离";
                throw ec.RunSmProEx();
            }
        }

        /// <summary>
        /// 打开虚拟磁盘
        /// </summary>
        public VirDrive(byte[] fl)
        {
            if (readnotDis)
            {
                SmException ec = new SmException();
                ec.message = "这个类有挂载的磁盘";
                throw ec.RunSmProEx();
            }

            byte[] bce = new byte[CreatIC];
            for (int x = 0; x < bce.Length; x++)
                bce[x] = fl[x];
            CreatVirDrive cp;
            try
            {
                cp = JsonConvert.DeserializeObject<CreatVirDrive>(Encoding.Unicode.GetString(bce));
            }
            catch (Exception ex)
            {
                SmException ec = new SmException();
                ec.CodeLine = "mov 0t,00;ccccc";
                ec.Debug = "这个问题无法简单解决\nJson:\n" + ex.Message;
                ec.FailWhy = "磁盘结构丢失，磁盘信息错误";
                ec.message = "这个错误导致整个磁盘无法读取";
                ec.ID = -1;
                throw ec.RunSmProEx();
            }
            readnotDis = true;
            preatVirDrive = cp;
            tempme = fl;
            PointerDrive = 0;
        }
        /// <summary>
        /// 返回(不包含信息头)所有字节头
        /// </summary>
        /// <returns></returns>
        public long ReturnByteOfDrive()
        {
            CloseEx();
            return tempme.LongLength - CreatIC;
        }
        /// <summary>
        /// 返回  磁盘的内容
        /// </summary>
        /// <returns></returns>
        public byte[] ReturnByteValue()
        {
            CloseEx();
            byte[] cp = new byte[ReturnByteOfDrive()];
            for (int x = CreatIC; x < tempme.Length; x++)
                cp[x - CreatIC] = tempme[x];
            return cp;
        }
        /// <summary>
        /// 指针写入磁盘
        /// </summary>
        /// <param name="ru"></param>
        public void PointerByteToBytes(byte[] ru)
        {
            CloseEx();
            for (int x = 0; x < ru.LongLength;poxc++)
            {
                tempme[poxc] = ru[x];
                x++;
            }
        }
        /// <summary>
        /// 选择返回字节
        /// </summary>
        /// <param name="idx">最大的选择</param>
        /// <returns></returns>
        public byte[] PointerByteToRead(int idx)
        {
            CloseEx();
            List<byte> cp = new List<byte>();
            for (; poxc <= idx; poxc++)
            {
                cp.Add(tempme[poxc]);
            }
            return cp.ToArray();
        }
        /// <summary>
        /// 返回磁盘文件byte
        /// </summary>
        /// <returns></returns>
        public byte[] ReturnDrive()
        {
            CloseEx();
            return tempme;
        }
        /// <summary>
        /// 返回  信息头
        /// </summary>
        /// <returns></returns>
        public CreatVirDrive ReturnTopInfo()
        {
            CloseEx();
            return preatVirDrive;
        }
        /// <summary>
        /// 关闭引索并销毁
        /// </summary>
        public void Close()
        {
            poxc = 0;
            tempme = null;
            preatVirDrive = null;
            readnotDis = false;
        }
        /// <summary>
        /// 是否关闭销毁
        /// </summary>
        /// <returns></returns>
        public bool Closed()
        {
            return !readnotDis;
        }
    }
    /// <summary>
    /// 磁盘引索标记
    /// </summary>
    public enum CreatPxDx
    {
        A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
    }
    /// <summary>
    /// 磁盘分配的格式化
    /// </summary>
    public enum CreatPxDil
    {

    }
    /// <summary>
    /// 新建分区时使用参数
    /// </summary>
    public class CreatPxDirive
    {
        /// <summary>
        /// 磁盘的分区型号
        /// </summary>
        public string PxPc { get; set; }
        /// <summary>
        /// 分配的磁盘大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 磁盘的标记
        /// </summary>
        public CreatPxDx ForX { get; set; }
        /// <summary>
        /// 磁盘的格式化
        /// </summary>
        public CreatPxDil ForL { get; set; }
    }
    class VLA
    {
        public CreatPxDirive[] ad { get; set; }
    }
    /// <summary>
    /// 操作磁盘的分区或卷
    /// </summary>
    public class VirDrivePxInfo
    {
        /// <summary>
        /// 分配磁盘读写时的信息
        /// </summary>
        public readonly int PxSize = 2048;
        VLA q8;
        VirDrive vc;
        /// <summary>
        /// 在此磁盘分配空间
        /// </summary>
        public VirDrivePxInfo(VirDrive vcx)
        {
            if (vcx.Closed())
            {
                throw new Exception("无法创建写入，磁盘关闭");
            }
            vc = vcx;
        }
        /// <summary>
        /// 新磁盘创建格式(谨慎操作，如果是分配的，将会全部删除分配)
        /// </summary>
        public void CreativeDrivePossd()
        {
            VLA g = new VLA();
            g.ad = new CreatPxDirive[0];
            string ipm = JsonConvert.SerializeObject(g);
            vc.PointerDrive = 0;
            vc.PointerByteToBytes(Encoding.Unicode.GetBytes(ipm));
        }
        /// <summary>
        /// 返回操作执行
        /// </summary>
        /// <returns></returns>
        public VirDrive ReturnD()
        {
            return vc;
        }
    }
}
