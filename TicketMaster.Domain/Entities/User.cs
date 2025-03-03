using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.ValueObjects;

namespace TicketMaster.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        public Address? Address { get; private set; }
        public bool Active { get; private set; }
    }
}
