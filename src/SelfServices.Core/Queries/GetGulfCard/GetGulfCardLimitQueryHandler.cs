using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SelfServices.Core.Models.Entities;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Queries.GetGulfCard
{
    public class GetGulfCardLimitQueryHandler : IRequestHandler<GetGulfCardLimitQuery, IEnumerable<GetGulfCardLimitQueryResult>>
    {
        private readonly IGulfCardReposiotry _repository;
        private readonly IMapper _mapper;
        public GetGulfCardLimitQueryHandler(IGulfCardReposiotry repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGulfCardLimitQueryResult>> Handle(GetGulfCardLimitQuery request, CancellationToken cancellationToken)
        {
            List<GetGulfCardLimitQueryResult> result = new List<GetGulfCardLimitQueryResult>();

            var fueltypes = await _repository.GetFueltTypes(request.UscId);
            if (fueltypes == null)
                return result;

            foreach (var fuelType in fueltypes)
            {
                var limit = await _repository.GetCardLimit(request.UscId, request.RfId, fuelType.Id);
                var limitResult = new GetGulfCardLimitQueryResult
                {
                    Limit = limit,
                    FuelId = fuelType.Id,
                    FuelName = fuelType.Name
                };
                result.Add(limitResult);
            }

            return result;
        }
    }
}