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
    /// 新建管理的包裹
    /// </summary>
    public class SettingPackage
    {
        /// <summary>
        /// SeeMods默认包裹名称
        /// </summary>
        public static readonly string PK_SmPro_Name = "SmProPackage";
        /// <summary>
        /// SeeMods默认缓存名称
        /// </summary>
        public static readonly string PK_SmPro_Temp_Name = "SmProTemp";
        /// <summary>
        /// SeeMods默认系统储存缓存位置列表
        /// </summary>
        public static readonly string ST_Temp_SmPro_Path = Path.GetTempPath() + "/&Temp.SmPro.xc" + new Random().Next() + "p";
        /// <summary>
        /// 初始化包裹(如果已经有包，则删除)
        /// </summary>
        public static void InitPackage(string packname)
        {
            InitPackage(packname, true);
        }
        /// <summary>
        /// 初始化包裹(是否删除原来包裹,true是,false否)
        /// </summary>
        public static void InitPackage(string packname, bool delete)
        {
            if (Directory.Exists(packname))
            {
                if (delete)
                    Directory.Delete(packname, true);
            }
            else
                Directory.CreateDirectory(packname);
        }
        /// <summary>
        /// 从本地打开包存储
        /// </summary>
        /// <param name="fileserty">包名称</param>
        public SettingPackage(string fileserty)
        {
            if (!Directory.Exists(fileserty))
            {
                SmException e = new SmException();
                e.message = "000 : 寻找包失败";
                e.ID = 1095;
                throw e;
            }
            PackAge = fileserty;
        }
        /// <summary>
        /// 包名称
        /// </summary>
        public string PackAge { get; protected set; }
        /// <summary>
        /// 读取子项包信息
        /// </summary>
        /// <param name="ifo">包查询信息</param>
        /// <returns>获取子项的文件字节</returns>
        public byte[] Read(SettingInfo ifo)
        {
            string dir = String64.FormatOverride(PackAge + "." + ifo.SubPackage, ".", "/");
            if (File.Exists(dir + "/" + ifo.FileName))
            {
                byte[] b = File.ReadAllBytes(dir + "/" + ifo.FileName);
                ifo.Read(b, this);
                return b;
            }
            return new byte[0];
        }
        /// <summary>
        /// 写入子项包信息
        /// </summary>
        /// <param name="ifo">包查询信息</param>
        /// <returns>获取子项的文件字节</returns>
        public byte[] Write(SettingInfo ifo,params object[] obj)
        {
            string dir = String64.FormatOverride(PackAge + "." + ifo.SubPackage, ".", "/");
            byte[] b = ifo.Write(this);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!File.Exists(dir + "/" + ifo.FileName))
                File.Create(dir + "/" + ifo.FileName).Dispose();
            File.WriteAllBytes(dir + "/" + ifo.FileName, b);
            return b;
        }
        /// <summary>
        /// 只创建文件或打卡并写入信息
        /// </summary>
        /// <param name="path">文件夹路径(使用"."代替)</param>
        /// <param name="filename">创建或写入文件</param>
        /// <param name="vd">数据包</param>
        public void WriteFile(string path, string filename, byte[] vd)
        {
            string dir = String64.FormatOverride(PackAge + "." + path, ".", "/");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!File.Exists(dir + "/" + filename))
                File.Create(dir + "/" + filename).Dispose();
            File.WriteAllBytes(dir + "/" + filename, vd);
        }
        /// <summary>
        /// 只读取信息
        /// </summary>
        /// <param name="path">文件夹路径(使用"."代替)</param>
        /// <param name="filename">读取文件</param>
        public byte[] ReadFile(string path, string filename)
        {
            string dir = String64.FormatOverride(PackAge + "." + path, ".", "/");
            if (File.Exists(dir + "/" + filename))
            {
                return File.ReadAllBytes(dir + "/" + filename);
            }
            return new byte[0];
        }
        /// <summary>
        /// 删除子项信息
        /// </summary>
        /// <param name="ifo">包查询信息</param>
        public void DeleteInfo(SettingInfo ifo)
        {
            string dir = String64.FormatOverride(PackAge + "." + ifo.SubPackage, ".", "/");
            if (File.Exists(dir + "/" + ifo.FileName))
                File.Delete(dir + "/" + ifo.FileName);
        }
        /// <summary>
        /// 删除子项信息和他的包所有
        /// </summary>
        /// <param name="ifo">包查询信息</param>
        public void DeleteDir(SettingInfo ifo)
        {
            string dir = String64.FormatOverride(PackAge + "." + ifo.SubPackage, ".", "/");
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);
        }
        /// <summary>
        /// 整理包裹-删除所有空文件夹和0字节文件
        /// </summary>
        public void AutoDelete()
        {
            AutoDelete(Path.GetFullPath(PackAge));
            InitPackage(PackAge);
        }
        /// <summary>
        /// 整理包裹-文件引索-删除所有空文件夹和0字节文件
        /// </summary>
        public void AutoDelete(string filepath)
        {
            foreach (string filep in Directory.GetFiles(filepath))
            {
                FileStream f = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                if (f.Length <= 0)
                {
                    f.Close();
                    f.Dispose();
                    File.Delete(filepath);
                }
            }
            foreach (string dirp in Directory.GetDirectories(filepath))
            {
                AutoDelete(filepath + "/" + dirp);
            }

            if (Directory.GetFiles(filepath).Length + Directory.GetDirectories(filepath).Length <= 0)
            {
                Directory.Delete(filepath);
            }
        }
    }
    /// <summary>
    /// 提供包的查询
    /// </summary>
    public interface SettingInfo
    {
        /// <summary>
        /// 提供子包搜索(位置用"."代替)
        /// </summary>
        string SubPackage { get; }
        /// <summary>
        /// 提供的文件搜索
        /// </summary>
        string FileName { get; }
        /// <summary>
        /// 在读取时调用的控件
        /// </summary>
        /// <param name="butter">字节</param>
        /// <param name="sp">主项搜索</param>
        void Read(byte[] butter, SettingPackage sp);
        /// <summary>
        /// 在写入时调用的控件
        /// </summary>
        /// <param name="sp">主项搜索</param>
        /// <param name="obj">替他提换</param>
        byte[] Write(SettingPackage sp,params object[] obj);
    }
}
