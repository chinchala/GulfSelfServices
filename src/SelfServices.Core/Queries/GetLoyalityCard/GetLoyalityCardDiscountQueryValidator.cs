using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SelfServices.Core.Common.BaseValidators;
using SelfServices.Core.Queries.GetGulfCard;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Queries.GetLoyalityCard
{
    public class GetLoyalityCardDiscountQueryValidator : AbstractValidator<GetLoyalityCardDiscountQuery>
    {
        public GetLoyalityCardDiscountQueryValidator(IValidationRepository repo)
        {
            RuleFor(x => x.RfId)
                .SetValidator(new RfIdValidator(repo))
                .NotEmpty();

            RuleFor(x => x.UscId)
                .SetValidator(new UscIdValidator(repo))
                .NotEmpty();
        }
    }
}
