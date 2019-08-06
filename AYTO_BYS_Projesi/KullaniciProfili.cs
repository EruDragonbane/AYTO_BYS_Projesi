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
using System.IO;

namespace AYTO_BYS_Projesi
{
    public partial class KullaniciProfili : Form
    {
        UserProfileDLL userProfileDLL = new UserProfileDLL();
        //Şifre eylemini gerçekleştirdiğimiz textboxların görünürlük ve aktifliği için kullanılan bir değişkendir.
        private int showDialogValue = 0;
        private string imageLocation = "";
        public KullaniciProfili(int UserIdOtherForm)
        {
            InitializeComponent();
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
            UserId6 = UserIdOtherForm;
        }
        public int UserId6 { get; set; }
        //Gereksiz işlemleri atmak
        private void DisposeEvent()
        {
            if (UserProfile_UserPictureBox.Image != null)
                UserProfile_UserPictureBox.Image.Dispose();
            if (ChangePictureButton.BackgroundImage != null)
                ChangePictureButton.BackgroundImage.Dispose();
        }
        //Şifre textboxlarının görünürlük-eylem aktifliği değiştirme
        private void PasswordTextBoxEnabledAndVisible(bool boolValue)
        {
            foreach(Control item in this.Controls)
            {
                if(item is CustomTextBox)
                {
                    CustomTextBox txtBox = (CustomTextBox)item;
                    txtBox.Enabled = boolValue;
                    txtBox.Visible = boolValue;
                }
            }
            UserProfile_ShowPassword_CheckBox.Enabled = boolValue;
            UserProfile_ShowPassword_CheckBox.Visible = boolValue;
            ChangePictureButton.Enabled = boolValue;
            ChangePictureButton.Visible = boolValue;

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
        //Kaydetme Öncesi kullanıcının istekleri kontrol edilir.
        private void UpdateWithPassword()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            string currentPassword = UserProfile_CurrentPassword_CustomTextbox.Text.Trim();
            string newPassword = UserProfile_NewPassword_CustomTextBox.Text.Trim();
            string confirmPassword = UserProfile_ConfirmNewPassword_CustomTextBox.Text.Trim();

            if (showDialogValue == 0)
            {
                PasswordTextBoxEnabledAndVisible(true);
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
                            UpdateProfile(newPassword);
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
            MessageBoxManager.Unregister();
        }
                        
        //Kaydetme
        private void UpdateProfile(string newPasword)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            String messageCheckFile = "Güncellemek istiyor musunuz?";
            String titleCheckFile = "";
            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
            DialogResult yesNoResult = MessageBox.Show(messageCheckFile, titleCheckFile, yesNoButtons);
            if (yesNoResult == DialogResult.Yes)
            {
                //userProfileDLL.ChangePassword(UserId6, newPassword);
                UpdateImage();
                //this.Close();
            }
            MessageBoxManager.Unregister();
        }
        //Resmi Kaydetme
        private void UpdateImage()
        {
            //Item4 = kullaniciNo 
            var userNameSurnameTuple = userProfileDLL.InformationAbourtUser(UserId6);
            //Dosyayı servere kullanıcının adı-soyadı ile kaydeder.
            string serverPath = @"C:\Users\Fatih\Desktop\ServerDosyaOrnegi\KullaniciResimleri\" + userNameSurnameTuple.Item4 + ".jpg";
            FileStream fileStream = File.OpenRead(imageLocation);
            byte[] contents = new byte[fileStream.Length];
            fileStream.Read(contents, 0, (int)fileStream.Length);
            fileStream.Close();
            File.WriteAllBytes(serverPath, contents);
        }
        private void KullaniciProfili_Load(object sender, EventArgs e)
        {
            InformationAboutUser();
            PasswordTextBoxEnabledAndVisible(false);
            //UserProfile_UserPictureBox.Enabled = false;
        }

        private void ChangePictureButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            OpenFileDialog images = new OpenFileDialog();
            //Yeni dosya formatları eklemek için
            //" Format İsmi |*.formattürü " şeklinde ekle
            images.Filter = "Görüntü Dosyaları |*.jpg;*.jpeg;*.bmp;*.wmf;*.png|" +
                "Tüm Dosyalar |*.*";
            images.RestoreDirectory = true;
            if (images.ShowDialog() == DialogResult.OK)
            {
                imageLocation = images.FileName;
                FileInfo fileInfo = new FileInfo(imageLocation);

                if (fileInfo.Length < (Math.Pow(10, 6)))
                {
                    UserProfile_UserPictureBox.Text = imageLocation;
                    UserProfile_UserPictureBox.ImageLocation = imageLocation;
                }
                else
                {
                    MessageBox.Show("Resmin boyutu 1MB'den büyüktür.");
                }
            }
        }

        private void UserProfile_CancelButton_Click(object sender, EventArgs e)
        {
            UserProfile_UserPictureBox.Controls.Remove(ChangePictureButton);
            DisposeEvent();
            this.Close();
        }

        private void UserProfile_UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateWithPassword();
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
        //Şifre göster/gizle //TextChanged CheckedChanged
        private void PasswordTextChangedEvent(object sender, EventArgs e)
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
    }
}
