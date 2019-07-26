namespace AYTO_BYS_Projesi
{
    partial class AdminPanel
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
            this.aytoAdminPage_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.belgelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görevlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silinenVerilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcılarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.belgelerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AdminPage_DataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdminPanelSearch_ComboBox = new System.Windows.Forms.ComboBox();
            this.AdminPanelSearch_CustomTextBox = new AYTO_BYS_Projesi.CustomTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InactiveOrActiveUser_Button = new System.Windows.Forms.Button();
            this.AdminPanel_DeleteButton = new System.Windows.Forms.Button();
            this.AdminPanel_UpdateButton = new System.Windows.Forms.Button();
            this.AdminPanel_AddButton = new System.Windows.Forms.Button();
            this.aytoAdminPage_MenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdminPage_DataGridView)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // aytoAdminPage_MenuStrip
            // 
            this.aytoAdminPage_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.verilerToolStripMenuItem,
            this.silinenVerilerToolStripMenuItem});
            this.aytoAdminPage_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.aytoAdminPage_MenuStrip.Name = "aytoAdminPage_MenuStrip";
            this.aytoAdminPage_MenuStrip.Size = new System.Drawing.Size(984, 24);
            this.aytoAdminPage_MenuStrip.TabIndex = 1;
            this.aytoAdminPage_MenuStrip.Text = "Menuler";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menü";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.profileToolStripMenuItem.Text = "Profil";
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.signOutToolStripMenuItem.Text = "Oturumu Kapat";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.SignOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "Çıkış";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // verilerToolStripMenuItem
            // 
            this.verilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.belgelerToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.görevlerToolStripMenuItem});
            this.verilerToolStripMenuItem.Name = "verilerToolStripMenuItem";
            this.verilerToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.verilerToolStripMenuItem.Text = "Veriler";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.usersToolStripMenuItem.Text = "Kullanıcılar";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // belgelerToolStripMenuItem
            // 
            this.belgelerToolStripMenuItem.Name = "belgelerToolStripMenuItem";
            this.belgelerToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.belgelerToolStripMenuItem.Text = "Belgeler";
            this.belgelerToolStripMenuItem.Click += new System.EventHandler(this.BelgelerToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.statusToolStripMenuItem.Text = "Belge Durumları";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.DurumlarToolStripMenuItem_Click);
            // 
            // görevlerToolStripMenuItem
            // 
            this.görevlerToolStripMenuItem.Name = "görevlerToolStripMenuItem";
            this.görevlerToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.görevlerToolStripMenuItem.Text = "Görevler";
            this.görevlerToolStripMenuItem.Click += new System.EventHandler(this.GörevlerToolStripMenuItem_Click);
            // 
            // silinenVerilerToolStripMenuItem
            // 
            this.silinenVerilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcılarToolStripMenuItem,
            this.belgelerToolStripMenuItem1});
            this.silinenVerilerToolStripMenuItem.Name = "silinenVerilerToolStripMenuItem";
            this.silinenVerilerToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.silinenVerilerToolStripMenuItem.Text = "Silinen Veriler";
            // 
            // kullanıcılarToolStripMenuItem
            // 
            this.kullanıcılarToolStripMenuItem.Name = "kullanıcılarToolStripMenuItem";
            this.kullanıcılarToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.kullanıcılarToolStripMenuItem.Text = "Kullanıcılar";
            this.kullanıcılarToolStripMenuItem.Click += new System.EventHandler(this.SilinenKullanıcılarToolStripMenuItem_Click);
            // 
            // belgelerToolStripMenuItem1
            // 
            this.belgelerToolStripMenuItem1.Name = "belgelerToolStripMenuItem1";
            this.belgelerToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.belgelerToolStripMenuItem1.Text = "Belgeler";
            this.belgelerToolStripMenuItem1.Click += new System.EventHandler(this.SilinenBelgelerToolStripMenuItem1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.43284F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 437F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 437F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 437);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.AdminPage_DataGridView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(978, 431);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // AdminPage_DataGridView
            // 
            this.AdminPage_DataGridView.AllowUserToAddRows = false;
            this.AdminPage_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminPage_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AdminPage_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AdminPage_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AdminPage_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdminPage_DataGridView.Location = new System.Drawing.Point(3, 92);
            this.AdminPage_DataGridView.MultiSelect = false;
            this.AdminPage_DataGridView.Name = "AdminPage_DataGridView";
            this.AdminPage_DataGridView.ReadOnly = true;
            this.AdminPage_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.AdminPage_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AdminPage_DataGridView.Size = new System.Drawing.Size(972, 336);
            this.AdminPage_DataGridView.TabIndex = 1;
            this.AdminPage_DataGridView.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.74486F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.25514F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(972, 83);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.AdminPanelSearch_ComboBox);
            this.groupBox1.Controls.Add(this.AdminPanelSearch_CustomTextBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // AdminPanelSearch_ComboBox
            // 
            this.AdminPanelSearch_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AdminPanelSearch_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.AdminPanelSearch_ComboBox.FormattingEnabled = true;
            this.AdminPanelSearch_ComboBox.Items.AddRange(new object[] {
            "Tümü"});
            this.AdminPanelSearch_ComboBox.Location = new System.Drawing.Point(6, 45);
            this.AdminPanelSearch_ComboBox.Name = "AdminPanelSearch_ComboBox";
            this.AdminPanelSearch_ComboBox.Size = new System.Drawing.Size(310, 26);
            this.AdminPanelSearch_ComboBox.TabIndex = 1;
            this.AdminPanelSearch_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomTextboxTextChanged_ComboBoxSelectedIndexChanged);
            // 
            // AdminPanelSearch_CustomTextBox
            // 
            this.AdminPanelSearch_CustomTextBox.CustomText = "Arama";
            this.AdminPanelSearch_CustomTextBox.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AdminPanelSearch_CustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AdminPanelSearch_CustomTextBox.ForeColor = System.Drawing.Color.Black;
            this.AdminPanelSearch_CustomTextBox.Location = new System.Drawing.Point(6, 12);
            this.AdminPanelSearch_CustomTextBox.MaxLength = 100;
            this.AdminPanelSearch_CustomTextBox.Multiline = true;
            this.AdminPanelSearch_CustomTextBox.Name = "AdminPanelSearch_CustomTextBox";
            this.AdminPanelSearch_CustomTextBox.Size = new System.Drawing.Size(310, 27);
            this.AdminPanelSearch_CustomTextBox.TabIndex = 0;
            this.AdminPanelSearch_CustomTextBox.TextChanged += new System.EventHandler(this.CustomTextboxTextChanged_ComboBoxSelectedIndexChanged);
            this.AdminPanelSearch_CustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.InactiveOrActiveUser_Button);
            this.groupBox2.Controls.Add(this.AdminPanel_DeleteButton);
            this.groupBox2.Controls.Add(this.AdminPanel_UpdateButton);
            this.groupBox2.Controls.Add(this.AdminPanel_AddButton);
            this.groupBox2.Location = new System.Drawing.Point(331, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // InactiveOrActiveUser_Button
            // 
            this.InactiveOrActiveUser_Button.Location = new System.Drawing.Point(526, 19);
            this.InactiveOrActiveUser_Button.Name = "InactiveOrActiveUser_Button";
            this.InactiveOrActiveUser_Button.Size = new System.Drawing.Size(110, 50);
            this.InactiveOrActiveUser_Button.TabIndex = 4;
            this.InactiveOrActiveUser_Button.Text = "Kullanıcı Aktifleştir/Pasifleştir";
            this.InactiveOrActiveUser_Button.UseVisualStyleBackColor = true;
            this.InactiveOrActiveUser_Button.Click += new System.EventHandler(this.InactiveOrActiveUser_Button_Click);
            // 
            // AdminPanel_DeleteButton
            // 
            this.AdminPanel_DeleteButton.Location = new System.Drawing.Point(178, 19);
            this.AdminPanel_DeleteButton.Name = "AdminPanel_DeleteButton";
            this.AdminPanel_DeleteButton.Size = new System.Drawing.Size(80, 50);
            this.AdminPanel_DeleteButton.TabIndex = 3;
            this.AdminPanel_DeleteButton.TabStop = false;
            this.AdminPanel_DeleteButton.Text = "Sil";
            this.AdminPanel_DeleteButton.UseVisualStyleBackColor = true;
            this.AdminPanel_DeleteButton.Click += new System.EventHandler(this.AdminPanel_DeleteButton_Click);
            // 
            // AdminPanel_UpdateButton
            // 
            this.AdminPanel_UpdateButton.Location = new System.Drawing.Point(92, 19);
            this.AdminPanel_UpdateButton.Name = "AdminPanel_UpdateButton";
            this.AdminPanel_UpdateButton.Size = new System.Drawing.Size(80, 50);
            this.AdminPanel_UpdateButton.TabIndex = 2;
            this.AdminPanel_UpdateButton.TabStop = false;
            this.AdminPanel_UpdateButton.Text = "Güncelle";
            this.AdminPanel_UpdateButton.UseVisualStyleBackColor = true;
            this.AdminPanel_UpdateButton.Click += new System.EventHandler(this.AdminPanel_UpdateButton_Click);
            // 
            // AdminPanel_AddButton
            // 
            this.AdminPanel_AddButton.Location = new System.Drawing.Point(6, 19);
            this.AdminPanel_AddButton.Name = "AdminPanel_AddButton";
            this.AdminPanel_AddButton.Size = new System.Drawing.Size(80, 50);
            this.AdminPanel_AddButton.TabIndex = 1;
            this.AdminPanel_AddButton.TabStop = false;
            this.AdminPanel_AddButton.Text = "Ekle";
            this.AdminPanel_AddButton.UseVisualStyleBackColor = true;
            this.AdminPanel_AddButton.Click += new System.EventHandler(this.AdminPanel_AddButton_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.aytoAdminPage_MenuStrip);
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminPanel_FormClosing);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.aytoAdminPage_MenuStrip.ResumeLayout(false);
            this.aytoAdminPage_MenuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdminPage_DataGridView)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip aytoAdminPage_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AdminPanel_DeleteButton;
        private System.Windows.Forms.Button AdminPanel_UpdateButton;
        private System.Windows.Forms.Button AdminPanel_AddButton;
        private System.Windows.Forms.ToolStripMenuItem verilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem belgelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görevlerToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView AdminPage_DataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox AdminPanelSearch_ComboBox;
        private CustomTextBox AdminPanelSearch_CustomTextBox;
        private System.Windows.Forms.ToolStripMenuItem silinenVerilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcılarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem belgelerToolStripMenuItem1;
        private System.Windows.Forms.Button InactiveOrActiveUser_Button;
    }
}