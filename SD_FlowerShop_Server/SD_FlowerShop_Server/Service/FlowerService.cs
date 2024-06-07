using SD_FlowerShop_Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD_FlowerShop_Server.Repository;
using System.Data;
using System.ServiceModel;
using System.Runtime.ConstrainedExecution;

namespace SD_FlowerShop_Server.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false, InstanceContextMode = InstanceContextMode.Single)]
    internal class FlowerService : IFlowerService
    {
        private IFlowerRepository iFlowerRepository;

        public FlowerService()
        {
            this.iFlowerRepository = new FlowerRepository();
        }

        public bool AddFlower(Flower flower)
        { 
            return this.iFlowerRepository.AddFlower(flower);
        }

        public bool DeleteFlower(uint flowerID, uint shopID)
        {
            return this.iFlowerRepository.DeleteFlower(flowerID, shopID);
        }

        public bool UpdateFlower(Flower flower)
        {
           return this.iFlowerRepository.UpdateFlower(flower);
        }

        public DataTable FlowerTable()
        {
           return this.iFlowerRepository.FlowerTable();
        }

        public DataTable FlowerTableEmpty()
        {
           return this.iFlowerRepository.FlowerTableEmpty();
        }

        public DataTable FlowerTableEmployee(uint shopID)
        {
            return this.iFlowerRepository.FlowerTableEmployee(shopID);
        }

        public List<Flower> FlowerListEmployee(uint shopID)
        {
            return this.iFlowerRepository.FlowerListEmployee(shopID);
        }

        public List<Flower> FlowerList()
        {
            return this.iFlowerRepository.FlowerList();
        }

        public List<Flower> FlowerList_ColorPrice(uint shopID)
        {
            return this.iFlowerRepository.FlowerList_ColorPrice(shopID);
        }

        public List<Flower> FlowerList_Availability(uint shopID)
        {
            return this.iFlowerRepository.FlowerList_Availability(shopID);
        }

        public List<Flower> FlowerList_Price(string priceString, uint shopID)
        {
            return this.iFlowerRepository.FlowerList_Price(priceString, shopID);
        }

        public List<Flower> FlowerList_Color(string color, uint shopID)
        {
            return this.iFlowerRepository.FlowerList_Color(color, shopID);
        }

        public List<Flower> FlowerList_FlowerShop(uint shopID)
        {
            return this.iFlowerRepository.FlowerList_FlowerShop(shopID);
        }

        public List<Flower> FlowerList_Stock(string stockString, uint shopID)
        {
            return this.iFlowerRepository.FlowerList_Stock(stockString, shopID);
        }

        public Flower SearchFlowerByName(string name)
        {
            return this.iFlowerRepository.SearchFlowerByName(name);
        }

        public List<Flower> SearchFlowerByType(string type)
        {
            return this.iFlowerRepository.SearchFlowerByType(type);
        }

        public List<Flower> SearchFlowerByTypeEmployee(string type, string shopID)
        {
            return this.iFlowerRepository.SearchFlowerByTypeEmployee(type, shopID);
        }

        public Dictionary<string, uint> FlowerStatistics(string criterion)
        {
            StatisticsService statisticsService = new StatisticsService(criterion);
            return statisticsService.StatisticsResult;
        }
    }
}
