using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EthernetShop.Models;
using EthernetShop.BLL.DTO;
using EthernetShop.DAL.Entities;
using EthernetShop.BLL.Services;

namespace EthernetShop.InitializationAutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public static void InitializeAutomapper()
        {
            Mapper.Initialize(x => { x.AddProfile<EthernetShop.BLL.Util.AutoMapperProfile>();
                x.AddProfile<EthernetShop.Util.AutoMapperProfile>(); });
            Mapper.Initialize(x => x.CreateMap<User, UserDTO>()
                .ForMember("Role", opt => opt.MapFrom(c => c.Role.Name)));
        }
        protected override void Configure()
        {
            CreateMap<UserAddDTO, User>()
                        .ForMember("PasswordHash", opt => opt.MapFrom(c => HashFunction.HashFunc(c.Password)))
                        .ForMember("RegistrationDate", opt => opt.MapFrom(c => DateTime.Now))
                        .ForMember("Role", opt => opt.MapFrom(c => new Role { Name = c.Role }));
            CreateMap<User, UserDTO>()
                .ForMember("Role", opt => opt.MapFrom(c => c.Role.Name));
        }
    }
}
