﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queies.Auditoriums.GetAll
{
    public class GetAllAuditoriumsQuery : IRequest<List<Auditorium>>
    {
    }
}
