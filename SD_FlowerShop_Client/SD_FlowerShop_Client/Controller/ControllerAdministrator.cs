using SD_FlowerShop_Client.Language;
using SD_FlowerShop_Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using SD_FlowerShop_Server.Service;
using System.Configuration;
using System.ServiceModel;
using SD_FlowerShop_Server.Domain;
using System.Data;
using SD_FlowerShop_Server.Repository;
using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SD_FlowerShop_Client.Controller
{
    public class ControllerAdministrator
    {
        private VAdministrator vAdministrator;
        private IUserService iUserService;
        private VLogin vLogin;
        private LangHelper lang;
        private int index;

        public ControllerAdministrator(int index)
        {
            this.vAdministrator = new VAdministrator(index);
            this.vLogin = new VLogin(index);
            this.lang = new LangHelper();
            this.lang.Add(this.vAdministrator);
            this.index = index;

            this.createBindings();
            this.eventsManagement();
        }

        public VAdministrator GetView()
        {
            this.vAdministrator.Show();
            return this.vAdministrator;
        }

        private void createBindings()
        {
            ChannelFactory<IUserService> channelAdmin;
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
            channelAdmin = new ChannelFactory<IUserService>(tcp, "net.tcp://" + s + ":52001/User");
            try
            {
                this.iUserService = channelAdmin.CreateChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void eventsManagement()
        {
            this.vAdministrator.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vAdministrator.GetAddButton().Click += new EventHandler(addUser);
            this.vAdministrator.GetUpdateButton().Click += new EventHandler(updateUser);
            this.vAdministrator.GetDeleteButton().Click += new EventHandler(deleteUser);
            this.vAdministrator.GetSearchButton().Click += new EventHandler(searchUser);
            this.vAdministrator.GetViewAllButton().Click += new EventHandler(viewAllUsers);
            this.vAdministrator.GetLogoutButton().Click += new EventHandler(logout);
            this.vAdministrator.GetUserTable().RowStateChanged += new DataGridViewRowStateChangedEventHandler(setUserControls);
            this.vAdministrator.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vAdministrator.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vAdministrator.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vAdministrator.GetLanguageBox().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void addUser(object sender, EventArgs e)
        {
            try
            {
                User user = this.validInformation();

                if (user != null)
                {
                    bool result = this.iUserService.AddUser(user);
                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxAddSuccess"));
                        this.resetGUIControls();

                        if (this.vAdministrator.GetUserTable() == null)
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

        private void notifyRepairedWhatsapp()
        {
            try
            {
                if (this.vAdministrator.GetUserTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.vAdministrator.GetUserTable().SelectedRows[0];



                    TwilioClient.Init(".", "..");

                    var message = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber("whatsapp:+12292109286"),
                        to: new Twilio.Types.PhoneNumber("whatsapp:+40765211258"),
                        body: "Your credential changed!"
                        );

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void notifyRepairedEmail()
        {
            try
            {

                using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
                {
                    mail.From = new MailAddress("baldnikobellic@gmail.com");
                    mail.To.Add("prowhite91@gmail.com");
                    mail.Subject = "Account changes";
                    mail.Body = "<h1>Your credential changed!</h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("baldnikobellic@gmail.com", "olacikita");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void updateUser(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(this.vAdministrator.GetUserID().Value))
                {
                    User user = this.validInformation();
                    if (user != null)
                    {
                        bool result = this.iUserService.UpdateUser(user);
                        if (result)
                        {
                            MessageBox.Show(lang.GetString("messageBoxUpdateSuccess"));
                            notifyRepairedEmail();
                            notifyRepairedWhatsapp();
                            this.resetGUIControls();
                        }
                        else MessageBox.Show(lang.GetString("messageBoxUpdateFail"));
                    }
                }
                else MessageBox.Show(lang.GetString("messageBoxNoUserSelected"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteUser(object sender, EventArgs e)
        {
            try
            {
                User user = this.validInformation();

                if (user != null)
                {
                    bool result = this.iUserService.DeleteUser((uint)this.vAdministrator.GetUserID().Value);
                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxDeleteSuccess"));
                        this.resetGUIControls();

                        if (this.vAdministrator.GetUserTable() == null)
                        {
                            MessageBox.Show(lang.GetString("messageBoxNoData"));
                        }
                    }
                    else MessageBox.Show(lang.GetString("messageBoxDeleteFail"));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void searchUser(object sender, EventArgs e)
        {
            try
            {
                if (this.vAdministrator.GetUserTable() != null)
                    this.vAdministrator.GetUserTable().Rows.Clear();
                if (this.vAdministrator.GetSearch().Text != null && this.vAdministrator.GetSearch().Text.Length > 0)
                {

                    List<User> list = this.iUserService.SearchUserByRole(this.vAdministrator.GetSearch().Text);

                    if (list == null)
                    {
                        MessageBox.Show(lang.GetString("messageBoxNoUserDesiredRole"));
                    }
                    else
                    {
                        foreach(User u in list)
                        {
                            this.vAdministrator.GetUserTable().Rows.Add(u.UserID, u.Username, u.Password, u.Role, u.ShopID, u.PhoneNumber, u.Email);

                        }
                    }

                }
                else MessageBox.Show(lang.GetString("messageBoxSearchEmpty"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void viewAllUsers(object sender, EventArgs e)
        {
            try
            {
                if (this.vAdministrator.GetUserTable() != null)
                {
                    this.vAdministrator.GetUserTable().Rows.Clear();
                    List<User> list = this.iUserService.UserList();
                    foreach (User u in list) {
                        this.vAdministrator.GetUserTable().Rows.Add(u.UserID, u.Username, u.Password, u.Role, u.ShopID, u.PhoneNumber, u.Email);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void logout(object sender, EventArgs e)
        {
            try
            {
                ControllerLogin login = new ControllerLogin(0);
                login.GetView();
                this.vAdministrator.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setUserControls(object sender, EventArgs e)
        {
            try
            {
                if (this.vAdministrator.GetUserTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.vAdministrator.GetUserTable().SelectedRows[0];

                    uint userID = Convert.ToUInt32(drvr.Cells[0].Value);
                    this.vAdministrator.GetUserID().Value = userID;

                    string username = drvr.Cells[1].Value.ToString();
                    this.vAdministrator.GetUsername().Text = username;

                    string password = drvr.Cells[2].Value.ToString();
                    this.vAdministrator.GetPassword().Text = password;

                    string role = drvr.Cells[3].Value.ToString();
                    this.vAdministrator.GetRole().Text = role;

                    uint shopID;
                    if (drvr.Cells[4].Value == DBNull.Value)
                    {
                        shopID = 1;
                        this.vAdministrator.GetShopID().Value = shopID;
                    }
                    else if (drvr.Cells[4].Value != null)
                    {
                        shopID = Convert.ToUInt32(drvr.Cells[4].Value);
                        this.vAdministrator.GetShopID().Value = shopID;
                    }

                    string phoneNumber = drvr.Cells[5].Value.ToString();
                    this.vAdministrator.GetPhoneNumber().Text = phoneNumber;

                    string email = drvr.Cells[6].Value.ToString();
                    this.vAdministrator.GetEmail().Text = email;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void resetGUIControls()
        {
            this.vAdministrator.GetUserID().Value = 1;
            this.vAdministrator.GetUsername().Text = string.Empty;
            this.vAdministrator.GetPassword().Text = string.Empty;
            this.vAdministrator.GetRole().Text = string.Empty;
            this.vAdministrator.GetSearch().Text = string.Empty;
            this.vAdministrator.GetUserTable().Rows.Clear();
            List<User> list = this.iUserService.UserList();

            foreach (User u in list)
            {
                this.vAdministrator.GetUserTable().Rows.Add(u.UserID, u.Username, u.Password, u.Role, u.ShopID, u.PhoneNumber, u.Email);
            }
        }

        private User validInformation()
        {
            if (this.vAdministrator.GetUserID().Value == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxUserIDNonZero"));
                return null;
            }

            if (this.vAdministrator.GetUsername().Text == null || this.vAdministrator.GetUsername().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxUsernameEmpty"));
                return null;
            }

            if (this.vAdministrator.GetPassword().Text == null || this.vAdministrator.GetPassword().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxPasswordEmpty"));
                return null;
            }

            if (this.vAdministrator.GetRole().Text == null || this.vAdministrator.GetRole().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxRoleEmpty"));
                return null;
            }

            if (this.vAdministrator.GetShopID().Value == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxShopIDNonZero"));
                return null;
            }

            if(this.vAdministrator.GetPhoneNumber().Text == null || this.vAdministrator.GetPhoneNumber().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxPhoneNumberEmpty"));
                return null;
            }

            if (this.vAdministrator.GetEmail().Text == null || this.vAdministrator.GetEmail().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxEmailEmpty"));
                return null;
            }
            return new User((uint)this.vAdministrator.GetUserID().Value, this.vAdministrator.GetUsername().Text, this.vAdministrator.GetPassword().Text, this.vAdministrator.GetRole().Text, (uint)this.vAdministrator.GetShopID().Value, this.vAdministrator.GetPhoneNumber().Text, this.vAdministrator.GetEmail().Text);
        }
    }
}
