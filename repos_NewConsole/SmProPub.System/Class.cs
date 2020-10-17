using ConsoleG.Core.com.LoadProgram;
using SmProPub;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.SmProPub.Event;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace System.SmProPub.ExClass
{
    /// <summary>
    /// SmProPub Class执行操作
    /// </summary>
    public class Class<T>
    {
        /// <summary>
        /// 获取这个<seealso cref="T"/>的执行信息
        /// </summary>
        /// <returns></returns>
        public static Assembly GetAssembly()
        {
            return Assembly.GetAssembly(typeof(T));
        }
        /// <summary>
        /// 带参数获取这个<seealso cref="T"/>的执行信息
        /// </summary>
        /// <returns></returns>
        public static Assembly GetAssembly(T obj)
        {
            return Assembly.GetAssembly(obj.GetType());
        }

        /// <summary>
        /// Class操作控件
        /// </summary>
        public Class()
        {

        }
        /// <summary>
        /// 模拟Java的几个关键词
        /// </summary>
        public class Java
        {
            /// <summary>
            /// 模拟Java的Finl关键词，储存(如果写入请指明Object类否则使用null)
            /// </summary>
            /// <param name="obj">声明的T类</param>
            /// <returns></returns>
            public static T Finl(object obj, string arg)
            {
                if (arg == null)
                {
                    SmException ex = new SmException();
                    ex.CodeLine = "mov 0t,00;mov 1c,2t;mov o7,56,0xc000001";
                    ex.Debug = "带入的值不能以Null为结束";
                    ex.FailWhy = "Deep 'Null'";
                    ex.message = "在模拟的的Finl关键字，无法以null结尾";
                    throw ex.RunSmProEx();
                }
                //Console.WriteLine(Struct2Bytes((T)obj).Length);
                //Console.WriteLine(CreativeMemoryty.ExistsMemoryFile(arg));
                if (!CreativeMemoryty.ExistsMemoryFile(arg))
                {

                    CreativleMemorySetting st = new CreativleMemorySetting();
                    st.Class = arg;
                    st.PD = false;
                    st.size = 1024;

                    CreativeMemoryty.CreativeMemory(st);
                    CreativeMemoryty sm = new CreativeMemoryty(st.Class);
                    sm.Creativestr();
                    sm.setValue(Struct2Bytes((T)obj));
                    sm.RunMake();
                    return (T)obj;
                }
                else
                {
                    //Console.WriteLine(obj == null);
                    if (obj == null)
                    {
                        CreativeMemoryty sm = new CreativeMemoryty(arg);
                        sm.Creativestr();
                        byte[] by = sm.returnValeByte();
                        return (T)Bytes2Struct(by);
                    }
                    else
                    {
                        CreativeMemoryty sm = new CreativeMemoryty(arg);
                        sm.Creativestr();
                        sm.setValue(Struct2Bytes((T)obj));
                        sm.RunMake();
                        sm.Creativestr();
                        byte[] by = sm.returnValeByte();
                        return (T)Bytes2Struct(by);
                    }
                }
            }
            /// <summary>
            /// 判断是否可以用Finl关键词
            /// </summary>
            /// <param name="fi"></param>
            /// <returns></returns>
            public static bool IfFinl(string fi)
            {
                return CreativeMemoryty.ExistsMemoryFile(fi);
            }
            
        }
        /// <summary> 
        /// 序列化Class为Byte[](直接转换)
        /// </summary> 
        /// <param name="data">要序列化的对象</param> 
        /// <returns>返回存放序列化后的数据缓冲区</returns> 
        public static byte[] Serialize(T data)
        {
            string s = JsonConvert.SerializeObject(data);
            return Encoding.Unicode.GetBytes(s);
            /*
            return Struct2Bytes(data);
            /*
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream rems = new MemoryStream();
            formatter.Serialize(rems, data);
            return rems.GetBuffer();
            */
        }

        /// <summary> 
        /// 反序列化Byte[]为Class(直接转换)
        /// </summary> 
        /// <param name="data">数据缓冲区</param> 
        /// <returns>对象</returns> 
        public static T Deserialize(byte[] data)
        {
            //Console.WriteLine(Encoding.Unicode.GetString(data));
            return JsonConvert.DeserializeObject<T>(Encoding.Unicode.GetString(data));
            /*
            return (T)Bytes2Struct(data);
            /*
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream rems = new MemoryStream(data);
            data = null;
            return (T)formatter.Deserialize(rems);
            */
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static unsafe byte[] Struct2Bytes(object obj)
        {
            int size = Marshal.SizeOf(obj);
            byte[] bytes = new byte[size];
            fixed (byte* pb = &bytes[0])
            {
                Marshal.StructureToPtr(obj, new IntPtr(pb), true);
            }
            return bytes;
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static unsafe object Bytes2Struct(byte[] bytes)
        {
            fixed (byte* pb = &bytes[0])
            {
                return Marshal.PtrToStructure(new IntPtr(pb), typeof(T));
            }
        }

    }
    class Classr<T>
    {
        Type t_class = null;
        public byte[] Serialize()
        {
            //MethodInfo[] ig = t_class.GetRuntimeMethods();
            //ig[0].CallingConvention



            return null;
        }
    }
    /// <summary>
    /// SmPro Sub 为Class的操作做贡献
    /// </summary>
    public class ObjectClass<T>
    {
        /// <summary>
        /// 新建一个Object Class
        /// </summary>
        public ObjectClass()
        {
            Name = nameof(T);
        }
        /// <summary>
        /// Save To Memory
        /// </summary>
        public static T[] GetIndexl { get; set; }
        /// <summary>
        /// Save In Program
        /// </summary>
        /// <param name="obj"></param>
        public int SaveInMemory(T obj)
        {
            int gf = 0;
            if (GetIndexl == null)
            {
                List<T> Inv = new List<T>();
                gf = 0;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
            else
            {
                List<T> Inv = new List<T>(GetIndexl);
                gf = Inv.Count;
                Inv.Add(obj);
                GetIndexl = Inv.ToArray();
            }
            if (StaticSaveAdd != null)
            {
                StaticSaveAdd(obj, new ObjectEvent());
            }
            return gf;
        }
        /// <summary>
        /// Kill In Program
        /// </summary>
        /// <param name="obj">Kill Object</param>
        public static void DisopseInMemory(T obj)
        {
            if (GetIndexl != null)
            {
                List<T> iij = new List<T>(GetIndexl);
                iij.Remove(obj);
                GetIndexl = iij.ToArray();
            if (GetIndexl.Length <= 0)
                GetIndexl = null;
            }
        }
        /// <summary>
        /// Save To Memory Name
        /// </summary>
        public int IDX { get; set; }

        /// <summary>
        /// 释放系统资源的时候先执行的自定义释放
        /// </summary>
        public delegate void ObjectClassDispose();
        /// <summary>
        /// 系统最近引发错误时事件
        /// </summary>
        /// <param name="e"></param>
        public delegate void ObjectClassThrow(Exception e);
        /// <summary>
        /// 执行自定义的方法
        /// </summary>
        public delegate void ObjectClassArg();

        /// <summary>
        /// 在共享内存重新写入时触发
        /// </summary>
        public static event ObjectEventArg StaticSaveAdd;
        /// <summary>
        /// 绑定在释放资源时自定义释放
        /// </summary>
        public event ObjectClassDispose DisposeEvent;
        /// <summary>
        /// 系统引发的异常在执行时(ThrowException必须为true才可以)
        /// </summary>
        public event ObjectClassThrow ThrowExceptionClass;
        /// <summary>
        /// 执行全部绑定的void
        /// </summary>
        public event ObjectClassArg ObjectClassArg5;


        /// <summary>
        /// 声明的名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 是否在程序引发异常时引发(false)或保存(true)
        /// </summary>
        public bool ThrowException { get; set; }
        /// <summary>
        /// 保存的异常
        /// </summary>
        public Exception SaveExceptionThrow { get; set; }
        /// <summary>
        /// 提供保存(需要时可以从这调用)
        /// </summary>
        public virtual object SaveObject { get; set; }

        /// <summary>
        /// 释放使用的资源执行(不管你是托管的还是非托管的)
        /// </summary>
        public virtual void Dispose()
        {
            //GC.SuppressFinalize(typeof(T));
            try
            {
                if (DisposeEvent != null)
                    DisposeEvent();
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                throwex(ex);
            }
        }
        /// <summary>
        /// 收集错误
        /// </summary>
        /// <param name="ex"></param>
        public void throwex(Exception ex)
        {
            if (ThrowException)
            {
                SaveExceptionThrow = ex;
                if (ThrowExceptionClass != null)
                    ThrowExceptionClass(ex);
            }
            else
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取执行的Type
        /// </summary>
        /// <returns></returns>
        public virtual Type Assebmly()
        {
            return typeof(T);
        }

        /// <summary>
        /// 返回执行的类名
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return nameof(T);
        }
    }
}
