using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SD_FlowerShop_Client.Language;
using SD_FlowerShop_Client.Controller;

namespace SD_FlowerShop_Client.View
{
    public partial class VLogin : Form, Observable
    {
        public VLogin(int index)
        {
            InitializeComponent();
            this.textBoxUsername.Text = string.Empty;
            this.textBoxPassword.Text = string.Empty;
            this.comboBoxLanguage.SelectedIndex = index;
        }

        public TextBox GetUsername()
        {
            return this.textBoxUsername;
        }

        public TextBox GetPassword()
        {
            return this.textBoxPassword;
        }

        public ComboBox GetLanguage()
        {
            return this.comboBoxLanguage;
        }

        public Button GetLogin()
        {
            return this.buttonLogin;
        }

        public void Update(Subject subj)
        {
            LangHelper lang = (LangHelper)subj;
            this.buttonLogin.Text = lang.GetString("buttonLogin");
            this.labelUsername.Text = lang.GetString("labelUsername");
            this.labelPassword.Text = lang.GetString("labelPassword");
        }
    }
}
