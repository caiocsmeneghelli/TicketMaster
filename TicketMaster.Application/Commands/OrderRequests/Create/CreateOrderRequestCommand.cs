﻿using MediatR;
using TicketMaster.Application.DTOs;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.OrderRequests.Create
{
    public class CreateOrderRequestCommand : IRequest<Result<Guid>>
    {
        public Guid GuidMovieSession { get; set; }
        public List<TicketDto>? Tickets { get; set; }
        public  PaymentDto? Payment { get; set; }
    }
}
