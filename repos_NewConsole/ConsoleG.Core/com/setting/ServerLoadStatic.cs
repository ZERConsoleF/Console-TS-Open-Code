using ConsoleG.Core.com.LoadProgram;
using Newtonsoft.Json;
using SmProPub;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleG.Core.com.setting
{
    public class GetServerArg
    {
        #region 注册开始
        public int max { get; set; }
        public string CreatTitle { get; set; }
        #endregion
        #region 注册程序窗口
        /*
        public int heigh { get; set; }
        public int weiht { get; set; }
        public bool MaxWindow { get; set; }
        public int iw { get; set; }
        public int ih { get; set; }
        */
        #endregion
        #region 注册组件
        public string sextr { get; set; }
        public List<string> cp { get; set; }
        public List<string> systemcp { get; set; }
        public int sleeption { get; set; }
        public bool showextrinfo { get; set; }
        #endregion
        #region 注册语言
        public string laugeAB { get; set; }
        #endregion
        #region 注册在执行时插件的参数引导
        public string[] exrarg { get; set; }
        #endregion
    }
    public class ServerLoadStatic
    {
        private static int minsiz = 256;

        public GetServerArg argf;
        public ServerLoadStatic(string[] gm, ref UtilPrintf p)
        {
            MakeArggi agr = new MakeArggi();
            agr.run(gm, 0, '-', ':');
            string struy = "serversetwork.ini";
            if (agr.returnTi("workini") != null)
                struy = agr.returnTi("workini");
            if (!File.Exists(struy))
            {
                Console.WriteLine(FanYi.frome("console.write.nowork", null));
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
            GetServerArg arg = JsonConvert.DeserializeObject<GetServerArg>(File.ReadAllText(struy));
            CreativleMemorySetting set = new CreativleMemorySetting();
            set.Class = SmProConst.GetMainMemoryName;

            if (agr.returnTi("max") != null)
            {
                arg.max = Convert.ToInt32(agr.returnTi("max"));
            }

            set.size = arg.max;

            if (set.size < minsiz)
            {
                UtilPrintf.Printf(UtilControl.Error, ref p, FanYi.frome("console.wrilt.monory", null) + " " + minsiz + " MB");
                Console.WriteLine("Pause...");
                Console.ReadLine();
                Environment.Exit(0);
            }

            set.PD = false;

            //CreativeMemoryty.CreativeMemory(ref p, set);

            //CreativeMemoryty ty = new CreativeMemoryty(SmProConst.GetMainMemoryName);
            //ty.Creativestr();

            UtilPrintf.Printf(UtilControl.Info, ref p, "[Memory] " + FanYi.frome("console.memory", null));
            UtilPrintf.Printf(UtilControl.Warn, ref p, "[Menory] About creat memory\nname {0}\nBytes(MB) {1}", set.Class, arg.max);
            Console.WriteLine("Load...");

            UtilPrintf.Printf(UtilControl.Info, ref p, "[Memory] " + FanYi.frome("console.makearg.usage", null));

            #region 注册标签
            arg.CreatTitle = agr.returnTi("creativetitle", arg.CreatTitle);
            //arg.MaxWindow = Convert.ToBoolean(agr.returnTi("maxwindow", arg.MaxWindow.ToString()));
            arg.sextr = agr.returnTi("extr", arg.sextr);
            //arg.weiht = Convert.ToInt32(agr.returnTi("w", arg.weiht.ToString()));
            //arg.heigh = Convert.ToInt32(agr.returnTi("h", arg.heigh.ToString()));
            arg.laugeAB = agr.returnTi("lauge", arg.laugeAB);
            //arg.ih = Convert.ToInt32(agr.returnTi("ih","0"));
            //arg.iw = Convert.ToInt32(agr.returnTi("iw", "0"));
            //arg.Server = Convert.ToBoolean(agr.returnTi("server", arg.Server.ToString()));
            arg.showextrinfo = Convert.ToBoolean(agr.returnTi("showextrinfo", true.ToString()));

            string systemcp = agr.returnTi("systemcp");
            string[] systemcps;
            if (systemcp == null)
                systemcps = new string[0];
            else
                systemcps = systemcp.Split(';');

            foreach (string su in systemcps)
                arg.systemcp.Add(su);


            string cp = agr.returnTi("systemcp");
            string[] cps;
            if (cp == null)
                cps = new string[0];
            else
                cps = systemcp.Split(';');

            foreach (string su in cps)
                arg.systemcp.Add(su);

            #endregion
            #region 注册插件的执行标签
            List<string> iop = new List<string>();
            for (int i = 0; i < gm.Length; i++)
            {
                string argp = gm[i];
                if (argp.ToLower() == "-exrtarg")
                {
                    for (int ii = i + 1; ii < gm.Length; ii++)
                    {
                        argp = gm[ii];
                        if (argp.ToLower() == "-endreg")
                        {
                            break;
                        }

                        iop.Add(argp);
                    }
                }
            }
            arg.exrarg = iop.ToArray();
            #endregion
            UtilPrintf.Printf(UtilControl.Info, ref p, "[LC] " + FanYi.frome("console.makes.success", null));

            string iu = JsonConvert.SerializeObject(arg);
            //ty.setValue(Encoding.Unicode.GetBytes("-" + SmProConst.GetMainArgName + ":" + iu + "\n-UI:7\n"));

            //ty.RunMake();
            //ty.Creativestr();

            argf = arg;

            //Console.WriteLine(Encoding.Unicode.GetString(ty.returnAll()));

            //ty.Close();
        }
    }
}
