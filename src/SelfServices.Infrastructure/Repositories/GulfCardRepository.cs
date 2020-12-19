
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetGulfCard;
using SelfServices.Core.Repositories;

namespace SelfServices.Infrastructure.Repositories
{
    public class GulfCardRepository : BaseRepository, IGulfCardReposiotry
    {
        private const string ConnectionSring = "STWZ";
        public GulfCardRepository(IConfiguration config)
            : base(config.GetConnectionString(ConnectionSring))
        {

        }

        public async Task<decimal> GetCardLimit(string uscId, string rfId, int productId, bool reserve = false)
        {
            return await GetAsync<decimal>("CHECK_LIMITS",
            new
            {
                USC_ID = uscId,
                RFID = rfId,
                PRODUCT_ID = productId,
                TagPreType = reserve ? 0 : -99,
                REQIP = "192.168.88.78"
            });
        }

        public async Task<IEnumerable<FuelType>> GetFueltTypes(string uscId)
        {
            return await GetListAsync<FuelType>("", new { USC_ID = uscId });
        }
    }
}