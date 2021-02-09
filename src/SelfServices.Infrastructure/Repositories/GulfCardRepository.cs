
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetGulfCard;
using SelfServices.Core.Repositories;

namespace SelfServices.Infrastructure.Repositories
{
    public class GulfCardRepository : BaseRepository, IGulfCardRepository
    {
        private const string ConnectionSring = "STWZ";
        public GulfCardRepository(IConfiguration config)
            : base(config.GetConnectionString(ConnectionSring))
        {

        }

        public async Task<CardLimit> GetCardLimit(string uscId, string rfId, int productId, bool reserve = false)
        {
            var result = await GetAsync<CardLimit>("spCheckLimitsWithoutReservation",
            new
            {
                USC_ID = uscId,
                RFID = rfId,
                PRODUCT_ID = productId,
                TagPreType = reserve ? 0 : -99,
                REQIP = "10.10.10.245"
            });

            return result;
        }

        public async Task<IEnumerable<FuelType>> GetFuelTypes(string uscId, string rfId)
        {
            return await GetListAsync<FuelType>("spGetProductsByUscId", new { UscId = uscId, RfId = rfId });
        }

        public async Task UpdateGulfClubSales(long salesId, long TxnId, string rfId)
        {
            await ExecuteAsync("spUpdatesAfterGulfClubTransaction", new { Id = salesId, TxnId, rfId });
        }
    }
}