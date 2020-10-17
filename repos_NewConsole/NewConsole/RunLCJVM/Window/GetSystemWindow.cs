using ConsoleG.Core.com;
using ConsoleG.Core.com.LoadProgram;
using ConsoleG.Core.com.setting;
using Newtonsoft.Json;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLCJVM.Window
{
    class GetSystemWindow
    {
        /// <summary>
        /// 获取系统的状态
        /// </summary>
        /// <summary>
        /// 系统的Location
        /// </summary>
        public Point Location;
        /// <summary>
        /// 系统的Size
        /// </summary>
        public Size Size;
        /// <summary>
        /// 系统的焦距
        /// </summary>
        public IntPtr intPtr;
        /// <summary>
        /// 设置系统的配置文件位置（根据此值引导）
        /// </summary>
        public string FindSetWork = "..\\..\\setwork.txt";
        /// <summary>
        /// 获取系统的窗口状态
        /// </summary>
        public void GetWindowProcess()
        {
            string userr = File.ReadAllText(FindSetWork);
            CreativeMemoryty ty = new CreativeMemoryty(SmProConst.GetMainMemoryName);
            ty.Creativestr();
            MakeArggi ari = new MakeArggi();
            ari.run(Encoding.Unicode.GetString(ty.returnValeByte()).Split('\n'), 0, '-', ':');
            GetArg arg = JsonConvert.DeserializeObject<GetArg>(ari.returnTi(SmProConst.GetMainArgName));

            IntPtr indexer = OtherDllRegistry.FindWindow(null, arg.CreatTitle);

            intPtr = indexer;

            OtherDllRegistry.RECT rc = new OtherDllRegistry.RECT();

            OtherDllRegistry.GetWindowRect(indexer, ref rc);

            int width = rc.Right - rc.Left; //窗口的宽度
            int height = rc.Bottom - rc.Top - 40 - 25 - 28; //窗口的高度
            Size = new Size(width, height);
            int x = rc.Left;
            int y = rc.Top;
            Location = new Point(x, y);
            ty.Close();
        }
    }
}
