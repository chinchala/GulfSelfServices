using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SelfServices.Core.Commands.LoyalityCardTransaction
{
    public class UpdateLoyalityCardTransactionCommandHandler : IRequestHandler<UpdateLoyalityCardTransactionCommand>
    {
        public async Task<Unit> Handle(UpdateLoyalityCardTransactionCommand request, CancellationToken cancellationToken)
        {
            
            return Unit.Value;
        }
    }
}