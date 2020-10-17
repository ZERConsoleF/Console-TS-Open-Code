using RunLCJVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using ConsoleG.Core.com;
using OpenCatLc;
using System.Threading;
using SmProPub.Window.Forms.UsersControl;
using System.SmProPub.ExClass;
using SmPro.System;

namespace ProgramWindowLoad
{
    public partial class OpenIPLoct : Form
    {
        private readonly string st = SmProConst.GetPathTempSave + "OpenLoad.json";
        public SeeModsConsoleRun run;
        SaveObject sc = new SaveObject();
        public OpenIPLoct(SeeModsConsoleRun run)
        {
            InitializeComponent();
            this.run = run;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pwdn.PasswordChar = new char();
            else
                pwdn.PasswordChar = '*';
        }

        private void Cont_Click(object sender, EventArgs e)
        {
            /*DialogResult rt = MessageBox.Show("请确保连接的信息正确","SeeMods Ts Connent",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (rt == DialogResult.Cancel)
            {
                CommentSy.Text = "返回操控";
                return;
            }
            */
            CommentSy.Text = "正在制作Json保存";
            run.mi.CommentShow.Text = "正在连接";
            #region
            bool by = false;
            if (IpAddure.Text.Length == 0)
            {
                CommentSy.Text = "请指定IP";
                by = true;
            }
            if (IpCont.Text.Length == 0)
            {
                CommentSy.Text = "请指定端口";
                by = true;
            }
            if (usern.Text.Length == 0)
            {
                CommentSy.Text = "请指定用户";
                by = true;
            }
            if (openFileDialog1.FileName == "")
            {
                CommentSy.Text = "请指定证书";
                by = true;
            }
            /*
            if (ConnKey.Text.Length == 0)
            {
                CommentSy.Text = "请指定证书秘钥";
                by = true;
            }
            */
            if (ConnentAtIndex.Text.Length == 0)
            {
                CommentSy.Text = "指纹虽然不重要但是有些插件会识别";
                by = true;
            }
            if (by)
            {
                run.mi.CommentShow.Text = "请检查空缺";
                return;
            }
            #endregion
            try
            {
                sc.url = IpAddure.Text;
                sc.con = Convert.ToInt32(IpCont.Text);
                sc.user = usern.Text;
                sc.pwd = pwdn.Text;
                sc.KeyFile = openFileDialog1.FileName;
                sc.Key = ConnentAtIndex.Text;

                string sy = JsonConvert.SerializeObject(sc);
                if (!Directory.Exists(SmProConst.GetPathTempSave))
                    Directory.CreateDirectory(SmProConst.GetPathTempSave);
                if (!File.Exists(st))
                    File.Create(st).Dispose();
                File.WriteAllText(st, sy);
                run.mi.CommentShow.Text = "活动成功,执行指令";
                //run.
                SmProPub.Window.Forms.UsersControl.ConsoleShowWindow i = null;
                //i.ConsoleS = true;
                new Thread(() => {
                    J:
                    if (ObjectClass<ConsoleShowWindow>.GetIndexl != null)
                        foreach (ConsoleShowWindow w in ObjectClass<ConsoleShowWindow>.GetIndexl)
                        {
                            if (w.Name == "y7staticr")
                            {
                                i = w;
                                break;
                            }
                        }
                    if (i == null)
                    {
                        foreach (FormMenu f in FormMenu.GetIndexl)
                        {
                            if (f.PackName == "Console static")
                            {
                                f.ObjectClassArgL();
                                goto J;
                            }
                        }
                    }
                    RunCommandSerd.RunCommand(i, string.Format("connent {0}:{1} {2} {3} \"{4}\" {5}", sc.url, sc.con, sc.user, sc.pwd, sc.KeyFile, sc.Key), false);
                    Close();
                }).Start();
                Hide();
            }
            catch (Exception ex)
            {
                run.mi.CommentShow.Text = "Throw Exception:" + ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s7 = Environment.CurrentDirectory;
            openFileDialog1.AutoUpgradeEnabled = false;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                openFileDialog1.FileName = "";
                CommentSy.Text = "无选择";
                return;
            }
            CommentSy.Text = "选择了 " + openFileDialog1.FileName;
            textBox1.Text = openFileDialog1.FileName;
            Environment.CurrentDirectory = s7;
        }

        private void OpenIPLoct_Load(object sender, EventArgs e)
        {
            if (File.Exists(st))
            {
                sc = JsonConvert.DeserializeObject<SaveObject>(File.ReadAllText(st));
                IpAddure.Text = sc.url;
                IpCont.Text = sc.con.ToString();
                usern.Text = sc.user;
                pwdn.Text = sc.pwd.ToString();
                openFileDialog1.FileName = sc.KeyFile;
                textBox1.Text = sc.KeyFile;
                ConnentAtIndex.Text = sc.Key;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                CommentSy.Text = "非法路径!";
                openFileDialog1.FileName = "";
                return;
            }
            openFileDialog1.FileName = textBox1.Text;
        }
    }

    public class SaveObject
    {
        public string url { get; set; }
        public int con { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public string KeyFile { get; set; }
        public string Key { get; set; }
    }
}
