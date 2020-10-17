using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Core.Ln
{
    /// <summary>
    /// 统一执行统一返回
    /// </summary>
    public interface LocationFailSeeModeRun
    {
        object[] Load(object[] sender, string arg);
        object[] Loading(object[] sender, string arg);
        object[] close(object[] sender, string arg);
        object[] etc(object[] sender, string arg);
    }
}
