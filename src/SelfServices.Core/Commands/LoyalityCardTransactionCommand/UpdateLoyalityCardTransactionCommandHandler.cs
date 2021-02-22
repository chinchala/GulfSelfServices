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
            if (command.Id is null)
                command.Id = 0;
            if (command.TxnId is null)
                command.TxnId = 0;

            await _repository.UpdateLoyaltySales(command);
            return Unit.Value;
        }
    }
}