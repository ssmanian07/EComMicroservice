using AutoMapper;
using ECom.Services.CouponAPI.Models;
using ECom.Services.CouponAPI.Models.Dto;

namespace ECom.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
