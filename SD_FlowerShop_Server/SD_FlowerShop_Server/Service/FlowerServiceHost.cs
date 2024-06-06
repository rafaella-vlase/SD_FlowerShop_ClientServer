using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Service
{
    public class FlowerServiceHost
    {
        private ServiceHost serviceHost;

        public FlowerServiceHost()
        {
            Console.WriteLine("Flower Service Host initialized.");
        }

        public void Start()
        {
            Console.WriteLine("Connecting to Flower Shop DB ...");
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

            IFlowerService flowerService = new FlowerService();
            serviceHost = new ServiceHost(flowerService);

            try
            {
                serviceHost.AddServiceEndpoint(typeof(IFlowerService), tcp, "net.tcp://" + s + ":52001/Flower");
                serviceHost.Open();
                Console.WriteLine("The connection to the DB was done successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to database! " + ex);
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
