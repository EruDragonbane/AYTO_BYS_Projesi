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

namespace AYTO_BYS_Projesi
{
    public partial class YeniBelgeEkrani : Form
    {
        public int statusValue;
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
            Program.dataBaseConnection.Close();
            string statusNameCmdText = "SELECT durumNo FROM durumlar WHERE durumAdi = @durumAdi";
            SqlCommand statusNameCmd = new SqlCommand(statusNameCmdText, Program.dataBaseConnection);
            statusNameCmd.Parameters.AddWithValue("@durumAdi", "Yeni");
            Program.dataBaseConnection.Open();
            SqlDataReader statusNameReader = statusNameCmd.ExecuteReader();
            if (statusNameReader.Read())
            {
                statusValue = Convert.ToInt32(statusNameReader["durumNo"]);
            }
            else
            {
                Program.dataBaseConnection.Close();
                SqlCommand addNewStatusCmd = new SqlCommand("INSERT INTO durumlar (durumAdi) VALUES ('Yeni')", Program.dataBaseConnection);
                Program.dataBaseConnection.Open();
                addNewStatusCmd.ExecuteNonQuery();
                Program.dataBaseConnection.Close();
                statusNameReader.Close();
                StatusNameTableValue();
            }
            Program.dataBaseConnection.Close();
            statusNameReader.Close();
            return statusValue;
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
            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //MeesageBox Özelleştirme
            MessageBoxManager.Register();
            //Sistem tarihleri, kullanıcının girdiği tarihi kontrol etmek amacıyla eklenmiştir. 
            string systemDate = DateTime.Now.ToString("dd/MM/yyyy");
            //Veritabanı bağlantısı aktif değilse aktif yap
            Program.dataBaseConnection.Close();
            string checkCmdText = "SELECT blg.belgeDizini, blg.belgeAdi, blg.kullaniciNo, klnc.kullaniciAdi, klnc.kullaniciSoyadi FROM belgelerim AS blg INNER JOIN kullanicilar AS klnc ON blg.kullaniciNo = klnc.kullaniciNo WHERE blg.belgeDizini = @belgeDizini AND blg.belgeAdi = @belgeAdi";
            SqlCommand checkCmd = new SqlCommand(checkCmdText, Program.dataBaseConnection);
            checkCmd.Parameters.AddWithValue("@belgeDizini", NewFileDirectory_TextBox.Text.Trim());
            checkCmd.Parameters.AddWithValue("@belgeAdi", NewFileName_TextBox.Text.Trim());
            Program.dataBaseConnection.Open();
            SqlDataReader checkCmdReader = checkCmd.ExecuteReader();
            //Eğer böyle bir belge adı ya da dizini yok ise false koşulu çalışır. Varsa true koşulu çalışır ve belge güncelleme ya da değiştirme seçeneği sunar.
            if (checkCmdReader.Read() == false)
            {
                Program.dataBaseConnection.Close();
                String messageNewFile = "Belgeyi eklemek istiyor musunuz?";
                String titleNewFile = "";
                DialogResult yesNoResult = MessageBox.Show(messageNewFile, titleNewFile, yesNoButtons);
                if (yesNoResult == DialogResult.Yes)
                {
                    //BELGE KAYDETME
                    FileInfo fileInfo = new FileInfo(NewFileDirectory_TextBox.Text.Trim());

                    if (fileInfo.Length < (Math.Pow(10, 7) * 1.5))
                    {
                        //Dosyayı server klasörüne kaydeder.
                        string serverPath = @"C:\Users\Fatih\Desktop\ServerDosyaOrnegi\" + FileTypeLabel.Text;
                        FileStream fileStream = File.OpenRead(NewFileDirectory_TextBox.Text.Trim());
                        byte[] contents = new byte[fileStream.Length];
                        fileStream.Read(contents, 0, (int)fileStream.Length);
                        fileStream.Close();
                        File.WriteAllBytes(serverPath, contents);

                        //Veritabanına bilgileri ekle
                        Program.dataBaseConnection.Close();
                        string registerCmdText = "INSERT INTO belgelerim (kullaniciNo, belgeBasligi, belgeAdi, belgeDizini, belgeVeriTipiveAdi, belgeServerDizini, belgeAciklamasi, eklenmeTarihi, sistemEklenmeTarihi, durumNo) values (@kullaniciNo, @belgeBasligi, @belgeAdi, @belgeDizini, @belgeVeriTipiveAdi, @belgeServerDizini, @belgeAciklamasi, @eklenmeTarihi, @sistemEklenmeTarihi, @durumNo)";
                        SqlCommand registerCmd = new SqlCommand(registerCmdText, Program.dataBaseConnection);

                        registerCmd.Parameters.AddWithValue("@kullaniciNo", UserId2);
                        registerCmd.Parameters.AddWithValue("@belgeBasligi", NewFileTitle_TextBox.Text.Trim());
                        registerCmd.Parameters.AddWithValue("@belgeAdi", NewFileName_TextBox.Text.Trim());
                        registerCmd.Parameters.AddWithValue("@belgeDizini", NewFileDirectory_TextBox.Text.Trim());
                        registerCmd.Parameters.AddWithValue("@belgeVeriTipiveAdi", FileTypeLabel.Text.Trim());
                        registerCmd.Parameters.AddWithValue("@belgeServerDizini", serverPath);
                        registerCmd.Parameters.AddWithValue("@belgeAciklamasi", NewFileExplain_RichTextBox.Text.Trim());
                        registerCmd.Parameters.AddWithValue("@eklenmeTarihi", DateTime.Parse(NewFileDateTimePicker.Text));
                        registerCmd.Parameters.AddWithValue("@sistemEklenmeTarihi", DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        registerCmd.Parameters.AddWithValue("@durumNo", StatusNameTableValue()); //Yeni eklenen belgeler her zaman Yeni olarak işaretlenir.
                        Program.dataBaseConnection.Open();
                        registerCmd.ExecuteNonQuery();
                        AddNewFileEventH();
                        NewFileLog(NewFileName_TextBox.Text.Trim());

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
                    Program.dataBaseConnection.Close();

                }
                else
                {
                    this.Show();
                    MessageBoxManager.Unregister();
                }
                Program.dataBaseConnection.Close();
            }
            //Böyle bir belge adı veya dizini varsa true döndürerek işlemi iptal eder.
            else
            {
                if(checkCmdReader["kullaniciNo"].ToString() == UserId2.ToString())
                {
                    String messageExisting = ("Böyle bir belge var. \n\nBelge Adı: " + NewFileName_TextBox.Text.Trim() + "\n\nBelge Dizini: " + NewFileDirectory_TextBox.Text.Trim() + "\n\nVar olan belgeyi güncellemek ister misiniz?");
                    String titleExisting = "Uyarı!";
                    DialogResult updateFileFormResult = MessageBox.Show(messageExisting, titleExisting, yesNoButtons);
                    MessageBoxManager.Unregister();
                    if (updateFileFormResult == DialogResult.Yes)
                    {
                        Program.dataBaseConnection.Close();
                        string updateFileCmdText = "SELECT blg.belgeNo FROM belgelerim AS blg WHERE blg.belgeAdi = @belgeAdi";
                        SqlCommand updateFileCmd = new SqlCommand(updateFileCmdText, Program.dataBaseConnection);
                        updateFileCmd.Parameters.AddWithValue("@belgeAdi", NewFileName_TextBox.Text.Trim());
                        Program.dataBaseConnection.Open();
                        SqlDataReader updateFormReader = updateFileCmd.ExecuteReader();
                        if (updateFormReader.Read())
                        {
                            MessageBoxManager.Unregister();
                            MessageBoxManager.Register();
                            string updateForm_belgeNo = updateFormReader["belgeNo"].ToString();
                            BelgeGuncellemeEkrani updateFileForm = new BelgeGuncellemeEkrani(updateForm_belgeNo, UserId2, UserId2);
                            if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGuncellemeEkrani))
                            {
                                MessageBox.Show("Belge güncelleme penceresi zaten açık! \n\nÖnce açık olan pencereyi kapatın.", "Uyarı");
                            }
                            else
                            {
                                //updateFileForm.UpdateFileEventH += Deneme;
                                this.Close();
                                updateFileForm.Show();
                            }
                        }
                        updateFormReader.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Bu belge " + checkCmdReader["kullaniciAdi"] + " " + checkCmdReader["kullaniciSoyadi"] + " tarafından eklendi.");
                    MessageBoxManager.Unregister();
                }

            }
            MessageBoxManager.Unregister();
            checkCmdReader.Close();
            Program.dataBaseConnection.Close();
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

        private void NewFileLog(string fileName)
        {
            string fileNameDB = "";
            Program.dataBaseConnection.Close();
            SqlCommand fileNameCmd = new SqlCommand("SELECT belgeNo FROM belgelerim WHERE belgeAdi = @belgeAdi", Program.dataBaseConnection);
            fileNameCmd.Parameters.AddWithValue("@belgeAdi", fileName);
            Program.dataBaseConnection.Open();
            SqlDataReader fileNameReader = fileNameCmd.ExecuteReader();
            if (fileNameReader.Read())
            {
                fileNameDB = fileNameReader["belgeNo"].ToString();
            }
            fileNameReader.Close();
            Program.dataBaseConnection.Close();
            string logFilePath = @"C:\Users\Fatih\Desktop\ServerLogKaydi\AddNewFileLog.txt";
            string writeText = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "}: Yeni belge ekleyen Kullanıcı No: " + UserId2 + "\tEklenen Belge No: " + fileNameDB + "\t Belge Adı: " + fileName;

            FileStream adminLogFS = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            adminLogFS.Close();
            File.AppendAllText(logFilePath, Environment.NewLine + writeText);
        }
    }
}