using FluentValidation;
using SelfServices.Core.Common.BaseValidators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Queries.GetGulfCard
{
    public class GetGulfCardLimitQueryValidator : AbstractValidator<GetGulfCardLimitQuery>
    {
        public GetGulfCardLimitQueryValidator(IValidationRepository repo)
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