﻿using System;
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
using AYTO.AdminPage;
using AYTO.Log;

namespace AYTO_BYS_Projesi
{
    public partial class AdminPanel : Form
    {
        AdminPageDLL adminPageDLL = new AdminPageDLL();
        LogDLL logDLL = new LogDLL();

        private string tableName = "";
        private string datagridColumnName = "";
        private string columnName = "";
        private string columnSecondName = "";
        private string columnTitle = "";
        DataSet dataSet;
        public AdminPanel()
        {
            InitializeComponent();
        }
        public string BelgeNo { get; set; }
        public AdminPanel(int admin_UserId)
        {
            InitializeComponent();
            AdminUserId = admin_UserId;
        }
        public int AdminUserId { get; set; }

        //Listeleme
        //Kullanıcıları listeleme 
        private void UsersList()
        {
            Program.dataBaseConnection.Close();
            string usersListAdapterText = "SELECT COUNT(blg.belgeNo) AS belgeToplam, klnc.kullaniciNo, klnc.kullaniciAdi, klnc.kullaniciSoyadi, klnc.kullaniciAktifligi, grv.gorevAdi, klnc.kullaniciKurumu, klnc.sistemKayitTarihi FROM (kullanicilar AS klnc LEFT OUTER JOIN belgelerim AS blg ON klnc.kullaniciNo = blg.kullaniciNo) LEFT OUTER JOIN gorevler AS grv ON klnc.gorevNo = grv.gorevNo GROUP BY klnc.kullaniciNo, klnc.kullaniciAdi, klnc.kullaniciSoyadi, klnc.kullaniciAktifligi, grv.gorevAdi, klnc.kullaniciKurumu, klnc.sistemKayitTarihi";

            SqlDataAdapter usersListAdapter = new SqlDataAdapter(usersListAdapterText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            dataSet = new DataSet();
            usersListAdapter.Fill(dataSet, "kullanicilar");
            AdminPage_DataGridView.DataSource = dataSet.Tables["kullanicilar"];
            usersListAdapter.Dispose();
            // Data Sütun İsimlendirme
            AdminPage_DataGridView.Columns[0].HeaderText = "Sahip Olduğu Belge Sayısı";
            AdminPage_DataGridView.Columns[1].HeaderText = "Kullanıcı No";
            AdminPage_DataGridView.Columns[2].HeaderText = "Ad";
            AdminPage_DataGridView.Columns[3].HeaderText = "Soyad";
            AdminPage_DataGridView.Columns[4].HeaderText = "Kullanıcı Durumu";
            AdminPage_DataGridView.Columns[5].HeaderText = "Görevi";
            AdminPage_DataGridView.Columns[6].HeaderText = "Kurum";
            AdminPage_DataGridView.Columns[7].HeaderText = "Kayıt Tarihi";

            Program.dataBaseConnection.Close();
            tableName = "kullanicilar";
            datagridColumnName = "kullaniciNo";
            columnName = "kullanici";
            columnTitle = "Kullanıcı";
        }
        //Belgeleri Listeleme
        private void FilesList()
        {
            //Veritabanı bağlantısı aktif değilse aktif yap
            Program.dataBaseConnection.Close();
            string filesListAdapterText = "SELECT DISTINCT blg.belgeBasligi, blg.belgeAdi, blg.eklenmeTarihi, blg.guncellenmeTarihi, blg.guncelleyenKisiNo, drm.durumAdi, klnc.kullaniciAdi+' '+klnc.kullaniciSoyadi AS klncAdSoyad FROM belgelerim AS blg, durumlar AS drm, kullanicilar AS klnc WHERE blg.durumNo = drm.durumNo AND klnc.kullaniciNo = blg.kullaniciNo ORDER BY blg.eklenmeTarihi DESC";
            SqlDataAdapter filesListAdapter = new SqlDataAdapter(filesListAdapterText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            dataSet = new DataSet();
            filesListAdapter.Fill(dataSet, "belgelerim");
            AdminPage_DataGridView.DataSource = dataSet.Tables["belgelerim"];
            filesListAdapter.Dispose();
            // Data Sütun İsimlendirme
            AdminPage_DataGridView.Columns[0].HeaderText = "Başlık";
            AdminPage_DataGridView.Columns[1].HeaderText = "Belge Adı";
            AdminPage_DataGridView.Columns[2].HeaderText = "Eklenme Tarihi";
            AdminPage_DataGridView.Columns[3].HeaderText = "Güncellenme Tarihi";
            AdminPage_DataGridView.Columns[4].HeaderText = "Güncelleyen Kişi";
            AdminPage_DataGridView.Columns[5].HeaderText = "Belge Durumu";
            AdminPage_DataGridView.Columns[6].HeaderText = "Belge Sahibi";

            Program.dataBaseConnection.Close();
            tableName = "belgelerim";
            datagridColumnName = "belgeAdi";
            columnName = "belge";
            columnTitle = "Belge";
        }
        //Belge durumları listelmee
        private void FileStatusList()
        {
            Program.dataBaseConnection.Close();
            string fileStatusListAdapterText = "SELECT DISTINCT drm.durumNo, drm.durumAdi, COUNT(blg.belgeNo) FROM durumlar AS drm LEFT OUTER JOIN belgelerim AS blg ON drm.durumNo = blg.durumNo GROUP BY drm.durumNo, drm.durumAdi";
            SqlDataAdapter fileStatusListAdapter = new SqlDataAdapter(fileStatusListAdapterText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            dataSet = new DataSet();
            fileStatusListAdapter.Fill(dataSet, "durumlar");
            AdminPage_DataGridView.DataSource = dataSet.Tables["durumlar"];
            fileStatusListAdapter.Dispose();
            // Data Sütun İsimlendirme
            AdminPage_DataGridView.Columns[0].HeaderText = "Durum No";
            AdminPage_DataGridView.Columns[1].HeaderText = "Durum Adı";
            AdminPage_DataGridView.Columns[2].HeaderText = "Duruma Sahip Olan Belge Sayısı";

            Program.dataBaseConnection.Close();
            tableName = "durumlar";
            datagridColumnName = "durumAdi";
            columnName = "durum";
            columnTitle = "Durum";
        }
        //Görevler Listeleme
        private void PositionList()
        {
            Program.dataBaseConnection.Close();
            string positionListAdapterText = "SELECT DISTINCT grv.gorevNo, grv.gorevAdi, COUNT(klnc.kullaniciNo) FROM gorevler AS grv LEFT OUTER JOIN kullanicilar AS klnc ON grv.gorevNo = klnc.gorevNo GROUP BY grv.gorevNo, grv.gorevAdi";
            SqlDataAdapter positionListAdapter = new SqlDataAdapter(positionListAdapterText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            dataSet = new DataSet();
            positionListAdapter.Fill(dataSet, "gorevler");
            AdminPage_DataGridView.DataSource = dataSet.Tables["gorevler"];
            positionListAdapter.Dispose();
            // Data Sütun İsimlendirme
            AdminPage_DataGridView.Columns[0].HeaderText = "Görev No";
            AdminPage_DataGridView.Columns[1].HeaderText = "Görev Adı";
            AdminPage_DataGridView.Columns[2].HeaderText = "Çalışan Sayısı";

            Program.dataBaseConnection.Close();
            tableName = "gorevler";
            datagridColumnName = "gorevAdi";
            columnName = "gorev";
            columnTitle = "Görev";
        }
        //Silinen Kullanıcıların Listelemesi
        private void DeletedUserList()
        {
            Program.dataBaseConnection.Close();
            string deletedUserListAdapterText = "SELECT  klnc.kullaniciAdi + ' ' + klnc.kullaniciSoyadi AS silenKisi, SLklnc.silinenKullaniciNo, SLklnc.silinenKullaniciAdi + ' ' +SLklnc.silinenKullaniciSoyadi AS SLklncAdSoyad, grv.gorevAdi, SLklnc.silinenKullaniciKurumu FROM (silinenKullanicilar AS SLklnc INNER JOIN gorevler AS grv ON SLklnc.silinenGorevNo = grv.gorevNo) INNER JOIN kullanicilar AS klnc ON SLklnc.silenKisi = klnc.kullaniciNo ORDER BY SLklnc.silinenKullaniciNo";

            SqlDataAdapter deletedUserListAdapter = new SqlDataAdapter(deletedUserListAdapterText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            dataSet = new DataSet();
            deletedUserListAdapter.Fill(dataSet, "silinenKullanicilar");
            AdminPage_DataGridView.DataSource = dataSet.Tables["silinenKullanicilar"];
            deletedUserListAdapter.Dispose();
            //Data Sütun
            AdminPage_DataGridView.Columns[0].HeaderText = "Silen Yetkili";
            AdminPage_DataGridView.Columns[1].HeaderText = "Silinen Kullanıcı No";
            AdminPage_DataGridView.Columns[2].HeaderText = "Silinen Kullanıcı";
            AdminPage_DataGridView.Columns[3].HeaderText = "Görevi";
            AdminPage_DataGridView.Columns[4].HeaderText = "Kurumu";
            AdminPage_DataGridView.Columns[0].HeaderCell.Style.Font = new Font("Microsoft Sans Serif",9F,FontStyle.Bold);

            Program.dataBaseConnection.Close();
            tableName = "silinenKullanicilar";
            datagridColumnName = "silinenKullaniciNo";
            columnName = "klncVeri";
            columnTitle = "Silinen Kullanıcı";
        }
        //Silinen Belgelerin Listelenmesi
        private void DeletedFilesList()
        {
            Program.dataBaseConnection.Close();
            string deletedfilesListAdapterText = "SELECT klnc.kullaniciAdi + ' ' + klnc.kullaniciSoyadi AS silenKisi, SLblg.silinenBelgeNo, SLblg.silinenBelgeAdi, SLblg.silinenSistemEklenmeTarihi, SLblg.silinenSistemGuncellenmeTarihi FROM silinenBelgeler AS SLblg INNER JOIN kullanicilar AS klnc ON SLblg.silenKisi = klnc.kullaniciNo ORDER BY SLblg.silinenBelgeNo";

            SqlDataAdapter deletedFilesListAdapter = new SqlDataAdapter(deletedfilesListAdapterText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            dataSet = new DataSet();
            deletedFilesListAdapter.Fill(dataSet, "silinenBelgeler");
            AdminPage_DataGridView.DataSource = dataSet.Tables["silinenBelgeler"];
            deletedFilesListAdapter.Dispose();
            //Data Sütun
            AdminPage_DataGridView.Columns[0].HeaderText = "Silen Yetkili";
            AdminPage_DataGridView.Columns[1].HeaderText = "Silinen Belge No";
            AdminPage_DataGridView.Columns[2].HeaderText = "Silinen Belge Adı";
            AdminPage_DataGridView.Columns[3].HeaderText = "Eklenme Tarihi";
            AdminPage_DataGridView.Columns[4].HeaderText = "Güncellenme Tarihi";
            AdminPage_DataGridView.Columns[0].HeaderCell.Style.Font =new Font("Microsoft Sans Seris", 9F, FontStyle.Bold);

            Program.dataBaseConnection.Close();
            tableName = "silinenBelgeler";
            datagridColumnName = "silinenBelgeNo";
            columnName = "blgVeri";
            columnTitle = "Silinen Belge";
        }
        //Listeleme
        //Arama ve Filtreleme Metotları
        private void KullanicilarSearch()
        {
            string searchData = AdminPanelSearch_CustomTextBox.Text.Trim().ToUpper();
            if (AdminPanelSearch_ComboBox.Text == "Tümü")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("kullaniciAdi LIKE '{0}%' OR kullaniciSoyadi LIKE '{0}%'   OR kullaniciKurumu LIKE '{0}%' OR gorevAdi LIKE '{0}%'", searchData);
            }
            else if(AdminPanelSearch_ComboBox.Text == "Ad Soyad")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("kullaniciAdi LIKE '{0}%' OR kullaniciSoyadi LIKE '{0}%'", searchData);
            }
            else if(AdminPanelSearch_ComboBox.Text == "Görev")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("gorevAdi LIKE '{0}%'", searchData);
            }
            else //if(AdminPanelSearch_ComboBox.Text == "Kurum")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("kullaniciKurumu LIKE '{0}%'", searchData);
            }
        }
        private void BelgelerimSearch()
        {
            string searchData = AdminPanelSearch_CustomTextBox.Text.Trim().ToUpper();
            if (AdminPanelSearch_ComboBox.Text == "Tümü")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("belgeBasligi LIKE '{0}%' OR belgeAdi LIKE '%{0}%' OR klncAdSoyad LIKE '%{0}%'", searchData);
            }
            else if (AdminPanelSearch_ComboBox.Text == "Başlık")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("belgeBasligi LIKE '{0}%'", searchData);
            }
            else  if (AdminPanelSearch_ComboBox.Text == "Belge Adı")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("belgeAdi LIKE '{0}%'", searchData);
            }
            else //(FileSearch_ComboBox.Text == "Gönderici")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("klncAdSoyad LIKE '%{0}%'", searchData);
            }
        }
        private void DurumlarSearch()
        {
            string searchData = AdminPanelSearch_CustomTextBox.Text.Trim().ToUpper();
            (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("durumAdi LIKE '{0}%'", searchData);
        }
        private void GorevlerSearch()
        {
            string searchData = AdminPanelSearch_CustomTextBox.Text.Trim().ToUpper();
            (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("gorevAdi LIKE '{0}%'", searchData);
        }
        private void SilinenKullanicilarSearch()
        {
            string searchData = AdminPanelSearch_CustomTextBox.Text.Trim().ToUpper();
            if(AdminPanelSearch_ComboBox.Text == "Tümü")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("SLklncAdSoyad LIKE '%{0}%' OR silenKisi LIKE '%{0}%'", searchData);
            }
            else if (AdminPanelSearch_ComboBox.Text == "Ad Soyad")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("SLklncAdSoyad LIKE '%{0}%'", searchData);
            }
            else //if(AdminPanelSearch_ComboBox.Text == "Silen Kişi")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("silenKisi LIKE '%{0}%'", searchData);
            }
        }
        private void SilinenBelgelerSearch()
        {
            string searchData = AdminPanelSearch_CustomTextBox.Text.Trim().ToUpper();
            if(AdminPanelSearch_ComboBox.Text == "Tümü")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("silinenBelgeAdi LIKE '{0}%' OR silenKisi LIKE '%{0}%'", searchData);
            }
            else if (AdminPanelSearch_ComboBox.Text == "Belge Adı")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("silinenBelgeAdi LIKE '{0}%'", searchData);
            }
            else //if(AdminPanelSearch_ComboBox.Text == "Silen Kişi")
            {
                (AdminPage_DataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("silenKisi LIKE '%{0}%'", searchData);
            }
        }
        private void SearchAndFillDataGrid()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (!string.IsNullOrWhiteSpace(AdminPanelSearch_ComboBox.Text) || !string.IsNullOrWhiteSpace(AdminPanelSearch_CustomTextBox.Text))
            {
                if(tableName == "kullanicilar")
                {
                    KullanicilarSearch();
                }
                else if(tableName == "belgelerim")
                {
                    BelgelerimSearch();
                }
                else if(tableName == "durumlar")
                {
                    DurumlarSearch();
                }
                else if(tableName == "gorevler")
                {
                    GorevlerSearch();
                }
                else if(tableName == "silinenKullanicilar")
                {
                    SilinenKullanicilarSearch();
                }
                else if(tableName == "silinenBelgeler")
                {
                    SilinenBelgelerSearch();
                }
                else
                {
                    MessageBox.Show("Hata: AdminPanel - SearchandFillDataGrid");
                }
            }
            else
            {
                ((DataTable)AdminPage_DataGridView.DataSource).DefaultView.RowFilter = string.Empty;
            }
            AdminPage_DataGridView.ClearSelection();
            MessageBoxManager.Unregister();
        }
        //Arama ve Filtreleme Metotları
        
        //YeniVeriEkle Form
        private void CallYeniVeriEkleForm()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            YeniVerilEkle addNewDataAdminForm = new YeniVerilEkle(tableName, AdminUserId);
            if (Application.OpenForms.OfType<Form>().Any(f => f is YeniVerilEkle))
            {
                //addNewDataAdminForm.Close();
                Application.OpenForms.OfType<Form>().First(f => f is YeniVerilEkle).Activate();
            }
            else
            {
                //Pencere konumunu ekran merkezine taşır.
                addNewDataAdminForm.StartPosition = FormStartPosition.CenterScreen;
                if(tableName == "kullanicilar")
                {
                    addNewDataAdminForm.AddNewDataEventH += UsersList;
                    addNewDataAdminForm.Show();
                }
                else if(tableName == "belgelerim")
                {
                    addNewDataAdminForm.AddNewDataEventH += FilesList;
                    addNewDataAdminForm.Show();
                }
                else if(tableName == "durumlar")
                {
                    addNewDataAdminForm.AddNewDataEventH += FileStatusList;
                    addNewDataAdminForm.Show();
                }
                else if(tableName == "gorevler")
                {
                    addNewDataAdminForm.AddNewDataEventH += PositionList;
                    addNewDataAdminForm.Show();
                }
                else
                {
                    MessageBox.Show("Hata: CallYeniVeriEkleForm");
                }
            }
            MessageBoxManager.Unregister();
        }
        //Yenileme Metotu
        private void RefreshLogAndDeleteEvent()
        {
            string currentCellValue = AdminPage_DataGridView.CurrentRow.Cells[1].Value.ToString();

            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            logDLL.AdminLog("delete", columnTitle, currentCellValue, AdminUserId, tableName, datagridColumnName);

            adminPageDLL.DeleteDataAfterCheck(currentCellValue, tableName, datagridColumnName);

            if (tableName == "kullanicilar")
                UsersList();
            else if (tableName == "belgelerim")
                FilesList();
            else if (tableName == "durumlar")
                FileStatusList();
            else if (tableName == "gorevler")
                PositionList();
            else if (tableName == "silinenKullanicilar")
                DeletedUserList();
            else if (tableName == "silinenBelgeler")
                DeletedFilesList();
            else
                MessageBox.Show("Hata: Admin Page Delete Button");
            MessageBoxManager.Unregister();
            AdminPage_DataGridView.ClearSelection();
        }
        //Açılan tablolara göre belirli öğeler açılır.
        private void EnabledVisibleTrueItems()
        {
            tableLayoutPanel1.Enabled = true;
            tableLayoutPanel1.Visible = true;
            AdminPanel_AddButton.Enabled = true;
            AdminPanel_UpdateButton.Enabled = true;
        }
        private void DeletedDataEnabledVisibleItems()
        {
            AdminPanelSearch_ComboBox.Enabled = true;
            tableLayoutPanel1.Enabled = true;
            tableLayoutPanel1.Visible = true;
            AdminPanel_AddButton.Enabled = false;
            AdminPanel_UpdateButton.Enabled = false;
            InactiveOrActiveUser_Button.Enabled = false;
            InactiveOrActiveUser_Button.Visible = false;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();

            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";

            tableLayoutPanel1.Enabled = false;
            tableLayoutPanel1.Visible = false;

            AdminPanel_AddButton.Enabled = false;
            AdminPanel_UpdateButton.Enabled = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            DialogResult exitDialog = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (exitDialog == DialogResult.Yes)
            {
                //parentGirisEkrani.Close();
                //this.Close();
                Application.Exit();
                logDLL.AdminLog("exit", "", "", AdminUserId, "", "");
            }
        }
        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBoxManager.Unregister();
            //MessageBoxManager.Register();
            //DialogResult exitDialog = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            //if (exitDialog == DialogResult.Yes)
            //{
            //    //parentGirisEkrani.Close();
            //    //this.Close();
            //    Application.Exit();
            //}   
        }
        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkrani loginForm = new GirisEkrani();
            this.Close();
            loginForm.Show();
            logDLL.AdminLog("exit", "", "", AdminUserId, "", "");
        }
        //Veriler
        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelSearch_CustomTextBox.Clear();
            AdminPanelSearch_ComboBox.Items.Clear();
            AdminPanelSearch_ComboBox.Items.Add("Tümü");
            AdminPanelSearch_ComboBox.Items.Add("Ad Soyad");
            AdminPanelSearch_ComboBox.Items.Add("Görev");
            AdminPanelSearch_ComboBox.Items.Add("Kurum");
            AdminPanelSearch_ComboBox.Enabled = true;
            InactiveOrActiveUser_Button.Enabled = true;
            InactiveOrActiveUser_Button.Visible = true;
            EnabledVisibleTrueItems();
            UsersList();
        }

        private void BelgelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelSearch_CustomTextBox.Clear();
            AdminPanelSearch_ComboBox.Items.Clear();
            AdminPanelSearch_ComboBox.Items.Add("Tümü");
            AdminPanelSearch_ComboBox.Items.Add("Başlık");
            AdminPanelSearch_ComboBox.Items.Add("Belge Adı");
            AdminPanelSearch_ComboBox.Items.Add("Belge Sahibi");
            AdminPanelSearch_ComboBox.Enabled = true;
            InactiveOrActiveUser_Button.Enabled = false;
            InactiveOrActiveUser_Button.Visible = false;
            EnabledVisibleTrueItems();
            FilesList();
        }

        private void DurumlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelSearch_CustomTextBox.Clear();
            AdminPanelSearch_ComboBox.Items.Clear();
            AdminPanelSearch_ComboBox.Enabled = false;
            InactiveOrActiveUser_Button.Enabled = false;
            InactiveOrActiveUser_Button.Visible = false;
            EnabledVisibleTrueItems();
            FileStatusList();
        }

        private void GörevlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelSearch_CustomTextBox.Clear();
            AdminPanelSearch_ComboBox.Items.Clear();
            AdminPanelSearch_ComboBox.Enabled = false;
            InactiveOrActiveUser_Button.Enabled = false;
            InactiveOrActiveUser_Button.Visible = false;
            EnabledVisibleTrueItems();
            PositionList();
        }
        //Silinen Veriler
        private void SilinenKullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelSearch_CustomTextBox.Clear();
            AdminPanelSearch_ComboBox.Items.Clear();
            AdminPanelSearch_ComboBox.Items.Add("Tümü");
            AdminPanelSearch_ComboBox.Items.Add("Ad Soyad");
            AdminPanelSearch_ComboBox.Items.Add("Silen Kişi");
            DeletedDataEnabledVisibleItems();
            DeletedUserList();
        }

        private void SilinenBelgelerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdminPanelSearch_CustomTextBox.Clear();
            AdminPanelSearch_ComboBox.Items.Clear();
            AdminPanelSearch_ComboBox.Items.Add("Tümü");
            AdminPanelSearch_ComboBox.Items.Add("Belge Adı");
            AdminPanelSearch_ComboBox.Items.Add("Silen Kişi");
            DeletedDataEnabledVisibleItems();
            DeletedFilesList();
        }

        private void AdminPanel_AddButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (tableName == "" || tableName == null || string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("Tablo İsmi Yok");
            }
            else if (tableName == "belgelerim")
            {
                YeniBelgeEkrani addNewFileAdminForm = new YeniBelgeEkrani(AdminUserId);
                if (Application.OpenForms.OfType<Form>().Any(f => f is YeniBelgeEkrani))
                {
                    Application.OpenForms.OfType<Form>().First(f => f is YeniBelgeEkrani).Activate();
                }
                else
                {
                    addNewFileAdminForm.StartPosition = FormStartPosition.CenterScreen;
                    addNewFileAdminForm.AddNewFileEventH += FilesList;
                    addNewFileAdminForm.Show();
                }
            }
            else
            {
                if(tableName == "kullanicilar")
                {
                    //Kullanıcı kaydı için görev şart olduğundan dolayı bu iki tablonun içerik kontrolü yapılır
                    string returnValue = adminPageDLL.CheckDataBaseTablePosition();
                    if(returnValue == "false")
                    {
                        MessageBox.Show("Herhangi bir görev olmadığından dolayı yeni kullanıcı ekleyemezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else //true
                    {
                        CallYeniVeriEkleForm();
                    }
                }
                else
                {
                    CallYeniVeriEkleForm();
                }
            }
            MessageBoxManager.Unregister();
        }
        private void AdminPanel_UpdateButton_Click(object sender, EventArgs e)
        {
            string currentCellValue = AdminPage_DataGridView.CurrentRow.Cells[1].Value.ToString();
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (AdminPage_DataGridView.Rows == null || AdminPage_DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Herhangi bir veri yok!");
                //return;
            }
            else
            {
                if (tableName == "belgelerim")
                {
                    //Item1 = returnValue, Item2 = selectedRowFileNo, Item3 = selectedRowUserNo
                    var updateFileTuple = adminPageDLL.AdminUpdateFile(AdminPage_DataGridView.CurrentRow.Cells[1].Value.ToString());
                    if(updateFileTuple.Item1 == "true")
                    {
                        BelgeGuncellemeEkrani updateFileForm = new BelgeGuncellemeEkrani(updateFileTuple.Item2, updateFileTuple.Item3, AdminUserId);
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
                            updateFileForm.UpdateFileEventH += FilesList;
                            updateFileForm.Show();
                            this.Show();
                        }
                    }
                    else //false
                    {
                        MessageBox.Show("Belge Seçilemedi");
                    }
                }
                else
                {
                    if (tableName != "kullanicilar")
                        columnSecondName = "Adi";
                    else
                        columnSecondName = "No";


                    //Item1 = returnValue, Item2 = selectedRowColumnDataNo
                    var updateCommonTuple = adminPageDLL.AdminUpdateCommon(currentCellValue, columnName, tableName, columnSecondName);
                    if(updateCommonTuple.Item1 == "true")
                    {
                        VeriGuncelle updateDataForm = new VeriGuncelle(updateCommonTuple.Item2, tableName, AdminUserId);
                        if (Application.OpenForms.OfType<Form>().Any(f => f is VeriGuncelle))
                        {
                            Application.OpenForms.OfType<Form>().First(f => f is VeriGuncelle).Activate();
                        }
                        else
                        {
                            //Pencere konumunu ekran merkezine taşır.
                            updateDataForm.StartPosition = FormStartPosition.CenterScreen;
                            if (tableName == "kullanicilar")
                            {
                                updateDataForm.UpdateDataEventH += UsersList;
                                updateDataForm.Show();
                            }
                            else if (tableName == "durumlar")
                            {
                                updateDataForm.UpdateDataEventH += FileStatusList;
                                updateDataForm.Show();
                            }
                            else if (tableName == "gorevler")
                            {
                                updateDataForm.UpdateDataEventH += PositionList;
                                updateDataForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Hata: AdminUpdateGlobalMethod");
                            }
                        }
                    }
                    else //false
                    {
                        MessageBox.Show("Veri Seçilemedi");
                    }
                }
            }
            MessageBoxManager.Unregister();
        }
        private void AdminPanel_DeleteButton_Click(object sender, EventArgs e)
        {

            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            AdminPage_DataGridView.ClearSelection();
            if (AdminPage_DataGridView.Rows == null || AdminPage_DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Herhangi bir veri yok!");
                //return;
            }
            else
            {
                if (AdminPage_DataGridView.Rows.Count.ToString() == string.Empty)
                {
                    MessageBox.Show("Lütfen bir veri seçiniz.");
                }
                else
                {
                    String deleteMessage = "Veriyi silmek istediğinize emin misiniz?";
                    String deleteTitle = "Uyarı!";
                    MessageBoxButtons deleteButtons = MessageBoxButtons.YesNo;
                    DialogResult deleteResult = MessageBox.Show(deleteMessage, deleteTitle, deleteButtons);
                    if (deleteResult == DialogResult.Yes)
                    {
                        string currentCellValue = AdminPage_DataGridView.CurrentRow.Cells[1].Value.ToString();

                        if (tableName == "belgelerim")
                        {
                            //Verilerin silinmesi öncesi bu veriler başka tablolara taşınır.
                            adminPageDLL.InsertDataToDatabaseBeforeDelete(currentCellValue, tableName, AdminUserId);
                            RefreshLogAndDeleteEvent();
                        }
                        else if(tableName == "silinenKullanicilar" || tableName == "silinenBelgeler")
                        {
                            RefreshLogAndDeleteEvent();
                        }
                        else
                        {
                            //Verilerin ilişkisinin kontrolü
                            //Item1 = returnValue, Item2 = datagridColumnValue
                            var checkDeleteTuple = adminPageDLL.RelationShipCheckBeforeDelete(currentCellValue, tableName, datagridColumnName);
                            if (checkDeleteTuple.Item1 == "true")
                            {
                                MessageBox.Show(columnTitle + " tablosundaki " + checkDeleteTuple.Item2 + " verisi, başka verilerle ilişkili olduğundan silinemiyor!");
                            }
                            else // false
                            {
                                if(tableName == "kullanicilar" || tableName == "belgelerim")
                                {
                                    adminPageDLL.InsertDataToDatabaseBeforeDelete(currentCellValue, tableName, AdminUserId);
                                    RefreshLogAndDeleteEvent();
                                }
                                else
                                {
                                    RefreshLogAndDeleteEvent();
                                }
                            }
                        }
                    }
                    //return;
                }
            }
            MessageBoxManager.Unregister();
        }
        //Kullanıcının aktifliğini değiştirir. Aktif olmayan kullanıcılar programa giriş yapamaz.
        private void InactiveOrActiveUser_Button_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            string currentCellValue = AdminPage_DataGridView.CurrentRow.Cells[1].Value.ToString();
            string selectedData = AdminPage_DataGridView.CurrentRow.Cells[4].Value.ToString();
            if (selectedData == "True")
            {
                String deleteMessage = "Kullanıcıyı pasifleştirmek istediğinize emin misiniz?";
                String deleteTitle = "Uyarı!";
                MessageBoxButtons deleteButtons = MessageBoxButtons.YesNo;
                DialogResult deleteResult = MessageBox.Show(deleteMessage, deleteTitle, deleteButtons);
                if (deleteResult == DialogResult.Yes)
                {
                    adminPageDLL.InactiveOrActiveUser(currentCellValue, 0);
                    logDLL.AdminLog("active", columnTitle, currentCellValue, AdminUserId, tableName, datagridColumnName);
                    UsersList();
                }
            }
            else if (selectedData == "False")
            {
                String deleteMessage = "Kullanıcıyı aktifleştirmek istediğinize emin misiniz?";
                String deleteTitle = "Uyarı!";
                MessageBoxButtons deleteButtons = MessageBoxButtons.YesNo;
                DialogResult deleteResult = MessageBox.Show(deleteMessage, deleteTitle, deleteButtons);
                if (deleteResult == DialogResult.Yes)
                {
                    adminPageDLL.InactiveOrActiveUser(currentCellValue, 1);
                    logDLL.AdminLog("active", columnTitle, currentCellValue, AdminUserId, tableName, datagridColumnName);
                    UsersList();
                }
            }
            else
            {
                MessageBox.Show("Hata: AdminPanel-InactiveOrActiveUser");
            }
            MessageBoxManager.Unregister();
        }
        //Arama ve Filtreleme
        private void CustomTextboxTextChanged_ComboBoxSelectedIndexChanged (object sender, EventArgs e)
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