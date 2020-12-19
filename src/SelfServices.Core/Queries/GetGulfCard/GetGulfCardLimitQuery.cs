using System.Collections.Generic;
using MediatR;

namespace SelfServices.Core.Queries.GetGulfCard
{
    public class GetGulfCardLimitQuery : IRequest<IEnumerable<GetGulfCardLimitQueryResult>>
    {
        public string UscId { get; set; }
        public string RfId { get; set; }
    }
}