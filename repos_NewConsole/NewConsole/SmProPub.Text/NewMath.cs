using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.Text
{
    /// <summary>
    /// 新的数学计算
    /// </summary>
    public static class NewMath
    {
        /// <summary>
        /// 绝对值
        /// </summary>
        /// <param name="valueat">一个数</param>
        /// <returns></returns>
        public static double AdsoValueAtInt(double valueat)
        {
            if (valueat < 0)
                return -valueat;
            else
                return valueat;
        }
        /// <summary>
        /// 对这个数开平方
        /// </summary>
        /// <param name="valueat">非负数</param>
        /// <param name="havepoint">保留几位小数</param>
        /// <returns></returns>
        [Obsolete("未完工，调用它可能出现假死")]
        public static double RadSignValueAtInt(int valueat,int havepoint)
        {
            throw new SmException("为了防止假死现象，已自动跳出");
            double d = 0;
            double f = 1;
            int jk = 0;
            int ghn = 0;
            if (valueat < 0)
                throw new SmException("开根号的数不可是负数");
            while (true)
            {
                jk++;
            }
        }
    }
}
