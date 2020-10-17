using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmPro.System
{
    /// <summary>
    /// 注册服务器查询程序菜单
    /// </summary>
    public class ServerItemRegedit
    {
        public static ServerItemRegedit CreatOrGetServerItemRegedit()
        {
            if (ServerItemRegeditr == null)
                return new ServerItemRegedit();
            else
                return ServerItemRegeditr;
        }
        public static ServerItemRegedit ServerItemRegeditr { get; set; }
        public ServerItemRegedit()
        {
            ServerItemRegeditr = this;
            ItemListCs = new List<ItemListCs>();
        }
        public List<ItemListCs> ItemListCs { get; set; }
    }
}
