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
using AYTO.UpdateData;
using AYTO.Log;

namespace AYTO_BYS_Projesi
{
    public partial class VeriGuncelle : Form
    {
        UpdateDataDLL updateDataDLL = new UpdateDataDLL();
        LogDLL logDLL = new LogDLL();

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
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();
            //Item1 = returnValue, Item2 = userName, Item3 = userSurname, ITem4 = userID, Item5 = userPosition, Item6 = userAuthority, Item7 = userCorp, TRest = statusPositionTuple, TRest Item1 = statusName, TRest Item2 = positionName);
            var textGridTuple = updateDataDLL.TextGridFromAdminPanel(TableName, DataFromAdminPanel);
            if(textGridTuple.Item1 == "error")
            {
                MessageBox.Show("Hata: VeriGuncelle-TextGrid1");
            }
            //
            if (TableName == "kullanicilar")
            {
                UpdateUserName_CustomTextBox.Text = textGridTuple.Item2;
                UpdateUserSurname_CustomTextBox.Text = textGridTuple.Item3;
                UpdateUserID_CustomTextBox.Text = textGridTuple.Item4;
                UpdateUserPosition_ComboBox.Text = textGridTuple.Item5;
                UpdateUserAuthority_ComboBox.Text = textGridTuple.Item6;
                UpdateUserCorp_CustomTextBox.Text = textGridTuple.Item7;
            }
            else if (TableName == "durumlar")
            {
                UpdateStatus_CustomTextBox.Text = textGridTuple.Rest.Item1;
            }
            else if (TableName == "gorevler")
            {
                UpdatePosition_CustomTextBox.Text = textGridTuple.Rest.Item2;
            }
            else
            {
                MessageBox.Show("Hata: VeriGuncelle-TextGrid");
            }
            MessageBoxManager.Unregister();
        }

        private void UpdateDataMethod()
        {
            MessageBoxManager.Unregister();
            MessageBoxManager.Register();

            string status = UpdateStatus_CustomTextBox.Text.Trim();
            string position = UpdatePosition_CustomTextBox.Text.Trim();
            string userAuthority = UpdateUserAuthority_ComboBox.Text.Trim();
            string userName = UpdateUserName_CustomTextBox.Text.Trim();
            string userSurname = UpdateUserSurname_CustomTextBox.Text.Trim();
            string userID = UpdateUserID_CustomTextBox.Text.Trim();
            string userCorp = UpdateUserCorp_CustomTextBox.Text.Trim();

            //Item1 = updateTitle, Item2 = comboBoxValue
            var updateDataTuple = updateDataDLL.UpdateData(TableName, status, position, userName, userSurname, userID, userAuthority, userCorp, DataFromAdminPanel);
            if (TableName == "kullanicilar")
            {
                //Refresh
                UpdateDataEventH();
                MessageBox.Show(userID + " kullanıcısı güncellendi.");
            }
            else if(TableName == "durumlar" || TableName == "gorevler")
            {
                //Refresh
                UpdateDataEventH();
                MessageBox.Show(updateDataTuple.Item1 + " güncellendi.");
                Program.dataBaseConnection.Close();

            }
            else
            {
                MessageBox.Show("Hata: VeriGuncelle-UpdateDataMethod");
            }
            logDLL.UpdateDataLog(TableName, UpdateDataUserId, DataFromAdminPanel, updateDataTuple.Item1, userName, userSurname, updateDataTuple.Item2);
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
    }
}
