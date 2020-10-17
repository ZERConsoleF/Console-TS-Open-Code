using ConsoleG.Core.com.LoadProgram;
using System;
using System.Collections.Generic;
using System.SmProPub.ExClass;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System.SmProPub.Event
{
    /// <summary>
    /// 引发事件
    /// </summary>
    /// <param name="sender">在基于ObjectEvent方法返回的结果</param>
    /// <param name="o">基于ObjectEvent</param>
    public delegate void ObjectEventArg(object sender, ObjectEvent o);
    /// <summary>
    /// 新的事件总称
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ObjectEvent
    {
        /// <summary>
        /// 初始化ObjectEvent
        /// </summary>
        public ObjectEvent()
        {
            Name = nameof(ObjectEvent) + new Random().Next().ToString();
        }

        /// <summary>
        /// 绑定事件(不确保可以正常写入内存)
        /// </summary>
        public virtual event ObjectEventArg ObjectEventArg;

        /// <summary>
        /// 初始化ObjectEvent数值(此方法并非安全，因为用到C++的模拟组件)
        /// <para>异常:</para>
        /// <see cref="SmException"/><para><see cref="Exception"/></para>
        /// </summary>
        /// <param name="value"></param>
        [Obsolete("不安全的代码")]
        public unsafe ObjectEvent(int* value)
        {
            Name = nameof(ObjectEvent) + (int)value;
        }

        /// <summary>
        /// 保存自定义在内存
        /// </summary>
        public virtual object Save { get; set; }
        /// <summary>
        /// 获取或设置事件名称(此事件可以被保存在内存中方便提取)
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 说明事件
        /// </summary>
        public virtual string Comment { get; set; }
        /// <summary>
        /// 保存在内存
        /// </summary>
        public unsafe void CreativeMemorySave(ObjectEvent e)
        {
            Class<ObjectEvent>.Java.Finl(e, Name);
        }
        /// <summary>
        /// 得到在内存分配的
        /// <para>异常:<para /><see cref="Exception"/></para>
        /// </summary>
        /// <returns>返回一个保存在内部的class</returns>
        public unsafe ObjectEvent GetMemorySaveNG()
        {
            return Class<ObjectEvent>.Java.Finl(null, Name);
        }
        /// <summary>
        /// 向事件发送消息
        /// </summary>
        /// <param name="sender">消息类</param>
        public virtual void SenderMsg(object sender, ObjectEvent msg)
        {
            if (ObjectEventArg != null)
                ObjectEventArg(sender, msg);
        }
    }
}
