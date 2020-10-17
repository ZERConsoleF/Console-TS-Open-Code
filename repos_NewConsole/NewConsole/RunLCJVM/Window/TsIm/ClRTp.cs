using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunLCJVM.Window.TsIm
{
    public class LoadMenust 
    { 
        public List<MenuCreat> cti { get; set; }
    }
    public class MenuCreat
    {
        public string text { get; set; }
        public string name { get; set; }
        public string runexe { get; set; }
        public string sendmessage { get; set; }
        public string imagefile { get; set; }
        public List<MenuCreat> menuCreats { get; set; }
        public bool underspite { get; set; }
    }
    class ClRTp
    {
    }
}
