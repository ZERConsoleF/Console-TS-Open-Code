using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Core.net
{
    /// <summary>
    /// SmPro程序集，加载信息
    /// </summary>
    public class LoadInfoClass
    {
        /// <summary>
        /// 初始加载信息
        /// </summary>
        public LoadInfoClass()
        {
            Versign = "V1.0.0";
            Comment = "";
            Copyright = "Copyright (C)  " + DateTime.Now.Year;
            NameLoad = "SeeMods Forexcm";
            ShowName = "Forexcm";
            Package = "Excm";
            ProgramLoad = new string[0];
            ETC = new object[0];
        }
        /// <summary>
        /// 版本信息
        /// </summary>
        public string Versign { get; set; }
        /// <summary>
        /// 文件说明
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// 程序名称
        /// </summary>
        public string NameLoad { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName { get; set; }
        /// <summary>
        /// 程序包的名称（程序包要和新建的程序包一致，否则会无法将此说明带回或其他的错误）
        /// </summary>
        public string Package { get; set; }
        /// <summary>
        /// 挂载的的程序名称（后续任务管理器可以操控）
        /// </summary>
        public string[] ProgramLoad { get; set; }
        /// <summary>
        /// 其他(可以当做储存)
        /// </summary>
        public object[] ETC { get; set; }
    }
}
