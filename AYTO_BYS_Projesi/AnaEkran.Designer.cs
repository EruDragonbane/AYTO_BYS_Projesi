namespace AYTO_BYS_Projesi
{
    partial class AnaEkran
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.aytoMainPage_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPageTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MyFiles_Groupbox = new System.Windows.Forms.GroupBox();
            this.BYS_ActionsTableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.MyFiles_FileActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.MyFiles_FileActions_CancelButton = new System.Windows.Forms.Button();
            this.MyFiles_FileActions_SendButton = new System.Windows.Forms.Button();
            this.MyFiles_FileActions_UpdateButton = new System.Windows.Forms.Button();
            this.MyFiles_FileActions_DeleteButton = new System.Windows.Forms.Button();
            this.MyFiles_NewFileButton = new System.Windows.Forms.Button();
            this.BYS_SearchTableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.FileSearch_ComboBox = new System.Windows.Forms.ComboBox();
            this.FileSearch_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.MyFiles_DataGridView = new System.Windows.Forms.DataGridView();
            this.MainPageTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SentFiles_GroupBox = new System.Windows.Forms.GroupBox();
            this.SentFiles_DataGridView = new System.Windows.Forms.DataGridView();
            this.SendFile_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendFile_FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendFile_SentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendFile_SentPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendFile_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedFiles_GroupBox = new System.Windows.Forms.GroupBox();
            this.ReceivedFiles_DataGridView = new System.Windows.Forms.DataGridView();
            this.ReceivedFile_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedFile_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedFile_ReceiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedFile_ReceivedFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedFile_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.aytoMainPage_MenuStrip.SuspendLayout();
            this.MainPageTableLayoutPanel1.SuspendLayout();
            this.MyFiles_Groupbox.SuspendLayout();
            this.BYS_ActionsTableLayoutPanel3.SuspendLayout();
            this.MyFiles_FileActionsGroupBox.SuspendLayout();
            this.BYS_SearchTableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyFiles_DataGridView)).BeginInit();
            this.MainPageTableLayoutPanel2.SuspendLayout();
            this.SentFiles_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SentFiles_DataGridView)).BeginInit();
            this.ReceivedFiles_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedFiles_DataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aytoMainPage_MenuStrip
            // 
            this.aytoMainPage_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem1,
            this.messagesToolStripMenuItem});
            this.aytoMainPage_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.aytoMainPage_MenuStrip.Name = "aytoMainPage_MenuStrip";
            this.aytoMainPage_MenuStrip.Size = new System.Drawing.Size(1423, 24);
            this.aytoMainPage_MenuStrip.TabIndex = 0;
            this.aytoMainPage_MenuStrip.Text = "Menuler";
            // 
            // menuToolStripMenuItem1
            // 
            this.menuToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem1.Name = "menuToolStripMenuItem1";
            this.menuToolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem1.Text = "Menü";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.profileToolStripMenuItem.Text = "Profil";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.signOutToolStripMenuItem.Text = "Oturumu Kapat";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.SignOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Çıkış";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.messagesToolStripMenuItem.Text = "Mesajlar";
            this.messagesToolStripMenuItem.Click += new System.EventHandler(this.MessagesToolStripMenuItem_Click);
            // 
            // MainPageTableLayoutPanel1
            // 
            this.MainPageTableLayoutPanel1.ColumnCount = 3;
            this.MainPageTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.09174F));
            this.MainPageTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.90826F));
            this.MainPageTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPageTableLayoutPanel1.Controls.Add(this.MyFiles_Groupbox, 0, 0);
            this.MainPageTableLayoutPanel1.Controls.Add(this.MainPageTableLayoutPanel2, 1, 0);
            this.MainPageTableLayoutPanel1.Controls.Add(this.groupBox1, 2, 0);
            this.MainPageTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageTableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.MainPageTableLayoutPanel1.Name = "MainPageTableLayoutPanel1";
            this.MainPageTableLayoutPanel1.RowCount = 1;
            this.MainPageTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPageTableLayoutPanel1.Size = new System.Drawing.Size(1423, 646);
            this.MainPageTableLayoutPanel1.TabIndex = 1;
            // 
            // MyFiles_Groupbox
            // 
            this.MyFiles_Groupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyFiles_Groupbox.Controls.Add(this.BYS_ActionsTableLayoutPanel3);
            this.MyFiles_Groupbox.Controls.Add(this.MyFiles_DataGridView);
            this.MyFiles_Groupbox.Location = new System.Drawing.Point(3, 3);
            this.MyFiles_Groupbox.Name = "MyFiles_Groupbox";
            this.MyFiles_Groupbox.Size = new System.Drawing.Size(521, 640);
            this.MyFiles_Groupbox.TabIndex = 0;
            this.MyFiles_Groupbox.TabStop = false;
            this.MyFiles_Groupbox.Text = "Belgelerim";
            // 
            // BYS_ActionsTableLayoutPanel3
            // 
            this.BYS_ActionsTableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BYS_ActionsTableLayoutPanel3.ColumnCount = 3;
            this.BYS_ActionsTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BYS_ActionsTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BYS_ActionsTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BYS_ActionsTableLayoutPanel3.Controls.Add(this.MyFiles_FileActionsGroupBox, 1, 0);
            this.BYS_ActionsTableLayoutPanel3.Controls.Add(this.MyFiles_NewFileButton, 0, 0);
            this.BYS_ActionsTableLayoutPanel3.Controls.Add(this.BYS_SearchTableLayoutPanel4, 2, 0);
            this.BYS_ActionsTableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.BYS_ActionsTableLayoutPanel3.Name = "BYS_ActionsTableLayoutPanel3";
            this.BYS_ActionsTableLayoutPanel3.RowCount = 1;
            this.BYS_ActionsTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BYS_ActionsTableLayoutPanel3.Size = new System.Drawing.Size(512, 70);
            this.BYS_ActionsTableLayoutPanel3.TabIndex = 3;
            // 
            // MyFiles_FileActionsGroupBox
            // 
            this.MyFiles_FileActionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyFiles_FileActionsGroupBox.Controls.Add(this.MyFiles_FileActions_CancelButton);
            this.MyFiles_FileActionsGroupBox.Controls.Add(this.MyFiles_FileActions_SendButton);
            this.MyFiles_FileActionsGroupBox.Controls.Add(this.MyFiles_FileActions_UpdateButton);
            this.MyFiles_FileActionsGroupBox.Controls.Add(this.MyFiles_FileActions_DeleteButton);
            this.MyFiles_FileActionsGroupBox.Location = new System.Drawing.Point(109, 3);
            this.MyFiles_FileActionsGroupBox.MaximumSize = new System.Drawing.Size(275, 55);
            this.MyFiles_FileActionsGroupBox.MinimumSize = new System.Drawing.Size(275, 55);
            this.MyFiles_FileActionsGroupBox.Name = "MyFiles_FileActionsGroupBox";
            this.MyFiles_FileActionsGroupBox.Size = new System.Drawing.Size(275, 55);
            this.MyFiles_FileActionsGroupBox.TabIndex = 2;
            this.MyFiles_FileActionsGroupBox.TabStop = false;
            this.MyFiles_FileActionsGroupBox.Text = "Eylemler";
            // 
            // MyFiles_FileActions_CancelButton
            // 
            this.MyFiles_FileActions_CancelButton.Location = new System.Drawing.Point(203, 20);
            this.MyFiles_FileActions_CancelButton.Name = "MyFiles_FileActions_CancelButton";
            this.MyFiles_FileActions_CancelButton.Size = new System.Drawing.Size(60, 30);
            this.MyFiles_FileActions_CancelButton.TabIndex = 5;
            this.MyFiles_FileActions_CancelButton.TabStop = false;
            this.MyFiles_FileActions_CancelButton.Text = "İptal Et";
            this.MyFiles_FileActions_CancelButton.UseVisualStyleBackColor = true;
            this.MyFiles_FileActions_CancelButton.Click += new System.EventHandler(this.MyFiles_FileActions_CancelButton_Click);
            // 
            // MyFiles_FileActions_SendButton
            // 
            this.MyFiles_FileActions_SendButton.Location = new System.Drawing.Point(5, 20);
            this.MyFiles_FileActions_SendButton.Name = "MyFiles_FileActions_SendButton";
            this.MyFiles_FileActions_SendButton.Size = new System.Drawing.Size(60, 30);
            this.MyFiles_FileActions_SendButton.TabIndex = 2;
            this.MyFiles_FileActions_SendButton.TabStop = false;
            this.MyFiles_FileActions_SendButton.Text = "Gönder";
            this.MyFiles_FileActions_SendButton.UseVisualStyleBackColor = true;
            this.MyFiles_FileActions_SendButton.Click += new System.EventHandler(this.MyFiles_FileActions_SendButton_Click);
            // 
            // MyFiles_FileActions_UpdateButton
            // 
            this.MyFiles_FileActions_UpdateButton.Location = new System.Drawing.Point(71, 20);
            this.MyFiles_FileActions_UpdateButton.Name = "MyFiles_FileActions_UpdateButton";
            this.MyFiles_FileActions_UpdateButton.Size = new System.Drawing.Size(60, 30);
            this.MyFiles_FileActions_UpdateButton.TabIndex = 3;
            this.MyFiles_FileActions_UpdateButton.TabStop = false;
            this.MyFiles_FileActions_UpdateButton.Text = "Güncelle";
            this.MyFiles_FileActions_UpdateButton.UseVisualStyleBackColor = true;
            this.MyFiles_FileActions_UpdateButton.Click += new System.EventHandler(this.MyFiles_FileActions_UpdateButton_Click);
            // 
            // MyFiles_FileActions_DeleteButton
            // 
            this.MyFiles_FileActions_DeleteButton.Location = new System.Drawing.Point(137, 20);
            this.MyFiles_FileActions_DeleteButton.Name = "MyFiles_FileActions_DeleteButton";
            this.MyFiles_FileActions_DeleteButton.Size = new System.Drawing.Size(60, 30);
            this.MyFiles_FileActions_DeleteButton.TabIndex = 4;
            this.MyFiles_FileActions_DeleteButton.TabStop = false;
            this.MyFiles_FileActions_DeleteButton.Text = "Sil";
            this.MyFiles_FileActions_DeleteButton.UseVisualStyleBackColor = true;
            this.MyFiles_FileActions_DeleteButton.Click += new System.EventHandler(this.MyFiles_FileActions_DeleteButton_Click);
            // 
            // MyFiles_NewFileButton
            // 
            this.MyFiles_NewFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MyFiles_NewFileButton.Location = new System.Drawing.Point(3, 10);
            this.MyFiles_NewFileButton.MaximumSize = new System.Drawing.Size(100, 50);
            this.MyFiles_NewFileButton.MinimumSize = new System.Drawing.Size(100, 50);
            this.MyFiles_NewFileButton.Name = "MyFiles_NewFileButton";
            this.MyFiles_NewFileButton.Size = new System.Drawing.Size(100, 50);
            this.MyFiles_NewFileButton.TabIndex = 1;
            this.MyFiles_NewFileButton.Text = "Yeni Belge";
            this.MyFiles_NewFileButton.UseVisualStyleBackColor = true;
            this.MyFiles_NewFileButton.Click += new System.EventHandler(this.MyFiles_NewFileButton_Click);
            // 
            // BYS_SearchTableLayoutPanel4
            // 
            this.BYS_SearchTableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BYS_SearchTableLayoutPanel4.ColumnCount = 1;
            this.BYS_SearchTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BYS_SearchTableLayoutPanel4.Controls.Add(this.FileSearch_ComboBox, 0, 1);
            this.BYS_SearchTableLayoutPanel4.Controls.Add(this.FileSearch_CustomTextBox, 0, 0);
            this.BYS_SearchTableLayoutPanel4.Location = new System.Drawing.Point(390, 3);
            this.BYS_SearchTableLayoutPanel4.Name = "BYS_SearchTableLayoutPanel4";
            this.BYS_SearchTableLayoutPanel4.RowCount = 2;
            this.BYS_SearchTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.BYS_SearchTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.BYS_SearchTableLayoutPanel4.Size = new System.Drawing.Size(133, 64);
            this.BYS_SearchTableLayoutPanel4.TabIndex = 3;
            // 
            // FileSearch_ComboBox
            // 
            this.FileSearch_ComboBox.DisplayMember = "Tümü";
            this.FileSearch_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileSearch_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileSearch_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FileSearch_ComboBox.FormattingEnabled = true;
            this.FileSearch_ComboBox.Items.AddRange(new object[] {
            "Tümü",
            "Başlık",
            "Belge Adı",
            "Belge Sahibi"});
            this.FileSearch_ComboBox.Location = new System.Drawing.Point(3, 36);
            this.FileSearch_ComboBox.Name = "FileSearch_ComboBox";
            this.FileSearch_ComboBox.Size = new System.Drawing.Size(127, 26);
            this.FileSearch_ComboBox.TabIndex = 7;
            this.FileSearch_ComboBox.TabStop = false;
            this.FileSearch_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomTextboxTextChanged_ComboBoxSelectedIndexChanged);
            // 
            // FileSearch_CustomTextBox
            // 
            this.FileSearch_CustomTextBox.CustomText = "Arama";
            this.FileSearch_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FileSearch_CustomTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileSearch_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FileSearch_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.FileSearch_CustomTextBox.Location = new System.Drawing.Point(3, 3);
            this.FileSearch_CustomTextBox.MaxLength = 100;
            this.FileSearch_CustomTextBox.MinimumSize = new System.Drawing.Size(127, 27);
            this.FileSearch_CustomTextBox.Multiline = true;
            this.FileSearch_CustomTextBox.Name = "FileSearch_CustomTextBox";
            this.FileSearch_CustomTextBox.Size = new System.Drawing.Size(127, 27);
            this.FileSearch_CustomTextBox.TabIndex = 6;
            this.FileSearch_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextboxTextChanged_ComboBoxSelectedIndexChanged);
            this.FileSearch_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // MyFiles_DataGridView
            // 
            this.MyFiles_DataGridView.AllowUserToAddRows = false;
            this.MyFiles_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyFiles_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MyFiles_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyFiles_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.MyFiles_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MyFiles_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MyFiles_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyFiles_DataGridView.Location = new System.Drawing.Point(6, 95);
            this.MyFiles_DataGridView.MinimumSize = new System.Drawing.Size(390, 0);
            this.MyFiles_DataGridView.MultiSelect = false;
            this.MyFiles_DataGridView.Name = "MyFiles_DataGridView";
            this.MyFiles_DataGridView.ReadOnly = true;
            this.MyFiles_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.MyFiles_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MyFiles_DataGridView.Size = new System.Drawing.Size(515, 539);
            this.MyFiles_DataGridView.TabIndex = 0;
            this.MyFiles_DataGridView.TabStop = false;
            this.MyFiles_DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyFiles_DataGridView_CellDoubleClick);
            this.MyFiles_DataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MyFiles_DataGridView_CellMouseClick);
            this.MyFiles_DataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MyFiles_DataGridView_ColumnHeaderMouseClick);
            // 
            // MainPageTableLayoutPanel2
            // 
            this.MainPageTableLayoutPanel2.ColumnCount = 1;
            this.MainPageTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPageTableLayoutPanel2.Controls.Add(this.SentFiles_GroupBox, 0, 1);
            this.MainPageTableLayoutPanel2.Controls.Add(this.ReceivedFiles_GroupBox, 0, 0);
            this.MainPageTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageTableLayoutPanel2.Location = new System.Drawing.Point(530, 3);
            this.MainPageTableLayoutPanel2.Name = "MainPageTableLayoutPanel2";
            this.MainPageTableLayoutPanel2.RowCount = 2;
            this.MainPageTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPageTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPageTableLayoutPanel2.Size = new System.Drawing.Size(520, 640);
            this.MainPageTableLayoutPanel2.TabIndex = 3;
            // 
            // SentFiles_GroupBox
            // 
            this.SentFiles_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SentFiles_GroupBox.Controls.Add(this.SentFiles_DataGridView);
            this.SentFiles_GroupBox.Location = new System.Drawing.Point(3, 323);
            this.SentFiles_GroupBox.Name = "SentFiles_GroupBox";
            this.SentFiles_GroupBox.Size = new System.Drawing.Size(514, 314);
            this.SentFiles_GroupBox.TabIndex = 2;
            this.SentFiles_GroupBox.TabStop = false;
            this.SentFiles_GroupBox.Text = "Gönderilenler";
            // 
            // SentFiles_DataGridView
            // 
            this.SentFiles_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SentFiles_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SentFiles_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SentFiles_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SentFiles_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.SentFiles_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SentFiles_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SendFile_Title,
            this.SendFile_FileName,
            this.SendFile_SentDate,
            this.SendFile_SentPerson,
            this.SendFile_Status});
            this.SentFiles_DataGridView.Location = new System.Drawing.Point(6, 19);
            this.SentFiles_DataGridView.Name = "SentFiles_DataGridView";
            this.SentFiles_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.SentFiles_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SentFiles_DataGridView.Size = new System.Drawing.Size(503, 289);
            this.SentFiles_DataGridView.TabIndex = 2;
            this.SentFiles_DataGridView.TabStop = false;
            // 
            // SendFile_Title
            // 
            this.SendFile_Title.HeaderText = "Başlık";
            this.SendFile_Title.Name = "SendFile_Title";
            // 
            // SendFile_FileName
            // 
            this.SendFile_FileName.HeaderText = "Belge Adı";
            this.SendFile_FileName.Name = "SendFile_FileName";
            // 
            // SendFile_SentDate
            // 
            this.SendFile_SentDate.HeaderText = "Tarih";
            this.SendFile_SentDate.Name = "SendFile_SentDate";
            // 
            // SendFile_SentPerson
            // 
            this.SendFile_SentPerson.HeaderText = "Kime";
            this.SendFile_SentPerson.Name = "SendFile_SentPerson";
            // 
            // SendFile_Status
            // 
            this.SendFile_Status.HeaderText = "Durum";
            this.SendFile_Status.Name = "SendFile_Status";
            // 
            // ReceivedFiles_GroupBox
            // 
            this.ReceivedFiles_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceivedFiles_GroupBox.Controls.Add(this.ReceivedFiles_DataGridView);
            this.ReceivedFiles_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.ReceivedFiles_GroupBox.Name = "ReceivedFiles_GroupBox";
            this.ReceivedFiles_GroupBox.Size = new System.Drawing.Size(514, 314);
            this.ReceivedFiles_GroupBox.TabIndex = 1;
            this.ReceivedFiles_GroupBox.TabStop = false;
            this.ReceivedFiles_GroupBox.Text = "Gelenler";
            // 
            // ReceivedFiles_DataGridView
            // 
            this.ReceivedFiles_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceivedFiles_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReceivedFiles_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReceivedFiles_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ReceivedFiles_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.ReceivedFiles_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReceivedFiles_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceivedFile_Title,
            this.ReceivedFile_Name,
            this.ReceivedFile_ReceiveDate,
            this.ReceivedFile_ReceivedFrom,
            this.ReceivedFile_Status});
            this.ReceivedFiles_DataGridView.Location = new System.Drawing.Point(6, 19);
            this.ReceivedFiles_DataGridView.Name = "ReceivedFiles_DataGridView";
            this.ReceivedFiles_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.ReceivedFiles_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReceivedFiles_DataGridView.Size = new System.Drawing.Size(503, 289);
            this.ReceivedFiles_DataGridView.TabIndex = 1;
            this.ReceivedFiles_DataGridView.TabStop = false;
            // 
            // ReceivedFile_Title
            // 
            this.ReceivedFile_Title.HeaderText = "Başlık";
            this.ReceivedFile_Title.Name = "ReceivedFile_Title";
            // 
            // ReceivedFile_Name
            // 
            this.ReceivedFile_Name.HeaderText = "Belge Adı";
            this.ReceivedFile_Name.Name = "ReceivedFile_Name";
            // 
            // ReceivedFile_ReceiveDate
            // 
            this.ReceivedFile_ReceiveDate.HeaderText = "Tarih";
            this.ReceivedFile_ReceiveDate.Name = "ReceivedFile_ReceiveDate";
            // 
            // ReceivedFile_ReceivedFrom
            // 
            this.ReceivedFile_ReceivedFrom.HeaderText = "Kimden";
            this.ReceivedFile_ReceivedFrom.Name = "ReceivedFile_ReceivedFrom";
            // 
            // ReceivedFile_Status
            // 
            this.ReceivedFile_Status.HeaderText = "Durum";
            this.ReceivedFile_Status.Name = "ReceivedFile_Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(1056, 3);
            this.groupBox1.MinimumSize = new System.Drawing.Size(300, 530);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 640);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mesajlar";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(250, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "Kapat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 670);
            this.Controls.Add(this.MainPageTableLayoutPanel1);
            this.Controls.Add(this.aytoMainPage_MenuStrip);
            this.MainMenuStrip = this.aytoMainPage_MenuStrip;
            this.Name = "AnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AYTO Belge Yönetim Sistemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaEkran_FormClosing);
            this.Load += new System.EventHandler(this.AnaEkran_Load);
            this.aytoMainPage_MenuStrip.ResumeLayout(false);
            this.aytoMainPage_MenuStrip.PerformLayout();
            this.MainPageTableLayoutPanel1.ResumeLayout(false);
            this.MyFiles_Groupbox.ResumeLayout(false);
            this.BYS_ActionsTableLayoutPanel3.ResumeLayout(false);
            this.MyFiles_FileActionsGroupBox.ResumeLayout(false);
            this.BYS_SearchTableLayoutPanel4.ResumeLayout(false);
            this.BYS_SearchTableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyFiles_DataGridView)).EndInit();
            this.MainPageTableLayoutPanel2.ResumeLayout(false);
            this.SentFiles_GroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SentFiles_DataGridView)).EndInit();
            this.ReceivedFiles_GroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedFiles_DataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip aytoMainPage_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel MainPageTableLayoutPanel1;
        private System.Windows.Forms.GroupBox MyFiles_Groupbox;
        private System.Windows.Forms.TableLayoutPanel BYS_ActionsTableLayoutPanel3;
        private System.Windows.Forms.GroupBox MyFiles_FileActionsGroupBox;
        private System.Windows.Forms.Button MyFiles_FileActions_CancelButton;
        private System.Windows.Forms.Button MyFiles_FileActions_SendButton;
        private System.Windows.Forms.Button MyFiles_FileActions_UpdateButton;
        private System.Windows.Forms.Button MyFiles_FileActions_DeleteButton;
        private System.Windows.Forms.Button MyFiles_NewFileButton;
        private System.Windows.Forms.DataGridView MyFiles_DataGridView;
        private System.Windows.Forms.TableLayoutPanel MainPageTableLayoutPanel2;
        private System.Windows.Forms.GroupBox SentFiles_GroupBox;
        private System.Windows.Forms.DataGridView SentFiles_DataGridView;
        private System.Windows.Forms.GroupBox ReceivedFiles_GroupBox;
        private System.Windows.Forms.DataGridView ReceivedFiles_DataGridView;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendFile_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendFile_FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendFile_SentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendFile_SentPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendFile_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedFile_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedFile_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedFile_ReceiveDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedFile_ReceivedFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedFile_Status;
        private System.Windows.Forms.TableLayoutPanel BYS_SearchTableLayoutPanel4;
        private CustomTextBox FileSearch_CustomTextBox;
        private System.Windows.Forms.ComboBox FileSearch_ComboBox;
    }
}

