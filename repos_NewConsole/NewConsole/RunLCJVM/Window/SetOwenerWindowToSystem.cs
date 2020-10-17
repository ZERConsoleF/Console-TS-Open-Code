using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunLCJVM.Window
{
    /// <summary>
    /// 设置自己的窗口到SeeMods的Main窗口
    /// </summary>
    public class SetOwenerWindowToSystem
    {
        int resetrun = 3;
        MainWindow mct;
        Form sert;
        /// <summary>
        /// 初始化加载(仅带入<see cref="MainWindow"/>)
        /// </summary>
        /// <param name="mce">在<see cref="MainWindow"/>申请变量</param>
        public SetOwenerWindowToSystem(MainWindow mce)
        {
            mct = mce;
        }
        /// <summary>
        /// 初始化加载(带入<see cref="MainWindow"/>and<see cref="Form"/>)
        /// </summary>
        /// <param name="mce">在<see cref="MainWindow"/>申请变量</param>
        /// <param name="fc">带入的变量</param>
        public SetOwenerWindowToSystem(MainWindow mce, Form fc)
        {
            mct = mce;
            sert = fc;
        }
        /// <summary>
        /// 带入需要操控的Window
        /// </summary>
        /// <param name="fc">Object Form T</param>
        /// <returns>Form</returns>
        public Form SetSunWindow(Form fc)
        {
            sert = fc;
            return sert;
        }
        /// <summary>
        /// 设置窗体在此位置
        /// </summary>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        public void SetLocation(int x, int y)
        {
            y = y + mct.TitlePan.Height;
            sert.Location = new System.Drawing.Point(x, y);
        }
        /// <summary>
        /// 获取窗体在此位置
        /// </summary>
        /// <returns>坐标轴</returns>
        public Point GetLocation()
        {
            Point pc = sert.Location;
            pc.Y = pc.Y - mct.TitlePan.Height;
            return pc;
        }
        /// <summary>
        /// 显示SubWindow在主窗体中(TopLevel自动为false)(会使用Invoke)
        /// </summary>
        public void Show(bool show)
        {
            int xdf = 0;
            if (mct.InvokeRequired)
            {
                mct.Invoke(new MethodInvoker(delegate { mct.Controls.Add(sert); }));
            }
            else
                mct.Controls.Add(sert);
            if (!show)
                return;
            Thread tc = new Thread(new ThreadStart(() =>
            {
                try
                {
                    Application.Run(sert);
                }
                catch (Exception ec)
                {
                    Console.WriteLine(ec.ToString());
                }
            }));
            tc.IsBackground = true;
            tc.Start();
        }
        /// <summary>
        /// 关闭释放SubWindow(可能会引发出已释放异常)
        /// </summary>
        [Obsolete("这个有很大的可能会引发异常在任何时候(除非加上try)")]
        public void CloseAndDispose()
        {
            sert.Close();
            sert.Dispose();
        }
    }
}
