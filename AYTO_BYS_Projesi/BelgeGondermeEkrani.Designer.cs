namespace AYTO_BYS_Projesi
{
    partial class BelgeGondermeEkrani
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
            this.SendFileTitle = new System.Windows.Forms.Label();
            this.SendFilePerson = new System.Windows.Forms.Label();
            this.SendFilePerson_CheckComboBox = new CheckComboBoxTest.CheckedComboBox();
            this.SendFileExplain = new System.Windows.Forms.Label();
            this.SendFileExplain_TextLength = new System.Windows.Forms.Label();
            this.SendFileExplain_CustomTextBox = new System.Windows.Forms.RichTextBox();
            this.SendFileName = new System.Windows.Forms.Label();
            this.SendFileDirectory = new System.Windows.Forms.Label();
            this.SendFile_SendButton = new System.Windows.Forms.Button();
            this.SendFile_CancelButton = new System.Windows.Forms.Button();
            this.SendFileDirectory_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.SendFileName_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.SendFileTitle_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.SuspendLayout();
            // 
            // SendFileTitle
            // 
            this.SendFileTitle.AutoSize = true;
            this.SendFileTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileTitle.Location = new System.Drawing.Point(12, 33);
            this.SendFileTitle.Name = "SendFileTitle";
            this.SendFileTitle.Size = new System.Drawing.Size(51, 20);
            this.SendFileTitle.TabIndex = 3;
            this.SendFileTitle.Text = "Başlık";
            // 
            // SendFilePerson
            // 
            this.SendFilePerson.AutoSize = true;
            this.SendFilePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFilePerson.Location = new System.Drawing.Point(12, 84);
            this.SendFilePerson.Name = "SendFilePerson";
            this.SendFilePerson.Size = new System.Drawing.Size(37, 20);
            this.SendFilePerson.TabIndex = 5;
            this.SendFilePerson.Text = "Alıcı";
            // 
            // SendFilePerson_CheckComboBox
            // 
            this.SendFilePerson_CheckComboBox.CheckOnClick = true;
            this.SendFilePerson_CheckComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SendFilePerson_CheckComboBox.DropDownHeight = 1;
            this.SendFilePerson_CheckComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFilePerson_CheckComboBox.FormattingEnabled = true;
            this.SendFilePerson_CheckComboBox.IntegralHeight = false;
            this.SendFilePerson_CheckComboBox.Location = new System.Drawing.Point(16, 107);
            this.SendFilePerson_CheckComboBox.MaximumSize = new System.Drawing.Size(800, 0);
            this.SendFilePerson_CheckComboBox.MinimumSize = new System.Drawing.Size(800, 0);
            this.SendFilePerson_CheckComboBox.Name = "SendFilePerson_CheckComboBox";
            this.SendFilePerson_CheckComboBox.Size = new System.Drawing.Size(800, 27);
            this.SendFilePerson_CheckComboBox.TabIndex = 2;
            this.SendFilePerson_CheckComboBox.ValueSeparator = ", ";
            this.SendFilePerson_CheckComboBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // SendFileExplain
            // 
            this.SendFileExplain.AutoSize = true;
            this.SendFileExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileExplain.Location = new System.Drawing.Point(12, 137);
            this.SendFileExplain.Name = "SendFileExplain";
            this.SendFileExplain.Size = new System.Drawing.Size(125, 20);
            this.SendFileExplain.TabIndex = 7;
            this.SendFileExplain.Text = "Konu Açıklaması";
            // 
            // SendFileExplain_TextLength
            // 
            this.SendFileExplain_TextLength.AutoSize = true;
            this.SendFileExplain_TextLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileExplain_TextLength.ForeColor = System.Drawing.Color.Green;
            this.SendFileExplain_TextLength.Location = new System.Drawing.Point(772, 137);
            this.SendFileExplain_TextLength.Name = "SendFileExplain_TextLength";
            this.SendFileExplain_TextLength.Size = new System.Drawing.Size(45, 20);
            this.SendFileExplain_TextLength.TabIndex = 9;
            this.SendFileExplain_TextLength.Text = "5000";
            // 
            // SendFileExplain_CustomTextBox
            // 
            this.SendFileExplain_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileExplain_CustomTextBox.Location = new System.Drawing.Point(16, 160);
            this.SendFileExplain_CustomTextBox.MaxLength = 5000;
            this.SendFileExplain_CustomTextBox.Name = "SendFileExplain_CustomTextBox";
            this.SendFileExplain_CustomTextBox.Size = new System.Drawing.Size(800, 325);
            this.SendFileExplain_CustomTextBox.TabIndex = 3;
            this.SendFileExplain_CustomTextBox.Text = "";
            this.SendFileExplain_CustomTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.SendFileExplain_CustomTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SendFileExplain_CustomTextBox_KeyUp);
            // 
            // SendFileName
            // 
            this.SendFileName.AutoSize = true;
            this.SendFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SendFileName.Location = new System.Drawing.Point(12, 492);
            this.SendFileName.Name = "SendFileName";
            this.SendFileName.Size = new System.Drawing.Size(77, 20);
            this.SendFileName.TabIndex = 12;
            this.SendFileName.Text = "Belge Adı";
            // 
            // SendFileDirectory
            // 
            this.SendFileDirectory.AutoSize = true;
            this.SendFileDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileDirectory.Location = new System.Drawing.Point(12, 543);
            this.SendFileDirectory.Name = "SendFileDirectory";
            this.SendFileDirectory.Size = new System.Drawing.Size(50, 20);
            this.SendFileDirectory.TabIndex = 13;
            this.SendFileDirectory.Text = "Belge";
            // 
            // SendFile_SendButton
            // 
            this.SendFile_SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendFile_SendButton.Location = new System.Drawing.Point(680, 597);
            this.SendFile_SendButton.MaximumSize = new System.Drawing.Size(65, 40);
            this.SendFile_SendButton.MinimumSize = new System.Drawing.Size(65, 40);
            this.SendFile_SendButton.Name = "SendFile_SendButton";
            this.SendFile_SendButton.Size = new System.Drawing.Size(65, 40);
            this.SendFile_SendButton.TabIndex = 6;
            this.SendFile_SendButton.Text = "Gönder";
            this.SendFile_SendButton.UseVisualStyleBackColor = true;
            this.SendFile_SendButton.Click += new System.EventHandler(this.SendFile_SendButton_Click);
            // 
            // SendFile_CancelButton
            // 
            this.SendFile_CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendFile_CancelButton.Location = new System.Drawing.Point(751, 597);
            this.SendFile_CancelButton.MaximumSize = new System.Drawing.Size(65, 40);
            this.SendFile_CancelButton.MinimumSize = new System.Drawing.Size(65, 40);
            this.SendFile_CancelButton.Name = "SendFile_CancelButton";
            this.SendFile_CancelButton.Size = new System.Drawing.Size(65, 40);
            this.SendFile_CancelButton.TabIndex = 7;
            this.SendFile_CancelButton.Text = "İptal Et";
            this.SendFile_CancelButton.UseVisualStyleBackColor = true;
            this.SendFile_CancelButton.Click += new System.EventHandler(this.SendFile_CancelButton_Click);
            // 
            // SendFileDirectory_CustomTextBox
            // 
            this.SendFileDirectory_CustomTextBox.CustomText = "";
            this.SendFileDirectory_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileDirectory_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileDirectory_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.SendFileDirectory_CustomTextBox.Location = new System.Drawing.Point(16, 566);
            this.SendFileDirectory_CustomTextBox.MaximumSize = new System.Drawing.Size(800, 25);
            this.SendFileDirectory_CustomTextBox.MaxLength = 255;
            this.SendFileDirectory_CustomTextBox.MinimumSize = new System.Drawing.Size(800, 25);
            this.SendFileDirectory_CustomTextBox.Multiline = true;
            this.SendFileDirectory_CustomTextBox.Name = "SendFileDirectory_CustomTextBox";
            this.SendFileDirectory_CustomTextBox.ReadOnly = true;
            this.SendFileDirectory_CustomTextBox.Size = new System.Drawing.Size(800, 25);
            this.SendFileDirectory_CustomTextBox.TabIndex = 5;
            // 
            // SendFileName_CustomTextBox
            // 
            this.SendFileName_CustomTextBox.CustomText = "";
            this.SendFileName_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileName_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileName_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.SendFileName_CustomTextBox.Location = new System.Drawing.Point(16, 515);
            this.SendFileName_CustomTextBox.MaximumSize = new System.Drawing.Size(800, 25);
            this.SendFileName_CustomTextBox.MaxLength = 255;
            this.SendFileName_CustomTextBox.MinimumSize = new System.Drawing.Size(800, 25);
            this.SendFileName_CustomTextBox.Multiline = true;
            this.SendFileName_CustomTextBox.Name = "SendFileName_CustomTextBox";
            this.SendFileName_CustomTextBox.ReadOnly = true;
            this.SendFileName_CustomTextBox.Size = new System.Drawing.Size(800, 25);
            this.SendFileName_CustomTextBox.TabIndex = 4;
            // 
            // SendFileTitle_CustomTextBox
            // 
            this.SendFileTitle_CustomTextBox.CustomText = "Konu Başlığını Girin";
            this.SendFileTitle_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileTitle_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SendFileTitle_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.SendFileTitle_CustomTextBox.Location = new System.Drawing.Point(16, 56);
            this.SendFileTitle_CustomTextBox.MaximumSize = new System.Drawing.Size(800, 25);
            this.SendFileTitle_CustomTextBox.MaxLength = 100;
            this.SendFileTitle_CustomTextBox.MinimumSize = new System.Drawing.Size(800, 25);
            this.SendFileTitle_CustomTextBox.Multiline = true;
            this.SendFileTitle_CustomTextBox.Name = "SendFileTitle_CustomTextBox";
            this.SendFileTitle_CustomTextBox.Size = new System.Drawing.Size(800, 25);
            this.SendFileTitle_CustomTextBox.TabIndex = 1;
            this.SendFileTitle_CustomTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.SendFileTitle_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // BelgeGondermeEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 671);
            this.Controls.Add(this.SendFile_CancelButton);
            this.Controls.Add(this.SendFile_SendButton);
            this.Controls.Add(this.SendFileDirectory_CustomTextBox);
            this.Controls.Add(this.SendFileDirectory);
            this.Controls.Add(this.SendFileName);
            this.Controls.Add(this.SendFileName_CustomTextBox);
            this.Controls.Add(this.SendFileExplain_CustomTextBox);
            this.Controls.Add(this.SendFileExplain_TextLength);
            this.Controls.Add(this.SendFileExplain);
            this.Controls.Add(this.SendFilePerson_CheckComboBox);
            this.Controls.Add(this.SendFilePerson);
            this.Controls.Add(this.SendFileTitle_CustomTextBox);
            this.Controls.Add(this.SendFileTitle);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(847, 710);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(847, 710);
            this.Name = "BelgeGondermeEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Belge Gönderme";
            this.Load += new System.EventHandler(this.BelgeGondermeEkrani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomTextBox SendFileTitle_CustomTextBox;
        private System.Windows.Forms.Label SendFileTitle;
        private System.Windows.Forms.Label SendFilePerson;
        private CheckComboBoxTest.CheckedComboBox SendFilePerson_CheckComboBox;
        private System.Windows.Forms.Label SendFileExplain;
        private System.Windows.Forms.Label SendFileExplain_TextLength;
        private System.Windows.Forms.RichTextBox SendFileExplain_CustomTextBox;
        private CustomTextBox SendFileName_CustomTextBox;
        private System.Windows.Forms.Label SendFileName;
        private System.Windows.Forms.Label SendFileDirectory;
        private CustomTextBox SendFileDirectory_CustomTextBox;
        private System.Windows.Forms.Button SendFile_SendButton;
        private System.Windows.Forms.Button SendFile_CancelButton;
    }
}