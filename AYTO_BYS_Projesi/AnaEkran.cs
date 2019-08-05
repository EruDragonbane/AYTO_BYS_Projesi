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
using AYTO.MainPage;
using AYTO.Log;

namespace AYTO_BYS_Projesi
{
    public partial class AnaEkran : Form
    {
        MainPageDLL mainPageDLL = new MainPageDLL();
        LogDLL logDLL = new LogDLL();

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
                        ActionsGroupBoxEnabledActivity("allElementsFalse");
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
        //Belge üzerinde eylem yapmak isteyen kullanıcının yetkilerini kontrol eder.
        private void UserIdCheckForPermission()
        {
            if (MyFiles_DataGridView.Rows == null || MyFiles_DataGridView.Rows.Count == 0)
            {
                ActionsGroupBoxEnabledActivity("allElementsFalse");
            }
            else
            {
                string currentCellValue = MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString();
                string returnValue = mainPageDLL.UserIdCheckForPermissin(currentCellValue, UserId);

                if (returnValue == "true")
                {
                    ActionsGroupBoxEnabledActivity("updateAndDeleteTrue");
                }
                else
                {
                    ActionsGroupBoxEnabledActivity("updateAndDeleteFalse");
                }
            }
        }
        //Formların aktifliğini kontrol ederek kapatır.
        private void FormActivityCheck()
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
            if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeDetayiEkrani))
            {
                Application.OpenForms.OfType<Form>().First(f => f is BelgeDetayiEkrani).Close();
            }
        }
        //Eylemler penceresi etkinliği --Tamamı pasif
        private void ActionsGroupBoxEnabledActivity(string enabledStatus)
        {
            if(enabledStatus == "allElementsFalse")
            {
                MyFiles_FileActions_SendButton.Enabled = false;
                MyFiles_FileActions_UpdateButton.Enabled = false;
                MyFiles_FileActions_DeleteButton.Enabled = false;
                MyFiles_FileActions_CancelButton.Enabled = false;
            }
            else if(enabledStatus == "updateAndDeleteTrue")
            {
                MyFiles_FileActions_UpdateButton.Enabled = true;
                MyFiles_FileActions_DeleteButton.Enabled = true;
            }
            else if(enabledStatus == "updateAndDeleteFalse")
            {
                MyFiles_FileActions_UpdateButton.Enabled = false;
                MyFiles_FileActions_DeleteButton.Enabled = false;
            }
            else if(enabledStatus == "sendAndCancelTrue")
            {
                MyFiles_FileActions_SendButton.Enabled = true;
                MyFiles_FileActions_CancelButton.Enabled = true;
            }
            else if(enabledStatus == "sendAndCancelFalse")
            {
                MyFiles_FileActions_SendButton.Enabled = false;
                MyFiles_FileActions_CancelButton.Enabled = false;
            }
            else
            {
                return;
            }

        }
        //Çıkış Eylemi
        private void FormClosingEvent()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            DialogResult exitDialog = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (exitDialog == DialogResult.Yes)
            {
                this.FormClosing -= AnaEkran_FormClosing;
                logDLL.NormalUserLog("exit", "", UserId);
                Application.Exit();
            }
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
            ActionsGroupBoxEnabledActivity("allElementsFalse");
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
                ActionsGroupBoxEnabledActivity("allElementsFalse");
                //return;
            }
            else
            {
                UserIdCheckForPermission();
                ActionsGroupBoxEnabledActivity("sendAndCancelTrue");
                //return;
            }
        }
        private void MyFiles_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            if (MyFiles_DataGridView.Rows == null || MyFiles_DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Herhangi bir veri yok!");
                //return;
            }
            else
            {
                string selectedRowName = MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString();
                //Item1 = returnValue, Item2 = fileNo
                var cellDoubleClickTuple = mainPageDLL.CellDoubleClick(selectedRowName);
                if (cellDoubleClickTuple.Item1 == "true")
                {
                    string selectedRowFileNo = cellDoubleClickTuple.Item2;
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
            }
            MessageBoxManager.Unregister();
        }
        //Columheader'a tıklandığında eylemler penceresi pasif olmaktadır.
        private void MyFiles_DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex == -1)
            {

                if (MyFiles_DataGridView.CurrentRow.Cells[1] == null || MyFiles_DataGridView.CurrentRow.Cells[1].Value == DBNull.Value || string.IsNullOrWhiteSpace(MyFiles_DataGridView.CurrentRow.Cells[1].ToString()))
                {
                    UserIdCheckForPermission();
                    ActionsGroupBoxEnabledActivity("sendAndCancelFalse");
                    //return;
                }
                else
                {
                    UserIdCheckForPermission();
                    ActionsGroupBoxEnabledActivity("sendAndCancelTrue");
                    //return;
                }
            }
            else
            {
                ActionsGroupBoxEnabledActivity("allElementsFalse");
            }
        }
        //Çıkış Eylemi
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClosingEvent();
        }
        private void AnaEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingEvent();
        }
        //Profil Penceresi
        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciProfili userProfileForm = new KullaniciProfili(UserId);
            //Pencere halihazırda aktif ise yeni pencere açmak
            //yerine varolan pencereyi açar.
            if (Application.OpenForms.OfType<Form>().Any(f => f is KullaniciProfili))
            {
                Application.OpenForms.OfType<Form>().First(f => f is KullaniciProfili).Activate();
            }
            else
            {
                //Pencere konumunu ekran merkezine taşır.
                userProfileForm.StartPosition = FormStartPosition.CenterScreen;
                userProfileForm.Show();
            }
        }
        //Oturum Kapatma Eylemi
        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            DialogResult exitDialog = MessageBox.Show("Hesaptan çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (exitDialog == DialogResult.Yes)
            {
                this.FormClosing -= AnaEkran_FormClosing;
                GirisEkrani loginForm = new GirisEkrani();
                logDLL.NormalUserLog("exit", "", UserId);
                this.Close();
                loginForm.Show();
            }
            MessageBoxManager.Unregister();
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
                FileSearch_CustomTextBox.Clear();
                Application.OpenForms.OfType<Form>().First(f => f is YeniBelgeEkrani).Activate();
            }
            else
            {
                FileSearch_CustomTextBox.Clear();
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
                //Item1 = returnValue, Item2 = fileNo
                var sendButtonClickTuple = mainPageDLL.SendUpdateButtonsClickForBelgeNo(selectedRowName);
                if (sendButtonClickTuple.Item1 == "true")
                {
                    string selectedRowFileNo = sendButtonClickTuple.Item2;
                    BelgeGondermeEkrani sendFileForm = new BelgeGondermeEkrani(selectedRowFileNo, UserId);
                    //Pencere halihazırda aktif ise yeni pencere açmak
                    //yerine varolan pencereyi açar.
                    if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGondermeEkrani))
                    {
                        FileSearch_CustomTextBox.Clear();
                        Application.OpenForms.OfType<Form>().First(f => f is BelgeGondermeEkrani).Activate();
                    }
                    else
                    {
                        FileSearch_CustomTextBox.Clear();
                        //Pencere konumunu ekran merkezine taşır.
                        sendFileForm.StartPosition = FormStartPosition.CenterScreen;
                        sendFileForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Belge Seçilemedi");
                }
                //return;
            }
            MessageBoxManager.Unregister();
        }
        private void MyFiles_FileActions_UpdateButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (MyFiles_DataGridView.Rows == null || MyFiles_DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Herhangi bir veri yok!");
                //return;
            }
            else
            {
                if (MyFiles_DataGridView.CurrentRow.Cells[0] == null || MyFiles_DataGridView.CurrentRow.Cells[0].Value == DBNull.Value || string.IsNullOrWhiteSpace(MyFiles_DataGridView.CurrentRow.Cells[0].ToString()))
                {
                    MessageBox.Show("Belge Seçilemedi");
                    //return;
                }
                else
                {
                    string selectedRowName = MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString();
                    //Item1 = returnValue, Item2 = fileNo
                    var updateButtonClickTuple = mainPageDLL.SendUpdateButtonsClickForBelgeNo(selectedRowName);
                    if (updateButtonClickTuple.Item1 == "true")
                    {
                        string selectedRowFileNo = updateButtonClickTuple.Item2;
                        BelgeGuncellemeEkrani updateFileForm = new BelgeGuncellemeEkrani(selectedRowFileNo, UserId, UserId);
                        //Pencere halihazırda aktif ise yeni pencere açmak
                        //yerine varolan pencereyi açar.
                        if (Application.OpenForms.OfType<Form>().Any(f => f is BelgeGuncellemeEkrani))
                        {
                            FileSearch_CustomTextBox.Clear();
                            Application.OpenForms.OfType<Form>().First(f => f is BelgeGuncellemeEkrani).Activate();
                        }
                        else
                        {
                            FileSearch_CustomTextBox.Clear();
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
                    //return;
                }
                MessageBoxManager.Unregister();
            }
        }
        //Belge Silme
        private void MyFiles_FileActions_DeleteButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            if (MyFiles_DataGridView.Rows == null || MyFiles_DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Herhangi bir veri yok!");
                //return;
            }
            else
            {
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
                            string currentCellValue = MyFiles_DataGridView.CurrentRow.Cells[1].Value.ToString();
                            mainPageDLL.InsertFileBeforeDelete(currentCellValue, UserId);

                            logDLL.NormalUserLog("delete", currentCellValue, UserId);
                            RefreshAndFillDataGrid();
                            FormActivityCheck();

                            if (MyFiles_DataGridView.Rows == null || MyFiles_DataGridView.Rows.Count == 0)
                            {
                                ActionsGroupBoxEnabledActivity("allElementsFalse");
                            }
                        }
                        else
                        {
                            ActionsGroupBoxEnabledActivity("allElementsFalse");
                        }
                    }
                    //return;
                }
                MyFiles_DataGridView.ClearSelection();
                MessageBoxManager.Unregister();
                Program.dataBaseConnection.Close();
            }
        }
        //Eylemler Penceresi İptal Etme
        private void MyFiles_FileActions_CancelButton_Click(object sender, EventArgs e)
        {
            FormActivityCheck();
            //Veritabanı eylem penceresini iptal edilmesi durumunda pasifleştirir.
            ActionsGroupBoxEnabledActivity("allElementsFalse");
            FileSearch_CustomTextBox.Clear();
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
    }
}
