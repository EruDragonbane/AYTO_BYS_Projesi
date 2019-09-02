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
using AYTO.SendFile;
using System.Net;
using System.Net.Sockets;

namespace AYTO_BYS_Projesi
{
    public partial class BelgeGondermeEkrani : Form
    {
        private static Socket socketForSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int PORT = 52000;

        SendFileDLL sendFileDLL = new SendFileDLL();

        public BelgeGondermeEkrani(string sendForm_belgeNo, int send_UserId)
        {
            InitializeComponent();
            BelgeNo = sendForm_belgeNo;
            UserId4 = send_UserId;
        }
        public string BelgeNo { get; set; }
        public int UserId4 { get; set; }

        public delegate void SentFileDataEventHandler();
        public event SentFileDataEventHandler SentFileDataEventH;
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
        //CheckComboBox doldurma
        private void CheckComboBoxFillMethod()
        {
            int rowValue = 0;

            Program.dataBaseConnection.Close();
            string checkComboCmdText = "SELECT klnc.kullaniciGiris, klnc.kullaniciAdi, klnc.kullaniciSoyadi FROM kullanicilar AS klnc WHERE klnc.silinmeDurumu = 'True' ORDER BY klnc.kullaniciNo";
            using (SqlCommand checkComboCmd = new SqlCommand(checkComboCmdText, Program.dataBaseConnection))
            {
                Program.dataBaseConnection.Open();
                using (SqlDataReader checkComboReader = checkComboCmd.ExecuteReader())
                {
                    while (checkComboReader.Read())
                    {
                        SendFilePerson_CheckComboBox.Items.Add(checkComboReader["kullaniciAdi"] + " " + checkComboReader["kullaniciSoyadi"] + "(" + checkComboReader["kullaniciGiris"] + ")");
                    }
                    rowValue++;
                }
            }
            Program.dataBaseConnection.Close();
        }
        //Kullanıcının Anahtar değerini çeker
        private void FindCheckedUsersNoAndInsertToTable()
        {
            string inboxFileTitle = SendFileTitle_CustomTextBox.Text.Trim();
            string inboxFileExplain = SendFileExplain_CustomTextBox.Text.Trim();
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            //Seçili kullanıcıların isimleri
            string[] splitText = SendFilePerson_CheckComboBox.Text.Split(',');
            //Kullanıcıların Id değerlerinin toplanacağı dizi
            string[] usersWithId = new string[splitText.Length];
            //Seçili kullanıcıların Idlerini ( ) arasından çıkarır
            for (int i = 0; i < splitText.Length; i++)
            {
                int firstIndex = splitText[i].IndexOf("(") + "(".Length;
                int lastIndex = splitText[i].LastIndexOf(")");
                usersWithId[i] = splitText[i].Substring(firstIndex, lastIndex - firstIndex);
            }
            //Seçili kullanıcıların anahtar verilerinin depolanacağı Dizi
            string[] usersNoArray = new string[splitText.Length];

            string usersNoCmdText = "SELECT klnc.kullaniciNo FROM kullanicilar AS klnc WHERE klnc.kullaniciGiris = @gonderilenKisi";
            for (int j = 0; j < splitText.Length; j++)
            {
                using (SqlCommand usersNoCmd = new SqlCommand(usersNoCmdText, Program.dataBaseConnection))
                {
                    //usersNoCmd.Parameters.Clear();
                    usersNoCmd.Parameters.AddWithValue("@gonderilenKisi", usersWithId[j]);
                    Program.dataBaseConnection.Open();
                    using (SqlDataReader usersNoReader = usersNoCmd.ExecuteReader())
                    {
                        if (usersNoReader.Read())
                        {
                            usersNoArray[j] = usersNoReader["kullaniciNo"].ToString();
                        }
                    }
                }
                Program.dataBaseConnection.Close();
            }
            //Verilerin kaydedilmesi
            if(usersNoArray != null && usersNoArray.Length != 0)
            {
                for(int k = 0; k<usersNoArray.Length; k++)
                {
                    sendFileDLL.InsertTheValuesToTableForSend(BelgeNo, UserId4, usersNoArray[k]);
                    sendFileDLL.InsertTheValuesToTableForInbox(BelgeNo, usersNoArray[k], UserId4, inboxFileTitle, inboxFileExplain);
                }
                MessageBox.Show("Belge gönderildi.");
                this.Close();
            }
            MessageBoxManager.Unregister();
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

            var textGridTuple = sendFileDLL.TextGridFromMainPage(BelgeNo);
            SendFileName_CustomTextBox.Text = textGridTuple.Item1;
            SendFileDirectory_CustomTextBox.Text = textGridTuple.Item2; 

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
            FindCheckedUsersNoAndInsertToTable();

            //try
            //{
            //    socketForSend.Connect(new IPEndPoint(IPAddress.Parse("192.168.244.128"), PORT));
            //    Console.WriteLine("Bağlantı Tamam");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //while(true && socketForSend.Connected)
            //{
            //    string fileWithFormat = sendFileDLL.FileNameWithFormat(BelgeNo);
            //    string sendFilePath = Program.serverFilePath + fileWithFormat;
            //    socketForSend.Send(Encoding.UTF8.GetBytes(sendFilePath));
            //}
            //Console.WriteLine("Bir tuşa basın");
            //Console.Read();
            //this.Close();
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
