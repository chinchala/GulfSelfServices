using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SelfServices.Core.Queries.GetLoyalityCard
{
    public class GetLoyalityCardDiscountQueryValidator : AbstractValidator<GetLoyalityCardDiscountQuery>
    {
        public GetLoyalityCardDiscountQueryValidator()
        {
            RuleFor(x => x.RFID)
                .NotEmpty();

            RuleFor(x => x.USCID)
                .NotEmpty();
        }
    }
}
