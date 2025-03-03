using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.ValueObjects
{
    public record Address
    {
        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        [Required]
        public string Street { get; private set; }
        [Required]
        public string City { get; private set; }
        [Required]
        public string State { get; private set; }
        [Required]
        public string Country { get; private set; }
    }
}
