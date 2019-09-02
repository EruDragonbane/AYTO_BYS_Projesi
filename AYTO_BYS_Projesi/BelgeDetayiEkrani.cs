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
using AYTO.FileDetail;
using AYTO.Log;
using System.Data.SqlClient;

namespace AYTO_BYS_Projesi
{
    public partial class BelgeDetayiEkrani : Form
    {
        FileDetailDLL fileDetailDLL = new FileDetailDLL();
        LogDLL logDLL = new LogDLL();

        private string fileNameWithFormat = "";

        public BelgeDetayiEkrani(string mainForm_belgeNo, string mainForm_userName, int detailForm_UserId, string PurposeForDetail)
        {
            InitializeComponent();
            BelgeNo = mainForm_belgeNo;
            ReceivedUserName = mainForm_userName;
            UserId5 = detailForm_UserId;
            DetailPurpose = PurposeForDetail;

        }
        public string BelgeNo { get; set; }
        public string ReceivedUserName { get; set; }
        public int UserId5 { get; set; }
        public string DetailPurpose { get; set; }
        private void LabelGridFromDataGridView()
        {
            if(DetailPurpose == "owner")
            {
                //Item1 = fileTitle, Item2 = fileName, Item3 = fileExplain, Item4 = fileDate, Item5 = addedFromUser
                var ownerLabelGridTuple = fileDetailDLL.LabelGridFromDataGridViewForOwner(BelgeNo);

                DetailFile_FileTitleLabel.Text = ownerLabelGridTuple.Item1;
                DetailFile_FileNameLinkLabel.Text = ownerLabelGridTuple.Item2;
                fileNameWithFormat = ownerLabelGridTuple.Item2;
                DetailFile_FileNameLinkLabel.AutoEllipsis = true;
                DetailFile_FileExplain_RichTextBox.Text = ownerLabelGridTuple.Item3;
                DetailFile_FileDateLabel.Text = ownerLabelGridTuple.Item4;
                DetailFile_AddedFromUserLabel.Text = ownerLabelGridTuple.Item5;
                if (ownerLabelGridTuple.Item2.Length > 39)
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(DetailFile_FileNameLinkLabel, ownerLabelGridTuple.Item2);
                }
            }
            else if(DetailPurpose == "received")
            {
                //Item1 = receivedTitle, Item2 = receivedFileName, Item3 = receivedExplain, Item4 = receivedDate, Item5 = addedFromUser
                var receivedLabelGridTuple = fileDetailDLL.LabelGridFromDataGridViewForReceived(BelgeNo, ReceivedUserName);
                DetailFile_FileTitleLabel.Text = receivedLabelGridTuple.Item1;
                DetailFile_FileNameLinkLabel.Text = receivedLabelGridTuple.Item2;
                fileNameWithFormat = receivedLabelGridTuple.Item2;
                DetailFile_FileNameLinkLabel.AutoEllipsis = true;
                DetailFile_FileExplain_RichTextBox.Text = receivedLabelGridTuple.Item3;
                DetailFile_FileDateLabel.Text = receivedLabelGridTuple.Item4;
                DetailFile_AddedFromUserLabel.Text = receivedLabelGridTuple.Item5;
                if (receivedLabelGridTuple.Item2.Length > 39)
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(DetailFile_FileNameLinkLabel, receivedLabelGridTuple.Item2);
                }
            }
            else
            {
                Console.WriteLine("Mesaj Gelmedi");
            }
        }
        private void DetailFileForm_Download()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            //Item1 = returnValue, Item2 = fileTypeAndName, Item3 = fileDirectory
            var downloadFileTuple = fileDetailDLL.DownloadButtonClick(BelgeNo);
            if (downloadFileTuple.Item1 == "true")
            {
                SaveFileDialog saveFileFromServer = new SaveFileDialog
                {
                    CreatePrompt = true,
                    RestoreDirectory = true,
                    Filter = "All files (*.*)|*.*",
                    FileName = downloadFileTuple.Item2
                };

                if (saveFileFromServer.ShowDialog() == DialogResult.OK)
                {
                    //Dosyayı, kullanıcının seçtiği konuma kaydeder.
                    string serverPath = downloadFileTuple.Item3;
                    using (FileStream saveFileStream = File.OpenRead(serverPath))
                    {
                        byte[] contents = new byte[saveFileStream.Length];
                        saveFileStream.Read(contents, 0, (int)saveFileStream.Length);
                        saveFileStream.Close();
                        File.WriteAllBytes(saveFileFromServer.FileName, contents);
                    }
                    Process.Start(saveFileFromServer.FileName);
                }
                logDLL.DownloadLog(UserId5, BelgeNo, downloadFileTuple.Item2);
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
            Program.dataBaseConnection.Close();
            string detailFileCmdText = "SELECT blg.belgeVeriTipiveAdi FROM belgelerim AS blg INNER JOIN kullanicilar AS klnc ON blg.kullaniciNo = klnc.kullaniciNo WHERE belgeNo = @belgeNo";
            using (SqlCommand detailFileCmd = new SqlCommand(detailFileCmdText, Program.dataBaseConnection))
            {
                detailFileCmd.Parameters.AddWithValue("@belgeNo", BelgeNo);
                Program.dataBaseConnection.Open();
                using (SqlDataReader detailFileReader = detailFileCmd.ExecuteReader())
                {
                    if (detailFileReader.Read())
                    {
                        string filePath = (Program.serverFilePath + detailFileReader["belgeVeriTipiveAdi"].ToString());
                        if (File.Exists(filePath))
                        {
                            DetailFileForm_Download();
                        }
                    }
                }
            }
            Program.dataBaseConnection.Close();
        }
        private void DetailFileForm_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}