using Newtonsoft.Json;
using SmProPub.LogSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCatLc
{
    public class SettingWindow : SettingInfo
    {
        public string SubPackage => "window.locat.info";

        public string FileName => "WindowsInfol.ini";
        public WindowsHaneld windowsHaneld { get; set; }

        public void Read(byte[] butter, SettingPackage sp)
        {
            windowsHaneld = JsonConvert.DeserializeObject<WindowsHaneld>(Encoding.Default.GetString(butter));
        }

        public byte[] Write(SettingPackage sp, params object[] obj)
        {
            return Encoding.Default.GetBytes(JsonConvert.SerializeObject(windowsHaneld));
        }
    }
    public class SettingWindowUnder : SettingInfo
    {
        public string SubPackage => "window.locat.info";

        public string FileName => "WindowsInfounder.ini";
        public WindowsHaneld windowsHaneld { get; set; }

        public void Read(byte[] butter, SettingPackage sp)
        {
            windowsHaneld = JsonConvert.DeserializeObject<WindowsHaneld>(Encoding.Default.GetString(butter));
        }

        public byte[] Write(SettingPackage sp, params object[] obj)
        {
            return Encoding.Default.GetBytes(JsonConvert.SerializeObject(windowsHaneld));
        }
    }
}
