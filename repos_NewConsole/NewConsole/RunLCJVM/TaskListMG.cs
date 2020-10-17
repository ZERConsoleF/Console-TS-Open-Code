using System;
using System.Collections.Generic;
using System.SmProPub.ExClass;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RunLCJVM
{
    [StructLayout(LayoutKind.Sequential)]
    public class TaskListMG
    {
        public static TaskListMG GetTaskListMG;
        public static TaskListMG GetTask()
        {
            if (GetTaskListMG == null)
                GetTaskListMG = new TaskListMG();
            /*
            TaskListMG li = null;
            if (Class<TaskListMG>.Java.IfFinl("System.IO.ExCeption.Creative"))
            {
                li = Class<TaskListMG>.Java.Finl(null, "System.IO.ExCeption.Creative");
            }
            else
            {
                li = Class<TaskListMG>.Java.Finl(new TaskListMG(), "System.IO.ExCeption.Creative");
            }    
            */
            return GetTaskListMG;
        }
        public TaskListMG()
        {
            ouc = new object[0];
        }
        private object[] ouc { get; set; }

        /// <summary>
        /// 自动添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="copet"></param>
        /// <param name="ocv"></param>
        public static void AutoAdd(string name, string copet, object ocv)
        {
            TaskListMG u = TaskListMG.GetTask();
            u.Add(name, copet, ocv);
            u.CopyMemory();
        }

        public void Add(string name,string copet,object ocv)
        {
            List<object> oc = new List<object>();
            if (ouc != null)
                foreach (object ob in ouc)
                    oc.Add(ob);
            oc.Add(new object[] { name, copet, ocv });
            ouc = oc.ToArray();
        }
        public void Clear()
        {
            ouc = new object[0];
        }
        public object[] ToArray()
        {
            return ouc;
        }
        public void CopyMemory()
        {
            //Class<TaskListMG>.Java.Finl(this, "System.IO.ExCeption.Creative");
        }
    }
}
