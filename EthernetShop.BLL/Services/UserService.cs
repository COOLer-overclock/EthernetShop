using EthernetShop.BLL.DTO;
using EthernetShop.BLL.Interfaces;
using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthernetShop.DAL.Entities;
using AM = EthernetShop.BLL.Util;
using System.Web;

namespace EthernetShop.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork db;
        HttpContext httpContext;

        public UserService(IUnitOfWork uow, HttpContext httpContext)
        {
            this.db = uow;
            this.httpContext = httpContext;
        }
        public void AddUser(UserAddDTO userAddDTO)
        {
            if (userAddDTO != null)
            {
                User user = AM.AutoMapper.Mapper.Map<UserAddDTO, User>(userAddDTO);
                var roles = db.Roles.GetList();
                if ((roles != null) && (roles.Any(r => r.Name.ToLower() == user.Role.Name.ToLower())))
                {
                    Role role = roles.FirstOrDefault(r => r.Name.ToLower() == user.Role.Name.ToLower());
                    user.Role = role;
                    db.Users.Add(user);
                    db.Save();
                }
                else
                {
                    db.Roles.Add(user.Role);
                    db.Users.Add(user);
                }
            }
        }
        public bool UserLogIn(UserLogInDTO userLogInDTO)
        {
            if (userLogInDTO.LoginEmail.Contains("@"))
            {
                User user = FindUser(c => c.Email == userLogInDTO.LoginEmail);
                if (user != null)
                {
                    if (CheckIfPasswordCorrect(user, userLogInDTO))
                    {
                        AuthorizeUser(user);
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            else
            {
                User user = FindUser(c => c.Login == userLogInDTO.LoginEmail);
                if (user != null)
                {
                    if (CheckIfPasswordCorrect(user, userLogInDTO))
                    {
                        AuthorizeUser(user);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }
        public void UserLogOut()
        {
            httpContext.Session["IsAuthorized"] = "False";
            httpContext.Session["Id"] = null;
            httpContext.Session["Login"] = null;
            httpContext.Session["Role"] = "User";
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            return AM.AutoMapper.Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(db.Users.GetList());
        }
        public void UpdateUser(UserAddDTO userAddDTO)
        {

        }
        public void DeleteUser(int id)
        {
            db.Users.Delete(id);
        }
        public void Dispose()
        {
            db.Dispose();
        }
        private bool CheckIfPasswordCorrect(User source, UserLogInDTO desteny)
        {
            if (HashFunction.HashFunc(desteny.Password) == source.PasswordHash)
                return true;
            return false;
        }
        private User FindUser(Func<User, bool> where)
        {
            var user = db.Users.Get(where);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        private void AuthorizeUser(User user)
        {
            httpContext.Session["IsAuthorized"] = "True";
            httpContext.Session["Id"] = user.Id.ToString();
            if (user.Login.Length > 0)
                httpContext.Session["Login"] = user.Login;
            else
                httpContext.Session["Login"] = user.Email;
            httpContext.Session["Role"] = user.Role.Name;
        }
    }
}