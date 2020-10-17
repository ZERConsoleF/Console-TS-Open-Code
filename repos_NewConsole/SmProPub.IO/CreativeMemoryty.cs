using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;
using SmProPub;
using ConsoleG.Core.com;
using System.Threading;
using Newtonsoft.Json;
using ConsoleG.Core.com.setting;

namespace ConsoleG.Core.com.LoadProgram
{
    public class CreativleMemorySetting
    {
        public string user { get; set; }
        public string password { get; set; }
        public string Class { get; set; }
        public long size { get; set; }
        public bool PD { get; set; }
    }
    public class CreativeMemoryty
    {

        private static int memoryaill { get { return 1000; } }
        private static string mena = Path.GetTempPath() + "/$0xc000041.SmPro.WorlkOutMT.Temp." + Environment.UserName;

        private static string[] DeleteDir(string dir)
        {
            if (!Directory.Exists(dir))
                return new string[0];
            List<string> gp = new List<string>();
            try
            {
                string[] deletei = Directory.GetFiles(dir);
                foreach (string hj in deletei)
                {
                    try
                    {
                        File.Delete(hj);
                    }
                    catch
                    {
                        gp.Add("[DirF] Did't Close the Memory at this file " + hj);
                    }
                }

                deletei = Directory.GetDirectories(dir);
                foreach (string jo in deletei)
                {
                    string[] sh = DeleteDir(jo);
                    foreach (string k in sh)
                        gp.Add(k);
                }

                Directory.Delete(dir);
                gp.Add("Success Lcct the menut " + dir);
            }
            catch (Exception ex)
            {
                gp.Clear();
                gp.Add("Necessary bc " + ex.Message);
            }
            return gp.ToArray();
        }

        /// <summary>
        /// 清空产生的内存垃圾
        /// </summary>
        public static void ClearMemory()
        {
            DeleteDir(mena);
        }

        /// <summary>
        /// 创建分配，成功为0，失败为-1,有日志写入
        /// </summary>
        /// <param name="name"></param>
        /// <param name="maxMB"></param>
        /// <returns></returns>
        public static int CreativeMemory(ref UtilPrintf u, CreativleMemorySetting set)
        {
            int x = CreativeMemory(set);

            if (x == 0)
                UtilPrintf.Printf(UtilControl.Warn, ref u, "[Memory] " + FanYi.frome("console.memory", null) + " " + set.Class);
            else
                UtilPrintf.Printf(UtilControl.Error, ref u, "[Memory] Creative The Memory did't anystic");
            return x;
        }
        /// <summary>
        /// 创建分配，成功为0，失败为-1
        /// </summary>
        /// <param name="name"></param>
        /// <param name="maxMB"></param>
        /// <returns></returns>
        public static int CreativeMemory(CreativleMemorySetting set)
        {
            string mename = mena;
            string fiy = mename + "\\" + set.Class;
            try
            {
                //MemoryMappedViewAccessor yu = MemoryMappedFile.CreateNew(set.Class, set.size * 1024 * 1024 + memoryaill,MemoryMappedFileAccess.ReadWriteExecute).CreateViewAccessor();
                if (!Directory.Exists(mena))
                    Directory.CreateDirectory(mena);
                if (File.Exists(fiy))
                    File.Delete(fiy);
                File.Create(fiy).Dispose();

                if (set.size < 0)
                {
                    SmException stp = new SmException();
                    stp.Debug = "重新解决分配问题";
                    stp.FailWhy = "未知的错误";
                    stp.message = "无法新建一个小于零的文件";
                    throw stp.RunSmProEx();
                }

                if (set.PD)
                {
                    if (set.user == null || set.user == "" || set.password == null || set.password == "")
                    {
                        SmException sm = new SmException();
                        sm.Debug = "在该PD为false时请解决空值";
                        sm.message = "DC";
                        throw sm.RunSmProEx();
                    }
                }

                string tr = JsonConvert.SerializeObject(set);
                if (tr.Length > memoryaill)
                {
                    SmException sm = new SmException();
                    sm.CodeLine = "0xcBFBFA150575";
                    sm.FailWhy = "信息字符超过了限制：" + memoryaill + " Bytes";
                    sm.Debug = "尝试重新分配";
                    sm.message = "信息字符溢出！";
                    throw sm.RunSmProEx();
                }
                byte[] sz = Encoding.Unicode.GetBytes(tr);
                byte[] st = new byte[memoryaill + 12];

                for (int x = 0; x < sz.Length; x++)
                {
                    st[x] = sz[x];
                }

                //yu.WriteArray<byte>(0, sz, 0, sz.Length);
                File.WriteAllBytes(fiy,st);
                
                return 0;
            }
            catch
            {
                
                return -1;
            }
        }
        /// <summary>
        /// 知道是否创建了内存流
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistsMemoryFile(string name)
        {
            string yo = mena;
            string namep = mena + "/" + name;
            return File.Exists(namep);
        }
                /// <summary>
                /// 释放储存，失败为-1，成功为0
                /// </summary>
                /// <param name="name"></param>
                /// <returns></returns>
                public static int DisposeCreativeMemory(string name)
        {
            string namea = mena + "/" + name;
            if (File.Exists(namea))
            {
                try
                {
                    File.Delete(namea);
                }
                catch
                {
                    return -1;
                }
                return 0;
            }
            return -1;
        }

        private bool logup = false;
        private string name;
        //private MemoryMappedFile mf;
        private CreativleMemorySetting stringh;
        //private MemoryMappedViewAccessor viewAccessor;
        private byte[] butter;

        /// <summary>
        /// 关闭内存缓存,之后为null
        /// </summary>
        public void Close()
        {
            /*
            viewAccessor.Dispose();
            mf.Dispose();
            */
            butter = null;
            logup = false;
            
        }
        /// <summary>
        /// 创建SmPro的内存文件读写
        /// </summary>
        /// <param name="name"></param>
        public CreativeMemoryty(string name)
        {
            string yo = mena;
            this.name = mena + "/" + name;
            if (!File.Exists(this.name))
            {
                SmException st = new SmException();
                st.Debug = "重新解决分配问题";
                st.FailWhy = "未知的错误";
                st.message = "无法将磁盘文件映射到内存";
                throw st.RunSmProEx();
            }

            /*
            O:
            try
            {
                mf = MemoryMappedFile.OpenExisting(name, MemoryMappedFileRights.ReadWrite);
                viewAccessor = mf.CreateViewAccessor();
                this.name = name;
            }
            catch
            {
                Console.WriteLine(0);
                goto O;
            }
            */
        }
        /// <summary>
        /// 返回信息字符为Json String
        /// </summary>
        /// <returns></returns>
        public string syreturn()
        {
            return Encoding.Unicode.GetString(butter, 0, memoryaill);
        }
        /// <summary>
        /// 返回信息字符为Class Object class
        /// </summary>
        /// <returns></returns>
        public T syreturn<T>()
        {
            return JsonConvert.DeserializeObject<T>(Encoding.Unicode.GetString(butter, 0, memoryaill));
        }
        /// <summary>
        /// 如果读取有账号密码，则需要登录它，会以bool返回是否登录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passworld"></param>
        /// <returns></returns>
        public bool LogUpTheMemory(string user,string passworld)
        {
            if (!logup)
            {
                string users = stringh.user;
                string pwd = stringh.password;
                if (users == user && pwd == passworld)
                    logup = true;
                else
                    logup = false;
            }
            return logup;
        }
        /// <summary>
        /// 重新写入内存（请确保缓存正确！）
        /// </summary>
        public void RunMake()
        {
            long v = stringh.size * 1024 * 1024 + memoryaill;
            if (butter.Length > v)
            {
                SmException st = new SmException();
                st.Debug = "重新解决分配问题";
                st.FailWhy = "字节超出限制大小:" + butter.Length + ":" + v;
                st.message = "无法将内存文件写入磁盘";
                throw st.RunSmProEx();
            }

            File.WriteAllBytes(name, butter);
            /*
            viewAccessor.WriteArray<byte>(0, butter, 0, butter.Length);
            */
        }

        private void nolog()
        {
            if (!logup)
            {
                SmException sm = new SmException();
                sm.CodeLine = "0xcBFBFA150575";
                sm.FailWhy = "需要登录";
                sm.Debug = "登录";
                sm.message = "登录";
                throw sm.RunSmProEx();
            }
        }

        /// <summary>
        /// 返回全部
        /// </summary>
        /// <returns></returns>
        public byte[] returnAll()
        {
            nolog();
            return butter;
        }
        /// <summary>
        /// 返回值他为byte[]不会包含信息字符
        /// </summary>
        /// <returns></returns>
        public byte[] returnValeByte()
        {
            nolog();
            byte[] bs = new byte[butter.Length - memoryaill];
            for (int c = memoryaill; c < butter.Length; c++)
                bs[c - memoryaill] = butter[c];
            return bs;
        }
        /// <summary>
        /// 返回他的信息字符
        /// </summary>
        /// <returns></returns>
        public byte[] returnsl()
        {
            nolog();
            byte[] sdf = new byte[memoryaill];
            for (int c = 0; c < memoryaill; c++)
                sdf[c] = butter[c];
            return sdf;
        }
        /// <summary>
        /// 设置元素（此方法非常安全）
        /// </summary>
        /// <param name="bt"></param>
        public void setValue(byte[] bt)
        {
            nolog();

            byte[] st = returnsl();
            List<byte> bi = new List<byte>();
            foreach (byte b in st)
                bi.Add(b);
            foreach (byte c in bt)
                bi.Add(c);
            butter = bi.ToArray();
        }
        /// <summary>
        /// 设置所有元素
        /// </summary>
        /// <param name="bk"></param>
        [Obsolete("注意使用此方法会非常危险，如果破坏了信息头，将会整体读取不出来")]
        public void setValueALL(byte[] bk)
        {
            nolog();
            butter = bk;
        }
        /// <summary>
        /// 返回信息
        /// </summary>
        /// <returns></returns>
        public CreativleMemorySetting returnSeting()
        {
            nolog();
            return stringh;
        }
        /// <summary>
        /// 创建byte内存
        /// </summary>
        /// <param name="min">最小的读取</param>
        /// <param name="max">最大的读取</param>
        public void Creativestr()//(long min,long max)
        {
            /*
            if (min <= 0 || max < 0 || min > max)
            {
                SmException ex = new SmException();
                ex.message = "也许重新分配一下，或看一下眼科";
                ex.Debug = "建议看眼科";
                ex.CodeLine = "0xc25041,0xc54936";
                ex.FailWhy = "有一个值为非法的";
                throw ex.RunSmProEx();
            }
            if (max == 0)
            {
                OtherDllRegistry.MEMORY_INFO me = new OtherDllRegistry.MEMORY_INFO();
                OtherDllRegistry.GlobalMemoryStatusEx(ref me);
                ulong y = me.ullAvailPhys;
                max = Convert.ToInt64(y);
            }
            */
            /*
            byte[] size = new byte[memoryaill];
            viewAccessor.ReadArray<byte>(0, size, 0, size.Length);
            string sy = Encoding.Unicode.GetString(size, 0, size.Length);
            stringh = JsonConvert.DeserializeObject<CreativleMemorySetting>(sy);
            butter = new byte[Convert.ToInt64(stringh.size) + memoryaill];
            viewAccessor.ReadArray<byte>(0, butter, 0, butter.Length);
            logup = !stringh.PD;
            */

            byte[] sd = File.ReadAllBytes(name);
            //Console.WriteLine(sd.Length);
            butter = sd;
            byte[] ji = new byte[memoryaill];

            for (int x = 0; x < memoryaill; x++)
            {
                ji[x] = sd[x];
            }

            string sy = Encoding.Unicode.GetString(ji);
            stringh = JsonConvert.DeserializeObject<CreativleMemorySetting>(sy);
            logup = !stringh.PD;
        }
    }
}
