using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmProPub
{
    /// <summary>
    /// 这是一个限于SmProPub中的错误解释
    /// </summary>
    public class SmException : Exception
    {
        private string mrp { get; set; }
        /// <summary>
        /// 解决方法
        /// </summary>
        public string Debug { get; set; }
        /// <summary>
        /// 错误ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 解决的代码行
        /// </summary>
        public string CodeLine { get; set; }
        /// <summary>
        /// 说明信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 为什么失败
        /// </summary>
        public string FailWhy { get; set; }
        /// <summary>
        /// 新建SmPro的错误解决
        /// </summary>
        public SmException()
        {
            Clear();
        }
        /// <summary>
        /// 新建SmPro融合解释外部解释
        /// </summary>
        /// <param name="ex">合并的项目</param>
        public SmException(Exception ex)
        {
            Clear();
            Debug = HelpLink = ex.HelpLink;
            ID = HResult = ex.HResult;
            message = ex.Message;
            FailWhy = CodeLine = Source = ex.Source;
        }
        /// <summary>
        /// 新建SmPro融合解释外部解释
        /// </summary>
        /// <param name="ex">合并的项目</param>
        public SmException(SmException ex)
        {
            Clear();
            HelpLink = ex.HelpLink;
            HResult = ex.HResult;
            message = ex.Message;
            Source = ex.Source;
            Debug = ex.Debug;
            ID = ex.ID;
            CodeLine = ex.CodeLine;
            message = ex.message;
            FailWhy = ex.FailWhy;
        }
        /// <summary>
        /// 获取返回的错误信息
        /// </summary>
        public override string Message { get { return message; } }
        /// <summary>
        /// 获取全部的帮助信息
        /// </summary>
        public string HelpMessage { get { return mrp; } }

        /// <summary>
        /// 直接使用错误表达
        /// </summary>
        /// <param name="message">信息</param>
        public SmException(string message)
        {
            Clear();
            Exception po = new Exception("\n信息：" + message + "\n\n可执行的解决方案：" + Debug + "\n\n错误ID：" + ID + "\n\n错误行：" + CodeLine + "\n\n失败原因：" + FailWhy);
            this.message = message;
            mrp = po.Message;
        }
        /// <summary>
        /// 标准的解释
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="Debug">解决方法</param>
        /// <param name="ID">错误ID</param>
        /// <param name="CodeLine">解决行</param>
        /// <param name="FailWhy">为什么</param>
        public SmException(string message,string Debug,int ID,string CodeLine,string FailWhy)
        {
            Clear();
            Exception po = new Exception("\n信息：" + message + "\n\n可执行的解决方案：" + Debug + "\n\n错误ID：" + ID + "\n\n错误行：" + CodeLine + "\n\n失败原因：" + FailWhy);
            this.Debug = Debug;
            this.ID = ID;
            this.CodeLine = CodeLine;
            this.FailWhy = FailWhy;
            this.message = message;
            mrp = po.Message;
        }
        /// <summary>
        /// 重置表达
        /// </summary>
        public void Clear()
        {
        mrp = "未知的定义";
        Debug = "无解决方案";
        ID = new Random().Next();
        CodeLine = "0xc0000";
        message = "无说明";
        FailWhy = "";
        }
        /// <summary>
        /// 制作错误，返回执行类(可以直接用throw)
        /// </summary>
        public Exception RunSmProEx()
        {
            //Exception po = new Exception("\n信息：" + message + "\n\n可执行的解决方案：" + Debug + "\n\n错误ID：" + ID + "\n\n错误行：" + CodeLine + "\n\n失败原因：" + FailWhy);
            //mrp = po.Message;
            return new Exception(mrp);
        }
        /// <summary>
        /// 篡改HResult输出
        /// </summary>
        /// <param name="hresult">新的HResult更改</param>
        [Obsolete("警告!强行篡改HResult会导致计算错误指针混乱")]
        public void ChangeHResult(int hresult)
        {
            HResult = hresult;
        }
    }
}
