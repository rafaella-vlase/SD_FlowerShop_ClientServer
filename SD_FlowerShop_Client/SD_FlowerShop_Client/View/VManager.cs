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
    public partial class VManager : Form, Observable
    {
        public VManager(int index)
        {
            InitializeComponent();
            this.numericUpDownFlowerID.Value = 0;
            this.numericUpDownShopID.Value = 0;
            this.textBoxFlowerName.Text = string.Empty;
            this.textBoxColor.Text = string.Empty;
            this.textBoxPrice.Text = string.Empty;
            this.textBoxStock.Text = string.Empty;
            this.comboBoxOrderBy.SelectedIndex = 0;
            this.comboBoxFilterBy.SelectedIndex = 0;
            this.textBoxSearch.Text = string.Empty;

            this.comboBoxChangeLanguage.SelectedIndex = index;
        }


        public NumericUpDown GetFlowerID()
        {
            return this.numericUpDownFlowerID;
        }

        public NumericUpDown GetShopID()
        {
            return this.numericUpDownShopID;
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

        public TextBox GetSearch()
        {
            return this.textBoxSearch;
        }

        public PictureBox GetPictureBox()
        {
            return this.pictureBoxFlowers;
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

        public Button GetSaveCSVButton()
        {
            return this.buttonSaveCSV;
        }

        public Button GetSaveJSONButton()
        {
            return this.buttonSaveJSON;
        }

        public Button GetSaveXMLButton()
        {
            return this.buttonSaveXML;
        }

        public Button GetSaveDOCButton()
        {
            return this.buttonSaveDOC;
        }

        public Button GetStatisticsButton()
        {
            return this.buttonStatistics;
        }

        public DataGridView GetFlowerTable()
        {
            return this.dataGridViewFlowers;
        }

        public void Update(Subject obs)
        {
            LangHelper lang = (LangHelper)obs;

            this.labelFlowerID.Text = lang.GetString("labelFlowerID");
            this.labelFlowerName.Text = lang.GetString("labelFlowerName");
            this.labelColor.Text = lang.GetString("labelColor");
            this.labelPrice.Text = lang.GetString("labelPrice");
            this.labelStock.Text = lang.GetString("labelStock");
            this.labelShopID.Text = lang.GetString("labelShopID");
            this.labelChangeLanguage.Text = lang.GetString("labelChangeLanguage");
            this.labelOrderBy.Text = lang.GetString("labelOrderBy");
            this.labelFilterBy.Text = lang.GetString("labelFilterBy");
            this.labelSearch.Text = lang.GetString("labelSearchFlower");

            this.buttonLogout.Text = lang.GetString("buttonLogout");
            this.buttonSearch.Text = lang.GetString("buttonSearch");
            this.buttonViewAll.Text = lang.GetString("buttonViewAll");
            this.buttonStatistics.Text = lang.GetString("buttonStatistics");
            this.buttonSaveCSV.Text = lang.GetString("buttonSaveCSV");
            this.buttonSaveJSON.Text = lang.GetString("buttonSaveJSON");
            this.buttonSaveXML.Text = lang.GetString("buttonSaveXML");
            this.buttonSaveDOC.Text = lang.GetString("buttonSaveDOC");
        }
    }
}

