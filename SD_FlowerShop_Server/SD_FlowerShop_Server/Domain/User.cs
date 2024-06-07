using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Domain
{
    public class User
    {
        protected uint userID;
        protected string username;
        protected string password;
        protected string role;
        protected uint shopID;
        protected string phoneNumber;
        protected string email;

        public User()
        {
            userID = 1;
            username = "ella";
            password = "stardew";
            role = "Administrator";
            shopID = 0;
            phoneNumber = "123456789";
            email = "test@gmail.com";
        }

        public User(uint userID, string username, string password, string role, uint shopID, string phoneNumber, string email)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.role = role;
            this.shopID = shopID;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public User(User user)
        {
            userID = user.userID;
            username = user.username;
            password = user.password;
            role = user.role;
            shopID = user.shopID;
            phoneNumber = user.phoneNumber;
            email = user.email;
        }

        public uint UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public uint ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public override string ToString()
        {
            string s = "Username: " + username;
            s += "\nPassword: " + password;
            s += "\nRole: " + role;
            s += "\nShopID: " + shopID;
            return s;
        }
    }
}

