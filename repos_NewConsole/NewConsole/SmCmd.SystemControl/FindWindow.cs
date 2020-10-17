using RunLCJVM;
using SmProPub.MakeRun;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmCmd.SystemControl
{
    public class FindWindow : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            Exception pv = new Exception("未知的错误");
            switch (ex)
            {
                case -3:
                    pv = new Exception("这个错误通常是无法转化为int数");
                    break;
                case -4:
                    pv = new Exception("找不到句柄");
                    break;
                default:
                    break;
            }
            return pv;
        }

        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            cw.FortText = Color.Yellow;
            List<Form> f4 = new List<Form>();

            foreach (Control c8 in r.mi.Controls)
            {
                if (c8 is Form)
                {
                    f4.Add(c8 as Form);
                }
            }

            arg = arg.Trim();

            if (arg.Length == 0)
            {
                cw.FortText = Color.White;
                cw.ConsoleWriteLine("必须参数传递，可以用help " + RunCommand());
            }
            string[] args = arg.Split(' ');

            if (args[0].ToLower() == "find")
            {
                foreach (Form fp in f4.ToArray())
                {
                    string[] gf = new string[]
                    {
                        "<",
                        "Handle:" + fp.Handle,
                        "Class:" + fp.GetType().Name,
                        "NameSpace:" + fp.GetType().Namespace,
                        "GUID:" + fp.GetType().GUID,
                        ">"
                    };

                    foreach (string g7 in gf)
                    {
                        cw.FortText = Color.Yellow;
                        cw.ConsoleWriteLine(g7);
                    }
                }
                return 0;
            }
            if (args.Length >= 2)
            {
                long sp;
                Form fc = null;
                try
                {
                    sp = Convert.ToInt64(args[0]);
                }
                catch
                {
                    return -3;
                }
                foreach (Form fp in f4.ToArray())
                {
                    if (fp.Handle.ToInt64() == sp)
                    {
                        fc = fp;
                        break;
                    }
                }
                if (fc == null)
                {
                    cw.FortText = Color.Red;
                    cw.ConsoleWriteLine("查找不到句柄:" + args[0]);
                    return -4;
                }
                cw.FortText = Color.White;
                cw.ConsoleWriteLine("句柄绑定:" + args[0]);
                try
                {
                    switch (args[1].ToLower())
                    {
                        case "close":
                            fc.Close();
                            break;
                        case "min":
                            fc.WindowState = FormWindowState.Minimized;
                            break;
                        case "show":
                            fc.WindowState = FormWindowState.Maximized;
                            break;
                        case "loction":
                            if (args.Length >= 3)
                            {
                                string[] pr = args[2].Split(',');
                                int x = Convert.ToInt32(pr[0]);
                                int y = Convert.ToInt32(pr[1]);
                                fc.Location = new Point(x, y);
                            }
                            else
                            {
                                cw.FortText = Color.Yellow;
                                cw.ConsoleWriteLine("控制Loction:X:" + fc.Location.X + ",Y:" + fc.Location.Y);
                            }
                            break;
                        case "size":
                            if (args.Length >= 3)
                            {
                                string[] pr = args[2].Split(',');
                                int x = Convert.ToInt32(pr[0]);
                                int y = Convert.ToInt32(pr[1]);
                                fc.Size = new Size(x, y);
                            }
                            else
                            {
                                cw.FortText = Color.Yellow;
                                cw.ConsoleWriteLine("控制Size:W:" + fc.Size.Width + ",H:" + fc.Size.Height);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    cw.FortText = Color.Yellow;
                    cw.ConsoleWriteLine(ex.ToString());
                    return 1;
                }
                cw.FortText = Color.Red;
                cw.ConsoleWriteLine("脱离绑定:" + args[0]);
                return 0;
            }

            cw.FortText = Color.Yellow;
            cw.ConsoleWriteLine("无效，可以用help " + RunCommand());
            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            return new string[]
            {
                "中文",
                "查找窗体",
                "用法 " + RunCommand() + " <<窗口句柄>|Find> [操作:close|min|show|loction|size] [ETC]",
                "",
                "其中:ETC",
                "Size:w, h",
                "loction:x, y",
                "",
                "其中:Find 查找窗体在系统窗体中"
            };
        }

        public string RunCommand()
        {
            return "controlwindow";
        }
    }
}
