using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Configuration;

namespace SD_FlowerShop_Server.Service
{
    public class UserServiceHost
    {
        private ServiceHost serviceHost;

        public UserServiceHost()
        {
            Console.WriteLine("User Service Host initialized.");
        }

        public void Start()
        {
            Console.WriteLine("Connecting to Service Auto DB ...");
            NetTcpBinding tcp = new NetTcpBinding
            {
                OpenTimeout = new TimeSpan(0, 60, 0),
                SendTimeout = new TimeSpan(0, 60, 0),
                ReceiveTimeout = new TimeSpan(0, 60, 0),
                CloseTimeout = new TimeSpan(0, 60, 0),
                MaxReceivedMessageSize = int.MaxValue
            };
            tcp.ReaderQuotas.MaxArrayLength = int.MaxValue;

            string s = ConfigurationManager.ConnectionStrings["IPAdress"].ConnectionString;
            tcp.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            tcp.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;

            IUserService userService = new UserService();
            serviceHost = new ServiceHost(userService);

            try
            {
                serviceHost.AddServiceEndpoint(typeof(IUserService), tcp, "net.tcp://" + s + ":52001/User");
                serviceHost.Open();
                Console.WriteLine("The connection to the DB was done successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to the database! " + ex);
            }
        }

        public void Stop()
        {
            if (serviceHost != null)
            {
                try
                {
                    serviceHost.Close();
                    Console.WriteLine("ServiceHost closed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to close ServiceHost! " + ex);
                }
            }
        }
    }
}
