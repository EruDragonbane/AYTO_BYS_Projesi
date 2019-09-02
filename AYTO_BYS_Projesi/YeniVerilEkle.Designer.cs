namespace AYTO_BYS_Projesi
{
    partial class YeniVerilEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdminPage_AddNewDataButton = new System.Windows.Forms.Button();
            this.AddNewUserPosition_ComboBox = new System.Windows.Forms.ComboBox();
            this.AddNewUserAuthority_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.newUserGroupBox = new System.Windows.Forms.GroupBox();
            this.AddNewUserName_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.AddNewUserSurname_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.AddNewUserID_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.AddNewUserPass_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.AddNewUserCorp_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.newStatusGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddNewStatus_ComboBox = new System.Windows.Forms.ComboBox();
            this.AddNewStatus_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.newPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.AddNewPosition_ComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AddNewPosition_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddNewData_CancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.newUserGroupBox.SuspendLayout();
            this.newStatusGroupBox.SuspendLayout();
            this.newPositionGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminPage_AddNewDataButton
            // 
            this.AdminPage_AddNewDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminPage_AddNewDataButton.Location = new System.Drawing.Point(3, 3);
            this.AdminPage_AddNewDataButton.Name = "AdminPage_AddNewDataButton";
            this.AdminPage_AddNewDataButton.Size = new System.Drawing.Size(180, 39);
            this.AdminPage_AddNewDataButton.TabIndex = 11;
            this.AdminPage_AddNewDataButton.Text = "Ekle";
            this.AdminPage_AddNewDataButton.UseVisualStyleBackColor = true;
            this.AdminPage_AddNewDataButton.Click += new System.EventHandler(this.AdminPage_AddNewDataButton_Click);
            // 
            // AddNewUserPosition_ComboBox
            // 
            this.AddNewUserPosition_ComboBox.DisplayMember = "0";
            this.AddNewUserPosition_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddNewUserPosition_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AddNewUserPosition_ComboBox.FormattingEnabled = true;
            this.AddNewUserPosition_ComboBox.Location = new System.Drawing.Point(9, 165);
            this.AddNewUserPosition_ComboBox.Name = "AddNewUserPosition_ComboBox";
            this.AddNewUserPosition_ComboBox.Size = new System.Drawing.Size(170, 23);
            this.AddNewUserPosition_ComboBox.TabIndex = 4;
            this.AddNewUserPosition_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            // 
            // AddNewUserAuthority_ComboBox
            // 
            this.AddNewUserAuthority_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddNewUserAuthority_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AddNewUserAuthority_ComboBox.FormattingEnabled = true;
            this.AddNewUserAuthority_ComboBox.Location = new System.Drawing.Point(189, 165);
            this.AddNewUserAuthority_ComboBox.Name = "AddNewUserAuthority_ComboBox";
            this.AddNewUserAuthority_ComboBox.Size = new System.Drawing.Size(170, 23);
            this.AddNewUserAuthority_ComboBox.TabIndex = 5;
            this.AddNewUserAuthority_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Görevi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Yetki Durumu";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.newUserGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.newStatusGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.newPositionGroupBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 474);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // newUserGroupBox
            // 
            this.newUserGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newUserGroupBox.Controls.Add(this.AddNewUserName_CustomTextBox);
            this.newUserGroupBox.Controls.Add(this.label2);
            this.newUserGroupBox.Controls.Add(this.AddNewUserSurname_CustomTextBox);
            this.newUserGroupBox.Controls.Add(this.label1);
            this.newUserGroupBox.Controls.Add(this.AddNewUserID_CustomTextBox);
            this.newUserGroupBox.Controls.Add(this.AddNewUserAuthority_ComboBox);
            this.newUserGroupBox.Controls.Add(this.AddNewUserPass_CustomTextBox);
            this.newUserGroupBox.Controls.Add(this.AddNewUserCorp_CustomTextBox);
            this.newUserGroupBox.Controls.Add(this.AddNewUserPosition_ComboBox);
            this.newUserGroupBox.Location = new System.Drawing.Point(3, 3);
            this.newUserGroupBox.MaximumSize = new System.Drawing.Size(372, 230);
            this.newUserGroupBox.MinimumSize = new System.Drawing.Size(372, 230);
            this.newUserGroupBox.Name = "newUserGroupBox";
            this.newUserGroupBox.Size = new System.Drawing.Size(372, 230);
            this.newUserGroupBox.TabIndex = 0;
            this.newUserGroupBox.TabStop = false;
            this.newUserGroupBox.Text = "Kullanıcı Ekle";
            // 
            // AddNewUserName_CustomTextBox
            // 
            this.AddNewUserName_CustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.AddNewUserName_CustomTextBox.CustomText = "Adı";
            this.AddNewUserName_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserName_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserName_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddNewUserName_CustomTextBox.Location = new System.Drawing.Point(10, 20);
            this.AddNewUserName_CustomTextBox.MaxLength = 50;
            this.AddNewUserName_CustomTextBox.Multiline = true;
            this.AddNewUserName_CustomTextBox.Name = "AddNewUserName_CustomTextBox";
            this.AddNewUserName_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.AddNewUserName_CustomTextBox.TabIndex = 0;
            this.AddNewUserName_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.AddNewUserName_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // AddNewUserSurname_CustomTextBox
            // 
            this.AddNewUserSurname_CustomTextBox.CustomText = "Soyadı";
            this.AddNewUserSurname_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserSurname_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserSurname_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddNewUserSurname_CustomTextBox.Location = new System.Drawing.Point(9, 53);
            this.AddNewUserSurname_CustomTextBox.MaxLength = 50;
            this.AddNewUserSurname_CustomTextBox.Multiline = true;
            this.AddNewUserSurname_CustomTextBox.Name = "AddNewUserSurname_CustomTextBox";
            this.AddNewUserSurname_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.AddNewUserSurname_CustomTextBox.TabIndex = 1;
            this.AddNewUserSurname_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.AddNewUserSurname_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // AddNewUserID_CustomTextBox
            // 
            this.AddNewUserID_CustomTextBox.CustomText = "Kullanıcı Adı";
            this.AddNewUserID_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserID_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserID_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddNewUserID_CustomTextBox.Location = new System.Drawing.Point(9, 86);
            this.AddNewUserID_CustomTextBox.MaxLength = 12;
            this.AddNewUserID_CustomTextBox.Multiline = true;
            this.AddNewUserID_CustomTextBox.Name = "AddNewUserID_CustomTextBox";
            this.AddNewUserID_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.AddNewUserID_CustomTextBox.TabIndex = 2;
            this.AddNewUserID_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.AddNewUserID_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // AddNewUserPass_CustomTextBox
            // 
            this.AddNewUserPass_CustomTextBox.CustomText = "Parola";
            this.AddNewUserPass_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserPass_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserPass_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddNewUserPass_CustomTextBox.Location = new System.Drawing.Point(9, 119);
            this.AddNewUserPass_CustomTextBox.MaxLength = 25;
            this.AddNewUserPass_CustomTextBox.Multiline = true;
            this.AddNewUserPass_CustomTextBox.Name = "AddNewUserPass_CustomTextBox";
            this.AddNewUserPass_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.AddNewUserPass_CustomTextBox.TabIndex = 3;
            this.AddNewUserPass_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.AddNewUserPass_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // AddNewUserCorp_CustomTextBox
            // 
            this.AddNewUserCorp_CustomTextBox.CustomText = "Çalıştığı Kurum";
            this.AddNewUserCorp_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserCorp_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewUserCorp_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddNewUserCorp_CustomTextBox.Location = new System.Drawing.Point(9, 194);
            this.AddNewUserCorp_CustomTextBox.MaxLength = 50;
            this.AddNewUserCorp_CustomTextBox.Multiline = true;
            this.AddNewUserCorp_CustomTextBox.Name = "AddNewUserCorp_CustomTextBox";
            this.AddNewUserCorp_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.AddNewUserCorp_CustomTextBox.TabIndex = 6;
            this.AddNewUserCorp_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.AddNewUserCorp_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // newStatusGroupBox
            // 
            this.newStatusGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newStatusGroupBox.Controls.Add(this.label3);
            this.newStatusGroupBox.Controls.Add(this.AddNewStatus_ComboBox);
            this.newStatusGroupBox.Controls.Add(this.AddNewStatus_CustomTextBox);
            this.newStatusGroupBox.Location = new System.Drawing.Point(3, 239);
            this.newStatusGroupBox.MaximumSize = new System.Drawing.Size(372, 85);
            this.newStatusGroupBox.MinimumSize = new System.Drawing.Size(372, 85);
            this.newStatusGroupBox.Name = "newStatusGroupBox";
            this.newStatusGroupBox.Size = new System.Drawing.Size(372, 85);
            this.newStatusGroupBox.TabIndex = 1;
            this.newStatusGroupBox.TabStop = false;
            this.newStatusGroupBox.Text = "Durum Ekle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mevcut Durumlar:";
            // 
            // AddNewStatus_ComboBox
            // 
            this.AddNewStatus_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddNewStatus_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AddNewStatus_ComboBox.FormattingEnabled = true;
            this.AddNewStatus_ComboBox.Location = new System.Drawing.Point(106, 56);
            this.AddNewStatus_ComboBox.Name = "AddNewStatus_ComboBox";
            this.AddNewStatus_ComboBox.Size = new System.Drawing.Size(253, 23);
            this.AddNewStatus_ComboBox.TabIndex = 1;
            // 
            // AddNewStatus_CustomTextBox
            // 
            this.AddNewStatus_CustomTextBox.CustomText = "Durum Adı";
            this.AddNewStatus_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewStatus_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewStatus_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddNewStatus_CustomTextBox.Location = new System.Drawing.Point(10, 19);
            this.AddNewStatus_CustomTextBox.MaxLength = 25;
            this.AddNewStatus_CustomTextBox.Multiline = true;
            this.AddNewStatus_CustomTextBox.Name = "AddNewStatus_CustomTextBox";
            this.AddNewStatus_CustomTextBox.Size = new System.Drawing.Size(349, 27);
            this.AddNewStatus_CustomTextBox.TabIndex = 0;
            this.AddNewStatus_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.AddNewStatus_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // newPositionGroupBox
            // 
            this.newPositionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPositionGroupBox.Controls.Add(this.AddNewPosition_ComboBox);
            this.newPositionGroupBox.Controls.Add(this.label4);
            this.newPositionGroupBox.Controls.Add(this.AddNewPosition_CustomTextBox);
            this.newPositionGroupBox.Location = new System.Drawing.Point(3, 330);
            this.newPositionGroupBox.MaximumSize = new System.Drawing.Size(372, 90);
            this.newPositionGroupBox.MinimumSize = new System.Drawing.Size(372, 90);
            this.newPositionGroupBox.Name = "newPositionGroupBox";
            this.newPositionGroupBox.Size = new System.Drawing.Size(372, 90);
            this.newPositionGroupBox.TabIndex = 2;
            this.newPositionGroupBox.TabStop = false;
            this.newPositionGroupBox.Text = "Görev Ekle";
            // 
            // AddNewPosition_ComboBox
            // 
            this.AddNewPosition_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddNewPosition_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AddNewPosition_ComboBox.FormattingEnabled = true;
            this.AddNewPosition_ComboBox.Location = new System.Drawing.Point(106, 56);
            this.AddNewPosition_ComboBox.Name = "AddNewPosition_ComboBox";
            this.AddNewPosition_ComboBox.Size = new System.Drawing.Size(253, 23);
            this.AddNewPosition_ComboBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mevcut Görevler:";
            // 
            // AddNewPosition_CustomTextBox
            // 
            this.AddNewPosition_CustomTextBox.CustomText = "Görev Adı";
            this.AddNewPosition_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewPosition_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddNewPosition_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddNewPosition_CustomTextBox.Location = new System.Drawing.Point(9, 19);
            this.AddNewPosition_CustomTextBox.MaxLength = 25;
            this.AddNewPosition_CustomTextBox.Multiline = true;
            this.AddNewPosition_CustomTextBox.Name = "AddNewPosition_CustomTextBox";
            this.AddNewPosition_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.AddNewPosition_CustomTextBox.TabIndex = 0;
            this.AddNewPosition_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.AddNewPosition_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel2.Controls.Add(this.AddNewData_CancelButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AdminPage_AddNewDataButton, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 426);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(372, 45);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(372, 45);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(372, 45);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // AddNewData_CancelButton
            // 
            this.AddNewData_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewData_CancelButton.Location = new System.Drawing.Point(189, 3);
            this.AddNewData_CancelButton.Name = "AddNewData_CancelButton";
            this.AddNewData_CancelButton.Size = new System.Drawing.Size(180, 39);
            this.AddNewData_CancelButton.TabIndex = 12;
            this.AddNewData_CancelButton.Text = "İptal Et";
            this.AddNewData_CancelButton.UseVisualStyleBackColor = true;
            this.AddNewData_CancelButton.Click += new System.EventHandler(this.AddNewData_CancelButton_Click);
            // 
            // YeniVerilEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(380, 477);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YeniVerilEkle";
            this.Text = "Yeni Veri Ekleme";
            this.Load += new System.EventHandler(this.KullaniciEkleme_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.newUserGroupBox.ResumeLayout(false);
            this.newUserGroupBox.PerformLayout();
            this.newStatusGroupBox.ResumeLayout(false);
            this.newStatusGroupBox.PerformLayout();
            this.newPositionGroupBox.ResumeLayout(false);
            this.newPositionGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTextBox AddNewUserName_CustomTextBox;
        private CustomTextBox AddNewUserSurname_CustomTextBox;
        private CustomTextBox AddNewUserID_CustomTextBox;
        private CustomTextBox AddNewUserPass_CustomTextBox;
        private System.Windows.Forms.Button AdminPage_AddNewDataButton;
        private System.Windows.Forms.ComboBox AddNewUserPosition_ComboBox;
        private CustomTextBox AddNewUserCorp_CustomTextBox;
        private System.Windows.Forms.ComboBox AddNewUserAuthority_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox newUserGroupBox;
        private System.Windows.Forms.GroupBox newStatusGroupBox;
        private CustomTextBox AddNewStatus_CustomTextBox;
        private System.Windows.Forms.ComboBox AddNewStatus_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox newPositionGroupBox;
        private CustomTextBox AddNewPosition_CustomTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AddNewPosition_ComboBox;
        private System.Windows.Forms.Button AddNewData_CancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}