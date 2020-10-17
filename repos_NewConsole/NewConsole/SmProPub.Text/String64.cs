using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub.Text
{
    /// <summary>
    /// 操控在String中的String64,可以声明<see langword="string"/>这类,不可继承，详细见官网的String64
    /// </summary>
    public sealed class String64 : IList<char>
    {
        #region 静态调用
        /// <summary>
        /// 制作标准的Args
        /// </summary>
        /// <param name="arg">一个标准的arg</param>
        /// <returns>标准的Args</returns>
        public static string[] MakeArg(string arg)
        {
            return MakeArg(arg, ' ');
        }
        /// <summary>
        /// 制作自定义的Args
        /// </summary>
        /// <param name="arg">一个标准的arg</param>
        /// <param name="ftext">分割标识</param>
        /// <returns>标准的Args</returns>
        public static string[] MakeArg(string arg, char ftext)
        {
            return MakeArg(arg, ftext, '"');
        }
        /// <summary>
        /// 制作自定义的Args
        /// </summary>
        /// <param name="arg">一个标准的arg</param>
        /// <param name="ftext">分割标识</param>
        /// <param name="setext">暂时取消分割标识</param>
        /// <returns>标准的Args</returns>
        public static string[] MakeArg(string arg, char ftext, char setext)
        {
            List<char> c = new List<char>();
            List<string> s = new List<string>();

            bool setf = false;

            foreach (char cg in arg)
            {
                if (!setf)
                    if (cg == ftext)
                    {
                        s.Add(new string(c.ToArray()));
                        c.Clear();
                        continue;
                    }
                if (cg == setext)
                {
                    setf = !setf;
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
        /// 替换指定文本(支持多项)
        /// </summary>
        /// <param name="arg">原文本</param>
        /// <param name="begin">在文本中需要替换的<see cref="string"/>字符</param>
        /// <param name="after">替换后文本标志</param>
        /// <returns></returns>
        public static string FormatOverride(string arg, string begin, string after)
        {
            string aftertext = null;

            List<char> c = new List<char>();
            for (int i = 0; i < arg.Length; i++)
            {
                for (int ii = i; ii < begin.Length + i;ii++)
                {
                    c.Add(arg[ii]);
                }
                string text = new string(c.ToArray());
                if (text == begin)
                {
                    text = after;
                    aftertext += text;
                    i += (text.Length - 1);
                    c.Clear();
                    continue;
                }
                c.Clear();
                aftertext += arg[i];
            }
            if (c.Count > 0)
            {
                aftertext += new string(c.ToArray());
            }
            return aftertext;
            /*
            for (int x = 0; x < arg.Length; x++)
            {
                List<char> c = new List<char>();
                int xd = 0;
                for (int x1 = x; x < begin.Length; x++)
                {
                    c.Add(arg[x1]);
                }
                if (new string(c.ToArray()) == begin)
                {

                }
            }
            */
        }
        #endregion
        #region 封装容器
        private List<char> sr = new List<char>();
        private bool lk = false;

        private void ThrowLock()
        {
            if (lk)
            {
                throw new SmException("容器无法设置，已被保护");
            }
        }
        #endregion
        /// <summary>
        /// 返回空的值
        /// </summary>
        public static String64 Empty { get { return new char[0]; } }

        public int Count => sr.Count;
        /// <summary>
        /// 获取当前<see cref="String64">对象中字符数
        /// </summary>
        public int Length { get => sr.Count; }

        public bool IsReadOnly => lk;

        /// <summary>
        /// 更改设置值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char this[int index] { get => sr[index]; set => c_change(index, value); }

        /// <summary>
        /// 空序列
        /// </summary>
        public String64()
        {
            sr = new List<char>(String64.Empty);
        }
        /// <summary>
        /// 新的序列
        /// </summary>
        /// <param name="v"></param>
        public String64(string v)
        {
            sr = new List<char>(v.ToCharArray());
        }
        /// <summary>
        /// 转化为string储存
        /// </summary>
        /// <param name="v"></param>
        public String64(char[] v)
        {
            sr = new List<char>(v);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="text">符合格式的string</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Format(string text,params object[] obj)
        {
            return string.Format(text, obj);
        }
        public override bool Equals(object obj)
        {
            return new string(this.sr.ToArray()) == obj.ToString();
        }
        public override int GetHashCode()
        {
            return Count;
        }
        public override string ToString()
        {
            return new string(sr.ToArray());
        }

        /// <summary>
        /// 锁定，拒绝任何写入允许读出
        /// </summary>
        public void Lock()
        {
            lk = true;
        }
        /// <summary>
        /// 解除锁定
        /// </summary>
        public void UnLock()
        {
            lk = false;
        }
        /// <summary>
        /// 返回char*
        /// </summary>
        /// <returns></returns>
        public unsafe char* c_str()
        {
            return (char*)Marshal.StringToCoTaskMemAnsi(new string(sr.ToArray()));
        }
        /// <summary>
        /// 更改组在配对的值
        /// </summary>
        /// <param name="idex"></param>
        /// <param name="y"></param>
        public void c_change(int idex,char y)
        {
            ThrowLock();
            sr[idex] = y;
            //sr = new string(p.ToArray());
        }

        public static implicit operator String64(char[] v)
        {
            String64 k = new String64(v);
            return k;
        }
        public static implicit operator String64(string v)
        {
            String64 p = new String64(v);
            return p;
        }
        public static implicit operator String(String64 v)
        {
            return new string(v.sr.ToArray());
        }
        public static bool operator ==(String64 left,String64 right)
        {
            return new string(left.sr.ToArray()) == new string(right.sr.ToArray());
        }
        public static bool operator !=(String64 left, String64 right)
        {
            return new string(left.sr.ToArray()) != new string(right.sr.ToArray());
        }
        public static bool operator ==(String64 left, String right)
        {
            return new string(left.sr.ToArray()) == right;
        }
        public static bool operator !=(String64 left, String right)
        {
            return new string(left.sr.ToArray()) != right;
        }
        public static String64 operator +(String64 left,String64 right)
        {
            left.sr.AddRange(right.sr.ToArray());
            return left;
        }
        public static String64 operator +(String64 left, String right)
        {
            left.sr.AddRange(right.ToCharArray());
            return left;
        }

        #region
        public int IndexOf(char item)
        {
            return sr.IndexOf(item);
        }

        public void Insert(int index, char item)
        {
            ThrowLock();
            sr.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ThrowLock();
            
            sr.RemoveAt(index);
            //sr = new string(p.ToArray());
        }

        public void Add(char item)
        {
            ThrowLock();
            
            sr.Add(item);
            //sr = new string(p.ToArray());
        }

        public void Clear()
        {
            ThrowLock();
            sr.Clear();
        }

        public bool Contains(char item)
        {
            return sr.Contains(item);
        }

        public void CopyTo(char[] array, int arrayIndex)
        {
            ThrowLock();
            sr.CopyTo(array, arrayIndex);
            //sr = new string(p.ToArray());
        }

        public bool Remove(char item)
        {
            ThrowLock();
            
            bool u = sr.Remove(item);
            //sr = new string(p.ToArray());
            return u;
        }

        public IEnumerator<char> GetEnumerator()
        {
            List<char> p = new List<char>(sr);
            return p.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
