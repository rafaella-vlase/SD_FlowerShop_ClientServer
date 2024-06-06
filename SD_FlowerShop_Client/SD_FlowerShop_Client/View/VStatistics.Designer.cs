namespace SD_FlowerShop_Client.View
{
    partial class VStatistics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VStatistics));
            this.comboBoxChangeLanguage = new System.Windows.Forms.ComboBox();
            this.labelChangeLanguage = new System.Windows.Forms.Label();
            this.labelCriterion = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.comboBoxCriterion = new System.Windows.Forms.ComboBox();
            this.chartFlowers = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartFlowers)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxChangeLanguage
            // 
            this.comboBoxChangeLanguage.FormattingEnabled = true;
            this.comboBoxChangeLanguage.Items.AddRange(new object[] {
            "English",
            "French",
            "Italian"});
            this.comboBoxChangeLanguage.Location = new System.Drawing.Point(1204, 1081);
            this.comboBoxChangeLanguage.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxChangeLanguage.Name = "comboBoxChangeLanguage";
            this.comboBoxChangeLanguage.Size = new System.Drawing.Size(238, 33);
            this.comboBoxChangeLanguage.TabIndex = 12;
            // 
            // labelChangeLanguage
            // 
            this.labelChangeLanguage.AutoSize = true;
            this.labelChangeLanguage.BackColor = System.Drawing.Color.Transparent;
            this.labelChangeLanguage.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChangeLanguage.Location = new System.Drawing.Point(908, 1083);
            this.labelChangeLanguage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChangeLanguage.Name = "labelChangeLanguage";
            this.labelChangeLanguage.Size = new System.Drawing.Size(265, 43);
            this.labelChangeLanguage.TabIndex = 11;
            this.labelChangeLanguage.Text = "Change Language";
            // 
            // labelCriterion
            // 
            this.labelCriterion.AutoSize = true;
            this.labelCriterion.BackColor = System.Drawing.Color.Transparent;
            this.labelCriterion.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCriterion.Location = new System.Drawing.Point(298, 1095);
            this.labelCriterion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCriterion.Name = "labelCriterion";
            this.labelCriterion.Size = new System.Drawing.Size(238, 43);
            this.labelCriterion.TabIndex = 10;
            this.labelCriterion.Text = "Select Criterion";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.MistyRose;
            this.buttonBack.Location = new System.Drawing.Point(790, 1178);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(256, 44);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Back to Manager";
            this.buttonBack.UseVisualStyleBackColor = false;
            // 
            // comboBoxCriterion
            // 
            this.comboBoxCriterion.FormattingEnabled = true;
            this.comboBoxCriterion.Items.AddRange(new object[] {
            "",
            "Flower Name",
            "Color"});
            this.comboBoxCriterion.Location = new System.Drawing.Point(558, 1087);
            this.comboBoxCriterion.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxCriterion.Name = "comboBoxCriterion";
            this.comboBoxCriterion.Size = new System.Drawing.Size(238, 33);
            this.comboBoxCriterion.TabIndex = 8;
            // 
            // chartFlowers
            // 
            this.chartFlowers.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartFlowers.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartFlowers.Legends.Add(legend1);
            this.chartFlowers.Location = new System.Drawing.Point(141, 86);
            this.chartFlowers.Margin = new System.Windows.Forms.Padding(6);
            this.chartFlowers.Name = "chartFlowers";
            this.chartFlowers.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFlowers.Series.Add(series1);
            this.chartFlowers.Size = new System.Drawing.Size(1547, 913);
            this.chartFlowers.TabIndex = 13;
            this.chartFlowers.Text = "chartFlowers";
            // 
            // VStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SD_FlowerShop_Client.Properties.Resources.defaultBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1800, 1344);
            this.Controls.Add(this.chartFlowers);
            this.Controls.Add(this.comboBoxChangeLanguage);
            this.Controls.Add(this.labelChangeLanguage);
            this.Controls.Add(this.labelCriterion);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.comboBoxCriterion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VStatistics";
            ((System.ComponentModel.ISupportInitialize)(this.chartFlowers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxChangeLanguage;
        private System.Windows.Forms.Label labelChangeLanguage;
        private System.Windows.Forms.Label labelCriterion;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ComboBox comboBoxCriterion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFlowers;
    }
}