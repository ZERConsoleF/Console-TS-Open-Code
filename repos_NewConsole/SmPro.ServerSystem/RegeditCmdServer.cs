using SmProPub.MakeRun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading.Tasks;

namespace SmPro.System
{
    /// <summary>
    /// 注册命令系统
    /// </summary>
    public class RegeditCmdServer : ObjectClass<RegeditCmdServer>
    {
        /// <summary>
        /// 新建注册
        /// </summary>
        public RegeditCmdServer()
        {
            IDX = SaveInMemory(this);
            RunInGet = new List<RunCommandToServer>();
        }
        /// <summary>
        /// 注册命令
        /// </summary>
        public List<RunCommandToServer> RunInGet { get; set; }
    }
}
