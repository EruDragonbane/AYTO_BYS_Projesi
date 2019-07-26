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
    public partial class VeriGuncelle : Form
    {
        //ComboBoxNameTableValue
        private int statusValue;
        public VeriGuncelle()
        {
            InitializeComponent();
        }

        public delegate void AddUpdateDataEventHandler();
        public event AddUpdateDataEventHandler UpdateDataEventH;
        public VeriGuncelle(string adminPanel_dataName, string adminPanel_tableName, int AdminUserId)
        {
            InitializeComponent();
            DataFromAdminPanel = adminPanel_dataName;
            TableName = adminPanel_tableName;
            UpdateDataUserId = AdminUserId;
        }
        public string DataFromAdminPanel { get; set; }
        public string TableName { get; set; }
        public int UpdateDataUserId { get; set; }

        //Textboxların ve Combobox'un boş olması durumunda güncelle butonu pasif kalmaktadır.
        private void TextControlForButton()
        {
            if(TableName == "kullanicilar")
            {
                if (UpdateUserName_CustomTextBox.Text.Trim() != string.Empty && UpdateUserSurname_CustomTextBox.Text.Trim() != string.Empty && UpdateUserID_CustomTextBox.Text.Trim() != string.Empty && UpdateUserPosition_ComboBox.Text != string.Empty && UpdateUserAuthority_ComboBox.Text != string.Empty && UpdateUserCorp_CustomTextBox.Text.Trim() != string.Empty)
                {
                    AdminPage_UpdateDataButton.Enabled = true;
                }
                else
                {
                    AdminPage_UpdateDataButton.Enabled = false;
                }
            }
            else if(TableName == "gorevler")
            {
                if (UpdatePosition_CustomTextBox.Text.Trim() != string.Empty)
                {
                    AdminPage_UpdateDataButton.Enabled = true;
                }
                else
                {
                    AdminPage_UpdateDataButton.Enabled = false;
                }
            }
            else if(TableName == "durumlar")
            {
                if (UpdateStatus_CustomTextBox.Text.Trim() != string.Empty)
                {
                    AdminPage_UpdateDataButton.Enabled = true;
                }
                else
                {
                    AdminPage_UpdateDataButton.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Hata: VeriGuncelle-Textcontrol");
            }
        }
        //AdminPanel'den gelen verinin bilgiler
        private void TextGridFromAdminPanel()
        {
            Program.dataBaseConnection.Close();
            string updateFileCmdText = "";
            string columnName = "";
            if (TableName == "durumlar")
            {
                columnName = "durum";
            }
            else if (TableName == "gorevler")
            {
                columnName = "gorev";
            }
            else
            {
                columnName = "";
            }

            if (TableName == "kullanicilar")
            {
                updateFileCmdText = "SELECT klnc.kullaniciAdi, klnc.kullaniciSoyadi, klnc.kullaniciGiris, grv.gorevAdi, ytk.yetkiAdi, klnc.kullaniciKurumu FROM kullanicilar AS klnc INNER JOIN gorevler AS grv ON klnc.gorevNo = grv.gorevNo INNER JOIN yetkiler AS ytk ON klnc.yetkiNo = ytk.yetkiNo WHERE kullaniciNo = @gelenVeri";
            }
            else if (TableName == "durumlar" || TableName == "gorevler")
            {
                updateFileCmdText = "SELECT " + columnName + "Adi FROM " + TableName + " WHERE " + columnName + "No = @gelenVeri";
            }
            else
            {
                MessageBox.Show("Hata: VeriGuncelle-TextGrid");
            }
            SqlCommand updateFileCmd = new SqlCommand(updateFileCmdText, Program.dataBaseConnection);
            updateFileCmd.Parameters.AddWithValue("@gelenVeri", DataFromAdminPanel);
            Program.dataBaseConnection.Open();
            SqlDataReader updateFileReader = updateFileCmd.ExecuteReader();
            if (updateFileReader.Read())
            {
                if (TableName == "kullanicilar")
                {
                    UpdateUserName_CustomTextBox.Text = updateFileReader["kullaniciAdi"].ToString();
                    UpdateUserSurname_CustomTextBox.Text = updateFileReader["kullaniciSoyadi"].ToString();
                    UpdateUserID_CustomTextBox.Text = updateFileReader["kullaniciGiris"].ToString();
                    UpdateUserPosition_ComboBox.Text = updateFileReader["gorevAdi"].ToString();
                    UpdateUserAuthority_ComboBox.Text = updateFileReader["yetkiAdi"].ToString();
                    UpdateUserCorp_CustomTextBox.Text = updateFileReader["kullaniciKurumu"].ToString();
                }
                else if (TableName == "durumlar")
                {
                    UpdateStatus_CustomTextBox.Text = updateFileReader["durumAdi"].ToString();
                }
                else if (TableName == "gorevler")
                {
                    UpdatePosition_CustomTextBox.Text = updateFileReader["gorevAdi"].ToString();
                }
                else
                {
                    MessageBox.Show("Hata: VeriGuncelle-TextGrid");
                }

            }
            updateFileReader.Close();
            Program.dataBaseConnection.Close();
        }

        private void CheckDataMethod()
        {
            string columnName = "";
            string title1 = "";
            if(TableName == "kullanicilar")
            {
                columnName = "kullanici";
                title1 = "Kullanıcıyı";
            }
            else if (TableName == "durumlar")
            {
                columnName = "durum";
                title1 = "Durumu";
            }
            else if (TableName == "gorevler")
            {
                columnName = "gorev";
                title1 = "Görevi";
            }
            else
            {
                columnName = "";
            }

            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            string checkCmdText = "SELECT " + columnName + "  FROM " + TableName + " WHERE " + columnName + "No = @gelenVeri";
            SqlCommand checkCmd = new SqlCommand(checkCmdText, Program.dataBaseConnection);
            checkCmd.Parameters.AddWithValue("@gelenVeri", DataFromAdminPanel);
            Program.dataBaseConnection.Open();
            SqlDataReader checkCmdReader = checkCmd.ExecuteReader();
            if(checkCmdReader.Read() == false)
            {
                String messageCheckData = title1 + " güncellemek istiyor musunuz?";
                String titleCheckData = "";
                MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
                DialogResult yesNoResult = MessageBox.Show(messageCheckData, titleCheckData, yesNoButtons);
                if(yesNoResult == DialogResult.Yes)
                {
                    UpdateDataMethod();
                }
                else
                {
                    MessageBoxManager.Unregister();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Böyle bir veri zaten var!");
                this.Show();
            }
            checkCmdReader.Close();
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
        }
        //Güncellenme durumunda değişen combobox verilerinin birincil anahtarlarını veritabanından çeker.
        private int ComboBoxNameTableValue(int inputValue)
        {
            string inputTableName = "";
            string inputColumnName = "";
            string inputComboBoxText = "";
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (inputValue == 1)
            {
                inputTableName = "gorevler";
                inputColumnName = "gorev";
                inputComboBoxText = UpdateUserPosition_ComboBox.Text;
            }
            else if(inputValue == 2)
            {
                inputTableName = "yetkiler";
                inputColumnName = "yetki";
                inputComboBoxText = UpdateUserAuthority_ComboBox.Text;
            }
            else
            {
                inputTableName = "";
                inputColumnName = "";
                inputComboBoxText = "";
                MessageBox.Show("Hata: VeriGuncelle-ComboBoxNameTableValue-1");
            }
            Program.dataBaseConnection.Close();
            string inputDataCmdText = "SELECT " + inputColumnName + "No FROM " + inputTableName + " WHERE " + inputColumnName + "Adi = @gelenVeri";
            SqlCommand inputDataCmd = new SqlCommand(inputDataCmdText, Program.dataBaseConnection);
            inputDataCmd.Parameters.AddWithValue("@gelenVeri", inputComboBoxText);
            Program.dataBaseConnection.Open();
            SqlDataReader inputDataReader = inputDataCmd.ExecuteReader();
            if (inputDataReader.Read())
            {
                statusValue = Convert.ToInt32(inputDataReader[inputColumnName + "No"]);
            }
            else
            {
                MessageBox.Show("Hata: VeriGuncelle-ComboBoxNameTableValue-2");
            }
            inputDataReader.Close();
            Program.dataBaseConnection.Close();
            return statusValue;

        }
        private void UpdateDataMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            Program.dataBaseConnection.Close();

            string updateDataCmdText = "";
            string updateColumnName = "";
            string comboBoxValue = "";
            string updateTitle = "";
            if(TableName == "durumlar")
            {
                updateColumnName = "durum";
                comboBoxValue = UpdateStatus_CustomTextBox.Text.Trim();
                updateTitle = "Durum";
            }
            else if(TableName == "gorevler")
            {
                updateColumnName = "gorev";
                comboBoxValue = UpdatePosition_CustomTextBox.Text.Trim();
                updateTitle = "Görev"; 
            }
            else
            {
                updateColumnName = "";
                updateTitle = "Kullanıcı";
            }

            SqlCommand updateDataCmd;
            if(TableName == "kullanicilar")
            {
                updateDataCmdText = "UPDATE kullanicilar SET kullaniciAdi = @kullaniciAdi, kullaniciSoyadi = @kullaniciSoyadi, kullaniciGiris = @kullaniciGiris, gorevNo = @gorevNo, yetkiNo = @yetkiNo, kullaniciKurumu = @kullaniciKurumu WHERE kullaniciNo = @kullaniciNo";
                updateDataCmd = new SqlCommand(updateDataCmdText, Program.dataBaseConnection);
                updateDataCmd.Parameters.AddWithValue("@kullaniciAdi", UpdateUserName_CustomTextBox.Text.Trim());
                updateDataCmd.Parameters.AddWithValue("@kullaniciSoyadi", UpdateUserSurname_CustomTextBox.Text.Trim());
                updateDataCmd.Parameters.AddWithValue("@kullaniciGiris", UpdateUserID_CustomTextBox.Text.Trim());
                updateDataCmd.Parameters.AddWithValue("@gorevNo", ComboBoxNameTableValue(1));
                updateDataCmd.Parameters.AddWithValue("@yetkiNo", ComboBoxNameTableValue(2));
                updateDataCmd.Parameters.AddWithValue("@kullaniciKurumu", UpdateUserCorp_CustomTextBox.Text.Trim());
                updateDataCmd.Parameters.AddWithValue("@kullaniciNo", DataFromAdminPanel);
                Program.dataBaseConnection.Open();
                updateDataCmd.ExecuteNonQuery();
                updateDataCmd.Dispose();
                //Refrest
                UpdateDataEventH();
                MessageBox.Show(UpdateUserID_CustomTextBox.Text.Trim() + " kullanıcısı güncellendi.");
                Program.dataBaseConnection.Close();
            }
            else if(TableName == "durumlar" || TableName == "gorevler")
            {
                updateDataCmdText = "UPDATE " + TableName + " SET " + updateColumnName + "Adi = @gelenVeri WHERE " + updateColumnName + "No = @gelenVeriNo";
                updateDataCmd = new SqlCommand(updateDataCmdText, Program.dataBaseConnection);
                updateDataCmd.Parameters.AddWithValue("@gelenVeri", comboBoxValue);
                updateDataCmd.Parameters.AddWithValue("@gelenVeriNo", DataFromAdminPanel);
                Program.dataBaseConnection.Open();
                updateDataCmd.ExecuteNonQuery();
                updateDataCmd.Dispose();
                //Refrest
                UpdateDataEventH();
                MessageBox.Show(updateTitle + " güncellendi.");
                Program.dataBaseConnection.Close();

            }
            else
            {
                updateDataCmdText = "";
                MessageBox.Show("Hata: VeriGuncelle-UpdateDataMethod");
            }
            UpdateDataLog(updateTitle, UpdateUserName_CustomTextBox.Text.Trim(), UpdateUserSurname_CustomTextBox.Text.Trim(), comboBoxValue);
            MessageBoxManager.Unregister();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //Comboboxları doldurmak amacıyla oluşturulmuş metotlardır.
        private void UpdateDataComboBoxFillMethod()
        {
            Program.dataBaseConnection.Close();
            string positionFillCmdText = "SELECT grv.gorevAdi FROM gorevler AS grv ORDER BY grv.gorevNo ASC";
            SqlCommand positionFillCmd = new SqlCommand(positionFillCmdText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            SqlDataReader positionFillReader = positionFillCmd.ExecuteReader();
            while (positionFillReader.Read())
            {
                UpdateUserPosition_ComboBox.Items.Add(positionFillReader["gorevAdi"]);
            }
            positionFillReader.Close();
            Program.dataBaseConnection.Close();
            string authorityFillCmdText = "SELECT ytk.yetkiAdi FROM yetkiler AS ytk ORDER BY ytk.yetkiNo ASC";
            SqlCommand authorityFillCmd = new SqlCommand(authorityFillCmdText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            SqlDataReader authorityFillReader = authorityFillCmd.ExecuteReader();
            while (authorityFillReader.Read())
            {
                UpdateUserAuthority_ComboBox.Items.Add(authorityFillReader["yetkiAdi"]);
            }
            authorityFillReader.Close();
            Program.dataBaseConnection.Close();
        }
        private void UpdateStatusAndPositionComboBoxFillMethod()
        {
            string columnName = "";
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (TableName == "gorevler")
            {
                columnName = "gorev";
            }
            else if (TableName == "durumlar")
            {
                columnName = "durum";
            }
            else
            {
                MessageBox.Show("Hata: GlobalMethod-VeriGuncelle");
            }
            if(columnName != string.Empty || TableName != string.Empty)
            {
                Program.dataBaseConnection.Close();
                string comboBoxStPosFillCmdText = "SELECT " + columnName + "Adi FROM " + TableName + " ORDER BY " + columnName + "No ASC";
                SqlCommand stPosFillCmd = new SqlCommand(comboBoxStPosFillCmdText, Program.dataBaseConnection);
                Program.dataBaseConnection.Open();
                SqlDataReader stPosFillReader = stPosFillCmd.ExecuteReader();
                if(TableName == "durumlar")
                {
                    while (stPosFillReader.Read())
                    {
                        UpdateStatus_ComboBox.Items.Add(stPosFillReader[columnName + "Adi"]);
                    }
                }
                else if(TableName == "gorevler")
                {
                    while (stPosFillReader.Read())
                    {
                        UpdatePosition_ComboBox.Items.Add(stPosFillReader[columnName + "Adi"]);
                    }
                }
                else
                {
                    MessageBox.Show("Hata: StPosFill-ComboAddWhile");
                }
                stPosFillReader.Close();
                Program.dataBaseConnection.Close();
            }
            else
            {
                MessageBox.Show("Hata: StPosFill-String.Empty");
            }
            MessageBoxManager.Unregister();
        }

        private void VeriGuncelle_Load(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();

            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";
            MessageBoxManager.Register();

            //Boş veriye karşı buton pasifleştirme
            TextControlForButton();
            //Veriye uygun olarak Text doldurma
            TextGridFromAdminPanel();
            //Combobox doldurma
            if (TableName == "kullanicilar")
            {
                UpdateDataComboBoxFillMethod();
            }
            else if (TableName == "durumlar" || TableName == "gorevler")
            {
                UpdateStatusAndPositionComboBoxFillMethod();
            }
            else
            {
                MessageBox.Show("Error: FillMethodLoad");
            }

            //Groupboxların özelleştirilmesi
            if (TableName == "kullanicilar")
            {
                //Parola
                UpdateUserPass_CustomTextBox.Enabled = false;
                UpdateUserPass_CustomTextBox.BackColor = SystemColors.Control;
                //Durumlar
                UpdateStatusGroupBox.Enabled = false;
                //newStatusGroupBox.Visible = false;
                UpdateStatus_CustomTextBox.BackColor = SystemColors.Control;
                //Görevler
                UpdatePositionGroupBox.Enabled = false;
                //newPositionGroupBox.Visible = false;
                UpdatePosition_CustomTextBox.BackColor = SystemColors.Control;
            }
            else if (TableName == "durumlar")
            {
                //Kullanıcılar
                UpdateUserGroupBox.Enabled = false;
                //newUserGroupBox.Visible = false;
                UpdateUserName_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserSurname_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserID_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserPass_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserCorp_CustomTextBox.BackColor = SystemColors.Control;
                //Görevler
                UpdatePositionGroupBox.Enabled = false;
                //newPositionGroupBox.Visible = false;
                UpdatePosition_CustomTextBox.BackColor = SystemColors.Control;

            }
            else if (TableName == "gorevler")
            {
                //Kullanıcılar
                UpdateUserGroupBox.Enabled = false;
                //newUserGroupBox.Visible = false;
                UpdateUserName_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserSurname_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserID_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserPass_CustomTextBox.BackColor = SystemColors.Control;
                UpdateUserCorp_CustomTextBox.BackColor = SystemColors.Control;
                //Durumlar
                UpdateStatusGroupBox.Enabled = false;
                //newStatusGroupBox.Visible = false;
                UpdateStatus_CustomTextBox.BackColor = SystemColors.Control;
            }
            else
            {
                MessageBox.Show("Hata: VeriGuncelle-Tablo ismi alınamadı");
            }

            MessageBoxManager.Unregister();
        }
        //Textboxların hepsi için tek bir keydown eventi
        private void TextBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        //Changed  Textboxlara veri girilmesi halinde TextControlForButton metotu çalıştırılır.
        private void TextBoxTextChanged_ComboboxSelectedIndexChanged(object sender, EventArgs e)
        {
            TextControlForButton();
        }

        private void AdminPage_UpdateDataButton_Click(object sender, EventArgs e)
        {
            UpdateDataMethod();
        }

        private void UpdateDataLog(string title, string kullaniciAdi, string kullaniciSoyadi, string dataName)
        {
            string columnNameValue = "";
            if(TableName == "kullanicilar")
            {
                columnNameValue = kullaniciAdi + ' ' + kullaniciSoyadi;
            }
            else
            {
                columnNameValue = dataName;
            }
            string logFilePath = @"C:\Users\Fatih\Desktop\ServerLogKaydi\AdminLog\UpdateDataLog.txt";
            string writeText = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]: Veri güncelleme yapan Yetkili No: " + UpdateDataUserId + "\tGüncellenen " + title + " No: " + DataFromAdminPanel + "\t" + title + " Adı: " + columnNameValue;
            Console.WriteLine(writeText);
            FileStream adminLogFS = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            adminLogFS.Close();
            File.AppendAllText(logFilePath, Environment.NewLine + writeText);
        }
    }
}
