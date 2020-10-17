using RunLCJVM;
using SmPro.System;
using SmProPub;
using SmProPub.MakeRun;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.SmProPub.ExClass;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmCmd.WindowCreative
{
    public class CreativeGetWindow : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            return new Exception("发生了未知错误");
        }

        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            cw.FortText = Color.Yellow;
            string hg = arg.Trim().ToLower();
            string[] args = arg.Split(' ');
            if (args.Length == 0)
                return 0;
            if (args[0] == "-help")
            {
                cw.ConsoleWriteLine("请使用[help {0}]来表示", RunCommand());
                return 0;
            }
            if (args[0] == "-show-savewindow")
            {
                cw.ConsoleWriteLine("Name|IDX|Handle");
                foreach (FormMenu m in FormMenu.GetIndexl)
                {
                    cw.ConsoleWriteLine(m.PackName + " | " + m.IDX + " | " + (m.CheckForm == null ? "null" : m.CheckForm.Handle.ToString()));
                }
            }
            if (args[0] == "-run-creative")
            {
                if (args.Length < 1)
                {
                    cw.ConsoleWriteLine("无法使用，请用help查看(至少需要2个option)");
                    return 0;
                }
                foreach (FormMenu m in FormMenu.GetIndexl)
                {
                    if (m.IDX.ToString() == args[1])
                    {
                        new Thread(() => { m.ObjectClassArgL(); }).Start();
                    }
                }
            }
            //Console.WriteLine(args[0]);
            if (args[0] == "-new-creative")
            {
                if (args.Length < 1)
                {
                    cw.ConsoleWriteLine("无法使用，请用help查看(至少需要2个option)");
                    return 0;
                }
                string name = args[1];
                NCKOLCTE t = new NCKOLCTE();
                t.Name = name + ".spwindow";
                t.Text = name;
                t.TitleName.Text = name;
                ObjectClass<Form> c = new ObjectClass<Form>();
                c.SaveInMemory(t);
                new Thread(() => {
                    t.TopLevel = false;
                    r.mi.AddControlInvoke(t);
                    t.Location = new Point(0, r.mi.TitlePan.Height);
                }).Start();
                /*
                FormMenu m = new FormMenu();
                m.PackName = name;
                m.CheckForm = t;
                m.ObjectClassArgL = new System.SmProPub.ExClass.ObjectClass<FormMenu>.ObjectClassArg(() => {
                    
                });
                m.ObjectClassArgL();
                */
                if (cw.ConsoleS)
                    UtilPrintf.Printf(UtilControl.Info, ref r.p, "[Creative Windows] 已提交给后台处理");
                else
                    cw.ConsoleWriteLine("[Creative Windows] 已提交给后台处理");
            }
            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            List<string> f = new List<string>();
            f.Add("创建标题Form文件");
            f.Add("");
            f.Add("创建标题文档，执行此命令");
            f.Add("用法:" + RunCommand() + "[option] [<窗体名称|窗体创建的IDX>]");
            f.Add("");
            f.Add("Option:'-'");
            f.Add("[-show-savewindow] 显示注册的窗体");
            f.Add("[-run-creative] 创建窗体，使用自声明的Invoke方法(请使用IDX)");
            f.Add("[-new-creative] 创建新的窗体(请使用名称)");
            return f.ToArray();
;        }

        public string RunCommand()
        {
            return "CreativeWindow";
        }


    }
}
