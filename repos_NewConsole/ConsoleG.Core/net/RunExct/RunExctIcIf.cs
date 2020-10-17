using Microsoft.CSharp;
using SmProPub;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleG.Core.net.RunExct
{
    /// <summary>
    /// SeeMods 插件执行
    /// </summary>
    public class RunLoct
    {
        public List<object[]> save = new List<object[]>();
        public string name { get; set; }
        public string SubLoct { get; set; }
        public string LoadForm { get; set; }
        public Assembly bsy { get; set; }
        public void MSget(string path)
        {
            bsy = Assembly.LoadFrom(path);
        }
        public object[] Locat(object[] sender, string arg, string runnameclass, string runnameworktext)
        {
            try
            {
                Assembly myAssembly = bsy;
                object oc = myAssembly.CreateInstance(runnameclass);
                MethodInfo mk = oc.GetType().GetMethod(runnameworktext);
                bsy = myAssembly;
                return (object[])mk.Invoke(oc, new object[] { sender, arg });
            }
            catch (Exception ex)
            {
                return new object[] { ex };
            }
        }
        public object[] Locat(string path, object[] sender, string arg,string runnameclass,string runnameworktext)
        {
            try
            {
                Assembly myAssembly = Assembly.LoadFrom(path);
                object oc = myAssembly.CreateInstance(runnameclass);
                MethodInfo mk = oc.GetType().GetMethod(runnameworktext);
                bsy = myAssembly;
                return (object[])mk.Invoke(oc, new object[] { sender, arg });
            }
            catch (Exception ex)
            {
                return new object[] { ex };
            }
        }
        public object[] Locat(string path, object[] sender,string arg)
        {
            try
            {
                Assembly myAssembly = Assembly.LoadFrom(path);
                object oc = myAssembly.CreateInstance("Main.PCI");
                MethodInfo mk = oc.GetType().GetMethod("Main");
                bsy = myAssembly;
                return (object[])mk.Invoke(oc, new object[] { sender, arg });
            }
            catch (Exception ex)
            {
                return new object[] { ex };
            }
        }
    }
    class RunExctIcIf
    {
        public List<object> save = new List<object>();
        public CSharpCodeProvider cs;
        public ICodeCompiler ic;
        public CompilerParameters cp;
        string mkrun;
        public CompilerResults ru;
        public List<string> str = new List<string>();
        public RunExctIcIf()
        {
            returnDllTc();
            cs = new CSharpCodeProvider();
            ic = cs.CreateCompiler();
            cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            

        }

        public void usingTm(string file)
        {
            mkrun = "using System;\n" +
                "using System.Runtime.InteropServices;\n" +
                "namespace RC {\n" +
                "public class RSD {\n" +
                "[DllImport(@\"" + file + "\")]\n" +
                "public extern static object[] Main(object[] sender, string arg);\n" +
                "" +
                "public object[] MainL(object[] arg,string text) {\n" +
                "return Main(arg,text);\n" +
                "}}}";
        }

        public void StAve()
        {
            foreach (string jk in str.ToArray())
                cp.ReferencedAssemblies.Add(jk);
            str.Clear();
        }

        public void MKISTR()
        {
            ru = ic.CompileAssemblyFromSource(cp, mkrun);
            if (ru.Errors.HasErrors)
            {
                SmException i = new SmException();
                i.Debug = "重新创建一个";
                string ui = "";
                int io = ru.Errors.Count;
                for (int gi = 0; gi < io; gi++)
                {
                    CompilerError p = ru.Errors[gi];
                    i.FailWhy = p.ToString();
                    i.CodeLine += p.Line;
                }
                i.CodeLine += "0xc03,7xc56";
                i.message = "在执行程序汇编时发生错误";
                throw i.RunSmProEx();
            }
        }

        public object[] runmk(object[] sender,string tect)
        {
            Assembly g = ru.CompiledAssembly;
            object oc = g.CreateInstance("RC.RSD");
            MethodInfo mk = oc.GetType().GetMethod("MainL");
            return (object[])mk.Invoke(oc, new object[] { sender, tect });
        }

        public void returnDllTc()
        {
            str.Add("System.dll");
            str.Add("System.Core.dll");
        }
        public override string ToString()
        {
            return "LD";
        }
    }
}
