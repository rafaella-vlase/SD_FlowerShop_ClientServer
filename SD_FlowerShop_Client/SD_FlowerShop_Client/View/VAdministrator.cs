using SD_FlowerShop_Client.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SD_FlowerShop_Client.View
{
    public partial class VAdministrator : Form, Observable
    {
        public VAdministrator(int index)
        {
            InitializeComponent();
            this.numericUpDownUserID.Value = 0;
            this.textBoxUsername.Text = string.Empty;
            this.textBoxPassword.Text = string.Empty;
            this.textBoxRole.Text = string.Empty;
            this.textBoxPhoneNumber.Text = string.Empty;
            this.textBoxEmail.Text = string.Empty;
            this.numericUpDownShopID.Value = 0;
            this.textBoxSearch.Text = string.Empty;

            this.comboBoxChangeLanguage.SelectedIndex = index;
        }



        public Button GetLogoutButton()
        {
            return this.buttonLogout;
        }

        public Button GetSearchButton()
        {
            return this.buttonSearch;
        }

        public Button GetViewAllButton()
        {
            return this.buttonViewAll;
        }

        public Button GetAddButton()
        {
            return this.buttonAdd;
        }

        public Button GetUpdateButton()
        {
            return this.buttonUpdate;
        }

        public Button GetDeleteButton()
        {
            return this.buttonDelete;
        }



        public ComboBox GetLanguageBox()
        {
            return this.comboBoxChangeLanguage;
        }

        public NumericUpDown GetUserID()
        {
            return this.numericUpDownUserID;
        }

        public NumericUpDown GetShopID()
        {
            return this.numericUpDownShopID;
        }

        public TextBox GetUsername()
        {
            return this.textBoxUsername;
        }

        public TextBox GetPassword()
        {
            return this.textBoxPassword;
        }

        public TextBox GetRole()
        {
            return this.textBoxRole;
        }

        public TextBox GetPhoneNumber()
        {
            return this.textBoxPhoneNumber;
        }

        public TextBox GetEmail()
        {
            return this.textBoxEmail;
        }

        public TextBox GetSearch()
        {
            return this.textBoxSearch;
        }

        public DataGridView GetUserTable()
        {
            return this.dataGridViewUsers;
        }

        public void Update(Subject obs)
        {
            LangHelper lang = (LangHelper)obs;

            this.labelUserID.Text = lang.GetString("labelUserID");
            this.labelUsername.Text = lang.GetString("labelUsername");
            this.labelPassword.Text = lang.GetString("labelPassword");
            this.labelRole.Text = lang.GetString("labelRole");
            this.labelPhoneNumber.Text = lang.GetString("labelPhoneNumber");
            this.labelEmail.Text = lang.GetString("labelEmail");
            this.labelShopID.Text = lang.GetString("labelShopID");
            this.labelSearch.Text = lang.GetString("labelSearchRole");
            this.labelChangeLanguage.Text = lang.GetString("labelChangeLanguage");

            this.buttonLogout.Text = lang.GetString("buttonLogout");
            this.buttonAdd.Text = lang.GetString("buttonAdd");
            this.buttonUpdate.Text = lang.GetString("buttonUpdate");
            this.buttonDelete.Text = lang.GetString("buttonDelete");
            this.buttonSearch.Text = lang.GetString("buttonSearch");
            this.buttonViewAll.Text = lang.GetString("buttonViewAll");
        }
    }
}

