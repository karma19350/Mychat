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


namespace MyChat
{
    public partial class InfoWindow : MaterialForm
    {
        public InfoWindow(string info_text, bool iscorrect)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;//设置主题颜色
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey600, Primary.BlueGrey800, Primary.BlueGrey300, Accent.DeepOrange100, TextShade.WHITE);
                //该窗口始终置顶
                this.TopMost = true;
                if (iscorrect == false)//错误框
                { 
                    OKButton.Visible = false;
                    CancelButton.Visible = true;
                    CancelButton.Text = "确定";
                    CancelButton.ForeColor = Color.Salmon;
                    //提示语
                    this.InfoLabel.Text = info_text;
                    CancelButton.Width = this.Width - 110;
                    //调整各控件的位置
                    InfoLabel.Location = new Point(this.Width / 2 - InfoLabel.Width / 2, 35);
                    CancelButton.Location = new Point(this.Width / 2 - CancelButton.Width / 2, 80);
                }
                else//正常信息提示框
                {
                    OKButton.Visible = true;
                    CancelButton.Text = "取消";
                    //提示语
                    this.InfoLabel.Text = info_text;
                    //利用label自动调整大小的功能来调整整个窗体大小
                    CancelButton.Width = this.Width / 2 - 50;
                    OKButton.Width = this.Width / 2 - 50;
                    //调整各控件的位置
                    InfoLabel.Location = new Point(this.Width / 2 - InfoLabel.Width / 2, 35);
                    CancelButton.Location = new Point(this.Width / 2 + 15, 80);
                    OKButton.Location = new Point(this.Width / 2 - OKButton.Width - 15, 80);
                }
            }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
