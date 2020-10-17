using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.Event;
using System.Text;
using System.Threading.Tasks;

namespace SmPro.System
{
    /// <summary>
    /// 处理脚本
    /// </summary>
    public class HasServerConEvent : ObjectEvent
    {
        public ItemListCs ItemListCs { get; set; }
        public object NewConsoleCY { get; set; }
        public ConsoleShowWindow ConsoleShowWindow { get; set; }
        public ListVerCs ListVerCs { get; set;}
        public string Iinfo { get; set; }
    }
}
