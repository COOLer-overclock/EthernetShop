using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EthernetShop.BLL.DTO;
using EthernetShop.DAL.Entities;
using EthernetShop.BLL.Services;
using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.BusinessModels;
using AM = EthernetShop.BLL.Util.AutoMapper;
using EthernetShop.BLL.Interfaces;

namespace EthernetShop.BLL.Util
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserAddDTO, User>()
                .ForMember("PasswordHash", opt => opt.MapFrom(c => HashFunction.HashFunc(c.Password)))
                .ForMember("RegistrationDate", opt => opt.MapFrom(c => DateTime.Now))
                .ForMember("Role", opt => opt.MapFrom(c => new Role { Name = c.Role }));
            CreateMap<User, UserDTO>()
                .ForMember("Role", opt => opt.MapFrom(c => c.Role.Name));
            CreateMap<CPU, CPU_DTO>()
                .ForMember("Images", opt => opt.MapFrom(c => EthernetShop.BLL.Util.AutoMapper.Mapper.Map<ICollection<ImagePath>, ICollection<string>>(c.ImagesPath)))
                .ForMember("CategoryId", x => x.MapFrom(c => c.Category.Id))
                .ForMember("CategoryName", x => x.MapFrom(c => c.Category.CategoryName));
            CreateMap<CPU_DTO, CPU>()
                .ForMember("ImagesPath", x => x.MapFrom(c => EthernetShop.BLL.Util.AutoMapper.Mapper.Map<ICollection<string>, ICollection<ImagePath>>(c.Images)))
                .ForMember("CategoryId", x => x.Ignore())
                .ForMember("Category", x => x.Ignore());
            CreateMap<string, ImagePath>()
                .ForMember("Path", opt => opt.MapFrom(c => c))
                .ForMember("Id", x => x.Ignore())
                .ForMember("ItemId", x => x.Ignore())
                .ForMember("Item", x => x.Ignore())
                .ForMember("CategoryId", x => x.Ignore())
                .ForMember("Category", x => x.Ignore());
            CreateMap<ImagePath, string>().ConvertUsing(x => x.Path);
            CreateMap<GPU, GPU_DTO>()
                .ForMember("Images", opt => opt.MapFrom(c => EthernetShop.BLL.Util.AutoMapper.Mapper.Map<ICollection<ImagePath>, ICollection<string>>(c.ImagesPath)))
                .ForMember("CategoryId", x => x.MapFrom(c => c.Category.Id))
                .ForMember("CategoryName", x => x.MapFrom(c => c.Category.CategoryName));
            CreateMap<GPU_DTO, GPU>()
                .ForMember("ImagesPath", x => x.MapFrom(c => EthernetShop.BLL.Util.AutoMapper.Mapper.Map<ICollection<string>, ICollection<ImagePath>>(c.Images)))
                .ForMember("CategoryId", x => x.Ignore())
                .ForMember("Category", x => x.Ignore());
            CreateMap<CPU, IEntityContent>()
                .ForMember("CategoryName", x => x.MapFrom(c => c.Category.CategoryName))
                .ForMember("Images", x => x.MapFrom(c => EthernetShop.BLL.Util.AutoMapper.Mapper.Map<ICollection<ImagePath>, ICollection<string>>(c.ImagesPath)));
            CreateMap<GPU, IEntityContent>()
                .ForMember("CategoryName", x => x.MapFrom(c => c.Category.CategoryName))
                .ForMember("Images", x => x.MapFrom(c => EthernetShop.BLL.Util.AutoMapper.Mapper.Map<ICollection<ImagePath>, ICollection<string>>(c.ImagesPath)));
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Order, OrderDTO>()
                .ForMember("Items", x => x.MapFrom(c => AM.Mapper.Map<ICollection<OrderItem>, ICollection<OrderItemDTO>>(c.Items)));
            CreateMap<OrderItemDTO, OrderItem>().ForMember("Id", x => x.Ignore());
            CreateMap<OrderDTO, Order>().ForMember("Items", x => x.MapFrom(c => AM.Mapper.Map<ICollection<OrderItemDTO>, ICollection<OrderItem>>(c.Items)));
            CreateMap<BasketContent, OrderItem>()
                .ForMember("Id", x => x.Ignore())
                .ForMember("ItemId", x => x.MapFrom(c => c.Id))
                .ForMember("ItemName", x => x.MapFrom(c => c.Name))
                .ForMember("Amount", x => x.MapFrom(c => c.AmountInBasket));
            CreateMap<ItemBase, BasketContent>()
                .ForMember("CategoryId", x => x.MapFrom(c => c.Category.Id))
                .ForMember("CategoryName", x => x.MapFrom(c => c.Category.CategoryName))
                .ForMember("Images", x => x.MapFrom(c => AM.Mapper.Map<ICollection<ImagePath>, ICollection<string>>(c.ImagesPath)))
                .ForMember("AmountInBasket", x => x.Ignore());
        }
    }
}