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
using AYTO.NewData;
using AYTO.Log;

namespace AYTO_BYS_Projesi
{
    public partial class YeniVerilEkle : Form
    {
        NewDataDLL newDataDLL = new NewDataDLL();
        LogDLL logDLL = new LogDLL();
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
            if (AddNewUserPosition_ComboBox.Items.Count != 0 || AddNewUserAuthority_ComboBox.Items.Count != 0)
            {
                AddNewUserPosition_ComboBox.SelectedIndex = 0;
                AddNewUserAuthority_ComboBox.SelectedIndex = 0;
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
            if(AddNewStatus_ComboBox.Items.Count != 0)
            {
                AddNewStatus_ComboBox.SelectedIndex = 0;
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
            if(AddNewPosition_ComboBox.Items.Count != 0)
            {
                AddNewPosition_ComboBox.SelectedIndex = 0;
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
        private void CheckDataMethod(string checkReturnValue)
        {
            //MessageBoxManager yerelleştirme çevirileri kayıt altına alır. UnRegister ile bu silinir.
            MessageBoxManager.Unregister();
            //MeesageBox Özelleştirme
            MessageBoxManager.Register();

            string newString = "";
            if(TableName == "kullanicilar")
            {
                newString = "kullanıcı";
            }
            else if(TableName == "durumlar")
            {
                newString = "durum";
            }
            else if(TableName == "gorevler")
            {
                newString = "görev";
            }
            else
            {
                newString = "";
            }

            if(checkReturnValue == "false")
            {
                String messageCheckFile = "Yeni " + newString + " eklemek istiyor musunuz?";
                String titleCheckFile = "";
                MessageBoxButtons yesNoButtons = MessageBoxButtons.YesNo;
                DialogResult yesNoResult = MessageBox.Show(messageCheckFile, titleCheckFile, yesNoButtons);
                if(yesNoResult == DialogResult.Yes)
                {
                    if (TableName == "kullanicilar")
                    {
                        AddNewUserMethod();
                    }
                    else if (TableName == "durumlar")
                    {
                        AddNewStatusMethod();
                    }
                    else if (TableName == "gorevler")
                    {
                        AddNewPositionMethod();
                    }
                    else
                    {
                        MessageBox.Show("Hata: YeniVeriEkle- CheckDataMethod");
                    }

                }
                else
                {
                    MessageBoxManager.Unregister();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Böyle bir " + newString + " adı zaten var!");
                this.Show();
            }
            MessageBoxManager.Unregister();
        }

        private void AddNewUserMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            string userName = AddNewUserName_CustomTextBox.Text.Trim();
            string userSurname = AddNewUserSurname_CustomTextBox.Text.Trim();
            string userID = AddNewUserID_CustomTextBox.Text.Trim();
            string userPassword = AddNewUserPass_CustomTextBox.Text.Trim();
            string userCorp = AddNewUserCorp_CustomTextBox.Text.Trim();
            string positionSelectedItem = AddNewUserPosition_ComboBox.SelectedItem.ToString();
            string authoritySelectedItem = AddNewUserAuthority_ComboBox.SelectedItem.ToString();

            newDataDLL.AddNewUser(userName, userSurname, userID, userPassword, userCorp, positionSelectedItem, authoritySelectedItem);
            AddNewDataEventH();
            //Log kaydı
            logDLL.NewDataLog(TableName, AdminUserId2, "Kullanıcı", "kullanici", "kullaniciGiris", userID);

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
                AddNewUserPosition_ComboBox.SelectedIndex = 0;
                AddNewUserAuthority_ComboBox.SelectedIndex = 0;
            }
            MessageBoxManager.Unregister();
        }
        private void AddNewStatusMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            string statusName = AddNewStatus_CustomTextBox.Text.Trim();
            newDataDLL.AddNewStatus(statusName);
            AddNewDataEventH();
            logDLL.NewDataLog(TableName, AdminUserId2, "Durum", "durum", "durumAdi", statusName);

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

            string positionName = AddNewPosition_CustomTextBox.Text.Trim();
            newDataDLL.AddNewPosition(positionName);
            AddNewDataEventH();
            logDLL.NewDataLog(TableName, AdminUserId2, "Görev", "gorev", "gorevAdi", positionName);

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
            AddNewPosition_ComboBox.SelectedIndex = 0;
            Program.dataBaseConnection.Close();
            MessageBoxManager.Unregister();
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
                MessageBoxManager.Register();
                MessageBox.Show("Tablo ismi alınamadı");
                this.Show();
            }
            MessageBoxManager.Unregister();
        }

        private void AddNewData_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AdminPage_AddNewDataButton_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            string checkReturnValue = "";

            //userID = kullaniciGiris sütunu
            string userID = AddNewUserID_CustomTextBox.Text.Trim();
            string statusName = AddNewStatus_CustomTextBox.Text.Trim();
            string positionName = AddNewPosition_CustomTextBox.Text.Trim();

            bool spaceString = userID.Contains(" ");
            if (spaceString == true)
            {
                MessageBox.Show("Kullanıcı adınızda boş karakter olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                checkReturnValue = newDataDLL.CheckUser(TableName, userID, statusName, positionName);
                CheckDataMethod(checkReturnValue);
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
    }
}