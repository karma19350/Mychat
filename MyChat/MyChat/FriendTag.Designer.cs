namespace MyChat
{
    partial class FriendTag
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendTag));
            this.NameLabel = new System.Windows.Forms.Label();
            this.TextLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.Portrait = new System.Windows.Forms.PictureBox();
            this.PortraitList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.Linen;
            this.NameLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NameLabel.Location = new System.Drawing.Point(110, 20);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(122, 25);
            this.NameLabel.TabIndex = 14;
            this.NameLabel.Text = "2016011435";
            this.NameLabel.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.BackColor = System.Drawing.Color.SeaShell;
            this.TextLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextLabel.Location = new System.Drawing.Point(110, 50);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(139, 20);
            this.TextLabel.TabIndex = 15;
            this.TextLabel.Text = "[您有新的未读消息]\r\n";
            this.TextLabel.Click += new System.EventHandler(this.TextLabel_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeLabel.Location = new System.Drawing.Point(255, 5);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(49, 20);
            this.TimeLabel.TabIndex = 16;
            this.TimeLabel.Text = "10:20";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Portrait
            // 
            this.Portrait.BackColor = System.Drawing.Color.White;
            this.Portrait.Image = global::MyChat.Properties.Resources.Leaf1;
            this.Portrait.Location = new System.Drawing.Point(20, 15);
            this.Portrait.Name = "Portrait";
            this.Portrait.Size = new System.Drawing.Size(60, 60);
            this.Portrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Portrait.TabIndex = 6;
            this.Portrait.TabStop = false;
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
            // FriendTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Portrait);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendTag";
            this.Size = new System.Drawing.Size(311, 90);
            this.Click += new System.EventHandler(this.FriendTag_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Portrait;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.ImageList PortraitList;
    }
}
