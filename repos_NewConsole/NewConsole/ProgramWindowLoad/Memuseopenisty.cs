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

namespace ProgramWindowLoad
{
    public partial class Memuseopenisty : Form
    {
        public SeeModsConsoleRun rt;
        public Memuseopenisty(SeeModsConsoleRun run)
        {
            InitializeComponent();
            this.rt = run;
        }

        private void 打开一个项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenIPLoct op = new OpenIPLoct(rt);
            op.ShowDialog();
        }

        private void menum2l1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewWindowListMainTo tr = new ViewWindowListMainTo(rt);
            tr.ShowDialog();
        }
    }
}
