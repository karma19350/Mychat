using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using System.Net.Sockets;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;


namespace MyChat
{
    public partial class LoginWindow : MaterialForm
    {
        public LoginWindow()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;//设置主题颜色
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey600, Primary.BlueGrey800, Primary.BlueGrey300, Accent.DeepOrange100, TextShade.WHITE);

            BasicInfo.LoadPortraitList();//载入头像信息
            Bitmap myPotrait = new Bitmap(MyChat.Properties.Resources.秋, 128, 128);
            //Bitmap myPotrait = new Bitmap("../Portrait/1.png");
            this.PortraitBox.Image = new Bitmap(myPotrait, 128, 128);
            // this.PortraitBox.Image = new Bitmap(myPotrait);
            BasicInfo.ServerIp = "166.111.140.14";
            BasicInfo.ServerPort = 8000;
            BasicInfo.Portrait = new Bitmap(MyChat.Properties.Resources.秋);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string LoginInfo;
            int Port = 10000;
            try//记录端口
            {
                Port = int.Parse(NameText.Text.Substring(6)) + 10000;
            }
            catch
            {
                InfoWindow Mes = new InfoWindow("请输入有效账号", false);
                Mes.StartPosition = FormStartPosition.CenterParent;
                Mes.ShowDialog();
            }
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)//判断该端口是否被占用
            {
                if (endPoint.Port == Port)
                {
                    InfoWindow Mes = new InfoWindow("该账号已登录", false);
                    Mes.StartPosition = FormStartPosition.CenterParent;
                    Mes.ShowDialog();
                    return;
                }
            }
            TcpClient client = new TcpClient();
            try//尝试连接服务器
            {
                client.Connect(BasicInfo.ServerIp, BasicInfo.ServerPort);
            }
            catch//未连接成功
            {
                InfoWindow Mes = new InfoWindow("连接失败\n请稍后重试", false);
                Mes.StartPosition = FormStartPosition.CenterParent;
                Mes.ShowDialog();
            }
            if (client.Connected)
            {
                NetworkStream ClientToServer = client.GetStream();
                LoginInfo = NameText.Text + "_" + PasswordText.Text;
                byte[] send = Encoding.Default.GetBytes(LoginInfo);//将输入信息转化为字节流
                ClientToServer.Write(send, 0, send.Length);//写入NetworkStream

                //接收
                byte[] msg = new byte[1024];
                int length = ClientToServer.Read(msg, 0, msg.Length);
                string response = Encoding.Default.GetString(msg, 0, length);
                Console.WriteLine(response);
                if (response == "lol")//服务器返回登录成功
                {
                    BasicInfo.UserName = NameText.Text;
                    ClientToServer.Close();
                    client.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    InfoWindow Mes = new InfoWindow("用户名或密码错误！", false);
                    Mes.StartPosition = FormStartPosition.CenterParent;
                    Mes.ShowDialog();
                }
            }
            else
            {
                return;
            }
        }
        //误触产生的空函数，不敢乱删以免设计器报错
        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void heightText_Click(object sender, EventArgs e)
        {

        }
        private void widthText_Click(object sender, EventArgs e)
        {

        }

      
    }
}
