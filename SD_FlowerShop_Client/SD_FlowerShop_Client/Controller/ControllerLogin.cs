using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD_FlowerShop_Server.Service;
using SD_FlowerShop_Server.Domain;
using SD_FlowerShop_Server.Repository;
using SD_FlowerShop_Client.View;
using SD_FlowerShop_Client.Language;
using System.Windows.Forms;
using System.ServiceModel;
using System.Configuration;
using System.Diagnostics;

namespace SD_FlowerShop_Client.Controller
{
    public class ControllerLogin
    {
        private LangHelper lang;
        private VLogin vLogin;
        private IUserService iUserService;
        private int index;

        public ControllerLogin(int index)
        {
            this.vLogin = new VLogin(index);
            this.lang = new LangHelper();
            this.index = index;
            this.createBinding();
            this.eventsManagement();      
        }

        private void createBinding()
        {
            ChannelFactory<IUserService> channelEmployee;
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
            channelEmployee = new ChannelFactory<IUserService>(tcp, "net.tcp://" + s + ":52001/User");
            try
            {
                this.iUserService = channelEmployee.CreateChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public VLogin GetView()
        {
            this.vLogin.Show();
            return this.vLogin;
        }

        private void eventsManagement()
        {
            this.vLogin.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vLogin.GetLogin().Click += new EventHandler(login);
            this.vLogin.GetLanguage().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vLogin.GetLanguage().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vLogin.GetLanguage().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vLogin.GetLanguage().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void login(object sender, EventArgs e)
        {
            try
            {
                string username = this.vLogin.GetUsername().Text;
                string password = this.vLogin.GetPassword().Text;

                if (username.Length > 0 && password.Length > 0)
                {
                    bool result = this.iUserService.LoginUser(username, password);
                    if (result == true)
                    {
                        string role = this.iUserService.GetRole(username, password);
                        if (role.Equals("Employee"))
                        {
                            this.vLogin.Hide();
                            Debug.WriteLine(index + " " + username);
                            ControllerEmployee controllerEmployee = new ControllerEmployee(index, username);
                            controllerEmployee.GetView();

                        }
                        else if (role.Equals("Manager"))
                        {
                            this.vLogin.Hide();
                            
                            ControllerManager controllerManager = new ControllerManager(index);
                            controllerManager.GetView();
                        }
                        else if (role.Equals("Administrator"))
                        {
                            this.vLogin.Hide();
                            ControllerAdministrator controllerAdministrator = new ControllerAdministrator(index);
                            controllerAdministrator.GetView();
                        }
                    }
                    else MessageBox.Show("Wrong username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

