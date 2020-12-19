using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Commands.ReserveCulfCardLimit
{
    public class ReserveCulfCardLimitCommandHandler : IRequestHandler<ReserveCulfCardLimitCommand>
    {
        private readonly IGulfCardReposiotry _repository;
        public ReserveCulfCardLimitCommandHandler(IGulfCardReposiotry repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(ReserveCulfCardLimitCommand request, CancellationToken cancellationToken)
        {
            var limit = await _repository.GetCardLimit(request.UscId, request.RfId, request.FuelId, true);
            return Unit.Value;
        }
    }
}