using MediatR;

namespace SelfServices.Core.Commands.ReserveCulfCardLimit
{
    public class ReserveCulfCardLimitCommand : IRequest
    {
        public string UscId { get; set; }
        public string RfId { get; set; }
        public int FuelId { get; set; }
    }
}