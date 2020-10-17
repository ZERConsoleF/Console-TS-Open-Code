using ConsoleG.Core.com;
using ConsoleG.Core.com.LoadProgram;
using ConsoleG.Core.com.setting;
using Newtonsoft.Json;
using SmProPub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLCJVM
{
    public class Rs
    {
        public void wreArgToMemory(object ag, string ariu, string argi)
        {
            CreativeMemoryty ty = new CreativeMemoryty(argi);
            ty.Creativestr();
            MakeArggi argt = new MakeArggi();
            string[] gi = Encoding.Unicode.GetString(ty.returnValeByte()).Split('\n');
            argt.run(gi, 0, '-', ':');
            int sr = argt.returnTiInt(ariu);
            gi[sr] = "-" + SmProConst.GetMainArgName + ":" + JsonConvert.SerializeObject(ag);
            string gu = "";
            foreach (string jp in gi)
            {
                gu += jp + "\n";
            }
            ty.setValue(Encoding.Unicode.GetBytes(gu));
            ty.RunMake();
            //UtilPrintf.Printf(UtilControl.Warn, ref p, "[WriteLineMemory] Success Write Li");
            ty.Creativestr();
            //Console.WriteLine(Encoding.Unicode.GetString(ty.returnValeByte()));

            ty.Close();
        }
    }
}
