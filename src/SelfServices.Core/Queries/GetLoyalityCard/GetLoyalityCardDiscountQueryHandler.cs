using AutoMapper;
using MediatR;
using SelfServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfServices.Core.Queries.GetLoyalityCard
{
    public class GetLoyalityCardDiscountQueryHandler : IRequestHandler<GetLoyalityCardDiscountQuery, IEnumerable<GetLoyalityCardDiscountQueryResult>>
    {
        private readonly ILoalityCardsRepository _repository;
        private readonly IMapper _mapper;

        public GetLoyalityCardDiscountQueryHandler(ILoalityCardsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetLoyalityCardDiscountQueryResult>> Handle(GetLoyalityCardDiscountQuery query, CancellationToken cancellationToken)
        {
            var list = await _repository.GetDiscountsAsync(query);
            return _mapper.Map<List<GetLoyalityCardDiscountQueryResult>>(list.ToList());
        }
    }
}
