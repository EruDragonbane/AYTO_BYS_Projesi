using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using AYTO.UpdateFile;

namespace AYTO_BYS_Projesi
{
    public partial class BelgeGuncellemeEkrani : Form
    {
        UpdateFileDLL updateFileDLL = new UpdateFileDLL();
        //StatusNameTableValue
        private int statusValue;
        public BelgeGuncellemeEkrani()
        {
            InitializeComponent();
        }
        //Belgenin güncellenmesi sonrası AnaEkran formunu yeniler. UpdateFileMethod metotunda sonunda döndürür.
        public delegate void UpdateFileEventHandler();
        public event UpdateFileEventHandler UpdateFileEventH;
        /*Belge dizini değiştirme butonunun aktifliğini kontrol etmek amacıyla kullanılmaktadır. 
         * updateFileDirectory_Button_Click eventi çalıştığında true değer döner.
         * False değer dönmesi durumunda belge dizininin değiştirilmediği ve dolayısıyla checkFileMethod metotuna gerek olmadığı anlaşılır.
         * True değer dönmesi durumunda ise updateFileMethod metotundan önce checkFileMethod çağırılır.
         * Belgenin dizini/adı dışındaki değiştirilmek istendiğinde checkFileMethod'unun yaratacağı sonsuz "belge var" döngüsünün önüne geçer.
         * En saçma yöntemlerinden biri olsa da işe yarıyor. :D
         */
        private bool updateDirectoryButtonCheck = false;
        //private string oldFileName = "";

        //YeniBelgeEkrani formundan belgenin numara olarak geçen anahtar değerini alır.
        //AnaEkran formundan kullanıcının Id değerini alır.
        public BelgeGuncellemeEkrani(string updateForm_belgeNo, int update_UserId, int updated_UserId)
        {
            InitializeComponent();
            BelgeNo = updateForm_belgeNo;
            UserId3 = update_UserId;
            WhoUpdatedId = updated_UserId;
        }
        public string BelgeNo { get; set; }
        public int UserId3 { get; set; }
        public int WhoUpdatedId { get; set; }

        //Textboxların ve Combobox'un boş olması durumunda güncelle butonu pasif kalmaktadır.
        private void TextControlForButton()
        {
            if (UpdateFileTitle_TextBox.Text.Trim() != string.Empty && UpdateFileName_TextBox.Text.Trim() != string.Empty && UpdateFileDirectory_TextBox.Text.Trim() != string.Empty && UpdateFileExplain_RichTextBox.Text.Trim() != string.Empty && UpdateFileStatus_ComboBox.Text.Trim() != string.Empty)
            {
                UpdateFile_UpdateButton.Enabled = true;
            }
            else
            {
                UpdateFile_UpdateButton.Enabled = false;
            }
        }
        //Belge Güncelleme Ekranını ilgili belgenin bilgileriyle dolduran metottdur. 
        private void TextGridFromOtherForm()
        {
            //Item1 = fileTitle, Item2 = fileDirectory, Item3 = fileName, Item4 = fileExplain, Item5 = fileDate, Item6 = fileStatus
            var textGridTuple = updateFileDLL.TextGridFromOtherForm(BelgeNo);

            UpdateFileTitle_TextBox.Text = textGridTuple.Item1;
            UpdateFileDirectory_TextBox.Text = textGridTuple.Item2;
            UpdateFileName_TextBox.Text = textGridTuple.Item3;
            UpdateFileExplain_RichTextBox.Text = textGridTuple.Item4;
            UpdateFileAddedDateTimePicker.Text = textGridTuple.Item5;
            UpdateFileStatus_ComboBox.Text = textGridTuple.Item6;
        }
        //Kontrol veya Güncelleme öncesinde kullanıcının yetkisini kontrol eder.
        private void UserIdCheckForPermission()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            string fileDirectory = UpdateFileDirectory_TextBox.Text;
            string fileName = UpdateFileName_TextBox.Text;

            string returnValue = updateFileDLL.UserIdCheckForPermission(fileDirectory, fileName);
            if (returnValue != "nullValue")
            {
                if (returnValue == UserId3.ToString())
                {
                    if (updateDirectoryButtonCheck == false)
                    {
                        UpdateFileMethod();
                    }
                    else
                    {
                        OldFileCheckMethod();
                    }
                }
                else
                {
                    MessageBox.Show("Bu belge üzerinde yetkiniz yok!");
                }
            }
            //Böyle bir belge yoksa
            else
            {
                UpdateFileMethod();
            }
            MessageBoxManager.Unregister();
        }
        /* Aynı pencerede belgenin bir kaç kez değişmesine karşı önlem olarak OldFileCheckMethod yaratılmıştır.
         * BelgeNo üzerinden belgeyi veritabanından kontrol ederek textboxlardaki ismi ile 
         * veritabanındaki ismi arasında karşılaştırma yapar
         */
        private void OldFileCheckMethod()
        {
            string fileName = UpdateFileName_TextBox.Text;
            string fileDirectory = UpdateFileDirectory_TextBox.Text;

            string returnValue = updateFileDLL.OldFileCheck(BelgeNo, fileName, fileDirectory);

            if (returnValue == "update")
            {
                UpdateFileMethod();
            }
            else //"check"
            {
                CheckFileMethod();
            }
        }
        //Belgeyi güncelleme işleminden önce bu belgenin var olup olmadığını kontrol eder. Yok ise updateFileMethod çalıştırır.
        private void CheckFileMethod()
        {
            string fileName = UpdateFileName_TextBox.Text.Trim();
            string fileDirectory = UpdateFileDirectory_TextBox.Text.Trim();
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //MeesageBox Özelleştirme
            MessageBoxManager.Register();

            string returnValue = updateFileDLL.CheckFile(fileName, fileDirectory);

            //Eğer böyle bir belge adı ya da dizini yok ise false koşulu çalışır. Varsa true koşulu çalışır ve belge güncelleme ya da değiştirme seçeneği sunar.
            if (returnValue == "false")
            {
                String messageCheckFile = "Belgeyi güncellemek istiyor musunuz?";
                String titleCheckFile = "";
                MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
                DialogResult yesNoResult = MessageBox.Show(messageCheckFile, titleCheckFile, yesNoButtons);
                if (yesNoResult == DialogResult.Yes)
                {
                    UpdateFileMethod();
                }
                else
                {
                    this.Show();
                    MessageBoxManager.Unregister();
                }
            }
            //Böyle bir belge adı veya dizini varsa true döndürerek işlemi iptal eder.
            else
            {
                String messageExisting = ("Böyle bir belge var. \n\nBelge Adı: " + UpdateFileName_TextBox.Text + "\n\nBelge Dizini: " + UpdateFileDirectory_TextBox.Text);
                String titleExisting = "Uyarı!";
                MessageBoxButtons okButtons = MessageBoxButtons.OK;
                DialogResult updateFileFormResult = MessageBox.Show(messageExisting, titleExisting, okButtons);
                MessageBoxManager.Unregister();
                this.Show();
            }
            MessageBoxManager.Unregister();
        }
        /*Belge eklerken kullanılan parametrelerden birisi durumNo'dur. Tablodaki "Yeni" değerini döndürülmektedir.
         * Durum adı Yeni veya Güncellenmiş değilse OtherStatusNameTableValue metotuna geçiş yapar. 
         */
        private int StatusNameTableValue()
        {
            /*Eğer belge yeni ise kayıt yapılırken Güncellenmiş olarak kaydedilir.
             *Güncellenme yapılırken Yeni durumu seçilirse yine Güncellenmiş olarak kaydedilir.
             * Combobox verilerinin indeksi 0 ile başladığından dolayı SelectedIndex+1 ile kaydedilmektedirler.
             */
            if (UpdateFileStatus_ComboBox.SelectedItem.ToString() == "Yeni" || UpdateFileStatus_ComboBox.SelectedItem.ToString() == "Güncellenmiş")
            {
                Program.dataBaseConnection.Close();
                string statusNameCmdText = "SELECT durumNo FROM durumlar WHERE durumAdi = @durumAdi";
                SqlCommand statusNameCmd = new SqlCommand(statusNameCmdText, Program.dataBaseConnection);
                statusNameCmd.Parameters.AddWithValue("@durumAdi", "Güncellenmiş");
                Program.dataBaseConnection.Open();
                SqlDataReader statusNameReader = statusNameCmd.ExecuteReader();
                if (statusNameReader.Read())
                {
                    statusValue = Convert.ToInt32(statusNameReader["durumNo"]);
                }
                else
                {
                    Program.dataBaseConnection.Close();
                    SqlCommand addNewStatusCmd = new SqlCommand("INSERT INTO durumlar (durumAdi) VALUES ('Güncellenmiş')", Program.dataBaseConnection);
                    Program.dataBaseConnection.Open();
                    addNewStatusCmd.ExecuteNonQuery();
                    Program.dataBaseConnection.Close();
                    statusNameReader.Close();
                    StatusNameTableValue();
                }
                Program.dataBaseConnection.Close();
                statusNameReader.Close();
            }
            else
            {
                OtherStatusNameTableValue();
            }
            Program.dataBaseConnection.Close();
            return statusValue;
        }
        private int OtherStatusNameTableValue()
        {
            Program.dataBaseConnection.Close();
            string statusNameCmdText = "SELECT durumNo FROM durumlar WHERE durumAdi = @durumAdi";
            SqlCommand statusNameCmd = new SqlCommand(statusNameCmdText, Program.dataBaseConnection);
            statusNameCmd.Parameters.AddWithValue("@durumAdi", UpdateFileStatus_ComboBox.SelectedItem);
            Program.dataBaseConnection.Open();
            SqlDataReader statusNameReader = statusNameCmd.ExecuteReader();
            if (statusNameReader.Read())
            {
                statusValue = Convert.ToInt32(statusNameReader["durumNo"]);
            }
            statusNameReader.Close();
            Program.dataBaseConnection.Close();
            return statusValue;
        }

        private void UpdateFileMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            Program.dataBaseConnection.Close();
            string updateFileCmdText = "UPDATE belgelerim SET belgeBasligi = @belgeBasligi, belgeAdi = @belgeAdi, belgeDizini = @belgeDizini, belgeAciklamasi = @belgeAciklamasi, durumNo = @durumNo, guncellenmeTarihi = @guncellenmeTarihi, sistemGuncellenmeTarihi = @sistemGuncellenmeTarihi, guncelleyenKisiNo = @guncelleyenKisiNo WHERE belgeNo = " + BelgeNo;
            SqlCommand updateFileCmd = new SqlCommand(updateFileCmdText, Program.dataBaseConnection);
            updateFileCmd.Parameters.AddWithValue("@belgeBasligi", UpdateFileTitle_TextBox.Text.Trim());
            updateFileCmd.Parameters.AddWithValue("@belgeAdi", UpdateFileName_TextBox.Text.Trim());
            updateFileCmd.Parameters.AddWithValue("@belgeDizini", UpdateFileDirectory_TextBox.Text.Trim());
            updateFileCmd.Parameters.AddWithValue("@belgeAciklamasi", UpdateFileExplain_RichTextBox.Text.Trim());
            updateFileCmd.Parameters.AddWithValue("@durumNo", StatusNameTableValue());
            updateFileCmd.Parameters.AddWithValue("@guncellenmeTarihi", DateTime.Parse(UpdateFileUpdateDateTimePicker.Text));
            updateFileCmd.Parameters.AddWithValue("@sistemGuncellenmeTarihi", DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
            updateFileCmd.Parameters.AddWithValue("@guncelleyenKisiNo", WhoUpdatedId);
            Program.dataBaseConnection.Open();
            updateFileCmd.ExecuteNonQuery();
            updateFileCmd.Dispose();
            //Refresh
            UpdateFileEventH?.Invoke();
            MessageBox.Show("Belge Güncellendi.");
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
            this.DialogResult = DialogResult.OK;
            this.Close();
            UpdateFileLog(UpdateFileName_TextBox.Text.Trim());
        }

        private void BelgeGuncellemeEkrani_Load(object sender, EventArgs e)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //Uyarı pencerelerindeki butonları Türkçeleştirmek amacıyla MessageBoxManager kullanılmıştır.
            //https://www.codeproject.com/Articles/18399/Localizing-System-MessageBox

            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";
            MessageBoxManager.Register();

            //Boş veriye karşı buton pasifleştirme
            TextControlForButton();
            //Veriye uygun olarak Text doldurma
            TextGridFromOtherForm();
            //Karakter sayısı gizleme
            UpdateFileExplain_TextLength.Visible = false;
            //Combobox doldurma
            UpdateFileStatus_ComboBox.Items.Add(updateFileDLL.ComboboxFill());

            MessageBoxManager.Unregister();
        }
        //Belgeyi Değiştirmek
        private void UpdateFileDirectory_Button_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            //Belgenin değiştirilmesine karşı önlem uyarısı
            String message = "Belgeyi değiştirmek istediğinizden emin misiniz?";
            String title = "Uyarı!";
            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
            DialogResult yesNoResult = MessageBox.Show(message, title, yesNoButtons);
            if (yesNoResult == DialogResult.Yes)
            {
                string fileDirectoryName;
                OpenFileDialog files = new OpenFileDialog();
                //Yeni dosya formatları eklemek için
                //" Format İsmi |*.formattürü " şeklinde ekle
                files.Filter = "" +
                    "Tüm Dosyalar |*.*|" +
                    "Tüm Belgeler |*.docx;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf|" +
                    "Word Belgeleri |*.docx|" +
                    "PDF Belgeleri |*.pdf|" +
                    "Metin Dosyaları |*.txt";
                if (files.ShowDialog() == DialogResult.OK)
                {
                    fileDirectoryName = Path.GetFileNameWithoutExtension(files.FileName);

                    if (UpdateFileDirectory_TextBox.Text.Trim() == "" || UpdateFileDirectory_TextBox.Text.Trim() != fileDirectoryName)
                    {
                        UpdateFileDirectory_TextBox.Text = files.FileName;
                    }

                    UpdateFileName_TextBox.Text = fileDirectoryName;
                }
            }
            FileInfo fileInfoForSize = new FileInfo(UpdateFileDirectory_TextBox.Text.Trim());
            UpdateFileSize_Label.Visible = true;
            if (fileInfoForSize.Length < (Math.Pow(10, 7) * 1.5))
            {
                UpdateFileSize_Label.ForeColor = Color.Green;
            }
            else
            {
                UpdateFileSize_Label.ForeColor = Color.Red;
            }
            if(fileInfoForSize.Length < 1024000)
            {
                UpdateFileSize_Label.Text = "Belge Boyutu: " + (fileInfoForSize.Length / 1024) + "KB";
            }
            else
            {
                UpdateFileSize_Label.Text = "Belge Boyutu: " + (fileInfoForSize.Length / 1024 / 1024) + "MB";
            }

            updateDirectoryButtonCheck = true;
            MessageBoxManager.Unregister();
        }

        private void UpdateFile_CancelButton_Click(object sender, EventArgs e)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            this.Close();
        }

        private void UpdateFile_UpdateButton_Click(object sender, EventArgs e)
        {
            //Sistem tarihleri
            UserIdCheckForPermission();
        }
        //Changed  Textboxlara veri girilmesi halinde TextControlForButton metotu çalıştırılır.
        //UpdateFileTitle, UpdateFileDirectory, UpdateFileName, UpdateFileExplain, UpdateFileStatus
        private void TextBoxTextChanged_ComboboxSelectedIndexChanged (object sender, EventArgs e)
        {
            TextControlForButton();
        }
        //KeyUp
        private void UpdateFileExplain_RichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateFileExplain_TextLength.Text = Convert.ToString(5000 - UpdateFileExplain_RichTextBox.TextLength);
            if (UpdateFileExplain_TextLength.Text != "5000")
                UpdateFileExplain_TextLength.Visible = true;
            else
                UpdateFileExplain_TextLength.Visible = false;
        }
        //Keydown
        private void UpdateFileTitle_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        //Changed
        
        private void UpdateFileLog(string fileName)
        {
            string logFilePath = @"C:\Users\Fatih\Desktop\ServerLogKaydi\UpdateFileLog.txt";
            string writeText = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]: Belge güncelleme işlemini yapan Kullanıcı No: " + BelgeNo + "\tBelge Adı: " + fileName;
            FileStream adminLogFS = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            adminLogFS.Close();
            File.AppendAllText(logFilePath, Environment.NewLine + writeText);
        }
    }
}
