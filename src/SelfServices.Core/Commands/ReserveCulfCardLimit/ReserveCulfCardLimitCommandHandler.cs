using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Commands.ReserveCulfCardLimit
{
    public class ReserveCulfCardLimitCommandHandler : IRequestHandler<ReserveCulfCardLimitCommand>
    {
        private readonly IGulfCardRepository _repository;
        public ReserveCulfCardLimitCommandHandler(IGulfCardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(ReserveCulfCardLimitCommand request, CancellationToken cancellationToken)
        {
            var limit = await _repository.GetCardLimit(request.UscId, request.RfId, request.FuelId, true);
            if (limit.Result != "OK")
                throw new System.Exception(limit.Result);
            return Unit.Value;
        }
    }
}