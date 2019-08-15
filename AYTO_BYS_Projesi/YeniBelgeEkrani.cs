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
using AYTO.NewFile;
using AYTO.Log;

namespace AYTO_BYS_Projesi
{
    public partial class YeniBelgeEkrani : Form
    {
        NewFileDLL newFileDLL = new NewFileDLL();
        LogDLL logDLL = new LogDLL();

        public YeniBelgeEkrani()
        {
            InitializeComponent();
        }

        public YeniBelgeEkrani(int userId)
        {
            InitializeComponent();
            UserId2 = userId;
        }
        public int UserId2 { get; set;}

        //Yeni belgenin eklenmesi sonrası AnaEkran formunu yeniler. registerMethod metotunda 18. satırdan (metot sonunda) döndürür.
        public delegate void AddNewFileEventHandler();
        public event AddNewFileEventHandler AddNewFileEventH;

        //TextBoxların boş olması durumunda ekle butonu pasif kalmaktadır.
        private void TextControlForButton()
        {
            if(NewFileTitle_TextBox.Text.Trim() != string.Empty && NewFileName_TextBox.Text.Trim() != string.Empty && NewFileDirectory_TextBox.Text.Trim() != string.Empty && NewFileExplain_RichTextBox.Text.Trim() != string.Empty)
            {
                NewFile_AddButton.Enabled = true;
            }
            else
            {
                NewFile_AddButton.Enabled = false;
            }
        }
        //Belge eklerken kullanılan parametrelerden birisi durumNo'dur. Tablodaki "Yeni" değerini döndürülmektedir.
        private int StatusNameTableValue()
        {
            return 0;
        }
        //Yeni bir belge eklemeden önce yapılan kontroller bütünüdür.
        private void NewFileChecks()
        {
            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //MeesageBox Özelleştirme
            MessageBoxManager.Register();

            string fileDirectory = NewFileDirectory_TextBox.Text.Trim();
            string fileName = NewFileName_TextBox.Text.Trim();
            //Amaç eklenen belgenin var olup olmadığını kontrol etmektir.
            //Item1 = returnValue, Item2 = userName, Item3 = userSurname
            var returnChecksTuple = newFileDLL.NewFile_AddButton_Check(UserId2, fileDirectory, fileName);

            if (returnChecksTuple.Item1 == "false")
            {
                String messageNewFile = "Belgeyi eklemek istiyor musunuz?";
                String titleNewFile = "";
                DialogResult yesNoResult = MessageBox.Show(messageNewFile, titleNewFile, yesNoButtons);
                if (yesNoResult == DialogResult.Yes)
                {
                    //BELGE KAYDETME
                    FileInfo fileInfo = new FileInfo(fileDirectory);

                    if (fileInfo.Length < (Math.Pow(10, 7) * 1.5))
                    {
                        //Dosyayı server klasörüne kaydeder.
                        string serverPath = Program.serverFilePath + FileTypeLabel.Text;
                        using (FileStream fileStream = File.OpenRead(fileDirectory))
                        {
                            byte[] contents = new byte[fileStream.Length];
                            fileStream.Read(contents, 0, (int)fileStream.Length);
                            fileStream.Close();
                            File.WriteAllBytes(serverPath, contents);
                        }
                        //Belgenin kayıt edilmesi
                        NewFileRegister(serverPath);
                        AddNewFileEventH();
                        logDLL.NewFileLog(UserId2, fileName);

                        String messageAnotherNewFile = "Belge başarıyla eklendi. \n\nYeni bir belge eklemek istiyor musunuz?";
                        DialogResult anotherResult = MessageBox.Show(messageAnotherNewFile, titleNewFile, yesNoButtons);
                        if (anotherResult == DialogResult.No)
                        {
                            this.Close();
                            MessageBoxManager.Unregister();
                        }
                        else
                        {
                            NewFileTitle_TextBox.Clear();
                            NewFileDirectory_TextBox.Clear();
                            NewFileName_TextBox.Clear();
                            NewFileExplain_RichTextBox.Clear();
                            NewFileDateTimePicker.Value = DateTime.Now;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dosya boyutu 15MB'den büyük!");
                    }
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
                if (returnChecksTuple.Item1 == "existingFile")
                {
                    MessageBox.Show("Bu isimde bir belgeniz var. \n\nBelge Adı: " + fileName + "\n\nBelge Dizini: " + fileDirectory);
                    MessageBoxManager.Unregister();
                }
                else
                {
                    MessageBox.Show("Bu belge " + returnChecksTuple.Item2 + " " + returnChecksTuple.Item3 + " tarafından eklendi.");
                    MessageBoxManager.Unregister();
                }
            }
            MessageBoxManager.Unregister();
        }
        //Belgenin kayıt edilmesi
        private void NewFileRegister(string serverPath)
        {
            //Veritabanına bilgileri ekle

            string registerFileTitle = NewFileTitle_TextBox.Text.Trim();
            string registerFileName = NewFileName_TextBox.Text.Trim();
            string registerFileDirectoy = NewFileDirectory_TextBox.Text.Trim();
            string registerFileTypeLabel = FileTypeLabel.Text.Trim();
            string registerFileExplain = NewFileExplain_RichTextBox.Text.Trim();
            string registerDateTime = NewFileDateTimePicker.Text;
            Console.WriteLine(newFileDLL.StatusNameTableValue());
            //newFileDLL.NewFile_AddButton_Register(UserId2, registerFileTitle, registerFileName, registerFileDirectoy, registerFileTypeLabel, serverPath, registerFileExplain, registerDateTime);
        }

        private void YeniBelgeEkrani_Load(object sender, EventArgs e)
        {
            TextControlForButton();
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();

            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";
            MessageBoxManager.Register();

            //Karakter Sayısını Gizleme
            NewFileExplain_TextLength.Visible = false;
            FileTypeLabel.Visible = false;
            NewFileSize_Label.Visible = false;
        }

        private void NewFileDirectory_Button_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            OpenFileDialog files = new OpenFileDialog();
            //Yeni dosya formatları eklemek için
            //" Format İsmi |*.formattürü " şeklinde ekle
            files.Filter = "" +
                "Tüm Dosyalar |*.*|" +
                "Tüm Belgeler |*.docx;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf|" +
                "Word Belgeleri |*.docx|" +
                "PDF Belgeleri |*.pdf|" +
                "Metin Dosyaları |*.txt";
            files.RestoreDirectory = true;
            //files.Title = "Eklemek istediğiniz belgeyi seçiniz.";
            if(files.ShowDialog() == DialogResult.OK)
            {
                if (NewFileDirectory_TextBox.Text.Trim() == "" || NewFileDirectory_TextBox.Text.Trim() != Path.GetFileNameWithoutExtension(files.FileName))
                {
                    NewFileDirectory_TextBox.Text = files.FileName;
                }
                NewFileName_TextBox.Text = Path.GetFileNameWithoutExtension(files.FileName);
                FileTypeLabel.Text = files.SafeFileName;
            }
            FileInfo fileInfoForSize = new FileInfo(NewFileDirectory_TextBox.Text.Trim());
            NewFileSize_Label.Visible = true;
            if (fileInfoForSize.Length < (Math.Pow(10, 7) * 1.5))
            {
                NewFileSize_Label.ForeColor = Color.Green;
            }
            else
            {
                NewFileSize_Label.ForeColor = Color.Red;
            }
            if(fileInfoForSize.Length < 1024000)
            {
                NewFileSize_Label.Text = "Belge Boyutu: " + (fileInfoForSize.Length / 1024) + "KB";
            }
            else
            {
                NewFileSize_Label.Text = "Belge Boyutu: " + (fileInfoForSize.Length / 1024 / 1024) + "MB";
            }
            MessageBoxManager.Unregister();
        }

        private void NewFile_CancelButton_Click(object sender, EventArgs e)
        {
            ////MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            this.Close();
        }

        private void NewFile_AddButton_Click(object sender, EventArgs e)
        {
            NewFileChecks();
        }
        //Changed  Textboxlara veri girilmesi halinde TextControlForButton metotu çalıştırılır.
        //NewFileTitle, NewFileDirectory, NewFileName, NewFileExplain
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextControlForButton();
        }
        //KeyUp Event-Karakter Sayısı Gösterme
        private void NewFileExplain_RichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            NewFileExplain_TextLength.Text = Convert.ToString(5000 - NewFileExplain_RichTextBox.TextLength);
            if (NewFileExplain_TextLength.Text != "5000")
                NewFileExplain_TextLength.Visible = true;
            else
                NewFileExplain_TextLength.Visible = false;
        }
        //Changed
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