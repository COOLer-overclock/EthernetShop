using AutoMapper;
using EthernetShop.BLL.DTO;
using EthernetShop.BLL.DTO.Content;
using EthernetShop.Models;
using EthernetShop.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthernetShop.Util
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserAddViewModel, UserAddDTO>();
            CreateMap<UserLogInViewModel, UserLogInDTO>();
            CreateMap<UserDTO, UserShowViewModel>();
            CreateMap<CPU_DTO, CPUViewModel>();
            CreateMap<CPUViewModel, CPU_DTO>();
            CreateMap<GPU_DTO, GPUViewModel>();
            CreateMap<GPUViewModel, GPU_DTO>();
            CreateMap<OrderCreateViewModel, OrderDTO>();
            CreateMap<UserDTO, SignalRUser>().ForMember("SignalRId", x => x.UseValue<object>(null));
        }
    }
}