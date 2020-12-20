using Microsoft.Extensions.Configuration;
using SelfServices.Core.Commands.LoyalityCardTransaction;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetLoyalityCard;
using SelfServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // var discounted = await GetListAsync<LoyalityCardDiscount>("spCheckDiscounts", query);
            // var prices = await GetListAsync<FuelType>("spGetProductPricesByUscId", new { USC_ID = query.USCID });
            // discounted =discounted.Join(prices, x => x.FUELID, x => x.Id, (x, y) => { x.FUEL_PRICE = y.Price - x.FUEL_PRICE; return x; });
            // return discounted;

            return await GetListAsync<LoyalityCardDiscount>("spGetDiscounts", query);

        }

        public async Task UpdateLoyaltySales(UpdateLoyalityCardTransactionCommand command)
        {
            await ExecuteAsync("spUpdatesAfterLoyalityCardTransaction", command);
        }
    }
}
