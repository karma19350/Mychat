namespace MyChat
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            this.FriendLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.RichText = new System.Windows.Forms.RichTextBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.GroupButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SendButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SearchDialogueButton = new System.Windows.Forms.Button();
            this.ScreenShotButton = new System.Windows.Forms.Button();
            this.FileButton = new System.Windows.Forms.Button();
            this.EmojiButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.EmojiList = new System.Windows.Forms.ImageList(this.components);
            this.BackPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.MyPotrait = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PortraitList = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyPotrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FriendLayoutPanel
            // 
            this.FriendLayoutPanel.BackColor = System.Drawing.Color.FloralWhite;
            this.FriendLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FriendLayoutPanel.Location = new System.Drawing.Point(0, 222);
            this.FriendLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FriendLayoutPanel.Name = "FriendLayoutPanel";
            this.FriendLayoutPanel.Size = new System.Drawing.Size(311, 525);
            this.FriendLayoutPanel.TabIndex = 1;
            // 
            // RichText
            // 
            this.RichText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichText.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichText.ForeColor = System.Drawing.Color.Black;
            this.RichText.Location = new System.Drawing.Point(311, 567);
            this.RichText.Name = "RichText";
            this.RichText.Size = new System.Drawing.Size(689, 138);
            this.RichText.TabIndex = 3;
            this.RichText.Text = "";
            // 
            // SearchText
            // 
            this.SearchText.BackColor = System.Drawing.SystemColors.Window;
            this.SearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchText.ForeColor = System.Drawing.Color.DarkGray;
            this.SearchText.Location = new System.Drawing.Point(30, 154);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(231, 18);
            this.SearchText.TabIndex = 10;
            this.SearchText.Text = "查询好友状态";
            this.SearchText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchText_MouseClick);
            // 
            // GroupButton
            // 
            this.GroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupButton.BackColor = System.Drawing.Color.SeaShell;
            this.GroupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GroupButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.GroupButton.FlatAppearance.BorderSize = 0;
            this.GroupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.GroupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.GroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupButton.ForeColor = System.Drawing.Color.Salmon;
            this.GroupButton.Location = new System.Drawing.Point(7, 172);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GroupButton.Size = new System.Drawing.Size(120, 30);
            this.GroupButton.TabIndex = 11;
            this.GroupButton.Text = "发起群聊";
            this.GroupButton.UseVisualStyleBackColor = false;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchButton.BackColor = System.Drawing.Color.SeaShell;
            this.SearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchButton.ForeColor = System.Drawing.Color.Salmon;
            this.SearchButton.Location = new System.Drawing.Point(175, 172);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SearchButton.Size = new System.Drawing.Size(120, 30);
            this.SearchButton.TabIndex = 12;
            this.SearchButton.Text = "查询好友";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.SeaShell;
            this.WelcomeLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WelcomeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WelcomeLabel.Location = new System.Drawing.Point(144, 82);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(104, 25);
            this.WelcomeLabel.TabIndex = 13;
            this.WelcomeLabel.Text = "Welcome!\r\n";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.SeaShell;
            this.NameLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NameLabel.Location = new System.Drawing.Point(144, 107);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(122, 25);
            this.NameLabel.TabIndex = 15;
            this.NameLabel.Text = "2016011481";
            // 
            // SendButton
            // 
            this.SendButton.Depth = 0;
            this.SendButton.Location = new System.Drawing.Point(857, 707);
            this.SendButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendButton.Name = "SendButton";
            this.SendButton.Primary = true;
            this.SendButton.Size = new System.Drawing.Size(141, 39);
            this.SendButton.TabIndex = 16;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.InfoLabel);
            this.panel1.Controls.Add(this.SearchDialogueButton);
            this.panel1.Controls.Add(this.ScreenShotButton);
            this.panel1.Controls.Add(this.FileButton);
            this.panel1.Controls.Add(this.EmojiButton);
            this.panel1.Location = new System.Drawing.Point(311, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 46);
            this.panel1.TabIndex = 0;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.Color.SeaShell;
            this.InfoLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InfoLabel.ForeColor = System.Drawing.Color.DimGray;
            this.InfoLabel.Location = new System.Drawing.Point(553, 13);
            this.InfoLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 20);
            this.InfoLabel.TabIndex = 18;
            // 
            // SearchDialogueButton
            // 
            this.SearchDialogueButton.AutoSize = true;
            this.SearchDialogueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchDialogueButton.BackColor = System.Drawing.Color.SeaShell;
            this.SearchDialogueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SearchDialogueButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.SearchDialogueButton.FlatAppearance.BorderSize = 0;
            this.SearchDialogueButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.SearchDialogueButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.SearchDialogueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchDialogueButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchDialogueButton.ForeColor = System.Drawing.Color.Salmon;
            this.SearchDialogueButton.Image = global::MyChat.Properties.Resources.查询;
            this.SearchDialogueButton.Location = new System.Drawing.Point(160, 8);
            this.SearchDialogueButton.Name = "SearchDialogueButton";
            this.SearchDialogueButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SearchDialogueButton.Size = new System.Drawing.Size(30, 30);
            this.SearchDialogueButton.TabIndex = 20;
            this.SearchDialogueButton.UseVisualStyleBackColor = false;
            this.SearchDialogueButton.Click += new System.EventHandler(this.SearchDialogueButton_Click);
            // 
            // ScreenShotButton
            // 
            this.ScreenShotButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ScreenShotButton.BackColor = System.Drawing.Color.SeaShell;
            this.ScreenShotButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ScreenShotButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.ScreenShotButton.FlatAppearance.BorderSize = 0;
            this.ScreenShotButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.ScreenShotButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.ScreenShotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenShotButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ScreenShotButton.ForeColor = System.Drawing.Color.Salmon;
            this.ScreenShotButton.Image = global::MyChat.Properties.Resources.截图;
            this.ScreenShotButton.Location = new System.Drawing.Point(110, 8);
            this.ScreenShotButton.Name = "ScreenShotButton";
            this.ScreenShotButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ScreenShotButton.Size = new System.Drawing.Size(30, 30);
            this.ScreenShotButton.TabIndex = 19;
            this.ScreenShotButton.UseVisualStyleBackColor = false;
            this.ScreenShotButton.Click += new System.EventHandler(this.ScreenShotButton_Click);
            // 
            // FileButton
            // 
            this.FileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileButton.BackColor = System.Drawing.Color.SeaShell;
            this.FileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FileButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.FileButton.FlatAppearance.BorderSize = 0;
            this.FileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.FileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.FileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileButton.ForeColor = System.Drawing.Color.Salmon;
            this.FileButton.Image = global::MyChat.Properties.Resources.文件1;
            this.FileButton.Location = new System.Drawing.Point(60, 8);
            this.FileButton.Name = "FileButton";
            this.FileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FileButton.Size = new System.Drawing.Size(30, 30);
            this.FileButton.TabIndex = 18;
            this.FileButton.UseVisualStyleBackColor = false;
            this.FileButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // EmojiButton
            // 
            this.EmojiButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EmojiButton.BackColor = System.Drawing.Color.SeaShell;
            this.EmojiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EmojiButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.EmojiButton.FlatAppearance.BorderSize = 0;
            this.EmojiButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.EmojiButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.EmojiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmojiButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmojiButton.ForeColor = System.Drawing.Color.Salmon;
            this.EmojiButton.Image = global::MyChat.Properties.Resources.表情__2_;
            this.EmojiButton.Location = new System.Drawing.Point(10, 8);
            this.EmojiButton.Name = "EmojiButton";
            this.EmojiButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmojiButton.Size = new System.Drawing.Size(30, 30);
            this.EmojiButton.TabIndex = 17;
            this.EmojiButton.UseVisualStyleBackColor = false;
            this.EmojiButton.Click += new System.EventHandler(this.EmojiButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.BackColor = System.Drawing.Color.SeaShell;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExitButton.ForeColor = System.Drawing.Color.Salmon;
            this.ExitButton.Location = new System.Drawing.Point(878, 32);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExitButton.Size = new System.Drawing.Size(120, 32);
            this.ExitButton.TabIndex = 17;
            this.ExitButton.Text = "退出登录";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // EmojiList
            // 
            this.EmojiList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("EmojiList.ImageStream")));
            this.EmojiList.TransparentColor = System.Drawing.Color.Transparent;
            this.EmojiList.Images.SetKeyName(0, "大哭.png");
            this.EmojiList.Images.SetKeyName(1, "嘿嘿.png");
            this.EmojiList.Images.SetKeyName(2, "哼.png");
            this.EmojiList.Images.SetKeyName(3, "惊呆.png");
            this.EmojiList.Images.SetKeyName(4, "可爱.png");
            this.EmojiList.Images.SetKeyName(5, "痞老板.png");
            this.EmojiList.Images.SetKeyName(6, "可怜.png");
            this.EmojiList.Images.SetKeyName(7, "酷.png");
            this.EmojiList.Images.SetKeyName(8, "使劲.png");
            this.EmojiList.Images.SetKeyName(9, "我去.png");
            this.EmojiList.Images.SetKeyName(10, "生气.png");
            this.EmojiList.Images.SetKeyName(11, "吐舌.png");
            this.EmojiList.Images.SetKeyName(12, "笑哭.png");
            // 
            // BackPicture
            // 
            this.BackPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackPicture.Image = global::MyChat.Properties.Resources.莫奈小径;
            this.BackPicture.Location = new System.Drawing.Point(311, 67);
            this.BackPicture.Name = "BackPicture";
            this.BackPicture.Size = new System.Drawing.Size(689, 457);
            this.BackPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackPicture.TabIndex = 18;
            this.BackPicture.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.SeaShell;
            this.pictureBox4.Image = global::MyChat.Properties.Resources.查询;
            this.pictureBox4.Location = new System.Drawing.Point(266, 150);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // MyPotrait
            // 
            this.MyPotrait.Image = global::MyChat.Properties.Resources.秋1;
            this.MyPotrait.Location = new System.Drawing.Point(30, 72);
            this.MyPotrait.Name = "MyPotrait";
            this.MyPotrait.Size = new System.Drawing.Size(70, 70);
            this.MyPotrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MyPotrait.TabIndex = 5;
            this.MyPotrait.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SeaShell;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(0, 67);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(311, 155);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(311, 527);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(689, 223);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PortraitList
            // 
            this.PortraitList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PortraitList.ImageStream")));
            this.PortraitList.TransparentColor = System.Drawing.Color.Transparent;
            this.PortraitList.Images.SetKeyName(0, "秋1.jpg");
            this.PortraitList.Images.SetKeyName(1, "睡莲2.jpg");
            this.PortraitList.Images.SetKeyName(2, "滑铁卢大桥.jpg");
            this.PortraitList.Images.SetKeyName(3, "莫奈晚霞.jpg");
            this.PortraitList.Images.SetKeyName(4, "杏花满枝1.jpg");
            this.PortraitList.Images.SetKeyName(5, "1.png");
            this.PortraitList.Images.SetKeyName(6, "4.png");
            this.PortraitList.Images.SetKeyName(7, "5.png");
            this.PortraitList.Images.SetKeyName(8, "2.png");
            this.PortraitList.Images.SetKeyName(9, "7.png");
            this.PortraitList.Images.SetKeyName(10, "8.png");
            this.PortraitList.Images.SetKeyName(11, "按钮2.png");
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.ControlBox = false;
            this.Controls.Add(this.BackPicture);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.GroupButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.MyPotrait);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.RichText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FriendLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyChat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyPotrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FriendLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox RichText;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox MyPotrait;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label NameLabel;
        private MaterialSkin.Controls.MaterialRaisedButton SendButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SearchDialogueButton;
        private System.Windows.Forms.Button ScreenShotButton;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.Button EmojiButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.PictureBox BackPicture;
        private System.Windows.Forms.ImageList EmojiList;
        private System.Windows.Forms.ImageList PortraitList;
    }
}