using SD_FlowerShop_Server.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Repository
{
    public class FlowerRepository : IFlowerRepository
    {
        private Repository repository;

        public FlowerRepository()
        {
            this.repository = Repository.GetInstance();
        }

        public bool AddFlower(Flower flower)
        {
            bool resultFlowers, resultFlowersShop;

            string commandSQL = "insert into Flowers values('";
            commandSQL += flower.FlowerName + "', '" + flower.Color;
            commandSQL += "')";
            resultFlowers = this.repository.CommandSQL(commandSQL);

            string commandSQL2 = "insert into FlowersShop values(";
            commandSQL2 += flower.ShopID;
            commandSQL2 += ", " + flower.Price + ", " + flower.Stock + ")";
            resultFlowersShop = this.repository.CommandSQL(commandSQL2);

            return (resultFlowers && resultFlowersShop);
        }

        public bool DeleteFlower(uint flowerID, uint shopID)
        {
            bool resultFlowers, resultFlowersShop;
            string commandSQL = "delete from FlowersShop where shopID = " + shopID + " and flowerID = " + flowerID;
            resultFlowersShop = this.repository.CommandSQL(commandSQL);

            string command2SQL = "delete from Flowers where flowerID = " + flowerID + ";";
            resultFlowers = this.repository.CommandSQL(command2SQL);

            return (resultFlowers && resultFlowersShop);
        }

        public bool UpdateFlower(Flower flower)
        {
            bool resultFlowers, resultFlowersShop;
            string commandSQL = "update Flowers set flowerName = '";
            commandSQL += flower.FlowerName + "', color = '" + flower.Color;
            commandSQL += "' where flowerID = " + flower.FlowerID;
            resultFlowers = this.repository.CommandSQL(commandSQL);


            string commandSQL2 = "update FlowersShop set price = ";
            commandSQL2 += flower.Price;
            commandSQL2 += ", stock = " + flower.Stock;
            commandSQL2 += " where shopID = " + flower.ShopID + " and flowerID = " + flower.FlowerID;
            resultFlowersShop = this.repository.CommandSQL(commandSQL2);

            return (resultFlowers && resultFlowersShop);
        }

        public DataTable FlowerTable()
        {
            string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
            selectSQL += "FROM Flowers AS F\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
            DataTable flowerTable = this.repository.GetTable(selectSQL);
            if (flowerTable == null || flowerTable.Rows.Count == 0)
            {
                return null;
            }
            return flowerTable;
        }

        public DataTable FlowerTableEmpty()
        {
            string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
            selectSQL += "FROM Flowers AS F\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\nwhere 1=0;";
            DataTable flowerTable = this.repository.GetTable(selectSQL);
            if (flowerTable == null || flowerTable.Rows.Count == 0)
            {
                return null;
            }
            return flowerTable;
        }

        public DataTable FlowerTableEmployee(uint shopID)
        {
            string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock\n";
            selectSQL += "FROM Flowers AS F\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
            selectSQL += "WHERE S.shopID = " + shopID + ";";
            //Debug.WriteLine(selectSQL);
            DataTable flowerTable = this.repository.GetTable(selectSQL);
            if (flowerTable == null || flowerTable.Rows.Count == 0)
            {
                return null;
            }
            return flowerTable;
        }

        public List<Flower> FlowerListEmployee(uint shopID)
        {
            DataTable flowerTable = this.FlowerTableEmployee(shopID);
            if (flowerTable == null)
                return null;
            List<Flower> list = new List<Flower>();
            foreach (DataRow dr in flowerTable.Rows)
            {
                Flower flower = this.convertToFlowerEmployee(dr);
                list.Add(flower);
            }
            return list;
        }

        public List<Flower> FlowerList()
        {
            DataTable flowerTable = this.FlowerTable();
            if (flowerTable == null)
                return null;
            List<Flower> list = new List<Flower>();
            foreach (DataRow dr in flowerTable.Rows)
            {
                Flower flower = this.convertToFlower(dr);
                list.Add(flower);
            }
            return list;
        }

        public List<Flower> FlowerList_ColorPrice(uint shopID)
        {

            if (shopID <= 0)
            {
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "ORDER BY F.color, FS.price" + ";";


                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlower(dr);
                    list.Add(flower);
                }
                return list;

            }
            else
            {

                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE S.shopID = " + shopID;
                selectSQL += "\nORDER BY F.color, FS.price" + ";";


                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlowerEmployee(dr);
                    list.Add(flower);
                }
                return list;
            }
        }

        public List<Flower> FlowerList_Availability(uint shopID)
        {

            if (shopID <= 0)
            {
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE FS.stock > 0" + ";";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlower(dr);
                    list.Add(flower);
                }
                return list;
            }
            else
            {
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE FS.stock > 0" + " AND S.shopID = " + shopID + ";";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlowerEmployee(dr);
                    list.Add(flower);
                }
                return list;
            }
        }


        public List<Flower> FlowerList_Price(string priceString, uint shopID)
        {

            if (shopID <= 0)
            {
                float price = (float)Convert.ToDouble(priceString);
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE FS.price = " + price + ";";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlower(dr);
                    list.Add(flower);
                }
                return list;
            }
            else
            {
                float price = (float)Convert.ToDouble(priceString);
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE FS.price = " + price + " AND FS.shopID = " + shopID + ";";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlowerEmployee(dr);
                    list.Add(flower);
                }
                return list;
            }
        }

        public List<Flower> FlowerList_Color(string color, uint shopID)
        {
            if (shopID <= 0)
            {
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE F.color = '" + color + "';";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlower(dr);
                    list.Add(flower);
                }
                return list;
            }
            else
            {
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE F.color = '" + color + "' AND FS.shopID = " + shopID + ";";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlowerEmployee(dr);
                    list.Add(flower);
                }
                return list;
            }
        }

        public List<Flower> FlowerList_FlowerShop(uint shopID)
        {
            string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
            selectSQL += "FROM Flowers AS F\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
            selectSQL += "WHERE S.shopID = " + shopID + ";";

            DataTable flowerTable = this.repository.GetTable(selectSQL);
            if (flowerTable == null || flowerTable.Rows.Count == 0)
            {
                return null;
            }
            List<Flower> list = new List<Flower>();
            foreach (DataRow dr in flowerTable.Rows)
            {
                Flower flower = this.convertToFlower(dr);
                list.Add(flower);
            }
            return list;
        }

        public List<Flower> FlowerList_Stock(string stockString, uint shopID)
        {

            if (shopID <= 0)
            {
                Debug.WriteLine(stockString);
                int stock = Convert.ToInt32(stockString);
                Debug.WriteLine(stock);
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE FS.stock = " + stock + ";";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlower(dr);
                    list.Add(flower);
                }
                return list;
            }
            else
            {
                int stock = Convert.ToInt32(stockString);
                string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock\n";
                selectSQL += "FROM Flowers AS F\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
                selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
                selectSQL += "WHERE FS.stock = " + stock + " AND FS.shopID = " + shopID + ";";

                DataTable flowerTable = this.repository.GetTable(selectSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                {
                    return null;
                }
                List<Flower> list = new List<Flower>();
                foreach (DataRow dr in flowerTable.Rows)
                {
                    Flower flower = this.convertToFlowerEmployee(dr);
                    list.Add(flower);
                }
                return list;
            }
        }

        private Flower convertToFlowerEmployee(DataRow dataRow)
        {
            int fid = (int)dataRow["flowerID"];
            int stock = (int)dataRow["stock"];
            float price = (float)Convert.ToDouble(dataRow["price"]);

            return new Flower((uint)fid, 0, (string)dataRow["flowerName"], (string)dataRow["color"], (float)price, (int)stock);
        }

        private Flower convertToFlower(DataRow dataRow)
        {
            int fid = (int)dataRow["flowerID"];
            int sid = (int)dataRow["shopID"];
            int stock = (int)dataRow["stock"];
            float price = (float)Convert.ToDouble(dataRow["price"]);
            return new Flower((uint)fid, (uint)sid, (string)dataRow["flowerName"], (string)dataRow["color"], (float)price, (int)stock);
        }

        public Flower SearchFlowerByName(string name)
        {
            try
            {
                string searchSQL = "Select * from FlowerShopMVC.dbo.Flowers where flowerName = '" + name + "'";
                DataTable flowerTable = this.repository.GetTable(searchSQL);
                if (flowerTable == null || flowerTable.Rows.Count == 0)
                    return null;
                DataRow dr = flowerTable.Rows[0];
                return this.convertToFlower(dr);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Flower> SearchFlowerByType(string type)
        {
            string selectSQL = "SELECT F.flowerID, F.flowerName, F.color, FS.price, FS.stock, S.shopID\n";
            selectSQL += "FROM FlowerShopMVC.dbo.Flowers AS F\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.FlowersShop AS FS ON F.flowerID = FS.flowerID\n";
            selectSQL += "JOIN FlowerShopMVC.dbo.Shops AS S ON FS.shopID = S.shopID\n";
            selectSQL += "WHERE F.flowerName = '" + type + "';";
            DataTable flowerTable = this.repository.GetTable(selectSQL);
            if (flowerTable == null || flowerTable.Rows.Count == 0)
                return null;
            List<Flower> list = new List<Flower>();
            foreach (DataRow dr in flowerTable.Rows)
            {
                Flower flower = this.convertToFlower(dr);
                list.Add(flower);
            }
            return list;
        }

    }
}
