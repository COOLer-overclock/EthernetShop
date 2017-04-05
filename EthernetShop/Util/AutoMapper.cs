using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AM = AutoMapper;

namespace EthernetShop.Util
{
    public static class AutoMapper
    {
        public static AM.IMapper Mapper;
        static AutoMapper()
        {
            var config = new AM.MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
                });
            Mapper = new AM.Mapper(config);
        }
    }
}