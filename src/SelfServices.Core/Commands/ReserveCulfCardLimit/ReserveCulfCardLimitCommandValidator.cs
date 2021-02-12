using FluentValidation;
using SelfServices.Core.Common.BaseValidators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Commands.ReserveCulfCardLimit
{
    public class ReserveCulfCardLimitCommandValidator : AbstractValidator<ReserveCulfCardLimitCommand>
    {
        public ReserveCulfCardLimitCommandValidator(IValidationRepository repo)
        {
            RuleFor(x => x.UscId)
                .SetValidator(new UscIdValidator(repo))
                .NotEmpty();

            RuleFor(x => x.RfId)
                .SetValidator(new RfIdValidator(repo,0))
                .NotEmpty();

            RuleFor(x => x.FuelId)
                .SetValidator(new FuelIdValidator(repo))
                .GreaterThan(0);
        }
    }
}