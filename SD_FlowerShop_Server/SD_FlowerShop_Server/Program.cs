using SD_FlowerShop_Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CombinedServiceHost host = new CombinedServiceHost();
            host.Start();
            Console.WriteLine("Services are running. Press Enter to exit...");
            Console.ReadLine();
            host.Stop();
        }
    }
}
