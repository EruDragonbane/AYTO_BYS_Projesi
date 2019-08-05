using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AYTO.UserProfile;

namespace AYTO_BYS_Projesi
{
    public partial class KullaniciProfili : Form
    {
        UserProfileDLL userProfileDLL = new UserProfileDLL();
        //Şifre eylemini gerçekleştirdiğimiz textboxların görünürlük ve aktifliği için kullanılan bir değişkendir.
        private int showDialogValue = 0;
        public KullaniciProfili()
        {
            InitializeComponent();            
        }
        public KullaniciProfili(int UserIdOtherForm)
        {
            InitializeComponent();
            UserId6 = UserIdOtherForm;
        }
        public int UserId6 { get; set; }
        //PictureBox içine butonu ekler.
        private void ChangePictureEvent()
        {
            UserProfile_UserPictureBox.Controls.Add(ChangePictureButton);
            ChangePictureButton.Width = 100;
            ChangePictureButton.Height = 100;
            ChangePictureButton.Location = new Point(50, 50);
            ChangePictureButton.BackColor = Color.Transparent;
            ChangePictureButton.FlatStyle = FlatStyle.Flat;
            ChangePictureButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ChangePictureButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ChangePictureButton.FlatAppearance.BorderSize = 0;
            ChangePictureButton.Cursor = Cursors.Hand;
        }
        //Şifre göster/gizle
        private void PasswordTextChangedEvent()
        {
            UserProfile_CurrentPassword_CustomTextbox.ForeColor = Color.Black;
            UserProfile_NewPassword_CustomTextBox.ForeColor = Color.Black;
            UserProfile_ConfirmNewPassword_CustomTextBox.ForeColor = Color.Black;

            if (UserProfile_ShowPassword_CheckBox.Checked)
            {
                UserProfile_CurrentPassword_CustomTextbox.PasswordChar = '\0';
                UserProfile_NewPassword_CustomTextBox.PasswordChar = '\0';
                UserProfile_ConfirmNewPassword_CustomTextBox.PasswordChar = '\0';
            }
            else
            {
                UserProfile_CurrentPassword_CustomTextbox.PasswordChar = '*';
                UserProfile_NewPassword_CustomTextBox.PasswordChar = '*';
                UserProfile_ConfirmNewPassword_CustomTextBox.PasswordChar = '*';
            }
        }
        //Şifre textboxlarının görünürlük-eylem aktifliği değiştirme
        private void PasswordTextBoxEnabledAndVisible(bool boolValue)
        {
            UserProfile_CurrentPassword_CustomTextbox.Enabled = boolValue;
            UserProfile_CurrentPassword_CustomTextbox.Visible = boolValue;
            UserProfile_NewPassword_CustomTextBox.Enabled = boolValue;
            UserProfile_NewPassword_CustomTextBox.Visible = boolValue;
            UserProfile_ConfirmNewPassword_CustomTextBox.Enabled = boolValue;
            UserProfile_ConfirmNewPassword_CustomTextBox.Visible = boolValue;
            UserProfile_ShowPassword_CheckBox.Enabled = boolValue;
            UserProfile_ShowPassword_CheckBox.Visible = boolValue;
            ChangePictureButton.Enabled = boolValue;
            ChangePictureButton.Visible = boolValue;

        }
        //Başarılı bir şifre değiştirme sonrası yapılacaklar
        private void AfterChangedPassword()
        {
            PasswordTextBoxEnabledAndVisible(false);
            UserProfile_UserPictureBox.Controls.Remove(ChangePictureButton);
            UserProfile_CurrentPassword_CustomTextbox.ForeColor = Color.Black;
            UserProfile_NewPassword_CustomTextBox.ForeColor = Color.Black;
            UserProfile_ConfirmNewPassword_CustomTextBox.ForeColor = Color.Black;
            showDialogValue = 0;
        }
        //Enter tuşu Textboxlar üzerinde pasif
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        //Kullanıcının bilgilerini çeker.
        private void InformationAboutUser()
        {
            //Item1 = userNameSurname, Item2 = userCorp, Item3 = userPosition
            var infoAboutUserTuple = userProfileDLL.InformationAbourtUser(UserId6);
            UserProfile_UserNameSurnameLabel.Text = infoAboutUserTuple.Item1;
            UserProfile_UserCorpLabel.Text = infoAboutUserTuple.Item2;
            UserProfile_UserPositionLabel.Text = infoAboutUserTuple.Item3;
        }

        private void KullaniciProfili_Load(object sender, EventArgs e)
        {
            InformationAboutUser();
            PasswordTextBoxEnabledAndVisible(false);
            //UserProfile_UserPictureBox.Enabled = false;
        }

        private void ChangePictureButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("yoaoaoao");
        }

        private void UserProfile_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void USerProfile_UpdateButton_Click(object sender, EventArgs e)
        {
            string currentPassword = UserProfile_CurrentPassword_CustomTextbox.Text.Trim();
            string newPassword = UserProfile_NewPassword_CustomTextBox.Text.Trim();
            string confirmPassword = UserProfile_ConfirmNewPassword_CustomTextBox.Text.Trim();
            if (showDialogValue == 0)
            {
                PasswordTextBoxEnabledAndVisible(true);
                ChangePictureEvent();
                showDialogValue = 1;
            }
            else
            {
                if (!string.IsNullOrEmpty(currentPassword) && !string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(confirmPassword))
                {
                    string returnValue = userProfileDLL.CheckPasswordBeforeChange(currentPassword, UserId6);
                    if (returnValue == "false")
                    {
                        UserProfile_CurrentPassword_CustomTextbox.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (newPassword == confirmPassword)
                        {
                            String messageCheckFile = "Güncellemek istiyor musunuz?";
                            String titleCheckFile = "";
                            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
                            DialogResult yesNoResult = MessageBox.Show(messageCheckFile, titleCheckFile, yesNoButtons);
                            if (yesNoResult == DialogResult.Yes)
                            {
                                userProfileDLL.ChangePassword(UserId6, newPassword);
                                AfterChangedPassword();
                                this.Close();
                            }
                        }
                        else
                        {
                            UserProfile_NewPassword_CustomTextBox.ForeColor = Color.Red;
                            UserProfile_ConfirmNewPassword_CustomTextBox.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Boş kısım olamaz!");
                } 
            }
        }
        //TextChanged
        private void UserProfile_CurrentPassword_CustomTextbox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextChangedEvent();
        }
        private void UserProfile_NewPassword_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextChangedEvent();
        }
        private void UserProfile_ConfirmNewPassword_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextChangedEvent();
        }
        private void UserProfile_ShowPassword_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextChangedEvent();
        }
        //TextChanged
    }
}
