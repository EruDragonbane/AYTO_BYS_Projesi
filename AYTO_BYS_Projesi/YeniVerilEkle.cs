using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace AYTO_BYS_Projesi
{
    public partial class YeniVerilEkle : Form
    {
        public YeniVerilEkle()
        {
            InitializeComponent();
        }
        //AdminPanel formundan tablonun ismini alır.
        public YeniVerilEkle(string adminPanel_tableName, int adminPage_UserId)
        {
            InitializeComponent();
            TableName = adminPanel_tableName;
            AdminUserId2 = adminPage_UserId;
        }
        public string TableName { get; set; }
        public int AdminUserId2 { get; set; }
        //ComboboxNameTableValue
        public string columnName, tableName, comboItem, columnValue;

        public delegate void AddNewDataEventHandler();
        public event AddNewDataEventHandler AddNewDataEventH;
        //Comboboxları doldurmak amacıyla oluşturulmuş metotlardır.
        private void NewUserComboBoxFillMethod()
        {
            Program.dataBaseConnection.Close();
            string positionFillCmdText = "SELECT grv.gorevAdi FROM gorevler AS grv ORDER BY grv.gorevNo ASC";
            string authorityFillCmdText = "SELECT ytk.yetkiAdi FROM yetkiler AS ytk ORDER BY ytk.yetkiNo ASC";
            SqlCommand positionFillCmd = new SqlCommand(positionFillCmdText, Program.dataBaseConnection);
            SqlCommand authorityFillCmd = new SqlCommand(authorityFillCmdText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            SqlDataReader positionFillReader = positionFillCmd.ExecuteReader();
            while (positionFillReader.Read())
            {
                AddNewUserPosition_ComboBox.Items.Add(positionFillReader["gorevAdi"]);
            }
            positionFillReader.Close();
            Program.dataBaseConnection.Close();
            Program.dataBaseConnection.Open();
            SqlDataReader authorityFillReader = authorityFillCmd.ExecuteReader();
            while (authorityFillReader.Read())
            {
                AddNewUserAuthority_ComboBox.Items.Add(authorityFillReader["yetkiAdi"]);
            }
            authorityFillReader.Close();
            Program.dataBaseConnection.Close();
        }
        private void NewStatusComboBoxFillMethod()
        {
            Program.dataBaseConnection.Close();
            string statusFillCmdText = "SELECT drm.durumAdi FROM durumlar AS drm ORDER BY drm.durumNo ASC";
            SqlCommand statusFillCmd = new SqlCommand(statusFillCmdText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            SqlDataReader statusFillReader = statusFillCmd.ExecuteReader();
            while (statusFillReader.Read())
            {
                AddNewStatus_ComboBox.Items.Add(statusFillReader["durumAdi"]);
            }
            statusFillReader.Close();
            Program.dataBaseConnection.Close();
        }
        private void NewPositionComboBoxFillMethod()
        {
            Program.dataBaseConnection.Close();
            string positionFillCmdText = "SELECT grv.gorevAdi FROM gorevler AS grv ORDER BY grv.gorevNo ASC";
            SqlCommand positionFillCmd = new SqlCommand(positionFillCmdText, Program.dataBaseConnection);
            Program.dataBaseConnection.Open();
            SqlDataReader positionFillReader = positionFillCmd.ExecuteReader();
            while (positionFillReader.Read())
            {
                AddNewPosition_ComboBox.Items.Add(positionFillReader["gorevAdi"]);
            }
            positionFillReader.Close();
            Program.dataBaseConnection.Close();
        }
        //Textboxların boş olup olmadığını kontrol eder.
        private void TextControlForButton()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (TableName == "kullanicilar")
            {
                if(AddNewUserName_CustomTextBox.Text.Trim() != string.Empty && AddNewUserSurname_CustomTextBox.Text.Trim() != string.Empty && AddNewUserID_CustomTextBox.Text.Trim() != string.Empty && AddNewUserPass_CustomTextBox.Text.Trim() != string.Empty && AddNewUserPosition_ComboBox.Text.Trim() != string.Empty && AddNewUserAuthority_ComboBox.Text.Trim() != string.Empty)
                {
                    AdminPage_AddNewDataButton.Enabled = true;
                }
                else
                {
                    AdminPage_AddNewDataButton.Enabled = false;
                }
            }
            else if (TableName == "durumlar")
            {
                if(AddNewStatus_CustomTextBox.Text.Trim() != string.Empty)
                {
                    AdminPage_AddNewDataButton.Enabled = true;
                }
                else
                {
                    AdminPage_AddNewDataButton.Enabled = false;
                }
            }
            else if (TableName == "gorevler")
            {
                if(AddNewPosition_CustomTextBox.Text.Trim() != string.Empty)
                {
                    AdminPage_AddNewDataButton.Enabled = true;
                }
                else
                {
                    AdminPage_AddNewDataButton.Enabled = false;
                }
            }
            else 
            {
                MessageBox.Show("Error: TextControlForButton");
            }
            MessageBoxManager.Unregister();
        }

        //Girilen verilerin veritabanında kontrolü
        private void CheckUserMethod()
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //MeesageBox Özelleştirme
            MessageBoxManager.Register();

            Program.dataBaseConnection.Close();
            string checkCmdText = "SELECT klnc.kullaniciAdi FROM kullanicilar AS klnc WHERE klnc.kullaniciGiris = @kullaniciGiris";
            SqlCommand checkCmd = new SqlCommand(checkCmdText, Program.dataBaseConnection);
            checkCmd.Parameters.AddWithValue("@kullaniciGiris", AddNewUserID_CustomTextBox.Text.Trim());
            Program.dataBaseConnection.Open();
            SqlDataReader checkCmdReader = checkCmd.ExecuteReader();
            if(checkCmdReader.Read() == false)
            {
                String messageCheckFile = "Yeni kullanıcıyı eklemek istiyor musunuz?";
                String titleCheckFile = "";
                MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
                DialogResult yesNoResult = MessageBox.Show(messageCheckFile, titleCheckFile, yesNoButtons);
                if(yesNoResult == DialogResult.Yes)
                {
                    AddNewUserMethod();
                }
                else
                {
                    MessageBoxManager.Unregister();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Böyle bir kullanıcı adı zaten var!");
                this.Show();
            }
            checkCmdReader.Close();
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
        }
        private void CheckStatusMethod()
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //MeesageBox Özelleştirme
            MessageBoxManager.Register();

            Program.dataBaseConnection.Close();
            string checkCmdText = "SELECT drm.durumAdi FROM durumlar AS drm WHERE drm.durumAdi = @durumAdi";
            SqlCommand checkCmd = new SqlCommand(checkCmdText, Program.dataBaseConnection);
            checkCmd.Parameters.AddWithValue("@durumAdi", AddNewStatus_CustomTextBox.Text.Trim());
            Program.dataBaseConnection.Open();
            SqlDataReader checkCmdReader = checkCmd.ExecuteReader();
            if (checkCmdReader.Read() == false)
            {
                String messageCheckFile = "Yeni durumu eklemek istiyor musunuz?";
                String titleCheckFile = "";
                MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
                DialogResult yesNoResult = MessageBox.Show(messageCheckFile, titleCheckFile, yesNoButtons);
                if (yesNoResult == DialogResult.Yes)
                {
                    AddNewStatusMethod();
                }
                else
                {
                    MessageBoxManager.Unregister();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Böyle bir durum adı zaten var!");
                this.Show();
            }
            checkCmdReader.Close();
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
        }
        private void CheckPositionMethod()
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //MeesageBox Özelleştirme
            MessageBoxManager.Register();

            Program.dataBaseConnection.Close();
            string checkCmdText = "SELECT grv.gorevAdi FROM gorevler AS grv WHERE grv.gorevAdi = @gorevAdi";
            SqlCommand checkCmd = new SqlCommand(checkCmdText, Program.dataBaseConnection);
            checkCmd.Parameters.AddWithValue("@gorevAdi", AddNewPosition_CustomTextBox.Text.Trim());
            Program.dataBaseConnection.Open();
            SqlDataReader checkCmdReader = checkCmd.ExecuteReader();
            if (checkCmdReader.Read() == false)
            {
                String messageCheckFile = "Yeni görevi eklemek istiyor musunuz?";
                String titleCheckFile = "";
                MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
                DialogResult yesNoResult = MessageBox.Show(messageCheckFile, titleCheckFile, yesNoButtons);
                if (yesNoResult == DialogResult.Yes)
                {
                    AddNewPositionMethod();
                }
                else
                {
                    MessageBoxManager.Unregister();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Böyle bir görev adı zaten var!");
                this.Show();
            }
            checkCmdReader.Close();
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
        }

        //Verilerin veritabanına kaydedilmesi
        private string ComboboxNameTableValue(int columnNo)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            Program.dataBaseConnection.Close();
            if(columnNo == 1)
            {
                columnName = "gorev";
                tableName = "gorevler";
                comboItem = AddNewUserPosition_ComboBox.SelectedItem.ToString();
            }
            else if(columnNo == 2)
            {
                columnName = "yetki";
                tableName = "yetkiler";
                comboItem = AddNewUserAuthority_ComboBox.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Error: ComboboxNameTableValue 1");
            }
            if (columnName != string.Empty || tableName != string.Empty || comboItem != string.Empty)
            {
                SqlCommand itemNoCmd = new SqlCommand("SELECT " + columnName + "No FROM " + tableName + " WHERE " + columnName + "Adi = @sutunAdi", Program.dataBaseConnection);
                itemNoCmd.Parameters.AddWithValue("@sutunAdi", comboItem);
                Program.dataBaseConnection.Open();
                SqlDataReader itemNoReader = itemNoCmd.ExecuteReader();
                if (itemNoReader.Read())
                {
                    columnValue = itemNoReader[columnName + "No"].ToString();
                }
                else
                {
                    MessageBox.Show("Error: ComboboxNameTableValue 2");
                }
                itemNoReader.Close();
            }
            else
            {
                MessageBox.Show("Error: ComboboxNameTableValue 3");
            }
            MessageBoxManager.Unregister();
            Program.dataBaseConnection.Close();
            return columnValue;
        }
        private void AddNewUserMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            Program.dataBaseConnection.Close();
            string addNewUserCmdText = "INSERT INTO kullanicilar (kullaniciAdi, kullaniciSoyadi, kullaniciGiris, kullaniciParola, gorevNo, sistemKayitTarihi, kullaniciKurumu, yetkiNo) VALUES (@kullaniciAdi, @kullaniciSoyadi, @kullaniciGiris, @kullaniciParola, @gorevNo, @sistemKayitTarihi, @kullaniciKurumu, @yetkiNo)";

            SqlCommand addNewUserCmd = new SqlCommand(addNewUserCmdText, Program.dataBaseConnection);

            addNewUserCmd.Parameters.AddWithValue("@kullaniciAdi", AddNewUserName_CustomTextBox.Text.Trim());
            addNewUserCmd.Parameters.AddWithValue("@kullaniciSoyadi", AddNewUserSurname_CustomTextBox.Text.Trim());
            addNewUserCmd.Parameters.AddWithValue("@kullaniciGiris", AddNewUserID_CustomTextBox.Text.Trim());
            addNewUserCmd.Parameters.AddWithValue("@kullaniciParola", Mda5Hash(AddNewUserPass_CustomTextBox.Text.Trim()));
            addNewUserCmd.Parameters.AddWithValue("@gorevNo", ComboboxNameTableValue(1));
            addNewUserCmd.Parameters.AddWithValue("@sistemKayitTarihi", DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
            addNewUserCmd.Parameters.AddWithValue("@kullaniciKurumu", AddNewUserCorp_CustomTextBox.Text.Trim());
            addNewUserCmd.Parameters.AddWithValue("@yetkiNo", ComboboxNameTableValue(2));
            Program.dataBaseConnection.Open();
            addNewUserCmd.ExecuteNonQuery();
            AddNewDataEventH();
            NewDataLog("Kullanıcı", "kullanici", "kullaniciGiris", AddNewUserID_CustomTextBox.Text.Trim());

            String messageAnotherNewUser = "Yeni kullanıcı başarıyla kayıt edildi. \n\nYeni bir kullanıcı eklemek istiyor musunuz?";
            String titleNewUser = "";
            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
            DialogResult anotherResult = MessageBox.Show(messageAnotherNewUser, titleNewUser, yesNoButtons);
            if (anotherResult == DialogResult.No)
            {
                this.Close();
                MessageBoxManager.Unregister();
            }
            else
            {
                AddNewUserName_CustomTextBox.Clear();
                AddNewUserSurname_CustomTextBox.Clear();
                AddNewUserID_CustomTextBox.Clear();
                AddNewUserPass_CustomTextBox.Clear();
                AddNewUserCorp_CustomTextBox.Clear();
                AddNewUserPosition_ComboBox.SelectedIndex = -1;
                AddNewUserAuthority_ComboBox.SelectedIndex = -1;
            }
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
        }
        private void AddNewStatusMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            Program.dataBaseConnection.Close();
            string addNewStatusCmdText = "INSERT INTO durumlar (durumAdi) VALUES (@durumAdi)";
            SqlCommand addNewStatusCmd = new SqlCommand(addNewStatusCmdText, Program.dataBaseConnection);

            addNewStatusCmd.Parameters.AddWithValue("@durumAdi", AddNewStatus_CustomTextBox.Text.Trim());
            Program.dataBaseConnection.Open();
            addNewStatusCmd.ExecuteNonQuery();
            AddNewDataEventH();
            NewDataLog("Durum", "durum", "durumAdi", AddNewStatus_CustomTextBox.Text.Trim());

            String messageAnotherNewUser = "Yeni durum başarıyla kayıt edildi. \n\nYeni bir durum eklemek istiyor musunuz?";
            String titleNewUser = "";
            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
            DialogResult anotherResult = MessageBox.Show(messageAnotherNewUser, titleNewUser, yesNoButtons);
            if (anotherResult == DialogResult.No)
            {
                this.Close();
                MessageBoxManager.Unregister();
            }
            else
            {
                AddNewStatus_ComboBox.Items.Clear();
                NewStatusComboBoxFillMethod();
                AddNewStatus_CustomTextBox.Clear();
            }
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
        }
        private void AddNewPositionMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            Program.dataBaseConnection.Close();
            string addNewStatusCmdText = "INSERT INTO gorevler (gorevAdi) VALUES (@gorevAdi)";
            SqlCommand addNewStatusCmd = new SqlCommand(addNewStatusCmdText, Program.dataBaseConnection);
            addNewStatusCmd.Parameters.AddWithValue("@gorevAdi", AddNewPosition_CustomTextBox.Text.Trim());
            Program.dataBaseConnection.Open();
            addNewStatusCmd.ExecuteNonQuery();
            AddNewDataEventH();
            NewDataLog("Görev", "gorev", "gorevAdi", AddNewPosition_CustomTextBox.Text.Trim());

            String messageAnotherNewUser = "Yeni görev başarıyla kayıt edildi. \n\nYeni bir görev eklemek istiyor musunuz?";
            String titleNewUser = "";
            MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
            DialogResult anotherResult = MessageBox.Show(messageAnotherNewUser, titleNewUser, yesNoButtons);
            if (anotherResult == DialogResult.No)
            {
                this.Close();
                MessageBoxManager.Unregister();
            }
            else
            {
                AddNewPosition_ComboBox.Items.Clear();
                NewPositionComboBoxFillMethod();
                AddNewPosition_CustomTextBox.Clear();
            }
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
        }
        //Girilen parolayı md5 ile şifreleyerek veritabanına ekler
        public static string Mda5Hash(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            StringBuilder hashString = new StringBuilder();
            byte[] hashArray = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            foreach (byte byteHash in hashArray)
                hashString.Append(byteHash.ToString("x2"));
            return hashString.ToString();
        }

        private void KullaniciEkleme_Load(object sender, EventArgs e)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            
            MessageBoxManager.Yes = "Evet";
            MessageBoxManager.No = "Hayır";
            MessageBoxManager.OK = "Tamam";

            //Combobox doldurma
            if (TableName == "kullanicilar")
            {
                NewUserComboBoxFillMethod();
            }
            else if (TableName == "durumlar")
            {
                NewStatusComboBoxFillMethod();
            }
            else if (TableName == "gorevler")
            {
                NewPositionComboBoxFillMethod();
            }
            else
            {
                MessageBox.Show("Error: AddButton");
                this.Show();
            }




            //Textboxların boş olması durumunda ekle butonu pasif kalır.
            TextControlForButton();

            //Groupboxların özelleştirilmesi
            if (TableName == "kullanicilar")
            {
                //Durumlar
                newStatusGroupBox.Enabled = false;
                //newStatusGroupBox.Visible = false;
                AddNewStatus_CustomTextBox.BackColor = SystemColors.Control;
                //Görevler
                newPositionGroupBox.Enabled = false;
                //newPositionGroupBox.Visible = false;
                AddNewPosition_CustomTextBox.BackColor = SystemColors.Control;
            }
            else if (TableName == "durumlar")
            {
                //Kullanıcılar
                newUserGroupBox.Enabled = false;
                //newUserGroupBox.Visible = false;
                AddNewUserName_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserSurname_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserID_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserPass_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserCorp_CustomTextBox.BackColor = SystemColors.Control;
                //Görevler
                newPositionGroupBox.Enabled = false;
                //newPositionGroupBox.Visible = false;
                AddNewPosition_CustomTextBox.BackColor = SystemColors.Control;

            }
            else if (TableName == "gorevler")
            {
                //Kullanıcılar
                newUserGroupBox.Enabled = false;
                //newUserGroupBox.Visible = false;
                AddNewUserName_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserSurname_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserID_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserPass_CustomTextBox.BackColor = SystemColors.Control;
                AddNewUserCorp_CustomTextBox.BackColor = SystemColors.Control;
                //Durumlar
                newStatusGroupBox.Enabled = false;
                //newStatusGroupBox.Visible = false;
                AddNewStatus_CustomTextBox.BackColor = SystemColors.Control;
            }
            else
            {
                MessageBox.Show("Tablo ismi alınamadı");
                this.Show();
            }
        }

        private void AddNewData_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AdminPage_AddNewDataButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            if (TableName == "kullanicilar")
            {
                CheckUserMethod();
            }
            else if (TableName == "durumlar")
            {
                CheckStatusMethod();
            }
            else if (TableName == "gorevler")
            {
                CheckPositionMethod();
            }
            else
            {
                MessageBox.Show("Error: AddButton");
                this.Show();
            }
            MessageBoxManager.Unregister();
        }

        //TextChanged ve SelectedIndexChanged Eventleri
        /*AddNewUserName, AddNewUserSurname, AddNewUserID, AddNewUserPass, AddNewUserPosition, AddNewUserAuthority,
         * AddNewUserCorp, AddNewStatus, AddNewPosition
         */
        private void CustomTextBoxTextChanged_ComboboxSelectedIndexChanged (object sender, EventArgs e)
        {
            TextControlForButton();
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
        //User, Status, Position
        private void NewDataLog(string title, string columnName, string whereColumnName, string inputData)
        {
            string dataNo = "";
            string  columnSecondName= "";
            if(TableName == "kullanicilar")
            {
                columnSecondName = " ID: ";
            }
            else
            {
                columnSecondName = " Adı: ";
            }

            Program.dataBaseConnection.Close();
            SqlCommand dataNoNoCmd = new SqlCommand("SELECT " + columnName + "No FROM " + TableName + " WHERE " + whereColumnName + "= @gelenVeri", Program.dataBaseConnection);
            dataNoNoCmd.Parameters.AddWithValue("@gelenVeri", inputData);
            Program.dataBaseConnection.Open();
            SqlDataReader dataNoReader = dataNoNoCmd.ExecuteReader();
            if (dataNoReader.Read())
            {
                dataNo = dataNoReader[columnName + "No"].ToString();
            }
            dataNoReader.Close();
            Program.dataBaseConnection.Close();
            string logFilePath = @"C:\Users\Fatih\Desktop\ServerLogKaydi\AdminLog\NewDataLog.txt";
            string writeText = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]: " + title + " ekleyen Yetkili No: " + AdminUserId2 + "\tEklenen " + title + " No: " + dataNo + "\t" + title + columnSecondName + inputData;

            FileStream adminLogFS = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            adminLogFS.Close();
            File.AppendAllText(logFilePath, Environment.NewLine + writeText);
        }

    }
}