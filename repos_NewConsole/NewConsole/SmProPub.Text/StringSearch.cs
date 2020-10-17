using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.Text
{
    /// <summary>
    /// 搜索string文本
    /// </summary>
    public static class StringSearch
    {
        /// <summary>
        /// 查找文本出现重复的百分比
        /// </summary>
        /// <param name="arg">文本</param>
        /// <param name="begin">对比文本</param>
        /// <returns></returns>
        public static double SearchStringInFormat(string arg, string begin)
        {
            List<char> c = new List<char>();
            int dfdf = 0;
            for (int i = 0; i < arg.Length; i++)
            {
                for (int ii = i; ii < begin.Length + i; ii++)
                {
                    if (arg.Length <= ii)
                        break;
                    c.Add(arg[ii]);

                }
                string text = new string(c.ToArray());
                if (text == begin)
                {
                    dfdf += begin.Length;
                    i += text.Length;
                    continue;
                }
                c.Clear();
            }
            //Console.WriteLine(dfdf);
            return (double)dfdf / (double)arg.Length;
        }
        /// <summary>
        /// 制作自定义的Args
        /// </summary>
        /// <param name="arg">一个标准的arg</param>
        /// <param name="ftext">分割标识</param>
        /// <param name="setext1">暂时取消分割标识1</param>
        /// <param name="setext2">暂时取消分割标识2</param>
        /// <returns>标准的Args</returns>
        public static string[] FormatString(string arg, char ftext, char setext1, char setext2)
        {
            return FormatString(arg, ftext, setext1, setext2, 0);
        }
        /// <summary>
        /// 制作自定义的Args
        /// </summary>
        /// <param name="arg">一个标准的arg</param>
        /// <param name="ftext">分割标识</param>
        /// <param name="setext1">暂时取消分割标识1</param>
        /// <param name="setext2">暂时取消分割标识2</param>
        /// <param name="backtrue">分割几次取消分割(0表示无限)</param>
        /// <returns>标准的Args</returns>
        public static string[] FormatString(string arg, char ftext, char setext1, char setext2, int backtrue)
        {
            List<char> c = new List<char>();
            List<string> s = new List<string>();

            bool setf = false;
            int ty = 0;

            foreach (char cg in arg)
            {
                if (backtrue > 0 && ty >= backtrue)
                {
                    c.Add(cg);
                    continue;
                }
                if (!setf)
                    if (cg == ftext)
                    {
                        s.Add(new string(c.ToArray()));
                        c.Clear();
                        ty++;
                        continue;
                    }
                if (!setf && cg == setext1)
                {
                    setf = true;
                    continue;
                }
                if (setf && cg == setext2)
                {
                    setf = false;
                    continue;
                }
                c.Add(cg);
            }

            if (c.Count > 0)
                s.Add(new string(c.ToArray()));

            if (setf)
            {
                throw new SmException("输入的字符串不正确!引索超出数值界限.");
            }

            return s.ToArray();
        }
        /// <summary>
        /// 使用I Byte计算方式并带单位最大(1024计算最大)
        /// </summary>
        /// <param name="byteslong">一个byte容量</param>
        /// <param name="uotr">保留几位小数的<see cref="double"/>形式</param>
        /// <returns></returns>
        public static string FormatIB(long byteslong,string uotr)
        {
            return FormatRepp(byteslong, 1024, new string[] { " IB", " KIB", " MIB", " GIB", " TIB" }, uotr);
        }
        /// <summary>
        /// 使用Byte计算方式并带单位最大(1000计算最大)
        /// </summary>
        /// <param name="byteslong">一个byte容量</param>
        /// <param name="uotr">保留几位小数的<see cref="double"/>形式</param>
        /// <returns></returns>
        public static string FormatB(long byteslong, string uotr)
        {
            return FormatRepp(byteslong, 1000, new string[] { " B", " KB", " MB", " GB", " TB" }, uotr);
        }
        /// <summary>
        /// 连除法，当小于特定的值后，输出数值和单位
        /// </summary>
        /// <param name="byteslong">一个数</param>
        /// <param name="tro">连除进制</param>
        /// <param name="ftr">单位</param>
        /// <param name="uotr">保留几位小数的<see cref="double"/>形式</param>
        /// <returns></returns>
        public static string FormatRepp(long byteslong,int tro, string[] ftr, string uotr)
        {
            double rcfj = byteslong;
            string gr = "";

            for (int i = 0; i < ftr.Length; i++)
            {
                if (rcfj < tro)
                {
                    gr = rcfj.ToString(uotr) + ftr[i];
                    break;
                }
                rcfj /= 1000;
            }
            return gr;
        }
    }
}
