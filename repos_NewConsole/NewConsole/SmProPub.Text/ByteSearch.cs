using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.Text
{
    /// <summary>
    /// 搜索Byte的查找
    /// </summary>
    public static class ByteSearch
    {
        /// <summary>
        /// 删除空字符(00字符)
        /// </summary>
        /// <param name="beffer">操控的项目</param>
        public static byte[] EmptyBytes(byte[] beffer)
        {
            return EmptyBytes(beffer, 0);
        }
        /// <summary>
        /// 删除哪些字符
        /// </summary>
        /// <param name="beffer">操控项目</param>
        /// <param name="delete">删除的字节</param>
        public static byte[] EmptyBytes(byte[] beffer, byte delete)
        {
            List<byte> b = new List<byte>();
            for (int i = 0; i < beffer.LongLength; i++)
            {
                if (delete != beffer[i])
                    b.Add(beffer[i]);
            }
            return b.ToArray();
        }
    }
}
