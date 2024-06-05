using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD_FlowerShop_Server.Domain;
using System.ServiceModel;
using System.Data;

namespace SD_FlowerShop_Server.Service
{
    [ServiceContract]
    public interface IFlowerService
    {
        [OperationContract]
        bool AddFlower(Flower flower);

        [OperationContract]

        bool DeleteFlower(uint flowerID, uint shopID);

        [OperationContract]

        bool UpdateFlower(Flower flower);

        [OperationContract]

        DataTable FlowerTable();

        [OperationContract]

        DataTable FlowerTableEmpty();

        [OperationContract]

        DataTable FlowerTableEmployee(uint shopID);

        [OperationContract]

        List<Flower> FlowerListEmployee(uint shopID);

        [OperationContract]

        List<Flower> FlowerList();

        [OperationContract]

        List<Flower> FlowerList_ColorPrice(uint shopID);

        [OperationContract]

        List<Flower> FlowerList_Availability(uint shopID);

        [OperationContract]

        List<Flower> FlowerList_Price(string priceString, uint shopID);

        [OperationContract]

        List<Flower> FlowerList_Color(string color, uint shopID);

        [OperationContract]

        List<Flower> FlowerList_FlowerShop(uint shopID);

        [OperationContract]

        List<Flower> FlowerList_Stock(string stockString, uint shopID);

        [OperationContract]

        Flower SearchFlowerByName(string name);

        [OperationContract]

        List<Flower> SearchFlowerByType(string type);
    }
}
