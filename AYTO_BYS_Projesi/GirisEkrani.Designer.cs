namespace AYTO_BYS_Projesi
{
    partial class GirisEkrani
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisEkrani));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginPage_ExitButton = new System.Windows.Forms.Button();
            this.LoginPage_LoginButton = new System.Windows.Forms.Button();
            this.passwordView_CheckBox = new System.Windows.Forms.CheckBox();
            this.LoginPassword_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.LoginId_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AYTO_BYS_Projesi.Properties.Resources.ayto_transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // LoginPage_ExitButton
            // 
            resources.ApplyResources(this.LoginPage_ExitButton, "LoginPage_ExitButton");
            this.LoginPage_ExitButton.Name = "LoginPage_ExitButton";
            this.LoginPage_ExitButton.UseVisualStyleBackColor = true;
            this.LoginPage_ExitButton.Click += new System.EventHandler(this.LoginPage_ExitButton_Click);
            // 
            // LoginPage_LoginButton
            // 
            resources.ApplyResources(this.LoginPage_LoginButton, "LoginPage_LoginButton");
            this.LoginPage_LoginButton.Name = "LoginPage_LoginButton";
            this.LoginPage_LoginButton.UseVisualStyleBackColor = true;
            this.LoginPage_LoginButton.Click += new System.EventHandler(this.LoginPage_LoginButton_Click);
            // 
            // passwordView_CheckBox
            // 
            resources.ApplyResources(this.passwordView_CheckBox, "passwordView_CheckBox");
            this.passwordView_CheckBox.Name = "passwordView_CheckBox";
            this.passwordView_CheckBox.UseVisualStyleBackColor = true;
            this.passwordView_CheckBox.CheckedChanged += new System.EventHandler(this.LoginPassword_CustomTextBox_TextChanged);
            // 
            // LoginPassword_CustomTextBox
            // 
            this.LoginPassword_CustomTextBox.CustomText = "PAROLA";
            this.LoginPassword_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            resources.ApplyResources(this.LoginPassword_CustomTextBox, "LoginPassword_CustomTextBox");
            this.LoginPassword_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.LoginPassword_CustomTextBox.Name = "LoginPassword_CustomTextBox";
            this.LoginPassword_CustomTextBox.TextChanged += new System.EventHandler(this.LoginPassword_CustomTextBox_TextChanged);
            // 
            // LoginId_CustomTextBox
            // 
            this.LoginId_CustomTextBox.CustomText = "KULLANICI";
            this.LoginId_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            resources.ApplyResources(this.LoginId_CustomTextBox, "LoginId_CustomTextBox");
            this.LoginId_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.LoginId_CustomTextBox.Name = "LoginId_CustomTextBox";
            // 
            // GirisEkrani
            // 
            this.AcceptButton = this.LoginPage_LoginButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.passwordView_CheckBox);
            this.Controls.Add(this.LoginPage_LoginButton);
            this.Controls.Add(this.LoginPassword_CustomTextBox);
            this.Controls.Add(this.LoginId_CustomTextBox);
            this.Controls.Add(this.LoginPage_ExitButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GirisEkrani";
            this.Load += new System.EventHandler(this.GirisEkrani_Load);
            this.Enter += new System.EventHandler(this.LoginPage_LoginButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LoginPage_ExitButton;
        private CustomTextBox LoginId_CustomTextBox;
        private CustomTextBox LoginPassword_CustomTextBox;
        private System.Windows.Forms.Button LoginPage_LoginButton;
        private System.Windows.Forms.CheckBox passwordView_CheckBox;
    }
}