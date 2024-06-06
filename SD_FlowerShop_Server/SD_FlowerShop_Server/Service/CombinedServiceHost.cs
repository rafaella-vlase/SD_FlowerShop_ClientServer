using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Service
{
    public class CombinedServiceHost
    {
        private readonly UserServiceHost userServiceHost;
        private readonly FlowerServiceHost flowerServiceHost;

        public CombinedServiceHost()
        {
            userServiceHost = new UserServiceHost();
            flowerServiceHost = new FlowerServiceHost();
        }

        public void Start()
        {
            userServiceHost.Start();
            flowerServiceHost.Start();
        }

        public void Stop()
        {
            userServiceHost.Stop();
            flowerServiceHost.Stop();
        }
    }
}
