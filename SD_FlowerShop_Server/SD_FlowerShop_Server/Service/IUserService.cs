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
    public interface IUserService
    {
        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        bool LoginUser(string username, string password);

        [OperationContract]
        string GetRole(string username, string password);

        [OperationContract]
        string GetShopID(string username);

        [OperationContract]
        bool DeleteUser(uint userID);

        [OperationContract]
        bool UpdateUser(User user);

        [OperationContract]
        DataTable UserTable();

        [OperationContract]

        List<User> UserList();

        [OperationContract]

        List<User> UserList_Role(string searchedRole);

        [OperationContract]
        User SearchUserByID(string id);

        [OperationContract]

        List<User> SearchUserByUsername(string username);

        [OperationContract]

        List<User> SearchUserByRole(string role);
    }
}
