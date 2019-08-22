namespace MyChat
{
    partial class LoginWindow
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.setGroup = new System.Windows.Forms.GroupBox();
            this.LoginButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.RememberButton = new System.Windows.Forms.RadioButton();
            this.PasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.NameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.NameText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PortraitBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortraitBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // setGroup
            // 
            this.setGroup.BackColor = System.Drawing.Color.SeaShell;
            this.setGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.setGroup.Controls.Add(this.LoginButton);
            this.setGroup.Controls.Add(this.RememberButton);
            this.setGroup.Controls.Add(this.PasswordLabel);
            this.setGroup.Controls.Add(this.NameLabel);
            this.setGroup.Controls.Add(this.PasswordText);
            this.setGroup.Controls.Add(this.NameText);
            this.setGroup.Location = new System.Drawing.Point(11, 165);
            this.setGroup.Name = "setGroup";
            this.setGroup.Size = new System.Drawing.Size(475, 205);
            this.setGroup.TabIndex = 6;
            this.setGroup.TabStop = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Depth = 0;
            this.LoginButton.Location = new System.Drawing.Point(155, 155);
            this.LoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Primary = true;
            this.LoginButton.Size = new System.Drawing.Size(190, 39);
            this.LoginButton.TabIndex = 12;
            this.LoginButton.Text = "Log In";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RememberButton
            // 
            this.RememberButton.AutoSize = true;
            this.RememberButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RememberButton.ForeColor = System.Drawing.Color.Salmon;
            this.RememberButton.Location = new System.Drawing.Point(59, 110);
            this.RememberButton.Name = "RememberButton";
            this.RememberButton.Size = new System.Drawing.Size(234, 24);
            this.RememberButton.TabIndex = 10;
            this.RememberButton.TabStop = true;
            this.RememberButton.Text = "Remember me next time :）";
            this.RememberButton.UseVisualStyleBackColor = true;
            this.RememberButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Depth = 0;
            this.PasswordLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PasswordLabel.Location = new System.Drawing.Point(55, 72);
            this.PasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(102, 24);
            this.PasswordLabel.TabIndex = 8;
            this.PasswordLabel.Text = "PassWord:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Depth = 0;
            this.NameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NameLabel.Location = new System.Drawing.Point(55, 28);
            this.NameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(104, 24);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "UserName:";
            // 
            // PasswordText
            // 
            this.PasswordText.Depth = 0;
            this.PasswordText.ForeColor = System.Drawing.Color.DarkGray;
            this.PasswordText.Hint = "";
            this.PasswordText.Location = new System.Drawing.Point(194, 72);
            this.PasswordText.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.PasswordChar = '*';
            this.PasswordText.SelectedText = "";
            this.PasswordText.SelectionLength = 0;
            this.PasswordText.SelectionStart = 0;
            this.PasswordText.Size = new System.Drawing.Size(206, 28);
            this.PasswordText.TabIndex = 1;
            this.PasswordText.Text = "net2018";
            this.PasswordText.UseSystemPasswordChar = false;
            this.PasswordText.Click += new System.EventHandler(this.heightText_Click);
            // 
            // NameText
            // 
            this.NameText.Depth = 0;
            this.NameText.ForeColor = System.Drawing.Color.DarkGray;
            this.NameText.Hint = "";
            this.NameText.Location = new System.Drawing.Point(194, 24);
            this.NameText.MouseState = MaterialSkin.MouseState.HOVER;
            this.NameText.Name = "NameText";
            this.NameText.PasswordChar = '\0';
            this.NameText.SelectedText = "";
            this.NameText.SelectionLength = 0;
            this.NameText.SelectionStart = 0;
            this.NameText.Size = new System.Drawing.Size(206, 28);
            this.NameText.TabIndex = 0;
            this.NameText.Text = "2016011481";
            this.NameText.UseSystemPasswordChar = false;
            this.NameText.Click += new System.EventHandler(this.widthText_Click);
            // 
            // PortraitBox
            // 
            this.PortraitBox.Image = global::MyChat.Properties.Resources.秋1;
            this.PortraitBox.Location = new System.Drawing.Point(186, 25);
            this.PortraitBox.Name = "PortraitBox";
            this.PortraitBox.Size = new System.Drawing.Size(128, 128);
            this.PortraitBox.TabIndex = 7;
            this.PortraitBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::MyChat.Properties.Resources.睡莲;
            this.panel1.Controls.Add(this.PortraitBox);
            this.panel1.Controls.Add(this.setGroup);
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 385);
            this.panel1.TabIndex = 8;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyChat.Properties.Resources.睡莲;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to MyChat!";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            this.setGroup.ResumeLayout(false);
            this.setGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortraitBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox setGroup;
        private System.Windows.Forms.RadioButton RememberButton;
        private MaterialSkin.Controls.MaterialLabel PasswordLabel;
        private MaterialSkin.Controls.MaterialLabel NameLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordText;
        private MaterialSkin.Controls.MaterialSingleLineTextField NameText;
        private System.Windows.Forms.PictureBox PortraitBox;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRaisedButton LoginButton;
    }
}

