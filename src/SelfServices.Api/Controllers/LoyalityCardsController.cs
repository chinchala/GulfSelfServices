using Microsoft.AspNetCore.Mvc;
using SelfServices.Core.Commands.LoyalityCardTransaction;
using SelfServices.Core.Queries.GetLoyalityCard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelfServices.Api.Controllers
{
    // [Authorize]
    public class LoyalityCardsController : BaseController
    {
        [HttpGet]
        [Route("GetDiscounts")]
        public async Task<IEnumerable<GetLoyalityCardDiscountQueryResult>> GetDiscount([FromQuery] GetLoyalityCardDiscountQuery query)
            => await Mediator.Send(query);

        [HttpPost]
        [Route("UpdateTransaction")]
        public async Task Transaction(UpdateLoyalityCardTransactionCommand command)
            => await Mediator.Send(command);
    }
}
