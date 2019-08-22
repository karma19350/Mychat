namespace MyChat
{
    partial class SendBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendBox));
            this.ChatLabel = new System.Windows.Forms.Label();
            this.FriendPortrait = new System.Windows.Forms.PictureBox();
            this.MyPortrait = new System.Windows.Forms.PictureBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.FriendNameLabel = new System.Windows.Forms.Label();
            this.MyNameLabel = new System.Windows.Forms.Label();
            this.EmojiBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FriendPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmojiBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatLabel
            // 
            this.ChatLabel.AutoSize = true;
            this.ChatLabel.BackColor = System.Drawing.Color.SeaShell;
            this.ChatLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChatLabel.Location = new System.Drawing.Point(94, 45);
            this.ChatLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this.ChatLabel.Name = "ChatLabel";
            this.ChatLabel.Size = new System.Drawing.Size(62, 25);
            this.ChatLabel.TabIndex = 0;
            this.ChatLabel.Text = "[表情]";
            this.ChatLabel.Click += new System.EventHandler(this.ChatLabel_Click);
            // 
            // FriendPortrait
            // 
            this.FriendPortrait.BackColor = System.Drawing.Color.White;
            this.FriendPortrait.Image = global::MyChat.Properties.Resources.Leaf1;
            this.FriendPortrait.Location = new System.Drawing.Point(15, 28);
            this.FriendPortrait.Name = "FriendPortrait";
            this.FriendPortrait.Size = new System.Drawing.Size(60, 60);
            this.FriendPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FriendPortrait.TabIndex = 1;
            this.FriendPortrait.TabStop = false;
            // 
            // MyPortrait
            // 
            this.MyPortrait.BackColor = System.Drawing.Color.White;
            this.MyPortrait.Image = global::MyChat.Properties.Resources.秋1;
            this.MyPortrait.Location = new System.Drawing.Point(614, 28);
            this.MyPortrait.Name = "MyPortrait";
            this.MyPortrait.Size = new System.Drawing.Size(60, 60);
            this.MyPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MyPortrait.TabIndex = 2;
            this.MyPortrait.TabStop = false;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeLabel.Location = new System.Drawing.Point(320, 7);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(49, 20);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "10:20";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FriendNameLabel
            // 
            this.FriendNameLabel.AutoSize = true;
            this.FriendNameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FriendNameLabel.Location = new System.Drawing.Point(13, 7);
            this.FriendNameLabel.Name = "FriendNameLabel";
            this.FriendNameLabel.Size = new System.Drawing.Size(99, 20);
            this.FriendNameLabel.TabIndex = 4;
            this.FriendNameLabel.Text = "2016011435";
            // 
            // MyNameLabel
            // 
            this.MyNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyNameLabel.AutoSize = true;
            this.MyNameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNameLabel.Location = new System.Drawing.Point(568, 7);
            this.MyNameLabel.Name = "MyNameLabel";
            this.MyNameLabel.Size = new System.Drawing.Size(99, 20);
            this.MyNameLabel.TabIndex = 5;
            this.MyNameLabel.Text = "2016011481";
            this.MyNameLabel.Click += new System.EventHandler(this.MyNameLabel_Click);
            // 
            // EmojiBox
            // 
            this.EmojiBox.BackColor = System.Drawing.Color.Transparent;
            this.EmojiBox.Image = ((System.Drawing.Image)(resources.GetObject("EmojiBox.Image")));
            this.EmojiBox.Location = new System.Drawing.Point(539, 32);
            this.EmojiBox.Name = "EmojiBox";
            this.EmojiBox.Size = new System.Drawing.Size(50, 50);
            this.EmojiBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EmojiBox.TabIndex = 6;
            this.EmojiBox.TabStop = false;
            this.EmojiBox.Visible = false;
            // 
            // SendBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EmojiBox);
            this.Controls.Add(this.MyNameLabel);
            this.Controls.Add(this.FriendNameLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.MyPortrait);
            this.Controls.Add(this.FriendPortrait);
            this.Controls.Add(this.ChatLabel);
            this.Name = "SendBox";
            this.Size = new System.Drawing.Size(677, 92);
            ((System.ComponentModel.ISupportInitialize)(this.FriendPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmojiBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChatLabel;
        private System.Windows.Forms.PictureBox FriendPortrait;
        private System.Windows.Forms.PictureBox MyPortrait;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label FriendNameLabel;
        private System.Windows.Forms.Label MyNameLabel;
        private System.Windows.Forms.PictureBox EmojiBox;
    }
}
