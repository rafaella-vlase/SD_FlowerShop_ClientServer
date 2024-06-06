using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using SD_FlowerShop_Server.Domain;  
using SD_FlowerShop_Server.Repository;

namespace SD_FlowerShop_Server.Service
{
    public class StatisticsService
    {
        private string criterion;
        private List<Flower> flowerList;
        private Dictionary<string, uint> statisticsResult;

        public StatisticsService(string criterion)
        {
            this.criterion = criterion;
            IFlowerRepository iFlowerRepository = new FlowerRepository();
            this.flowerList = iFlowerRepository.FlowerList();
            this.statisticsResult = new Dictionary<string, uint>();
            if (this.flowerList != null && this.flowerList.Count > 0)
            {
                this.statisticalDetermination();
            }
        }

        public string Criterion
        {
            get { return this.criterion; }
            set { this.criterion = value; this.statisticalDetermination(); }
        }

        public List<Flower> FlowerList
        {            
            get { return this.flowerList; }
            set { this.flowerList = value; this.statisticalDetermination(); }
        }

        public Dictionary<string, uint> StatisticsResult
        {
            get { return this.statisticsResult; }
        }
        private void statisticalDetermination()
        {
            foreach (Flower flower in this.flowerList)
            {
                string key = flower.FlowerName.ToUpper();
                if (this.criterion.ToUpper() == "COLOR")
                {
                    key = flower.Color.ToUpper();
                }

                if (this.statisticsResult.ContainsKey(key))
                {
                    this.statisticsResult[key] += 1;
                }
                else
                {
                    this.statisticsResult[key] = 1;
                }
            }

        }
       
    }
}
