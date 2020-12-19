using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfServices.Core.Queries;
using SelfServices.Core.Queries.GetLoyalityCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServices.Api.Controllers
{
    // [Authorize]
    public class LoyalityCardsController : BaseController
    {
        [HttpGet]
        public async Task<IEnumerable<GetLoyalityCardDiscountQueryResult>> GetDiscount([FromQuery] GetLoyalityCardDiscountQuery query)
            => await Mediator.Send(query);
    }
}
