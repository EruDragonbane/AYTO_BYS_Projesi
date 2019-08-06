using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AYTO.Login;
using AYTO.Log;

namespace AYTO_BYS_Projesi
{
    public partial class GirisEkrani : Form
    {
        LoginDLL loginDLL = new LoginDLL();
        LogDLL logDLL = new LogDLL();

        public GirisEkrani()
        {
            InitializeComponent();
        }
        //Şifrenin görünürlüğü
        private void LoginPassword_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordView_CheckBox.Checked)
            {
                LoginPassword_CustomTextBox.PasswordChar = '\0';
            }
            else
            {
                LoginPassword_CustomTextBox.PasswordChar = '*';
            }
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //Path C:\Users\Fatih\Desktop\AYTOProjesiSQL\AYTO_BYS_Projesi\AYTO_BYS_Projesi\Images\ayto_transparent.png"
            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";
        }

        private void LoginPage_ExitButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            DialogResult exitDialog = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (exitDialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            MessageBoxManager.Unregister();
        }

        private void LoginPage_LoginButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            //Item1 = returnValue, Item2 = kullaniciNo, Item3 = userAuthority, Item4 = kullaniciAdi, Item5 = kullaniciSoyadi
            //Item3, Item4 ve Item5 LoginLog'da kullanılmaktadır.
            //Item2 hem GirisEkrani hem de LoginLog'da kullanılmaktadır.
            var returnTuple = loginDLL.LoginPage_LoginButton(LoginId_CustomTextBox.Text.Trim(), LoginPassword_CustomTextBox.Text.Trim());
            if(returnTuple.Item1 == "yetkili")
            {
                AdminPanel adminFormLogin = new AdminPanel(returnTuple.Item2);
                pictureBox1.Image.Dispose();
                this.Hide();
                adminFormLogin.Show();
                logDLL.LoginLog(returnTuple.Item2, returnTuple.Item3, returnTuple.Item4, returnTuple.Item5);
            }
            else if(returnTuple.Item1 == "kullanici")
            {
                AnaEkran mainFormLogin = new AnaEkran(Convert.ToInt32(returnTuple.Item2));
                pictureBox1.Image.Dispose();
                this.Hide();
                mainFormLogin.Show();
                logDLL.LoginLog(returnTuple.Item2, returnTuple.Item3, returnTuple.Item4, returnTuple.Item5);
            }
            else if (returnTuple.Item1 == "inactive")
            {
                MessageBox.Show("Hesabınız askıya alındı. Giriş yapamazsınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logDLL.LoginLog(returnTuple.Item2, returnTuple.Item3, returnTuple.Item4, returnTuple.Item5);
            }
            else if(returnTuple.Item1 == "wrongIdOrPassword")
            {
                MessageBox.Show("Kullanıcı adı veya parolanız yanlış!");
            }
            else if(returnTuple.Item1 == "nullValue")
            {
                MessageBox.Show("Boş kısım olamaz!");
            }
            else
            {
                MessageBox.Show("Hata: GirisEkrani - LoginButton");
            }

            MessageBoxManager.Unregister();
        }
    }
}