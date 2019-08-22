using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace MyChat
{
    public delegate void SetFront(string name);//显示当前聊天对话框委托
    class BasicInfo
    {
        public static string ServerIp { get; set; }//166.111.140.14
        public static int ServerPort { get; set; }//8000
        public static string UserName { get; set; }//当前登录者的账号
        public static Bitmap Portrait { get; set; }//当前登录者的头像
        public static string CurrentFriend { get; set; }//当前对话好友账号或群聊名称
        public static bool IsGroup { get; set; }//当前是否在群聊
        public static List<string> PortraitList = new List<string>();//记录头像信息
        public static void LoadPortraitList()
        {
            if (!File.Exists("PortraitList.txt"))
            {
                FileStream fs = new FileStream("PortraitList.txt", FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }
            string[] Portraits = File.ReadAllLines("PortraitList.txt");
            PortraitList.Clear();
            PortraitList = new List<string>(Portraits);
        }
        public static void AddPortraitList(string PortraitInfo)
        {
            PortraitList.Add(PortraitInfo);
            StreamWriter sw = new StreamWriter("PortraitList.txt", true);
            sw.WriteLine(PortraitInfo);
            sw.Close(); 
        }
    }

    class QueryResult//向中央服务器查询好友状态
    {
        public string Message = "";
        public bool IsOnline = false;
        public string IP = "";
    }

    class Friend
    {
        public event SetFront setFront;//对话框显示事件
        public bool IsBusy = false;
        public bool IsGroupChat = false;//默认不是群聊
        public Grouptalk GroupInfo = new Grouptalk();//新建群聊，默认是空群聊
        public static int PeopleCount = 0;
        public string Name;//好友用户名
        public FriendTag Tag = new FriendTag("","");//左侧好友标签
        public FlowLayoutPanel ChatPanel = new FlowLayoutPanel();//好友对话框
        public List<string> WordList = new List<string>();//聊天记录
        public int RecentSave = 0;//最近一次保存聊天记录的位置

        public Friend(string name, string word = "我们可以开始聊天啦",bool IsGroup=false)//新添加好友时首发信息是对话
        {
            if (IsGroup == true)
                IsGroupChat = true;
            this.Name = name;
            Random rand = new Random((int)DateTime.Now.Ticks);
           
            int i = -1;
            BasicInfo.LoadPortraitList();
            for (int j = 0; j < BasicInfo.PortraitList.Count(); j++)
            {
                if (name.Equals(BasicInfo.PortraitList[j].Substring(0, 10)))
                {
                    i = int.Parse(BasicInfo.PortraitList[j].Substring(11,1));
                    break;
                }
            }
            if (IsGroupChat == true)//群聊头像固定为10号
            {
                i = 10;
            }
            if (i == -1)
            {
                i = rand.Next(1, 10);//随机生成头像信息并记录
                string NewString = Name + " " + i.ToString();
  
                BasicInfo.AddPortraitList(NewString);
            }
            Tag = new FriendTag(name, word);
            Tag.SetPortrait(i);
            PeopleCount++;
            Tag.setFront1 += new SetFront1(HelpsetFront);//点击标签时弹出相应对话框
            InitFlowLayoutPanel(name);//初始化对话框
            Bitmap Portrait = Tag.GetPortrait();
            SendBox NewSend = new SendBox(word, 0, Portrait,name);
            string temp = "[" + NewSend.GetTime() + "]" + this.Name + ":" + word;
            this.WordList.Add(temp);
            ChatPanel.Controls.Add(NewSend);//对话框显示欢迎信息"我们可以开始聊天啦"
        }
        public Friend(string name, Image image, bool IsGroup = false)//新添加好友显示表情
        {
            if (IsGroup == true)
                IsGroupChat = true;
            this.Name = name;
            Random rand = new Random((int)DateTime.Now.Ticks);
            int i = -1;
            BasicInfo.LoadPortraitList();
            for (int j = 0; j < BasicInfo.PortraitList.Count(); j++)
            {
                if (name.Equals( BasicInfo.PortraitList[j].Substring(0, 10)))
                {
                    i = int.Parse(BasicInfo.PortraitList[j].Substring(11,1));
                    break;
                }
            }
            if (IsGroupChat == true)//群聊头像固定为10号
            {
                i = 10;
            }
            if (i == -1)
            {
                i = rand.Next(1, 10);//随机生成头像信息
                string NewString = Name + " " + i.ToString();
                BasicInfo.AddPortraitList(NewString);
            }
            Tag = new FriendTag(name, "[表情]");
            Tag.SetPortrait(i);
            PeopleCount++;
            Tag.setFront1 += new SetFront1(HelpsetFront);//点击标签时弹出相应对话框
            InitFlowLayoutPanel(name);//初始化对话框
            Bitmap Portrait = Tag.GetPortrait();
            SendBox NewSend = new SendBox(image, 0, Portrait,name);
            ChatPanel.Controls.Add(NewSend);
            string temp = "[" + NewSend.GetTime() + "]" + Name + ":[表情]";
            this.WordList.Add(temp);
        }
        public void HelpsetFront(string name)//否则会报错委托对象为空
        {
            setFront(name);
        }
        public void AddPeerText(string word, bool IsFile = false)//显示对方发送信息
        {
            Bitmap Portrait = Tag.GetPortrait();
            SendBox NewSend = new SendBox(word, 0, Portrait,this.Name);
            if (IsFile)
                NewSend.IsFile = true;
            ChatPanel.Controls.Add(NewSend);
            ChatPanel.ScrollControlIntoView(NewSend);
            Tag.SetTime(NewSend.GetTime());
            Tag.SetWords(NewSend.GetWords());
            string temp = "[" + NewSend.GetTime() + "]" + this.Name + ":" + word ;
            this.WordList.Add(temp);
        }
        public void AddMyText(string word)//显示自己发送信息
        {
            Bitmap Portrait = BasicInfo.Portrait;
            SendBox NewSend = new SendBox(word, 1, Portrait,BasicInfo.UserName);
            ChatPanel.Controls.Add(NewSend);
            ChatPanel.ScrollControlIntoView(NewSend);
            string temp = "[" + NewSend.GetTime() + "]" + BasicInfo.UserName + ":" + word;
            this.WordList.Add(temp);
        }
        public void AddPeerEmoji(Image image)//显示对方发送表情
        {
            Bitmap Portrait = Tag.GetPortrait();
            SendBox NewSend = new SendBox(image, 0, Portrait,this.Name);
            ChatPanel.Controls.Add(NewSend);
            ChatPanel.ScrollControlIntoView(NewSend);
            Tag.SetTime(NewSend.GetTime());
            Tag.SetWords(NewSend.GetWords());
            string temp = "["+ NewSend.GetTime() + "]" + Name  + ":[表情]" ;
            this.WordList.Add(temp);
        }
        public void AddMyEmoji(Image image)//显示自己发送表情
        {
            Bitmap Portrait = BasicInfo.Portrait;
            SendBox NewSend = new SendBox(image, 1, Portrait,BasicInfo.UserName);
            ChatPanel.Controls.Add(NewSend);
            ChatPanel.ScrollControlIntoView(NewSend);
            string temp = "[" + NewSend.GetTime() + "]" + BasicInfo.UserName + ":[表情]";
            this.WordList.Add(temp);
        }

        private void InitFlowLayoutPanel(string Name)//初始化对话框
        {
            ChatPanel = new FlowLayoutPanel();
            ChatPanel.AutoSize = false;
            ChatPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ChatPanel.Name = Name + "ChatPanel";
            ChatPanel.BackgroundImage = global::MyChat.Properties.Resources.莫奈小径;
            ChatPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //ChatPanel.BackColor = Color.SeaShell;
            ChatPanel.Location = new System.Drawing.Point(233, 55);
            //ChatPanel.Location = new System.Drawing.Point(311, 67);
            ChatPanel.Size = new System.Drawing.Size(520, 365);
            ChatPanel.AutoScroll = true;
            ChatPanel.WrapContents = false;
            ChatPanel.FlowDirection = FlowDirection.TopDown;
            ChatPanel.Visible = true;
        }
    }

    public enum DialogueType
    {
        PeerText,
        MyText,
        PeerFile
    }

    public class Grouptalk
    {
        public int MemberCount;//成员数
        public Dictionary<string, string> Name_IP = new Dictionary<string, string>();
        public Grouptalk()
        {
            Name_IP.Clear();//"用户名+IP"空列表
            MemberCount = 0;
        }
        public Grouptalk(Dictionary<string, string> FriendsInfo)
        {
            Name_IP.Clear();
            foreach (var ii in FriendsInfo)
            {
                string name = ii.Key;
                string ip = ii.Value;
                Name_IP.Add(name, ip);
            }
            MemberCount = FriendsInfo.Count;
        }
        public void UpdateGroupInfo(Dictionary<string, string> FriendsInfo)
        {
            Name_IP.Clear();
            foreach (var ii in FriendsInfo)
            {
                string name = ii.Key;
                string ip = ii.Value;
                Name_IP.Add(name, ip);
            }
            MemberCount = FriendsInfo.Count;
        }
        public string SetMessage(string message)//将发送的信息添加报头
        {
            string MessageSend = "";
            List<string> FriendName = new List<string>(Name_IP.Keys);
            MessageSend = "[Group]" + "[Count]" + FriendName.Count.ToString() + "[Info]";
            for (int i = 0; i < FriendName.Count; i++)
            {
                MessageSend = MessageSend + FriendName[i] + Name_IP[FriendName[i]] + "//";
            }
            MessageSend = MessageSend + "[Sender]" + BasicInfo.UserName + "[Message]" + message;
            return MessageSend;
        }

        public string GetMessage(string message)//将发送的信息去除报头
        {
            int num;
            string sender="";
            Dictionary<string, string> ReceiveInfo = new Dictionary<string, string>();
            ReceiveInfo.Clear();
            string ParseMessage = message.Substring("[Group]".Length);
            int i = message.IndexOf("[Count]") + "[Count]".Length;//获取群聊人数信息
            int j = message.IndexOf("[Info]");
            num = int.Parse(message.Substring(i, j - i));//获得人数
            ParseMessage = message.Substring(j + "[Info]".Length);//用户名+IP
            for (int k = 0; k < num; k++)
            {
                i = ParseMessage.IndexOf("//");
                string name = ParseMessage.Substring(0, 10);
                string ip = ParseMessage.Substring(10, i - 10);
                ReceiveInfo.Add(name, ip);
                ParseMessage = ParseMessage.Substring(i + "//".Length);
            }
            //刷新用户名+IP
            UpdateGroupInfo(ReceiveInfo);
            i = ParseMessage.IndexOf("[Sender]") + "[Sender]".Length;
            j = ParseMessage.IndexOf("[Message]");
         
            sender = ParseMessage.Substring(i, j - i);
            string MessageReceive = ParseMessage.Substring(j + "[Message]".Length);
            return sender + MessageReceive;//发送人+发送人发的信息
        }
        
        public string UpdateGroupMessageSend(string name, Dictionary<string, string> updateDictionary) //用新的字典更新用户名+IP
        {
            string message = "[Group]" + "[InfoUpdate]" + "[Name]" + name;
            List<string> FriendName = new List<string>(updateDictionary.Keys);
            message = message + "[Count]" + FriendName.Count.ToString() + "[Info]";
            for (int i = 0; i < FriendName.Count; i++)
            {
                message = message + FriendName[i] + updateDictionary[FriendName[i]] + "//";
            }
            message = message + "[Sender]" + BasicInfo.UserName;
            UpdateGroupInfo(updateDictionary);//更新信息,这个信息里没有发送的信息
            return message;
        }

        public string UpdateGroupMessageReceive(string message)
        {
            string parse = "//";
            int num;
            string msg = "";
            Dictionary<string, string> ReceiveInfo = new Dictionary<string, string>();//新建字典
            ReceiveInfo.Clear();
            msg = message.Substring("[Group]".Length + "[InfoUpdate]".Length);
            int i = message.IndexOf("[Name]") + "[Name]".Length;
            int j = message.IndexOf("[Count]");
            string newname = message.Substring(i, j - i);//获得群聊名字

            i = message.IndexOf("[Count]") + "[Count]".Length;
            j = message.IndexOf("[Info]");
            num = int.Parse(message.Substring(i, j - i));//获得人数
            msg = message.Substring(j + "[Info]".Length);
            for (int k = 0; k < num; k++)
            {
                i = msg.IndexOf(parse);
                string name = msg.Substring(0, 10);
                string ip = msg.Substring(10, i - 10);
                ReceiveInfo.Add(name, ip);//更新所有群聊人的信息
                msg = msg.Substring(i + parse.Length);
            }
          
            UpdateGroupInfo(ReceiveInfo);
            i = msg.IndexOf("[Sender]") + "[Sender]".Length;
            string sender = msg.Substring(i);
            return newname;
        }
    }

}
