using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Domain
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        bool LoginUser(string username, string password);
        string GetRole(string username, string password);
        string GetShopID(string username);
        bool DeleteUser(uint userID);
        bool UpdateUser(User user);
        DataTable UserTable();
        List<User> UserList();
        List<User> UserList_Role(string searchedRole);
        User SearchUserByID(string id);
        List<User> SearchUserByUsername(string username);
        List<User> SearchUserByRole(string role);

    }
}
