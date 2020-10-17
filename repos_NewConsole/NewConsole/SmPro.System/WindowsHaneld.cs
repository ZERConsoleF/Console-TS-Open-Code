using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCatLc
{
    public class WindowsHaneld
    {
        public WindowsHaneld()
        {
            SubWindowsHaneldPackage = new List<SubWindowsHaneldPackage>();
            SunItemWindowsPackages = new List<SunItemWindowsPackage>();
            SunWindows = new List<SunWindows>();
        }
        public string TitleAt { get; set; }
        public Point Point { get; set; }
        public Size Size { get; set; }
        public bool FileScreen { get; set; }
        public bool StartThis { get; set; }
        public int AsiPosInt { get; set; }
        public List<SubWindowsHaneldPackage> SubWindowsHaneldPackage { get; set; }
        public List<SunItemWindowsPackage> SunItemWindowsPackages { get; set; }
        public List<SunWindows> SunWindows { get; set; }
    }
    public class SunWindows
    {
        public string Name { get; set; }
        public string HasPackName { get; set; }
        public string Arg { get; set; }
        public Point Point { get; set; }
        public Size Size { get; set; }
        public bool StartThis { get; set; }
    }
    public class SunItemWindowsPackage
    {
        public string PackName { get; set; }
        public string Arg { get; set; }
        public bool IsShow { get; set; }
        public int HasAdd { get; set; }
    }
    public class SubWindowsHaneldPackage
    {
        public SubWindowsHaneldPackage()
        {
            Names = new List<string>();
            DockStyle = DockStyle.None;
            TitleSet = 24;
            UnderDockStyle = DockStyle.Top;
        }
        public Color BackGround { get; set; }
        public int TitleSet { get; set; }
        public DockStyle UnderDockStyle { get; set; }
        public DockStyle DockStyle { get; set; }
        public List<string> Names { get; set; }
        public string PackName { get; set; }
        public bool StartThis { get; set; }
        public Point Point { get; set; }
        public Size Size { get; set; }
    }
}
