using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SelfServices.Core.Repositories;

namespace SelfServices.Infrastructure.Repositories
{
    public class ValidationRepository : BaseRepository, IValidationRepository
    {
        private const string ConnectionSring = "STWZ";
        public ValidationRepository(IConfiguration config)
            : base(config.GetConnectionString(ConnectionSring))
        {

        }
        public async Task<bool> ValidateFuelIdAsync(int fuelId)
        {
            return await GetAsync<bool>("spValidateFuelIdAsync", new { FuelId = fuelId });
        }

        public async Task<bool> ValidateRfidAsync(string rfId)
        {
            return await GetAsync<bool>("spValidateRfidAsync", new { RfId = rfId });
        }

        public async Task<bool> ValidateTransactionIdAsync(long transactionId)
        {
            return await GetAsync<bool>("spValidateTransactionIdAsync", new { TransactionId = transactionId });
        }

        public async Task<bool> ValidateUscIdAsync(string uscId)
        {
            return await GetAsync<bool>("spValidateUscIdAsync", new { UscId = uscId });
        }
    }
}