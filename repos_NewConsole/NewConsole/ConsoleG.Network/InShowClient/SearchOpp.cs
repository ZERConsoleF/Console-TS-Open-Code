using ConsoleG.Network.InShowServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.InShowClient
{
    /// <summary>
    /// 服务器类查询和服务器接收类的执行
    /// </summary>
    public class SearchOpp : ObjectClass<SearchOpp>
    {
        public static SearchOpp GetClass { get; protected set; }
        /// <summary>
        /// 新建查询机制
        /// </summary>
        public SearchOpp()
        {
            GetClass = this;
            IDX = SaveInMemory(this);
            ObjectEventOppen = new List<ObjectEvent>();
            ObjectEventOppenEnd = new List<ObjectEvent>();
        }
        /// <summary>
        /// 事件(发送前)操控执行
        /// </summary>
        public List<ObjectEvent> ObjectEventOppen { get; set; }
        /// <summary>
        /// 事件(发送后)操控执行
        /// </summary>
        public List<ObjectEvent> ObjectEventOppenEnd { get; set; }
    }
    /// <summary>
    /// 新建查询
    /// </summary>
    public class SearchClass
    {
        RunTServerFP r;
        /// <summary>
        /// 新建查询
        /// </summary>
        /// <param name="r">查询服务</param>
        public SearchClass(RunTServerFP r)
        {
            if (SearchOpp.GetClass == null)
                new SearchOpp();
            this.r = r;
        }
        /// <summary>
        /// 是否取消操作
        /// </summary>
        public bool CanelControl { get; set; }
        /// <summary>
        /// 获取服务器返回的查询类
        /// </summary>
        /// <returns></returns>
        public SenderClassForm GetSenderClassFormHandle()
        {
            return r.GetBackHandleClassSender;
        }
        /// <summary>
        /// 绑定发送者
        /// </summary>
        /// <param name="c"></param>
        public void SetSenderClass(SenderClassForm c)
        {
            r.HandleClassSender = c;
        }
        /// <summary>
        /// 通过查询返回者的发送查询类名，执行发送后的事件
        /// </summary>
        public void SearchSenderInEventEnd()
        {
            SearchOpp o = SearchOpp.GetClass;
            foreach (ObjectEvent f in o.ObjectEventOppenEnd)
            {
                if (f.Name == r.GetBackHandleClassSender.ControlClass)
                {
                    f.SenderMsg(this, new ObjectEvent());
                    break;
                }
            }
        }
        /// <summary>
        /// 通过查询返回者的发送查询类名，执行发送前的事件
        /// </summary>
        public void SearchSenderInEventStart()
        {
            SearchOpp o = SearchOpp.GetClass;
            foreach (ObjectEvent f in o.ObjectEventOppen)
            {
                if (f.Name == r.GetBackHandleClassSender.ControlClass)
                {
                    f.SenderMsg(this, new ObjectEvent());
                    break;
                }
            }
        }
        /// <summary>
        /// 获取查询服务
        /// </summary>
        /// <returns></returns>
        public RunTServerFP GetSearchServer()
        {
            return r;
        }
        /// <summary>
        /// 标准的发送执行请求
        /// </summary>
        public void Sender()
        {
            SearchSenderInEventStart();
            if (CanelControl)
            {
                CanelControl = false;
                return;
            }
            r.Sender();
            SearchSenderInEventEnd();
        }
    }
}
