using System.Collections.Generic;
using AutoMapper;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetLoyalityCard;

namespace SelfServices.Core.Mapping
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<LoyalityCardDiscount, GetLoyalityCardDiscountQueryResult>();
            // .ForMember(x => x.Discount, a => a.MapFrom(x => x.FUEL_PRICE));
        }
    }
}