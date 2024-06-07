using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using SD_FlowerShop_Client.Language;
using SD_FlowerShop_Client.View;
using SD_FlowerShop_Server.Service;
using System.Windows.Forms;
using System.ServiceModel;
using System.Configuration;
using SD_FlowerShop_Server.Repository;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;


namespace SD_FlowerShop_Client.Controller
{
    public class ControllerStatistics
    {
        private VStatistics vStatistics;
        private Dictionary<string, uint> statistics;
        private LangHelper lang;
        private int index;
        private IFlowerService iFlowerService;

        public ControllerStatistics(int index)
        {
            this.vStatistics = new VStatistics(index);
           
            this.index = index;

            this.lang = new LangHelper();
            this.lang.Add(this.vStatistics);
            this.createBindings();

            this.eventsManagement();
        }

        public VStatistics GetView()
        {
            this.vStatistics.Show();
            return this.vStatistics;
        }

        private void createBindings()
        {
            ChannelFactory<IFlowerService> channelManager;
            NetTcpBinding tcp = new NetTcpBinding();
            tcp.OpenTimeout = new TimeSpan(0, 60, 0);
            tcp.SendTimeout = new TimeSpan(0, 60, 0);
            tcp.ReceiveTimeout = new TimeSpan(0, 60, 0);
            tcp.CloseTimeout = new TimeSpan(0, 60, 0);
            tcp.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcp.Security.Mode = SecurityMode.Transport;
            tcp.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            tcp.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            string s = ConfigurationManager.ConnectionStrings["IPAdress"].ConnectionString;
            channelManager = new ChannelFactory<IFlowerService>(tcp, "net.tcp://" + s + ":52002/Flower");
            try
            {
                this.iFlowerService = channelManager.CreateChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void eventsManagement()
        {
            this.vStatistics.FormClosed += new System.Windows.Forms.FormClosedEventHandler(exitApplication);
            this.vStatistics.GetBackButton().Click += new EventHandler(backToManager);
            this.vStatistics.GetCriterionBox().SelectedIndexChanged += new EventHandler(showStatistics);
            this.vStatistics.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vStatistics.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vStatistics.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vStatistics.GetLanguageBox().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void backToManager(object sender, EventArgs e)
        {
            try
            {
                ControllerManager manager = new ControllerManager(index);
                manager.GetView();
                this.vStatistics.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void showStatistics(object sender, EventArgs e)
        {
            string criterion = this.vStatistics.GetCriterionBox().SelectedItem.ToString();


            statistics = this.iFlowerService.FlowerStatistics(this.vStatistics.GetCriterionBox().SelectedItem.ToString());

            if (this.statistics != null)
            {
                this.vStatistics.ClearChart();
                this.vStatistics.SetLegendsChart(criterion);
                this.vStatistics.SetSeriesChart(statistics, criterion);
                this.vStatistics.SetTitleChart("Statistics by " + criterion);
            }
        }
    }
}
