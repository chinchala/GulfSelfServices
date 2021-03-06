using FluentValidation;
using SelfServices.Core.Common.BaseValidators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Commands.LoyalityCardTransaction
{
    public class UpdateLoyalityCardTransactionCommandValidator : AbstractValidator<UpdateLoyalityCardTransactionCommand>
    {
        public UpdateLoyalityCardTransactionCommandValidator(IValidationRepository repo)
        {
            //RuleFor(x => x.Id)
            //    .SetValidator(new TransactionIdValidator(repo))
            //    .GreaterThan(0);

            RuleFor(x => x.TxnId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.RfId)
                .SetValidator(new RfIdValidator(repo, 1))
                .NotEmpty();
        }
    }
}