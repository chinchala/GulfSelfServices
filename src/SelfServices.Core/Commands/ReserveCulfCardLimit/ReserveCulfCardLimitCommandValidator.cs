using FluentValidation;

namespace SelfServices.Core.Commands.ReserveCulfCardLimit
{
    public class ReserveCulfCardLimitCommandValidator : AbstractValidator<ReserveCulfCardLimitCommand>
    {
        public ReserveCulfCardLimitCommandValidator()
        {
            RuleFor(x => x.UscId)
                .NotEmpty();

            RuleFor(x => x.RfId)
                .NotEmpty();

            RuleFor(x => x.FuelId)
                .GreaterThan(0);
        }
    }
}