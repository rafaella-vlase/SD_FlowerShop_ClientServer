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
using System.Windows.Forms.DataVisualization.Charting;

namespace SD_FlowerShop_Client.View
{
    public partial class VStatistics : Form, Observable
    {
        private int index;
        public VStatistics(int index)
        {
            InitializeComponent();
            this.comboBoxChangeLanguage.SelectedIndex = index;
        }

        public Label GetCriterionLabel()
        {
            return this.labelCriterion;
        }

        public Label GetFlowerShopLabel()
        {
            return this.labelChangeLanguage;
        }

        public ComboBox GetCriterionBox()
        {
            return this.comboBoxCriterion;
        }

        public ComboBox GetLanguageBox()
        {
            return this.comboBoxChangeLanguage;
        }

        public Chart GetFlowerChart()
        {
            return this.chartFlowers;
        }

        public Button GetBackButton()
        {
            return this.buttonBack;
        }

        public void ClearChart()
        {
            this.chartFlowers.Series.Clear();
            this.chartFlowers.Legends.Clear();
        }

        public void SetLegendsChart(string seriesName)
        {
            this.chartFlowers.Legends.Add(seriesName);
            this.chartFlowers.Legends[0].LegendStyle = LegendStyle.Table;
            this.chartFlowers.Legends[0].Docking = Docking.Right;
            this.chartFlowers.Legends[0].Alignment = StringAlignment.Center;
            this.chartFlowers.Legends[0].Title = seriesName;
            this.chartFlowers.Legends[0].BorderColor = Color.Black;
        }

        public void SetSeriesChart(Dictionary<string, uint> list, string seriesName)
        {
            this.chartFlowers.Series.Add(seriesName);
            this.chartFlowers.Series[seriesName].ChartType = SeriesChartType.Pie;
            foreach (KeyValuePair<string, uint> pair in list)
                this.chartFlowers.Series[seriesName].Points.AddXY(pair.Key, pair.Value);
            foreach (DataPoint p in this.chartFlowers.Series[seriesName].Points)
                p.Label = "#PERCENT";
            this.chartFlowers.Series[seriesName].LegendText = "#VALX";
        }

        public void SetTitleChart(string title)
        {
            this.chartFlowers.Titles.Clear();
            this.chartFlowers.Titles.Add(title);
            this.chartFlowers.Titles[0].Docking = Docking.Top;
            this.chartFlowers.Titles[0].Alignment = ContentAlignment.MiddleRight;
            this.chartFlowers.Titles[0].Font = new Font("Times New Roman", 15, FontStyle.Bold);
        }


        public void Update(Subject obs)
        {
            LangHelper lang = (LangHelper)obs;

            this.labelCriterion.Text = lang.GetString("labelCriterion");
            this.labelChangeLanguage.Text = lang.GetString("labelChangeLanguage");
            //this.buttonBack.Text = lang.GetString("buttonBack");
        }
    }
}
