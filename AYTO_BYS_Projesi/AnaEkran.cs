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
using System.IO;

namespace AYTO_BYS_Projesi
{
    public partial class AnaEkran : Form
    {
        //OleDbConnection dataBaseCon;
        SqlDataAdapter dataBaseAdapter;
        //SqlCommand dataBaseCmd;
        DataSet dataSet;

        public AnaEkran()
        {
            InitializeComponent();
        }
        //Giriş ekranında kullanıcının kullaniciGiris anahtarını alır.
        public AnaEkran(int LoginId)
        {
            InitializeComponent();
            UserId = LoginId;
        }
        public int UserId { get; set; }

        //Belgelerim veritabanını çağırmak için bir metottur.Aynı zamanda veritabanını yeniler.
        private void RefreshAndFillDataGrid()
        {
            //Veritabanı bağlantısı aktif değilse aktif yap
            Program.dataBaseConnection.Close();
            string dataBaseAdapterText = "SELECT DISTINCT blg.belgeBasligi, blg.belgeAdi, blg.eklenmeTarihi, blg.guncellenmeTarihi, drm.durumAdi, klnc.kullaniciAdi+' '+klnc.kullaniciSoyadi AS klncAdSoyad FROM belgelerim AS blg, durumlar AS drm, kullanicilar AS klnc WHERE blg.durumNo = drm.durumNo AND klnc.kullaniciNo = blg.kullaniciNo ORDER BY blg.eklenmeTarihi DESC";
            dataBaseAdapter = new SqlDataAdapter(dataBaseAdapterText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            dataSet = new DataSet();
            dataBaseAdapter.Fill(dataSet, "belgelerim");
            MyFiles_DataGridView.DataSource = dataSet.Tables["belgelerim"];
            dataBaseAdapter.Dispose();
            // Data Sutün İsimlendirme
            MyFiles_DataGridView.Columns[0].HeaderText = "Başlık";
            MyFiles_DataGridView.Columns[1].HeaderText = "Belge Adı";
            MyFiles_DataGridView.Columns[2].HeaderText = "Eklenme Tarihi";
            MyFiles_DataGridView.Columns[3].HeaderText = "Güncellenme Tarihi";
            MyFiles_DataGridView.Columns[4].HeaderText = "Belge Durumu";
            MyFiles_DataGridView.Columns[5].HeaderText = "Belge Sahibi";

            foreach (DataGridViewRow dataGridRow in this.MyFiles_DataGridView.Rows)
            {
                for (int i = 0; i < dataGridRow.Cells.Count; i++)
                {
                    if (dataGridRow.Cells[i].Value == null || dataGridRow.Cells[i].Value == DBNull.Value || string.IsNullOrWhiteSpace(dataGridRow.Cells[i].Value.ToString()))
                    {
                        MyFiles_FileActions_SendButton.Enabled = false;
                        MyFiles_FileActions_UpdateButton.Enabled = false;
                        MyFiles_FileActions_DeleteButton.Enabled = false;
                        MyFiles_FileActions_CancelButton.Enabled = false;
                        return;
                    }
                }
            }
            Program.dataBaseConnection.Close();
        }
        //Belgeler veritabanında arama ve listeleme amacıyla kullanılır.
        private void SearchAndFillDataGrid()
        {
            //Arama hatalarına karşı önlem olarak trim ve toupper fonksiyonları kullanılmıştır.
            string searchData = FileSearch_CustomTextBox.Text.Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(FileSearch_ComboBox.Text) && !string.IsNullOrWhiteSpace(FileSearch_CustomTextBox.Text))
            {
                if (FileSearch_ComboBox.Text == "Tümü")
                {
                    (MyFiles_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("belgeBasligi LIKE '{0}%' OR belgeAdi LIKE '%{0}%' OR klncAdSoyad LIKE '%{0}%'", searchData);
                }
                else if (FileSearch_ComboBox.Text == "Başlık")
                {
                    (MyFiles_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("belgeBasligi LIKE '{0}%'", searchData);
                }
                else if (FileSearch_ComboBox.Text == "Belge Adı")
                {
                    (MyFiles_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("belgeAdi LIKE '{0}%'", searchData);
                }
                else //(FileSearch_ComboBox.Text == "Gönderici")
                {
                    (MyFiles_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format(" klncAdSoyad LIKE '%{0}%'", searchData);
                }
            }
            else
            {
                ((DataTable)MyFiles_DataGridView.DataSource).DefaultView.RowFilter = string.Empty;
            }
            MyFiles_DataGridView.ClearSelection();
        }

        private void UserIdCheckForPermission()
        {
            Program.dataBaseConnection.Close();
            string userCheckCmdText = "SELECT blg.kullaniciNo FROM belgelerim AS blg WHERE blg.belgeAdi = @belgeAdi";
            SqlCommand userCheckCmd = new SqlCommand(userCheckCmdText, Program.dataBaseConnection);
            userCheckCmd.Parameters.AddWithValue("@belgeAdi", MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString());
            Program.dataBaseConnection.Open();
            SqlDataReader userCheckReader = userCheckCmd.ExecuteReader();
            if (userCheckReader.Read() && userCheckReader["kullaniciNo"].ToString() == UserId.ToString())
            {
                MyFiles_FileActions_UpdateButton.Enabled = true;
                MyFiles_FileActions_DeleteButton.Enabled = true;
            }
            else
            {
                MyFiles_FileActions_UpdateButton.Enabled = false;
                MyFiles_FileActions_DeleteButton.Enabled = false;
            }
            userCheckReader.Close();
            Program.dataBaseConnection.Close();
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();

            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";
            //Mesajlar Penceresi Pasif
            groupBox1.Visible = false;
            button1.Enabled = false;
            //Veritabanını çağırma
            RefreshAndFillDataGrid();
            //Eylemler penceresi, veritabanı içindeki herhangi
            //bir veriye tıklanıldığı zaman aktif olmaktadır.
            //Başlangıçta pasiftir.
            MyFiles_FileActions_SendButton.Enabled = false;
            MyFiles_FileActions_UpdateButton.Enabled = false;
            MyFiles_FileActions_DeleteButton.Enabled = false;
            MyFiles_FileActions_CancelButton.Enabled = false;
            //Veritabanları sadece okunulabilir haldedir.
            MyFiles_DataGridView.ReadOnly = true;
            ReceivedFiles_DataGridView.ReadOnly = true;
            SentFiles_DataGridView.ReadOnly = true;
            //Combobox "Tümü" elemanının seçili olması
            FileSearch_ComboBox.SelectedIndex = 0;

            MyFiles_DataGridView.ClearSelection();
        }

        private void MyFiles_DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (MyFiles_DataGridView.Rows.Count == 0 || MyFiles_DataGridView.Rows == null)
            {
                MyFiles_FileActions_UpdateButton.Enabled = false;
                MyFiles_FileActions_DeleteButton.Enabled = false;
                MyFiles_FileActions_SendButton.Enabled = false;
                MyFiles_FileActions_CancelButton.Enabled = false;
                //return;
            }
            else
            {
                UserIdCheckForPermission();
                //MyFiles_FileActions_UpdateButton.Enabled = true;
                //MyFiles_FileActions_DeleteButton.Enabled = true;
                MyFiles_FileActions_SendButton.Enabled = true;
                MyFiles_FileActions_CancelButton.Enabled = true;
                //return;
            }
        }
        private void MyFiles_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectedRowName = MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString();

            Program.dataBaseConnection.Close();
            string detailFileCmdText = "SELECT blg.belgeNo FROM belgelerim AS blg WHERE blg.belgeAdi = @belgeAdi";
            SqlCommand detailFileCmd = new SqlCommand(detailFileCmdText, Program.dataBaseConnection);
            detailFileCmd.Parameters.AddWithValue("@belgeAdi", selectedRowName);
            Program.dataBaseConnection.Open();
            SqlDataReader detailFileReader = detailFileCmd.ExecuteReader();
            if (detailFileReader.Read())
            {
                string selectedRowFileNo = detailFileReader["belgeNo"].ToString();
                BelgeDetayiEkrani updateFileForm = new BelgeDetayiEkrani(selectedRowFileNo, UserId);
                //Pencere halihazırda aktif ise yeni pencere açmak
                //yerine varolan pencereyi açar.
                if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeDetayiEkrani))
                {
                    Application.OpenForms.OfType<Form>().First(f => f is BelgeDetayiEkrani).Activate();
                }
                else
                {
                    //Pencere konumunu ekran merkezine taşır.
                    updateFileForm.StartPosition = FormStartPosition.CenterScreen;
                    updateFileForm.Show();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Belge Seçilemedi");
            }
            detailFileReader.Close();
            Program.dataBaseConnection.Close();
        }
        //Columheader'a tıklandığında eylemler penceresi pasif olmaktadır.
        private void MyFiles_DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex == -1)
            {

                if (MyFiles_DataGridView.CurrentRow.Cells[1] == null || MyFiles_DataGridView.CurrentRow.Cells[1].Value == DBNull.Value || string.IsNullOrWhiteSpace(MyFiles_DataGridView.CurrentRow.Cells[1].ToString()))
                {
                    UserIdCheckForPermission();
                    MyFiles_FileActions_SendButton.Enabled = false;
                    MyFiles_FileActions_CancelButton.Enabled = false;
                    //return;
                }
                else
                {
                    UserIdCheckForPermission();
                    MyFiles_FileActions_SendButton.Enabled = true;
                    MyFiles_FileActions_CancelButton.Enabled = true;
                    //return;
                }
            }
            else
            {
                MyFiles_FileActions_SendButton.Enabled = false;
                MyFiles_FileActions_UpdateButton.Enabled = false;
                MyFiles_FileActions_DeleteButton.Enabled = false;
                MyFiles_FileActions_CancelButton.Enabled = false;
            }
        }
        //Çıkış Eylemi
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            DialogResult exitDialog = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (exitDialog == DialogResult.Yes)
            {
                NormalUserLog("exit", "");
                Application.Exit();
            }
        }
        //Oturum Kapatma Eylemi
        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkrani loginForm = new GirisEkrani();
            this.Close();
            loginForm.Show();
            NormalUserLog("exit", "");
        }
        //Mesajlar penceresi ve butonları aktif eder.
        private void MessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button1.Enabled = true;
        }

        //Mesajlar penceresini gizler ve butonları pasifleştirir.
        //İstemsiz eylemlerin engellenmesi sağlanmaktadır. 
        /////////////////////DÜZENLE
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            button1.Enabled = false;
        }
        //EYLEMLER (Yeni Belge, Belge Gönderme, Belge Güncelleme, Belge Silme, Eylem Penceresi İptali)
        //Yeni Belge Ekranı
        private void MyFiles_NewFileButton_Click(object sender, EventArgs e)
        {
            YeniBelgeEkrani newFileForm = new YeniBelgeEkrani(UserId);
            //Pencere halihazırda aktif ise yeni pencere açmak
            //yerine varolan pencereyi açar.
            if (Application.OpenForms.OfType<Form>().Any(f => f is YeniBelgeEkrani))
            {
                Application.OpenForms.OfType<Form>().First(f => f is YeniBelgeEkrani).Activate();
            }
            else
            {
                //Pencere konumunu ekran merkezine taşır.
                newFileForm.StartPosition = FormStartPosition.CenterScreen;
                newFileForm.AddNewFileEventH += RefreshAndFillDataGrid;
                newFileForm.Show();
                this.Show();
            }
        }
        private void MyFiles_FileActions_SendButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (MyFiles_DataGridView.Rows == null || MyFiles_DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Belge yok!");
                //return;
            }
            else
            {
                string selectedRowName = MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString();

                Program.dataBaseConnection.Close();
                string selectedFileCmdText = "SELECT blg.belgeNo FROM belgelerim AS blg WHERE blg.belgeAdi = @belgeAdi";
                SqlCommand selectedFileCmd = new SqlCommand(selectedFileCmdText, Program.dataBaseConnection);
                selectedFileCmd.Parameters.AddWithValue("@belgeAdi", selectedRowName);
                Program.dataBaseConnection.Open();
                SqlDataReader selectedFileReader = selectedFileCmd.ExecuteReader();
                if (selectedFileReader.Read())
                {
                    string selectedRowFileNo = selectedFileReader["belgeNo"].ToString();
                    BelgeGondermeEkrani sendFileForm = new BelgeGondermeEkrani(selectedRowFileNo, UserId);
                    //Pencere halihazırda aktif ise yeni pencere açmak
                    //yerine varolan pencereyi açar.
                    if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGondermeEkrani))
                    {
                        Application.OpenForms.OfType<Form>().First(f => f is BelgeGondermeEkrani).Activate();
                    }
                    else
                    {
                        //Pencere konumunu ekran merkezine taşır.
                        sendFileForm.StartPosition = FormStartPosition.CenterScreen;
                        sendFileForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Belge Seçilemedi");
                }
                selectedFileReader.Close();
                //return;
            }
            MessageBoxManager.Unregister();
            Program.dataBaseConnection.Close();
        }
        private void MyFiles_FileActions_UpdateButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (MyFiles_DataGridView.CurrentRow.Cells[0] == null || MyFiles_DataGridView.CurrentRow.Cells[0].Value == DBNull.Value || string.IsNullOrWhiteSpace(MyFiles_DataGridView.CurrentRow.Cells[0].ToString()))
            {
                MessageBox.Show("Belge Seçilemedi");
                //return;
            }
            else
            {
                string selectedRowName = MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString();

                Program.dataBaseConnection.Close();
                string selectedFileCmdText = "SELECT blg.belgeNo FROM belgelerim AS blg WHERE blg.belgeAdi = @belgeAdi";
                SqlCommand selectedFileCmd = new SqlCommand(selectedFileCmdText, Program.dataBaseConnection);
                selectedFileCmd.Parameters.AddWithValue("@belgeAdi", selectedRowName);
                Program.dataBaseConnection.Open();
                SqlDataReader selectedFileReader = selectedFileCmd.ExecuteReader();
                if (selectedFileReader.Read())
                {
                    string selectedRowFileNo = selectedFileReader["belgeNo"].ToString();
                    BelgeGuncellemeEkrani updateFileForm = new BelgeGuncellemeEkrani(selectedRowFileNo, UserId, UserId);
                    //Pencere halihazırda aktif ise yeni pencere açmak
                    //yerine varolan pencereyi açar.
                    if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGuncellemeEkrani))
                    {
                        Application.OpenForms.OfType<Form>().First(f => f is BelgeGuncellemeEkrani).Activate();
                    }
                    else
                    {
                        //Pencere konumunu ekran merkezine taşır.
                        updateFileForm.StartPosition = FormStartPosition.CenterScreen;
                        updateFileForm.UpdateFileEventH += RefreshAndFillDataGrid;
                        updateFileForm.Show();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Belge Seçilemedi");
                }
                selectedFileReader.Close();
                //return;
            }
            MessageBoxManager.Unregister();
            Program.dataBaseConnection.Close();
        }
        //Belge Silme
        private void MyFiles_FileActions_DeleteButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (MyFiles_DataGridView.CurrentRow.Cells[0].Value == null || MyFiles_DataGridView.CurrentRow.Cells[0].Value == DBNull.Value || string.IsNullOrWhiteSpace(MyFiles_DataGridView.CurrentRow.Cells[0].ToString()))
            {
                MessageBox.Show("Belge Seçilemedi");
                //return;
            }
            else
            {
                if (MyFiles_DataGridView.CurrentRow.Cells[0].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Lütfen bir belge seçiniz.");
                }
                else
                {
                    String deleteMessage = "Belgeyi silmek istediğinize emin misiniz?";
                    String deleteTitle = "Uyarı!";
                    MessageBoxButtons deleteButtons = MessageBoxButtons.YesNo;
                    DialogResult deleteResult = MessageBox.Show(deleteMessage, deleteTitle, deleteButtons);
                    if (deleteResult == DialogResult.Yes)
                    {
                        string deletedFileInsertCmdText = "INSERT INTO silinenBelgeler (silinenKullaniciNo, silinenBelgeNo, silinenBelgeBasligi, silinenBelgeAdi, silinenBelgeDizini, silinenBelgeVeriTipiveAdi, silinenBelgeServerDizini, silinenBelgeAciklamasi, silinenEklenmeTarihi, silinenSistemEklenmeTarihi, silinenGuncellenmeTarihi, silinenSistemGuncellenmeTarihi, silinenGuncelleyenKisiNo, silinenDurumNo) SELECT kullaniciNo, belgeNo, belgeBasligi, belgeAdi, belgeDizini, belgeVeriTipiveAdi, belgeServerDizini, belgeAciklamasi, eklenmeTarihi, sistemEklenmeTarihi, guncellenmeTarihi, sistemGuncellenmeTarihi, guncelleyenKisiNo, durumNo FROM belgelerim WHERE belgeAdi = @gelenVeri";

                        string deletedByCmdText = "UPDATE silinenBelgeler SET silenKisi = @silenKisi WHERE silinenBelgeAdi = @gelenVeri";

                        string deleteFileCmdText = "DELETE FROM belgelerim WHERE belgeAdi = @belgeAdi";

                        SqlCommand deletedFileInsertCmd = new SqlCommand(deletedFileInsertCmdText, Program.dataBaseConnection);
                        deletedFileInsertCmd.Parameters.AddWithValue("@gelenVeri", MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString());
                        Program.dataBaseConnection.Open();
                        deletedFileInsertCmd.ExecuteNonQuery();
                        Program.dataBaseConnection.Close();

                        SqlCommand deletedByCmd = new SqlCommand(deletedByCmdText, Program.dataBaseConnection);
                        deletedByCmd.Parameters.AddWithValue("@silenKisi", UserId);
                        deletedByCmd.Parameters.AddWithValue("@gelenVeri", MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString());
                        Program.dataBaseConnection.Open();
                        deletedByCmd.ExecuteNonQuery();
                        Program.dataBaseConnection.Close();

                        SqlCommand deleteFileCmd = new SqlCommand(deleteFileCmdText, Program.dataBaseConnection);
                        deleteFileCmd.Parameters.AddWithValue("@belgeAdi", MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString());
                        Program.dataBaseConnection.Open();
                        deleteFileCmd.ExecuteNonQuery();

                        NormalUserLog("delete", MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString());
                        RefreshAndFillDataGrid();
                    }
                }
                //return;
            }
            MessageBoxManager.Unregister();
            Program.dataBaseConnection.Close();
        }
        //Eylemler Penceresi İptal Etme
        private void MyFiles_FileActions_CancelButton_Click(object sender, EventArgs e)
        {
            //Formların aktifliği kontrol ederek kapatır.
            if (Application.OpenForms.OfType<Form>().Any(f => f is YeniBelgeEkrani))
            {
                Application.OpenForms.OfType<Form>().First(f => f is YeniBelgeEkrani).Close();
            }
            if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGondermeEkrani))
            {
                Application.OpenForms.OfType<Form>().First(f => f is BelgeGondermeEkrani).Close();
            }
            if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGuncellemeEkrani))
            {
                Application.OpenForms.OfType<Form>().First(f => f is BelgeGuncellemeEkrani).Close();
            }
            //Veritabanı eylem penceresini iptal edilmesi durumunda pasifleştirir.
            MyFiles_FileActions_SendButton.Enabled = false;
            MyFiles_FileActions_UpdateButton.Enabled = false;
            MyFiles_FileActions_DeleteButton.Enabled = false;
            MyFiles_FileActions_CancelButton.Enabled = false;

            MyFiles_DataGridView.ClearSelection();
        }
        //Arama ve Filtreleme
        private void CustomTextboxTextChanged_ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFillDataGrid();
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
        //Delete, Exit
        private void NormalUserLog(string value, string fileName)
        {
            string fileNoinDB = "";
            Program.dataBaseConnection.Close();
            SqlCommand fileNoCmd = new SqlCommand("SELECT silinenBelgeNo FROM silinenBelgeler WHERE silinenBelgeAdi = @belgeAdi", Program.dataBaseConnection);
            fileNoCmd.Parameters.AddWithValue("@belgeAdi", fileName);
            Program.dataBaseConnection.Open();
            SqlDataReader fileNoReader = fileNoCmd.ExecuteReader();
            if (fileNoReader.Read())
            {
                fileNoinDB = fileNoReader["silinenBelgeNo"].ToString();
            }
            else
            {
                fileNoinDB = "";
            }
            fileNoReader.Close();
            Program.dataBaseConnection.Close();

            string logFilePath = "";
            string writeText = "";
            if(value == "delete")
            {
                logFilePath = @"C:\Users\Fatih\Desktop\ServerLogKaydi\NormalUserDeleteFileLog.txt";
                writeText = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]: Belge silme işlemini yapan Kullanıcı No: " + UserId + "\tSilinen Belge No: " + fileNoinDB + "\tBelge Adı: " + fileName;
            }
            else if(value == "exit")
            {
                logFilePath = @"C:\Users\Fatih\Desktop\ServerLogKaydi\UserExitLog.txt";
                writeText = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]: Çıkış yapan Kullanıcı No: " + UserId;
            }
            else
            {
                MessageBox.Show("Hata: AnaEkran - NormalUserLog");
            }
            FileStream adminLogFS = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            adminLogFS.Close();
            File.AppendAllText(logFilePath, Environment.NewLine + writeText);
        }
    }
}
