using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System.SmProPub.Event
{
    /// <summary>
    /// Window窗体处理消息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class EventHandler : ObjectEvent
    {
        /// <summary>
        /// 当任何控件活动时引发的事件<para>通常标记为(C*)</para>
        /// </summary>
        public event ObjectEventArg ChangeObject;
        /// <summary>
        /// 当继承的Save发生改变时引发事件
        /// </summary>
        public event ObjectEventArg ChangeObjectSave;
        /// <summary>
        /// 当继承的Name发生变化时
        /// </summary>
        public event ObjectEventArg ChangeObjectName;
        /// <summary>
        /// 重写的Save
        /// </summary>
        public override object Save
        { 
            get 
            { 
                return base.Save;
            } 
            set 
            { 
                if (ChangeObjectSave != null) 
                    ChangeObjectSave(value, this); 
                base.Save = value; 
            } 
        }
        /// <summary>
        /// 重写的Name
        /// </summary>
        public override string Name {
            get 
            { 
                return base.Name; 
            }
            set 
            {
                if (ChangeObjectName != null)
                    ChangeObjectName(value, this);
                base.Name = value; 
            } 
        }
        /// <summary>
        /// (C*)重新定义消息发送
        /// </summary>
        public void SenderMsg(object sender)
        {
            if (ChangeObject != null)
                ChangeObject(sender, this);
            base.SenderMsg(sender, this);
        }
    }
}
