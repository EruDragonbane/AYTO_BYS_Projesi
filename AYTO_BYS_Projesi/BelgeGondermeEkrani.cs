using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AYTO_BYS_Projesi
{
    public partial class BelgeGondermeEkrani : Form
    {
        public BelgeGondermeEkrani()
        {
            InitializeComponent();
        }
        public BelgeGondermeEkrani(string sendForm_belgeNo, int send_UserId)
        {
            InitializeComponent();
            BelgeNo = sendForm_belgeNo;
            UserId4 = send_UserId;
        }
        public string BelgeNo { get; set; }
        public int UserId4 { get; set; }
        //TextBoxların boş olması durumunda ekle butonu pasif kalmaktadır.
        private void TextControlForButton()
        {
            if (SendFileTitle_CustomTextBox.Text.Trim() != string.Empty && SendFilePerson_CheckComboBox.Text.Trim() != string.Empty && SendFileExplain_CustomTextBox.Text.Trim() != string.Empty)
            {
                SendFile_SendButton.Enabled = true;
            }
            else
            {
                SendFile_SendButton.Enabled = false;
            }
        }
        private void TextGridFromAnaEkran()
        {
            Program.dataBaseConnection.Close();
            string sendFileCmdText = "SELECT blg.belgeDizini, blg.belgeAdi FROM belgelerim AS blg INNER JOIN kullanicilar AS klnc ON blg.kullaniciNo = klnc.kullaniciNo WHERE belgeNo = @belgeNo";
            SqlCommand sendFileCmd = new SqlCommand(sendFileCmdText, Program.dataBaseConnection);
            sendFileCmd.Parameters.AddWithValue("@belgeNo", BelgeNo);
            Program.dataBaseConnection.Open();
            SqlDataReader sendFileReader = sendFileCmd.ExecuteReader();
            if (sendFileReader.Read())
            {
                SendFileName_CustomTextBox.Text = sendFileReader["belgeAdi"].ToString();
                SendFileDirectory_CustomTextBox.Text = sendFileReader["belgeDizini"].ToString();

            }
            sendFileReader.Close();
            Program.dataBaseConnection.Close();
        }
        //CheckComboBox doldurma
        private void CheckComboBoxFillMethod()
        {
            Program.dataBaseConnection.Close();
            string checkComboCmdText = "SELECT klnc.kullaniciAdi, klnc.kullaniciSoyadi FROM kullanicilar AS klnc ORDER BY klnc.kullaniciNo";
            SqlCommand checkComboCmd = new SqlCommand(checkComboCmdText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            SqlDataReader checkComboReader = checkComboCmd.ExecuteReader();
            while (checkComboReader.Read())
            {
                SendFilePerson_CheckComboBox.Items.Add(checkComboReader["kullaniciAdi"] + " " + checkComboReader["kullaniciSoyadi"]);
            }
            checkComboReader.Close();
            Program.dataBaseConnection.Close();
        }

        private void BelgeGondermeEkrani_Load(object sender, EventArgs e)
        {
            //Karakter Sayısı Gizleme
            SendFileExplain_TextLength.Visible = false;
            //Buton Kontrolü
            TextControlForButton();
            MessageBoxManager.Unregister();
            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";
            MessageBoxManager.Register();

            TextGridFromAnaEkran();
            TextGridFromAnaEkran();

            //Checkcombobox içeriği
            CheckComboBoxFillMethod();
            
            MessageBoxManager.Unregister();
        }
        //KeyUp Event-Karakter Sayısı Gösterme
        private void SendFileExplain_CustomTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SendFileExplain_TextLength.Text = Convert.ToString(5000 - SendFileExplain_CustomTextBox.TextLength);
            if (SendFileExplain_TextLength.Text != "5000")
                SendFileExplain_TextLength.Visible = true;
            else
                SendFileExplain_TextLength.Visible = false;
        }

        private void SendFile_SendButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SendFile_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Changed Textboxlara veri girilmesi halinde TextControlForButton metotu çalıştırılır.
        //SendFileTitle, SendFilePerson, SendFileExplain
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextControlForButton();
        }

        //Textboxların hepsi için tek bir keydown eventi
        private void TextBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
