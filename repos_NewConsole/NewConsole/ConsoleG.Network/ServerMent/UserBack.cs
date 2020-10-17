using ConsoleG.Network.InShowClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Network.ServerMent
{
    public class UserBack : SenderClassForm
    {
        public UserBack()
        {
            ControlClass = "userback";
        }
        public List<ServerUserControl> GetServerUserControl { get; protected set; }
        public ServerLogUp GetServerLogUp { get; protected set; }

        public override void ExecuteOver(NewConsoleNetCY c, RunTServerFP r)
        {
            SenderClassForm y = r.GetBackHandleClassSender;
            ServerLogUp l = Class<ServerLogUp>.Deserialize(y.GetBytes);
            GetServerLogUp = l;
            GetServerUserControl = l.UserSave;
        }
    }
}
