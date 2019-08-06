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

namespace AYTO_BYS_Projesi
{
    public partial class BelgeDetayiEkrani : Form
    {
        FileDetailDLL fileDetailDLL = new FileDetailDLL();
        LogDLL logDLL = new LogDLL();

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
            //Item1 = fileTitle, Item2 = fileName, Item3 = fileExplain, Item4 = fileDate, Item5 = addedFromUser
            var labelGridTuple = fileDetailDLL.LabelGridFromDataGridView(BelgeNo);
            
            DetailFile_FileTitleLabel.Text = labelGridTuple.Item1;
            DetailFile_FileNameLinkLabel.Text = labelGridTuple.Item2;
            DetailFile_FileExplain_RichTextBox.Text = labelGridTuple.Item3;
            DetailFile_FileDateLabel.Text = labelGridTuple.Item4;
            DetailFile_AddedFromUserLabel.Text = labelGridTuple.Item5;
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
            fileDetailDLL.LinkClicked_OpenFileEvent(BelgeNo);
        }

        private void DetailFileForm_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailFileForm_DownloadButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            //Item1 = returnValue, Item2 = fileTypeAndName, Item3 = fileDirectory
            var downloadFileTuple = fileDetailDLL.DownloadButtonClick(BelgeNo);
            if(downloadFileTuple.Item1 == "true")
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
                    FileStream saveFileStream = File.OpenRead(serverPath);
                    byte[] contents = new byte[saveFileStream.Length];
                    saveFileStream.Read(contents, 0, (int)saveFileStream.Length);
                    saveFileStream.Close();
                    File.WriteAllBytes(saveFileFromServer.FileName, contents);
                }
                logDLL.DownloadLog(UserId5, BelgeNo, downloadFileTuple.Item2);
            }
            MessageBoxManager.Unregister();
        }
    }
}
