using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfServices.Core.Commands.ReserveCulfCardLimit;
using SelfServices.Core.Queries.GetGulfCard;

namespace SelfServices.Api.Controllers
{
    public class GulfCardsController : BaseController
    {
        [HttpGet]
        [Route("GetCardLimits")]
        public async Task<IEnumerable<GetGulfCardLimitQueryResult>> GetCardLimits([FromQuery]GetGulfCardLimitQuery query)
            => await Mediator.Send(query);

        [HttpPost]
        [Route("ReserveCardLimits")]
        public async Task ReserveCardLimits(ReserveCulfCardLimitCommand command)
            => await Mediator.Send(command);
    }
}