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
using AYTO.Log;

namespace AYTO_BYS_Projesi
{
    public partial class BelgeGuncellemeEkrani : Form
    {
        UpdateFileDLL updateFileDLL = new UpdateFileDLL();
        LogDLL logDLL = new LogDLL();
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
            UpdateFileStatus_ComboBox.SelectedIndex = UpdateFileStatus_ComboBox.Items.IndexOf(textGridTuple.Item6);
        }
        //Combobox'u durumlar ile doldurur.
        private void ComboboxFill()
        {
            Program.dataBaseConnection.Close();
            string comboboxFilldCmdText = "SELECT drm.durumAdi FROM durumlar AS drm ORDER BY drm.durumNo ASC";
            SqlCommand comboboxFillCmd = new SqlCommand(comboboxFilldCmdText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            SqlDataReader comboboxFillReader = comboboxFillCmd.ExecuteReader();
            while (comboboxFillReader.Read())
            {
                UpdateFileStatus_ComboBox.Items.Add(comboboxFillReader["durumAdi"].ToString());
            }
            comboboxFillReader.Close();
            Program.dataBaseConnection.Close();
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
                        /* Aynı pencerede belgenin bir kaç kez değişmesine karşı önlem olarak OldFileCheckMethod yaratılmıştır.
                         * BelgeNo üzerinden belgeyi veritabanından kontrol ederek textboxlardaki ismi ile 
                         * veritabanındaki ismi arasında karşılaştırma yapar
                         */
                        string oldFileCheckReturnValue = updateFileDLL.OldFileCheck(BelgeNo, fileName, fileDirectory);

                        if (oldFileCheckReturnValue == "update")
                        {
                            UpdateFileMethod();
                        }
                        else //"check"
                        {
                            CheckFileMethod();
                        }
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
        private void UpdateFileMethod()
        {
            string updateFileTitle = UpdateFileTitle_TextBox.Text.Trim();
            string updateFileName = UpdateFileName_TextBox.Text.Trim();
            string updateFileDirectory = UpdateFileDirectory_TextBox.Text.Trim();
            string updateFileExplain = UpdateFileExplain_RichTextBox.Text.Trim();
            string comboboxSelectedItem = UpdateFileStatus_ComboBox.SelectedItem.ToString();
            string updateDateTimePicker = UpdateFileUpdateDateTimePicker.Text;

            updateFileDLL.UpdateFile(BelgeNo, updateFileTitle, updateFileName, updateFileDirectory, updateFileExplain, comboboxSelectedItem, updateDateTimePicker, WhoUpdatedId);

            //Refresh
            UpdateFileEventH?.Invoke();
            MessageBox.Show("Belge Güncellendi.");
            MessageBoxManager.Unregister();
            this.DialogResult = DialogResult.OK;
            this.Close();
            logDLL.UpdateFileLog(UserId3, BelgeNo, updateFileName);
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
            ComboboxFill();

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
    }
}
