using MediatR;

namespace SelfServices.Core.Commands.LoyalityCardTransaction
{
    public class UpdateLoyalityCardTransactionCommand : IRequest
    {
        public long? Id { get; set; }
        public long? TxnId { get; set; }
        public string RfId { get; set; }
    }
}