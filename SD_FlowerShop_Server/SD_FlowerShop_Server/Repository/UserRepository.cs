using SD_FlowerShop_Server.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Repository
{
    public class UserRepository: IUserRepository
    {
        private Repository repository;

        public UserRepository()
        {
            this.repository = Repository.GetInstance();
        }

        public bool AddUser(User user)
        {
            if (user.Role == "Manager" || user.Role == "Administrator")
            {
                string commandSQL = "insert into Users values('";
                commandSQL += user.Username + "','" + user.Password + "','" + user.Role;
                commandSQL += "', " + "NULL" + ")";
                return this.repository.CommandSQL(commandSQL);
            }
            else
            {
                string commandSQL = "insert into Users values('";
                commandSQL += user.Username + "','" + user.Password + "','" + user.Role;
                commandSQL += "', " + user.ShopID + ")";
                return this.repository.CommandSQL(commandSQL);
            }
        }

        public bool LoginUser(string username, string password)
        {
            string commandSQL = "SELECT * FROM [Users] WHERE username = '";
            commandSQL += username + "'" + "AND password = '";
            commandSQL += password + "'";
            DataTable userTable = this.repository.GetTable(commandSQL);

            if (userTable != null || userTable.Rows.Count != 0)
            {
                return true;
            }

            return false;
        }

        public string GetRole(string username, string password)
        {
            string commandSQL = "SELECT * FROM [Users] WHERE username = '";
            commandSQL += username + "' AND password = '" + password + "'";
            DataTable userTable = this.repository.GetTable(commandSQL);

            if (userTable != null || userTable.Rows.Count != 0)
            {
                DataRow row = userTable.Rows[0];
                return row["role"].ToString();
            }

            return "";
        }

        public string GetShopID(string username)
        {
            string commandSQL = "SELECT shopID FROM [Users] WHERE username = '" + username + "' and shopID >= 1;";
            DataTable userTable = this.repository.GetTable(commandSQL);

            if (userTable != null || userTable.Rows.Count != 0)
            {
                DataRow row = userTable.Rows[0];
                return row["shopID"].ToString();
            }

            return "";
        }


        public bool DeleteUser(uint userID)
        {
            string commandSQL = "delete from [Users] where userID = " + userID;
            return this.repository.CommandSQL(commandSQL);
        }

        public bool UpdateUser(User user)
        {
            if (user.Role == "Manager" || user.Role == "Administrator")
            {
                string commandSQL = "update [Users] set username = '";
                commandSQL += user.Username + "', password = '" + user.Password;
                commandSQL += "', role = '" + user.Role;
                commandSQL += "', shopID = " + "NULL";
                commandSQL += " where userID = " + user.UserID;
                return this.repository.CommandSQL(commandSQL);
            }
            else
            {
                string commandSQL = "update [Users] set username = '";
                commandSQL += user.Username + "', password = '" + user.Password;
                commandSQL += "', role = '" + user.Role;
                commandSQL += "', shopID = " + user.ShopID;
                commandSQL += " where userID = " + user.UserID;
                return this.repository.CommandSQL(commandSQL);
            }
        }

        public DataTable UserTable()
        {
            string selectSQL = "Select * from [Users] order by userID";
            DataTable userTable = this.repository.GetTable(selectSQL);
            if (userTable == null || userTable.Rows.Count == 0)
                return null;
            return userTable;
        }

        public List<User> UserList()
        {
            DataTable userTable = this.UserTable();
            if (userTable == null)
                return null;
            List<User> list = new List<User>();
            foreach (DataRow dr in userTable.Rows)
            {
                User user = this.convertToUser(dr);
                list.Add(user);
            }
            return list;
        }

        public List<User> UserList_Role(string searchedRole)
        {
            string selectSQL = "Select * from [Users] where role ='";
            selectSQL += searchedRole + "' order by username";
            DataTable userTable = this.repository.GetTable(selectSQL);
            if (userTable == null || userTable.Rows.Count == 0)
                return null;
            List<User> list = new List<User>();
            foreach (DataRow dr in userTable.Rows)
            {
                User user = this.convertToUser(dr);
                list.Add(user);
            }
            return list;
        }

        public User SearchUserByID(string id)
        {
            try
            {
                int ID = Convert.ToInt32(id);
                string searchSQL = "Select * from [Users] where userID = " + ID;
                DataTable userTable = this.repository.GetTable(searchSQL);
                if (userTable == null || userTable.Rows.Count == 0)
                    return null;
                DataRow dr = userTable.Rows[0];
                return this.convertToUser(dr);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<User> SearchUserByUsername(string username)
        {
            string selectSQL = "Select * from [Users] where username ='" + username + "'";
            DataTable userTable = this.repository.GetTable(selectSQL);
            if (userTable == null || userTable.Rows.Count == 0)
                return null;
            List<User> list = new List<User>();
            foreach (DataRow dr in userTable.Rows)
            {
                User user = this.convertToUser(dr);
                list.Add(user);
            }
            return list;
        }

        public List<User> SearchUserByRole(string role)
        {
            string selectSQL = "Select * from [Users] where role ='" + role + "'";
            DataTable userTable = this.repository.GetTable(selectSQL);
            if (userTable == null || userTable.Rows.Count == 0)
                return null;
            List<User> list = new List<User>();
            foreach (DataRow dr in userTable.Rows)
            {
                User user = this.convertToUser(dr);
                list.Add(user);
            }
            return list;
        }

        private User convertToUser(DataRow dataRow)
        {
            int shopID = -1;
            int id = (int)dataRow["userID"];
            if (dataRow["shopID"] == DBNull.Value)
                shopID = 1;
            else
                shopID = (int)dataRow["shopID"];
            return new User((uint)id, (string)dataRow["username"], (string)dataRow["password"], (string)dataRow["role"], (uint)shopID);
        }

    }
}
