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
    public class RegeditCmd : ObjectClass<RegeditCmd>
    {
        /// <summary>
        /// 新建注册
        /// </summary>
        public RegeditCmd()
        {
            IDX = SaveInMemory(this);
            RunInGet = new List<RunCommandTo>();
        }
        /// <summary>
        /// 注册命令
        /// </summary>
        public List<RunCommandTo> RunInGet { get; set; }
    }
}
