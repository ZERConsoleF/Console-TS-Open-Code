using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.SmProPub.Event;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmPro.System
{
    /// <summary>
    /// 服务器查询列表
    /// </summary>
    public class ServerSenderOppo
    {
        public string GetNewSender { get; set; }
    }
    public class ItemRegedit : ObjectClass<ItemRegedit>
    {
        public ItemRegedit()
        {
            IDX = SaveInMemory(this);
            ObjectEvents = new ObjectEvent();
        }
        public ObjectEvent ObjectEvents { get; set; }
    }
}
