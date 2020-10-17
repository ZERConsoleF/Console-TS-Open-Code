using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmProPub;

namespace ConsoleG.Core.com.setting
{
    /// <summary>
    /// 执行翻译
    /// </summary>
    public class FanYi
    {
        /// <summary>
        /// 根据系统语言翻译
        /// </summary>
        /// <param name="ve">文本</param>
        /// <param name="obj">其他参数</param>
        /// <returns></returns>
        private static string frome(string ve,params object[] obj)
        {
            string lauge = Thread.CurrentThread.CurrentCulture.Name.ToLower();
            string vc = frome(ve, lauge, obj);
            return vc;
        }

        /// <summary>
        /// 根据自己的语言翻译
        /// </summary>
        /// <param name="ve">文本</param>
        /// <param name="lauge">语言</param>
        /// <param name="obj">其他参数</param>
        /// <returns></returns>
        public static string frome(string ve, string lauge, params object[] obj)
        {
            if (lauge == "" || lauge == null)
                lauge = Thread.CurrentThread.CurrentCulture.Name.ToLower();
            return mk("", ve, lauge, obj);
        }
        /// <summary>
        /// 根据标记找到程序的翻译包
        /// </summary>
        /// <param name="pk">语言包</param>
        /// <param name="ve">文本</param>
        /// <param name="lauge">语言</param>
        /// <param name="obj">其他参数</param>
        /// <returns></returns>
        public static string fromepk(string pk, string ve, string lauge, params object[] obj)
        {
            if (lauge == "" || lauge == null)
                lauge = Thread.CurrentThread.CurrentCulture.Name.ToLower();

            return mk(pk, ve, lauge, obj);
        }
        private static string mk(string sf,string ve, string lauge, params object[] obj)
        {
            const string dirt = "lauge";
            string th = sf;
            string vc = ve;
            if (Directory.Exists(dirt))
            {
                G:
                if (File.Exists(dirt + "/" + th + "_" + lauge + ".lang"))
                {
                    MakeArggi ari = new MakeArggi();
                    ari.run(File.ReadAllLines(dirt + "/" + th + "_" + lauge + ".lang"), 0, '-', '=');
                    string st = ari.returnTi(ve);
                    if (st != null)
                        vc = st;
                }
                else
                {
                    lauge = "en-us";
                    if (File.Exists(dirt + "/" + th + "_" + lauge + ".lang"))
                        goto G;
                }
            }
            vc = string.Format(vc, obj);
            return vc;
        }
    }
}
