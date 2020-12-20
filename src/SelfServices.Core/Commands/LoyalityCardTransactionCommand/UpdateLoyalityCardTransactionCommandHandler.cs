using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Commands.LoyalityCardTransaction
{
    public class UpdateLoyalityCardTransactionCommandHandler : IRequestHandler<UpdateLoyalityCardTransactionCommand>
    {
        private readonly ILoalityCardsRepository _repository;

        public UpdateLoyalityCardTransactionCommandHandler(ILoalityCardsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateLoyalityCardTransactionCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateLoyaltySales(command);
            return Unit.Value;
        }
    }
}