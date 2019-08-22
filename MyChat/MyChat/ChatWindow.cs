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
using System.Net;
using System.Threading;
using System.IO;


namespace MyChat
{
    public partial class ChatWindow : MaterialForm
    {
        private List<Friend> MyFriendList;//好友列表
        private EmojiBox AllEmoji;//表情框

        private TcpListener MyListener;//侦听来自TCP网络客户端的连接
        private TcpClient client;//TcpClient
        private Thread LisThd;//后台侦听线程

        public ChatWindow()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;//设置界面主题颜色
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey600, Primary.BlueGrey800, Primary.BlueGrey300, Accent.DeepOrange100, TextShade.WHITE);

            LisThd = new Thread(Listen);
            LisThd.IsBackground = true;
            LisThd.Start();//开始侦听
            this.NameLabel.Text = BasicInfo.UserName;//初始化基本信息
            MyFriendList = new List<Friend>();
            //BasicInfo.CurrentFriend = BasicInfo.UserName;
           // BasicInfo.CurrentFriend = null;
            AllEmoji = new EmojiBox();
            Controls.Add(AllEmoji);
            AllEmoji.Hide();
            AllEmoji.sendEmoji += new SendEmoji(send_emoji);
            BasicInfo.LoadPortraitList();

            int i = -1;
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int j = 0; j < BasicInfo.PortraitList.Count(); j++)
            {
                if (BasicInfo.UserName.Equals(BasicInfo.PortraitList[j].Substring(0, 10)))
                {
                    i = int.Parse(BasicInfo.PortraitList[j].Substring(11,1));
                    break;
                }
                Console.WriteLine(BasicInfo.PortraitList[j].Substring(0, 10));
            }
            if (i == -1)
            {
                i = rand.Next(1, 10);//随机生成头像信息并记录
                string NewString = BasicInfo.UserName + " " + i.ToString();
                BasicInfo.AddPortraitList(NewString);
            }

            this.MyPotrait.Image = PortraitList.Images[i];
            BasicInfo.Portrait= new Bitmap(PortraitList.Images[i]);
        }
        
        private void Listen()
        {
            int LisPort = int.Parse(BasicInfo.UserName.Substring(6)) + 10000;//为每个用户使用单独侦听端口学号后4位加上10000,
            MyListener = new TcpListener(IPAddress.Any, LisPort);//设定本机侦听的IP和端口号
            MyListener.Start();//开始侦听
            AsyncCallback LisCallback = new AsyncCallback(AcpClientCallback);//异步方法处理
            MyListener.BeginAcceptTcpClient(LisCallback, MyListener);//异步接受传入的连接尝试
        }
        private void AcpClientCallback(IAsyncResult ar)//回调函数
        {
            MyListener = (TcpListener)ar.AsyncState;
            client = MyListener.EndAcceptTcpClient(ar);//异步接受传入的连接尝试
            Thread AcpThread = new Thread(PharseMessage);  //收到聊天后单独开线程处理接收信息
            AcpThread.Start();
            AsyncCallback LisCallback = new AsyncCallback(AcpClientCallback);//循环监听
            MyListener.BeginAcceptTcpClient(LisCallback, MyListener);//重新开始异步操作来接受传入的连接尝试
        }
        private void PharseMessage()//接到消息时确认发送方回复ACK,为正式信息传输做准备
        {
            NetworkStream PeerToPeer = client.GetStream();//提取网络数据流
            string FriendName = TcpReceive(PeerToPeer);//收到来自FriendName的消息
            TcpSend(PeerToPeer, "ACK");//回复ACK
            string receivedWords = TcpReceive(PeerToPeer);//接收正式的消息
            if (receivedWords.StartsWith("[FileName]"))//收到的是文件
                ProcessFile(FriendName, receivedWords);
            else
                ProcessMessage(FriendName, receivedWords);//收到的是消息或表情
        }
        private void ProcessMessage(string FriendName, string receivedWords)//处理消息与表情
        {
            this.Invoke(new EventHandler(delegate
            { 
                Friend CurrentFriend;
                if (receivedWords.StartsWith("[Group]"))
                {
                    int j = -1;
                    for (int i = 0; i < MyFriendList.Count; i++)
                    {
                        if (MyFriendList[i].Name == FriendName)//已有该群聊
                        {
                            j = i;
                            break;
                        }
                    }
                    if (j != -1)
                    {

                        MyFriendList[j].IsGroupChat = true;
                        if (receivedWords.StartsWith("[Group][InfoUpdate]")) //更新信息
                        {
                            MyFriendList[j].GroupInfo.UpdateGroupMessageReceive(receivedWords);
                            if (MyFriendList[j].Name == BasicInfo.CurrentFriend)
                            {
                                BasicInfo.IsGroup = true;
                            }
                        }
                        else
                        {
                            string msg = MyFriendList[j].GroupInfo.GetMessage(receivedWords);
                            string sender = msg.Substring(0, 10);
                            msg = msg.Substring(10);
                            if (msg.StartsWith("[Emoji]"))
                            {
                                int num = 0;
                                try
                                {
                                    num = int.Parse(msg.Substring("[Emoji]".Length));
                                    if (num >= EmojiList.Images.Count || num < 0)
                                        num = EmojiList.Images.Count - 1;
                                }
                                catch { num = 0; }
                                CurrentFriend = UpdateChatPanel(FriendName, "[" + sender + "]发送表情");//更新对话框
                                Refresh(CurrentFriend, false);
                                CurrentFriend = UpdateChatPanel(FriendName, EmojiList.Images[num]);//更新对话框
                                Refresh(CurrentFriend, false);
                                BasicInfo.IsGroup = true;
                            }
                            else
                            {
                                CurrentFriend = UpdateChatPanel(FriendName, "[" + sender + "]:\n");//更新对话框
                                Refresh(CurrentFriend, false);
                            }
                        }
                    }
                    else {
                        if (receivedWords.StartsWith("[Group][InfoUpdate]")) 
                        { }
                        else
                        {
                            Dictionary<string, string> friends_info = new Dictionary<string, string>();
                            friends_info.Clear();
                            ProcessMessage(FriendName, receivedWords);
                        }
                    }
                }
                else if (receivedWords.StartsWith("[Emoji]"))
                {
                    int num = 0;
                    try
                    {
                        num = int.Parse(receivedWords.Substring("[Emoji]".Length));
                        if (num >= EmojiList.Images.Count || num < 0)
                            num = EmojiList.Images.Count - 1;
                    }
                    catch { Console.WriteLine("表情下标越界"); }
                    CurrentFriend = UpdateChatPanel(FriendName, EmojiList.Images[num]);//更新对话框
                    Refresh(CurrentFriend, false);
                }
                else
                {
                    CurrentFriend = UpdateChatPanel(FriendName, receivedWords);//更新对话框
                    Refresh(CurrentFriend, false);
                }
                if (Friend.PeopleCount == 1)
                {
                    BasicInfo.CurrentFriend = FriendName;
                }
            }));
        }
        private void ProcessFile(string FriendName, string receivedWords)//处理接收到的文件
        {
            NetworkStream PeerToPeer = client.GetStream();
            int pos = -1;
            for (int i = 0; i < MyFriendList.Count; i++)
            {
                if (MyFriendList[i].Name == FriendName)
                {
                    pos = i;
                    break;
                }
            }
            if (pos > -1)
            {
                bool IsError = false;
                string message = receivedWords;
 
                int posTemp = message.IndexOf("[Length]");
                string FileName = message.Substring("[FileName]".Length, posTemp - "[FileName]".Length);//提取文件名
                Console.WriteLine("接收文件"+FileName);
                int FileLength = int.Parse(message.Substring(posTemp + "[Length]".Length));
                string path = ".\\" + BasicInfo.UserName;//存在当前目录下该用户名的文件夹下
                if (!Directory.Exists(path))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    directoryInfo.Create();
                }
                string FilePath = path + "\\"+ FileName;

                FileStream WriteStream;//把接收的文件写到文件里
                try
                {
                    WriteStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
                }
                catch
                {
                    Console.WriteLine("写入文件失败");
                    InfoWindow Mes = new InfoWindow("文件写入失败\n文件被占用", false)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    Mes.Show();
                    return;
                }

                byte[] buffer = new byte[2048];
                int ReceiveBytes = 0;
                PeerToPeer.ReadTimeout = 20000;
                Console.WriteLine("正在接收文件");
                int ReceiveLength = 0;
                while (ReceiveLength < FileLength && !IsError)
                {
                    try
                    {
                        ReceiveBytes = PeerToPeer.Read(buffer, 0, buffer.Length);
                        ReceiveLength += ReceiveBytes;
                        WriteStream.Write(buffer, 0, ReceiveBytes);//将字节写入文件
                    }
                    catch
                    {
                        IsError = true;//似乎提示框会报错，但是一般不会被触发
                        InfoWindow Mes = new InfoWindow("文件接收失败\n请稍后重试", false);
                        Mes.StartPosition = FormStartPosition.CenterParent;
                        Mes.Show();
                        return;
                    }
                }
                PeerToPeer.Flush();
                PeerToPeer.Close();
                if (!IsError)
                {
                    WriteStream.Flush();
                    WriteStream.Close();
                    this.Invoke(new EventHandler(delegate
                    {
                        string temp = "[文件][" + FileName + "]";//显示在聊天框里
                        Friend TempFriend = UpdateChatPanel(FriendName, temp, DialogueType.PeerText);
                        Refresh(TempFriend);
                        if (Friend.PeopleCount == 1)
                        {
                            BasicInfo.CurrentFriend = FriendName;
                        }
                    }));
                }
            }
            else
            {
                UpdateChatPanel(FriendName, string.Empty);//添加好友对话后再处理文件
                ProcessFile(FriendName, receivedWords);
            }
        }

        private void TcpSend(NetworkStream ClientToServer, string Message)//发送TCP消息
        {
            byte[] msg = Encoding.Default.GetBytes(Message);//将字符串转化为字节流
            try
            {
                ClientToServer.Write(msg, 0, msg.Length);//写入NetworkStream
                Console.WriteLine(Message);
            }
            catch
            {
                InfoWindow Mes = new InfoWindow("发送消息失败！", false);
                Mes.StartPosition = FormStartPosition.CenterParent;
                Mes.ShowDialog();
            }
        }
        private string TcpReceive(NetworkStream ClientToServer)//接收TCP消息
        {
            string response = "";
            byte[] Buffer = new byte[1024];
            int length = 0;
            try
            {
                length = ClientToServer.Read(Buffer, 0, 1024);
                if (length > 0)
                {
                    response = Encoding.Default.GetString(Buffer, 0, length);//将字节流转化为字符串
                    Console.WriteLine("TCP_Receive"+response);
                }
            }
            catch
            {
                InfoWindow Mes = new InfoWindow("接收消息失败！", false);
                Mes.StartPosition = FormStartPosition.CenterParent;
                Mes.ShowDialog();
            }
            return response;
        }
        private QueryResult SearchIP (string Name)//查询对话方的IP地址信息
        {
            TcpClient client = new TcpClient();
            QueryResult query = new QueryResult();
            try
            {
                client.Connect(BasicInfo.ServerIp, BasicInfo.ServerPort);
            }
            catch
            {
                InfoWindow Mes2 = new InfoWindow("连接失败\n  请稍后重试", false);
                Mes2.StartPosition = FormStartPosition.CenterParent;
                Mes2.ShowDialog();
                client.Close();
            }
            if (client.Connected)
            {
                NetworkStream ClientToServer = client.GetStream();
                string QueryInfo = "q" + Name;//“q”+学号查询在线状态
                TcpSend(ClientToServer, QueryInfo);
                string response = TcpReceive(ClientToServer);
                query.Message = response;
                if (response.Length > 0)
                {
                    if (response == "n")
                    {
                        InfoWindow Mes1 = new InfoWindow("该用户不在线", false);
                        Mes1.StartPosition = FormStartPosition.CenterParent;
                        Mes1.ShowDialog();
                    }
                    else
                    {
                        query.IsOnline = true;
                        query.IP = response;
                    }
                }
                ClientToServer.Close();
            }
            client.Close();
            return query;
        }
        private bool SendText(string Name, string Message)//发起P2P连接发送信息
        {
            QueryResult query = SearchIP(Name);
            if (query.IsOnline)
            {
                TcpClient NewClient = new TcpClient();
                try//尝试发起P2P连接
                {
                    int Port = int.Parse(Name.Substring(6)) + 10000;
                    NewClient.Connect(query.IP, Port);
                }
                catch//P2P连接失败
                {
                    Console.WriteLine("发起P2P连接失败");
                    return false;
                }
                if (NewClient.Connected)
                {
                    NetworkStream PeerToPeer = NewClient.GetStream();
                    byte[] ConfirmMessage = Encoding.Default.GetBytes(BasicInfo.UserName);
                    string response;
                    try
                    {
                        PeerToPeer.Write(ConfirmMessage, 0, ConfirmMessage.Length);//发送自己的名字，收到ACK时进行对话
                        byte[] ReturnMessage = new byte[20];
                        int length = PeerToPeer.Read(ReturnMessage, 0, ReturnMessage.Length);
                        response = Encoding.Default.GetString(ReturnMessage, 0, length);
                        Console.WriteLine(response);
                    }
                    catch
                    {
                        Console.WriteLine("发送认证信息失败");
                        PeerToPeer.Close();
                        NewClient.Close();
                        return false;
                    }
                    if (response == "ACK")//收到ACK回复可以正式进行对话
                    {
                        try
                        {
                            byte[] SendMessage = Encoding.Default.GetBytes(Message);
                            PeerToPeer.Write(SendMessage, 0, SendMessage.Length);//把消息发送出去
                        }
                        catch
                        {
                            //Console.WriteLine("发送需要传递的信息失败");
                            PeerToPeer.Close();
                            NewClient.Close();
                            return false;
                        }
                     }
                    Console.WriteLine("发送"+Message+"成功");
                    PeerToPeer.Close();
                    NewClient.Close();
                    return true;
                }
            }
            InfoLabel.Location = new Point(679 - InfoLabel.Width, 13);
            return false;
        }
        private void sendfile(object file)//发起P2P连接发送文件
        {
            string FileName = (string)file;
            string FriendName = FileName.Substring(0, 10);
            FileName = FileName.Substring(10);
            string truefilename = FileName.Substring(FileName.LastIndexOf('\\') + 1);
            FileStream ReadStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024];
            int Packet = 1024;
            int TotalFileNum = (int)(ReadStream.Length + 1023) / 1024;
            if (TotalFileNum > 0)// 文件不为空
            {
                int pos = -1;
                for (int i = 0; i < MyFriendList.Count; i++)
                {
                    if (MyFriendList[i].Name == FriendName)
                    {
                        pos = i;
                        break;
                    }
                }
                QueryResult query = SearchIP(FriendName);//与发送消息基本相同
                while (true)//等待端口空闲
                {
                    pos = -1;
                    for (int i = 0; i < MyFriendList.Count; i++)
                    {
                        if (MyFriendList[i].Name == FriendName)
                        {
                            pos = i;
                            break;
                        }
                    }
                    if (pos > -1 || MyFriendList[pos].IsBusy == false)
                        break;
                    else
                    {
                        InfoLabel.Text = "端口正在占用，请稍等";
                    }
                }
                TcpClient NewClient = new TcpClient();
                MyFriendList[pos].IsBusy = true;//正在占用端口

                try//先尝试连接服务器
                {
                    int Port = int.Parse(FriendName.Substring(6)) + 10000;
                    NewClient.Connect(query.IP, Port);
                }
                catch//未连接成功
                {
                    Console.WriteLine("发起P2P连接失败");
                    return;
                }
                if (NewClient.Connected)
                {
                    NetworkStream PeerToPeer = NewClient.GetStream();
                    byte[] ConfirmMessage = Encoding.Default.GetBytes(BasicInfo.UserName);
                    string response;
                    try
                    {
                        PeerToPeer.Write(ConfirmMessage, 0, ConfirmMessage.Length);//发送自己的名字，收到ACK时进行对话
                        byte[] ReturnMessage = new byte[20];
                        int length = PeerToPeer.Read(ReturnMessage, 0, ReturnMessage.Length);
                        response = Encoding.Default.GetString(ReturnMessage, 0, length);
                        Console.WriteLine(response);
                    }
                    catch
                    {
                        Console.WriteLine("发送P2P认证信息失败");
                        PeerToPeer.Close();
                        NewClient.Close();
                        return;
                    }
                    if (response == "ACK")//对方已经收到发出去的消息并加自己为好友
                    { 
                    string temp = "[FileName]" + truefilename + "[Length]" + ReadStream.Length.ToString();
                    byte[] msg = Encoding.Default.GetBytes(temp);
                    //Console.WriteLine(msg.Length);
                    PeerToPeer.Write(msg, 0, msg.Length);
                    PeerToPeer.WriteTimeout = 20000;
                    int fileLength = 0;
                    try
                    {
                        while (fileLength < ReadStream.Length)
                        {
                            this.Invoke(new EventHandler(delegate
                            {
                                double percent = Convert.ToInt32(100.0 * fileLength / ReadStream.Length);
                                InfoLabel.Text = "文件传输中..." + percent + "%";//显示文件传输进度
                            }));
                            Packet = ReadStream.Read(buffer, 0, buffer.Length);
                            PeerToPeer.Write(buffer, 0, Packet);
                            fileLength += Packet;
                        }
                        Console.WriteLine(fileLength.ToString() + "  " + ReadStream.Length.ToString());
                        this.Invoke(new EventHandler(delegate
                        {
                            InfoLabel.Text = "文件传输完成";
                        }));
                        ReadStream.Flush();//ReadStream.Flush();
                        PeerToPeer.Flush();
                        ReadStream.Close();
                    }
                    catch
                    {
                        InfoWindow Mes2 = new InfoWindow("文件传输失败", false);
                        Console.WriteLine("文件传输失败");
                        Mes2.StartPosition = FormStartPosition.CenterParent;
                        Mes2.Show();
                        return;
                    }
                    this.Invoke(new EventHandler(delegate
                    {
                        temp = "[文件][" + truefilename + "]";
                        UpdateChatPanel(BasicInfo.CurrentFriend, temp, DialogueType.MyText);//更新对话框显示
                    }));
                }
                    PeerToPeer.Close();
                    NewClient.Close();
                }
                MyFriendList[pos].IsBusy = false;//释放端口 
            }
            else
            {
                InfoWindow Mes2 = new InfoWindow("传输文件为空或过大", false);
                Mes2.StartPosition = FormStartPosition.CenterParent;
                Mes2.ShowDialog();
                return;
            }
        }

        private Friend UpdateChatPanel(string FriendName, string word = "",DialogueType t = DialogueType.PeerText, bool IsGroup = false)//更新对话框信息
        {
            bool HasFound = false;
            Friend TempFriend;
            int i = 0;
            while ( i < MyFriendList.Count)
            {
                if (MyFriendList[i].Name == FriendName)
                {
                    HasFound = true;
                    break;
                }
                i++;
            }
            if (!HasFound)
            {
                if (IsGroup == true)
                {
                    if (word != string.Empty)
                        TempFriend = new Friend(FriendName, word,true);//新生成朋友类时生成标签
                    else
                        TempFriend = new Friend(FriendName, "我们可以开始聊天啦", true);
                }
                else
                { 
                if (word != string.Empty)
                    TempFriend = new Friend(FriendName, word);//新生成朋友类时生成标签
                else
                    TempFriend = new Friend(FriendName);
                }
                TempFriend.setFront += new SetFront(setfront);//对话框置前
                MyFriendList.Add(TempFriend);
            }
            else
            {
                TempFriend = MyFriendList[i];
                if (word == string.Empty) word = "我们又见面啦！";
                if (t == DialogueType.PeerText)
                    TempFriend.AddPeerText(word);
                else if (t == DialogueType.MyText)
                    TempFriend.AddMyText(word);
                else if (t == DialogueType.PeerFile)
                    TempFriend.AddPeerText(word, true);
            }
            return TempFriend;
        }
        private Friend UpdateChatPanel(string FriendName, Image image, DialogueType t = DialogueType.PeerText, bool IsGroup = false)//更新对话框信息
        {
            bool HasFound = false;
            Friend TempFriend;
            int i = 0;
            while (i < MyFriendList.Count)
            {
                if (MyFriendList[i].Name == FriendName)
                {
                    HasFound = true;
                    break;
                }
                i++;
            }
            if (!HasFound)
            {
                if (IsGroup == true)
                {
                    TempFriend = new Friend(FriendName, image,true);
                }
                else
                { 
                TempFriend = new Friend(FriendName, image);
                }
                TempFriend.setFront += new SetFront(setfront);//增加委托触发
                MyFriendList.Add(TempFriend);
            }
            else
            {
                TempFriend = MyFriendList[i];
                if (t == DialogueType.PeerText)
                    TempFriend.AddPeerEmoji(image);
                else if (t == DialogueType.MyText)
                    TempFriend.AddMyEmoji(image);
            }
            return TempFriend;
        }
        private bool Refresh(Friend friend, bool BringFront = false)//调整控件顺序
        {
            FriendTag TempTag = friend.Tag;
            FlowLayoutPanel TempChatPanel = friend.ChatPanel;
            string TempString = friend.Name + "Tag";
            int pos = -1;
            for (int i = 0; i < FriendLayoutPanel.Controls.Count; i++)
            {
                if (FriendLayoutPanel.Controls[i].Name == TempString)
                {
                    pos = i;
                    break;
                }
            }
            if (pos == -1)
            {
                FriendLayoutPanel.Controls.Add(TempTag);
                Controls.Add(TempChatPanel);
                TempChatPanel.BringToFront();
                BasicInfo.CurrentFriend = friend.Name;//更新当前聊天好友
                return true;
            }
            else
            {
                FriendLayoutPanel.Controls.RemoveAt(pos);
                FriendLayoutPanel.Controls.Add(TempTag);
                FriendLayoutPanel.Controls.SetChildIndex(TempTag, pos);//更新标签里最新的时间与消息
                pos = -1;
                TempString = friend.Name + "ChatPanel";
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].Name == TempString)
                    {
                        pos = i;
                        break;
                    }
                }
                if (pos > -1)
                {
                    Controls.RemoveAt(pos);
                    Controls.Add(TempChatPanel);
                    //Controls.Add(friend.ChatPanel);
                    if (pos == 0 || BringFront ||BasicInfo.CurrentFriend== friend.Name)
                        //friend.ChatPanel.BringToFront();
                       TempChatPanel.BringToFront();
                    return true;
                }
                else
                {
                    Console.WriteLine("对应的对话框怎么没有好友标签？");
                    return false;
                } 
            }
        }
        private void setfront(string name) //显示对应的聊天对话框
        {
            BasicInfo.CurrentFriend = name;
            string PanelName = name + "ChatPanel";
            int pos = -1;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Name == PanelName)
                    pos = i;
            }
            if (pos > -1)
            {
                this.Controls[pos].BringToFront();
                BasicInfo.CurrentFriend = name;
                Console.WriteLine(name + "该显示在最前面了");
            }
            else { Console.WriteLine("没有找到相应的panel"); }
        }
        private void send_emoji(int num)//发送表情包
        {
            AllEmoji.Hide();
            string message = "[Emoji]" + num.ToString();
            if (SendText(BasicInfo.CurrentFriend, message))
            {
                Friend TempFriend = UpdateChatPanel(BasicInfo.CurrentFriend, EmojiList.Images[num], DialogueType.MyText);
                Refresh(TempFriend, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)//“查询好友”按键，查询好友在线状态并添加好友
        {
            string QueryName = SearchText.Text;
            if (QueryName == BasicInfo.UserName)//查询自己学号禁止添加自己操作
            {
                InfoWindow Mes2 = new InfoWindow("您已在线", false);
                Mes2.StartPosition = FormStartPosition.CenterParent;
                Mes2.ShowDialog();
                return;
            }
            TcpClient client = new TcpClient();
            QueryResult query = new QueryResult();
            try
            {
                client.Connect(BasicInfo.ServerIp, BasicInfo.ServerPort);
            }
            catch
            {
                InfoWindow Mes2 = new InfoWindow("连接失败\n  请稍后重试", false);
                Mes2.StartPosition = FormStartPosition.CenterParent;
                Mes2.ShowDialog();
                client.Close();
            }
            if (client.Connected)
            {
                NetworkStream ClientToServer = client.GetStream();
                string QueryInfo = "q" + QueryName;//“q”+学号查询在线状态
                TcpSend(ClientToServer, QueryInfo);
                string response = TcpReceive(ClientToServer);
                query.Message = response;
                Console.WriteLine("查询好友状态IP"+response);
                if (response.Length>0)
                {
                    if (response.StartsWith("I") || response.StartsWith("P"))//服务器返回InVailid No.或Please send correct message
                    {
                        InfoWindow Mes1 = new InfoWindow("该用户不存在", false);
                        Mes1.StartPosition = FormStartPosition.CenterParent;
                        Mes1.ShowDialog();
                        return;
                    }
                    else if (response == "n")
                    {
                        InfoWindow Mes1 = new InfoWindow("该用户不在线", false);
                        Mes1.StartPosition = FormStartPosition.CenterParent;
                        Mes1.ShowDialog();
                        return;
                    }
                    else
                    {
                        query.IsOnline = true;
                        query.IP = response;
                    }
                }
                ClientToServer.Close();
            }
            client.Close();

            InfoWindow Mes = new InfoWindow(QueryName + "在线\n 是否发起会话？", true);
            Mes.StartPosition = FormStartPosition.CenterParent;
            Mes.ShowDialog();
            if (Mes.DialogResult == DialogResult.Cancel)
                return;
            Friend CurrentFriend = UpdateChatPanel(QueryName, string.Empty);
            Refresh(CurrentFriend,true);
            return;
        }
        private void LoginButton_Click(object sender, EventArgs e)//"Send"按键，按下发送消息键
        {
            if (RichText.Text.Length == 0)
            {
                InfoWindow Mes1 = new InfoWindow("您还未输入信息哦", false);
                Mes1.StartPosition = FormStartPosition.CenterParent;
                Mes1.ShowDialog();
                return;
            }
            else
            {
                if (BasicInfo.CurrentFriend == null)
                {
                    InfoWindow Mes1 = new InfoWindow("您还未添加好友哦", false);
                    Mes1.StartPosition = FormStartPosition.CenterParent;
                    Mes1.ShowDialog();
                    return;
                }
                string filePath = "";
                //string 
                if (filePath == string.Empty)
                {
                    if (SendText(BasicInfo.CurrentFriend, RichText.Text))
                    {
                        Friend TempFriend = UpdateChatPanel(BasicInfo.CurrentFriend, RichText.Text, DialogueType.MyText);
                        Refresh(TempFriend, true);
                        RichText.Clear();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    string file = BasicInfo.CurrentFriend + filePath;
                    Thread SendFile;//发送文件线程
                    SendFile = new Thread(new ParameterizedThreadStart(sendfile));
                    SendFile.Start((object)file);//开线程传文件
                    RichText.Clear();
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)//点击“发送文件”图标
        {
            int pos = -1;
            for (int i = 0; i < MyFriendList.Count; i++)
            {
                if (MyFriendList[i].Name == BasicInfo.CurrentFriend)
                {
                    pos = i;
                    break;
                }
            }
            if (pos == -1)
            {
                UpdateChatPanel(BasicInfo.UserName, string.Empty);//更新当前聊天好友信息
                for (int i = 0; i < MyFriendList.Count; i++)
                {
                    if (MyFriendList[i].Name == BasicInfo.CurrentFriend)
                    {
                        pos = i;
                        break;
                    }
                }
            }
            if (pos > -1)
            {
                if (!MyFriendList[pos].IsBusy)
                {
                    OpenFileDialog SelectFile = new OpenFileDialog();
                    SelectFile.Filter = "All files (*.*)|*.*";
                    if (SelectFile.ShowDialog() == DialogResult.OK)//确认传文件
                    {
                        string file = BasicInfo.CurrentFriend + SelectFile.FileName;//包含要发送的对象及文件名的信息
                        Thread SendFile;//发送文件线程
                        SendFile = new Thread(new ParameterizedThreadStart(sendfile));
                        SendFile.Start((object)file);//新开线程传文件
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)//点击"退出登录"按键，执行下线功能
        {
            InfoWindow Confirm = new InfoWindow("确认退出当前账号？", true);
            Confirm.StartPosition = FormStartPosition.CenterParent;
            Confirm.ShowDialog();
            if (Confirm.DialogResult == DialogResult.OK)//确认退出
            {
                Confirm.Close();
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect(BasicInfo.ServerIp, BasicInfo.ServerPort);
                }
                catch
                {
                    InfoWindow Mes = new InfoWindow("服务器正忙\n 请稍等", false);
                    Mes.StartPosition = FormStartPosition.CenterParent;
                    Mes.Show();
                    return;
                }
                if (client.Connected)//连接成功发送下线请求
                {
                    NetworkStream ClientToServer = client.GetStream();
                    string LoginInfo = "logout" + BasicInfo.UserName;//"logout"+学号
                    byte[] send = Encoding.Default.GetBytes(LoginInfo);//转化为字节流
                    ClientToServer.Write(send, 0, send.Length);//写入NetworkStream

                    byte[] msg = new byte[1024];  //接收
                    int length = ClientToServer.Read(msg, 0, msg.Length);
                    string response = Encoding.Default.GetString(msg, 0, length);
                    Console.WriteLine(response);
                    if (response == "loo")//服务器返回成功下线信息
                    {
                        ClientToServer.Close();
                        client.Close();
                        InfoWindow Mes = new InfoWindow("下线成功！", false);
                        Mes.StartPosition = FormStartPosition.CenterParent;
                        Mes.ShowDialog();
                        if (Mes.DialogResult == DialogResult.Cancel)
                        {
                            System.Environment.Exit(0);//关闭所有进程
                        }
                    }
                    else
                    {
                        //InfoWindow Mes = new InfoWindow("服务器状态异常\n    请稍等", false);//提示信息好像会重复，这里不要了
                        //Mes.StartPosition = FormStartPosition.CenterParent;
                        //Mes.Show();
                        return;
                    }
                }
            }
        }
        private void SearchDialogueButton_Click(object sender, EventArgs e)//点击“保存/查询聊天记录”图标
        {
            string path = ".\\" + BasicInfo.UserName;
            if (!Directory.Exists(path))//用户目录不存在时新建文件夹
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                directoryInfo.Create();
            }
            if (!File.Exists(path + "\\With" + BasicInfo.CurrentFriend + ".txt"))//打开保存聊天记录的文件
            {
                FileStream fs = new FileStream(path + "\\With" + BasicInfo.CurrentFriend + ".txt", FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }
            int pos = -1;
            for (int i = 0; i < MyFriendList.Count; i++)
            {
                if (MyFriendList[i].Name == BasicInfo.CurrentFriend)
                {
                    pos = i;
                    break;
                }
            }
            if (pos > -1)
            {
                Console.WriteLine(pos);
                StreamWriter sw = new StreamWriter(path + "\\With" + BasicInfo.CurrentFriend + ".txt", true);
                for (int i = MyFriendList[pos].RecentSave; i < MyFriendList[pos].WordList.Count; i++)
                    sw.WriteLine(MyFriendList[pos].WordList[i]);
                MyFriendList[pos].RecentSave = MyFriendList[pos].WordList.Count;
                sw.Close();

                InfoWindow Confirm = new InfoWindow("聊天记录保存成功\n    是否打开?", true);
                Confirm.StartPosition = FormStartPosition.CenterParent;
                Confirm.ShowDialog();
                if (Confirm.DialogResult == DialogResult.OK)//确认退出
                {
                    System.Diagnostics.Process.Start("Explorer", path);
                }
                else return;
            }
        }
        private void SearchText_MouseClick(object sender, MouseEventArgs e)//查询好友登录状态的清空
        {
                SearchText.Text = "";
                SearchText.ForeColor = Color.Black;
                //SearchText.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }
        private void EmojiButton_Click(object sender, EventArgs e)//点击“发送表情”图标
        {
            AllEmoji.Show();
            AllEmoji.BringToFront();
            Console.WriteLine("按下了表情键就出现表情框了");
        }
        private void ScreenShotButton_Click(object sender, EventArgs e)//点击“截图”图标
        {
            InfoWindow Mes = new InfoWindow("功能尚未开放\n    敬请期待", false);
            Mes.StartPosition = FormStartPosition.CenterParent;
            Mes.ShowDialog();
        }
        // 误触产生的空函数，不敢乱删以免设计器报错
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void GroupButton_Click(object sender, EventArgs e)//点击“发起群聊”图标
        {
            if (MyFriendList.Count < 3)
            {
                InfoWindow Mes1 = new InfoWindow("您的好友数小于3\n  不能发起群聊", false);
                Mes1.StartPosition = FormStartPosition.CenterParent;
                Mes1.ShowDialog();
                return;
            }
            InfoWindow Confirm = new InfoWindow("与当前所有好友\n  发起群聊？", true);
            Confirm.StartPosition = FormStartPosition.CenterParent;
            Confirm.ShowDialog();
            if (Confirm.DialogResult == DialogResult.Cancel)//
            {
                return;
            }
            InfoWindow Mes = new InfoWindow("程序员Debug中...\n  请尝试其他功能", false);
            Mes.StartPosition = FormStartPosition.CenterParent;
            Mes.ShowDialog();
            return;
        }
    }
}
