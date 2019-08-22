using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

namespace MyChat
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                login.Close();
                ChatWindow MainWindow = new ChatWindow(); 
                Application.Run(MainWindow);
                //Logout();//关闭程序时下线
                System.Environment.Exit(0); //后台关闭多线程
            }
        }
        static void Logout()//下线功能，现已移植到ChatWindow中
        {
            InfoWindow Confirm = new InfoWindow("确认退出当前账号？", true);
            Confirm.StartPosition = FormStartPosition.CenterParent;
            Confirm.ShowDialog();
            if (Confirm.DialogResult == DialogResult.OK)
            {
                Confirm.Close();
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect(BasicInfo.ServerIp, BasicInfo.ServerPort);
                }
                catch
                {
                    InfoWindow Mes = new InfoWindow("服务器无响应\n您已强制退出程序", false);
                    Mes.StartPosition = FormStartPosition.CenterParent;
                    Mes.Show();
                }
                if (client.Connected)
                {
                    NetworkStream ClientToServer = client.GetStream();
                    string LoginInfo = "logout" + BasicInfo.UserName;//下线格式："logout"+学号
                    byte[] send = Encoding.Default.GetBytes(LoginInfo);//将输入信息转化为byte字节流
                    ClientToServer.Write(send, 0, send.Length);//从networkstream中写入字节流
                    //接收
                    byte[] msg = new byte[1024];
                    int length = ClientToServer.Read(msg, 0, msg.Length);
                    string response = Encoding.Default.GetString(msg, 0, length);
                    Console.WriteLine(response);
                    if (response == "loo")
                    {
                        ClientToServer.Close();
                        client.Close();
                        InfoWindow Mes = new InfoWindow("您已强制退出程序\n  下线成功！", false);
                        Mes.StartPosition = FormStartPosition.CenterParent;
                        Mes.ShowDialog();
                        if (Mes.DialogResult == DialogResult.Cancel)
                        { System.Environment.Exit(0); }//关闭所有进程
                    }
                    else
                    {
                        InfoWindow Mes = new InfoWindow("未成功下线！\n您已强制退出程序", false);
                        Mes.StartPosition = FormStartPosition.CenterParent;
                        Mes.Show();
                    }
                }
            }
       }
    }
}
