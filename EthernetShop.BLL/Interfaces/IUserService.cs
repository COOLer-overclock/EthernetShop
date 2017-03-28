using EthernetShop.BLL.DTO;
using System;
using System.Collections.Generic;

namespace EthernetShop.BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserAddDTO userAddDTO);
        bool UserLogIn(UserLogInDTO userLogInDTO);
        void UserLogOut();
        IEnumerable<UserDTO> GetUsers();
        void UpdateUser(UserAddDTO userAddDTO);
        void DeleteUser(int id);
        void Dispose();
    }
}