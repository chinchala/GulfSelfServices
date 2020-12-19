using FluentValidation;

namespace SelfServices.Core.Commands.LoyalityCardTransaction
{
    public class UpdateLoyalityCardTransactionCommandValidator : AbstractValidator<UpdateLoyalityCardTransactionCommand>
    {
        public UpdateLoyalityCardTransactionCommandValidator()
        {
            RuleFor(x=>x.Id)
                .GreaterThan(0);

            RuleFor(x=>x.RfId)
                .NotEmpty();
        }
    }
}