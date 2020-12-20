using System.Collections.Generic;
using System.Threading.Tasks;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetGulfCard;

namespace SelfServices.Core.Repositories
{
    public interface IGulfCardRepository
    {
        Task<CardLimit> GetCardLimit(string uscId, string rfId, int productId, bool reserve = false);
        Task<IEnumerable<FuelType>> GetFuelTypes(string uscId);
        Task UpdateGulfClubSales(long salesId, string rfId);
    }
}