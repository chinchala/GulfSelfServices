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
            // CreateMap<List<LoyalityCardDiscount>, List<GetLoyalityCardDiscountQueryResult>>();
            CreateMap<LoyalityCardDiscount, GetLoyalityCardDiscountQueryResult>()
                .ForMember(x => x.FuelPrice, a => a.MapFrom(x => x.FUEL_PRICE));
        }
    }
}