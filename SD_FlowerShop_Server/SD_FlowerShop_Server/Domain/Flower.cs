using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Domain
{
    public class Flower
    {
        protected uint flowerID;
        protected uint shopID;
        protected string flowerName;
        protected string color;
        protected float price;
        protected int stock;

        public Flower()
        {
            flowerID = 1;
            shopID = 1;
            price = 15;
            stock = 20;
            color = "Red";
            flowerName = "Rose";
        }

        public Flower(uint flowerID, uint shopID, string flowerName, string color, float price, int stock)
        {
            this.flowerID = flowerID;
            this.shopID = shopID;
            this.price = price;
            this.stock = stock;
            this.color = color;
            this.flowerName = flowerName;
        }

        public Flower(Flower flower)
        {
            flowerID = flower.flowerID;
            shopID = flower.shopID;
            price = flower.price;
            stock = flower.stock;
            color = flower.color;
            flowerName = flower.flowerName;
        }

        public uint FlowerID
        {
            get { return flowerID; }
            set { flowerID = value; }
        }

        public uint ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string FlowerName
        {
            get { return flowerName; }
            set { flowerName = value; }
        }

        public override string ToString()
        {
            string s = "Flower: " + flowerName;
            s += "Flower ID: " + flowerID;
            s += " Florist: " + shopID;
            s += " Color: " + color;
            s += " Price: " + price;
            s += " Stock = " + stock;
            return s;
        }
    }
}
}
