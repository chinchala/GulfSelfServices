﻿using MediatR;

namespace SelfServices.Core.Commands.GulfClubTransactionCommand
{
    public class GulfClubTransactionCommand : IRequest
    {
        public long? Id { get; set; }
        public long? TxnId { get; set; }
        public string RfId { get; set; }
    }
}
