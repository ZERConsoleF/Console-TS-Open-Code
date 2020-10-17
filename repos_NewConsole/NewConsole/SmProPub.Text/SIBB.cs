using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.Text
{
    /// <summary>
    /// 声明的变量，转换总和
    /// </summary>
    public abstract class SIBB<T>
    {
        public static T[] DeleteLastOB(T[] obj)
        {
            List<T> rt = new List<T>();
            for (int x = 0; x < obj.Length - 1; x++)
                rt.Add(obj[x]);
            return rt.ToArray();
        }
    }
}
