using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub
{
    public class MakeArggi
    {
        private string[] tp1 = new string[0];
        private List<string> inputList = new List<string>();
        private List<string> inputArgList = new List<string>();
        private bool runt = false;
        private char iy = '-';
        private char isu = ':';
        /// <summary>
        /// 返回制作前的数值(非List)
        /// </summary>
        /// <returns></returns>
        public string[] returnTyli()
        {
            return tp1;
        }
        /// <summary>
        /// 返回所有在此列表的的值(null外)
        /// </summary>
        /// <returns></returns>
        public string[] returnTminuts()
        {
            List<string> st = new List<string>();
            for (int x = 0; x < (inputList.Count + inputArgList.Count) / 2; x++)
            {
                st.Add(returnListArg()[x] + isu + returnListValue()[x]);
            }
            return st.ToArray();
        }

        /// <summary>
        /// 返回值，与arg对应
        /// </summary>
        /// <returns></returns>
        public string[] returnListValue()
        {
            return inputList.ToArray();
        }
        /// <summary>
        /// 返回Arg，与值对应
        /// </summary>
        /// <returns></returns>
        public string[] returnListArg()
        {
            return inputArgList.ToArray();
        }
        /// <summary>
        /// 在数值组中，有几个arg(需要区分大小写)
        /// </summary>
        /// <param name="ve">值</param>
        /// <returns></returns>
        public int returnArgisr(string ve)
        {
            int x = 0;
            foreach (string sy in returnListArg())
            {
                if (sy == iy + ve)
                    x++;
            }
            return x;
        }
        /// <summary>
        /// 在数值组中，对应的arg数值（如果没有则null）(区分大小写)
        /// </summary>
        /// <param name="ve">值</param>
        /// <returns></returns>
        public string returnTi(string ve)
        {
            string yp = null;
            for (int x = 0; x < returnListArg().Length; x++)
            {
                if (returnListArg()[x] == iy + ve)
                {
                    yp = returnListValue()[x];
                    break;
                }
            }
            return yp;
        }
        /// <summary>
        /// 返回第一个匹配值在列表中排第几(零开始引索)(如果没有返回-1)
        /// </summary>
        /// <param name="ve"></param>
        /// <returns></returns>
        public int returnTiInt(string ve)
        {
            int yp = -1;
            for (int x = 0; x < returnListArg().Length; x++)
            {
                if (returnListArg()[x] == iy + ve)
                {
                    yp = x;
                    break;
                }
            }
            return yp;
        }
        /// <summary>
        /// 在数值组中，对应的arg数值（如果没有已默认的方式返回）(区分大小写)
        /// </summary>
        /// <param name="ve">值</param>
        /// <param name="returnabout">返回的值</param>
        /// <returns></returns>
        public string returnTi(string ve, string returnabout)
        {
            string yp = returnTi(ve);
            if (yp == null)
                yp = returnabout;
            return yp;
        }
        /// <summary>
        /// 执行制造
        /// </summary>
        /// <param name="gm">初始值，通常为args</param>
        /// <param name="cont">开始时的值引索</param>
        /// <param name="tu">在前面的标记</param>
        /// <param name="st">分开为string[]的char</param>
        public void run(string[] gm, int cont, char tu, char st)
        {
            tp1 = gm;
            iy = tu;
            int x = cont;
            isu = st;
            iy = tu;
            for (int xy = x; xy < gm.Length; xy++)
            {
                string i = gm[xy];
                if (i != "" && i[0] == tu)
                {
                    string[] tmp = i.Split(isu);
                    string arg = tmp[0];
                    string value = "";
                    for (int g = 1; g < tmp.Length; g++)
                    {
                        value += tmp[g] + st;
                    }
                    string tmp1 = "";
                    for (int g = 0; g < value.Length - 1; g++)
                    {
                        tmp1 += value[g];
                    }
                    value = tmp1;

                    inputList.Add(value);
                    inputArgList.Add(arg);

                }
                x = xy;
            }
            runt = true;
        }
    }

}
