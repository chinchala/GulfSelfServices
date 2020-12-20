using SelfServices.Core.Commands.LoyalityCardTransaction;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Queries.GetLoyalityCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Core.Repositories
{
    public interface ILoalityCardsRepository
    {
        Task<IEnumerable<LoyalityCardDiscount>> GetDiscountsAsync(GetLoyalityCardDiscountQuery query);

        Task UpdateLoyaltySales(UpdateLoyalityCardTransactionCommand command);
    }
}
