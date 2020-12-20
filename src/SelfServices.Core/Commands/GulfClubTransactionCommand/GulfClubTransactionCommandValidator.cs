using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Core.Commands.GulfClubTransactionCommand
{
    public class GulfClubTransactionCommandValidator : AbstractValidator<GulfClubTransactionCommand>
    {
        public GulfClubTransactionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.RfId)
                .NotEmpty();
        }
    }
}
