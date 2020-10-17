using RunLCJVM;
using SmProPub.MakeRun;
using SmProPub.Text;
using SmProPub.Window.Forms.UsersControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmProCmd.Shell
{
    public class Shell : RunCommandTo
    {
        public Exception Exception(int ex)
        {
            Exception exr = new Exception("无法知道的错误!");
            
            switch (ex)
            {
                case 404:
                    exr = new Exception("程序无法启动，无法找到bash命令");
                    break;
            }
            return exr;
        }

        public int Execute(string arg, SeeModsConsoleRun r, ConsoleShowWindow cw, object obj)
        {
            cw.FortText = Color.Aqua;

            string[] args = String64.MakeArg(arg, ' ', '\'');
            bool hasopen = cw.ReadText;
            bool hastextout = cw.DisTextOutEvent;
            bool hasexit = false;
            cw.ReadText = true;
            cw.DisTextOutEvent = true;
            try
            {
                cw.ConsoleWriteLine("Copyright (C) SeeMods 2020");
                cw.ConsoleWriteLine("");
                cw.ConsoleWriteLine("强制终止代码协议请按Ctrl + Shift + C");
                cw.ConsoleWriteLine("正在初始化环境...");
                string cmd = "cmd.exe";
                string dir = Environment.CurrentDirectory;
                if (args.Length > 0)
                    cmd = args[0];
                if (args.Length > 1)
                {
                    for (int x = 1; x < args.Length; x++)
                    {
                        switch (args[x].ToLower())
                        {
                            case "-path":
                                cmd = args[x + 1];
                                break;
                        }
                    }
                }

                Process p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = cmd;
                p.StartInfo.WorkingDirectory = dir;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;

                p.StartInfo.UseShellExecute = false;
                p.Start();

                List<Thread> t = new List<Thread>();

                t.Add(new Thread(() => {
                    if (!r.args.Server)
                        while (true)
                        {
                            cw.FortText = Color.Aqua;
                            string str = cw.ConsoleReadLine();
                            cw.ConsoleKeyBack(str.Length);
                            p.StandardInput.WriteLine(str);
                            p.StandardInput.AutoFlush = true;
                        }
                    else
                        while (true)
                        {
                            cw.FortText = Color.Blue;
                            string str = cw.ConsoleReadLine();
                            for (int iu = 0; iu < str.Length; iu++)
                                Console.Write("\b");
                            p.StandardInput.WriteLine(str);
                            p.StandardInput.AutoFlush = true;
                        }
                }));
                p.BeginOutputReadLine();
                p.OutputDataReceived += (sender, e) => {
                    string textline = e.Data;
                    if (textline == null)
                        return;
                    cw.FortText = Color.Aqua;
                    textline = String64.FormatOverride(textline, "\n", "\r\n");
                    cw.ConsoleWriteLine(textline);
                };
                p.BeginErrorReadLine();
                p.ErrorDataReceived += (sender, e) => {
                    string textline = e.Data;
                    if (textline == null)
                        return;
                    cw.FortText = Color.Aqua;
                    textline = String64.FormatOverride(textline, "\n", "\r\n");
                    cw.ConsoleWriteLine(textline);
                };
                /*
                t.Add(new Thread(()=> {
                    while (true)
                    {
                        string textline = p.StandardOutput.ReadLine();
                        cw.FortText = Color.Aqua;
                        textline = String64.FormatOverride(textline,"\n","\r\n");
                        cw.ConsoleWriteLine(textline);
                    }
                }));
                */

                cw.ShowText.KeyDown += (object senderp, KeyEventArgs k) => {
                    if (k.Control && k.Shift && k.KeyCode == Keys.C)
                    {
                        foreach (Thread ddrt in t.ToArray())
                        {
                            ddrt.Interrupt();
                            ddrt.Abort();
                        }
                        p.Kill();
                        hasexit = true;
                    }
                };

                foreach (Thread ddrt in t.ToArray())
                {
                    ddrt.Start();
                }

                p.WaitForExit();

                if (!hasexit)
                    foreach (Thread ddrt in t.ToArray())
                    {
                        ddrt.Interrupt();
                        ddrt.Abort();
                    }
                cw.ConsoleWriteLine("注销操控");
            }
            catch (Exception ex)
            {
                cw.ConsoleWriteLine("Fail Return! " + ex.Message);
                return 0;
            }

            cw.ReadText = hasopen;
            cw.DisTextOutEvent = hastextout;

            return 0;
        }

        public string[] HelpCommand(string arg)
        {
            List<string> s = new List<string>();
            s.Add("Shell用法");
            s.Add(" Shell [<bash path> [-option]]");
            s.Add("");
            s.Add("Option:");
            s.Add("-path [path] 将以这个目录执行");
            s.Add("");
            s.Add("注意:取消分隔符为''");
            return s.ToArray();
        }

        public string RunCommand()
        {
            return "shell";
        }
    }
}
