using System.Threading.Tasks;

namespace SelfServices.Core.Repositories
{
    public interface IValidationRepository
    {
        Task<bool> ValidateRfidAsync(string rfId);
        Task<bool> ValidateUscIdAsync(string uscId);
        Task<bool> ValidateFuelIdAsync(int fuelId);
        Task<bool> ValidateTransactionIdAsync(long transactionId);
    }
}