using System.Collections.Generic;
using System.Threading.Tasks;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetGulfCard;

namespace SelfServices.Core.Repositories
{
    public interface IGulfCardReposiotry
    {
        Task<decimal> GetCardLimit(string uscId, string rfId, int productId, bool reserve = false);
        Task<IEnumerable<FuelType>> GetFueltTypes(string uscId);
    }
}