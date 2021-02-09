using FluentValidation;
using SelfServices.Core.Common.BaseValidators;
using SelfServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Core.Commands.GulfClubTransactionCommand
{
    public class GulfClubTransactionCommandValidator : AbstractValidator<GulfClubTransactionCommand>
    {
        public GulfClubTransactionCommandValidator(IValidationRepository repo)
        {
            RuleFor(x => x.Id)
                .SetValidator(new TransactionIdValidator(repo))
                .GreaterThan(0);

            RuleFor(x => x.RfId)
                .SetValidator(new RfIdValidator(repo))
                .NotEmpty();
        }
    }
}
