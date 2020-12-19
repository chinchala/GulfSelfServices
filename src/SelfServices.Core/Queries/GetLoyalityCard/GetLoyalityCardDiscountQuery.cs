using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Core.Queries.GetLoyalityCard
{
    public class GetLoyalityCardDiscountQuery : IRequest<IEnumerable<GetLoyalityCardDiscountQueryResult>>
    {
        public string RFID { get; set; }
        public string USCID { get; set; }
    }
}
