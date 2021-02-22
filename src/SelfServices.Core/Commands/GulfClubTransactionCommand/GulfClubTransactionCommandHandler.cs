using MediatR;
using SelfServices.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SelfServices.Core.Commands.GulfClubTransactionCommand
{
    public class GulfClubTransactionCommandHandler : IRequestHandler<GulfClubTransactionCommand>
    {
        private readonly IGulfCardRepository _repository;

        public GulfClubTransactionCommandHandler(IGulfCardRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(GulfClubTransactionCommand command, CancellationToken cancellationToken)
        {
            if (command.Id is null)
                command.Id = 0;
            if (command.TxnId is null)
                command.TxnId = 0;


            await _repository.UpdateGulfClubSales(command.Id, command.TxnId, command.RfId);
            return Unit.Value;
        }
    }
}
