﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using SD_FlowerShop_Client.View;
using SD_FlowerShop_Client.Language;
using SD_FlowerShop_Client.Service;
using SD_FlowerShop_Server.Service;
using SD_FlowerShop_Server.Domain;
using SD_FlowerShop_Server.Repository;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Reflection;

namespace SD_FlowerShop_Client.Controller
{
    public class ControllerEmployee
    {
        private LangHelper lang;
        private VEmployee vEmployee;
        private VLogin vLogin;
        private IFlowerService iFlowerService;

        public ControllerEmployee(int index)
        {
            this.vEmployee = new VEmployee(index);
            this.lang = new LangHelper();
            this.lang.Add(this.vEmployee);
            this.createBinding();
            this.eventsManagement();
        }

        public VEmployee GetView()
        {
            this.vEmployee.Show();
            return this.vEmployee;
        }

        private void createBinding()
        {
            ChannelFactory<IFlowerService> channelEmployee;
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
            channelEmployee = new ChannelFactory<IFlowerService>(tcp, "net.tcp://" + s + ":52001/Flower");
            try
            {
                this.iFlowerService = channelEmployee.CreateChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void eventsManagement()
        {
            this.vEmployee.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vEmployee.GetAddButton().Click += new EventHandler(addFlower);
            this.vEmployee.GetUpdateButton().Click += new EventHandler(updateFlower);
            this.vEmployee.GetDeleteButton().Click += new EventHandler(deleteFlower);
            this.vEmployee.GetSearchButton().Click += new EventHandler(searchBy);
            this.vEmployee.GetFilterByBox().SelectedIndexChanged += new EventHandler(filterBy);
            this.vEmployee.GetOrderByBox().SelectedIndexChanged += new EventHandler(orderBy);
            this.vEmployee.GetViewAllButton().Click += new EventHandler(viewAll);
            this.vEmployee.GetSaveCSVButton().Click += new EventHandler(saveCSV);
            this.vEmployee.GetSaveJSONButton().Click += new EventHandler(saveJSON);
            this.vEmployee.GetSaveXMLButton().Click += new EventHandler(saveXML);
            this.vEmployee.GetSaveDOCButton().Click += new EventHandler(saveDOC);
            this.vEmployee.GetLogoutButton().Click += new EventHandler(logout);
            this.vEmployee.GetFlowerTable().RowStateChanged += new DataGridViewRowStateChangedEventHandler(setFlowerControls);
            this.vEmployee.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vEmployee.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vEmployee.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vEmployee.GetLanguageBox().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void addFlower(object sender, EventArgs e)
        {
            try
            {
                Flower flower = this.validInformation();
                if (flower != null)
                {
                    bool result = this.iFlowerService.AddFlower(flower);
                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxAddSuccess"));

                        if (this.vEmployee.GetFlowerTable().Columns.Contains("shopID"))
                        {
                            this.vEmployee.GetFlowerTable().Columns.Remove("shopID");
                        }

                        this.resetGUIControls();

                        if (this.vEmployee.GetFlowerTable() == null)
                            MessageBox.Show(lang.GetString("messageBoxNoData"));

                    }
                    else MessageBox.Show(lang.GetString("messageBoxAddFail"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void updateFlower(object sender, EventArgs e)
        {
            try
            {
                Flower flower = this.validInformation();

                if (flower != null)
                {
                    bool result = this.iFlowerService.UpdateFlower(flower);

                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxUpdateSuccess"));
                        if (this.vEmployee.GetFlowerTable().Columns.Contains("shopID"))
                            this.vEmployee.GetFlowerTable().Columns.Remove("shopID");
                        this.resetGUIControls();

                        if (this.vEmployee.GetFlowerTable() == null)
                            MessageBox.Show(lang.GetString("messageBoxNoData"));
                    }
                    else MessageBox.Show(lang.GetString("messageBoxUpdateFail"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteFlower(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(this.vEmployee.GetFlowerID().Value))
                {
                    bool result = this.iFlowerService.DeleteFlower(Convert.ToUInt32(this.vEmployee.GetFlowerID().Value), shopIDEmployee);

                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxDeleteSuccess"));
                        if (this.vEmployee.GetFlowerTable().Columns.Contains("shopID"))
                            this.vEmployee.GetFlowerTable().Columns.Remove("shopID");
                        this.resetGUIControls();

                        if (this.vEmployee.GetFlowerTable() == null)
                            MessageBox.Show(lang.GetString("messageBoxNoData"));
                    }
                    else MessageBox.Show(lang.GetString("messageBoxDeleteFail"));
                }
                else MessageBox.Show(lang.GetString("messageBoxNoFlowerSelected"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void searchBy(object sender, EventArgs e)
        {
            try
            {
                if (this.vEmployee.GetFlowerTable() != null)
                {
                    this.vEmployee.GetFlowerTable().DataSource = this.iFlowerService.FlowerTableEmpty();
                }
                if (this.vEmployee.GetSearch().Text.Length > 0)
                {
                    string searchedFlower = this.vEmployee.GetSearch().Text;
                    List<Flower> list = this.iFlowerService.SearchFlowerByType(searchedFlower);

                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("flowerID", typeof(uint));
                    dt.Columns.Add("flowerName", typeof(string));
                    dt.Columns.Add("color", typeof(string));
                    dt.Columns.Add("price", typeof(float));
                    dt.Columns.Add("stock", typeof(int));
                    dt.Columns.Add("shopID", typeof(uint));


                    if (list != null && list.Count > 0)
                    {
                        foreach (Flower f in list)
                        {
                            DataRow row = dt.NewRow();

                            row["flowerID"] = f.FlowerID;
                            row["flowerName"] = f.FlowerName;
                            row["color"] = f.Color;
                            row["price"] = f.Price;
                            row["stock"] = f.Stock;
                            row["shopID"] = f.ShopID;

                            dt.Rows.Add(row);
                        }

                        this.vEmployee.GetFlowerTable().DataSource = dt;
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
                string selectedOption = this.vEmployee.GetFilterByBox().SelectedItem.ToString();

                if (this.vEmployee.GetFlowerTable() != null)
                    this.vEmployee.GetFlowerTable().DataSource = this.iFlowerService.FlowerTableEmpty();
                if (selectedOption.Length > 0)
                {
                    if (selectedOption.ToUpper() == "AVAILABILITY")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_Availability(shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "PRICE")
                    {
                        Debug.WriteLine(this.vEmployee.GetPrice().ToString());
                        List<Flower> list = this.iFlowerService.FlowerList_Price(this.vEmployee.GetPrice().Text, shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "COLOR")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_Color(this.vEmployee.GetColor().Text, shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "STOCK")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_Stock(this.vEmployee.GetStock().Text, shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
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
                if (this.vEmployee.GetFlowerTable() != null)
                    this.vEmployee.GetFlowerTable().DataSource = this.iFlowerService.FlowerTableEmpty();

                string selectedOption = this.vEmployee.GetOrderByBox().SelectedItem.ToString();
                if (selectedOption.Length > 0)
                {
                    if (selectedOption.ToUpper() == "NONE")
                    {
                        this.vEmployee.GetFlowerTable().DataSource = this.iFlowerService.FlowerTableEmployee(shopIDEmployee);
                    }
                    else if (selectedOption.ToUpper() == "COLOR AND PRICE")
                    {
                        List<Flower> list = this.iFlowerService.FlowerList_ColorPrice(shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
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
                if (this.vEmployee.GetFlowerTable() != null)
                {
                    this.vEmployee.GetFlowerTable().DataSource = this.iFlowerService.FlowerTableEmpty();
                    this.vEmployee.GetFlowerTable().DataSource = this.iFlowerService.FlowerTableEmployee(shopIDEmployee);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void logout(object sender, EventArgs e)
        {
            try
            {
                ControllerLogin login = new ControllerLogin(index);
                login.GetView();
                this.vEmployee.Hide();
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
                if (this.vEmployee.GetFlowerTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.vEmployee.GetFlowerTable().SelectedRows[0];

                    uint flowerID = Convert.ToUInt32(drvr.Cells[0].Value);
                    this.vEmployee.GetFlowerID().Value = flowerID;

                    string flowerName = drvr.Cells[1].Value.ToString();
                    this.vEmployee.GetFlowerName().Text = flowerName;

                    string color = drvr.Cells[2].Value.ToString();
                    this.vEmployee.GetColor().Text = color;

                    string price = drvr.Cells[3].Value.ToString();
                    this.vEmployee.GetPrice().Text = price.ToString();

                    string stock = drvr.Cells[4].Value.ToString();
                    this.vEmployee.GetStock().Text = stock.ToString();

                    string imageName = flowerName + "_" + color;

                    string workingDirectory = Environment.CurrentDirectory;
                    workingDirectory = workingDirectory.Substring(0, workingDirectory.Length - 9);

                    string path = workingDirectory + "resources\\flowers\\" + imageName + ".jpg";
                    string secondPath = workingDirectory + "resources\\flowers\\noFlowerFound.jpg";

                    try
                    {
                        this.vEmployee.GetPictureBox().Image = System.Drawing.Image.FromFile(path);
                    }
                    catch
                    {
                        this.vEmployee.GetPictureBox().Image = System.Drawing.Image.FromFile(secondPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void resetGUIControls()
        {
            this.vEmployee.GetFlowerID().Value = 1;
            this.vEmployee.GetFlowerName().Text = string.Empty;
            this.vEmployee.GetColor().Text = string.Empty;
            this.vEmployee.GetPrice().Text = string.Empty;
            this.vEmployee.GetStock().Text = string.Empty;
            this.vEmployee.GetOrderByBox().SelectedIndex = 0;
            this.vEmployee.GetFilterByBox().SelectedIndex = 0;
            this.vEmployee.GetSearch().Text = string.Empty;
            this.vEmployee.GetFlowerTable().DataSource = this.iFlowerService.FlowerTableEmpty();
            this.vEmployee.GetFlowerTable().DataSource = iFlowerService.FlowerTableEmployee(shopIDEmployee);
        }

        private Flower validInformation()
        {
            uint flowerID = (uint)this.vEmployee.GetFlowerID().Value;
            if (flowerID == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxFlowerIDNonZero"));
                return null;
            }

            string flowerName = this.vEmployee.GetFlowerName().Text;
            if (flowerName == null || flowerName.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxFlowerNameEmpty"));
                return null;
            }

            string color = this.vEmployee.GetColor().Text;
            if (flowerName == null || flowerName.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxColorEmpty"));
                return null;
            }

            float price = (float)Convert.ToDouble(this.vEmployee.GetPrice().Text);
            if (price <= 0)
            {
                MessageBox.Show(lang.GetString("messageBoxPriceHigher"));
                return null;
            }

            int stock = Convert.ToInt32(this.vEmployee.GetStock().Text);
            if (stock < 0)
            {
                MessageBox.Show(lang.GetString("messageBoxStockMinZero"));
                return null;
            }

            string shopIDString = IUserRepository.GetShopID(username);
            uint shopID = Convert.ToUInt32(shopIDString);
            if (shopID == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxShopIDNonZero"));
                return null;
            }
            return new Flower(flowerID, shopID, flowerName, color, price, stock);
        }
    }
}
}
