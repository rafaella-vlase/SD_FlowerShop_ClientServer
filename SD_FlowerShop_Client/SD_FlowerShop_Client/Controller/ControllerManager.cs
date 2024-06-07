using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using SD_FlowerShop_Client.Language;
using SD_FlowerShop_Client.View;
using SD_FlowerShop_Client.Service;
using SD_FlowerShop_Server.Domain;
using SD_FlowerShop_Server.Repository;
using SD_FlowerShop_Server.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;


namespace SD_FlowerShop_Client.Controller
{
    public class ControllerManager
    {
        private VManager vManager;
        private VLogin vLogin;
        private IUserService iUserService;
        private IFlowerService iFlowerService;
        private LangHelper lang;
        private int index;

        public ControllerManager(int index)
        {
            this.vManager = new VManager(index);
            this.vLogin = new VLogin(index);
            this.index = index;

            this.lang = new LangHelper();
            this.lang.Add(this.vManager);

            this.createBindings();
            this.eventsManagement();
        }

        public VManager GetView()
        {
            this.vManager.Show();
            return this.vManager;
        }

        private void createBindings()
        {
            ChannelFactory<IUserService> channelAdminUser;
            ChannelFactory<IFlowerService> channelAdminFlower;
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
            channelAdminUser = new ChannelFactory<IUserService>(tcp, "net.tcp://" + s + ":52001/User");
            channelAdminFlower = new ChannelFactory<IFlowerService>(tcp, "net.tcp://" + s + ":52002/Flower");
            try
            {
                this.iUserService = channelAdminUser.CreateChannel();
                this.iFlowerService = channelAdminFlower.CreateChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void eventsManagement()
        {
            this.vManager.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vManager.GetSearchButton().Click += new EventHandler(searchBy);
            this.vManager.GetFilterByBox().SelectedIndexChanged += new EventHandler(filterBy);
            this.vManager.GetOrderByBox().SelectedIndexChanged += new EventHandler(orderBy);
            this.vManager.GetViewAllButton().Click += new EventHandler(viewAll);
            this.vManager.GetSaveCSVButton().Click += new EventHandler(saveCSV);
            this.vManager.GetSaveJSONButton().Click += new EventHandler(saveJSON);
            this.vManager.GetSaveXMLButton().Click += new EventHandler(saveXML);
            this.vManager.GetSaveDOCButton().Click += new EventHandler(saveDOC);
            //this.vManager.GetStatisticsButton().Click += new EventHandler(showStatistics);
            this.vManager.GetLogoutButton().Click += new EventHandler(logout);
            this.vManager.GetFlowerTable().RowStateChanged += new DataGridViewRowStateChangedEventHandler(setFlowerControls);
            this.vManager.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vManager.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vManager.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vManager.GetLanguageBox().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void searchBy(object sender, EventArgs e)
        {
            try
            {
                if (this.vManager.GetFlowerTable() != null)
                {
                    this.vManager.GetFlowerTable().Rows.Clear();
                }
                if (this.vManager.GetSearch().Text.Length > 0)
                {
                    string searchedFlower = this.vManager.GetSearch().Text;
                    List<Flower> list = this.iFlowerService.SearchFlowerByType(searchedFlower);

                    
                    if (list != null && list.Count > 0)
                    {
                        foreach (Flower f in list)
                        {
                            this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID); 
                        }
                    }
                    else MessageBox.Show(lang.GetString("messageBoxNoFlowerDesiredName"));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void filterBy(object sender, EventArgs e)
        {
            try
            {
                string selectedOption = this.vManager.GetFilterByBox().SelectedItem.ToString();

                if (this.vManager.GetFlowerTable() != null)
                    this.vManager.GetFlowerTable().Rows.Clear();
                if (selectedOption.Length > 0)
                {
                    if (selectedOption.ToUpper() == "AVAILABILITY")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_Availability(0);

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID);
                            }
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "PRICE")
                    {
                        Debug.WriteLine(this.vManager.GetPrice().ToString());
                        List<Flower> list = this.iFlowerService.FlowerList_Price(this.vManager.GetPrice().Text, 0);

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID);
                            }
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "COLOR")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_Color(this.vManager.GetColor().Text, 0);


                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID);
                            }
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "STOCK")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_Stock(this.vManager.GetStock().Text, 0);


                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID);
                            }
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "FLOWER SHOP")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_FlowerShop((uint)this.vManager.GetShopID().Value);


                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID);
                            }
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void orderBy(object sender, EventArgs e)
        {
            try
            {
                if (this.vManager.GetFlowerTable() != null)
                    this.vManager.GetFlowerTable().Rows.Clear();

                string selectedOption = this.vManager.GetOrderByBox().SelectedItem.ToString();
                if (selectedOption.Length > 0)
                {
                    if (selectedOption.ToUpper() == "NONE")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList();
                        foreach (Flower f in list)
                        {
                            this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID);
                        }
                    }
                    else if (selectedOption.ToUpper() == "COLOR AND PRICE")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_ColorPrice(0);

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                this.vManager.GetFlowerTable().Rows.Add(f.FlowerID, f.FlowerName, f.Color, f.Price, f.Stock, f.ShopID);
                            }
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoData"));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void viewAll(object sender, EventArgs e)
        {
            try
            {
                if (this.vManager.GetFlowerTable() != null)
                {
                    this.vManager.GetFlowerTable().Rows.Clear();
                }

                List<Flower> list = this.iFlowerService.FlowerList();
                foreach (Flower f in list)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = f.FlowerID });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = f.FlowerName });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = f.Color });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = f.Price });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = f.Stock });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = f.ShopID });
                    this.vManager.GetFlowerTable().Rows.Add(row);
                }
                this.vManager.GetFlowerTable().Rows.Add();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void saveCSV(object sender, EventArgs e)
        {
            try
            {
                FileSaveServiceFactory.FileType fileType = FileSaveServiceFactory.FileType.Excel;
                FileSaveService fileSaveService = FileSaveServiceFactory.CreateFileSaveService(fileType);

                MemoryStream chartImage = new MemoryStream();
                List<Flower> flowerList = new List<Flower>();
                string figureTitle = "Flower List Figure";

                fileSaveService.CreateFile(chartImage, flowerList, figureTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveJSON(object sender, EventArgs e)
        {
            try
            {
                FileSaveServiceFactory.FileType fileType = FileSaveServiceFactory.FileType.JSON;
                FileSaveService fileSaveService = FileSaveServiceFactory.CreateFileSaveService(fileType);

                MemoryStream chartImage = new MemoryStream();
                List<Flower> flowerList = new List<Flower>();
                string figureTitle = "Flower List Figure";

                fileSaveService.CreateFile(chartImage, flowerList, figureTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveXML(object sender, EventArgs e)
        {
            try
            {
                FileSaveServiceFactory.FileType fileType = FileSaveServiceFactory.FileType.XML;
                FileSaveService fileSaveService = FileSaveServiceFactory.CreateFileSaveService(fileType);

                MemoryStream chartImage = new MemoryStream();
                List<Flower> flowerList = new List<Flower>();
                string figureTitle = "Flower List Figure";

                fileSaveService.CreateFile(chartImage, flowerList, figureTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveDOC(object sender, EventArgs e)
        {
            try
            {
                FileSaveServiceFactory.FileType fileType = FileSaveServiceFactory.FileType.Word;
                FileSaveService fileSaveService = FileSaveServiceFactory.CreateFileSaveService(fileType);

                MemoryStream chartImage = new MemoryStream();
                List<Flower> flowerList = new List<Flower>();
                string figureTitle = "Car List Figure";

                fileSaveService.CreateFile(chartImage, flowerList, figureTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void showStatistics(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ControllerStatistics statistics = new ControllerStatistics(index);
        //        statistics.GetView();
        //        this.vManager.Hide();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void logout(object sender, EventArgs e)
        {
            try
            {
                ControllerLogin login = new ControllerLogin(index);
                login.GetView();
                this.vManager.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setFlowerControls(object sender, EventArgs e)
        {
            try
            {
                if (this.vManager.GetFlowerTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.vManager.GetFlowerTable().SelectedRows[0];

                    uint flowerID = Convert.ToUInt32(drvr.Cells[0].Value);
                    this.vManager.GetFlowerID().Value = flowerID;

                    string flowerName = drvr.Cells[1].Value.ToString();
                    this.vManager.GetFlowerName().Text = flowerName;

                    string color = drvr.Cells[2].Value.ToString();
                    this.vManager.GetColor().Text = color;

                    string price = drvr.Cells[3].Value.ToString();
                    this.vManager.GetPrice().Text = price.ToString();

                    string stock = drvr.Cells[4].Value.ToString();
                    this.vManager.GetStock().Text = stock.ToString();

                    uint shopID = Convert.ToUInt32(drvr.Cells[5].Value);
                    this.vManager.GetShopID().Value = shopID;

                    string imageName = flowerName + "_" + color;

                    string workingDirectory = Environment.CurrentDirectory;
                    workingDirectory = workingDirectory.Substring(0, workingDirectory.Length - 9);

                    string path = workingDirectory + "resources\\flowers\\" + imageName + ".jpg";
                    string secondPath = workingDirectory + "resources\\flowers\\noFlowerFound.jpg";

                    try
                    {
                        this.vManager.GetPictureBox().Image = System.Drawing.Image.FromFile(path);
                    }
                    catch
                    {
                        this.vManager.GetPictureBox().Image = System.Drawing.Image.FromFile(secondPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}

