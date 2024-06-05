using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Domain
{
    public interface IFlowerRepository 
    {
        bool AddFlower(Flower flower);
        bool DeleteFlower(uint flowerID, uint shopID);
        bool UpdateFlower(Flower flower);
        DataTable FlowerTable();
        DataTable FlowerTableEmpty();
        DataTable FlowerTableEmployee(uint shopID);
        List<Flower> FlowerListEmployee(uint shopID);
        List<Flower> FlowerList();
        List<Flower> FlowerList_ColorPrice(uint shopID);
        List<Flower> FlowerList_Availability(uint shopID);
        List<Flower> FlowerList_Price(string priceString, uint shopID);
        List<Flower> FlowerList_Color(string color, uint shopID);
        List<Flower> FlowerList_FlowerShop(uint shopID);
        List<Flower> FlowerList_Stock(string stockString, uint shopID);
        Flower SearchFlowerByName(string name);
        List<Flower> SearchFlowerByType(string type);
    }
}
