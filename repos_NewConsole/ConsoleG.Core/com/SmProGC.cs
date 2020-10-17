using ConsoleG.Core.com.LoadProgram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Core.com
{
    /// <summary>
    /// smpro GC回收
    /// </summary>
    public abstract class SmProGC
    {
        /// <summary>
        /// 清空产生的内存垃圾
        /// </summary>
        public static void ClearMemory()
        {
            CreativeMemoryty.ClearMemory();
        }
    }
}
