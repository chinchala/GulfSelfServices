﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SelfServices.Core.Queries.GetGulfCard;

namespace SelfServices.Core.Queries.GetLoyalityCard
{
    public class GetLoyalityCardDiscountQueryValidator : AbstractValidator<GetLoyalityCardDiscountQuery>
    {
        public GetLoyalityCardDiscountQueryValidator()
        {
            // Include<GetGulfCardLimitQueryValidator>();
            RuleFor(x => x.RfId)
                .NotEmpty();

            RuleFor(x => x.UscId)
                .NotEmpty();
        }
    }
}
