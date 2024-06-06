namespace SD_FlowerShop_Client.View
{
    partial class VAdministrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VAdministrator));
            this.comboBoxChangeLanguage = new System.Windows.Forms.ComboBox();
            this.labelChangeLanguage = new System.Windows.Forms.Label();
            this.pictureBoxBubble = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.numericUpDownShopID = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownUserID = new System.Windows.Forms.NumericUpDown();
            this.textBoxRole = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelShopID = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonViewAll = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBubble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShopID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxChangeLanguage
            // 
            this.comboBoxChangeLanguage.FormattingEnabled = true;
            this.comboBoxChangeLanguage.Items.AddRange(new object[] {
            "English",
            "French",
            "Italian"});
            this.comboBoxChangeLanguage.Location = new System.Drawing.Point(1598, 148);
            this.comboBoxChangeLanguage.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxChangeLanguage.Name = "comboBoxChangeLanguage";
            this.comboBoxChangeLanguage.Size = new System.Drawing.Size(400, 33);
            this.comboBoxChangeLanguage.TabIndex = 46;
            // 
            // labelChangeLanguage
            // 
            this.labelChangeLanguage.AutoSize = true;
            this.labelChangeLanguage.BackColor = System.Drawing.Color.Transparent;
            this.labelChangeLanguage.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelChangeLanguage.Location = new System.Drawing.Point(1602, 73);
            this.labelChangeLanguage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChangeLanguage.Name = "labelChangeLanguage";
            this.labelChangeLanguage.Size = new System.Drawing.Size(403, 67);
            this.labelChangeLanguage.TabIndex = 45;
            this.labelChangeLanguage.Text = "Change Language";
            // 
            // pictureBoxBubble
            // 
            this.pictureBoxBubble.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBubble.BackgroundImage = global::SD_FlowerShop_Client.Properties.Resources.admin_bubble;
            this.pictureBoxBubble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBubble.Location = new System.Drawing.Point(300, 148);
            this.pictureBoxBubble.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxBubble.Name = "pictureBoxBubble";
            this.pictureBoxBubble.Size = new System.Drawing.Size(330, 85);
            this.pictureBoxBubble.TabIndex = 44;
            this.pictureBoxBubble.TabStop = false;
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAvatar.BackgroundImage = global::SD_FlowerShop_Client.Properties.Resources.avatar;
            this.pictureBoxAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(182, 227);
            this.pictureBoxAvatar.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(224, 210);
            this.pictureBoxAvatar.TabIndex = 43;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.BackColor = System.Drawing.Color.Transparent;
            this.labelSearch.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelSearch.Location = new System.Drawing.Point(520, 475);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(449, 67);
            this.labelSearch.TabIndex = 42;
            this.labelSearch.Text = "Search User By Role";
            // 
            // numericUpDownShopID
            // 
            this.numericUpDownShopID.Location = new System.Drawing.Point(1152, 410);
            this.numericUpDownShopID.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownShopID.Maximum = new decimal(new int[] {
            4000000,
            0,
            0,
            0});
            this.numericUpDownShopID.Name = "numericUpDownShopID";
            this.numericUpDownShopID.Size = new System.Drawing.Size(368, 31);
            this.numericUpDownShopID.TabIndex = 41;
            // 
            // numericUpDownUserID
            // 
            this.numericUpDownUserID.Location = new System.Drawing.Point(1152, 98);
            this.numericUpDownUserID.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownUserID.Maximum = new decimal(new int[] {
            4000000,
            0,
            0,
            0});
            this.numericUpDownUserID.Name = "numericUpDownUserID";
            this.numericUpDownUserID.Size = new System.Drawing.Size(368, 31);
            this.numericUpDownUserID.TabIndex = 40;
            // 
            // textBoxRole
            // 
            this.textBoxRole.Location = new System.Drawing.Point(1152, 335);
            this.textBoxRole.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxRole.Multiline = true;
            this.textBoxRole.Name = "textBoxRole";
            this.textBoxRole.Size = new System.Drawing.Size(364, 39);
            this.textBoxRole.TabIndex = 39;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(1152, 256);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(364, 39);
            this.textBoxPassword.TabIndex = 38;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(1152, 173);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxUsername.Multiline = true;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(364, 39);
            this.textBoxUsername.TabIndex = 37;
            // 
            // labelShopID
            // 
            this.labelShopID.AutoSize = true;
            this.labelShopID.BackColor = System.Drawing.Color.Transparent;
            this.labelShopID.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelShopID.Location = new System.Drawing.Point(822, 402);
            this.labelShopID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShopID.Name = "labelShopID";
            this.labelShopID.Size = new System.Drawing.Size(197, 67);
            this.labelShopID.TabIndex = 36;
            this.labelShopID.Text = "Shop ID";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.BackColor = System.Drawing.Color.Transparent;
            this.labelRole.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelRole.Location = new System.Drawing.Point(822, 325);
            this.labelRole.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(122, 67);
            this.labelRole.TabIndex = 35;
            this.labelRole.Text = "Role";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelPassword.Location = new System.Drawing.Point(822, 245);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(228, 67);
            this.labelPassword.TabIndex = 34;
            this.labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelUsername.Location = new System.Drawing.Point(822, 166);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(234, 67);
            this.labelUsername.TabIndex = 33;
            this.labelUsername.Text = "Username";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.BackColor = System.Drawing.Color.Transparent;
            this.labelUserID.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelUserID.Location = new System.Drawing.Point(822, 91);
            this.labelUserID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(182, 67);
            this.labelUserID.TabIndex = 32;
            this.labelUserID.Text = "User ID";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.MistyRose;
            this.buttonLogout.Location = new System.Drawing.Point(182, 448);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(6);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(172, 65);
            this.buttonLogout.TabIndex = 31;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(520, 548);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(572, 62);
            this.textBoxSearch.TabIndex = 30;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.MistyRose;
            this.buttonDelete.Location = new System.Drawing.Point(1944, 548);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(172, 65);
            this.buttonDelete.TabIndex = 29;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.MistyRose;
            this.buttonUpdate.Location = new System.Drawing.Point(1736, 548);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(172, 65);
            this.buttonUpdate.TabIndex = 28;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.MistyRose;
            this.buttonAdd.Location = new System.Drawing.Point(1536, 548);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(172, 65);
            this.buttonAdd.TabIndex = 27;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // buttonViewAll
            // 
            this.buttonViewAll.BackColor = System.Drawing.Color.MistyRose;
            this.buttonViewAll.Location = new System.Drawing.Point(1324, 545);
            this.buttonViewAll.Margin = new System.Windows.Forms.Padding(6);
            this.buttonViewAll.Name = "buttonViewAll";
            this.buttonViewAll.Size = new System.Drawing.Size(172, 65);
            this.buttonViewAll.TabIndex = 26;
            this.buttonViewAll.Text = "View All";
            this.buttonViewAll.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.MistyRose;
            this.buttonSearch.Location = new System.Drawing.Point(1116, 545);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(172, 65);
            this.buttonSearch.TabIndex = 25;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(138, 664);
            this.dataGridViewUsers.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersWidth = 82;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1954, 810);
            this.dataGridViewUsers.TabIndex = 24;
            // 
            // VAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SD_FlowerShop_Client.Properties.Resources.defaultBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2254, 1546);
            this.Controls.Add(this.comboBoxChangeLanguage);
            this.Controls.Add(this.labelChangeLanguage);
            this.Controls.Add(this.pictureBoxBubble);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.numericUpDownShopID);
            this.Controls.Add(this.numericUpDownUserID);
            this.Controls.Add(this.textBoxRole);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelShopID);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonViewAll);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VAdministrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAdministrator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBubble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShopID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxChangeLanguage;
        private System.Windows.Forms.Label labelChangeLanguage;
        private System.Windows.Forms.PictureBox pictureBoxBubble;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.NumericUpDown numericUpDownShopID;
        private System.Windows.Forms.NumericUpDown numericUpDownUserID;
        private System.Windows.Forms.TextBox textBoxRole;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelShopID;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonViewAll;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
    }
}