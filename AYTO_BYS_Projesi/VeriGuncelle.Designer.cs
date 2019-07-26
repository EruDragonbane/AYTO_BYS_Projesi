namespace AYTO_BYS_Projesi
{
    partial class VeriGuncelle
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateUserGroupBox = new System.Windows.Forms.GroupBox();
            this.UpdateUserName_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateUserSurname_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateUserID_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.UpdateUserAuthority_ComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateUserPass_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.UpdateUserCorp_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.UpdateUserPosition_ComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateStatusGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateStatus_ComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateStatus_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.UpdatePositionGroupBox = new System.Windows.Forms.GroupBox();
            this.UpdatePosition_ComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdatePosition_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateData_CancelButton = new System.Windows.Forms.Button();
            this.AdminPage_UpdateDataButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.UpdateUserGroupBox.SuspendLayout();
            this.UpdateStatusGroupBox.SuspendLayout();
            this.UpdatePositionGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.UpdateUserGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UpdateStatusGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.UpdatePositionGroupBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 474);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // UpdateUserGroupBox
            // 
            this.UpdateUserGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateUserGroupBox.Controls.Add(this.UpdateUserName_CustomTextBox);
            this.UpdateUserGroupBox.Controls.Add(this.label2);
            this.UpdateUserGroupBox.Controls.Add(this.UpdateUserSurname_CustomTextBox);
            this.UpdateUserGroupBox.Controls.Add(this.label1);
            this.UpdateUserGroupBox.Controls.Add(this.UpdateUserID_CustomTextBox);
            this.UpdateUserGroupBox.Controls.Add(this.UpdateUserAuthority_ComboBox);
            this.UpdateUserGroupBox.Controls.Add(this.UpdateUserPass_CustomTextBox);
            this.UpdateUserGroupBox.Controls.Add(this.UpdateUserCorp_CustomTextBox);
            this.UpdateUserGroupBox.Controls.Add(this.UpdateUserPosition_ComboBox);
            this.UpdateUserGroupBox.Location = new System.Drawing.Point(3, 3);
            this.UpdateUserGroupBox.MaximumSize = new System.Drawing.Size(372, 230);
            this.UpdateUserGroupBox.MinimumSize = new System.Drawing.Size(372, 230);
            this.UpdateUserGroupBox.Name = "UpdateUserGroupBox";
            this.UpdateUserGroupBox.Size = new System.Drawing.Size(372, 230);
            this.UpdateUserGroupBox.TabIndex = 0;
            this.UpdateUserGroupBox.TabStop = false;
            this.UpdateUserGroupBox.Text = "Kullanıcı";
            // 
            // UpdateUserName_CustomTextBox
            // 
            this.UpdateUserName_CustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.UpdateUserName_CustomTextBox.CustomText = "Adı";
            this.UpdateUserName_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserName_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserName_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UpdateUserName_CustomTextBox.Location = new System.Drawing.Point(10, 20);
            this.UpdateUserName_CustomTextBox.MaxLength = 50;
            this.UpdateUserName_CustomTextBox.Multiline = true;
            this.UpdateUserName_CustomTextBox.Name = "UpdateUserName_CustomTextBox";
            this.UpdateUserName_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.UpdateUserName_CustomTextBox.TabIndex = 0;
            this.UpdateUserName_CustomTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.UpdateUserName_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
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
            // UpdateUserSurname_CustomTextBox
            // 
            this.UpdateUserSurname_CustomTextBox.CustomText = "Soyadı";
            this.UpdateUserSurname_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserSurname_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserSurname_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UpdateUserSurname_CustomTextBox.Location = new System.Drawing.Point(9, 53);
            this.UpdateUserSurname_CustomTextBox.MaxLength = 50;
            this.UpdateUserSurname_CustomTextBox.Multiline = true;
            this.UpdateUserSurname_CustomTextBox.Name = "UpdateUserSurname_CustomTextBox";
            this.UpdateUserSurname_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.UpdateUserSurname_CustomTextBox.TabIndex = 1;
            this.UpdateUserSurname_CustomTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.UpdateUserSurname_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
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
            // UpdateUserID_CustomTextBox
            // 
            this.UpdateUserID_CustomTextBox.CustomText = "Kullanıcı Adı";
            this.UpdateUserID_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserID_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserID_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UpdateUserID_CustomTextBox.Location = new System.Drawing.Point(9, 86);
            this.UpdateUserID_CustomTextBox.MaxLength = 12;
            this.UpdateUserID_CustomTextBox.Multiline = true;
            this.UpdateUserID_CustomTextBox.Name = "UpdateUserID_CustomTextBox";
            this.UpdateUserID_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.UpdateUserID_CustomTextBox.TabIndex = 2;
            this.UpdateUserID_CustomTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.UpdateUserID_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // UpdateUserAuthority_ComboBox
            // 
            this.UpdateUserAuthority_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateUserAuthority_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.UpdateUserAuthority_ComboBox.FormattingEnabled = true;
            this.UpdateUserAuthority_ComboBox.Location = new System.Drawing.Point(189, 165);
            this.UpdateUserAuthority_ComboBox.Name = "UpdateUserAuthority_ComboBox";
            this.UpdateUserAuthority_ComboBox.Size = new System.Drawing.Size(170, 23);
            this.UpdateUserAuthority_ComboBox.TabIndex = 5;
            this.UpdateUserAuthority_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            // 
            // UpdateUserPass_CustomTextBox
            // 
            this.UpdateUserPass_CustomTextBox.CustomText = "Parola";
            this.UpdateUserPass_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserPass_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserPass_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UpdateUserPass_CustomTextBox.Location = new System.Drawing.Point(9, 119);
            this.UpdateUserPass_CustomTextBox.MaxLength = 25;
            this.UpdateUserPass_CustomTextBox.Multiline = true;
            this.UpdateUserPass_CustomTextBox.Name = "UpdateUserPass_CustomTextBox";
            this.UpdateUserPass_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.UpdateUserPass_CustomTextBox.TabIndex = 3;
            this.UpdateUserPass_CustomTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.UpdateUserPass_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // UpdateUserCorp_CustomTextBox
            // 
            this.UpdateUserCorp_CustomTextBox.CustomText = "Çalıştığı Kurum";
            this.UpdateUserCorp_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserCorp_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateUserCorp_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UpdateUserCorp_CustomTextBox.Location = new System.Drawing.Point(9, 194);
            this.UpdateUserCorp_CustomTextBox.MaxLength = 50;
            this.UpdateUserCorp_CustomTextBox.Multiline = true;
            this.UpdateUserCorp_CustomTextBox.Name = "UpdateUserCorp_CustomTextBox";
            this.UpdateUserCorp_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.UpdateUserCorp_CustomTextBox.TabIndex = 6;
            this.UpdateUserCorp_CustomTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.UpdateUserCorp_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // UpdateUserPosition_ComboBox
            // 
            this.UpdateUserPosition_ComboBox.DisplayMember = "0";
            this.UpdateUserPosition_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateUserPosition_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.UpdateUserPosition_ComboBox.FormattingEnabled = true;
            this.UpdateUserPosition_ComboBox.Location = new System.Drawing.Point(9, 165);
            this.UpdateUserPosition_ComboBox.Name = "UpdateUserPosition_ComboBox";
            this.UpdateUserPosition_ComboBox.Size = new System.Drawing.Size(170, 23);
            this.UpdateUserPosition_ComboBox.TabIndex = 4;
            this.UpdateUserPosition_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            // 
            // UpdateStatusGroupBox
            // 
            this.UpdateStatusGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateStatusGroupBox.Controls.Add(this.label3);
            this.UpdateStatusGroupBox.Controls.Add(this.UpdateStatus_ComboBox);
            this.UpdateStatusGroupBox.Controls.Add(this.UpdateStatus_CustomTextBox);
            this.UpdateStatusGroupBox.Location = new System.Drawing.Point(3, 239);
            this.UpdateStatusGroupBox.MaximumSize = new System.Drawing.Size(372, 85);
            this.UpdateStatusGroupBox.MinimumSize = new System.Drawing.Size(372, 85);
            this.UpdateStatusGroupBox.Name = "UpdateStatusGroupBox";
            this.UpdateStatusGroupBox.Size = new System.Drawing.Size(372, 85);
            this.UpdateStatusGroupBox.TabIndex = 1;
            this.UpdateStatusGroupBox.TabStop = false;
            this.UpdateStatusGroupBox.Text = "Durum";
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
            // UpdateStatus_ComboBox
            // 
            this.UpdateStatus_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateStatus_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.UpdateStatus_ComboBox.FormattingEnabled = true;
            this.UpdateStatus_ComboBox.Location = new System.Drawing.Point(106, 56);
            this.UpdateStatus_ComboBox.Name = "UpdateStatus_ComboBox";
            this.UpdateStatus_ComboBox.Size = new System.Drawing.Size(253, 23);
            this.UpdateStatus_ComboBox.TabIndex = 1;
            // 
            // UpdateStatus_CustomTextBox
            // 
            this.UpdateStatus_CustomTextBox.CustomText = "Durum Adı";
            this.UpdateStatus_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateStatus_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateStatus_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UpdateStatus_CustomTextBox.Location = new System.Drawing.Point(10, 19);
            this.UpdateStatus_CustomTextBox.MaxLength = 25;
            this.UpdateStatus_CustomTextBox.Multiline = true;
            this.UpdateStatus_CustomTextBox.Name = "UpdateStatus_CustomTextBox";
            this.UpdateStatus_CustomTextBox.Size = new System.Drawing.Size(349, 27);
            this.UpdateStatus_CustomTextBox.TabIndex = 0;
            this.UpdateStatus_CustomTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.UpdateStatus_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // UpdatePositionGroupBox
            // 
            this.UpdatePositionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdatePositionGroupBox.Controls.Add(this.UpdatePosition_ComboBox);
            this.UpdatePositionGroupBox.Controls.Add(this.label4);
            this.UpdatePositionGroupBox.Controls.Add(this.UpdatePosition_CustomTextBox);
            this.UpdatePositionGroupBox.Location = new System.Drawing.Point(3, 330);
            this.UpdatePositionGroupBox.MaximumSize = new System.Drawing.Size(372, 90);
            this.UpdatePositionGroupBox.MinimumSize = new System.Drawing.Size(372, 90);
            this.UpdatePositionGroupBox.Name = "UpdatePositionGroupBox";
            this.UpdatePositionGroupBox.Size = new System.Drawing.Size(372, 90);
            this.UpdatePositionGroupBox.TabIndex = 2;
            this.UpdatePositionGroupBox.TabStop = false;
            this.UpdatePositionGroupBox.Text = "Görev";
            // 
            // UpdatePosition_ComboBox
            // 
            this.UpdatePosition_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdatePosition_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.UpdatePosition_ComboBox.FormattingEnabled = true;
            this.UpdatePosition_ComboBox.Location = new System.Drawing.Point(106, 56);
            this.UpdatePosition_ComboBox.Name = "UpdatePosition_ComboBox";
            this.UpdatePosition_ComboBox.Size = new System.Drawing.Size(253, 23);
            this.UpdatePosition_ComboBox.TabIndex = 1;
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
            // UpdatePosition_CustomTextBox
            // 
            this.UpdatePosition_CustomTextBox.CustomText = "Görev Adı";
            this.UpdatePosition_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdatePosition_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdatePosition_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.UpdatePosition_CustomTextBox.Location = new System.Drawing.Point(9, 19);
            this.UpdatePosition_CustomTextBox.MaxLength = 25;
            this.UpdatePosition_CustomTextBox.Multiline = true;
            this.UpdatePosition_CustomTextBox.Name = "UpdatePosition_CustomTextBox";
            this.UpdatePosition_CustomTextBox.Size = new System.Drawing.Size(350, 27);
            this.UpdatePosition_CustomTextBox.TabIndex = 0;
            this.UpdatePosition_CustomTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged_ComboboxSelectedIndexChanged);
            this.UpdatePosition_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel2.Controls.Add(this.UpdateData_CancelButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AdminPage_UpdateDataButton, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 426);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(372, 45);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(372, 45);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(372, 45);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // UpdateData_CancelButton
            // 
            this.UpdateData_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateData_CancelButton.Location = new System.Drawing.Point(189, 3);
            this.UpdateData_CancelButton.Name = "UpdateData_CancelButton";
            this.UpdateData_CancelButton.Size = new System.Drawing.Size(180, 39);
            this.UpdateData_CancelButton.TabIndex = 12;
            this.UpdateData_CancelButton.Text = "İptal Et";
            this.UpdateData_CancelButton.UseVisualStyleBackColor = true;
            // 
            // AdminPage_UpdateDataButton
            // 
            this.AdminPage_UpdateDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminPage_UpdateDataButton.Location = new System.Drawing.Point(3, 3);
            this.AdminPage_UpdateDataButton.Name = "AdminPage_UpdateDataButton";
            this.AdminPage_UpdateDataButton.Size = new System.Drawing.Size(180, 39);
            this.AdminPage_UpdateDataButton.TabIndex = 11;
            this.AdminPage_UpdateDataButton.Text = "Güncelle";
            this.AdminPage_UpdateDataButton.UseVisualStyleBackColor = true;
            this.AdminPage_UpdateDataButton.Click += new System.EventHandler(this.AdminPage_UpdateDataButton_Click);
            // 
            // VeriGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VeriGuncelle";
            this.Text = "VeriGuncelle";
            this.Load += new System.EventHandler(this.VeriGuncelle_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.UpdateUserGroupBox.ResumeLayout(false);
            this.UpdateUserGroupBox.PerformLayout();
            this.UpdateStatusGroupBox.ResumeLayout(false);
            this.UpdateStatusGroupBox.PerformLayout();
            this.UpdatePositionGroupBox.ResumeLayout(false);
            this.UpdatePositionGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox UpdateUserGroupBox;
        private CustomTextBox UpdateUserName_CustomTextBox;
        private System.Windows.Forms.Label label2;
        private CustomTextBox UpdateUserSurname_CustomTextBox;
        private System.Windows.Forms.Label label1;
        private CustomTextBox UpdateUserID_CustomTextBox;
        private System.Windows.Forms.ComboBox UpdateUserAuthority_ComboBox;
        private CustomTextBox UpdateUserPass_CustomTextBox;
        private CustomTextBox UpdateUserCorp_CustomTextBox;
        private System.Windows.Forms.ComboBox UpdateUserPosition_ComboBox;
        private System.Windows.Forms.GroupBox UpdateStatusGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox UpdateStatus_ComboBox;
        private CustomTextBox UpdateStatus_CustomTextBox;
        private System.Windows.Forms.GroupBox UpdatePositionGroupBox;
        private System.Windows.Forms.ComboBox UpdatePosition_ComboBox;
        private System.Windows.Forms.Label label4;
        private CustomTextBox UpdatePosition_CustomTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button UpdateData_CancelButton;
        private System.Windows.Forms.Button AdminPage_UpdateDataButton;
    }
}