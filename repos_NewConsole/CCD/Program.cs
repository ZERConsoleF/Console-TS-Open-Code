using ConsoleG.CnsCop;
using ConsoleG.Network;
using ConsoleG.Network.Server;
using SmProPub.Endorce;
using SmProPub.IO.Drive;
using SmProPub.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.SmProPub.Event;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine((int)byte.Parse("FF",System.Globalization.NumberStyles.Number));
            //Console.ReadLine();
            //Application.Run(new Form1());
            /*
            Encoed r = new Encoed();
            r.ControlByte += new ObjectEventArg((object sender, ObjectEvent e) => {
                EventLockEncoder er = (EventLockEncoder)e;
                string ni = string.Format("总字节:{0}Bytes,操控字节:{1}Bytes,剩余时间:{2},百分比:{3}%,读写测评:{4}/S ", StringSearch.FormatIB(er.ByteAllLock, "0.00"), StringSearch.FormatIB(er.ByteLoadedLock, "0.00"), er.LastTime.Hour + ":" + er.LastTime.Minute + ":" + er.LastTime.Second + "." + er.LastTime.Millisecond, er.ByteAcces.ToString("0.00"), StringSearch.FormatIB(er.TimeOppendByte, "0.00"));
                Console.Write(ni);
                foreach (char i in ni)
                {
                    Console.Write("\b\b");
                }
            });
            byte[] j = r.BytesLock(File.ReadAllBytes(@"E:\Desktop\1.txt"), new int[] { 6,7 }, new int[] { 8,10 });
            File.WriteAllBytes(@"E:\Desktop\2.txt", j);
            File.WriteAllBytes(@"E:\Desktop\3.txt", r.DeBytesLock(j, new int[] { 6, 7 }, new int[] { 8, 10 }));
            Console.ReadLine();
            */
            FileEncoed e = new FileEncoed();
            e.FileControlEvent += (sender, es) => {
                EventFileLockEncoed er = (EventFileLockEncoed)es;
                if (er.FileStatus == EventFileStatus.Find)
                {
                    string nie = string.Format("正在寻找:{0}/{1}", StringSearch.FormatIB(er.ByteLoadedLock, "0.00"), StringSearch.FormatIB(er.ByteAllLock, "0.00"));
                    Console.Write(nie);
                    foreach (char i in nie)
                    {
                        Console.Write("\b\b");
                    }
                    return;
                }
                string ni = string.Format("总字节:{0}Bytes,操控字节:{1}Bytes,剩余时间:{2},百分比:{3}%,读写测评:{4}/S ", StringSearch.FormatIB(er.ByteAllLock, "0.00"), StringSearch.FormatIB(er.ByteLoadedLock, "0.00"), er.LastTime.Hour + ":" + er.LastTime.Minute + ":" + er.LastTime.Second, er.ByteAcces.ToString("0.00"), StringSearch.FormatIB(er.TimeOppendByte, "0.00"));
                Console.Write(ni);
                foreach (char i in ni)
                {
                    Console.Write("\b\b");
                }
            };
            e.ThisPath = @"E:\迅雷下载\smzy_Bandicamtyzcj.rar";
            e.AcceptPath = @"E:\Desktop\2.txt";
            e.IDX = new int[] { 6, 7 };
            e.IDX2 = new int[] { 8, 10 };
            e.StartLock();
            Console.Read();
            Console.WriteLine();
            e.ThisPath = @"E:\Desktop\2.txt";
            e.AcceptPath = @"E:\Desktop\3.txt";
            e.StartUnLock();
            return;
            /*
Encoed r = new Encoed();
r.ControlByte += new ObjectEventArg((object sender, ObjectEvent e) => {
    EventLockEncoder er = (EventLockEncoder)e;
    string ni = string.Format("总字节:{0}Bytes,操控字节:{1}Bytes,剩余时间:{2},百分比:{3}%,读写测评:{4}Bytes/S      ", er.ByteAllLock, er.ByteLoadedLock, er.LastTime.Hour + ":" + er.LastTime.Minute + ":" + er.LastTime.Second + "." + er.LastTime.Millisecond, er.ByteAcces.ToString("0.00"),er.TimeOppendByte);
    Console.Write(ni);
    foreach (char i in ni)
    {
        Console.Write("\b\b");
    }
});
r.ThreadSleep = 0;
r.OpenThread = true;
byte[] j = r.BytesLock(File.ReadAllBytes(@"D:/mono.msi"), new int[] { 13, 15, 17, 13, 1, 4, 4 }, new int[] { 13, 12, 17, 19, 8, 3, 8 });
File.WriteAllBytes("D:/FG.txt", j);
File.WriteAllBytes("D:/u.txt", r.DeBytesLock(File.ReadAllBytes("D:/FG.txt"), new int[] { 13, 15, 17, 13, 1, 4, 4 }, new int[] { 13, 12, 17, 19, 8, 3, 8 }));

Console.ReadLine();
Application.Run(new Form1());
return;
NewConsoleNetSr s = new NewConsoleNetSr();
s.ServerBindAbout.UserSave.Add(new ServerUserControl("28759","28759","okm200606"));
s.ServerBindAbout.ServerCAI = "007b4c5aff4d5a120";
s.ServerBindAbout.ServerName = "FFS";

ServerIns i = new ServerIns();
i.ServerName = "FFS";
i.CAIIndex = "007b4c5aff4d5a120";
string h = i.MakeOne();

InfeNewConsoleHup hj = new InfeNewConsoleHup();
hj.User = "28759";
hj.Passworld = "okm200606";
hj.IndexProgres = h;

s.IPBlind = new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"),1111);
s.Blind();
s.NewSender += T_ab;
s.SenderByte += S_SenderByte;

NewConsoleNetCY c = new NewConsoleNetCY();
c.IPBlind = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1111);
c.AddBlind = hj;
c.Connent();
c.LogUp();
c.AutuoRevice();

CnsCop p = new CnsCop(c);
p.SendClass = new UpFile();
/*
c.Sender(Encoding.Unicode.GetBytes("213"));
c.SenderByteCY += C_SenderByteCY;
c.AutuoRevice();
Thread.Sleep(2500);
s.Send(s.FindSocketList(0), Encoding.Unicode.GetBytes("456"));
/*
CreatVirDrive vc = new CreatVirDrive();
vc.BytesDriveMe = 1024;
vc.DriveInfo = "HD SBFSD";
vc.DrivePCPRInfo = SmProPub.IO.Drive.DriveType.Drive;
vc.DrivePrInfo = "B52017D10391";
byte[] vy = VirDrive.CreativeCTDR(vc);
File.WriteAllBytes("1.txt", vy);
VirDrive vp = new VirDrive(vy);
VirDrivePxInfo p = new VirDrivePxInfo(vp);
p.CreativeDrivePossd();
File.WriteAllBytes("1.txt",p.ReturnD().ReturnDrive());
*/
        }

        private static void C_SenderByteCY(object sender, ObjectEvent o)
        {
            ServerSenderOveEvent p = (ServerSenderOveEvent)o;
            byte[] oi = p.SenderOver;
            Console.WriteLine(Encoding.Unicode.GetString(oi));
        }

        private static void S_SenderByte(object sender, ObjectEvent o)
        {
            ServerSenderOveEvent p = (ServerSenderOveEvent)o;
            byte[] oi = p.SenderOver;
            Console.WriteLine(Encoding.Unicode.GetString(oi));
        }

        static void T_ab(object sender,ObjectEvent e)
        {
            Console.WriteLine(11);
        }
    }
    public class cft
    {
        public string POL { get; set; }
    }
}
