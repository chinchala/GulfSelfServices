using Microsoft.Extensions.Configuration;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetLoyalityCard;
using SelfServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelfServices.Infrastructure.Repositories
{
    public class LoalityCardsRepository : BaseRepository, ILoalityCardsRepository
    {
        private const string ConnectionSring = "STWZ";
        public LoalityCardsRepository(IConfiguration config)
            : base(config.GetConnectionString(ConnectionSring))
        {

        }

        public async Task<IEnumerable<LoyalityCardDiscount>> GetDiscountsAsync(GetLoyalityCardDiscountQuery query)
        {
            return await GetListAsync<LoyalityCardDiscount>("spCheckDiscounts", query);
        }
    }
}
