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
    public delegate void SendEmoji(int number);//定义了一个委托类型
   

    public partial class EmojiBox : UserControl
    {
        public event SendEmoji sendEmoji;
        //private Cor[] EmojiLocatiion;
        public EmojiBox()
        {
            InitializeComponent();
            this.Location = new Point(235, 460);
            Console.WriteLine("表情包控件个数" + Controls.Count);
            //for (int i = 0; i < this.Controls.Count; i++)
            //{
            //    EmojiLocatiion[i] = new Cor(Controls[i].Location.X, Controls[i].Location.Y);
            //}
            Application.DoEvents();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sendEmoji(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sendEmoji(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sendEmoji(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sendEmoji(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sendEmoji(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            sendEmoji(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            sendEmoji(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            sendEmoji(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            sendEmoji(8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            sendEmoji(9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            sendEmoji(10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            sendEmoji(11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            sendEmoji(12);
        }

       
    }

    public class Cor//定义坐标类
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cor(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
