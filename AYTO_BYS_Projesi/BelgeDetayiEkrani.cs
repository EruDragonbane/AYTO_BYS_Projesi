using System;
using System.Diagnostics;
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
using AYTO.SendFile;

namespace AYTO_BYS_Projesi
{
    public partial class BelgeDetayiEkrani : Form
    {
        SendFileDLL sendFileDLL = new SendFileDLL();
        public BelgeDetayiEkrani()
        {
            InitializeComponent();
        }
        public BelgeDetayiEkrani(string mainForm_belgeNo, int detailForm_UserId)
        {
            InitializeComponent();
            BelgeNo = mainForm_belgeNo;
            UserId5 = detailForm_UserId;
        }
        public string BelgeNo { get; set; }
        public int UserId5 { get; set; }
        private void LabelGridFromDataGridView()
        {
            var labelGridTuple = sendFileDLL.LabelGridFromDataGridView(BelgeNo);
            
            DetailFile_FileTitleLabel.Text = labelGridTuple.Item1;
            DetailFile_FileNameLinkLabel.Text = labelGridTuple.Item2;
            DetailFile_FileExplain_RichTextBox.Text = labelGridTuple.Item3;
            DetailFile_FileDateLabel.Text = labelGridTuple.Item4;
            DetailFile_SendFromUserLabel.Text = labelGridTuple.Item5;
        }
        private void DetailFileForm_SendFileButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            BelgeGondermeEkrani sendFileForm = new BelgeGondermeEkrani(BelgeNo, UserId5);
            //Pencere halihazırda aktif ise yeni pencere açmak
            //yerine varolan pencereyi açar.
            if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGondermeEkrani))
            {
                MessageBox.Show("Belge güncelleme penceresi zaten açık! \n\nÖnce açık olan pencereyi kapatın.", "Uyarı");
            }
            else
            {
                //Pencere konumunu ekran merkezine taşır.
                sendFileForm.StartPosition = FormStartPosition.CenterScreen;
                sendFileForm.Show();
            }
            MessageBoxManager.Unregister();
        }
        //Dosyayı ilgili programda açar.
        private void BelgeDetayiEkrani_Load(object sender, EventArgs e)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();

            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";
            MessageBoxManager.Register();

            LabelGridFromDataGridView();
        }

        private void DetailFile_FileNameLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sendFileDLL.LinkClicked_OpenFileEvent(BelgeNo);
        }

        private void DetailFileForm_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailFileForm_DownloadButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            Program.dataBaseConnection.Close();
            string fileNameCmdText = "SELECT blg.belgeAdi, klnc.kullaniciGiris, blg.belgeVeriTipiveAdi, blg.belgeServerDizini FROM belgelerim AS blg INNER JOIN kullanicilar AS klnc ON blg.kullaniciNo = klnc.kullaniciNo WHERE belgeNo = @belgeNo";
            SqlCommand fileNameCmd = new SqlCommand(fileNameCmdText, Program.dataBaseConnection);
            fileNameCmd.Parameters.AddWithValue("@belgeNo", BelgeNo);
            Program.dataBaseConnection.Open();
            SqlDataReader fileNameCmdReader = fileNameCmd.ExecuteReader();
            if(fileNameCmdReader.Read())
            {
                SaveFileDialog saveFileFromServer = new SaveFileDialog();
                saveFileFromServer.CreatePrompt = true;
                saveFileFromServer.RestoreDirectory = true;
                saveFileFromServer.Filter = "All files (*.*)|*.*";
                saveFileFromServer.FileName = fileNameCmdReader["belgeVeriTipiveAdi"].ToString();

                if (saveFileFromServer.ShowDialog() == DialogResult.OK)
                {
                    //Dosyayı, kullanıcının seçtiği konuma kaydeder.
                    string serverPath = fileNameCmdReader["belgeServerDizini"].ToString();
                    FileStream saveFileStream = File.OpenRead(serverPath);
                    byte[] contents = new byte[saveFileStream.Length];
                    saveFileStream.Read(contents, 0, (int)saveFileStream.Length);
                    saveFileStream.Close();
                    File.WriteAllBytes(saveFileFromServer.FileName, contents);
                }
                DownloadLog(fileNameCmdReader["belgeVeriTipiveAdi"].ToString(), fileNameCmdReader["kullaniciGiris"].ToString());
            }
            MessageBoxManager.Unregister();
            fileNameCmdReader.Close();
            Program.dataBaseConnection.Close();
        }

        private void DownloadLog(string fileName, string userIdName)
        {
            string logFilePath = @"C:\Users\Fatih\Desktop\ServerLogKaydi\DownloadFileLog.txt";
            string writeText = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]: Dosyayı indiren Kullanıcı No: " + UserId5 + "\tKullanıcı ID: " + userIdName + "\t İndirilen Dosya No: " + BelgeNo + "\tBelge Adı: " + fileName;
            FileStream adminLogFS = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            adminLogFS.Close();
            File.AppendAllText(logFilePath, Environment.NewLine + writeText);
        }
    }
}
