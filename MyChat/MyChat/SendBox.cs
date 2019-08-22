using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChat
{
    public partial class SendBox : UserControl
    {
        public bool IsFile = false;
        public int SendType;//=1;
        public SendBox(string ChatText,int ChatType, Bitmap Portrait,string ChatName="2016011435")//添加对话显示
        {
            InitializeComponent();
            string CurrentTime;
            CurrentTime = DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute < 10)//以两位数显示分钟
                CurrentTime += ":" + "0" + DateTime.Now.Minute.ToString();
            else
                CurrentTime += ":" + DateTime.Now.Minute.ToString();
            TimeLabel.Text = CurrentTime;
            ChatLabel.Text = ChatText;
            FriendNameLabel.Text = ChatName;
            MyNameLabel.Text = BasicInfo.UserName;
            SendType = ChatType;
            this.Height = ChatLabel.Height + 65;
            if(ChatType==0)
            { 
            ChatLabel.Location = new Point(80, 40);
            ChatLabel.BringToFront();
            }
            else if (ChatType == 1)
            {
                ChatLabel.Location = new Point(this.Width-ChatLabel.Width-70, 40);
                ChatLabel.BringToFront();
            }
            Bitmap ShowPortrait = new Bitmap(Portrait);
            if (ChatType == 0)
            {
                this.FriendPortrait.Image = ShowPortrait;
                MyPortrait.Visible = false;
                MyNameLabel.Visible = false;
            }
            else if (ChatType == 1)
            {
                this.MyPortrait.Image = ShowPortrait;
                FriendPortrait.Visible = false;
                FriendNameLabel.Visible = false;
            }
        }
        public SendBox(Image Emoji, int ChatType, Bitmap Portrait, string ChatName = "2016011435")//添加图片显示
        {
            InitializeComponent();
            string CurrentTime;
            CurrentTime = DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute < 10)//以两位数显示分钟
                CurrentTime += ":" + "0" + DateTime.Now.Minute.ToString();
            else
                CurrentTime += ":" + DateTime.Now.Minute.ToString();
            TimeLabel.Text = CurrentTime;
            FriendNameLabel.Text = ChatName;
            MyNameLabel.Text = BasicInfo.UserName;
            SendType = ChatType;
            //ChatLabel.Text = ChatText;
            //this.Height = ChatLabel.Height + 65;
            for (int i = 0; i < this.Controls.Count; i++)
                this.Controls[i].Visible = false;
            EmojiBox.Visible = true;
            EmojiBox.Image = new Bitmap(Emoji, 50, 50);
            Bitmap ShowPortrait = new Bitmap(Portrait);
            if (ChatType == 0)
            {
                this.FriendNameLabel.Visible = true;
                this.FriendPortrait.Visible = true;
                this.FriendPortrait.Image = ShowPortrait;
                this.TimeLabel.Visible = true;
                EmojiBox.Location = new Point(80, 30);
                this.Height = EmojiBox.Height + 65;
            }
            else if (ChatType == 1)
            {
                this.MyNameLabel.Visible = true;
                this.MyPortrait.Visible = true;
                this.MyPortrait.Image = ShowPortrait;
                this.TimeLabel.Visible = true;
                EmojiBox.Location = new Point(this.Width - 110,30);
                this.Height = EmojiBox.Height + 65;
            }
        }
        public string GetWords()
        {
            return ChatLabel.Text;
        }
        public void SetTime()
        {
            string CurrentTime;
            CurrentTime = DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute < 10)//以两位数显示分钟
                CurrentTime += ":" + "0" + DateTime.Now.Minute.ToString();
            else
                CurrentTime += ":" + DateTime.Now.Minute.ToString();
            TimeLabel.Text = CurrentTime;
        }
        public string GetTime()
        {
            return TimeLabel.Text;
        }
        private void MyNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void ChatLabel_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("对话被按了");
            //if (SendType==0)
            //{
            //    //string message = ChatLabel.Text;
            //    //int j = message.IndexOf("\n");
            //    //string fileName = message.Substring(0, j);
            //    string fileName = ChatLabel.Text;
            //    sendFile1(FriendNameLabel.Text, fileName);
            //    Console.WriteLine("接收文件被按了");
            //}
        }
    }
}
