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
    public delegate void SetFront1(string name);//点击Tag时候的委托
    public partial class FriendTag : UserControl
    {
        public event SetFront1 setFront1; //点击Tag时候的委托事件 
        public FriendTag(string FriendName,string Words="[添加好友成功]")
        {
            InitializeComponent();
            string CurrentTime;
            CurrentTime = DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute < 10)//显示时间
                CurrentTime += ":" + "0" + DateTime.Now.Minute.ToString();
            else
                CurrentTime += ":" + DateTime.Now.Minute.ToString();
            TimeLabel.Text = CurrentTime;
            Name = FriendName + "Tag";
            SetName(FriendName);
            SetWords(Words);
        }

        private void FriendTag_Click(object sender, EventArgs e)//点击Tag时对话框置前
        {
            //ShowNewsIcon.Visible = false;
            TextLabel.Text = "";
            setFront1(this.NameLabel.Text);//发送委托
        }
        private void TextLabel_Click(object sender, EventArgs e)//点击Text时对话框置前，以免有时候点击Tag点不准
        {
            //ShowNewsIcon.Visible = false;
            TextLabel.Text = "";
            setFront1(this.NameLabel.Text);//发送委托
        }
        private void NameLabel_Click(object sender, EventArgs e)//点击NameLabel时对话框置前，以免有时候点击Tag点不准
        {
            //ShowNewsIcon.Visible = false;
            TextLabel.Text = "";
            setFront1(this.NameLabel.Text);//发送委托
        }

        //设置时间
        public void SetTime(string TimeString)
        {
            this.TimeLabel.Text = TimeString;
        }
        //设置用户名
        public void SetName(string NameString)
        {
            this.NameLabel.Text = NameString;
        }
        //设置聊天的最后一句话
        public void SetWords(string WordString)
        {
            this.TextLabel.Text = WordString;
        }
        //设置头像
        public void SetPortrait(int i)
        {
            Portrait.Image = PortraitList.Images[i];
        }
        //返回用户名
        public string GetName()
        {
            return NameLabel.Text;
        }
        //返回头像
        public Bitmap GetPortrait()
        {
            return new Bitmap(Portrait.Image);
        }
        //返回时间
        public String GetTime(string TimeString)
        {
            return TimeLabel.Text;
        }
        //返回聊天的最后一句话
        public String GetWords(string WordString)
        {
            return TextLabel.Text ;
        }

      
    }
}
