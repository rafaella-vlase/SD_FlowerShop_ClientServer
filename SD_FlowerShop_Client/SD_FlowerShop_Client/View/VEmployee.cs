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

namespace SD_FlowerShop_Client.View
{
    public partial class VEmployee : Form, Observable
    {
        public VEmployee(int index)
        {
            InitializeComponent();
            this.numericUpDownFlowerID.Value = 1;
            this.textBoxFlowerName.Text = string.Empty;
            this.textBoxColor.Text = string.Empty;
            this.textBoxPrice.Text = string.Empty;
            this.textBoxStock.Text = string.Empty;
            this.comboBoxFilterBy.SelectedIndex = 0;
            this.comboBoxOrderBy.SelectedIndex = 0;
            this.textBoxSearch.Text = string.Empty;

            this.comboBoxChangeLanguage.SelectedIndex = index;
        }


        public NumericUpDown GetFlowerID()
        {
            return this.numericUpDownFlowerID;
        }

        public TextBox GetFlowerName()
        {
            return this.textBoxFlowerName;
        }

        public TextBox GetColor()
        {
            return this.textBoxColor;
        }

        public TextBox GetPrice()
        {
            return this.textBoxPrice;
        }

        public TextBox GetStock()
        {
            return this.textBoxStock;
        }

        public ComboBox GetOrderByBox()
        {
            return this.comboBoxOrderBy;
        }

        public ComboBox GetFilterByBox()
        {
            return this.comboBoxFilterBy;
        }

        public ComboBox GetLanguageBox()
        {
            return this.comboBoxChangeLanguage;
        }

        public TextBox GetSearch()
        {
            return this.textBoxSearch;
        }

        public DataGridView GetFlowerTable()
        {
            return this.dataGridViewFlowers;
        }

        public PictureBox GetPictureBox()
        {
            return this.pictureBoxFlowers;
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

        public Button GetSearchButton()
        {
            return this.buttonSearch;
        }

        public Button GetViewAllButton()
        {
            return this.buttonViewAll;
        }

        public Button GetSaveCSVButton()
        {
            return this.buttonSaveCSV;
        }

        public Button GetSaveXMLButton()
        {
            return this.buttonSaveXML;
        }

        public Button GetSaveJSONButton()
        {
            return this.buttonSaveJSON;
        }

        public Button GetSaveDOCButton()
        {
            return this.buttonSaveDOC;
        }

        public Button GetLogoutButton()
        {
            return this.buttonLogout;
        }

        public void Update(Subject obs)
        {
            LangHelper lang = (LangHelper)obs;

            this.labelFlowerID.Text = lang.GetString("labelFlowerID");
            this.labelFlowerName.Text = lang.GetString("labelFlowerName");
            this.labelColor.Text = lang.GetString("labelColor");
            this.labelPrice.Text = lang.GetString("labelPrice");
            this.labelStock.Text = lang.GetString("labelStock");
            this.labelChangeLanguage.Text = lang.GetString("labelChangeLanguage");
            this.labelOrderBy.Text = lang.GetString("labelOrderBy");
            this.labelFilterBy.Text = lang.GetString("labelFilterBy");
            this.labelSearch.Text = lang.GetString("labelSearchFlower");

            this.buttonAdd.Text = lang.GetString("buttonAdd");
            this.buttonUpdate.Text = lang.GetString("buttonUpdate");
            this.buttonDelete.Text = lang.GetString("buttonDelete");
            this.buttonLogout.Text = lang.GetString("buttonLogout");
            this.buttonSearch.Text = lang.GetString("buttonSearch");
            this.buttonViewAll.Text = lang.GetString("buttonViewAll");
            this.buttonSaveCSV.Text = lang.GetString("buttonSaveCSV");
            this.buttonSaveJSON.Text = lang.GetString("buttonSaveJSON");
            this.buttonSaveXML.Text = lang.GetString("buttonSaveXML");
            this.buttonSaveDOC.Text = lang.GetString("buttonSaveDOC");
        }
    }
}

