namespace AYTO_BYS_Projesi
{
    partial class KullaniciProfili
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciProfili));
            this.UserProfile_UserPictureBox = new System.Windows.Forms.PictureBox();
            this.ChangePictureButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.UserProfile_UserNameSurnameLabel = new System.Windows.Forms.Label();
            this.UserProfile_UserCorpLabel = new System.Windows.Forms.Label();
            this.UserProfile_UserPositionLabel = new System.Windows.Forms.Label();
            this.USerProfile_UpdateButton = new System.Windows.Forms.Button();
            this.UserProfile_CancelButton = new System.Windows.Forms.Button();
            this.UserProfile_ShowPassword_CheckBox = new System.Windows.Forms.CheckBox();
            this.UserProfile_ConfirmNewPassword_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.UserProfile_NewPassword_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.UserProfile_CurrentPassword_CustomTextbox = new AYTO_BYS_Projesi.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfile_UserPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UserProfile_UserPictureBox
            // 
            this.UserProfile_UserPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("UserProfile_UserPictureBox.Image")));
            this.UserProfile_UserPictureBox.Location = new System.Drawing.Point(12, 12);
            this.UserProfile_UserPictureBox.MaximumSize = new System.Drawing.Size(200, 200);
            this.UserProfile_UserPictureBox.MinimumSize = new System.Drawing.Size(200, 200);
            this.UserProfile_UserPictureBox.Name = "UserProfile_UserPictureBox";
            this.UserProfile_UserPictureBox.Size = new System.Drawing.Size(200, 200);
            this.UserProfile_UserPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserProfile_UserPictureBox.TabIndex = 2;
            this.UserProfile_UserPictureBox.TabStop = false;
            // 
            // ChangePictureButton
            // 
            this.ChangePictureButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChangePictureButton.BackgroundImage")));
            this.ChangePictureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChangePictureButton.Location = new System.Drawing.Point(12, 162);
            this.ChangePictureButton.MaximumSize = new System.Drawing.Size(100, 100);
            this.ChangePictureButton.Name = "ChangePictureButton";
            this.ChangePictureButton.Size = new System.Drawing.Size(50, 50);
            this.ChangePictureButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.ChangePictureButton, "Profil resminizi değiştirmek için tıklayın.");
            this.ChangePictureButton.UseVisualStyleBackColor = true;
            this.ChangePictureButton.Click += new System.EventHandler(this.ChangePictureButton_Click);
            // 
            // UserProfile_UserNameSurnameLabel
            // 
            this.UserProfile_UserNameSurnameLabel.AutoSize = true;
            this.UserProfile_UserNameSurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_UserNameSurnameLabel.Location = new System.Drawing.Point(218, 12);
            this.UserProfile_UserNameSurnameLabel.Name = "UserProfile_UserNameSurnameLabel";
            this.UserProfile_UserNameSurnameLabel.Size = new System.Drawing.Size(95, 20);
            this.UserProfile_UserNameSurnameLabel.TabIndex = 4;
            this.UserProfile_UserNameSurnameLabel.Text = "Fatih Akkurt";
            // 
            // UserProfile_UserCorpLabel
            // 
            this.UserProfile_UserCorpLabel.AutoSize = true;
            this.UserProfile_UserCorpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_UserCorpLabel.Location = new System.Drawing.Point(219, 42);
            this.UserProfile_UserCorpLabel.Name = "UserProfile_UserCorpLabel";
            this.UserProfile_UserCorpLabel.Size = new System.Drawing.Size(64, 20);
            this.UserProfile_UserCorpLabel.TabIndex = 5;
            this.UserProfile_UserCorpLabel.Text = "Kurumu";
            // 
            // UserProfile_UserPositionLabel
            // 
            this.UserProfile_UserPositionLabel.AutoSize = true;
            this.UserProfile_UserPositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_UserPositionLabel.Location = new System.Drawing.Point(218, 72);
            this.UserProfile_UserPositionLabel.Name = "UserProfile_UserPositionLabel";
            this.UserProfile_UserPositionLabel.Size = new System.Drawing.Size(55, 20);
            this.UserProfile_UserPositionLabel.TabIndex = 6;
            this.UserProfile_UserPositionLabel.Text = "Görevi";
            // 
            // USerProfile_UpdateButton
            // 
            this.USerProfile_UpdateButton.Location = new System.Drawing.Point(218, 218);
            this.USerProfile_UpdateButton.MaximumSize = new System.Drawing.Size(75, 30);
            this.USerProfile_UpdateButton.MinimumSize = new System.Drawing.Size(75, 30);
            this.USerProfile_UpdateButton.Name = "USerProfile_UpdateButton";
            this.USerProfile_UpdateButton.Size = new System.Drawing.Size(75, 30);
            this.USerProfile_UpdateButton.TabIndex = 10;
            this.USerProfile_UpdateButton.Text = "Güncelle";
            this.USerProfile_UpdateButton.UseVisualStyleBackColor = true;
            this.USerProfile_UpdateButton.Click += new System.EventHandler(this.USerProfile_UpdateButton_Click);
            // 
            // UserProfile_CancelButton
            // 
            this.UserProfile_CancelButton.Location = new System.Drawing.Point(293, 218);
            this.UserProfile_CancelButton.MaximumSize = new System.Drawing.Size(75, 30);
            this.UserProfile_CancelButton.MinimumSize = new System.Drawing.Size(75, 30);
            this.UserProfile_CancelButton.Name = "UserProfile_CancelButton";
            this.UserProfile_CancelButton.Size = new System.Drawing.Size(75, 30);
            this.UserProfile_CancelButton.TabIndex = 11;
            this.UserProfile_CancelButton.Text = "İptal Et";
            this.UserProfile_CancelButton.UseVisualStyleBackColor = true;
            this.UserProfile_CancelButton.Click += new System.EventHandler(this.UserProfile_CancelButton_Click);
            // 
            // UserProfile_ShowPassword_CheckBox
            // 
            this.UserProfile_ShowPassword_CheckBox.AutoSize = true;
            this.UserProfile_ShowPassword_CheckBox.Location = new System.Drawing.Point(218, 195);
            this.UserProfile_ShowPassword_CheckBox.Name = "UserProfile_ShowPassword_CheckBox";
            this.UserProfile_ShowPassword_CheckBox.Size = new System.Drawing.Size(86, 17);
            this.UserProfile_ShowPassword_CheckBox.TabIndex = 12;
            this.UserProfile_ShowPassword_CheckBox.Text = "Şifreyi göster";
            this.UserProfile_ShowPassword_CheckBox.UseVisualStyleBackColor = true;
            this.UserProfile_ShowPassword_CheckBox.CheckedChanged += new System.EventHandler(this.UserProfile_ShowPassword_CheckBox_CheckedChanged);
            // 
            // UserProfile_ConfirmNewPassword_CustomTextBox
            // 
            this.UserProfile_ConfirmNewPassword_CustomTextBox.CustomText = "Yeni Şifre (Tekrar)";
            this.UserProfile_ConfirmNewPassword_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_ConfirmNewPassword_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_ConfirmNewPassword_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UserProfile_ConfirmNewPassword_CustomTextBox.Location = new System.Drawing.Point(218, 166);
            this.UserProfile_ConfirmNewPassword_CustomTextBox.MaximumSize = new System.Drawing.Size(150, 25);
            this.UserProfile_ConfirmNewPassword_CustomTextBox.MaxLength = 25;
            this.UserProfile_ConfirmNewPassword_CustomTextBox.MinimumSize = new System.Drawing.Size(150, 25);
            this.UserProfile_ConfirmNewPassword_CustomTextBox.Multiline = true;
            this.UserProfile_ConfirmNewPassword_CustomTextBox.Name = "UserProfile_ConfirmNewPassword_CustomTextBox";
            this.UserProfile_ConfirmNewPassword_CustomTextBox.Size = new System.Drawing.Size(150, 25);
            this.UserProfile_ConfirmNewPassword_CustomTextBox.TabIndex = 8;
            this.UserProfile_ConfirmNewPassword_CustomTextBox.TextChanged += new System.EventHandler(this.UserProfile_ConfirmNewPassword_CustomTextBox_TextChanged);
            this.UserProfile_ConfirmNewPassword_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            // 
            // UserProfile_NewPassword_CustomTextBox
            // 
            this.UserProfile_NewPassword_CustomTextBox.CustomText = "Yeni Şifre";
            this.UserProfile_NewPassword_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_NewPassword_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_NewPassword_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UserProfile_NewPassword_CustomTextBox.Location = new System.Drawing.Point(218, 135);
            this.UserProfile_NewPassword_CustomTextBox.MaximumSize = new System.Drawing.Size(150, 25);
            this.UserProfile_NewPassword_CustomTextBox.MaxLength = 25;
            this.UserProfile_NewPassword_CustomTextBox.MinimumSize = new System.Drawing.Size(150, 25);
            this.UserProfile_NewPassword_CustomTextBox.Multiline = true;
            this.UserProfile_NewPassword_CustomTextBox.Name = "UserProfile_NewPassword_CustomTextBox";
            this.UserProfile_NewPassword_CustomTextBox.Size = new System.Drawing.Size(150, 25);
            this.UserProfile_NewPassword_CustomTextBox.TabIndex = 7;
            this.UserProfile_NewPassword_CustomTextBox.TextChanged += new System.EventHandler(this.UserProfile_NewPassword_CustomTextBox_TextChanged);
            this.UserProfile_NewPassword_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            // 
            // UserProfile_CurrentPassword_CustomTextbox
            // 
            this.UserProfile_CurrentPassword_CustomTextbox.CustomText = "Mevcut Şifre";
            this.UserProfile_CurrentPassword_CustomTextbox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_CurrentPassword_CustomTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserProfile_CurrentPassword_CustomTextbox.ForeColor = System.Drawing.Color.Black;
            this.UserProfile_CurrentPassword_CustomTextbox.Location = new System.Drawing.Point(218, 104);
            this.UserProfile_CurrentPassword_CustomTextbox.MaximumSize = new System.Drawing.Size(150, 25);
            this.UserProfile_CurrentPassword_CustomTextbox.MaxLength = 25;
            this.UserProfile_CurrentPassword_CustomTextbox.MinimumSize = new System.Drawing.Size(150, 25);
            this.UserProfile_CurrentPassword_CustomTextbox.Multiline = true;
            this.UserProfile_CurrentPassword_CustomTextbox.Name = "UserProfile_CurrentPassword_CustomTextbox";
            this.UserProfile_CurrentPassword_CustomTextbox.Size = new System.Drawing.Size(150, 25);
            this.UserProfile_CurrentPassword_CustomTextbox.TabIndex = 1;
            this.UserProfile_CurrentPassword_CustomTextbox.TextChanged += new System.EventHandler(this.UserProfile_CurrentPassword_CustomTextbox_TextChanged);
            this.UserProfile_CurrentPassword_CustomTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            // 
            // KullaniciProfili
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.UserProfile_ShowPassword_CheckBox);
            this.Controls.Add(this.UserProfile_CancelButton);
            this.Controls.Add(this.USerProfile_UpdateButton);
            this.Controls.Add(this.UserProfile_ConfirmNewPassword_CustomTextBox);
            this.Controls.Add(this.UserProfile_NewPassword_CustomTextBox);
            this.Controls.Add(this.UserProfile_UserPositionLabel);
            this.Controls.Add(this.UserProfile_UserCorpLabel);
            this.Controls.Add(this.UserProfile_UserNameSurnameLabel);
            this.Controls.Add(this.ChangePictureButton);
            this.Controls.Add(this.UserProfile_UserPictureBox);
            this.Controls.Add(this.UserProfile_CurrentPassword_CustomTextbox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "KullaniciProfili";
            this.Text = "KullaniciProfili";
            this.Load += new System.EventHandler(this.KullaniciProfili_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserProfile_UserPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomTextBox UserProfile_CurrentPassword_CustomTextbox;
        private System.Windows.Forms.PictureBox UserProfile_UserPictureBox;
        private System.Windows.Forms.Button ChangePictureButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label UserProfile_UserNameSurnameLabel;
        private System.Windows.Forms.Label UserProfile_UserCorpLabel;
        private System.Windows.Forms.Label UserProfile_UserPositionLabel;
        private CustomTextBox UserProfile_NewPassword_CustomTextBox;
        private CustomTextBox UserProfile_ConfirmNewPassword_CustomTextBox;
        private System.Windows.Forms.Button USerProfile_UpdateButton;
        private System.Windows.Forms.Button UserProfile_CancelButton;
        private System.Windows.Forms.CheckBox UserProfile_ShowPassword_CheckBox;
    }
}