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
            await _repository.UpdateGulfClubSales(command.Id, command.RfId);
            return Unit.Value;
        }
    }
}
